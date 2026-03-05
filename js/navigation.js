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

            // Show a toast notification forwarded from another tab.
            // Delay slightly so the tab has time to come to the foreground
            // (Android Chrome throttles background tab JS).
            if (event.data && event.data.type === 'toast') {
                setTimeout(function() {
                    if (_onAssignmentsUpdated) {
                        _onAssignmentsUpdated.invokeMethodAsync('ShowToast', event.data.message, event.data.style);
                    }
                }, 600);
            }
        });
    }

    // Called by App.razor to register a callback for assignment refreshes.
    // Always defined so it never throws, even without BroadcastChannel.
    window.registerAssignmentRefresh = function(dotNetRef) {
        _onAssignmentsUpdated = dotNetRef;
    };

    // Send a toast message to all other tabs (no-op without BroadcastChannel)
    window.sendToastToOtherTabs = function(message, style) {
        if (channel) {
            channel.postMessage({ type: 'toast', message: message, style: style });
        }
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
