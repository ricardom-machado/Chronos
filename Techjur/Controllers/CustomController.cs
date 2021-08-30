using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Techjur.Controllers
{
    public class CustomController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Session["idUsuario"] = "10020030044";
        }
    }
}