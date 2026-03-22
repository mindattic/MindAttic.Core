namespace MindAttic.Core.Shared.Interfaces;

public interface IThemeService
{
    string CurrentTheme { get; }
    IReadOnlyList<string> AvailableThemes { get; }
    event Action? ThemeChanged;
    Task InitializeAsync();
    Task<string> GetThemeAsync();
    Task SetThemeAsync(string theme);
}
