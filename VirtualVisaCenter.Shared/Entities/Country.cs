using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VirtualVisaCenter.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 Caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; } 

        [Display(Name = "Capital")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 Caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Capital { get; set; }

        [JsonIgnore]

        public ICollection<Embassy> Embassy { get; set;}

        [JsonIgnore]
        
        public ICollection<Rate> Rate { get; set;}
    }
}
