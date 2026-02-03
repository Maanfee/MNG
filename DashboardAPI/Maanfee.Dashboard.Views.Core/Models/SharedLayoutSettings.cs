namespace Maanfee.Dashboard.Views.Core
{
    public static class SharedLayoutSettings
    {
        public static bool IsRTL { get; set; }

        public static bool IsDarkMode { get; set; }

        public static string? ThemeColor { get; set; }

        public static string? CurrentVersion { get; set; }

        public static bool IsFullscreenMode { get; set; }
       
        public static string CultureCode { get; set; } = LanguageService.GetCultureCode(LanguageService.SupportedCountry.US);
    }
}
