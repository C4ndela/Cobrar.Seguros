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
        private readonly BDcontext contex;

        public CobrarControllers (BDcontext contex )
        {
            this.contex = contex;
        }

        [HttpGet]
        public async Task<ActionResult<List<Poliza>>> Get()
        {
            return await contex.Polizas.ToListAsync(); 
        }

    }
}
