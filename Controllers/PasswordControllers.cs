using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using MyApp.Model;
using MyApp.OtpController;

namespace MyApp.PWController
{
    public class PasswordController : Controller
    {
        private readonly IOTPService OtpService;

        private readonly PasswordHasher<User> Encrypt;

        private readonly MyDatabase Data;

        public PasswordController(IOTPService _OtpService, PasswordHasher<User> _Encrypt, MyDatabase _Data)
        {
            OtpService = _OtpService;
            Encrypt = _Encrypt;
            Data = _Data;
        }

        [HttpGet]
        public IActionResult Forgot_Password()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Forgot_Password(User user)
        {
            var UserDetails = Data.Users.FirstOrDefault(U => user.Email == U.Email);

            if (UserDetails != null)
            {
                await OtpService.Generate_Send_OtpAsync(user.Email);

                TempData["Email"] = user.Email;
                TempData.Keep();

                return RedirectToAction("Verify_Otp");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Verify_Otp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Verify_otp(string Otp)
        {
            var email = TempData["Email"]?.ToString();
            TempData.Keep();

            if (OtpService.ValidateOtp(email!, Otp))
            {
                return RedirectToAction("Password_Reset", new { email = email });
            }
            ModelState.AddModelError("Otp", "Incorrect or Expired OTp: Please Try Again: ");
            return View(new User { Email = email! });
        }
        [HttpGet]
        public IActionResult Password_Reset(string email)
        {
            return View(new User { Email = email });
        }

        [HttpPost]
        public IActionResult Password_Reset(User user, string email)
        {
            var User_Details = Data.Users.FirstOrDefault(U => U.Email == email);
            if (User_Details != null)
            {
                if (user.Password == user.C_Password)
                {
                    User_Details.Password = Encrypt.HashPassword(User_Details, user.Password);
                    Data.Users.Update(User_Details);

                    var OtpRecord = Data.userotp.FirstOrDefault(O => O.Email == email);
                    Data.userotp.Remove(OtpRecord!);
                    Data.SaveChanges();
                    return RedirectToAction("Login","Account");
                }
                ModelState.AddModelError("C_Password", "Passwords do not match");
            }
            return View(new User { Email = email });
        }

    }
}

