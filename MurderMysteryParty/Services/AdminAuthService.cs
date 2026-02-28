using Microsoft.JSInterop;

namespace MurderMysteryParty.Services;

public class AdminAuthService
{
    private const string StorageKey = "admin-authenticated";
    private readonly IConfiguration _configuration;
    private readonly IJSRuntime _jsRuntime;
    private bool _initialized;

    public AdminAuthService(IConfiguration configuration, IJSRuntime jsRuntime)
    {
        _configuration = configuration;
        _jsRuntime = jsRuntime;
    }

    public bool IsAuthenticated { get; private set; }

    public event Action? OnChange;

    public async Task InitializeAsync()
    {
        if (_initialized)
        {
            return;
        }

        var storedValue = await _jsRuntime.InvokeAsync<string?>("sessionStorage.getItem", StorageKey);
        IsAuthenticated = string.Equals(storedValue, "true", StringComparison.OrdinalIgnoreCase);
        _initialized = true;
    }

    public async Task<bool> LoginAsync(string password)
    {
        var configuredPassword = _configuration["Admin:Password"];
        if (string.IsNullOrWhiteSpace(configuredPassword))
        {
            return false;
        }

        if (!string.Equals(password, configuredPassword, StringComparison.Ordinal))
        {
            return false;
        }

        IsAuthenticated = true;
        await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", StorageKey, "true");
        OnChange?.Invoke();
        return true;
    }

    public async Task LogoutAsync()
    {
        IsAuthenticated = false;
        await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", StorageKey);
        OnChange?.Invoke();
    }
}
