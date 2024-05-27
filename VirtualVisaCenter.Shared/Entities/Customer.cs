using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VirtualVisaCenter.Shared.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name = "Documento de identidad")]
        [MaxLength(20, ErrorMessage = "No se permiten más de 20 dígitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Document { get; set; }


        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 Caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string FirstName { get; set; }


        [Display(Name = "Apellido")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 Caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El campo de fecha de nacimiento es obligatorio.")]
        [DataType(DataType.Date, ErrorMessage = "La fecha de nacimiento debe ser una fecha válida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Email")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 Caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Email { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "El campo del teléfono móvil es obligatorio.")]
        [Phone(ErrorMessage = "El formato del número de teléfono no es válido.")]
        public string CellPhone { get; set; }

        [Display(Name = "Direccion de residencia")]
        [Required(ErrorMessage = "El campo de dirección es obligatorio.")]
        [StringLength(100, ErrorMessage = "La dirección no debe exceder los 60 caracteres.")]
        public string Address { get; set; }

        public string FullName => $"{FirstName}{LastName}";

        [JsonIgnore]

        public ICollection<Request> Request { get; set; }
        [JsonIgnore]

        public ICollection<CriminalRecord> CriminalRecord { get; set;}

    }
}
