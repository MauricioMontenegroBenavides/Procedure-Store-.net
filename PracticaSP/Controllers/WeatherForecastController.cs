using DAC.Interfaces;
using DAC.Models;
using Microsoft.AspNetCore.Mvc;

using PracticaSP.InterfacesBussines;

namespace PracticaSP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IEmpleadoRepo _empleado;
       
        public WeatherForecastController(
            ILogger<WeatherForecastController> logger, 
            IEmpleadoRepo empleado
           )
        {
            _logger = logger;
            _empleado = empleado;
          
        }

       

        [HttpPost("Guardar")]
        public Task<Prueba> Guardar([FromBody] Prueba data)
        {


            Task<Prueba> da =_empleado.GuardarDatos(data);

            return da;
        }

        [HttpPost("Consulta")]
        public Task<Consulta> Consulta([FromBody] Consulta data)
        {

            data.Constantes = "data2";
            Task<Consulta> da = _empleado.GuardarDatostodo(data);

            return da;
        }

        [HttpGet("Obtener/{id}")]
        public Task<dynamic> ObtenerId(int id)
        {

            Task<dynamic> da = _empleado.ObtenerId(id);

            return da;


        }

        [HttpGet("ObtenerTODO")]
        public async  Task<List<Prueba>> ObtenerTodo()
        {


            List<Prueba> da = await _empleado.ObtenerTodo();

            return da;
        }


        //[HttpPut("Editar/{id}")]
        //public Task<Prueba> Editar([FromBody] Prueba data)
        //{

        //}


        //[HttpDelete("Borrar/{id}")]
        //public Task<Prueba> Borrar([FromBody] Prueba data)
        //{

        //}


    }
}