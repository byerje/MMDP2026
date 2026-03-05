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
(function() {
    if (typeof BroadcastChannel === 'undefined') return;

    var channel = new BroadcastChannel('mmdp-tab-ping');

    // Every tab listens for pings and responds
    channel.addEventListener('message', function(event) {
        if (event.data === 'ping') {
            channel.postMessage('pong');
        }
    });

    // Exposed for Blazor interop — returns true if another tab is open
    window.hasOtherTabOpen = function() {
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
