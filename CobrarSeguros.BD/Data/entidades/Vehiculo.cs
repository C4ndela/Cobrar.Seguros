using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobrarSeguros.BD.Data.entidades
{
    [Index(nameof(Patente), nameof (nroPoliza), Name= "Vehiculo_UQ", IsUnique= true)]
    public class Vehiculo : EntityBase
    {
        [Required]
        [MaxLength (8, ErrorMessage = "La patente del vehiculo no debe superar los {1} caracteres")]
        public int Patente { get; set; }
        [Required]
        [MaxLength(4, ErrorMessage = "El año del vehiculo no debe superar los {1} caracteres")]
        public int Año { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "La suma asegurada del vehiculo no debe superar los {1} caracteres")]
        public int Sumasegurada { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "El periodo de poliza no debe superar los {1} caracteres")]
        public string periodoPoliza { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "La vigencia de poliza no debe superar los {1} caracteres")]
        public int vigenciaPoliza { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "El nro de poliza no debe superar los {1} caracteres")]
        public int nroPoliza { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "El modelo de vehiculo no debe superar los {1} caracteres")]
        public string Modelo { get; set; }
        [Required]
        [MaxLength(4, ErrorMessage = "El tipo de seguro no debe superar los {1} caracteres")]
        public string tipoSeguro { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "La compañia de seguro no debe superar los {1} caracteres")]
        public string compañiaSeguro { get; set; }
    }
}
