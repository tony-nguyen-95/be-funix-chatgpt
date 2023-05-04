using Funix.HannahAssistant.Api.Models;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Funix.HannahAssistant.Api.Common
{
    public static class AppFunction
    {
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        public static string HashPassword(this string password)
        {
            byte[] salt = new byte[16];
            rngCsp.GetBytes(salt);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            return Convert.ToBase64String(hashBytes);
        }

        public static string ToSHA512HashString(this string inputString)
        {
            using (SHA512 shaM = new SHA512Managed())
            {
                byte[] hash = shaM.ComputeHash(Encoding.UTF8.GetBytes(inputString));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static ApiStatusModel<bool> ReturnBadRequest(Exception ex)
        {
            return new ApiStatusModel<bool>() {  
                ApiStatusCode = ApiStatusCode.Error, 
                ApiMessage = "Đã có lỗi xảy ra. Vui lòng liên hệ quản trị viên hệ thống.",
                ReturnData = false,
                ApiException = new ApiException() { 
                    ErrorCode = ex.HResult,
                    Exception = ex,
                    ExceptionMessage = ex.Message
                },
                ApiHttpStatus = new ApiHttpStatus() { 
                    HttpCode = System.Net.HttpStatusCode.BadRequest
                }
            };
        }

        public enum StudentProgress
        {
            Delay = 1,
            OnSchedule = 2,
            Over = 3
        }

        public static int GetIsoWeekOfYear(this DateTime StartDate)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            dfi.FirstDayOfWeek = DayOfWeek.Monday;

            return cal.GetWeekOfYear(StartDate, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
        }
    }
}
