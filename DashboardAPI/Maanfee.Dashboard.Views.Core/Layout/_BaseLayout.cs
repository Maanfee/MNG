using Maanfee.JsInterop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Maanfee.Dashboard.Views.Core
{
    public class _BaseLayout : LayoutComponentBase
    {
        [Inject]
        protected virtual LocalConfigurationService? LocalConfiguration { get; set; }

        [Inject]
        protected virtual NavigationManager? Navigation { get; set; }

        [Inject]
        protected virtual LocalStorage? LocalStorage { get; set; }

        [Inject]
        protected virtual Fullscreen? Fullscreen { get; set; }

        [Inject]
        protected virtual ISnackbar? Snackbar { get; set; }

        [Inject]
        protected virtual IDialogService? Dialog { get; set; }

        [CascadingParameter]
        protected Task<AuthenticationState>? AuthenticationState { get; set; }

        //[Inject]
        //protected virtual IAuthorizationService? AuthorizationService { get; set; }

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
