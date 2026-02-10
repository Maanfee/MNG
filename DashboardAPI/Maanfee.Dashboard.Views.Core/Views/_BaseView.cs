namespace Maanfee.Dashboard.Views.Core
{
    public class _BaseView : _BaseLayout
    {
        protected Type ContentType => this.GetType();

        protected bool IsLoaded { get; set; } = false;

    }
}
