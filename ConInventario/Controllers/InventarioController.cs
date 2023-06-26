using ConInventario.DTO;
using ConInventario.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ConInventario.Controllers
{
    [Route("inventario")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly IInventarioM repositorio;

        public InventarioController(IInventarioM r)
        {
            this.repositorio = r;
        }

        [HttpGet]
        public IEnumerable<InventarioDTO> buscaItem()
        {
            var listaSKU = repositorio.ConsultaSKU().Select(x => x.convertirDTO());
            return listaSKU;
        }

        [HttpGet("{SKU}")]
        public ActionResult<InventarioDTO> BuscarSKU(string SKU)
        {
            var item = repositorio.ConsultaSKUx(SKU).convertirDTO();

            if (item is null)
            {
                return NotFound();
            }

            return item;
        }

    }
}
