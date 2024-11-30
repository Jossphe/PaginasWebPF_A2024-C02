using System.Data;
using Microsoft.Data.SqlClient;
using ReciclajeApp.Models;

namespace ReciclajeApp.Repositories
{
    public interface IBuenaPracticaRepository
    {
        List<BuenaPractica> ObtenerBuenasPracticasPorTipoDesecho(string clasificacionDesecho = null);
    }

    public class BuenaPracticaRepository : IBuenaPracticaRepository
    {
        private readonly string _connectionString;

        public BuenaPracticaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<BuenaPractica> ObtenerBuenasPracticasPorTipoDesecho(string clasificacionDesecho = null)
        {
            var buenasPracticas = new List<BuenaPractica>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_ObtenerBuenasPracticasPorTipoDesecho", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar el parámetro opcional para filtrar por clasificación de desecho
                    if (!string.IsNullOrEmpty(clasificacionDesecho))
                    {
                        command.Parameters.Add(new SqlParameter("@ClasificacionDesecho", SqlDbType.NVarChar) { Value = clasificacionDesecho });
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("@ClasificacionDesecho", SqlDbType.NVarChar) { Value = DBNull.Value });
                    }

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            buenasPracticas.Add(new BuenaPractica
                            {
                                PracticaID = Convert.ToInt32(reader["PracticaID"]),
                                Titulo = reader["Titulo"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                ClasificacionDesecho = reader["ClasificacionDesecho"].ToString(),  // Manteniendo "ClasificacionDesecho"
                                FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),
                                FechaActualizacion = reader["FechaActualizacion"] == DBNull.Value
                                                     ? (DateTime?)null
                                                     : Convert.ToDateTime(reader["FechaActualizacion"])
                            });
                        }
                    }
                }
            }

            return buenasPracticas;
        }
    }
}