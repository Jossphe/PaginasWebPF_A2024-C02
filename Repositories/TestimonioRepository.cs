using System.Data;
using Microsoft.Data.SqlClient;
using ReciclajeApp.Models;

namespace ReciclajeApp.Repositories
{
    public interface ITestimonioRepository
    {
        List<Testimonio> ObtenerTestimoniosActivos();
    }

    public class TestimonioRepository : ITestimonioRepository
    {
        private readonly string _connectionString;

        public TestimonioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Testimonio> ObtenerTestimoniosActivos()
        {
            var testimonios = new List<Testimonio>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_ObtenerTestimoniosActivos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            testimonios.Add(new Testimonio
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Empresa = reader["Empresa"].ToString(),
                                Mensaje = reader["Mensaje"].ToString(),
                                FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),
                                Activo = Convert.ToBoolean(reader["Activo"])
                            });
                        }
                    }
                }
            }

            return testimonios;
        }
    }
}