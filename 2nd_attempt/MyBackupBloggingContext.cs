using Microsoft.EntityFrameworkCore;

namespace c_string_demo._2nd_attempt
{
    public class MyBackupBloggingContext : BloggingContext<MyBackupBloggingContext>
    {
        public MyBackupBloggingContext(string conntectionString) : base(conntectionString)
        {
        }

        public MyBackupBloggingContext(DbContextOptions<MyBackupBloggingContext> options) : base(options) { }

    }
}
