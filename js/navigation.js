window.isPageRefresh = function() {
    // Check if this is a page refresh using Navigation Timing API
    if (performance && performance.getEntriesByType) {
        const navEntries = performance.getEntriesByType("navigation");
        if (navEntries.length > 0) {
            return navEntries[0].type === "reload";
        }
    }
    
    // Fallback for older browsers
    if (performance && performance.navigation) {
        return performance.navigation.type === 1;
    }
    
    return false;
};

window.getCurrentPath = function() {
    return window.location.pathname;
};

// Lightweight tab-awareness using BroadcastChannel.
// Tabs respond to pings so a QR-scan tab can check if another tab exists
// before attempting to close itself.
// BroadcastChannel is supported on Chrome, Edge, Firefox, and Safari 15.4+.
// On unsupported browsers, these functions are no-ops and the QR-scan tab
// simply stays open (safe fallback).
(function() {
    var channel = (typeof BroadcastChannel !== 'undefined')
        ? new BroadcastChannel('mmdp-tab-ping')
        : null;
    var _onAssignmentsUpdated = null;

    if (channel) {
        // Every tab listens for pings and responds.
        // After responding, notify Blazor to refresh assignments from localStorage
        // since the pinging tab just completed a QR-scan assignment.
        channel.addEventListener('message', function(event) {
            if (event.data === 'ping') {
                channel.postMessage('pong');
                // Give the other tab a moment to finish writing localStorage
                setTimeout(function() {
                    if (_onAssignmentsUpdated) {
                        _onAssignmentsUpdated.invokeMethodAsync('RefreshAssignments');
                    }
                }, 500);
            }
        });
    }

    // When this tab becomes visible again, check localStorage for a pending toast.
    // This is more reliable than BroadcastChannel for background tabs on Android.
    document.addEventListener('visibilitychange', function() {
        if (document.visibilityState === 'visible' && _onAssignmentsUpdated) {
            var raw = localStorage.getItem('pendingToast');
            if (raw) {
                localStorage.removeItem('pendingToast');
                try {
                    var data = JSON.parse(raw);
                    _onAssignmentsUpdated.invokeMethodAsync('ShowToast', data.message, data.style);
                } catch(e) { /* ignore corrupt data */ }
            }
        }
    });

    // Called by App.razor to register a callback for assignment refreshes.
    // Always defined so it never throws, even without BroadcastChannel.
    window.registerAssignmentRefresh = function(dotNetRef) {
        _onAssignmentsUpdated = dotNetRef;
    };

    // Write a toast to localStorage so the other tab picks it up when it becomes visible.
    window.sendToastToOtherTabs = function(message, style) {
        localStorage.setItem('pendingToast', JSON.stringify({ message: message, style: style }));
    };

    // Returns true if another tab is open (always false without BroadcastChannel)
    window.hasOtherTabOpen = function() {
        if (!channel) {
            return Promise.resolve(false);
        }
        return new Promise(function(resolve) {
            var found = false;

            function onPong(event) {
                if (event.data === 'pong') {
                    found = true;
                    channel.removeEventListener('message', onPong);
                    resolve(true);
                }
            }

            channel.addEventListener('message', onPong);
            channel.postMessage('ping');

            setTimeout(function() {
                if (!found) {
                    channel.removeEventListener('message', onPong);
                    resolve(false);
                }
            }, 300);
        });
    };
})();
