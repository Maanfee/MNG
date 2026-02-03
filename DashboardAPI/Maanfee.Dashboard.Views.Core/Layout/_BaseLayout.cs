using Maanfee.JsInterop;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Maanfee.Dashboard.Views.Core
{
    public class _BaseLayout : LayoutComponentBase
    {
        [Inject]
        protected LocalConfigurationService? LocalConfiguration { get; set; }

        [Inject]
        protected NavigationManager? Navigation { get; set; }

        [Inject]
        protected LocalStorage? LocalStorage { get; set; }

        [Inject]
        protected Fullscreen? Fullscreen { get; set; }

        protected virtual MudTheme? CurrentTheme { get; set; }

    }
}
