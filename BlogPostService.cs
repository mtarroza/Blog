using Microsoft.Extensions.Logging;

namespace Blog
{
    public interface IBlogPostService
    {
        public void WriteLog(string message);
    }
    public class BlogPostService : IBlogPostService
    {
        public ILogger Logger { get; set; }
        public void WriteLog(string message)
        {
            Logger.LogInformation(message);
        }
    }
}
