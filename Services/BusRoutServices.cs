using BusServiceApplication.Data;
using BusServiceApplication.Data.Models;
using BusServiceApplication.Pages.StudentComponents;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BusServiceApplication.Services
{
    public class BusRoutServices
    {

        private IDbContextFactory<ProjectDbContext> _dbContextFactory;

        //constructor where we create the DB context 
        public BusRoutServices(IDbContextFactory<ProjectDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        //-----------------------------------------------------------------------
        // Morning Bus Services 

        //Add A user to the MORNING bus 
        public void addStudentToMorningBus(BusDetailsMorning studentUsingBus)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.busDetailsMorning.Add(studentUsingBus);
                context.SaveChanges();
            }
        }

        //Logic that checks if there is space on the bus for the user 
        public bool checkSpaceOnTheBusMorning(BusDetailsMorning studnetUsingBus)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                int usedSpace = context.busDetailsMorning.Where(x => x.BusNumber == studnetUsingBus.BusNumber).Count();
                if (usedSpace == studnetUsingBus.BusLimit || usedSpace > studnetUsingBus.BusLimit)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        //Service to add student to the waiting list 
        public void  addStudentToWaitingList(WaitingListDetails studentUsingBusMovedToWaitingList)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.waitingListDetails.Add(studentUsingBusMovedToWaitingList);
                context.SaveChanges() ;
                
            }
        }

        //Get List of Studnets on the morning bus 
        public List<BusDetailsMorning> GetListOfStudentsOnMorningBus()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var listOfStudentsOnMorningBus = context.busDetailsMorning.ToList();  // this will get all entries in the DB table 
                return listOfStudentsOnMorningBus; // return the list as an object 
            }
        }

        //----------------------------------------------------------------------------
        // Afternoon bus Services 

        public void addStudentToAfternoonBus(BusDetailsAfternoon studentUsingBus)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.busDetailsAfternoon.Add(studentUsingBus);
                context.SaveChanges();
            }
        }

        //Logic that checks if there is space on the bus for the user 
        public bool checkSpaceOnTheBusAfternoon(BusDetailsAfternoon studnetUsingBus)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                int usedSpace = context.busDetailsAfternoon.Where(x => x.BusNumber == studnetUsingBus.BusNumber).Count();
                if (usedSpace == studnetUsingBus.BusLimit || usedSpace > studnetUsingBus.BusLimit)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        //Get List of Studnets on the Afternnon bus 
        public List<BusDetailsAfternoon> GetListOfStudentsOnAfternoonBus()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var listOfStudentsOnMorningBus = context.busDetailsAfternoon.ToList();  // this will get all entries in the DB table 
                return listOfStudentsOnMorningBus;
            }
        }

        //-----------------------------------
        //Delete a student from a specific bus rout 

  
        public void DeleteStudentFromBusRoutMorning(string childUsername, int busNumber  )
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var recordToDeleteChildID = context.busDetailsMorning.Where(x => x.ChildUserNameId == childUsername);
                var recordToDeleteBusNumber = context.busDetailsMorning.Where(x => x.BusNumber == busNumber);
                if (recordToDeleteChildID != null && recordToDeleteBusNumber != null) // if we find the record with this ID 
                {
                    context.busDetailsMorning.Remove((BusDetailsMorning)recordToDeleteChildID);
                    context.SaveChanges();
                }
                else
                {
                    Debug.WriteLine("Record Not Found");
                }
            }
        }

        public void DeleteStudentFromBusRoutAfternoon(string childUsername, int busNumber)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var recordToDeleteChildID = context.busDetailsAfternoon.Where(x => x.ChildUserNameId == childUsername);
                var recordToDeleteBusNumber = context.busDetailsAfternoon.Where(x => x.BusNumber == busNumber);
                if (recordToDeleteChildID != null && recordToDeleteBusNumber != null) // if we find the record with this ID 
                {
                    context.busDetailsAfternoon.Remove((BusDetailsAfternoon)recordToDeleteChildID);
                    context.SaveChanges();
                }
                else
                {
                    Debug.WriteLine("Record Not Found");
                }
            }
        }


    }
}
