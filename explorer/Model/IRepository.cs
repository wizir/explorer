using System.Linq;

namespace explorer.Model
{
    public interface IRepository<T>
        where T: DatabaseObject
    {
        IQueryable<T> Items { get; }
        void SaveItem(T item);
        T DeleteItem(int id);
    }
}