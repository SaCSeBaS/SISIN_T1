using System;
using System.Collections.Generic;
using System.Text;

namespace Laberinto
{
    public class Coordenada
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int[,] Laberinto { get; set; }
        public int AnteriorDecision { get; set; } // 1 - IZQUIERDA | 2 - DERECHA | 3 - ARRIBA | 4 - ABAJO | 0 - DEFAULT
        public bool Explorado { get; set; }
        public Coordenada Padre { get; set; }
        public List<Coordenada> Hijos { get; set; }

        public Coordenada(int x, int y, int[,] laberinto, int anteriorDecision)
        {
            X = x;
            Y = y;
            Laberinto = laberinto;
            AnteriorDecision = anteriorDecision;
            Explorado = false;
            Padre = null;
            Hijos = new List<Coordenada>();
        }

        public void GenerarCaminos()
        {
            // CASO 1
            // IZQUIERDA
            if (EsValido(1))
            {
                Hijos.Add(new Coordenada(X - 1, Y, Laberinto, 1));
            }

            // CASO 2
            // DERECHA
            if (EsValido(2))
            {
                Hijos.Add(new Coordenada(X + 1, Y, Laberinto, 2));
            }

            // CASO 3
            // ARRIBA
            if (EsValido(3))
            {
                Hijos.Add(new Coordenada(X, Y - 1, Laberinto, 3));
            }

            // CASO 4
            // ABAJO
            if (EsValido(4))
            {
                Hijos.Add(new Coordenada(X, Y + 1, Laberinto, 4));
            }
        }

        // VALIDAR QUE SE PUEDA REALIZAR LA ACCIÓN (NO CHOCARSE CON UN MURO)
        // VALIDAR NO SALIRSE DE LA MATRIZ (X E Y NO PUEDEN SER MENORES QUE 0 O MAYORES QUE 29)
        // VALIDAR QUE NO SE REALICE EL PASO CONTRARIO AL ANTERIOR (ES DECIR IZQUIERDA CON DERECHA, ARRIBA CON ABAJO Y VICEVERSA)
        public bool EsValido(int caso)
        {
            switch(caso)
            {
                // IZQUIERDA
                case 1:

                    if (AnteriorDecision == 2)
                        return false;

                    if (X - 1 < 0)
                        return false;

                    if (Laberinto[X-1, Y] == 1)
                        return false;

                    return true;

                // DERECHA
                case 2:

                    if (AnteriorDecision == 1)
                        return false;

                    if (X + 1 > 29)
                        return false;

                    if (Laberinto[X+1, Y] == 1)
                        return false;

                    return true;

                // ARRIBA
                case 3:

                    if (AnteriorDecision == 4)
                        return false;

                    if (Y - 1 < 0)
                        return false;

                    if (Laberinto[X, Y-1] == 1)
                        return false;

                    return true;

                // ABAJO
                case 4:

                    if (AnteriorDecision == 3)
                        return false;

                    if (Y + 1 > 29)
                        return false;

                    if (Laberinto[X, Y+1] == 1)
                        return false;

                    return true;

                default:
                    return false; // GRACIAS COMPILADOR
            }
        }

        // VERIFICAR SI LLEGÓ AL FINAL
        public bool EsFinal() => X == 29 && Y == 29;

        public void DibujarLaberinto()
        {
            // PINTAR PARTE SUPERIOR
            Console.SetCursorPosition(3, 1);
            for (int i = 0; i < 32; i++)
            {
                Console.Write("═");
            }

            // PINTAR PARTE INFERIOR
            Console.SetCursorPosition(3, 32);
            for (int i = 0; i < 32; i++)
            {
                Console.Write("═");
            }

            // PINTAR PARTE IZQUIERDA
            for (int i = 0, j = 1; i < 32; i++, j++)
            {
                Console.SetCursorPosition(3, j);
                Console.Write("║");
            }

            // PINTAR PARTE DERECHA
            for (int i = 0, j = 1; i < 32; i++, j++)
            {
                Console.SetCursorPosition(34, j);
                Console.Write("║");
            }

            // PINTAR ESQUINA SUPERIOR IZQUIERDA
            Console.SetCursorPosition(3, 1);
            Console.Write("╔");

            // PINTAR ESQUINA SUPERIOR DERECHA
            Console.SetCursorPosition(34, 1);
            Console.Write("╗");

            // PINTAR ESQUINA INFERIOR IZQUIERDA
            Console.SetCursorPosition(3, 32);
            Console.Write("╚");

            // PINTAR ESQUINA INFERIOR DERECHA
            Console.SetCursorPosition(34, 32);
            Console.Write("╝");

            // NUMERACIÓN PARTE SUPERIOR
            Console.SetCursorPosition(4, 0);
            for (int i = 1, j = 65; i <= 30; i++, j++)
            {
                if(j <= 90)
                    Console.Write(Convert.ToChar(j));
                else
                    Console.Write(Convert.ToChar(j+6));
            }

            // NUMERACIÓN PARTE INFERIOR
            Console.SetCursorPosition(4, 33);
            for (int i = 1, j = 65; i <= 30; i++, j++)
            {
                if (j <= 90)
                    Console.Write(Convert.ToChar(j));
                else
                    Console.Write(Convert.ToChar(j + 6));
            }

            // NUMERACIÓN PARTE IZQUIERDA
            for (int i = 2, j = 1; i <= 31; i++, j++)
            {
                if (j < 10)
                    Console.SetCursorPosition(2, i);
                else
                    Console.SetCursorPosition(1, i);

                Console.Write(j);
            }

            // NUMERACIÓN PARTE DERECHA
            for (int i = 2, j = 1; i <= 31; i++, j++)
            {
                Console.SetCursorPosition(35, i);
                Console.Write(j);
            }

            // DIBUJAR PAREDES DEL LABERINTO
            for (int i = 0, x = 4; i < 30; i++, x++)
            {
                for (int j = 0, y = 2; j < 30; j++, y++)
                {
                    Console.SetCursorPosition(x, y);
                    if (Laberinto[j, i] == 1)
                    {
                        Console.Write("█");
                    }
                }
            }

            // IMPRIMIR MENSAJE
            Console.SetCursorPosition(3, 35);
            Console.Write("Presiona ENTER para continuar...");
        }

        public void MostrarEstadoActual(int fila, int columna, int numeroPasos, int pasoActual)
        {
            // MOSTRAR ESTADO
            Console.SetCursorPosition(43, 13);
            if(pasoActual == 0)
                Console.Write("ESTADO INICIAL");
            else
                if (numeroPasos != pasoActual)
                    Console.Write("ESTADO ACTUAL");
                else
                    Console.Write("ESTADO FINAL");

            Console.SetCursorPosition(43, 15);
            Console.Write("Fila: " + fila);
            Console.SetCursorPosition(43, 16);

            if (columna + 64 <= 90)
                Console.Write("Columna: " + Convert.ToChar(columna + 64));
            else
                Console.Write("Columna: " + Convert.ToChar(columna + 70));

            Console.SetCursorPosition(43, 18);
            Console.Write("Número de Pasos: " + numeroPasos);
            Console.SetCursorPosition(43, 19);
            Console.Write("Paso Actual: " + pasoActual);
        }

        public void ReportCamino()
        {
            // DIBUJAR LABERINTO
            DibujarLaberinto();

            // IMPRIMIR CARRO AL INICIO
            Console.SetCursorPosition(4, 2);
            Console.Write("©");

            // OBTENER RECORRIDO
            Coordenada next = this;
            List<Coordenada> coordenadas = new List<Coordenada>();
            while (next.Padre != null)
            {
                coordenadas.Add(next);
                next = next.Padre;
            }

            // MOSTRAR ESTADO INICIAL
            MostrarEstadoActual(1, 1, coordenadas.Count, 0);
            Console.ReadLine();
            Console.Clear();

            // MOSTRAR EL RESTO DEL CAMINO
            for (int i = coordenadas.Count - 1, j = 1; i >= 0; i--, j++)
            {
                DibujarLaberinto();
                Console.SetCursorPosition(coordenadas[i].Y + 4, coordenadas[i].X + 2);
                Console.Write("©");
                MostrarEstadoActual(coordenadas[i].X + 1, coordenadas[i].Y + 1, coordenadas.Count, j);
                Console.ReadLine();
                if(i != 0)
                    Console.Clear();
            }

            // COLOCAR EL CURSOR LEJOS PARA NO ARRUINAR LA IMPRESIÓN
            Console.SetCursorPosition(0, 40);
        }
    }
}