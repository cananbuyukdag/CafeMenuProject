using BusinessLayer.Concrete;
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
            var result = adm.GetList().FirstOrDefault(x => x.Username == entity.Username && x.HashPassword == entity.HashPassword);
            if (result != null)
            {

                FormsAuthentication.SetAuthCookie(entity.Username, false);
                Session["Username"] = entity.Username;
                entity.SaltPassword = GenerateSalt();
                entity.HashPassword = HashPassword(entity.HashPassword, entity.SaltPassword);
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                //TempData["msg"] = "false";
                return Json(new { success = false });
            }
        }
        private string GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        private string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = Encoding.UTF8.GetBytes(password + salt);
                var hash = sha256.ComputeHash(saltedPassword);
                return Convert.ToBase64String(hash);
            }
        }

    }
}