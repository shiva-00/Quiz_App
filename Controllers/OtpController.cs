using MyApp.Model;
using MyApp.Data;
using MyApp.Services;

namespace MyApp.OtpController
{
    public interface IOTPService
    {
        Task Generate_Send_OtpAsync(string email);
        bool ValidateOtp(string email, string Otp);
    }

    public class OTPService : IOTPService
    {
        private readonly MyDatabase Data;
        private readonly IEmailService emailService;

        public OTPService(MyDatabase _db, IEmailService _emailService)
        {
            Data = _db;
            emailService = _emailService;
        }

        public async Task Generate_Send_OtpAsync(string email)
        {

            var otp = new Random().Next(100000, 999999).ToString();
            var OtpRecord = new UserOtp()
            {
                Email = email,
                Otp = otp,
                Expire = DateTime.Now.AddMinutes(5)
            };
            Data.userotp.Add(OtpRecord);
            Data.SaveChanges();

            await emailService.SendEmailAsync(email, "OTP Code", $"Your Otp code is {otp}.\nExpires in 5 minutes");
            

        }

        public bool ValidateOtp(string email, string Otp)
        {
            var record = Data.userotp.FirstOrDefault(X => X.Email == email && X.Otp == Otp && X.Expire > DateTime.Now);

            return record != null;
        }
    }
}