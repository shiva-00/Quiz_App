# QUIZ Module with USER AUTHENTICATION SYSTEM (ASP.NET Core MVC) 

## Overview 
The Quiz Module is a web-based feature built using ASP.NET Core MVC that allows users to register, Login, and attempt quizzes across multiple subjects and difficulty levels. It dynamically displays questions, captures user response, and calculate scores upon submission.



## FEATURES 
- User Registration with Validation
- Secure Login
- Forgot Password with Otp Verification via Email
- Multiple subjects (Mathematics, ENglish, Logical, etc.,)
- score calculation and result summary after submission
- MVC architectire with proper model binding and validation
- Entity Framework Core with SQL Server for database management

## Tech Stack

- **Backend**        : ASP.NET Core MVC
- **Frontend**       : Razor Pages (HTML, CSS, Bootstrap)
- **Database**       : SQL Server (Entity Framework Core)
- **Authentication** : Custom authentication with OTP verification
- **Email Service**  : SMTP configuration for sending OTPs and messages

## Prerequisites
- .NET 6.0 SDK or later
- SQL Server (LocalDB or full version)
- Visual Studio / VS Code

  
```markdown
## Folder Structure

📂 Controllers
   ┣ 📜 AccountController.cs
   ┣ 📜 OtpController.cs
   ┣ 📜 PageController.cs
   ┗ 📜 PasswordControllers.cs
   ┗ 📜 MathController.cs
   ┗ 📜 QuizController.cs
📂 Models
   ┗ 📜 User.cs
   ┗ 📜 Quiz.cs
📂 Views
  ┣ 📂 Account
  ┃   ┣ 📜 Login.cshtml
  ┃   ┣ 📜 Register.cshtml
  ┃   ┗ 📜 Verify_Email.cshtml
  ┣ 📂 Page
  ┃   ┗ 📜 WebPage.cshtml
  ┗ 📂 Password
  ┃   ┣ 📜 Forgot_Password.cshtml
  ┃   ┣ 📜 Verify_Otp.cshtml
  ┃   ┗ 📜 Password_Reset.cshtml
  ┣ 📂 Math
      ┣ 📂 Mathematics_Easy.cshtml
      ┣ 📂 Mathematics_Medium.cshtml
  ┣ 📂 Quiz
      ┣ 📂 Aptitude.cshtml
      ┣ 📂 Logical.cshtml
      ┣ 📂 English.cshtml
      ┣ 📂 General_Knowledge.cshtml
      ┣ 📂 Mathematics.cshtml
  ┣ 📂 shared
      ┣ 📂 Result.cshtml

📂 Data
  ┗ 📜 MyDatabase.cs
📂 Services
  ┗ 📜 Email.cs
📂 Migrations
  ┣ 📜 20250902154619_InitialTable.cs
  ┗ 📜 MyDatabaseModelSnapshot.cs



# SetUp

1. **Clone the Repository**
                  https://github.com/shiva-00/User-Authentication.git
                  cd User-Authentication

2. **Update Database Connection String**
                  Open appsettings.json and update the ConnectionStrings section with your SQL Server details.

3. ## Configure Email Settings
                  In appsettings.json, update the EmailSettings section with your SMTP details:
                    "EmailSettings": { 
                      "SmtpServer": "smtp.gmail.com",
                      "Port": 587,
                      "SenderName": "Your App Name",
                      "SenderEmail": "your-email@example.com",
                      "Password": "your-email-password"
                    }


4.  **Apply Migrations & Create Database**
                  dotnet ef database update

5. **Run the Application**
                  dotnet run



# Future Enhancements
- To-Do List with full CRUD operations
- Role-based Authentication (Admin/User)
- Profile Management
- Activity Logs for User Operations
- Implementing all subjects for quizzing





