[Serializable]
abstract class Localizacion
{
    public string Tipo { get; set; }

    public abstract void InteractuarConOperador(Operador operador);

    // Agrega otros métodos y propiedades según sea necesario
}

[Serializable]
class TerrenoBaldio : Localizacion
{
    public TerrenoBaldio()
    {
        Tipo = "Terreno Baldío";
    }

    public override void InteractuarConOperador(Operador operador)
    {
        // Lógica específica para Terreno Baldío
    }
}

[Serializable]
class Planicie : Localizacion
{
    public Planicie()
    {
        Tipo = "Planicie";
    }

    public override void InteractuarConOperador(Operador operador)
    {
        // Lógica específica para Planicie
    }
}

[Serializable]
class Bosque : Localizacion
{
    public Bosque()
    {
        Tipo = "Bosque";
    }

    public override void InteractuarConOperador(Operador operador)
    {
        // Lógica específica para Bosque
    }
}

[Serializable]
class SectorUrbano : Localizacion
{
    public SectorUrbano()
    {
        Tipo = "Sector Urbano";
    }

    public override void InteractuarConOperador(Operador operador)
    {
        // Lógica específica para Sector Urbano
    }
}

[Serializable]
class Vertedero : Localizacion
{
    public Vertedero()
    {
        Tipo = "Vertedero";
    }

    public override void InteractuarConOperador(Operador operador)
    {
        // Lógica específica para Vertedero
    }
}

[Serializable]
class Lago : Localizacion
{
    public Lago()
    {
        Tipo = "Lago";
    }

    public override void InteractuarConOperador(Operador operador)
    {
        // Lógica específica para Lago
    }
}