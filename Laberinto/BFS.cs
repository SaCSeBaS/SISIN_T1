using System;
using System.Collections.Generic;
using System.Text;

namespace Laberinto
{
    public class BFS
    {
        public Coordenada BreadthFirstSearch(Coordenada estadoInicial)
        {
            Coordenada actual;
            List<Coordenada> queue = new List<Coordenada>
            {
                estadoInicial // AGREGAR EL PRIMER ESTADO AL QUEUE
            };

            while (queue.Count > 0) // MIENTRAS EXISTAN ELEMENTOS DONDE BUSCAR
            {
                actual = queue[0]; // OBTENER EL SIGUIENTE ELEMENTO EN EL QUEUE
                queue.RemoveAt(0); // ELIMINAR EL ELEMENTO DE LA LISTA

                if (actual.EsFinal()) // ENCONTRÓ EL ESTADO FINAL
                    return actual;

                actual.GenerarCaminos(); // GENERAR POSIBLES CAMINOS

                foreach (Coordenada estado in actual.Hijos)
                {
                    if (!estado.Explorado) // VERIFICAR SI HA SIDO EXPLORADO
                    {
                        estado.Explorado = true; // MARCAR COMO EXPLORADO
                        estado.Padre = actual; // INDICAR PADRE
                        queue.Add(estado); // AGREGAR EL HIJO AL QUEUE
                    }
                }
            }

            return null; // NO ENCONTRÓ CAMINO
        }
    }
}