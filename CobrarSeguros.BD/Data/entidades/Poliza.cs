using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobrarSeguros.BD.Data.entidades
{
    [Index( nameof (VehiculoId), nameof (nroPoliza), Name = "Poliza.VehiculoID_UQ", IsUnique = true)]
    public class Poliza : EntityBase 
    {

        [Required]
        [MaxLength(40, ErrorMessage = "El nombre de la empresa no debe superar los {1} caracteres")]
        public string empresaAseguradora { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "El numero de poliza es obligatorio")]
        public string nroPoliza { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "El tipo de seguro no debe superar los {1} caracteres")]
        public string tipoSeguro { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "La vigencia de poliza no debe superar los {1} caracteres")]
        public string vigenciaPoliza { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "El periodo de poliza no debe superar los {1} caracteres")]
        public string periodoPoliza { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "El vencimiento de poliza no debe superar los {1} caracteres")]
        public string vencimientoFactura { get; set; }

        [Required]
        public string linkAsegurador { get; set; }

        [Required]
        public bool Estado { get; set; }

        //[ForeignKey("Vehiculo")]


        public Vehiculo Vehiculo { get; set; }
        public int VehiculoId { get; set; } 
    }
}
