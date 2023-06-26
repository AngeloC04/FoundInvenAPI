using ConInventario.Modelo;

namespace ConInventario.Repositorio
{
    public class InventarioM: IInventarioM
    {
        private readonly List<Inventario> inventario = new()
        {
            new Inventario {SKU = "101010", Bodega = "913", DispoNeto = 0, InvCompro = 10, UniPorUbica = 50},
            new Inventario {SKU = "202020", Bodega = "917", DispoNeto = 100, InvCompro = 1, UniPorUbica = 5}
        };

        public IEnumerable<Inventario> ConsultaSKU()
        {
            return inventario;
        }

        public Inventario ConsultaSKUx(string SKU)
        {
            return inventario.Where(i => i.SKU == SKU).SingleOrDefault();
        }

    }
}
