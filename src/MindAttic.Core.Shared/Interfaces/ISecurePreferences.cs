namespace MindAttic.Core.Shared.Interfaces;

public interface ISecurePreferences
{
    Task<string?> GetAsync(string key);
    Task SetAsync(string key, string value);
    Task RemoveAsync(string key);
    Task<bool> ContainsKeyAsync(string key);
}
