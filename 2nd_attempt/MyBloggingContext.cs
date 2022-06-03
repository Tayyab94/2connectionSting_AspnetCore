using Microsoft.EntityFrameworkCore;

namespace c_string_demo._2nd_attempt
{
    public class MyBloggingContext :BloggingContext<MyBloggingContext>
    {
        public MyBloggingContext(string connectionString) : base(connectionString) { }
        public MyBloggingContext(DbContextOptions<MyBloggingContext> options) : base(options) { }
    }
}
