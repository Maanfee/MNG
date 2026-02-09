using Maanfee.JsInterop;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Maanfee.Dashboard.Views.Core
{
    public class _BaseLayout : LayoutComponentBase
    {
        [Inject]
        protected LocalConfigurationService? LocalConfiguration { get; set; }

        [Inject]
        protected NavigationManager? Navigation { get; set; }

        [Inject]
        protected LocalStorage? LocalStorage { get; set; }

        [Inject]
        protected Fullscreen? Fullscreen { get; set; }

        [Inject]
        protected ISnackbar? Snackbar { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            SharedLayoutSettings.Theme = MaanfeeTheme.ThemeBuilder(SharedLayoutSettings.Theme.PaletteLight.Primary
                , SharedLayoutSettings.SelectedFont?.FontName);

            SnakbarDirectionConfiguration();
        }

        // ******************************************************

        private void SnakbarDirectionConfiguration()
        {
            Snackbar?.Configuration.PositionClass = (SharedLayoutSettings.IsRTL) ? Defaults.Classes.Position.BottomStart : Defaults.Classes.Position.BottomEnd;
        }

    }
}
