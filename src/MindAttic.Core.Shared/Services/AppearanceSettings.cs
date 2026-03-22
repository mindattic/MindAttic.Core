using MindAttic.Core.Shared.Interfaces;

namespace MindAttic.Core.Shared.Services;

public class AppearanceSettings
{
    private readonly ISecurePreferences _preferences;

    public int ControlHeight { get; private set; } = 40;
    public int Gutter { get; private set; } = 10;
    public int BorderRadius { get; private set; } = 6;

    public event Action? Changed;

    public AppearanceSettings(ISecurePreferences preferences)
    {
        _preferences = preferences;
    }

    public async Task InitializeAsync()
    {
        ControlHeight = await GetIntAsync("APP_CONTROL_HEIGHT", 40);
        Gutter = await GetIntAsync("APP_GUTTER", 10);
        BorderRadius = await GetIntAsync("APP_BORDER_RADIUS", 6);
    }

    public async Task SetControlHeightAsync(int height)
    {
        ControlHeight = Math.Clamp(height, 24, 64);
        await _preferences.SetAsync("APP_CONTROL_HEIGHT", ControlHeight.ToString());
        Changed?.Invoke();
    }

    public async Task SetGutterAsync(int px)
    {
        Gutter = Math.Clamp(px, 0, 32);
        await _preferences.SetAsync("APP_GUTTER", Gutter.ToString());
        Changed?.Invoke();
    }

    public async Task SetBorderRadiusAsync(int px)
    {
        BorderRadius = Math.Clamp(px, 0, 20);
        await _preferences.SetAsync("APP_BORDER_RADIUS", BorderRadius.ToString());
        Changed?.Invoke();
    }

    private async Task<int> GetIntAsync(string key, int defaultValue)
    {
        try
        {
            var value = await _preferences.GetAsync(key);
            return int.TryParse(value, out var result) ? result : defaultValue;
        }
        catch
        {
            return defaultValue;
        }
    }
}
