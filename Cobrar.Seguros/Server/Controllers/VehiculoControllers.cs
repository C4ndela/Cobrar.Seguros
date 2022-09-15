using CobrarSeguros.BD.Data;
using CobrarSeguros.BD.Data.entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cobrar.Seguros.Server.Controllers
{
    [ApiController]
    [Route("api/Vehiculo")]
    [Authorize]

    public class VehiculoControllers : ControllerBase
    {
        private readonly BDcontext context;

        public VehiculoControllers(BDcontext context)
        {
            this.context = context;
        }


        #region Get

        [HttpGet]
        public async Task<ActionResult<List<Vehiculo>>> Get()
        {
            return await context.Vehiculos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Vehiculo>> Get(int id)
        {
            var Vehiculo = await context.Vehiculos.Where
                                   (p => p.ID == id).FirstOrDefaultAsync();
            if (Vehiculo == null)
            {
                return NotFound($"No existe vehiculo de Id= {id}");
            }
            return Vehiculo; 
        }

        [HttpGet("{VehiculoPorPatente/{Patente}")]
        public async Task<ActionResult<Vehiculo>> VehiculoPorPatente(string Patente)
        {
            var Vehiculo = await context.Vehiculos.Where
                                   (p => p.Patente == Patente)
                                   .Include (po => po.Poliza).FirstOrDefaultAsync();

            if (Vehiculo == null)
            {
                return NotFound($"No existe un vehiculo con patente= {Patente}");
            }
            return Vehiculo;
        }

        #endregion

        #region post
        [HttpPost]
        public async Task<ActionResult<Vehiculo>> Post(Vehiculo vehiculo)
        {
            try
            {
                context.Vehiculos.Add(vehiculo);
                await context.SaveChangesAsync();
                return vehiculo;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region put

        //[HttpPut("pantete:string")]

        //public ActionResult Put(string Patente, [FromBody] Vehiculo vehiculo)
        //{
        //    if (Patente != vehiculo.Patente)
        //    {
        //        return BadRequest("Datos incorrectos");
        //    }

        //    var auto = context.Vehiculos.Where(e => e.Patente == Patente);

        //    if (auto == null)
        //    {
        //        return NotFound("No existe vehiculo a modificar");
        //    }

        //    auto.Sumasegurada = Vehiculo.Sumasegurada;

        //    try
        //    {
        //        context.Vehiculos.Update(auto);
        //        context.SaveChanges();
        //        return Ok();
        //    }
        //    catch
        //    {
        //        return BadRequest($"Lso datos no han sido actualizados por:{e.Message}");
        //    }

        //}

        #endregion

        #region delete
        [HttpDelete ("{id:int}")]

        public ActionResult Delete (int id)
        {
            var auto = context.Vehiculos.Where(x => x.ID == id).FirstOrDefault();
            if (auto == null)
            {
                return NotFound($"El registro {id} no fue encontrado"); 
            }

            try
            {
                context.Vehiculos.Remove(auto); 
                context.SaveChanges();
                return Ok($"El registro {auto.Sumasegurada} ha sido borrado."); 
            }
            catch 
            {
                return BadRequest($"Lso datos no han sido eliminados"); //AGREGAR (e.Message)
            }
        }

        #endregion

    }
}
