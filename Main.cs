class Program
{
    static void Main(string[] args)
    {
        Cuartel cuartel = new Cuartel();

        Operador operador1 = new Operador(1, "UAV", 4000, 5, 50, "Localizacion1", "Activo", false, false);
        Operador operador2 = new Operador(2, "K9", 6500, 40, 30, "Localizacion2", "Activo", false, false);

        cuartel.operadores.Add(operador1);
        cuartel.operadores.Add(operador2);

        operador1.Moverse("Localizacion3", 10);
        cuartel.ListarEstadoOperadores();

        Console.WriteLine("¿Quieres cargar una simulación previa o generar una nueva simulación? (Cargar/Generar)");
        string respuesta = Console.ReadLine().ToLower();

        Cuartel cuartel = new Cuartel();

        Terreno terreno;
        if (respuesta == "cargar")
        {
            terreno = CargarSimulacion();
        }
        else
        {
            Console.WriteLine("Generando nueva simulación...");
            terreno = new Terreno(100);
        }

        // Crea operadores y realiza operaciones en el sistema según las nuevas funcionalidades

        static Terreno CargarSimulacion()
    {
        // Cargar una simulación previa
        try
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("simulacion.dat", FileMode.Open, FileAccess.Read);
            Terreno terreno = (Terreno)formatter.Deserialize(stream);
            stream.Close();
            return terreno;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("No se encontró un archivo de simulación previa. Generando nueva simulación...");
            return new Terreno(100);
        }
    }

    static void GuardarSimulacion(Terreno terreno)
    {
        // guardar una simulación
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream("simulacion.dat", FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, terreno);
        stream.Close();
    }
        Console.ReadKey();

    static string connectionString = "Data Source=SkyNetDatabase.db;Version=3;";

    static void Main(string[] args)
    {
        // Intenta cargar desde la base de datos
        if (IntentarCargarDesdeBaseDeDatos())
        {
            // Éxito, continúa con el programa
        }
        else
        {
            // Falla, recurre a los datos locales
            CargarDatosLocales();
            // Genera datos si no hay datos locales
            if (DatosLocalesVacios())
            {
                GenerarDatosIniciales();
            }
        }

        // Resto del programa

        // Cierra el programa
        GuardarEnBaseDeDatos();
        GuardarDatosLocales();
    }

    static bool IntentarCargarDesdeBaseDeDatos()
    {
        try
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                static List<Operador> CargarOperadoresDesdeBaseDeDatos()
{
    List<Operador> operadores = new List<Operador>();

    try
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Operadores";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Operador operador = new Operador();
                        operador.Id = reader.GetInt32(0); // Ajustar según la estructura real de la tabla
                        operador.Nombre = reader.GetString(1); // Ajustar según la estructura real de la tabla

                        // Leer otros campos

                        operadores.Add(operador);
                    }
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al cargar operadores desde la base de datos: {ex.Message}");
    }

    return operadores;
}

                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar desde la base de datos: {ex.Message}");
            return false;
        }
    }

    static void CargarDatosLocales()
    {
    try
    {
        if (File.Exists("DatosLocales.txt"))
        {
            using (StreamReader reader = new StreamReader("DatosLocales.txt"))
            {
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                ProcesarLineaDeDatos(linea);
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al cargar datos locales: {ex.Message}");
    }
}

static void ProcesarLineaDeDatos(string linea)
{
    // Procesar cada línea de datos y cargar la información
    string[] campos = linea.Split(',');
    
    int id = int.Parse(campos[0]);
    string nombre = campos[1];
    
    // Crea operador y asigna valores
    Operador operador = new Operador();
    operador.Id = id;
    operador.Nombre = nombre;
    
}

    static bool DatosLocalesVacios() //Metodo True
    {
        return !File.Exists("DatosLocales.txt");
    }

    static void GenerarDatosIniciales()
{
    // Operadores iniciales de ejemplo
    Operador operador1 = new Operador
    {
        Id = 1,
        Nombre = "Operador1",
        // Configurar otros atributos según implementación
    };

    Operador operador2 = new Operador
    {
        Id = 2,
        Nombre = "Operador2",
        // Configurar otros atributos según implementación
    };

    // Agrega los operadores a la lista o estructura de datos
    listaDeOperadores.Add(operador1);
    listaDeOperadores.Add(operador2);

    GuardarDatosLocales();
    GuardarEnBaseDeDatos();
}
}

    static void GuardarEnBaseDeDatos()
    {
        try
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Actualiza las estadísticas de los operadores antes de guardar
                foreach (Operador operador in listaDeOperadores)
                {
                    operador.ActualizarEstadisticas();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar en la base de datos: {ex.Message}");
        }
    }

    static void GuardarEnBaseDeDatos()
{
    try
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            // Limpiar la tabla antes de guardar si es necesario
            string limpiarTablaQuery = "DELETE FROM Operadores";
            using (SQLiteCommand limpiarTablaCommand = new SQLiteCommand(limpiarTablaQuery, connection))
            {
                limpiarTablaCommand.ExecuteNonQuery();
            }

            // Insertar cada operador en la base de datos
            foreach (Operador operador in listaDeOperadores)
            {
                string insertarQuery = "INSERT INTO Operadores (Id, Nombre, KilometrosRecorridos, EnergiaConsumida, CargaTransportada, InstruccionesIndividuales, DaniosRecibidos, UltimosLugaresVisitados) " +
                    "VALUES (@Id, @Nombre, @KilometrosRecorridos, @EnergiaConsumida, @CargaTransportada, @InstruccionesIndividuales, @DaniosRecibidos, @UltimosLugaresVisitados)";

                using (SQLiteCommand insertarCommand = new SQLiteCommand(insertarQuery, connection))
                {
                    // Configurar los parámetros con los valores del operador actual
                    insertarCommand.Parameters.AddWithValue("@Id", operador.Id);
                    insertarCommand.Parameters.AddWithValue("@Nombre", operador.Nombre);
                    insertarCommand.Parameters.AddWithValue("@KilometrosRecorridos", operador.KilometrosRecorridos);
                    insertarCommand.Parameters.AddWithValue("@EnergiaConsumida", operador.EnergiaConsumida);
                    insertarCommand.Parameters.AddWithValue("@CargaTransportada", operador.CargaTransportada);
                    insertarCommand.Parameters.AddWithValue("@InstruccionesIndividuales", operador.InstruccionesIndividuales);
                    insertarCommand.Parameters.AddWithValue("@DaniosRecibidos", operador.DaniosRecibidos);
                    // Convertir la lista de lugares visitados a un formato que se pueda almacenar en la base de datos (por ejemplo, convertir a cadena JSON)
                    insertarCommand.Parameters.AddWithValue("@UltimosLugaresVisitados", ConvertirListaAFormatoAlmacenamiento(operador.UltimosLugaresVisitados));

                    // Ejecutar la consulta de inserción
                    insertarCommand.ExecuteNonQuery();
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al guardar en la base de datos: {ex.Message}");
    }
}
}

