using System.Diagnostics;
using System.Net.Mail;


namespace BusServiceApplication.HelperMethods
{
    public class EmailSender
    {

        public async Task<string> RegisterationEmail(string parentName , string parentEmailAddress)
        {
            try
            {
                var message = string.Empty;
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("ImpumeleloBusServiceBookingSystem@outlook.com"); // get the values from appSettings 
                    mail.To.Add($"{parentEmailAddress}"); // email to the parent value passed in 
                    mail.Subject = "Successful Registration";
                    mail.Body = EmailMessages.RegistrationMessage(parentName, parentEmailAddress);
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.outlook.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential(
                            "ImpumeleloBusServiceBookingSystem@outlook.com", "Password123!@#");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        message = "mail Sent ";
                        smtp.Dispose();
                    }

                    return message;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error : {ex}");
                throw;
            }
        }

        public async Task<string> SuccessfullyAddedToBus(string parentName , string parentEmailAddress,  string childName, string busDetails, string busTime)
        {
            try
            {
                var message = string.Empty;
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("ImpumeleloBusServiceBookingSystem@outlook.com"); // get the values from appSettings 
                    mail.To.Add($"{parentEmailAddress}"); // email to the parent value passed in 
                    mail.Subject = "Successfully applied for bus service";
                    mail.Body = EmailMessages.ChildAddedToBus(parentName, childName, busDetails, busTime);
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.outlook.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential(
                            "ImpumeleloBusServiceBookingSystem@outlook.com", "Password123!@#");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        message = "mail Sent ";
                        smtp.Dispose();
                    }

                    return message;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error : {ex}");
                throw;
            }
        }

        public async Task<string> AddedToWaitingList(string parentName, string parentEmailAddress, string childName, string busDetails)
        {
            try
            {
                var message = string.Empty;
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("ImpumeleloBusServiceBookingSystem@outlook.com"); // get the values from appSettings 
                    mail.To.Add($"{parentEmailAddress}"); // email to the parent value passed in 
                    mail.Subject = "Added to waiting list";
                    mail.Body = EmailMessages.ChildAddedToWaitingList(parentName, childName, busDetails);
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.outlook.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential(
                            "ImpumeleloBusServiceBookingSystem@outlook.com", "Password123!@#");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        message = "mail Sent ";
                        smtp.Dispose();
                    }
                    return message;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error : {ex}");
                throw;
            }
        }

    }
}
