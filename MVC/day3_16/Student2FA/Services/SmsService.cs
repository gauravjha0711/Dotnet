using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Microsoft.Extensions.Configuration;

namespace Student2FA.Services
{
    public class SmsService
    {
        private readonly IConfiguration _configuration;

        public SmsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendSMS(string phone, string otp)
        {
            // 🔹 Fetch from appsettings.json
            var accountSid = _configuration["SmsSettings:AccountSid"];
            var authToken = _configuration["SmsSettings:AuthToken"];
            var fromNumber = _configuration["SmsSettings:FromPhoneNumber"];

            // 🔹 Initialize Twilio
            TwilioClient.Init(accountSid, authToken);

            // 🔹 Ensure phone is in correct format (+91...)
            if (!phone.StartsWith("+"))
            {
                phone = "+91" + phone; // default India
            }

            // 🔹 Send SMS
            var message = MessageResource.Create(
                body: $@"Student2FA Security

Your One-Time Password (OTP) is: {otp}

Valid for 5 minutes.
Do NOT share this code.

- Student2FA",
                from: new PhoneNumber(fromNumber),
                to: new PhoneNumber(phone)
            );
        }
    }
}