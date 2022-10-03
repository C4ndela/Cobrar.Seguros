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


        #region post
        [HttpPost]
        public async Task<ActionResult<Vehiculo>> Post(Vehiculo vehiculo)
        {
            try
            {
                //var clienteActivoId = User.Claims.Where(c => c.Type == "clienteActivoId").Select(x => x.Value).FirstOrDefault();

                //if (clienteActivoId == null)
                //    return NotFound("No se puede agregar el vehiculo");

                ///*usa la cuenta activa para la carga del vehiculo bajo esa cuenta*/
                //vehiculo.ClientesId = clienteActivoId;


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

        #region Get

        [HttpGet("/Patente")]
        public async Task<ActionResult<Vehiculo>> VehiculoPorPatente(string Patente)
        {
            var Vehiculo = await context.Vehiculos.Where
                                   (p => p.Patente == Patente).FirstOrDefaultAsync();
                                   //.Include(po => po.Vehiculo).FirstOrDefaultAsync()
            if (Vehiculo == null)
            {
                return NotFound($"No existe un vehiculo con patente= {Patente}");
            }
            return Vehiculo;
        }

        [HttpGet("/ClienteId")]
        public async Task<ActionResult<Vehiculo>> VehiculoPorClienteId(int ClienteId)
        {
            var Vehiculo = await context.Vehiculos.Where
                                   (c => c.ClientesId == ClienteId).FirstOrDefaultAsync();

            if (Vehiculo == null)
            {
                return NotFound($"No existe un vehiculo con cliente numero id= {ClienteId}");
            }
            return Vehiculo;
        }
        #endregion

        #region put

        [HttpPut("Patente:string")]

        public ActionResult Put(string Patente, [FromBody] Vehiculo vehiculo)
        {
            if (Patente != vehiculo.Patente)
            {
                return BadRequest("Datos incorrectos");
            }

            var autos = context.Vehiculos.Where(p => p.Patente == Patente).FirstOrDefault();

            if (autos == null)
            {
                return BadRequest("No existe vehiculo a modificar");
            }

            autos.Sumasegurada = vehiculo.Sumasegurada;

            try
            {
                context.Vehiculos.Update(autos);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no han sido actualizados por:{e.Message}");
            }
        }

        #endregion

        #region delete
        [HttpDelete("{patente:string}")]

        public ActionResult Delete(string Patente)
        {
            var auto = context.Vehiculos.Where(x => x.Patente == Patente).FirstOrDefault();
            if (auto == null)
            {
                return NotFound($"El registro {Patente} no fue encontrado");
            }

            try
            {
                context.Vehiculos.Remove(auto);
                context.SaveChanges();
                return Ok($"El registro {auto.Patente} ha sido borrado.");
            }
            catch
            {
                return BadRequest($"Los datos no han sido eliminados"); //AGREGAR (e.Message)
            }
        }
        #endregion

    }

}