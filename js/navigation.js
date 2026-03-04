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

// BroadcastChannel for coordinating QR code scans across tabs.
// When a QR code is scanned on a phone that already has the app open,
// the existing tab handles the navigation instead of opening a duplicate.
(function() {
    if (typeof BroadcastChannel === 'undefined') return;

    var channel = new BroadcastChannel('mmdp-tab-coordinator');

    // Listen for requests from newly opened tabs
    channel.addEventListener('message', function(event) {
        if (event.data && event.data.type === 'qr-navigate') {
            // Another tab is asking us to navigate - focus this tab and go to the URL
            window.focus();
            window.location.href = event.data.url;
            // Tell the new tab we handled it
            channel.postMessage({ type: 'qr-handled' });
        }
    });

    // Expose for Blazor interop
    window.mmdpTabCoordinator = {
        // Called from the new tab to ask existing tabs to handle the URL.
        // Returns a promise that resolves to true if an existing tab handled it.
        requestExistingTab: function(url) {
            return new Promise(function(resolve) {
                var handled = false;

                function onResponse(event) {
                    if (event.data && event.data.type === 'qr-handled') {
                        handled = true;
                        channel.removeEventListener('message', onResponse);
                        resolve(true);
                    }
                }

                channel.addEventListener('message', onResponse);
                channel.postMessage({ type: 'qr-navigate', url: url });

                // If no response within 500ms, no existing tab is open
                setTimeout(function() {
                    if (!handled) {
                        channel.removeEventListener('message', onResponse);
                        resolve(false);
                    }
                }, 500);
            });
        }
    };

    // Auto-detect QR code scan: if the URL contains ?assign=true (or &assign=true),
    // try handing off to an existing tab immediately before Blazor loads.
    if (window.location.search.indexOf('assign=true') !== -1) {
        window.mmdpTabCoordinator.requestExistingTab(window.location.href).then(function(handled) {
            if (handled) {
                // An existing tab navigated to the URL. Try to close this duplicate tab.
                try {
                    window.close();
                } catch (e) {
                    // ignore
                }
                // If window.close() didn't work (browser restriction), replace the page
                // with a simple message so the user knows to close it manually.
                setTimeout(function() {
                    document.body.innerHTML =
                        '<div style="display:flex;align-items:center;justify-content:center;height:100vh;' +
                        'background:#1a1a1a;color:#f5f5dc;font-family:sans-serif;text-align:center;padding:20px;">' +
                        '<div>' +
                        '<h2 style="color:#d4af37;">? Opened in your existing tab</h2>' +
                        '<p>You can close this tab.</p>' +
                        '</div></div>';
                }, 300);
            }
        });
    }
})();
