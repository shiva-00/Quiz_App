using Microsoft.AspNetCore.Mvc;
using MyApp.Model;
using MyApp.Data;
using MyApp.Services;
using Microsoft.AspNetCore.Identity;
using MyApp.OtpController;

namespace MyApp.controller
{
    public class AccountController : Controller
    {
        private readonly IEmailService emailService;
        private readonly IOTPService OtpService;
        private readonly MyDatabase Data;
        private readonly PasswordHasher<User> Encrypt;

        public AccountController(IEmailService _emailService, MyDatabase data, IOTPService _OtpService)
        {
            Data = data;
            Encrypt = new PasswordHasher<User>();
            OtpService = _OtpService;
            emailService = _emailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var Existinguser = Data.Users.FirstOrDefault(E => E.Email == user.Email);
            if (Existinguser != null)
            {
                ModelState.AddModelError("Email", "Email Already Exists. Please TryAgain");
                return View(user);
            }
            if (user.Password == user.C_Password)
            {
                await OtpService.Generate_Send_OtpAsync(user.Email);

                TempData["Name"] = user.Name;
                TempData["Email"] = user.Email;
                TempData["Password"] = Encrypt.HashPassword(new User(), user.Password);
                TempData.Keep();

                return RedirectToAction("Verify_Email");
            }

            else if (user.Password != user.C_Password)
                ModelState.AddModelError("C_Password", "Passwords do not match. Please Try Again");

            return View(user);

        }
        [HttpGet]
        public IActionResult Verify_Email()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Verify_Email(string otp)
        {
            var name = TempData["Name"]?.ToString();
            var email = TempData["Email"]?.ToString();
            var password = TempData["Password"]?.ToString();

            TempData.Keep();
            if (OtpService.ValidateOtp(email!, otp))
            {
                var User_Details = new User()
                {
                    Name = name!,
                    Email = email!,
                    Password = password!
                };
                Data.Users.Add(User_Details);
                var OtpRecord = Data.userotp.FirstOrDefault(X => X.Email == email);
                Data.userotp.Remove(OtpRecord!);
                Data.SaveChanges();
                await emailService.SendEmailAsync(User_Details.Email, "Status", "congratulations! You Have Successfully Created your Account with us. you can now login.");
                return RedirectToAction("Login");
            }

            ModelState.AddModelError("Otp", "Incorrect or Expired Otp. Please Try Again");
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User loginuser)
        {
            if (string.IsNullOrWhiteSpace(loginuser.Email) || string.IsNullOrWhiteSpace(loginuser.Password))
            {
                return View(loginuser);
            }
            
            var user = Data.Users.FirstOrDefault(E => E.Email == loginuser.Email);
            if (user == null)
            {
                ModelState.AddModelError("Email", "User Doesnot Exist. Please Enter Valid Credentials. ");
                return View(loginuser);
            }
            var result = Encrypt.VerifyHashedPassword(user, user.Password, loginuser.Password);

            if (result == PasswordVerificationResult.Success)
                return RedirectToAction("WebPage", "Page", new { Id = user.id });

            ModelState.AddModelError("Password", "Password Incorrect. Please Enter again. ");
            return View(loginuser);
        }

        }
    }
