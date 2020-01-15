using Task5.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace Task5.Controllers
{
    public class HomeController : Controller
    {
        static List<Phone> data = new List<Phone>
        {
            new Phone { Id = Guid.NewGuid().ToString(), Name="iPhone 7", Price=52000 },
            new Phone { Id = Guid.NewGuid().ToString(), Name="Samsung Galaxy S7", Price=42000 },
        };
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetPhones()
        {
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddPhone(Phone phone)
        {
            phone.Id = Guid.NewGuid().ToString();
            data.Add(phone);
            return Json(phone);
        }

        [HttpDelete]
        public ActionResult DeletePhone(string id)
        {
            Phone phone = data.FirstOrDefault(x => x.Id == id);
            if (phone != null)
            {
                data.Remove(phone);
                return Json(phone);
            }
            return HttpNotFound();
        }
    }
}
//В качестве источника данных здесь используется массив объектов Phone, но при необходимости его можно заменить на контекст EF для работы с базо

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//using Task5.Models;

//namespace Task5.Controllers
//{
//    public class HomeController : Controller
//    {
//        // создаем контекст данных
//        SalesEntities db = new SalesEntities();

//        public ActionResult Index()
//        {
//            //// получаем из бд все объекты Book
//            //IEnumerable<Product> books = db.Product;
//            //// передаем все объекты в динамическое свойство Books в ViewBag

//            ////ViewBag. = books;

//            //// возвращаем представление
//            //return View();

//            return View();
//        }

//        public ActionResult About()
//        {
//            ViewBag.Message = "Your application description page.";

//            return View();
//        }

//        public ActionResult Contact()
//        {
//            ViewBag.Message = "Your contact page.";

//            return View();
//        }
//    }
//}