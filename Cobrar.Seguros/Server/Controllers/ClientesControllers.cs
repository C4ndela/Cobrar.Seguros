using CobrarSeguros.BD.Data;
using CobrarSeguros.BD.Data.entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cobrar.Seguros.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Clientes")]
    public class ClienteControllers : ControllerBase
    {
        private readonly BDcontext context;
        public ClienteControllers(BDcontext context)
        {
            this.context = context;
        }

        #region post
        [HttpPost]
            public async Task<ActionResult<int>> Post(Clientes cliente)
            {
                try
                {
                    context.Cliente.Add(cliente);
                    await context.SaveChangesAsync();
                    return cliente.Id;
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            #endregion

           #region Get

            [HttpGet("/DNI")]
            public async Task<ActionResult<Clientes>> ClienteporDNI(int DNI)
            {
                var Vehiculo = await context.Cliente.Where
                                       (d => d.DNI == DNI).FirstOrDefaultAsync();
                if (Vehiculo == null)
                {
                    return NotFound($"No existe un clinte con DNI= {DNI}");
                }
                return Vehiculo;
            }

        #endregion

         #region put

        [HttpPut("DNI:int")]

        public ActionResult Put(int Id, [FromBody] Clientes Cliente)
        {
            if (Id != Cliente.DNI)
            {
                return BadRequest("Datos incorrectos");
            }

            var persona = context.Cliente.Where(n => n.Id == Id).FirstOrDefault();

            if (Id == null)
            {
                return BadRequest("No existe vehiculo a modificar");
            }


            persona.nroTelfonico = Cliente.nroTelfonico;
            persona.Localidad = Cliente.Localidad;
            persona.Domicilio = Cliente.Domicilio;
          

            try
            {
                context.Cliente.Update(persona);
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
        [HttpDelete("{DNI:int}")]

            public ActionResult Delete(int DNI)
            {
                var persona = context.Cliente.Where(x => x.DNI == DNI).FirstOrDefault();
                if (persona == null)
                {
                    return NotFound($"El registro {DNI} no fue encontrado");
                }

                try
                {
                    context.Cliente.Remove(persona);
                    context.SaveChanges();
                    return Ok($"El registro {persona.DNI} ha sido borrado.");
                }
                catch
                {
                    return BadRequest($"Los datos no han sido eliminados"); //AGREGAR (e.Message)
                }
            }

            #endregion

           #region metodos

            //private bool UserExist(int DNI) //confirma si el usuario con DNI x existe
            //{
            //    var user = context.Cliente.Where(u => u.DNI == DNI).FirstOrDefault();
            //    if (user != null)
            //        return false;
            //    return true;
            //}

            #endregion
        }
    }  