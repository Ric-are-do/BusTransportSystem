using System.ComponentModel.DataAnnotations;

namespace BusServiceApplication.Data.Models
{
    public class ParentDetails
    {
        [Key]
        public int Id { get; set; }


        public string firstName { get; set; }


        public string lastName { get; set; }

 
        public string emailAddress { get; set; }

       
        public string phoneNumber { get; set; }

      
        public string username { get; set; }

     
        public string password { get; set;  }

       
        public DateTime CreateedDate { get; set; }



    }
}
