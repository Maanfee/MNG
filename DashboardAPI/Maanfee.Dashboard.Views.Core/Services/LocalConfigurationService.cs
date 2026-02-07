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

        public async Task InitConfigurationAsync(LanguageManager.SupportedCountry DefaultLanguage)
        {
            var StoredConfiguration = await LocalStorage.GetAsync<LayoutSettings>(ConfigurationStoredName);
            if (StoredConfiguration == null)
            {
                LayoutSettings LayoutSettings = CreateDefaultConfiguration(LanguageManager.GetCultureCode(DefaultLanguage));
                await LocalStorage.SetAsync<LayoutSettings>(ConfigurationStoredName, LayoutSettings);

                SharedLayoutSettings.IsDarkMode = LayoutSettings.IsDarkMode;
                SharedLayoutSettings.IsRTL = LayoutSettings.IsRTL;
                SharedLayoutSettings.ThemeColor = new PaletteLight().Primary.Value;
                SharedLayoutSettings.CurrentVersion = LayoutSettings.CurrentVersion;
                SharedLayoutSettings.IsFullscreenMode = LayoutSettings.IsFullscreenMode;
                SharedLayoutSettings.CultureCode = LayoutSettings.CultureCode;
                SharedLayoutSettings.RenderMode = LayoutSettings.RenderMode;
            }
            else
            {
                SharedLayoutSettings.IsDarkMode = StoredConfiguration.IsDarkMode;
                SharedLayoutSettings.IsRTL = StoredConfiguration.IsRTL;
                SharedLayoutSettings.ThemeColor = StoredConfiguration.ThemeColor;
                SharedLayoutSettings.CurrentVersion = StoredConfiguration.CurrentVersion;
                SharedLayoutSettings.IsFullscreenMode = StoredConfiguration.IsFullscreenMode;
                SharedLayoutSettings.CultureCode = StoredConfiguration.CultureCode;
                SharedLayoutSettings.RenderMode = StoredConfiguration.RenderMode;
            }
        }

        public async Task SetConfigurationAsync()
        {
            await LocalStorage.SetAsync<LayoutSettings>(ConfigurationStoredName, new LayoutSettings()
            {
                IsDarkMode = SharedLayoutSettings.IsDarkMode,
                IsRTL = SharedLayoutSettings.IsRTL,
                ThemeColor = SharedLayoutSettings.ThemeColor,
                CurrentVersion = SharedLayoutSettings.CurrentVersion,
                IsFullscreenMode = SharedLayoutSettings.IsFullscreenMode,
                CultureCode = SharedLayoutSettings.CultureCode,
                RenderMode = SharedLayoutSettings.RenderMode,
            });
        }

        private LayoutSettings CreateDefaultConfiguration(string DefaultLanguageCode)
        {
            return new LayoutSettings
            {
                IsDarkMode = false,
                IsRTL = false,
                ThemeColor = new PaletteLight().Primary.Value,
                CurrentVersion = string.Empty,
                IsFullscreenMode = false,
                CultureCode = DefaultLanguageCode,
                RenderMode = RenderMode.WebAssembly,
            };
        }

    }
}
