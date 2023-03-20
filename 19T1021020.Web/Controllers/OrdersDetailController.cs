using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _19T1021020.Web.Controllers
{
    /// <summary>
    /// OrdersDetailController
    /// </summary>
    [Authorize]
    public class OrdersDetailController : Controller
    {
        // GET: OrdersDetail
        public ActionResult Index()
        {
            return View();
        }
    }
}