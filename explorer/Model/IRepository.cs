using System.Linq;

namespace explorer.Model
{
    public interface IRepository<T>
    {
        IQueryable<T> Items { get; }
        void SaveItem(T post);
        T DeleteItem(int id);
    }
}