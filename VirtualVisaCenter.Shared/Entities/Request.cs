using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VirtualVisaCenter.Shared.Entities
{


    public class Request
    {
        public int Id { get; set; }

        // Solicitante

        // Fecha y hora de la solicitud
        [Display(Name = "Fecha de la solicitud")]
        [Required(ErrorMessage = "La fecha y hora de la solicitud son obligatorias.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RequestDateTime { get; set; }

        [Display(Name = "Tipo de solicitud")]
        [Required(ErrorMessage = "El tipo de solicitud es obligatorio.")]
        [StringLength(50, ErrorMessage = "El tipo de solicitud no debe exceder los 50 caracteres.")]
        public string RequestType { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(500, ErrorMessage = "La descripción no debe exceder los 100 caracteres.")]
        public string Description { get; set; }

        // Estado
        [Required(ErrorMessage = "El estado es obligatorio.")]
        [StringLength(20, ErrorMessage = "El estado no debe exceder los 20 caracteres.")]
        public string Status { get; set; }

        // Respuestas o comentarios
        [StringLength(1000, ErrorMessage = "Los comentarios no deben exceder los 1000 caracteres.")]
        public string Comments { get; set; }

        // Archivos adjuntos (esto es solo un ejemplo, puede requerir una implementación personalizada)
        public List<string> Attachments { get; set; }
        [JsonIgnore]

        public Embassy Embassy { get; set; }
        [JsonIgnore]

        public Customer Customer { get; set; }
        [JsonIgnore]

        public TypeVIsa TypeVIsa { get; set; }

        [JsonIgnore]

        public ICollection<Agenda> Agenda { get; set; } 
    }


}
