using System;
using System.Linq;

namespace explorer.Model
{
    public class DatabaseRepository<T> : IRepository<T>
        where T: DatabaseObject
    {
        private PostgreDbContext<T> _context;
        public IQueryable<T> Items => _context.Items;

        public DatabaseRepository(PostgreDbContext<T> context)
        {
            _context = context;
        }
        
        
        public void SaveItem(T item)
        {
            if (item.Id == default)
            {
                item.Created = DateTimeOffset.Now;
                _context.Add(item);
            }
            else
            {
                item.LastModified = DateTimeOffset.Now;
                _context.Update(item);
            }

            _context.SaveChanges();
        }

        public T DeleteItem(int id)
        {
            var item = _context.Items.FirstOrDefault(entity => entity.Id == id) ?? throw new NullReferenceException(
                             $"Entity of type {typeof(T)} with id {id} not found in the database.");
            
            _context.Remove(item);
            return item;
        }
    }
}