using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace explorer.Model
{
    [Table("DiaryPages")]
    public class Page : DatabaseObject
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}