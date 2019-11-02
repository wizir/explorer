using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace explorer.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTimeOffset? Created { get; set; }
        public DateTimeOffset? LastModified { get; set; }
    }
}