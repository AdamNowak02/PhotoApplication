using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Data.Entities
{
    [Table("Aparat")]
    public class AparatEntity
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public ISet<PhotoEntity> Photos { get; set; }
    }
}

