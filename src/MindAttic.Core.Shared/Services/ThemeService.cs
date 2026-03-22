using MindAttic.Core.Shared.Interfaces;

namespace MindAttic.Core.Shared.Services;

public class ThemeService : IThemeService
{
    private const string ThemeKey = "APP_THEME";
    private const string DefaultTheme = "Light";

    private readonly ISecurePreferences _preferences;

    public string CurrentTheme { get; private set; } = DefaultTheme;

    public IReadOnlyList<string> AvailableThemes { get; } =
    [
        "Light", "Dark", "Spring", "Summer", "Autumn", "Winter",
        "Matrix", "Ice", "Sunset", "Neon", "Dracula", "Solarized", "Midnight"
    ];

    public event Action? ThemeChanged;

    public ThemeService(ISecurePreferences preferences)
    {
        _preferences = preferences;
    }

    public async Task InitializeAsync()
    {
        CurrentTheme = await GetThemeAsync();
    }

    public async Task<string> GetThemeAsync()
    {
        try
        {
            var theme = await _preferences.GetAsync(ThemeKey);
            return string.IsNullOrEmpty(theme) ? DefaultTheme : theme;
        }
        catch
        {
            return DefaultTheme;
        }
    }

    public async Task SetThemeAsync(string theme)
    {
        if (!AvailableThemes.Contains(theme))
            theme = DefaultTheme;

        await _preferences.SetAsync(ThemeKey, theme);
        CurrentTheme = theme;
        ThemeChanged?.Invoke();
    }
}
