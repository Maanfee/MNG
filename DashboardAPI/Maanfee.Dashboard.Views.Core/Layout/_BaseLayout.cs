using Maanfee.JsInterop;
using Microsoft.AspNetCore.Components;
using MudBlazor;

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

        protected virtual async Task OpenInformationDialog()
        {
            DialogParameters DialogParameters = new DialogParameters();
            DialogParameters.Add("ComponentName", this.GetType().Name);
            DialogParameters.Add("ComponentFullName", this.GetType().FullName!);

            await Dialog!.ShowAsync<InformationDialog>(string.Empty, DialogParameters,
                 new DialogOptions()
                 {
                     NoHeader = true,
                     MaxWidth = MaxWidth.Small,
                     FullWidth = true,
                     Position = DialogPosition.Center,
                     BackgroundClass = "Dialog-Blur",
                     CloseOnEscapeKey = true,
                 });
        }

    }
}
