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
            string opcion = "1";
            do
            {
                Console.Clear();
                Console.WriteLine("------------------------Opciones---------------------------");
                Console.WriteLine("1. Mostrar Personas");
                Console.WriteLine("2. Mostrar Vehículos");
                Console.WriteLine("3. Insertar Personas");
                Console.WriteLine("4. Insertar Vehiculos");
                Console.WriteLine("5. Ver repuestos e insumos");
                Console.WriteLine("6. Generar factura");
                Console.WriteLine("*. Salir");
                Console.WriteLine("------------------------Seleccione una opcion---------------------------");
                opcion = Console.ReadLine();
                if (opcion == "1")
                {
                    MostrarPersonas();
                }
                else if (opcion == "2")
                {
                    MostrarVehiculos();
                }
                else if (opcion == "3")
                {
                    MostrarPersonas();
                    InsertarPersonas();
                }
                else if (opcion == "4")
                {
                    MostrarPersonas();
                    MostrarVehiculos();
                    InsertarVehiculos();
                }
                else
                {
                    Console.WriteLine("Saliendo");
                }
            } while (opcion != "*");
        }

        private static void Conectar()
        {
            Console.WriteLine("Interactuando con la BD desde la consola");
            string connString = "Data Source=LAPTOP-EN8N3AD0\\MSSQLSERVER02;Initial Catalog=Concesionario;Integrated Security=True; trustServerCertificate=True";

            conn = new SqlConnection(connString);
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
                Console.WriteLine("Connexion fallida");
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


        private static void MostrarPersonas()
        {
            /*CodCliente char(10) not null,
            Vehiculo  varchar(30) not null,
            CI nchar(10) not null,
            Telefono nchar(10) not null,
            Dirección varchar(50) not null,
            Nombre varchar(30) not null,
            Apellido varchar(30) not null,*/
            comando = new SqlCommand("select * from Clientes", conn);
            ejecutor = comando.ExecuteReader();
            while (ejecutor.Read())
            {
                Console.WriteLine(
                    ejecutor["CodCliente"] + " | " +
                    ejecutor["Vehiculo"] + " | " +
                    ejecutor["CI"] + " | " +
                    ejecutor["Telefono"] + " | " +
                    ejecutor["Dirección"] + " | " +
                    ejecutor["Nombre"] + " | " +
                    ejecutor["Apellido"]
                    );
            }
            Console.WriteLine("**_______________________**");
            Console.ReadKey();
            ejecutor.Close();
        }
        private static void InsertarPersonas()
        {
            comando.Dispose();
            try
            {
                Console.WriteLine("------------------------Insertar Personas--------------------------");
                Console.WriteLine("Ingresar Código del Cliente");
                string CodCliente = Console.ReadLine();
                Console.WriteLine("Ingresar vehiculo");
                string Vehiculo = Console.ReadLine();
                Console.WriteLine("Ingresar CI");
                string CI = Console.ReadLine();
                Console.WriteLine("Ingresar Telefono");
                string Telefono = Console.ReadLine();
                Console.WriteLine("Ingresar Direccion");
                string Direccion = Console.ReadLine();
                Console.WriteLine("Ingresar Nombre");
                string Nombre = Console.ReadLine();
                Console.WriteLine("Ingresar Apellido");
                string Apellido = Console.ReadLine();

                // ...
                comando.CommandText = "insert into Clientes values ('" +
                    CodCliente + "','" +
                    Vehiculo + "', '" +
                    CI + "', '" +
                    Telefono + "', '" +
                    Direccion + "', '" +
                    Nombre + "', '" +
                    Apellido + "')";

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

        private static void MostrarVehiculos()
        {
            comando = new SqlCommand("select * from Vehiculo", conn);
            ejecutor = comando.ExecuteReader();
            while (ejecutor.Read())
            {
                Console.WriteLine(
                    ejecutor["CodVehiculo"] + " | " +
                    ejecutor["CodCliente"] + " | " +
                    ejecutor["Matricula"] + " | " +
                    ejecutor["Modelo"] + " | " +
                    ejecutor["Color"]
                    );
            }
            Console.WriteLine("**_______________________**");
            Console.ReadKey();
            ejecutor.Close();
        }
        private static void InsertarVehiculos()
        {
            comando.Dispose();
            try
            {
                Console.WriteLine("------------------------Insertar Vehiculos--------------------------");
                Console.WriteLine("Ingresar Codigo del Vehiculo");
                string CodVehiculo = Console.ReadLine();
                Console.WriteLine("Ingresar Codigo del Cliente");
                string CodCliente = Console.ReadLine();
                Console.WriteLine("Ingresar Matricula");
                string Matricula = Console.ReadLine();
                Console.WriteLine("Ingresar Modelo");
                string Modelo = Console.ReadLine();
                Console.WriteLine("Ingresar Color");
                string Color = Console.ReadLine();
                // ...
                comando.CommandText = "insert into Vehiculo values ('" +
                    CodVehiculo + "','" +
                    CodCliente + "', '" +
                    Matricula + "', '" +
                    Modelo + "', '" +
                    Color + "')";

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
    }
}
