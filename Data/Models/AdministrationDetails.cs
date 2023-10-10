using System.ComponentModel.DataAnnotations;

namespace BusServiceApplication.Data.Models
{
    public class AdministrationDetails
    {
        [Key]
        public string Id { get; set; }

        public char initials { get; set; }

        public string surname { get; set; }

        public string emailAddress { get; set; }

        public string password { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
