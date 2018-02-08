using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuConsola
{
    /// <summary>
    /// Clase Marco
    /// </summary>
    class Marco
    {
        #region Campos
        public Coordenada _superiorIzquierda;
        public Coordenada _inferiorDerecha;
        //internal const string MENSAJE_EXCEPCION_MARCO = "El tamaño del marco está fuera del rango de valores permitidos.";
        //internal Exception MarcoFueraDeRangoException = new ArgumentOutOfRangeException(MENSAJE_EXCEPCION_MARCO, new ArgumentOutOfRangeException());
        public ConsoleColor _colorMarco;
        public EstiloMarco _estiloMarco;
        #endregion

        #region Constructores
        public Marco()
        {
            _superiorIzquierda = new Coordenada(0, 0);
            _inferiorDerecha = new Coordenada(Console.WindowHeight - 1, Console.WindowWidth - 1);
            _estiloMarco = EstiloMarco.Simple;
            _colorMarco = Console.ForegroundColor;
        }
        public Marco(Coordenada esquinaSuperiorIzquierda, Coordenada esquinaInferiorDerecha, EstiloMarco estiloMarco)
        {
            _superiorIzquierda = esquinaSuperiorIzquierda;
            _inferiorDerecha = esquinaInferiorDerecha;
            _estiloMarco = estiloMarco;
            _colorMarco = Console.ForegroundColor;
        }
        public Marco(Coordenada esquinaSuperiorIzquierda, Coordenada esquinaInferiorDerecha, EstiloMarco estiloMarco, ConsoleColor colorMarco)
        {
            _superiorIzquierda = esquinaSuperiorIzquierda;
            _inferiorDerecha = esquinaInferiorDerecha;
            _estiloMarco = estiloMarco;
            _colorMarco = colorMarco;
        }
        public Marco(Coordenada esquinaSuperiorIzquierda, EstiloMarco estiloMarco)
        {
            _superiorIzquierda = esquinaSuperiorIzquierda;
            _inferiorDerecha = new Coordenada();
            _estiloMarco = estiloMarco;
            _colorMarco = Console.ForegroundColor;
        }
        public Marco(Coordenada esquinaSuperiorIzquierda, EstiloMarco estiloMarco, ConsoleColor colorMarco)
        {
            _superiorIzquierda = esquinaSuperiorIzquierda;
            _estiloMarco = estiloMarco;
            _colorMarco = colorMarco;
        }
        #endregion
    }
}
