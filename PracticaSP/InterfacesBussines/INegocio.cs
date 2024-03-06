using DAC.Models;

namespace PracticaSP.InterfacesBussines
{
    public interface INegocio
    {
        Task<Prueba> GuardarDatos(Prueba datos);
    }
}
