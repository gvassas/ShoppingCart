using IndividualAssignment2A.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace IndividualAssignment2A.BusinessLogic
{
    public class EmailHelper
    {
        public const string SUCCESS = "Thank you for contacting us. Please allow one business day for a response";

        string EmailFromArvixe(Email message)
        {
            const string SMTP_USER = "guillaume@lifetrap.net";
            message.Recipient = SMTP_USER;
            // ** See ARVIXE doc
            const string SMTP_PWD = "plmkop";              // ** See ARVIXE doc
            const bool USE_HTML = true;
            // ** See ARVIXE doc
            const string SMTP_SERVER = "mail.lifetrap.net.BROWN.mysitehosted.com";
            try
            {
                MailMessage mailMsg = new MailMessage(message.Sender, message.Recipient);
                mailMsg.Subject = message.Subject;
                mailMsg.Body = message.Body;
                mailMsg.IsBodyHtml = USE_HTML;

                SmtpClient smtp = new SmtpClient();
                smtp.Port = 25;
                smtp.Host = SMTP_SERVER;
                smtp.Credentials = new System.Net.NetworkCredential(SMTP_USER, SMTP_PWD);
                smtp.Send(mailMsg);
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
            //send reply
            ReplyFromArvixe(message);
            return SUCCESS;
        }



        //Send automatic reply email
        void ReplyFromArvixe(Email message)
        {
            const string SMTP_USER = "guillaume@lifetrap.net";
            message.Recipient = message.Sender;
            message.Sender = SMTP_USER;
            // ** See ARVIXE doc
            const string SMTP_PWD = "plmkop";              // ** See ARVIXE doc
            const bool USE_HTML = true;
            // ** See ARVIXE doc
            const string SMTP_SERVER = "mail.lifetrap.net.BROWN.mysitehosted.com";
            try
            {
                MailMessage mailMsg = new MailMessage(message.Sender, message.Recipient);
                mailMsg.Subject = "Re:" + message.Subject;
                mailMsg.Body = "Thank you for contacting us. Please allow one business day for a response";
                mailMsg.IsBodyHtml = USE_HTML;

                SmtpClient smtp = new SmtpClient();
                smtp.Port = 25;
                smtp.Host = SMTP_SERVER;
                smtp.Credentials = new System.Net.NetworkCredential(SMTP_USER, SMTP_PWD);
                smtp.Send(mailMsg);
            }
            catch (System.Exception ex)
            {
            }
        }

        // if local use smtp4dev otherwise use arvixe
        public string SendMessage(Email message)
        {
            string response = SUCCESS;

            response = EmailFromArvixe(message);
            return response;
        }
    }
}
