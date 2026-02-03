using Maanfee.Dashboard.Views.Core;
using Maanfee.JsInterop;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MudBlazor;
using MudBlazor.Services;

namespace Maanfee.Dashboard
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMaanfeeDashboardServiceManager(this IServiceCollection services)
        {
            // MudBlazor
            #region MudBlazor Snackbar Configuration

            services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;

                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = false;
                config.SnackbarConfiguration.ShowCloseIcon = false;
                config.SnackbarConfiguration.VisibleStateDuration = 5000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });

            #endregion

            // JsInterop
            services.AddMaanfeeJsInterop();
          
            // CSR
            if (OperatingSystem.IsBrowser())
            {
                // Dashboard Configuration
                services.TryAddSingleton<LocalConfigurationService>();
            }
            // SSR
            else
            {
                // Dashboard Configuration
                services.TryAddScoped<LocalConfigurationService>();
            }

            return services;
        }
    }
}
