using MudBlazor;

namespace Maanfee.Dashboard.Views.Core
{
    public class _BaseView : _BaseLayout
    {
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
