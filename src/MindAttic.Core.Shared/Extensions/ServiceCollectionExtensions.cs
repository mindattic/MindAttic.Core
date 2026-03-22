using Microsoft.Extensions.DependencyInjection;
using MindAttic.Core.Shared.Interfaces;
using MindAttic.Core.Shared.Services;

namespace MindAttic.Core.Shared.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMindAtticCoreShared(this IServiceCollection services)
    {
        services.AddSingleton<IThemeService, ThemeService>();
        services.AddSingleton<AppearanceSettings>();
        return services;
    }
}
