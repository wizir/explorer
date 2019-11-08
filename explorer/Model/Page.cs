using System;
using System.ComponentModel.DataAnnotations.Schema;
using Reinforced.Typings.Attributes;

namespace explorer.Model
{
    [TsClass]
    [Table("DiaryPages")]
    public class Page : DatabaseObject
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}