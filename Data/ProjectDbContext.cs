using BusServiceApplication.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BusServiceApplication.Data
{
    //Create our Db Context 
    public class ProjectDbContext : DbContext
    {
        //Create a constructor for the DB context 
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) 
        {
            
        }
        
        // This is where we create contexts for all the tables 
        // Create a context for the ParentDetails Table 
        public DbSet<ParentDetails> loginProfile { get; set; }
        // Create a context for the AdministrationDetails
        public DbSet<AdministrationDetails> administrationDetails { get; set; }
        public DbSet<StudentDetails> studentDetails { get; set; }
        public DbSet<BusDetailsMorning> busDetailsMorning { get; set; }
        public DbSet<WaitingListDetails> waitingListDetails { get; set; }
        public DbSet<BusDetailsAfternoon> busDetailsAfternoon { get; set; }

    }
}
