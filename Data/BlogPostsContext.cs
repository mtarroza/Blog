using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog.Models;

namespace Blog.Data
{
    /// <summary>
    /// Database context for storing and querying BlogPost items
    /// </summary>
    public class BlogPostsContext : DbContext
    {
        public BlogPostsContext(DbContextOptions<BlogPostsContext> options)
            : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
