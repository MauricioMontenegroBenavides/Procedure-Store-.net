using DAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC.Interfaces
{
    public interface IEmpleadoRepo
    {
        Task<Prueba> GuardarDatos(Prueba data);
        Task<dynamic> ObtenerId(int id);

        Task<List<Prueba>> ObtenerTodo();
        Task<Consulta> GuardarDatostodo(Consulta data);
    }
}
