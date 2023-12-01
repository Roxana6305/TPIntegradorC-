using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
class Terreno
{
    public Localizacion[,] Mapa { get; set; }

    public Terreno(int tamaño)
    {
        Mapa = new Localizacion[tamaño, tamaño];
        InicializarTerreno();
    }

    private void InicializarTerreno()
    {
        Random random = new Random();
        for (int i = 0; i < Mapa.GetLength(0); i++)
        {
            for (int j = 0; j < Mapa.GetLength(1); j++)
            {
                int tipoLocalizacion = random.Next(6);
                switch (tipoLocalizacion)
                {
                    case 0:
                        Mapa[i, j] = new TerrenoBaldio();
                        break;
                    case 1:
                        Mapa[i, j] = new Planicie();
                        break;
                    case 2:
                        Mapa[i, j] = new Bosque();
                        break;
                    case 3:
                        Mapa[i, j] = new SectorUrbano();
                        break;
                    case 4:
                        Mapa[i, j] = new Vertedero();
                        break;
                    case 5:
                        Mapa[i, j] = new Lago();
                        break;
                    // Añade más tipos de localizaciones
                }
            }
        }
    }
}
