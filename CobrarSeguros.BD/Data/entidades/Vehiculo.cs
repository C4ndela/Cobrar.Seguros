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
     [Index( nameof(Patente), Name = "VehiculoID_UQ", IsUnique = true)]

       public class Vehiculo : EntityBase 
    {
         [Required]
         [MaxLength(10, ErrorMessage = "La patente del vehiculo no debe superar los {1} caracteres")]
         public string Patente { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "El modelo de vehiculo no debe superar los {1} caracteres")]
        public string Modelo { get; set; }
        [Required]
         public int Año { get; set; }
        [Required]
        public int Sumasegurada { get; set; }

        //[ForeignKey("Poliza")]

        public Clientes Clientes {get; set; }
        public int ClientesId { get; set; }

       

    }
}
