using Data.Entities;

namespace PhotoApp.Models
{
    public class PhotoMapper
    {
        public static PhotoEntity ToEntity(Photo model)
        {
            return new PhotoEntity()
            {
                Opis = model.Opis,
                Autor = model.Autor,
                DataPublikacji = model.DataPublickacji,
                Rozdzielczosc = model.Rozdzielczosc,
                Format = model.Format,
                PhotoId = model.Id,
                AparatId = (int)model.AparatId
            };
        }

        public static Photo FromEntity(PhotoEntity entity)
        {
            return new Photo()
            {
                Opis = entity.Opis,
                Autor = entity.Autor,
                DataPublickacji = (DateTime)entity.DataPublikacji,
                Rozdzielczosc = entity.Rozdzielczosc,
                Format = entity.Format,
                Id = entity.PhotoId,
                AparatId = entity.AparatId

            };
        }
    }
}