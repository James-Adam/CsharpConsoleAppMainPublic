using System;
using System.ComponentModel;
using System.Net.Mail;
using System.Text;

namespace AuthenticatedSchoolSystem.Back_End.Services
{
    public static class EmailService
    {
        private static bool mailSent;

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            string token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }

            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error);
            }
            else
            {
                Console.WriteLine("Message sent.");
            }

            mailSent = true;
        }

        public static void SendEmail(string email, string[] args)
        {
            //var mailMessage = new MailMessage("info@suteki.co.uk", emailAddress)
            //{
            //    Subject = "Hello!",
            //    Body = "An important message :)"
            //};

            //var smtpClient = new SmtpClient("smtp.suteki.co.uk");

            //return smtpClient.SendTask(mailMessage, null);
            ////smtpClient
            ///
            ///
            ///
            ///
            ///// Command-line argument must be the SMTP host.
            SmtpClient client = new SmtpClient(args[0]);
            // Specify the email sender. Create a mailing address that includes a UTF8 character in
            // the display name.
            MailAddress from = new MailAddress("jane@contoso.com",
                "Jane " + (char)0xD8 + " Clayton",
                Encoding.UTF8);
            // Set destinations for the email message.
            MailAddress to = new MailAddress("ben@contoso.com");
            // Specify the message content.
            MailMessage message = new MailMessage(from, to)
            {
                Body = "This is a test email message sent by an application. "
            };
            // Include some non-ASCII characters in body and subject.
            string someArrows = new string(new[] { '\u2190', '\u2191', '\u2192', '\u2193' });
            message.Body += Environment.NewLine + someArrows;
            message.BodyEncoding = Encoding.UTF8;
            message.Subject = "test message 1" + someArrows;
            message.SubjectEncoding = Encoding.UTF8;
            // Set the method that is called back when the send operation ends.
            client.SendCompleted += SendCompletedCallback;
            // The userState can be any object that allows your callback method to identify this
            // send operation. For this example, the userToken is a string constant.
            const string userState = "test message1";
            client.SendAsync(message, userState);
            Console.WriteLine("Sending message... press c to cancel mail. Press any other key to exit.");
            string answer = Console.ReadLine();
            // If the user canceled the send, and mail hasn't been sent yet, then cancel the pending operation.
            if (answer.StartsWith("c") && !mailSent)
            {
                client.SendAsyncCancel();
            }

            // Clean up.
            message.Dispose();
            Console.WriteLine("Goodbye.");
            /// <summary>
            /// </summary>
        }
    }
}