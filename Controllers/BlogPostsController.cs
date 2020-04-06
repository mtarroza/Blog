
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Blog.Data;
using Blog.Models;

namespace Blog.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly BlogPostsContext _context;
        private readonly IDataRepository<BlogPost> _repo;
        private readonly ILogger<BlogPostsController> _logger;

        public BlogPostsController(BlogPostsContext context, IDataRepository<BlogPost> repo, ILogger<BlogPostsController> logger)
        {
            _context = context;
            _repo = repo;
            _logger = logger;
        }

        // GET: api/BlogPosts
        [HttpGet]
        public IEnumerable<BlogPost> GetBlogPost()
        {
            _logger.LogInformation(LoggingEvents.GetAllBlogPosts,"Getting all BlogPosts");
            return _context.BlogPosts.OrderByDescending(p => p.PostId);
        }

        // GET: api/BlogPosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBlogPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _logger.LogInformation(LoggingEvents.GetBlogPostFromId, "Getting BlogPost with Id: {Id}", id);
            var blogPost = await _context.BlogPosts.FindAsync(id);

            if (blogPost == null)
            {
                _logger.LogWarning(LoggingEvents.GetBlogPostFromIdNotFound, "Requested BlogPost with Id: {Id} NOT FOUND", id);
                return NotFound();
            }

            return Ok(blogPost);
        }

        // PUT: api/BlogPosts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogPost([FromRoute] int id, [FromBody] BlogPost blogPost)
        {
            _logger.LogInformation(LoggingEvents.UpdateBlogPostWithId, "Updating BlogPost with Id: {0}", id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blogPost.PostId)
            {
                _logger.LogWarning(LoggingEvents.UpdateBlogPostWithIdNotFound, "Update for BlogPost with Id: {0} BAD REQUEST", id);
                return BadRequest();
            }

            _context.Entry(blogPost).State = EntityState.Modified;

            try
            {
                _repo.Update(blogPost);
                await _repo.SaveAsync(blogPost);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogPostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BlogPosts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<IActionResult> PostBlogPost([FromBody] BlogPost blogPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _logger.LogInformation(LoggingEvents.CreateBlogPost, "Creating BlogPost from Creator: {0}", blogPost.Creator);

            _repo.Add(blogPost);
            await _repo.SaveAsync(blogPost);

            return CreatedAtAction("GetBlogPost", new { id = blogPost.PostId }, blogPost);
        }

        // DELETE: api/BlogPosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _logger.LogInformation(LoggingEvents.DeleteBlogPostWithId, "Deleting BlogPost with Id: {0}", id);
            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost == null)
            {
                _logger.LogInformation(LoggingEvents.DeleteBlogPostWithIdNotFound, "Requested BlogPost with Id: {0} NOT FOUND", id);
                return NotFound();
            }

            _repo.Delete(blogPost);
            var save = await _repo.SaveAsync(blogPost);

            return Ok(blogPost);
        }

        private bool BlogPostExists(int id)
        {
            return _context.BlogPosts.Any(e => e.PostId == id);
        }
    }
}
