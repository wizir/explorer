using System;
using System.Collections.Generic;
using System.Linq;

namespace explorer.Model
{
    public class FakePageRepository : IRepository<Page>
    {
        private List<Page> _items = new List<Page>
        {
            new Page
            {
                Id = 1, Created = new DateTimeOffset(new DateTime(2019, 10, 20, 12, 30, 45)), 
                Date = new DateTime(2019, 10, 20),
                Title = "moj paskudny dzień",
                Body = "dzisiaj było paskudnie"
            },
            new Page
            {
                Id = 2, Created = new DateTimeOffset(new DateTime(2019, 10, 22, 15, 21, 14)), 
                Date = new DateTime(2019, 10, 22),
                Title = "moj cudowny dzień",
                Body = "dzisiaj było coduwnie, że ja cie piernicze"
            },
            new Page
            {
                Id = 3, Created = new DateTimeOffset(new DateTime(2019, 10, 27, 12, 30, 45)), LastModified = new DateTimeOffset(new DateTime(2019, 10, 27, 14, 0,0)),
                Date = new DateTime(2019, 10, 27),
                Title = "wspaniała wycieczka do landrynkowej krainy",
                Body = "dzisiaj pojechalismy sobie do landrynkowej krainy, było cudownie"
            }
        };
            
        public IQueryable<Page> Items => _items.AsQueryable();
        public void SaveItem(Page item)
        {
            if (item.Id == default)
            {
                item.Created = DateTimeOffset.Now;
                item.Id = _items.Max(entry => entry.Id) + 1;
                _items.Add(item);
            }
            else
            {
                item.LastModified = DateTimeOffset.Now;
                _items.RemoveAll(entity => entity.Id == item.Id);
                _items.Add(item);
            }
        }

        public Page DeleteItem(int id)
        {
            var item = _items.FirstOrDefault(entity => entity.Id == id);
            _items.Remove(item);
            return item;
        }
    }
}