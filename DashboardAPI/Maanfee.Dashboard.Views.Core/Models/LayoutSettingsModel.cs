namespace Maanfee.Dashboard.Views.Core
{
    public class LayoutSettingsModel
    {
        public bool IsRTL { get; set; }

        public bool IsDarkMode { get; set; }

        public string? ThemeColor { get; set; }

        public string? CurrentVersion { get; set; }

        public bool IsFullscreenMode { get; set; }

        public string CultureCode { get; set; } = LanguageService.GetCultureCode(LanguageService.SupportedCountry.US);
    }
}
