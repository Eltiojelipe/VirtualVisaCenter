using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVisaCenter.Shared.Entities
{
    public class Embassy
    {
        public int Id { get; set; }

        // Nombre de la embajada
        [Required(ErrorMessage = "El nombre de la embajada es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre de la embajada no debe exceder los 100 caracteres.")]
        public string Name { get; set; }

        // País de la embajada
        [Required(ErrorMessage = "El país de la embajada es obligatorio.")]
        [StringLength(100, ErrorMessage = "El país no debe exceder los 100 caracteres.")]
        public string Country { get; set; }

        [Display(Name = "Direccion de la embajada")]
        [Required(ErrorMessage = "El campo de dirección es obligatorio.")]
        [StringLength(100, ErrorMessage = "La dirección no debe exceder los 60 caracteres.")]
        public string Address { get; set; }

        // Teléfono de la embajada
        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El número de teléfono no es válido.")]
        public string Phone { get; set; }

        // Correo electrónico de la embajada
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Email { get; set; }

        // Horario de atención de la embajada
        [StringLength(100, ErrorMessage = "El horario de atención no debe exceder los 100 caracteres.")]
        public string OfficeHours { get; set; }

        // Página web de la embajada
        [Url(ErrorMessage = "La URL de la página web no es válida.")]
        public string Website { get; set; }

        // Nombre del embajador
        [StringLength(100, ErrorMessage = "El nombre del embajador no debe exceder los 100 caracteres.")]
        public string Ambassador { get; set; }

        public Country country { get; set; }

        public ICollection<Request> Requests { get; set; }

    }
}
