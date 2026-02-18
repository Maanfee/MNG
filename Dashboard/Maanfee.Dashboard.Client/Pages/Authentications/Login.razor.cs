using Maanfee.Dashboard.Core;
using Maanfee.Dashboard.Domain.ViewModels;
using MudBlazor;

namespace Maanfee.Dashboard.Client.Pages.Authentications
{
    public partial class Login
    {
        private bool PasswordVisibility;
        private InputType PasswordInput = InputType.Password;
        private string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

        private LoginViewModel LoginViewModelSubmit = new();
        private bool IsProcessing = false;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        private void TogglePasswordVisibility()
        {
            if (PasswordVisibility)
            {
                PasswordVisibility = false;
                PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                PasswordInput = InputType.Password;
            }
            else
            {
                PasswordVisibility = true;
                PasswordInputIcon = Icons.Material.Filled.Visibility;
                PasswordInput = InputType.Text;
            }
        }

        private async Task OnSubmit()
        {
            if (IsProcessing)
                return;
            IsProcessing = true;

            try
            {
                await AuthenticationStateProvider.Login(LoginViewModelSubmit.TrimStringAndCheckPersianSpecialLetter() ?? new LoginViewModel());
                Navigation?.NavigateTo("/0");
            }
            catch (Exception ex)
            {
                Snackbar?.Add(ex.Message, Severity.Error);

                //if (LoggingHubConnection is not null)
                //{
                //    await LoggingHubConnection.SendAsync("SendMessageAsync", new LogInfo
                //    {
                //        IdLoggingPlatform = LoggingPlatformDefaultValue.Client,
                //        Message = $"{ex.Message}",
                //        LogDate = DateTime.Now,
                //        IdLoggingLevel = LoggingLevelDefaultValue.Error,
                //    });
                //}
            }
            finally
            {
                IsProcessing = false;
            }
        }

    }
}
