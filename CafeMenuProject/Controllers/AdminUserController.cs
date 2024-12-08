using BusinessLayer.Concrete;
using BusinessLayer.Validationrules;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeMenuProject.Controllers
{
    public class AdminUserController : Controller
    {
        private UserManager manager = new UserManager(new EfUserDal());
        [HttpGet]
        public ActionResult Index()
        {
            var m = manager.GetList();
            return View(m);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User entity) 
        {
            UserValidator validator = new UserValidator();
            ValidationResult result = validator.Validate(entity);
            if (result.IsValid)
            {
                manager.AddUser(entity);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var w = manager.GetById(id);
            return View(w);
        }

        [HttpPost]
        public ActionResult Update(User entity)
        {

            UserValidator validator = new UserValidator();
            ValidationResult result = validator.Validate(entity);
            if (result.IsValid)
            {
                manager.UserUpdate(entity);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

    }
}
