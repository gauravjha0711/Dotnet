using OtpNet;
using QRCoder;
using System.Text;

namespace Student2FA.Services
{
    public class AuthenticatorService
    {
        public string GenerateSecretKey()
        {
            var key = KeyGeneration.GenerateRandomKey(20);
            return Base32Encoding.ToString(key);
        }

        public string GenerateQrCodeUri(string appName, string key)
        {
            return $"otpauth://totp/{appName}?secret={key}&issuer=Student2FA";
        }

        public string GenerateQrCodeImage(string qrText)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            Base64QRCode qrCode = new Base64QRCode(qrCodeData);

            return qrCode.GetGraphic(20);
        }

        public bool ValidateOtp(string key, string otp)
        {
            var keyBytes = Base32Encoding.ToBytes(key);
            var totp = new Totp(keyBytes);

            return totp.VerifyTotp(otp, out long timeStepMatched, new VerificationWindow(2, 2));
        }
    }
}