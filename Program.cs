using System;
using Microsoft.Data.SqlClient;

namespace DBConnectV2
{
    class Program
    {
        static SqlConnection conn;
        static SqlCommand comando;
        static SqlDataReader ejecutor;

        static void Main(string[] args)
        {
            Conectar();

            MostrarOpciones();

            Console.WriteLine("**-----------------------------FIN--------------------------------**");
            Console.ReadKey();
        }

        private static void MostrarOpciones()
        {
            Console.WriteLine("------------------------Opciones---------------------------");
            Console.WriteLine("1. Registrar cliente");
            Console.WriteLine("2. Registrar vehiculo");
            Console.WriteLine("3. Asignar mecanico");
            Console.WriteLine("4. Asignar ayudantes");
            Console.WriteLine("5. Ver repuestos e insumos");
            Console.WriteLine("6. Generar factura");
            Console.WriteLine("*. Salir");
            Console.WriteLine("------------------------Seleccione una opcion---------------------------");
            string opcion = Console.ReadLine();
            if (opcion == "1")
            {
                MostrarMenu1();
            }
            else if (opcion == "2")
            {
                MostrarMenu2();
            }
            else
            {
                Console.WriteLine("Saliendo");
            }
        }

        private static void Conectar()
        {
            Console.WriteLine("Interactuando con la BD desde la consola");
            string connString = "Data Source=LAPTOP-EN8N3AD0\\MSSQLSERVER02;Initial Catalog=Concesionario;Integrated Security=True; trustServerCertificate=True";
            //            string connString = "Data Source = V-W7-DES; Initial Catalog = ConcesionariosVeh; User ID = PracticaConn; Password = PracticaConn";
            //conn = new SqlConnection(connString);
            try
            {
                Console.WriteLine("Abrimos la conexi�n ...");
                //conn.Open();
                //Console.WriteLine("Connexion exitosa");

            }
            catch (Exception e)
            {
                //Console.WriteLine("Error: " + e.Message);
                //Environment.Exit(0);
                Console.WriteLine("Connexion fallida");
            }
        }

        private static void MostrarMenu1()
        {
            Console.WriteLine("------------------------Menu 1---------------------------");
            Console.WriteLine("Ingresar codigo cliente");
            string codigoCliente = Console.ReadLine();
            Console.WriteLine("Ingresar vehiculo");
            string vehiculo = Console.ReadLine();
            Console.WriteLine("Ingresar CI");
            string ci = Console.ReadLine();
            Console.WriteLine("Ingresar Telefono");
            string telefono = Console.ReadLine();
            Console.WriteLine("Ingresar Direccion");
            string direccion = Console.ReadLine();
            Console.WriteLine("Ingresar Nombre");
            string nombre = Console.ReadLine();
            // ...

            comando.Dispose();
            Console.WriteLine("Insertando informacion en la base de datos...");
            try
            {
                comando.CommandText =
                    "insert into Clientes values (" +
                    "'" + codigoCliente + "', " +
                    "'" + direccion + "', " +
                    "'" + nombre + "')";
                comando.ExecuteNonQuery();
                Console.WriteLine("Se guardaron los datos");
                ejecutor.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Environment.Exit(0);
            }
        }

        private static void MostrarMenu2()
        {
            Console.WriteLine("------------------------Menu 2--------------------------");
            Console.WriteLine("Ingresar codigo vehiculo");
            string codigoVehiculo = Console.ReadLine();
            Console.WriteLine("Ingresar Matricula");
            string matricula = Console.ReadLine();
            Console.WriteLine("Ingresar Modelo");
            string modelo = Console.ReadLine();
            Console.WriteLine("Ingresar Color");
            string color = Console.ReadLine();
            Console.WriteLine("Ingresar Fecha de Ingreso");
            string fechaingreso = Console.ReadLine();
            Console.WriteLine("Ingresar Hora de Ingreso");
            string horaingreso = Console.ReadLine();
            // ...

            comando.Dispose();
            Console.WriteLine("Insertando informacion en la base de datos...");
            try
            {
                comando.CommandText =
                    "insert into Clientes values (" +
                    "'" + codigoCliente + "', " +
                    "'" + direccion + "', " +
                    "'" + nombre + "')";
                comando.ExecuteNonQuery();
                Console.WriteLine("Se guardaron los datos");
                ejecutor.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Environment.Exit(0);
            }
        }

        private static void CuartoEjercicio()
        {
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
        }

        private static void TercerEjercicio()
        {
            comando.Dispose();
            Console.WriteLine("Ejecutamos un procedimiento almacenado sin parametros");
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = "ListaVendedores";
            ejecutor = comando.ExecuteReader();
            while (ejecutor.Read())
            {
                Console.WriteLine(ejecutor["CI"] + " | " + ejecutor["Nombre"] + " | " + ejecutor["Telefono"] + " | " + ejecutor["Domicilio"]);
            }
            Console.WriteLine("**_______________________**");
            Console.ReadKey();
        }

        private static void SegundoEjercicio()
        {
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
        }

        private static void PrimerEjercicio()
        {
            Console.WriteLine("Ejecutamos un comando SQL directamente");
            comando = new SqlCommand("select * from Vendedores", conn);
            ejecutor = comando.ExecuteReader();
            while (ejecutor.Read())
            {
                Console.WriteLine(ejecutor["CI"] + " | " + ejecutor["Nombre"] + " | " + ejecutor["Telefono"]);
            }
            Console.WriteLine("**_______________________**");
            Console.ReadKey();
            ejecutor.Close();
        }
    }

}
