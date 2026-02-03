using Maanfee.JsInterop;
using MudBlazor;

namespace Maanfee.Dashboard.Views.Core
{
    public class LocalConfigurationService
    {
        public LocalConfigurationService(LocalStorage localStorage)
        {
            LocalStorage = localStorage;
        }

        public LocalStorage LocalStorage;
        private const string ConfigurationStoredName = "ConfigurationStorage";

        public async Task InitConfigurationAsync(LanguageService.SupportedCountry DefaultLanguage)
        {
            var StoredConfiguration = await LocalStorage.GetAsync<LayoutSettingsModel>(ConfigurationStoredName);
            if (StoredConfiguration == null)
            {
                LayoutSettingsModel LayoutSettings = CreateDefaultConfiguration(LanguageService.GetCultureCode(DefaultLanguage));
                await LocalStorage.SetAsync<LayoutSettingsModel>(ConfigurationStoredName, LayoutSettings);

                SharedLayoutSettings.IsDarkMode = LayoutSettings.IsDarkMode;
                SharedLayoutSettings.IsRTL = LayoutSettings.IsRTL;
                SharedLayoutSettings.ThemeColor = new PaletteLight().Primary.Value;
                SharedLayoutSettings.CurrentVersion = LayoutSettings.CurrentVersion;
                SharedLayoutSettings.IsFullscreenMode = LayoutSettings.IsFullscreenMode;
                SharedLayoutSettings.CultureCode = LayoutSettings.CultureCode;
            }
            else
            {
                SharedLayoutSettings.IsDarkMode = StoredConfiguration.IsDarkMode;
                SharedLayoutSettings.IsRTL = StoredConfiguration.IsRTL;
                SharedLayoutSettings.ThemeColor = StoredConfiguration.ThemeColor;
                SharedLayoutSettings.CurrentVersion = StoredConfiguration.CurrentVersion;
                SharedLayoutSettings.IsFullscreenMode = StoredConfiguration.IsFullscreenMode;
                SharedLayoutSettings.CultureCode = StoredConfiguration.CultureCode;
            }
        }

        public async Task SetConfigurationAsync()
        {
            await LocalStorage.SetAsync<LayoutSettingsModel>(ConfigurationStoredName, new LayoutSettingsModel()
            {
                IsDarkMode = SharedLayoutSettings.IsDarkMode,
                IsRTL = SharedLayoutSettings.IsRTL,
                ThemeColor = SharedLayoutSettings.ThemeColor,
                CurrentVersion = SharedLayoutSettings.CurrentVersion,
                IsFullscreenMode = SharedLayoutSettings.IsFullscreenMode,
                CultureCode = SharedLayoutSettings.CultureCode,
            });
        }

        private LayoutSettingsModel CreateDefaultConfiguration(string defaultLanguageCode)
        {
            return new LayoutSettingsModel
            {
                IsDarkMode = false,
                IsRTL = false,
                ThemeColor = new PaletteLight().Primary.Value,
                CurrentVersion = string.Empty,
                IsFullscreenMode = false,
                CultureCode = defaultLanguageCode,
            };
        }

    }
}
