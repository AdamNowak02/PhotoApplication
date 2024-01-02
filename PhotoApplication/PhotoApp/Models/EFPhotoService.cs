using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Data;
using Data.Entities;




namespace PhotoApp.Models
{
    public class EFPhotoService : IPhotoService
    {
        private readonly AppDbContext _context;

        public EFPhotoService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Photo photo)
        {
            var entity = _context.Photos.Add(PhotoMapper.ToEntity(photo));
            int id = entity.Entity.PhotoId;


            _context.SaveChanges();
            return id;
        }

        public void Update(Photo photo)
        {
            PhotoEntity entity = PhotoMapper.ToEntity(photo);
            _context.Update(entity);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {

            PhotoEntity? find = _context.Photos.Find(id);
            if (find != null)
            {
                _context.Photos.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<Photo> FindAll()
        {
            return _context.Photos.Select(e => PhotoMapper.FromEntity(e)).ToList();
        }

        public Photo? FindById(int id)
        {
            PhotoEntity? find = _context.Photos.Find(id);
            return find == null ? null : PhotoMapper.FromEntity(find);
        }

        public List<AparatEntity> FindAllAparats()
        {
            return _context.Aparats.ToList();
        }
    }
}