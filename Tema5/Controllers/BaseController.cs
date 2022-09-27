using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tema5Business;

namespace Tema5.Controllers
{
    public class BaseController : Controller
    {
        private Business _business;
        public Business Business
        {
            get { return _business ?? (_business = new Business()); }



        }

    }
}