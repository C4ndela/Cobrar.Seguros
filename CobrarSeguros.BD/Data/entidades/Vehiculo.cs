using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobrarSeguros.BD.Data.entidades

{ 
     [Index(nameof (PolizaID), nameof (Patente), Name = "Vehiculo.PolizaID_UQ", IsUnique = true)]

       public class Vehiculo : EntityBase
       {
         [Required]
         [MaxLength(8, ErrorMessage = "La patente del vehiculo no debe superar los {1} caracteres")]
          public string Patente { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "El modelo de vehiculo no debe superar los {1} caracteres")]
        public string Modelo { get; set; }
        [Required]
         public int Año { get; set; }
         [Required]
        public int Sumasegurada { get; set; }
        
        
        
        [Required(ErrorMessage = "Cliente es obligatorio")]
        public int ClienteID { get; set; }
        public Clientes Clientes {get; set; } 

        public int PolizaID { get; set; }
        public Poliza Poliza { get; set; }
       }
}
