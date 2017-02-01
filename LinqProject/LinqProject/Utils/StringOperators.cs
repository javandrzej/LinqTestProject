using System;
using System.Linq;
using System.Net.Mail;

namespace LinqProject.Utils
{
    public class StringOperators
    {
        public static bool IsUpperString(string message)
        {
            return message.All(c => char.IsUpper(c));
        }

        public static bool IsLowerString(string message)
        {
            return message.All(c => char.IsLower(c));
        }

        public static bool IsValidEmailAddress(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static string GetCreatedFileStaus(bool success, string fileExtension)
        {
            return success ?
                  "File with extension " + fileExtension.ToLower() + " was successful created at time " + DateTime.Now
             : "File with extension " + fileExtension.ToLower() + " was not created at time " + DateTime.Now;
        }
    }
}
