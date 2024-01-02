using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PhotoApp.Models
{
    public class Photo
    {
        [HiddenInput]
        public int Id { get; set; }
   
        public string Opis { get; set; }


        public string Autor { get; set; }

        public DateTime DataPublickacji { get; set; }

        public string Rozdzielczosc { get; set; }
 
        public string Format { get; set; }

        public int? AparatId { get; set; }

        [ValidateNever]
        public List<SelectListItem> Aparats { get; set; }


    }
}