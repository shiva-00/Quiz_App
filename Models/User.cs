using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlTypes;


namespace MyApp.Model
{
    public class User
    {
        public int id { get; set; }
        [Required(ErrorMessage ="This Field Name cannot be empty: ")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "EMail Field cannot be empty: ")]
        [EmailAddress(ErrorMessage ="Please Enter Valid Email")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage ="Password Field Name cannot be empty: "), DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [NotMapped, DataType(DataType.Password)]
        [Required(ErrorMessage ="This Field Name cannot be empty: ")]
        public string C_Password { get; set; } = string.Empty;

    }

    public class UserOtp
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;

        public string Otp { get; set; } = string.Empty;
        public DateTime Expire { get; set; }
    }

    public class EmailSettings
    {
        public string SmtpServer { get; set; } = string.Empty;
        public int Port { get; set; }
        public string SenderName { get; set; } = string.Empty;
        public string SenderEmail { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        
    }  
}