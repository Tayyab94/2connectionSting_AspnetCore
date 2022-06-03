using c_string_demo._2nd_attempt;
using c_string_demo.Models;
using Microsoft.EntityFrameworkCore;

namespace c_string_demo.Repos
{
    public class StudentRepo : IStudentRepo
    {
        private readonly MyBloggingContext myBloggingContext;
        private readonly MyBackupBloggingContext myBackupBloggingContext;

        public StudentRepo(MyBloggingContext bloggingContext, MyBackupBloggingContext backUp)
        {
            myBloggingContext = bloggingContext;
            myBackupBloggingContext = backUp;
        }
        public async Task AddStudent(Student student)
        {
            try
            {
                myBloggingContext.Students.Add(student);
                await myBloggingContext.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;
            }
            try
            {
                myBackupBloggingContext.Students.Add(new Student() { Name= student.Name});
                await myBackupBloggingContext.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;
            }

       

       
        }

        public async Task<List<Student>> GetAll()
        {
            return await myBackupBloggingContext.Students.ToListAsync();
        }
    }
}
