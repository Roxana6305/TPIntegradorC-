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

        Console.ReadKey();
    }
}
