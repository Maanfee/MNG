using MudBlazor;
using MudBlazor.Utilities;

namespace Maanfee.Dashboard.Views.Core
{
    public class LayoutSettings
    {
        public bool IsRTL { get; set; }

        public bool IsDarkMode { get; set; }

        public MudColor ThemeColor { get; set; } = new PaletteLight().Primary;

        public string? CurrentVersion { get; set; }

        public bool IsFullscreenMode { get; set; }

        public string CultureCode { get; set; } = LanguageManager.GetCultureCode(LanguageManager.SupportedCountry.US);

        public RenderMode RenderMode { get; set; }
    }
}
