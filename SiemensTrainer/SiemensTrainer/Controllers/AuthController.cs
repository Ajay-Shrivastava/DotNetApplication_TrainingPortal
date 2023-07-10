using Microsoft.AspNetCore.Mvc;
using SiemensTrainer.Models;

namespace SiemensTrainer.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            ModelState.Remove("failedauth");
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(Users user)
        {
            // Validate the user's credentials (e.g., check against a database)
            if (user.Username == "admin" && user.Password == "password")
            {
                ModelState.Remove("failedauth");
                // Successful login
                return RedirectToAction("Dashboard", "Home");
            }
                ModelState.AddModelError("failedauth", "LOGIN FAILED");
                return View(user);
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(Users user)
        {
            ModelState.Clear();

            
                if (user.Fname == null)
                {
                    ModelState.AddModelError("fnameRequired", "Please provide First Name");
                }

                if (user.Lname == null)
                {
                    ModelState.AddModelError("lnameReuqired", "Please Provide Last Name");
                }

                if (user.Password == null)
                {
                    ModelState.AddModelError("passwordRequired", "Please Provide Password");
                }

                if (user.Email == null)
                {
                    ModelState.AddModelError("emailRequired", "Please Provide Email");
                }

                if (user.Username == null)
                {
                    ModelState.AddModelError("usernameRequired", "Please Provide Username");
                }

                if (user.Password != null && user.Password.Length <= 5)
                {
                    ModelState.AddModelError("passwordRequired", "password must contains more then 5 characters");
                }

            if (user.Fname != null && user.Lname != null && user.Password != null && user.Password.Length > 5 && user.Email != null && user.Username != null)
            {
                ModelState.AddModelError("signupSuccess", "SuccessFully Signed Up, please go to Login page");
                return View(user);
            }
            else
            {
                ModelState.AddModelError("signupFailed", "Failed to Signed Up");
                return View(user);
            }
        }
    }
}
