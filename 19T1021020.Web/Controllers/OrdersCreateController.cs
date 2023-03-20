using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _19T1021020.Web.Controllers
{
    /// <summary>
    /// OrdersCreateController
    /// </summary>
    [Authorize]
    public class OrdersCreateController : Controller
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        
        
    }
}