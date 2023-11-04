using BusServiceApplication.Pages.Parent_Componenets;

namespace BusServiceApplication.HelperMethods
{
    public class EmailMessages
    {
        public static string RegistrationMessage(string parentName,string parentEmailAddress)
        {
            var message = 
            $"<h1> Greetings {parentName} </h1> \n " +
            $"<p> Thank you for registering for the Impumelelo Bus Service Booking System \n </p>" +
            $"<p>We have your email address as {parentEmailAddress} </p> \n" +
            $"<p> Please feel free to contact us on 0812440694 if you experience any issues </p> \n " +
            $"<p>Kind Regards </p> \n" +
            $"<p> The Bus Service team </p> ";
            
            return message;
        }


        public static string ChildAddedToBus(string parentName , string childName , string busdetails, string bustTime)
        {
            var message =
                $"<h1> Greetings {parentName} </h1> \n " +
                $"<p> We are happy to inform you that you have successfully booked a place for {childName} on the </p> " +
                $"<p>{busdetails} bus route during {bustTime} </p> \n" +
                $"<p>Should you have any querries, please contact us on 081244094  </p> \n " +
                $"<p>kind regards \n " +
                $"<p>The Bus Service Team </p>";

            return message;
        }

        public static string ChildAddedToWaitingList(string parentName , string childname, string busdetails )
        {
            var message =
            $"<h1> Greetings {parentName} </h1> \n " +
                $"<p> Based on the bus rout selected, all seats on the current route : {busdetails} are currently booked  </p> \n" +
                $"<p> We have added {childname} to the waiting list and will inform you if a space opens  </p> \n" +
                $"<p>Should you have any querries, please contact us on 081244094  </p> " +
                $"<p>kind Regards  </p> \n" +
                $"<p>The bus service team </p>";

            return message;


        }
    }


}
