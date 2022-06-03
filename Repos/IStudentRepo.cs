using c_string_demo.Models;

namespace c_string_demo.Repos
{
    public interface IStudentRepo
    {
        Task<List<Student>> GetAll();
        Task AddStudent(Student student);
    }
}
