namespace MindAttic.Core.Shared.Interfaces;

public interface ISettingsProvider
{
    Task<T?> GetAsync<T>(string key);
    Task SetAsync<T>(string key, T value);
    Task RemoveAsync(string key);
    Task SaveAsync();
    Task LoadAsync();
}
