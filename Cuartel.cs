class Cuartel
{
    public List<Operador> operadores { get; set; }
    public List<Operador> reserva { get; set; }

    public Cuartel()
    {
        operadores = new List<Operador>();
        reserva = new List<Operador>();
    }

    public void ListarEstadoOperadores()
    {
        foreach (var operador in operadores)
        {
            Console.WriteLine($"ID: {operador.ID}, Tipo: {operador.Tipo}, Batería: {operador.Bateria}, Localización: {operador.Localizacion}");
        }
    }
    
}