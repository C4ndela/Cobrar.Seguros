using CobrarSeguros.BD.Data;
using CobrarSeguros.BD.Data.entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cobrar.Seguros.Server.Controllers
{
    [ApiController]
    [Route("api/Cobrar")]
    [Authorize]

    public class CobrarControllers : ControllerBase
    {
        private readonly BDcontext context;

        public CobrarControllers(BDcontext context)
        {
            this.context = context;
        }


        #region Get

        [HttpGet]
        public async Task<ActionResult<List<Poliza>>> Get()
        {
            return await context.Polizas.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Poliza>> Get(int id)
        {
            var poliza= await context.Polizas.Where
                                   (p => p.ID == id).FirstOrDefaultAsync();
            if (poliza == null)
            {
                return NotFound($"No existe una poliza de Id= {id}");
            }
            return poliza; 
        }

        #endregion
    }
}
