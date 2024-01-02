using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("Photos")]
    public class PhotoEntity
    {
        [Key]
        public int PhotoId { get; set; }

        public string Opis { get; set; }


        public string Autor { get; set; }

        public DateTime DataPublikacji { get; set; }

        public string Rozdzielczosc { get; set; }

        public string Format { get; set; }

        public int? AparatId { get; set; }

       public AparatEntity Aparat { get; set; }
    }
}
