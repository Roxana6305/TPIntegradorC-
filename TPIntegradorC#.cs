using System;

class OperadorMecanico
{
    public int Id { get; }
    public int Bateria { get; set; }
    public string Estado { get; set; }
    public int CargaMaxima { get; }
    public double VelocidadOptima { get; }
    public string Localizacion { get; set; }

    public OperadorMecanico(int id, int bateria, string estado, int cargaMaxima, double velocidadOptima)
    {
        Id = id;
        Bateria = bateria;
        Estado = estado;
        CargaMaxima = cargaMaxima;
        VelocidadOptima = velocidadOptima;
    }

    public void Mover(double distancia)
    {
        // Implementar la lógica para mover el operador y actualizar la batería y velocidad
    }

    public void TransferirCargaBateria(OperadorMecanico otroOperador)
    {
        // Implementar la transferencia de carga de batería entre operadores en la misma localización
    }

    public void TransferirCargaFisica(OperadorMecanico otroOperador)
    {
        // Implementar la transferencia de carga física entre operadores en la misma localización
    }

    public void VolverAlCuartel()
    {
        // Implementar el retorno al cuartel y transferencia de carga física y recarga de batería
    }

    public override string ToString()
    {
        return $"Operador ID: {Id}, Batería: {Bateria} mAh, Estado: {Estado}, Localización: {Localizacion}";
    }
}

//clases derivadas para cada tipo de operador (UAV, K9 y M8) que heredan de la clase OperadorMecanico:

class UAV : OperadorMecanico
{
    public UAV(int id, int bateria) : base(id, bateria, "Activo", 40, 100.0)
    {
    }
}

class K9 : OperadorMecanico
{
    public K9(int id, int bateria) : base(id, bateria, "Activo", 5, 50.0)
    {
    }
}

class M8 : OperadorMecanico
{
    public M8(int id, int bateria) : base(id, bateria, "Activo", 250, 30.0)
    {
    }
}