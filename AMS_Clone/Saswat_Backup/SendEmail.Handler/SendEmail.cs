using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Tracking.Entities;
using static Tracking.Entities.Enums;

namespace SendEmail.Handler
{
    public class SendEmail
    {
        public async Task SendEmailToDefaulters(List<Tuple<CmRecords, GlcSwipe, LeadDetails>> late, List<Tuple<CmRecords, GlcSwipe, LeadDetails>> noSwipe, Admin PF)
        {
            string PFBody = "Dear " + PF.Name + ",\nThe following people were marked as swiping late:\n";

            string PFBodyHtml = "<p>Dear " + PF.Name + ",\n</p><p>The following people were marked as swiping late:\n</p>" +
                                "<table><tr><th>Name</th><th>MID</th><th>Time</th></tr>";
            //SMTP client
            SmtpClient sC = new SmtpClient("smtp.gmail.com");
            //port number for Gmail mail
            sC.Port = 587;
            //credentials to login in to Gmail account
            sC.Credentials = new NetworkCredential("orchardkalinga@gmail.com", "Orchardkalinga18");
            //enabled SSL
            sC.EnableSsl = true;

            try
            {
                foreach (var cm in late)
                {
                    //Mail Message
                    MailMessage mM = new MailMessage();
                    //Mail Address
                    mM.From = new MailAddress("orchardkalinga@gmail.com");
                    //receiver email id
                    mM.To.Add(cm.Item1.Email);
                    mM.CC.Add(cm.Item3.LeadEmail);
                    //subject of the email
                    mM.Subject = "GLC NOT ON TIME SWIPE: " + cm.Item2.Datetime.ToLongDateString();

                    //add the body of the email
                    mM.Body = "Dear " + cm.Item1.FirstName + " " + cm.Item1.LastName + ",\n" +
                        "You are late this morning & swiped in at " + cm.Item2.Datetime.ToLongTimeString() +
                        ".\nYour People Function representative will get in touch with you soon.\n\n" +
                        "**THIS IS AN AUTOMATED MESSAGE DO NOT RESPOND**";
                    await sC.SendMailAsync(mM);

                    PFBody += cm.Item1.FirstName + " " + cm.Item1.LastName + " (MID: " + cm.Item1.Mid + "), Time: " + cm.Item2.Datetime.ToLongTimeString() + "\n";
                    PFBodyHtml += "<tr><td>" + cm.Item1.FirstName + " " + cm.Item1.LastName + "</td><td>" + cm.Item1.Mid + "</td><td>" + cm.Item2.Datetime.ToLongTimeString() + "</td></tr>";
                }
                PFBody += "\nThe following people were marked as not swiping: \n";
                PFBodyHtml += "</table><p>The following people were marked as not swiping: \n" +
                    "           (Those not on campus will be written in bold)\n</p>" +
                            "<table><tr><th>Name</th><th>MID</th></tr>";
                foreach (var cm in noSwipe)
                {
                    //Mail Message
                    MailMessage mM = new MailMessage();
                    //Mail Address
                    mM.From = new MailAddress("orchardkalinga@gmail.com");
                    //receiver email id
                    mM.To.Add(cm.Item1.Email);
                    mM.CC.Add(cm.Item3.LeadEmail);
                    if (cm.Item2.Swipetype == ((SwipeType)2).ToString())
                    {
                        //subject of the email
                        mM.Subject = "GLC NO SWIPE: "+ cm.Item2.Datetime.ToLongDateString();
                        //add the body of the email
                        mM.Body = "Dear " + cm.Item1.FirstName + " " + cm.Item1.LastName + ",\n" +
                            "You did not swipe into campus this morning.\n" +
                            "Your People Function representative will get in touch with you soon.\n\n" +
                            "**THIS IS AN AUTOMATED MESSAGE DO NOT RESPOND**";
                        PFBodyHtml += "<tr><td>" + cm.Item1.FirstName + " " + cm.Item1.LastName + "</td><td>" + cm.Item1.Mid + "</td></tr>";
                    }
                    else {
                        //subject of the email
                        mM.Subject = "NOT ON CAMPUS: " + cm.Item2.Datetime.ToLongDateString();
                        //add the body of the email
                        mM.Body = "Dear " + cm.Item1.FirstName + " " + cm.Item1.LastName + ",\n" +
                            "We are unable to track you inside the campus.\n" +
                            "Please contact your PF as soon as possible to let us know if you are safe and well.\n\n" +
                            "**THIS IS AN AUTOMATED MESSAGE DO NOT RESPOND**";
                        PFBodyHtml += "<tr><td><b>" + cm.Item1.FirstName + " " + cm.Item1.LastName + "</b></td><td><b>" + cm.Item1.Mid + "</b></td></tr>";
                    }
                   
                    await sC.SendMailAsync(mM);

                    PFBody += cm.Item1.FirstName + " " + cm.Item1.LastName + " (MID: " + cm.Item1.Mid + ")\n";
                }
                PFBody += "\nEmails have been sent to all listed to notify them of their default.\n" +
                    "**THIS IS AN AUTOMATED MESSAGE DO NOT RESPOND**";
                PFBodyHtml += "</table><p>\nEmails have been sent to all listed to notify them of their default.\n</p>" +
                    "<p>**THIS IS AN AUTOMATED MESSAGE DO NOT RESPOND**</p>";
                MailMessage PFMessage = new MailMessage();
                //Mail Address
                PFMessage.From = new MailAddress("orchardkalinga@gmail.com");
                //receiver email id
                PFMessage.To.Add(PF.Email);
                PFMessage.Subject = "List of defaulters for " + DateTime.Now.ToShortDateString();
                AlternateView plain = AlternateView.CreateAlternateViewFromString(PFBody, null, "text/plain");
                AlternateView html = AlternateView.CreateAlternateViewFromString(PFBodyHtml, null, "text/html");
                PFMessage.AlternateViews.Add(plain);
                PFMessage.AlternateViews.Add(html);
                await sC.SendMailAsync(PFMessage);
                sC.Dispose();
                //Send an email
            }//end of try block
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task SendCodeEmail(String UserEmail, String Code)
        {
            MailMessage resetMessage = new MailMessage();
            resetMessage.From = new MailAddress("23Ted1995@gmail.com");
            resetMessage.To.Add(UserEmail);
            resetMessage.Subject = "AMS PASSWORD RESET";
            resetMessage.Body = "here is your reset code: " + Code;
            SmtpClient sm = new SmtpClient("smtp.gmail.com");
            sm.Port = 587;
            sm.Credentials = new NetworkCredential("orchardkalinga@gmail.com", "Orchardkalinga18");
            sm.EnableSsl = true;
            await sm.SendMailAsync(resetMessage);

        }
       public async Task AlterMail(List<CmRecords> list, Admin PF)
        {
            foreach (var data in list)
            {
                MailMessage alertMessage = new MailMessage();
                alertMessage.From = new MailAddress("23Ted1995@gmail.com");
                alertMessage.To.Add(data.Email);
                alertMessage.CC.Add(PF.Email);
                alertMessage.Subject = "AMS PASSWORD RESET";
                alertMessage.Body = "Dear Campus Minds," +
                "We are observing that  many of you are swiping after 8.30 am and coming late for the stand up.As already communicated, finish your breakfast and swipe in before 8.25 am. \n" +
                "Please note that coming late to work affects not only your work, it affects the entire process you are involved in. \n" +
                "Please be responsible and follow the procedure \n" +
                "\n\n\n\n" +
                "Thanks \n" +
                PF.Name +
                "\n\n\n **THIS IS AN AUTOMATED MESSAGE DO NOT RESPOND**";
                SmtpClient sm = new SmtpClient("smtp.gmail.com");
                sm.Port = 587;
                sm.Credentials = new NetworkCredential("orchardkalinga@gmail.com", "Orchardkalinga18");
                sm.EnableSsl = true;
                await sm.SendMailAsync(alertMessage);
            }
        }
    }
}
