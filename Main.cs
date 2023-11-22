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
        // ...

        static Terreno CargarSimulacion()
    {
        // Lógica para cargar una simulación previa
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
        // Lógica para guardar una simulación
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream("simulacion.dat", FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, terreno);
        stream.Close();
    }
        Console.ReadKey();
    }
}
