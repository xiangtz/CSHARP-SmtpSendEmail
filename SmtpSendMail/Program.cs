using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmtpSendMail
{
    class Program
    {
        static void Main(string[] args)
        {
            var sender = "automail@test.com";
            var receiver = "receiver@test.com";
            var host = "test.com";
            var hostPort = 25;
            var credentialsAccount = "automail";
            var credentialsPassword = "p@ssw0rd";

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress(sender);
            msg.To.Add(receiver);
            msg.Subject = "Hello world! " + DateTime.Now.ToString();
            msg.Body = "hi to you ... :)";
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = true;
            client.Host = host;
            client.Port = hostPort;
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(credentialsAccount, credentialsPassword);
            client.Timeout = 20000;
            try
            {
                client.Send(msg);
               // return "Mail has been successfully sent!";
            }
            catch (Exception ex)
            {
              //  return "Fail Has error" + ex.Message;
            }
            finally
            {
                msg.Dispose();
            }
        }
    }
}
