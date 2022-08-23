using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobrarSeguros.BD.Data.entidades

{ 
     [Index(nameof(Patente), Name = "Vehiculo_UQ", IsUnique = true)]
       public class Vehiculo : EntityBase
       {
         [Required]
         [MaxLength(8, ErrorMessage = "La patente del vehiculo no debe superar los {1} caracteres")]
          public string Patente { get; set; }
         [Required]
          public int Año { get; set; }
         [Required]
          public int Sumasegurada { get; set; }
         [Required]
          [MaxLength(50, ErrorMessage = "El modelo de vehiculo no debe superar los {1} caracteres")]
           public string Modelo { get; set; }

            [Required(ErrorMessage = "Cliente es obligatorio")]
           public int ClienteId { get; set; }
           public Clientes Cliente { get; set; }
           public List<Poliza> Poliza { get; set; }
       }
}
