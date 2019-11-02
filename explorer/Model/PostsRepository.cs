using System;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using Microsoft.Extensions.FileProviders;

namespace explorer.Model
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts { get; }
        void SavePost(Post post);
        Post DeletePost(int id);

    }
    
    
    public class PostsRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;
        public PostsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Post> Posts => _context.Posts;

        public void SavePost(Post post)
        {
            if(post.Created == null) post.Created = DateTimeOffset.Now;
            
            if (post.Id == 0)
            {
                _context.Add(post);
            }
            else
            {
                var entry = _context.Posts.FirstOrDefault(p => p.Id == post.Id);
                if (entry != null)
                {
                    entry.Title = post.Title;
                    entry.Body = post.Body;
                    entry.LastModified = DateTimeOffset.Now;
                }
            }

            _context.SaveChanges();
        }

        public Post DeletePost(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (post != null)
            {
                _context.Remove(post);
                _context.SaveChanges();
            }
            return post;
        }
    }
}