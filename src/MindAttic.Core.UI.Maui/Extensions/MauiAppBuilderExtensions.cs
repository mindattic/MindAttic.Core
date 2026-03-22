using MindAttic.Core.Shared.Extensions;

namespace MindAttic.Core.UI.Maui.Extensions;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder UseMindAtticCore(this MauiAppBuilder builder)
    {
        builder.Services.AddMindAtticCoreShared();
        return builder;
    }
}
