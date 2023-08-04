using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusServiceApplication.Data.Models
{
    public class BusDetailsAfternoon
    {
        [Key]
        public int AfternoonID { get; set; } // Key property

        // Foreign key referencing the StudentDetails model
        public string ChildUserNameId { get; set; }

        // Navigation property to access the associated StudentDetails
        [ForeignKey(nameof(ChildUserNameId))]
        public StudentDetails StudentDetails { get; set; }

        public int BusNumber { get; set; }
        public int BusLimit { get; set; }
        public bool MorningTrip { get; set; }
        public string Area { get; set; }

        // Bus Route 1A
        public string BusRouteAAddress { get; set; }
        public string BusRouteAPickupTime { get; set; }

        // Bus Route 1B
        public string BusRouteBAddress { get; set; }
        public string BusRouteBPickupTime { get; set; }

        public DateTime DateEntryCreated { get; set; }
        public string TimeEntryCreated { get; set; }

        public DateTime TakingBusStartDate { get; set; }
        public DateTime TakingBusEndDate { get; set; }
    }
}
