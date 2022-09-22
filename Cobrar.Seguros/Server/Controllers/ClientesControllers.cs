﻿using CobrarSeguros.BD.Data;
using CobrarSeguros.BD.Data.entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Cobrar.Seguros.Server.Controllers
{
    public class ClientesControllers
    {
        [ApiController]
        [Route("api/Clientes")]
        [Authorize]

        public class ClienteControllers : ControllerBase
        {
            private readonly BDcontext context;

            public ClienteControllers(BDcontext context)
            {
                this.context = context;
            }

            #region post
            [HttpPost]
            public async Task<ActionResult<Clientes>> Post(Clientes cliente)
            {
                try
                {
                    context.Cliente.Add(cliente);
                    await context.SaveChangesAsync();
                    return cliente;
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
                                       (d => d.DNI == DNI)
                                       .Include(po => po.Vehiculos).FirstOrDefaultAsync();
                if (Vehiculo == null)
                {
                    return NotFound($"No existe un vehiculo con patente= {DNI}");
                }
                return Vehiculo;
            }
            #endregion

            #region delete
            [HttpDelete("{id:int}")]

            public ActionResult Delete(int id)
            {
                var persona = context.Cliente.Where(x => x.ID == id).FirstOrDefault();
                if (persona == null)
                {
                    return NotFound($"El registro {id} no fue encontrado");
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
        }
    }
} 