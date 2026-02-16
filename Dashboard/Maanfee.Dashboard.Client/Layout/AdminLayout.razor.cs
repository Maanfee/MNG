using Maanfee.Dashboard.Resources;
using Maanfee.Dashboard.Views.Core;
using MudBlazor;

namespace Maanfee.Dashboard.Client.Layout
{
    public partial class AdminLayout : _BaseLayout//, IDisposable
    {
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Fullscreen?.FullscreenChanged += OnFullscreenChange;
            //if (SharedLayoutSettings.IsFullscreenMode)
            //{
            //    await Fullscreen!.ToggleFullscreenAsync();
            //}

            Snackbar?.Add($"{DashboardResource.StringWelcome}", Severity.Success);
        }

        // ******************************************************

        private bool DrawerOpen = true;

        // ******************************************************

        private async Task ToggleDarkMode()
        {
            if (SharedLayoutSettings.IsDarkMode)
            {
                SharedLayoutSettings.IsDarkMode = false;
            }
            else
            {
                SharedLayoutSettings.IsDarkMode = true;
            }

            await LocalConfiguration!.SetConfigurationAsync();
        }

        private async Task ToggleDirection()
        {
            if (SharedLayoutSettings.IsRTL)
            {
                SharedLayoutSettings.IsRTL = false;
            }
            else
            {
                SharedLayoutSettings.IsRTL = true;
            }

            await LocalConfiguration!.SetConfigurationAsync();
        }

        private async Task ToggleFullscrren(bool Toggled)
        {
            if (Toggled)
            {
                await Fullscreen!.ToggleFullscreenAsync();
            }
            else
            {
                await Fullscreen!.ExitFullscreenAsync();
            }
        }

        private async void OnFullscreenChange(object? sender, bool isFullscreen)
        {
            //TableHeight = TableConfiguration.SetHeight(SharedLayoutSettings.IsRTL, await Fullscreen.IsFullscreenAsync(), _IsTableScroll);

            SharedLayoutSettings.IsFullscreenMode = isFullscreen;
            await LocalConfiguration!.SetConfigurationAsync();

            await InvokeAsync(StateHasChanged);
        }

        // ******************************************************

        #region - Theme Manager -

        private bool IsThemeManagerOpen;

        protected async Task OnThemingDrawerOpenChanged(bool state)
        {
            IsThemeManagerOpen = state;
            // Save for fullscreen mode
            if (!state)
            {
                await LocalConfiguration!.SetConfigurationAsync();
            }

            await InvokeAsync(StateHasChanged);
        }

        private async Task UpdateUserPreferences(MudTheme Theme)
        {
            //SharedLayoutSettings.Theme = MaanfeeTheme.ThemeBuilder(Color, SharedLayoutSettings.SelectedFont?.FontName);
            await InvokeAsync(StateHasChanged);
        }

        #endregion

        //public void Dispose()
        //{
        //    Fullscreen.OnFullscreenChange -= OnFullscreenChange;
        //}

    }
}
