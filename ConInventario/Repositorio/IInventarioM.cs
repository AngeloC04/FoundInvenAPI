using ConInventario.Modelo;

namespace ConInventario.Repositorio
{
    public interface IInventarioM
    {
        Inventario ConsultaSKUx(string SKU);

        IEnumerable<Inventario> ConsultaSKU();
    }
}
