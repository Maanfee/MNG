using MudBlazor;
using MudBlazor.Utilities;

namespace Maanfee.Dashboard.Views.Core
{
    public static class SharedLayoutSettings
    {
        public static bool IsRTL { get; set; }

        public static bool IsDarkMode { get; set; }

        public static MudColor ThemeColor { get; set; } = new PaletteLight().Primary;

        public static string? CurrentVersion { get; set; }

        public static bool IsFullscreenMode { get; set; }
       
        public static string CultureCode { get; set; } = LanguageManager.GetCultureCode(LanguageManager.SupportedCountry.US);

        // ***********************************

        private static RenderMode _renderMode = RenderMode.WebAssembly;

        public static RenderMode RenderMode
        {
            get => _renderMode;
            set
            {
                if (_renderMode != value)
                {
                    _renderMode = value;
                    OnRenderModeChanged?.Invoke();
                }
            }
        }

        public static event Action? OnRenderModeChanged;

        // ***********************************


    }
}
