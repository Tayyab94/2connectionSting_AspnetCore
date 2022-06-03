using c_string_demo.Repos;
using Microsoft.AspNetCore.Mvc;
using c_string_demo.Models;

namespace c_string_demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IStudentRepo studentRepo;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IStudentRepo student)
        {
            _logger = logger;
            studentRepo = student;
        }

        [HttpPost]
        public async Task<IActionResult> addStudent([FromBody] studentVM student)
        {
            var model = new Student()
            {
                Name = student.studentName
            };
         await   this.studentRepo.AddStudent(model);

            return Ok(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> getAll()
        {
            var data = await studentRepo.GetAll();
            return data;
        }
    }

    public class studentVM
    {
        public string studentName { get; set; }
    }
}