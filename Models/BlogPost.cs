using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
	/// <summary>
	/// Model for one BlogPost item
	/// </summary>
	public class BlogPost
	{
		[Key]
		public int PostId { get; set; }

		[Required]
		public string Creator { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string Body { get; set; }

		[Required]
		public DateTime Dt { get; set; }
	}

	public class LoggingEvents
	{
		// API Events
		public const int GetAllBlogPosts = 1000;
		public const int GetBlogPostFromId = 1001;
		public const int UpdateBlogPostWithId = 1002;
		public const int CreateBlogPost = 1003;
		public const int DeleteBlogPostWithId = 1004;

		// Failed API Events
		public const int GetBlogPostFromIdNotFound = 4000;
		public const int UpdateBlogPostWithIdNotFound = 4001;
		public const int DeleteBlogPostWithIdNotFound = 4002;
	}
}
