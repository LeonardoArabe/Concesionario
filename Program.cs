using System;
using Microsoft.Data.SqlClient;

namespace DBConnectV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Interactuando con la BD desde la consola");
            string connString = "Data Source=LAPTOP-EN8N3AD0\\MSSQLSERVER02;Initial Catalog=Concesionario;Integrated Security=True; trustServerCertificate=True";
            //            string connString = "Data Source = V-W7-DES; Initial Catalog = ConcesionariosVeh; User ID = PracticaConn; Password = PracticaConn";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                Console.WriteLine("Abrimos la conexi�n ...");
                conn.Open();
                Console.WriteLine("Connexion exitosa");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Environment.Exit(0);
            }


            // Primer ejercicio: un comando SQL directo
            Console.WriteLine("Ejecutamos un comando SQL directamente");
            SqlCommand comando = new SqlCommand("select * from Vendedores", conn);
            SqlDataReader ejecutor = comando.ExecuteReader();
            while (ejecutor.Read())
            {
                Console.WriteLine(ejecutor["CI"] + " | " + ejecutor["Nombre"] + " | " + ejecutor["Telefono"]);
            }
            Console.WriteLine("**_______________________**");
            Console.ReadKey();
            ejecutor.Close();


            /* Segundo ejercicio: un comando SQL directo
                        comando.Dispose();
                        Console.WriteLine("Ejecutamos un segundo comando SQL directamente (insert)");
                        try
                        {
                            comando.CommandText = "insert into Vendedores values ('7894565', 'Av. Perimetral esq. Transversal 1', 'Leonardo Arabe', '3457896', '0000', '0000')";
                            comando.ExecuteNonQuery();
                            Console.WriteLine("**_______________________**");
                            Console.ReadKey();
                            ejecutor.Close();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: " + e.Message);
                            Environment.Exit(0);
                        }
 
            */

            //Tercer ejercicio: procedimiento almacenado sin parametros
           /* comando.Dispose();
            Console.WriteLine("Ejecutamos un procedimiento almacenado sin parametros");
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = "ListaVendedores";
            ejecutor = comando.ExecuteReader();
            while (ejecutor.Read())
            {
                Console.WriteLine(ejecutor["CI"] + " | " + ejecutor["Nombre"] + " | " + ejecutor["Telefono"] + " | " + ejecutor["Domicilio"]);
            }
            Console.WriteLine("**_______________________**");
            Console.ReadKey();*/




            //Cuarto Ejercicio
            comando.Dispose();
            ejecutor.Close();
            Console.WriteLine("Ejecutamos un procedimiento almacenado con parametros de entrada y salida");
            comando.CommandText = "VerVendedor";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@p_CI", "3789496");
            SqlParameter Nombre = new SqlParameter("@p_Nombre", System.Data.SqlDbType.VarChar, 40);
            Nombre.Direction = System.Data.ParameterDirection.Output;
            comando.Parameters.Add(Nombre);
            comando.ExecuteNonQuery();
            Console.WriteLine("El numero de CI corresponde al vendedor:" + Nombre.Value);
            Console.WriteLine("**_______________________**");
            Console.ReadKey();
        }
    }

}
