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
    public double KilometrosRecorridos { get; set; }
    public int EnergiaConsumida { get; set; }
    public double CargaTransportada { get; set; }
    public int InstruccionesIndividuales { get; set; }
    public int DaniosRecibidos { get; set; }
    public List<string> UltimosLugaresVisitados { get; set; }

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
            Console.WriteLine("El operador ya está en el cuartel.");
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
            Console.WriteLine("Los Operadores no están en la misma localización.");
        }
    }
    
    public void RealizarOrdenGeneral(Cuartel cuartel, Terreno terreno)
{
    if (!Dañado && !EnCuartel)
    {
        Localizacion vertederoCercano = BuscarVertederoCercano(terreno);

        if (vertederoCercano != null)
        {
            // Moverse al vertedero
            Moverse(vertederoCercano.Tipo, CalcularDistancia(Localizacion, vertederoCercano.Tipo));

            // Recoger carga máxima
            CargarMaximo();

            // Moverse al sitio de reciclaje más cercano
            Localizacion reciclajeCercano = BuscarReciclajeCercano(terreno);
            if (reciclajeCercano != null)
            {
                Moverse(reciclajeCercano.Tipo, CalcularDistancia(Localizacion, reciclajeCercano.Tipo));

                // Descargar carga en el sitio de reciclaje
                DescargarCarga();
            }
            else
            {
                Console.WriteLine("No hay sitios de reciclaje disponibles cercanos.");
            }
        }
        else
        {
            Console.WriteLine("No hay vertederos disponibles cercanos.");
        }
    }
    else
    {
        Console.WriteLine("El operador está dañado o en el cuartel y no puede realizar la orden general.");
    }
}

private void CargarMaximo()
{
    // Simulación de carga máxima
    Console.WriteLine("Cargando carga máxima.");
}

private void DescargarCarga()
{
    // Descarga de carga en el sitio de reciclaje
    Console.WriteLine("Descargando carga en el sitio de reciclaje.");
}

private Localizacion BuscarVertederoCercano(Terreno terreno)
{
    // Para encontrar el vertedero más cercano
    Random random = new Random();
    int fila = random.Next(terreno.Mapa.GetLength(0));
    int columna = random.Next(terreno.Mapa.GetLength(1));

    Localizacion localizacion = terreno.Mapa[fila, columna];
    return localizacion.Tipo == "Vertedero" ? localizacion : null;
}

private Localizacion BuscarReciclajeCercano(Terreno terreno)
{
    // Para encontrar el sitio de reciclaje más cercano
    Random random = new Random();
    int fila = random.Next(terreno.Mapa.GetLength(0));
    int columna = random.Next(terreno.Mapa.GetLength(1));

    Localizacion localizacion = terreno.Mapa[fila, columna];
    return localizacion.Tipo == "Sitio de Reciclaje" ? localizacion : null;
}

private double CalcularDistancia(string origen, string destino)
{
    // Cálculo de distancia entre dos localizaciones
    Console.WriteLine($"Calculando distancia entre {origen} y {destino}.");

    // Devuelve una distancia aleatoria para simular la operación real
    Random random = new Random();
    return random.NextDouble() * 10;
}

    public void RealizarMantenimiento(Cuartel cuartel)
{
    if (!Dañado)
    {
        if (EnCuartel)
        {
            Console.WriteLine("El operador ya está en el cuartel y no necesita mantenimiento adicional.");
        }
        else
        {
            // Moverse al cuartel
            Moverse("Cuartel", CalcularDistancia(Localizacion, "Cuartel"));

            // Realizar mantenimiento
            RealizarMantenimientoEnCuartel(cuartel);
        }
    }
    else
    {
        Console.WriteLine("El operador está dañado y requiere mantenimiento.");
        // Realizar reparaciones y cambios de componentes
        RealizarReparaciones();
        RealizarCambioComponentes();
    }
}

private void RealizarMantenimientoEnCuartel(Cuartel cuartel)
{
    // Mantenimiento en el cuartel
    Console.WriteLine("Realizando mantenimiento en el cuartel.");

    // Moverse a la reserva si es necesario
    if (cuartel.reserva.Contains(this))
    {    // agregar más lógica según sea necesario
        cuartel.reserva.Remove(this);
        cuartel.operadores.Add(this);
    }
        EnCuartel = true;
}

private void RealizarReparaciones()
{
    // Reparaciones en el operador
    Console.WriteLine("Realizando reparaciones en el operador.");
}

private void RealizarCambioComponentes()
{
    // Cambio de componentes en el operador
    Console.WriteLine("Realizando cambio de componentes en el operador.");
}

    public void CambiarBateria()
    {
        if (!EnCuartel)
    {
        // Cambio de batería
        Console.WriteLine("Cambiando la batería del operador.");
    }
    else
    {
        Console.WriteLine("El operador está en el cuartel y no necesita cambio de batería.");
    }
}


    public void SimularDaño()
    {
    Random random = new Random();
    int tipoDaño = random.Next(5); // 0 a 4, para simular diferentes tipos de daños

    switch (tipoDaño)
    {
        case 0:
            // MOTOR COMPROMETIDO: Reduce su velocidad promedio a la mitad.
            Console.WriteLine("Operador con MOTOR COMPROMETIDO. Velocidad reducida a la mitad.");
            VelocidadOptima /= 2;
            break;
        case 1:
            // SERVO ATASCADO: No puede realizar operaciones de carga y descarga física.
            Console.WriteLine("Operador con SERVO ATASCADO. No puede realizar operaciones de carga y descarga física.");
            break;
        case 2:
            // BATERIA PERFORADA: Pierde batería un 500% más rápido en cada operación.
            Console.WriteLine("Operador con BATERIA PERFORADA. Pierde batería un 500% más rápido en cada operación.");
            CapacidadBateria /= 5;
            break;
        case 3:
            // PUERTO BATERIA DESCONECTADO: No puede realizar operaciones de carga, recarga o transferencia de batería.
            Console.WriteLine("Operador con PUERTO BATERIA DESCONECTADO. No puede realizar operaciones de carga, recarga o transferencia de batería.");
            break;
        case 4:
            // PINTURA RAYADA: No tiene efecto.
            Console.WriteLine("Operador con PINTURA RAYADA. No tiene efecto.");
            break;
        default:
            Console.WriteLine("Error: Tipo de daño no reconocido.");
            break;
    }

    Dañado = true;
}

public void ActualizarEstadisticas()
    {
        // Actualizar las estadísticas después de cada operación o daño
        KilometrosRecorridos += 10; // Ejemplo de incremento en cada estadística
        EnergiaConsumida += 100;    
        CargaTransportada += 5;     
        InstruccionesIndividuales += 1; 
        DaniosRecibidos += 1;       
        UltimosLugaresVisitados.Add(Localizacion); 
    }

}
