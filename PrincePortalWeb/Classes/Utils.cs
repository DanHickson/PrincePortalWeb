using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;


namespace PrincePortalWeb.Classes
{
    public class Utils
    {

        public static bool Email_Without_Attachment(String ToEmail, String mailfrom, String Subj, string Message)
        {
            //Reading sender Email credential from web.config file
            //   HostAdd = ConfigurationManager.AppSettings["150.158.0.199"].ToString();
            // FromEmailid = ConfigurationManager.AppSettings["SFDC@CCEE.NET"].ToString();
            //Pass = ConfigurationManager.AppSettings["Password"].ToString();

            //creating the object of MailMessage
            try
            {
                //MailMessage mailMessage = new MailMessage();
                //mailMessage.From = new MailAddress(mailfrom); //From Email Id
                //mailMessage.Subject = Subj; //Subject of Email
                //mailMessage.Body = Message; //body or message of Email
                //mailMessage.IsBodyHtml = true;
                ////Adding Multiple recipient email id logic
                //string[] Multi = ToEmail.Split(','); //spiliting input Email id string with comma(,)
                //foreach (string Multiemailid in Multi)
                //{
                //    mailMessage.To.Add(new MailAddress(Multiemailid)); //adding multi reciver's Email Id
                //}
                //SmtpClient smtp = new SmtpClient(); // creating object of smptpclient
                //smtp.Host = Global.GlobalVariables.SMTPHOST;
                ////"150.158.0.251"; //host of emailaddress for example smtp.gmail.com etc

                ////network and security related credentials
                //smtp.EnableSsl = true;
                //NetworkCredential NetworkCred = new NetworkCredential();
                //NetworkCred.UserName = Global.GlobalVariables.SMTPUSER;
                //NetworkCred.Password = Global.GlobalVariables.SMTPPASS;
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = NetworkCred;
                //smtp.Port = Global.GlobalVariables.SMTPPORT;
                //smtp.Send(mailMessage); //sending Email
                ////return true;


                MailMessage mail = new MailMessage();
                mail.To.Add(ToEmail);

                mail.From = new MailAddress(mailfrom);
                mail.Subject = Subj;
                mail.IsBodyHtml = true;
                string Body = Message;
                mail.Body = Body;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = Global.GlobalVariables.SMTPHOST; //Or Your SMTP Server Address
                smtp.Port = Global.GlobalVariables.SMTPPORT;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                (Global.GlobalVariables.SMTPUSER, Global.GlobalVariables.SMTPPASS);

                //Or your Smtp Email ID and Password
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return true;
                
            }
            catch (Exception)
            {

                return false;
            }

           
        }
    }
}