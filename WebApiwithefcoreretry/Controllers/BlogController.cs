using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using WebApiwithefcoreretry.Data;
using WebApiwithefcoreretry.Entity;

namespace WebApiwithefcoreretry.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<BlogController> _logger;
        private readonly BlogDBContext _blogDBContext;

        public BlogController(ILogger<BlogController> logger, 
            BlogDBContext blogDBContext)
        {
            _logger = logger;
            _blogDBContext = blogDBContext;
        }

        [HttpGet(Name = "GetBlogs")]
        public IEnumerable<Blog> Get()
        {
            List<Blog> list = new List<Blog>();
            try
            {
                list =  _blogDBContext.Blogs.ToList();
            }

            catch (RetryLimitExceededException ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            catch (Exception)
            {

                throw;
            }
          
            return list;
        }
    }
}
