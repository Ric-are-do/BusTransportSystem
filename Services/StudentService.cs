using BusServiceApplication.Data.Models;
using BusServiceApplication.Data;
using Microsoft.EntityFrameworkCore;

public class StudentService
{
    private IDbContextFactory<ProjectDbContext> _dbContextFactory;

    //constructor
    public StudentService(IDbContextFactory<ProjectDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    //methods for Student

    //Parent adds student to the database 
    public void AddStudent(StudentDetails student)
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            context.studentDetails.Add(student);
            context.SaveChanges();
        }
    }

    //Parent Views List of Students under them 

    public List<StudentDetails> getAllStudentsUnderLoggedInParent(int parentID)
    {
        using (var context =  _dbContextFactory.CreateDbContext())
        {
            //NB added the to list, this will ensure that the lumda expression is true, the it will be added to the list
            var studentUnderParent = context.studentDetails.Where(x => x.ParentId == parentID).ToList() ;
            return studentUnderParent;
        }
    }

    public List<StudentDetails> GetAllStudentsUsingChildUserNameID( string childUserNameId)
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            var studentList = context.studentDetails.Where(x => x.childUserNameId == childUserNameId).ToList();
            return studentList;
        }
    }

    public StudentDetails GetStudentObjectByChildUserNameID(string childUserNameId)
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            var student = context.studentDetails.SingleOrDefault(x => x.childUserNameId == childUserNameId);
            return student;
        }
    }

    //--------------------------------------------------------------------
    //Return list of children belonging to parent from an OBJECT and NOT A DATABASE 
    //Filter the studetns that belong to a specific parent and return them as objects



    //--------------------------------------------------------------------------
    //Get a parent object from a student object 
    //Here we pass in the ID of the child , then get the parent ID , from there we search the loginProfile for the parent ID and return the parent as an object
    //I plan on using this for the emails
    public ParentDetails getParentObjectUsingchildUserNameID(string childUserNameID)
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            var parentID = context.studentDetails.SingleOrDefault(x => x.childUserNameId == childUserNameID);
            int Id =  parentID.ParentId;
            var parent  = context.loginProfile.SingleOrDefault(x => x.Id == Id);
            return parent;

        }
     }

    


}


