using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.Models
{
    
    public class yetkiKontrol : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.Cookies["Eposta"] != null)
            {
                return true;
            }
            else
            {
                httpContext.Response.Redirect("/Giris/Index");

                return false;
            }
        }
    }
}
