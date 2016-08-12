using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class EmailBusiness
    {
       public MailAddress to { get; set; }
       public MailAddress from { get; set; }
       public string sub { get; set; }
       public string body { get; set; }

    public string ToAdmin()
    {
        string feedback = "";
        EmailBusiness me = new EmailBusiness();

        var m = new MailMessage()
        {

            Subject = sub,
            Body = body,
            IsBodyHtml = true
        };
        to = new MailAddress("21229090@dut4life.ac.za", "Administrator");
        m.To.Add(to);
        m.From = new MailAddress(from.ToString());
        m.Sender = to;


        SmtpClient smtp = new SmtpClient
        {
            Host = "mfd.dut.ac.za",
            Port = 443,
            Credentials = new NetworkCredential("21229090@dut4life.ac.za", "Dut940418"),
            EnableSsl = true
        };

        try
        {
            smtp.Send(m);
            feedback = "Message sent";
        }
        catch (Exception e)
        {
            feedback = "Message not sent retry" + e.Message;
        }
        return feedback;
    }

  }

}

