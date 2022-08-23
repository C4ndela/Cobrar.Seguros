using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobrarSeguros.BD.Data.entidades
{
    [Index(nameof(DNI), Name = "ClienteDNI_UQ", IsUnique = true)]
    public class Clientes : EntityBase
    {
        [Required]
        public int DNI { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "El Nombre de la persona no debe superar los {1} caracteres")]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "El Apellido de la persona no debe superar los {1} caracteres")]
        public string Apellido { get; set; }
        [Required]
        [MaxLength(80, ErrorMessage = "La localidad de la persona no debe superar los {1} caracteres")]
        public string Localidad { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "El domicilio de la persona no debe superar los {1} caracteres")]
        public string Domicilio { get; set; }
        [Required]
        public int nroTelfonico { get; set; }

        public List<Poliza> Poliza { get; set; }

    }
}