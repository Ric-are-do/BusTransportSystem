using BusServiceApplication.Data;
using BusServiceApplication.Data.Models;
using BusServiceApplication.HelperMethods;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace BusServiceApplication.Services
{
    public class AdministratorServices
    {
        private IDbContextFactory<ProjectDbContext> _dbContextFactory;

        //constructor
        public AdministratorServices(IDbContextFactory<ProjectDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        //methods for administrtor
        public void AddAdministrator(AdministrationDetails administrationDetails)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.administrationDetails.Add(administrationDetails);
                context.SaveChanges();
            }
        }

        // get admin login details 
        public void GetAdministratorDetailsForLogin(string EmailAddress, string Password)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var administratorEmail = context.administrationDetails.SingleOrDefault(x => x.emailAddress == EmailAddress);
                var administratorPassword = context.administrationDetails.SingleOrDefault(x => x.password == Password);
                if (administratorEmail == null || administratorPassword == null)
                {
                    Debug.WriteLine("Password Or Email Is incorrect ");
                }
                else
                {
                    Debug.WriteLine($"{administratorEmail} and {administratorPassword}");
                }

            }
        }

        //get administrator based on the ID thats passed in 
        public AdministrationDetails GetAdministratorDetailsFromId(string passedInId)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var administrator = context.administrationDetails.SingleOrDefault(x => x.Id == passedInId);

                if (administrator == null)
                {
                    Debug.WriteLine("adminIsNotInDatabase");
                }
                return administrator;
            }
        }

        //------------------------------------------------------------------------------
        //Get Back a List Of Students On the waiting List 
        public List<WaitingListDetails> GetStudentsOnWaitingList() // create a method that will return a list of items from the DB 
        {
            using (var context = _dbContextFactory.CreateDbContext()) // create a connection to our database 
            {
                // store the list of items that match the lumda expression then store them into this list 
                // we are creating a context to the waitingListDetails Table whic
                var ListOfStudents = context.waitingListDetails.ToList();
                return ListOfStudents;
            }
        }

        // create a list of all students On the Morning trip 
        public List<BusDetailsMorning> GetStudentsOnMorningBus()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var ListOfStudentsOnMorningBus = context.busDetailsMorning.ToList();
                return ListOfStudentsOnMorningBus;
            }
        }

        // create a list of students on the Afternoon trup
        public List<BusDetailsAfternoon> GetStudentsOnAfternoonBus()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var ListOfStudentsOnAfternonBus = context.busDetailsAfternoon.ToList();
                return ListOfStudentsOnAfternonBus;
            }
        }

        //-----------------------------------------------------------------
        //Methods For MIS reports 

        //Lets admin search for students on a given day in afternoon trip
        public List<BusDetailsAfternoon> GetListOfStudentsOnAfternoonBusAndSelectDate(DateTime selectedDate)
        {
            List<BusDetailsAfternoon> selectedStudents = new List<BusDetailsAfternoon>(); // empty lIst 

            using (var context = _dbContextFactory.CreateDbContext())
            {
                var ListOfStudentsOnAfternoonBus = context.busDetailsAfternoon.ToList();  // this will get all entries in the DB table 

                foreach (var student in ListOfStudentsOnAfternoonBus) // we loop sthough students 
                {
                    if (student.TakingBusStartDate <= selectedDate && selectedDate <= student.TakingBusEndDate) // if student matches this condition
                    {
                        selectedStudents.Add(student); // add them to empty list 
                    }
                }
            }
            return selectedStudents;
        }

        //Lets admin search for students on a given day in Morning trip
        public List<BusDetailsMorning> GetListOfStudentsOnMorningBusAndSelectDate(DateTime selectedDate)
        {
            List<BusDetailsMorning> selectedStudents = new List<BusDetailsMorning>(); // empty lIst 

            using (var context = _dbContextFactory.CreateDbContext())
            {
                var ListOfStudentsOnAfternoonBus = context.busDetailsMorning.ToList();  // this will get all entries in the DB table 

                foreach (var student in ListOfStudentsOnAfternoonBus) // we loop sthough students 
                {
                    if (student.TakingBusStartDate <= selectedDate && selectedDate <= student.TakingBusEndDate) // if student matches this condition
                    {
                        selectedStudents.Add(student); // add them to empty list 
                    }
                }
            }
            return selectedStudents;
        }

        //Lets admin search for students during a week of the given date for the morning trip
        public List<BusDetailsMorning> GetListOfStudentsOnMorningBusDuringWeek(DateTime weekStartDate)
        {
            DateTime weekEndDate = weekStartDate.AddDays(6); // this is how we determine a weeks period from start date
            List<BusDetailsMorning> selectedStudents = new List<BusDetailsMorning>(); // this is the list we will add results to 

            //below is our DbContext
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var listOfStudentsOnMorningBus = context.busDetailsMorning.ToList();

                foreach (var student in listOfStudentsOnMorningBus)
                {
                    if (student.TakingBusStartDate <= weekStartDate)
                    {
                        selectedStudents.Add(student);
                    }
                }
            }
            return selectedStudents;

        }

        public List<BusDetailsAfternoon> GetListOfStudentsOnAfternoonBusDuringWeek(DateTime weekStartDate)
        {
            DateTime weekEndDate = weekStartDate.AddDays(6); // this is how we determine a weeks period from start date
            List<BusDetailsAfternoon> selectedStudents = new List<BusDetailsAfternoon>(); // this is the list we will add results to 

            //below is our DbContext
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var listOfStudentsOnAfternoongBus = context.busDetailsAfternoon.ToList();

                foreach (var student in listOfStudentsOnAfternoongBus)
                {
                    if (student.TakingBusStartDate <= weekStartDate)
                    {
                        selectedStudents.Add(student);
                    }
                }
            }
            return selectedStudents;

        }

        //-------------------------------------------
        // Delete a student record on the waiting List using The ID of that record 

        public void DeleteStudentFromWaitinList(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var recordToDelete = context.waitingListDetails.SingleOrDefault(x => x.id == id);
                if (recordToDelete != null) // if we find the record with this ID 
                {
                    context.waitingListDetails.Remove(recordToDelete);
                    context.SaveChanges();
                }
                else
                {
                    Debug.WriteLine("Record Not Found");
                }
            }
        }

        //Add a student from the waiting list to the bus they needed to be on 

        public void UpdateAndTransferToAfternoonList(WaitingListDetails waitingListDetails)
        {
            var afternoonDetails = new BusDetailsAfternoon
            {
                ChildUserNameId = waitingListDetails.ChildUserNameId,
                BusNumber = waitingListDetails.BusNumber,
                BusLimit = waitingListDetails.BusLimit,
                MorningTrip = waitingListDetails.MorningTrip,
                Area = waitingListDetails.Area,
                BusRouteAAddress = waitingListDetails.BusRouteAAddress,
                BusRouteAPickupTime = waitingListDetails.BusRouteAPickupTime,
                BusRouteBAddress = waitingListDetails.BusRouteBAddress,
                BusRouteBPickupTime = waitingListDetails.BusRouteBPickupTime,
                DateEntryCreated = DateTime.Now, // Set the current date and time for the new object
                TimeEntryCreated = DateTime.Now.ToString("HH:mm:ss"), // Set the current time for the new object
                TakingBusStartDate = waitingListDetails.TakingBusStartDate,
                TakingBusEndDate = waitingListDetails.TakingBusEndDate
            };

            // next we add the object to the Afternoon Details list 

            using (var context =  _dbContextFactory.CreateDbContext())
            {
                context.busDetailsAfternoon.Add(afternoonDetails);
                context.SaveChanges();
            }

            //Delete the student from the waiting List 
            DeleteStudentFromWaitinList(waitingListDetails.id);
        }

        //Repeat the code for for the moring list 

        public void UpdateAndTransferToMorningList(WaitingListDetails waitingListDetails)
        {
            var afternoonDetails = new BusDetailsMorning
            {
                ChildUserNameId = waitingListDetails.ChildUserNameId,
                BusNumber = waitingListDetails.BusNumber,
                BusLimit = waitingListDetails.BusLimit,
                MorningTrip = waitingListDetails.MorningTrip,
                Area = waitingListDetails.Area,
                BusRouteAAddress = waitingListDetails.BusRouteAAddress,
                BusRouteAPickupTime = waitingListDetails.BusRouteAPickupTime,
                BusRouteBAddress = waitingListDetails.BusRouteBAddress,
                BusRouteBPickupTime = waitingListDetails.BusRouteBPickupTime,
                DateEntryCreated = DateTime.Now, // Set the current date and time for the new object
                TimeEntryCreated = DateTime.Now.ToString("HH:mm:ss"), // Set the current time for the new object
                TakingBusStartDate = waitingListDetails.TakingBusStartDate,
                TakingBusEndDate = waitingListDetails.TakingBusEndDate
            };

            // next we add the object to the Afternoon Details list 

            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.busDetailsMorning.Add(afternoonDetails);
                context.SaveChanges();
            }

            //Delete the student from the waiting List 
            DeleteStudentFromWaitinList(waitingListDetails.id);
        }

        //----------------------------------------------------

    }

}
