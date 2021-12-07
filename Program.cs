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
                Console.WriteLine("3. Mostrar Mecánicos");
                Console.WriteLine("4. Mostrar Hoja de Parte");
                Console.WriteLine("5. Mostrar Respuestos, Materiales e Insumos");
                Console.WriteLine("6. Mostrar Ayudantes");
                Console.WriteLine("7. Insertar Personas");
                Console.WriteLine("8. Insertar Vehiculos");
                Console.WriteLine("9. Insertar Mecánicos");
                Console.WriteLine("10. Insertar Hoja de Parte");
                Console.WriteLine("11. Insertar Repuestos, Materiales e Insumos");
                Console.WriteLine("12. Insertar Ayudantes");
                Console.WriteLine("13. Generar Factura");
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
                    MostrarMecanicos();
                }
                else if (opcion == "4")
                {
                    MostrarHojadeParte();
                }
                else if (opcion == "5")
                {
                    MostrarRepuestosInsumosMateriales();
                }
                else if (opcion == "6")
                {
                    MostrarAyudantes();
                }
                else if (opcion == "7")
                {
                    MostrarPersonas();
                    InsertarPersonas();
                }
                else if (opcion == "8")
                {
                    MostrarPersonas();
                    InsertarVehiculos();
                }
                else if (opcion == "9")
                {
                    MostrarVehiculos();
                    InsertarMecanicos();
                }
                else if (opcion == "10")
                {
                    MostrarVehiculos();
                    MostrarMecanicos();
                    InsertarHojadeParte();
                }
                else if (opcion == "11")
                {
                    MostrarHojadeParte();
                    InsertarRepuestosInsumosMateriales();
                }
                else if (opcion == "12")
                {
                    MostrarMecanicos();
                    InsertarAyudantes();
                }
                else if (opcion == "13")
                {
                    MostrarHojadeParte();
                    GenerarFacturas();
                    MostrarFacturas();
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
           // comando.Dispose();
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
        private static void MostrarMecanicos()
        {
            comando = new SqlCommand("select * from Mecanicos", conn);
            ejecutor = comando.ExecuteReader();
            while (ejecutor.Read())
            {
                Console.WriteLine(
                    ejecutor["CodMecanico"] + " | " +
                    ejecutor["CodVehiculo"] + " | " +
                    ejecutor["Nombre"] + " | " +
                    ejecutor["Apellido"] + " | " +
                    ejecutor["Estado"]
                    );
            }
            Console.WriteLine("**_______________________**");
            Console.ReadKey();
            ejecutor.Close();
        }
        private static void InsertarMecanicos()
        {
            comando.Dispose();
            try
            {
                Console.WriteLine("------------------------Insertar Mecanicos--------------------------");
                Console.WriteLine("Ingresar Codigo del Mecanico");
                string CodMecanico = Console.ReadLine();
                Console.WriteLine("Ingresar Codigo del Vehiculo");
                string CodVehiculo = Console.ReadLine();
                Console.WriteLine("Ingresar Nombre");
                string Nombre = Console.ReadLine();
                Console.WriteLine("Ingresar Apellido");
                string Apellido = Console.ReadLine();
                Console.WriteLine("Ingresar Estado");
                string Estado = Console.ReadLine();
                // ...
                comando.CommandText = "insert into Mecanicos values ('" +
                    CodMecanico + "','" +
                    CodVehiculo + "', '" +
                    Nombre + "', '" +
                    Apellido + "', '" +
                    Estado + "')";

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
        private static void MostrarHojadeParte()
        {
            comando = new SqlCommand("select * from HojadeParte", conn);
            ejecutor = comando.ExecuteReader();
            while (ejecutor.Read())
            {
                Console.WriteLine(
                    ejecutor["CodHoja"] + " | " +
                    ejecutor["CodVehiculo"] + " | " +
                    ejecutor["CodMecanico"] + " | " +
                    ejecutor["FechaIngreso"] + " | " +
                    ejecutor["HoraIngreso"] + " | " +
                    ejecutor["Manodeobra"]
                    );
            }
            Console.WriteLine("**_______________________**");
            Console.ReadKey();
            ejecutor.Close();
        }
        private static void InsertarHojadeParte()
        {
            comando.Dispose();
            try
            {
                Console.WriteLine("------------------------Insertar Hoja de Parte--------------------------");
                Console.WriteLine("Ingresar Codigo de la Hoja de Parte");
                string CodHoja = Console.ReadLine();
                Console.WriteLine("Ingresar Codigo del Vehiculo");
                string CodVehiculo = Console.ReadLine();
                Console.WriteLine("Ingresar Codigo del Mecanico");
                string CodMecanico = Console.ReadLine();
                Console.WriteLine("Ingresar Fecha de Ingreso");
                string FechaIngreso = Console.ReadLine();
                Console.WriteLine("Ingresar Hora de Ingreso");
                string HoraIngreso = Console.ReadLine();
                Console.WriteLine("Ingresar monto de la Mano de Obra");
                string Manodeobra = Console.ReadLine();
                // ...
                comando.CommandText = "insert into HojadeParte values ('" +
                    CodHoja + "','" +
                    CodVehiculo + "','" +
                    CodMecanico + "', '" +
                    FechaIngreso + "', '" +
                    HoraIngreso + "', '" +
                    Manodeobra + "')";

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
        private static void MostrarRepuestosInsumosMateriales()
        {
            comando = new SqlCommand("select * from Repuestos_Insumos_Materiales", conn);
            ejecutor = comando.ExecuteReader();
            while (ejecutor.Read())
            {
                Console.WriteLine(
                    ejecutor["CodRep_Ins_Mat"] + " | " +
                    ejecutor["CodHoja"] + " | " +
                    ejecutor["Nombre"] + " | " +
                    ejecutor["Precio"] 
                    );
            }
            Console.WriteLine("**_______________________**");
            Console.ReadKey();
            ejecutor.Close();
        }
        private static void InsertarRepuestosInsumosMateriales()
        {
            comando.Dispose();
            try
            {
                Console.WriteLine("------------------------Insertar Repuestos, Materiales e Insumos--------------------------");
                Console.WriteLine("Ingresar Codigo de los Repuestos, Materiales e Insumos");
                string CodRep_Ins_Mat = Console.ReadLine();
                Console.WriteLine("Ingresar Codigo de la Hoja de Parte");
                string CodHoja = Console.ReadLine();
                Console.WriteLine("Ingresar el Nombre");
                string Nombre = Console.ReadLine();
                Console.WriteLine("Ingresar Precio");
                string Precio = Console.ReadLine();
                // ...
                comando.CommandText = "insert into Repuestos_Insumos_Materiales values ('" +
                    CodRep_Ins_Mat + "','" +
                    CodHoja + "','" +
                    Nombre + "', '" +
                    Precio + "')";

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
        private static void MostrarAyudantes()
        {
            comando = new SqlCommand("select * from Ayudantes", conn);
            ejecutor = comando.ExecuteReader();
            while (ejecutor.Read())
            {
                Console.WriteLine(
                    ejecutor["CodAyudante"] + " | " +
                    ejecutor["CodMecanico"] + " | " +
                    ejecutor["Nombre"] + " | " +
                    ejecutor["Apellido"]
                    );
            }
            Console.WriteLine("**_______________________**");
            Console.ReadKey();
            ejecutor.Close();
        }
        private static void InsertarAyudantes()
        {
            comando.Dispose();
            try
            {
                Console.WriteLine("------------------------Insertar Ayudantes--------------------------");
                Console.WriteLine("Ingresar Codigo del Ayudante");
                string CodAyudante = Console.ReadLine();
                Console.WriteLine("Ingresar Codigo del Mecanico");
                string CodMecanico = Console.ReadLine();
                Console.WriteLine("Ingresar el Nombre");
                string Nombre = Console.ReadLine();
                Console.WriteLine("Ingresar Apellido");
                string Apellido = Console.ReadLine();
                // ...
                comando.CommandText = "insert into Ayudantes values ('" +
                    CodAyudante + "','" +
                    CodMecanico + "','" +
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
        private static void GenerarFacturas()
        {
            Console.WriteLine("Ingresar código de la factura");
            string CodFactura = Console.ReadLine();
            Console.WriteLine("Ingresar código de la Hoja de Parte");
            string CodHoja = Console.ReadLine();
            Console.WriteLine("Ingresar a que nombre estará la factura");
            string Nombre = Console.ReadLine();
            Console.WriteLine("Ingresar número de NIT");
            string Nit_Fac = Console.ReadLine();

            comando.Dispose();
            ejecutor.Close();
            comando.CommandText = "Generar_Factura";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CodFactura", CodFactura);
            comando.Parameters.AddWithValue("@CodHoja", CodHoja);
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Nit_Fac", Nit_Fac);
            comando.ExecuteNonQuery();
            Console.WriteLine("Factura generada correctamente");
        }
        private static void MostrarFacturas()
        {
            comando = new SqlCommand("select * from Facturas", conn);
            ejecutor = comando.ExecuteReader();
            while (ejecutor.Read())
            {
                Console.WriteLine(
                    ejecutor["CodFactura"] + " | " +
                    ejecutor["CodHoja"] + " | " +
                    ejecutor["Nombre"] + " | " +
                    ejecutor["Nit_Fac"] + " | " +
                    ejecutor["Total"]
                    );
            }
            Console.WriteLine("**_______________________**");
            Console.ReadKey();
            ejecutor.Close();
        }
    }
}
