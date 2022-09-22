using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobrarSeguros.BD.Data.entidades
{
    [Index( nameof(VehiculosID), Name = "Poliza.VehiculoID_UQ", IsUnique = true)]
    public class Poliza : EntityBase
    {
        [Required]
        [MaxLength(20, ErrorMessage = "El numero de poliza es obligatorio")]
        public string nroPoliza { get; set; }

        [Required]
        [MaxLength(4, ErrorMessage = "El tipo de seguro no debe superar los {1} caracteres")]
        public string tipoSeguro { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "La vigencia de poliza no debe superar los {1} caracteres")]
        public string vigenciaPoliza { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "El periodo de poliza no debe superar los {1} caracteres")]
        public string periodoPoliza { get; set; }


        public Vehiculo Vehiculos { get; set; }
        public int VehiculosID { get; set; } 
    }
}
