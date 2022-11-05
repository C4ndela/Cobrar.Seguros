using CobrarSeguros.BD.Data;
using CobrarSeguros.BD.Data.entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cobrar.Seguros.Server.Controllers
{
    [ApiController]
    [Route("api/Poliza")]
    [Authorize]

 
        public class PolizaControllrs : ControllerBase
        {
            private readonly BDcontext context;

            public PolizaControllrs(BDcontext context)
            {
                this.context = context;
            }

            #region post
            [HttpPost]
            public async Task<ActionResult<Poliza>> Post(Poliza poliza)
            {
                try
                {
                    context.Polizas.Add(poliza);
                    await context.SaveChangesAsync();
                    return poliza;
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            #endregion

            #region Get

            [HttpGet("/NroPoliza")]
            public async Task<ActionResult<Poliza>> PolizaporNumero(string nroPoliza)
            {

                var Vehiculo = await context.Polizas.Where
                                       (d => d.nroPoliza == nroPoliza).FirstOrDefaultAsync();
                                       //.Include(po => po.Vehiculos).FirstOrDefaultAsync();
                if (Vehiculo == null)
                {
                    return NotFound($"No existe un seguro con nro de poliza= {nroPoliza}");
                }
                return Vehiculo;
            }

        //[HttpGet("/VehiculoId")]
        //public async Task<ActionResult<Poliza>> PolizaporVehiculo(int VehiculoId)
        //{
        //    var Poliza = await context.Polizas.Where
        //                           (c => c.VehiculoId == VehiculoId).FirstOrDefaultAsync();

        //    if (Poliza == null)

        //        return NotFound($"No existe un vehiculo con cliente numero id= {VehiculoId}");
        //}
        //    return Poliza;
        //}


        #endregion

        #region put

        [HttpPut("nroPoliza")]

        public ActionResult Put(string nroPoliza, [FromBody] Poliza Polizas)
        {
            if (nroPoliza != Polizas.nroPoliza)
            {
                return BadRequest("Datos incorrectos");
            }

            var numeroPoli = context.Polizas.Where(n => n.nroPoliza == nroPoliza).FirstOrDefault();

            if (numeroPoli == null)
            {
                return BadRequest("No existe vehiculo a modificar");
            }

            numeroPoli.nroPoliza = Polizas.nroPoliza;
            numeroPoli.vigenciaPoliza = Polizas.vigenciaPoliza;
            numeroPoli.tipoSeguro = Polizas.tipoSeguro; 

            try
            {
                context.Polizas.Update(numeroPoli);
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
        [HttpDelete("{nroPoliza}")]

            public ActionResult Delete(string nroPoliza)
            {
                var seguro = context.Polizas.Where(x => x.nroPoliza == nroPoliza).FirstOrDefault();
                if (seguro == null)
                {
                    return NotFound($"El registro {nroPoliza} no fue encontrado");
                }

                try
                {
                    context.Polizas.Remove(seguro);
                    context.SaveChanges();
                    return Ok($"El registro {seguro.nroPoliza} ha sido borrado.");
                }
                catch
                {
                    return BadRequest($"Los datos no han sido eliminados"); //AGREGAR (e.Message)
                }
            }

            #endregion
        }
    }
