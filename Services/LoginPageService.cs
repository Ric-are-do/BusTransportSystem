using BusServiceApplication.Data;
using BusServiceApplication.Data.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Components;
using System.Net.Mail;


namespace BusServiceApplication.Services
{
    public class LoginPageService
    {
        private IDbContextFactory<ProjectDbContext> _dbComtextFactory;

        public LoginPageService(IDbContextFactory<ProjectDbContext> dbComtextFactory)
        {
            _dbComtextFactory = dbComtextFactory;
        }   

        // All methods that we will implement with the Login Services are noted below 

        //Registration Methods 
        public void RegisterANewUser(ParentDetails User)
        {
            using (var context = _dbComtextFactory.CreateDbContext()) 
            { 
                context.loginProfile.Add(User);
                context.SaveChanges();
            }
        }

        // check that the user registering has a unique Username and email address
        public void CheckThatCredenetailsAreUnique(string enteredUsername , string enteredEmailAddress)
        {
            using (var context = _dbComtextFactory.CreateDbContext())
            {
                var Username = context.loginProfile.SingleOrDefault(x => x.username == enteredUsername);
               var EmailAddress = context.loginProfile.SingleOrDefault(x => x.emailAddress == enteredEmailAddress);
                if(Username == null && EmailAddress == null)
                {
                    Debug.WriteLine("PASS");
                }
                else
                {
                    throw new Exception ("There is a username or email address that exists");
                }

            }
        }

        //-----------------------------------------------------------------------------
        //login Methods 
        public void GetUserNameForLogIn(string emailAddress , string passowrd)
        {
            //create a user context
            using (var context = _dbComtextFactory.CreateDbContext())
            {
                var UserName = context.loginProfile.SingleOrDefault(x => x.emailAddress == emailAddress);
                var UserPassword = context.loginProfile.SingleOrDefault(y => y.password == passowrd);
                if (UserName == null || UserPassword == null)
                {
                    throw new Exception("UserName or Password is incorrect");
                }
                else
                {
                    // add a navigation page here that takes the user to their profile Page.
                    Debug.WriteLine("both Returned successfully");

                }
            }
        }
        //---------------------------------------------------------------------------------------------------------
        //Return Parent Object 
        public ParentDetails GetParentObject(string emailAddress , string passowrd)
        {
            using (var context = _dbComtextFactory.CreateDbContext())
            {
                var parentObject = context.loginProfile.SingleOrDefault(x => x.emailAddress == emailAddress && x.password == passowrd );
                
                if (parentObject == null)
                {
                    throw new Exception("email address is or password is incorrect");
                }
                else
                {
                    return parentObject;
                }
            }
        }

        //This method will return a parent object by searching for the userName 
        public ParentDetails GetParentObjectWithUserName(string userName)
        {
            using (var context = _dbComtextFactory.CreateDbContext())
            {
                var parentObject = context.loginProfile.SingleOrDefault(x => x.username == userName);

                if (parentObject == null)
                {
                    throw new Exception("email address is or password is incorrect");
                }
                else
                {
                    return parentObject;
                }
            }

        }

        //-----------------------------------------------------------------------------------
        //Administarion log in methods 

        public void GetAdminForLogIn(string emailAddress, string passowrd)
        {
            //create a user context
            using (var context = _dbComtextFactory.CreateDbContext())
            {
                var UserName = context.administrationDetails.SingleOrDefault(x => x.emailAddress == emailAddress && x.password== passowrd);
                if (UserName.emailAddress == null || UserName.password == null)
                {
                    throw new Exception("UserName or Password is incorrect");
                }
                else
                {
                    // add a navigation page here that takes the user to their profile Page.
                    Debug.WriteLine("both Returned successfully");

                }
            }
        }

        public AdministrationDetails GetAdminObjectWithLoginDetails(string emailAddress, string password)
        {
            using (var context = _dbComtextFactory.CreateDbContext())
            {
                var AdminLoggingIn = context.administrationDetails.SingleOrDefault( x => x.emailAddress == emailAddress && x.password== password);
                if(AdminLoggingIn == null)
                {
                    throw new Exception("admin details returned Null");
                }
                else
                {
                    return AdminLoggingIn; 
                }
            }
        }

    }
}
