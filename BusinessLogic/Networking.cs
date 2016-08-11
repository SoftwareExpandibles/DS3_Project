using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web.Helpers;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Networking
    {
        public bool SendEmailConfirmation(string email, string url)
        {
            bool isvalid = false;
            try
            {

                var boddy = new StringBuilder();

                boddy.Append("Hello " + email + "<br/>");
                boddy.Append("Thank you for your interest in creating an account with us." +
                             "Your account is currently inactive,you can activate it by navigating to the address below" +
                             "before using it" + "<br/>" + url);

                string bodyFor = boddy.ToString();
                string toFor = email;
                const string subjectFor = "Registration Confirmation";

                var mail = new MailAddress("21229090@dut4life.ac.za", "Rangamo Customer");

                WebMail.SmtpServer = "mfd.dut.ac.za";
                WebMail.SmtpPort = 25;
                WebMail.UserName = "21229090@dut4life.ac.za";
                WebMail.Password = "Dut940418";
                WebMail.From = mail.ToString();
                WebMail.EnableSsl = true;


                WebMail.Send(to: toFor, subject: subjectFor, body: bodyFor);

                isvalid = true;
                return isvalid;
            }
            catch
            {
                return isvalid;
            }
        }

        public bool SendEmailForgot(string email, string url)
        {
            bool isvalid = false;
            try
            {

                var boddy = new StringBuilder();


                boddy.Append("Hello , Please click the link below to reset your password.");
                boddy.Append("");
                boddy.Append(url);

                string bodyFor = boddy.ToString();
                string toFor = email;
                const string subjectFor = "Reset Password";

                var mail = new MailAddress("21229090@dut4life.ac.za", "Customer Membership");

                WebMail.SmtpServer = "mfd.dut.ac.za";
                WebMail.SmtpPort = 25;
                WebMail.UserName = "21229090@dut4life.ac.za";
                WebMail.Password = "Dut940418";
                WebMail.From = mail.ToString();
                WebMail.EnableSsl = true;

                WebMail.Send(to: toFor, subject: subjectFor, body: bodyFor);

                isvalid = true;
                return isvalid;
            }
            catch
            {
                return isvalid;
            }
        }
    }
}
