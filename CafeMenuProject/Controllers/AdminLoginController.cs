using BusinessLayer.Concrete;
using CafeMenuProject.Services;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CafeMenuProject.Controllers
{
    public class AdminLoginController : Controller
    {
        private UserManager adm = new UserManager(new EfUserDal());
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.msg = TempData["msg"] as string;
            return View();
        }
        [HttpPost]
        public ActionResult Index(User entity)
        {
            var result = adm.GetList().FirstOrDefault(x => x.Username == entity.Username);
            if (result != null)
            {
                result.SaltPassword = HashingHelper.GenerateSalt();
                result.HashPassword = HashingHelper.HashPassword(entity.HashPassword, entity.SaltPassword);

                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return Json(new { success = false });
            }
        }


    }
}