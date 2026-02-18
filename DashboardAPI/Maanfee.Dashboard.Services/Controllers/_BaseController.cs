using Maanfee.Dashboard.Domain.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Maanfee.Dashboard.Services.Controllers
{
    public class _BaseController<T> : ControllerBase
    {
        public _BaseController(_BaseContext_SQLServer context
            , HttpClient http)
        {
            try
            {
                db_SQLServer = context;
                Http = http;
            }
            catch //(Exception ex)
            {
            }
        }


        protected readonly _BaseContext_SQLServer? db_SQLServer;

        protected HttpClient? Http;
    }
}
