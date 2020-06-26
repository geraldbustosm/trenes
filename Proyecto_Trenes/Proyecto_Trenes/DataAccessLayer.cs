using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trenes
{
    public class DataAccessLayer
    {
        private SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;User ID=SA;Initial Catalog=Proyecto-Trenes-DB;Data Source=DESKTOP-EBJ27AI"); 
        public void insertTren(Tren tren) {
            try
            {
                conn.Open();
                string query = @"
                                INSERT INTO Trenes (capacidad, codigo, tipoMaterial, origen, destino)
                                VALUES (@tipo, @origen, @destino, @capacidad, @codigo)
                                ";
                SqlParameter capacidad = new SqlParameter("@capacidad", tren.capacidad);
                SqlParameter codigo = new SqlParameter("@codigo", tren.codigo);
                SqlParameter tipoMaterial = new SqlParameter("@tipo", tren.tipo);
                SqlParameter origen = new SqlParameter("@origen", tren.origen);
                SqlParameter destino = new SqlParameter("@destino", tren.destino);

                SqlCommand command = new SqlCommand(query, conn);

                command.Parameters.Add(capacidad);
                command.Parameters.Add(codigo);
                command.Parameters.Add(tipoMaterial);
                command.Parameters.Add(origen);
                command.Parameters.Add(destino);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Tren> getTrenes()
        {
            List<Tren> trenes = new List<Tren>();
            try
            {
                conn.Open();
                string query = @"SELECT *
                                FROM Trenes";
                SqlCommand command = new SqlCommand(query, conn);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    trenes.Add(new Tren
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        capacidad = reader["capacidad"].ToString(),
                        codigo = reader["codigo"].ToString(),
                        tipo = reader["tipoMaterial"].ToString(),
                        origen = reader["origen"].ToString(),
                        destino = reader["destino"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return trenes;
        }
    }
}
