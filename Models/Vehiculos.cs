using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_Vehículos.Models
{
    public class Vehiculos
    {
        [Key]
        public int VehiculoId { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacío")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacío")]
        public string Modelo { get; set; }

        public int Year { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacío")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacío")]
        public float PrecioCompra { get; set; }

        [Required(ErrorMessage = "Este campo no pude estar vacío")]
        public float PrecioVenta { get; set; }
    }
}
