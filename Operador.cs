using System;
using System.Collections.Generic;

class Operador
{
    public int ID { get; set; }
    public string Tipo { get; set; }
    public int Bateria { get; set; }
    public int CargaMaxima { get; set; }
    public int VelocidadOptima { get; set; }
    public string Localizacion { get; set; }
    public string Estado { get; set; }
    public bool EnStandby { get; set; }
    public bool EnCuartel { get; set; } 
    public bool Dañado { get; set; }

    public Operador(int id, string tipo, int bateria, int cargaMaxima, int velocidadOptima, string localizacion, string estado, bool enStandby, bool enCuartel)
    {
        ID = id;
        Tipo = tipo;
        Bateria = bateria;
        CargaMaxima = cargaMaxima;
        VelocidadOptima = velocidadOptima;
        Localizacion = localizacion;
        Estado = estado;
        EnStandby = enStandby;
        EnCuartel = enCuartel;
        Dañado = dañado;
    }

    public void Moverse(string nuevaLocalizacion, double distancia)
    {
        // Actualiza la batería y la localización 
        double consumoBateria = (distancia / VelocidadOptima) * 0.1 * CargaMaxima;
        if (Bateria >= consumoBateria)
        {
            Bateria -= (int)consumoBateria;
            Localizacion = nuevaLocalizacion;
        }
        else
        {
            Console.WriteLine("Batería insuficiente para moverse.");
        }
    }

    public void TransferirCarga(Operador destino, int cantidad)
    {
        // Transfiere carga de batería de un operador a otro
        if (Localizacion == destino.Localizacion)
        {
            if (Bateria >= cantidad)
            {
                Bateria -= cantidad;
                destino.Bateria += cantidad;
            }
            else
            {
                Console.WriteLine("Batería insuficiente para transferir carga.");
            }
        }
        else
        {
            Console.WriteLine("Operadores no están en la misma localización.");
        }
    }

    public void VolverAlCuartel(Cuartel cuartel)
    {
        if (EnCuartel)
        {
            Console.WriteLine("El operador ya está en el cuartel y no se puede mover de nuevo al cuartel.");
        }
        else
        {
            EnCuartel = true;
            cuartel.operadores.Add(this);
        }
    }
    public void TransferirCargaFisica(Operador destino, int cantidad)
    {
        // Transfiere carga física entre operadores
        if (Localizacion == destino.Localizacion)
        {
            if (CargaMaxima >= cantidad)
            {
                CargaMaxima -= cantidad;
                destino.CargaMaxima += cantidad;
            }
            else
            {
                Console.WriteLine("Carga máxima insuficiente para transferir carga física.");
            }
        }
        else
        {
            Console.WriteLine("Operadores no están en la misma localización.");
        }
    }
    public void VolverAlCuartel(Cuartel cuartel)
    {
        if (!EnCuartel)
        {
            // Lógica para volver al cuartel
            EnCuartel = true;
            cuartel.operadores.Add(this);
        }
        else
        {
            Console.WriteLine("El operador ya está en el cuartel y no se puede mover de nuevo al cuartel.");
        }
    }
    public void RealizarOrdenGeneral(Cuartel cuartel, Terreno terreno)
    {
        // Lógica para la orden general de recoger carga y llevar al sitio de reciclaje
    }

    public void RealizarMantenimiento(Cuartel cuartel)
    {
        // Lógica para la orden general de volver al cuartel para mantenimiento
    }

    public void CambiarBateria()
    {
        // Lógica para cambiar la batería
    }

    public void SimularDaño()
    {
        // Lógica para simular diferentes tipos de daños al operador
    }
}
