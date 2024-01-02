using Data.Entities;

namespace PhotoApp.Models
{
    public class MemoryPhotoService : IPhotoService
    {
        private Dictionary<int, Photo> _items = new Dictionary<int, Photo>();


        public int Add(Photo item)
        {
            int id = _items.Keys.Count != 0 ? _items.Keys.Max() : 0;
            item.Id = id + 1;
            _items.Add(item.Id, item);
            return item.Id;
        }

        public void Delete(int id)
        {
            _items.Remove(id);
        }

        public List<Photo> FindAll()
        {
            return _items.Values.ToList();
        }

        public Photo? FindById(int id)
        {
            return _items[id];
        }

        public void Update(Photo item)
        {
            _items[item.Id] = item;
        }

        public List<AparatEntity> FindAllAparats()
        {
            throw new NotImplementedException();
        }

    }
}

