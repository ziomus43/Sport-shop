using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sport_shop.Areas.Identity.Data;
using Sport_shop.Data;
using Sport_shop.Models;

namespace Sport_shop.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthDbContext _Authcontext;
        private readonly Sport_shopDbContext _context;

        public AuthController(AuthDbContext Authcontext, Sport_shopDbContext context)
        {
            _Authcontext = Authcontext;
            _context = context;
        }
        

        public ActionResult Login()
        {
            return View("~/Areas/Identity/Pages/Account/Login.cshtml");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginConfirmed(
            [Bind("Login,Password")] ApplicationUser applicationUser)
        {
            
            var loggins = _Authcontext.ApplicationUsers;
            foreach(ApplicationUser appu in loggins)
            {
                if (applicationUser.Login == appu.Login && applicationUser.Password == appu.Password)
                {
                    return View("~/Areas/Identity/Pages/Account/LoginConfirmed.cshtml");
                }
            }   
            return View("~/Areas/Identity/Pages/Account/Login.cshtml");
        }
        public ActionResult Logout()
        {
            return View("~/Areas/Identity/Pages/Account/Logout.cshtml");
        }
        public ActionResult Register()
        {
            return View("~/Areas/Identity/Pages/Account/Register.cshtml");
        }

        // GET: AuthController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AuthController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AuthController/Create
        public ActionResult Create()
        {

            return View("~/Views/Home/Index.cshtml");
        }

        // POST: AuthController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ApplicationUserID,Login,Password,EmailAddress,ClientID")] ApplicationUser applicationUser,
            [Bind("ClientID,Name,Surname")] Client client)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(client);
                _context.SaveChanges();
                int id = client.ClientID;
                applicationUser.ClientID = id;
                _Authcontext.Add(applicationUser);
                _Authcontext.SaveChanges();
                
                return View("~/Views/Home/Index.cshtml");
            }
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: AuthController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuthController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuthController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
