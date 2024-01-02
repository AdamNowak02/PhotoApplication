using Data.Entities;

namespace PhotoApp.Models
{
    public interface IPhotoService
    {
        int Add(Photo photo);
        void Delete(int id);
        void Update(Photo photo);
        List<Photo> FindAll();
        Photo? FindById(int id);
        List<AparatEntity> FindAllAparats();
    }
}
