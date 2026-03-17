using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;

namespace Student2FA.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(string email, string otp)
        {
            // 🔹 Fetch config from appsettings.json
            var smtpServer = _configuration["EmailSettings:SmtpServer"];
            var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"] ?? "587");
            var senderEmail = _configuration["EmailSettings:SenderEmail"];
            var senderPassword = _configuration["EmailSettings:SenderPassword"];

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Student2FA", senderEmail));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Your Login OTP";

            message.Body = new TextPart("html")
            {
                Text = $@"
<html>
<head>
<style>
    body {{
        margin:0;
        padding:0;
        background-color:#f4f6f9;
        font-family: Arial, Helvetica, sans-serif;
    }}

    .email-container {{
        width:100%;
        padding:30px 0;
    }}

    .main-table {{
        width:600px;
        margin:auto;
        background:#ffffff;
        border:1px solid #dcdcdc;
        border-radius:12px;
        overflow:hidden;
        box-shadow: 0 4px 12px rgba(0,0,0,0.1);
    }}

    .header {{
        background:#007bff;
        color:white;
        padding:20px;
        font-size:22px;
        text-align:center;
        font-weight:bold;
    }}

    .content {{
        padding:30px;
        text-align:center;
    }}

    .otp-box {{
        margin:20px auto;
        font-size:32px;
        letter-spacing:6px;
        font-weight:bold;
        color:#007bff;
        border:2px dashed #007bff;
        padding:15px 25px;
        display:inline-block;
        background:#f8fbff;
        border-radius:8px;
    }}

    .info {{
        margin-top:15px;
        font-size:14px;
        color:#555;
    }}

    .footer {{
        background:#f7f7f7;
        padding:15px;
        font-size:12px;
        color:#777;
        text-align:center;
        border-top:1px solid #e0e0e0;
    }}

    /* 🔹 Extra UI (Your Auth Style Added) */
    .auth-container {{
        max-width: 420px;
        margin: auto;
        text-align: center;
    }}
</style>
</head>

<body>

<table class='email-container'>
<tr>
<td>

<table class='main-table' cellpadding='0' cellspacing='0'>

<tr>
<td class='header'>
Student2FA Login Verification
</td>
</tr>

<tr>
<td class='content'>

<p style='font-size:16px;'>Hello Student,</p>

<p>Your One Time Password (OTP) for secure login is:</p>

<div class='otp-box'>
{otp}
</div>

<p class='info'>
This OTP is valid for the next <b>5 minutes</b>.
</p>

<p class='info'>
Do not share this code with anyone.
</p>

</td>
</tr>

<tr>
<td class='footer'>
If you did not request this login, please ignore this email.<br>
© 2026 Student2FA Security System
</td>
</tr>

</table>

</td>
</tr>
</table>

</body>
</html>"
            };

            using (var client = new SmtpClient())
            {
                client.Connect(smtpServer, smtpPort, false);

                client.Authenticate(senderEmail, senderPassword);

                client.Send(message);

                client.Disconnect(true);
            }
        }
    }
}