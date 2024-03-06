using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using DAC.Interfaces;
using DAC.Models;
using DAC.Configuration;
using System.Reflection.Metadata.Ecma335;

namespace DAC.PruebaDac
{
    public class EmpleadoRepositorio:IEmpleadoRepo
    {
        private readonly CladenaConexion _conexion;
        public EmpleadoRepositorio(IOptions<CladenaConexion> conexion)
        {

            _conexion = conexion.Value;
        }


        public async Task<Consulta> GuardarDatostodo( Consulta data)
        {
            
            using (SqlConnection conec = new SqlConnection(_conexion.CadenaConexio))
            {

                using (SqlCommand comando = new SqlCommand("Sp_Consulta", conec))
                {

                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Informacion", data.Informacion);
                    comando.Parameters.AddWithValue("@Constantes", data.Constantes);
                  

                    try
                    {

                        conec.Open();
                        comando.ExecuteNonQuery();
                        return data;

                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }

                }
            }


        }
        public async Task<Prueba> GuardarDatos(Prueba data)
        {
            string operationType = "Insert";
            using (SqlConnection conec = new SqlConnection(_conexion.CadenaConexio))
            {

                using (SqlCommand comando = new SqlCommand("Sp_Persona",conec))
                {

                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Correo", data.correo);
                    comando.Parameters.AddWithValue("@Nombre", data.nombre);
                    comando.Parameters.AddWithValue("@OperationType", operationType);

                    try
                    {

                        conec.Open();
                        comando.ExecuteNonQuery();
                        return data;

                    }
                    catch (Exception ex)
                    {

                        throw ex ;
                    }

                }
            }

         
        }


        public async Task<dynamic> ObtenerId(int id)
        {
            string operationType= "Select";
            using (SqlConnection conec = new SqlConnection(_conexion.CadenaConexio))
            {
                using (SqlCommand comando = new SqlCommand("Sp_Persona", conec))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idNumber", id);
                    comando.Parameters.AddWithValue("@correo", DBNull.Value);
                    comando.Parameters.AddWithValue("@nombre", DBNull.Value);
                    comando.Parameters.AddWithValue("@OperationType", operationType);

                    try
                    {
                        conec.Open();
                        using (var reader = await comando.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new Prueba
                                {
                                   
                                    correo = reader.GetString("correo"),
                                    nombre = reader.GetString("nombre")
                                    

                                };
                            }
                        }
                        return null; // Si no se encontraron resultados
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
        }


        public async Task<List<Prueba>> ObtenerTodo() {

            List<Prueba> resultados = new List<Prueba>();
            string operationType = "SelectTodo";
            using (SqlConnection conec = new SqlConnection(_conexion.CadenaConexio)) {

                using (SqlCommand comando = new SqlCommand("Sp_Persona", conec)) {

                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idNumber", DBNull.Value);
                    comando.Parameters.AddWithValue("@correo", DBNull.Value);
                    comando.Parameters.AddWithValue("@nombre", DBNull.Value);
                    comando.Parameters.AddWithValue("@OperationType", operationType);

                    try{

                        conec.Open();

                        using (SqlDataReader reader = comando.ExecuteReader()) {


                            while (await reader.ReadAsync())
                            {
                                Prueba prueba = new Prueba
                                {
                                    correo = reader["correo"].ToString(),
                                    nombre = reader["nombre"].ToString(),
                                  
                                    // Agregar otros campos según la estructura de tu tabla
                                };

                                resultados.Add(prueba);
                            }

                            return resultados;

                        }

                    }
                    catch (Exception ex)
                    {

                       throw;
                    }

                }
            
            }
        
        }

       }

        
       
}
