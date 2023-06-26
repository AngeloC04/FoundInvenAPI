using ConInventario.DTO;
using ConInventario.Modelo;

namespace ConInventario
{
    public static class Utilidades
    {
        public static InventarioDTO convertirDTO(this Inventario p)
        {
            if (p != null)
            {
                return new InventarioDTO
                {
                    SKU = p.SKU,
                    Bodega = p.Bodega,
                    DispoNeto = p.DispoNeto,
                    InvCompro = p.InvCompro,
                    UniPorUbica = p.UniPorUbica,

                };
            }

            return null;
        }
    }
}
