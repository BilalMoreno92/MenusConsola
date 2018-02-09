using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuConsola
{
    /// <summary>
    /// Coordenada (posición en la consola)
    /// </summary>
    public class Coordenada
    {
        /// <summary>
        /// Campos
        /// </summary>
        private int _top;
        private int _left;
        public int Top
        {
            get { return _top; }
            set
            {
                if (value < 0)
                    _top = 0;
                else
                    if (value >= Console.WindowHeight)
                        _top = Console.WindowHeight - 1;
                    else
                        _top = value;
            }
        }
        public int Left
        {
            get { return _left; }
            set
            {
                if (value < 0)
                    _left = 0;
                else
                    if (value >= Console.WindowWidth)
                        _left = Console.WindowWidth - 1;
                    else
                        _left = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Coordenada()
        {
            _top = 0;
            _left = 0;
        }
        public Coordenada(int top, int left)
        {
            Top = top;
            Left = left;
        }

        /// <summary>
        /// Mayor qué
        /// </summary>
        /// <param name ="coordenadaIzquierda">Coordenada a la izquierda del operador.</param>
        /// <param name="coordenadaDerecha">Coordenada a la derecha del operador.</param>
        /// <returns>True si coordenadaIzquierda es mayor que coordenadaDerecha, de locontrario false.</returns>
        public static bool operator >(Coordenada coordenadaIzquierda, Coordenada coordenadaDerecha)
        {
            if (coordenadaIzquierda._top > coordenadaDerecha._top && coordenadaIzquierda._left > coordenadaDerecha._left)
                return true;
            else return false;
        }
        /// <summary>
        /// Menor qué
        /// </summary>
        /// <param name="coordenadaIzquierda">Coordenada a la izquierda del operador.</param>
        /// <param name="coordenadaDerecha">Coordenada a la derecha del operador.</param>
        /// <returns>True si coordenadaIzquierda es menor que coordenadaDerecha, de locontrario false.</returns>
        public static bool operator <(Coordenada coordenadaIzquierda, Coordenada coordenadaDerecha)
        {
            if (coordenadaIzquierda._top < coordenadaDerecha._top || coordenadaIzquierda._left < coordenadaDerecha._left)
                return true;
            else return false;
        }
        /// <summary>
        /// Menos
        /// </summary>
        /// <param name="coordenadaIzquierda">Coordenada a la izquierda del operador.</param>
        /// <param name="coordenadaDerecha">Coordenada a la derecha del operador.</param>
        /// <returns>La resta entre ambas coordenadas que equivalen al Alto y el Ancho.</returns>
        public static Coordenada operator -(Coordenada coordenadaIzquierda, Coordenada coordenadaDerecha)
        {
            return new Coordenada(coordenadaIzquierda._top - coordenadaIzquierda._top, coordenadaDerecha._left - coordenadaDerecha._left);
        }
    }
}
