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
}


