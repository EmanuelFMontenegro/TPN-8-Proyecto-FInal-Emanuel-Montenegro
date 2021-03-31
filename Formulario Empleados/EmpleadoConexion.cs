using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Formulario_Empleados
{
    class EmpleadoConexion
    {
        public List<Empleado> ListarEmpleados()
        {
            List<Empleado> listado = new List<Empleado>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            conexion.ConnectionString = "data source=DESKTOP-HBVMSVQ; initial catalog=EMPLEADOS_DB; integrated security=sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "select * from Empleados";
            comando.Connection = conexion;
            conexion.Open();

            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Empleado aux = new Empleado();
                aux.Id = lector.GetInt32(0);
                aux.NombreCompleto = lector.GetString(1);
                aux.DNI = lector.GetInt32(2);
                aux.Edad = lector.GetInt32(3);
                aux.Casado = lector.GetString(4);
                aux.Salario = lector.GetDecimal(5);

                listado.Add(aux);
            }
            conexion.Close();

            return listado;
            }
            internal void modificar(Empleado empleado)
            {
                SqlConnection conexion = new SqlConnection("data source=DESKTOP-HBVMSVQ; initial catalog=EMPLEADOS_DB; integrated security=sspi");
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = conexion;

                try
                {
                    comando.CommandText = "Update Empleados Set NombreCompleto=@nombre, DNI=@dni,Edad=@edad,Casado=@casado,Salario=@salario Where Id=@id";
                    comando.Parameters.AddWithValue("@nombre", empleado.NombreCompleto);
                    comando.Parameters.AddWithValue("@dni", empleado.DNI);
                    comando.Parameters.AddWithValue("@edad", empleado.Edad);
                    comando.Parameters.AddWithValue("@casado", empleado.Casado);
                    comando.Parameters.AddWithValue("@salario", empleado.Salario);
                    comando.Parameters.AddWithValue("@id", empleado.Id);

                conexion.Open();
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

               internal void eliminar(int id)
            {
                SqlConnection conexion = new SqlConnection("data source=DESKTOP-HBVMSVQ; initial catalog=EMPLEADOS_DB; integrated security=sspi");
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = conexion;

                try
                {
                    comando.CommandText = "Delete From Empleados Where Id=@id";
                    comando.Parameters.AddWithValue("@id", id);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void agregar(Empleado Empl)
            {
                SqlConnection conexion = new SqlConnection("data source=DESKTOP-HBVMSVQ; initial catalog=EMPLEADOS_DB; integrated security=sspi");
                SqlCommand comando = new SqlCommand();

                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = conexion;
            comando.CommandText = "INSERT INTO Empleados VALUES ('" + Empl.NombreCompleto + "','" + Empl.DNI + "','" + Empl.Edad
                + "','" + Empl.Casado + "','" + Empl.Salario + "')";
                comando.Parameters.AddWithValue("@nombre", Empl.NombreCompleto);
                comando.Parameters.AddWithValue("@dni", Empl.DNI);
                comando.Parameters.AddWithValue("@edad", Empl.Edad);
                comando.Parameters.AddWithValue("@casado", Empl.Casado);
                comando.Parameters.AddWithValue("@salario", Empl.Salario);
                comando.Parameters.AddWithValue("@id", Empl.Id);

            conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
        }
    }

