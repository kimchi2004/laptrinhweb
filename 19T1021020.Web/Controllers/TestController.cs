using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _19T1021020.Web.Controllers
{
    public class TestController : Controller
    {
        /// <summary>
        ///     Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Input()
        {
            var person = new Person
            {
                BirthDate = new DateTime(2001, 10, 21)
            };

            return View(person);
        }

        /// <summary>
        ///     Input
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Input(Person person)
        {
            var data = new
            {
                person.Name,
                BirthDate = $"{person.BirthDate:dd/MM/yyyy}",
                person.Salary
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public string TestDate(string date)
        {
            var data = DateTime.Parse(date);
            return $"{data:dd/MM/yyyy}";
        }
    }

    /// <summary>
    ///     Person
    /// </summary>
    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public float Salary { get; set; }
    }
}