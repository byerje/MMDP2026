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

    // When this tab becomes visible again:
    // 1. Check localStorage for a pending toast from another tab
    // 2. Notify Blazor to reconnect SignalR and re-sync state
    //    (iOS Safari kills WebSocket connections in background tabs)
    document.addEventListener('visibilitychange', function() {
        if (document.visibilityState === 'visible' && _onAssignmentsUpdated) {
            // Check for pending toast
            var raw = localStorage.getItem('pendingToast');
            if
