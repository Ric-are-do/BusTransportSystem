using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusServiceApplication.Data.Models
{
    public class StudentDetails
    {

        [Key]
        public string childUserNameId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CellphoneNumber { get; set; }
        public string Grade { get; set; }
        public DateTime CreatedDate { get; set; }
        // Foreign key to link the student with the parent
        public int ParentId { get; set; }

        // Navigation property to access the associated ParentDetails
        [ForeignKey(nameof(ParentId))]
        public ParentDetails ParentDetails { get; set; }
    }
}
