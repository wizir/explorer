using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace explorer.Model
{
    public abstract class DatabaseObject
    {
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? LastModified { get; set; }
    }
}