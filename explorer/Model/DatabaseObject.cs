using System;
using Reinforced.Typings.Attributes;

namespace explorer.Model
{
    [TsClass]
    public abstract class DatabaseObject
    {
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? LastModified { get; set; }
    }
}