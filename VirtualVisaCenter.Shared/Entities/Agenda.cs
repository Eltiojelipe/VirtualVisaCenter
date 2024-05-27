using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VirtualVisaCenter.Shared.Entities
{
    public class Agenda
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime Date { get; set; }


        [Display(Name = "Observación")]
        [StringLength(500, ErrorMessage = "Las observaciones no deben exceder los 250 caracteres.")]
        public string Remarks { get; set; }

        [Display(Name = "Disponible")]


        public bool IsAvailable { get; set; }

        [JsonIgnore]
        public Request Request { get; set; }    

    }
}
