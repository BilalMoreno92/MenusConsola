using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuConsola
{
    /// <summary>
    /// Estilo de la línea del marco.
    /// </summary>
    public enum EstiloMarco { Transparente, Simple, Doble };

    /// <summary>
    /// Clase Menú
    /// </summary>
    public class Menu
    {
        #region Campos
        private const int MINIMO_ALTURA = 7;
        private const int MINIMO_ANCHO = 7;
        private Marco _marco;
        private string _titulo;
        private string[] _contenido;
        private string _mensaje;
        private ConsoleColor _colorFondo;
        private ConsoleColor _colorTitulo;
        private ConsoleColor _colorContenido;
        private ConsoleColor _colorMensaje;
        private ConsoleColor _colorTexto;
        private int LINEA_TITULO;
        private int PRIMERA_LINEA_OPCIONES;
        private int MAXIMO_OPCIONES;
        private int LINEA_MENSAJE;
        private int COMIENZO_LINEA;
        private int LONGITUD_LINEA;
        private int linea;  // Numero de línea para el método Mostrar()
        #endregion

        #region Propiedades
        /// <summary>
        /// Color del fondo del menú (el fondo de la consola alrededor del menú no se verá afectado).
        /// </summary>
        public ConsoleColor ColorFondo
        {
            get { return _colorFondo; }
            set { _colorFondo = value; }
        }
        /// <summary>
        /// Color del título.
        /// </summary>
        public ConsoleColor ColorTitulo
        {
            get { return _colorTitulo; }
            set { _colorTitulo = value; }
        }
        /// <summary>
        /// Color del contenido.
        /// </summary>
        public ConsoleColor ColorContenido
        {
            get { return _colorContenido; }
            set { _colorContenido = value; }
        }
        /// <summary>
        /// Color del mensaje.
        /// </summary>
        public ConsoleColor ColorMensaje
        {
            get { return _colorMensaje; }
            set { _colorMensaje = value; }
        }
        /// <summary>
        /// Al editar esta propiedad se cambian los colores del título, el contenido y el mensaje.
        /// </summary>
        public ConsoleColor ColorTexto
        {
            set
            {
                _colorTexto = value;
                _colorTitulo = value;
                _colorContenido = value;
                _colorMensaje = value;

            }
        }
        /// <summary>
        /// Color de la línea del marco.
        /// </summary>
        public ConsoleColor ColorMarco
        {
            get { return _marco._colorMarco; }
            set { _marco._colorMarco = value; }
        }
        /// <summary>
        /// Título del menú, en el marco superior. La longitud máxima de línea es Ancho - 2.
        /// </summary>
        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }
        /// <summary>
        /// Opciones o contenido principal del menú, en el marco central. El número máximo de opciones a mostrar será Alto - 6. La longitud máxima de línea es Ancho - 2.
        /// </summary>
        public string[] Contenido
        {
            get { return _contenido; }
            set { _contenido = value; }
        }
        /// <summary>
        /// Mensaje mostrado en el marco inferior. La longitud máxima de línea es Ancho - 3.
        /// </summary>
        public string Mensaje
        {
            get { return _titulo; }
            set { _titulo = value; }
        }
        /// <summary>
        /// Posición de la esquina superior izquierda del marco.
        /// </summary>
        public Coordenada SuperiorIzquierda
        {
            get { return _marco._superiorIzquierda; }
            //set
            //{
            //    _marco._superiorIzquierda.Top = value.Top;
            //    _marco._superiorIzquierda.Left = value.Left;
            //    if (Alto > Console.WindowHeight || Alto < MINIMO_ALTURA || Ancho > Console.WindowWidth || Ancho < MINIMO_ANCHO)
            //        throw _marco.MarcoFueraDeRangoException;


            //}
        }
        /// <summary>
        /// Posición de la esquina inferior derecha del marco.
        /// </summary>
        public Coordenada InferiorDerecha
        {
            get { return _marco._inferiorDerecha; }
            //set
            //{
            //    _marco._inferiorDerecha.Top = value.Top;
            //    _marco._superiorIzquierda.Left = value.Left;
            //    if (Alto > Console.WindowHeight || Alto < MINIMO_ALTURA || Ancho > Console.WindowWidth || Ancho < MINIMO_ANCHO)
            //        throw _marco.MarcoFueraDeRangoException;
            //}
        }
        /// <summary>
        /// Altura del marco.
        /// </summary>
        public int Alto
        {
            get { return _marco._inferiorDerecha.Top - _marco._superiorIzquierda.Top + 1; }
            set
            {
                if (value < MINIMO_ALTURA)
                    InferiorDerecha.Top = _marco._superiorIzquierda.Top + MINIMO_ALTURA - 1;
                else
                    if (value > Console.WindowHeight)
                    InferiorDerecha.Top = Console.WindowHeight - 1;
                else
                    InferiorDerecha.Top = _marco._superiorIzquierda.Top + value - 1;
            }
        }
        /// <summary>
        /// Ancho del marco.
        /// </summary>
        public int Ancho
        {
            get { return _marco._inferiorDerecha.Left - _marco._superiorIzquierda.Left + 1; }
            set
            {
                if (value < MINIMO_ALTURA)
                    InferiorDerecha.Left = _marco._superiorIzquierda.Left + MINIMO_ANCHO - 1;
                else
                    if (value > Console.WindowHeight)
                    InferiorDerecha.Left = Console.WindowWidth - 1;
                else
                    InferiorDerecha.Left = _marco._superiorIzquierda.Left + value - 1;
            }
        }
        /// <summary>
        /// Estilo del marco (Transparente, Simple y Doble)
        /// </summary>
        public EstiloMarco EstiloMarco { get { return _marco._estiloMarco; } set { _marco._estiloMarco = value; } }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacío. Ocupa toda la ventana por defecto.
        /// </summary>
        public Menu()
        {
            _marco = new Marco();
            _titulo = "";
            _contenido = new string[] { };
            _mensaje = "";
            _colorFondo = Console.BackgroundColor;
            ColorTexto = Console.ForegroundColor;

        }
        /// <summary>
        /// Crea un menú a partir de dos esquinas, estilo, titulo, contenido y mensaje.
        /// </summary>
        /// <param name="esquinaSuperiorIzquierda">Esquina superior izquierda del marco.</param>
        /// <param name="esquinaInferiorDerecha">Esquina inferior derecha del marco.</param>
        /// <param name="estiloMarco">Estilo de la línea del marco.</param>
        /// <param name="titulo">Título del menú.</param>
        /// <param name="contenido">Contenido principal del menú.</param>
        /// <param name="mensaje">Mensaje al pié del menú.</param>
        public Menu(Coordenada esquinaSuperiorIzquierda, Coordenada esquinaInferiorDerecha, EstiloMarco estiloMarco, string titulo, string[] contenido, string mensaje)
        {

            _marco = new Marco(esquinaSuperiorIzquierda, esquinaInferiorDerecha, estiloMarco);
            if (Alto < MINIMO_ALTURA)
                Alto = MINIMO_ALTURA;
            if (Ancho < MINIMO_ANCHO)
                Ancho = MINIMO_ANCHO;
            _titulo = titulo;
            _contenido = contenido;
            _mensaje = mensaje;
            _colorFondo = Console.BackgroundColor;
            ColorTexto = Console.ForegroundColor;
        }
        /// <summary>
        /// Crea un menú a partir de su esquina superior derecha, alto, ancho, estilo del marco, título, contenido y mensaje.
        /// </summary>
        /// <param name="esquinaSuperiorIzquierda">Esquina superior izquierda del marco.</param>
        /// <param name="alto">Altura del marco.</param>
        /// <param name="ancho">Ancho del marco.</param>
        /// <param name="estiloMarco">Estilo de la línea del marco.</param>
        /// <param name="titulo">Título del menú.</param>
        /// <param name="contenido">Contenido principal del menú.</param>
        /// <param name="mensaje">Mensaje al pié del menú</param>
        public Menu(Coordenada esquinaSuperiorIzquierda, int alto, int ancho, EstiloMarco estiloMarco, string titulo, string[] contenido, string mensaje)
        {
            _marco = new Marco(esquinaSuperiorIzquierda, estiloMarco);
            Alto = alto;
            Ancho = ancho;
            _titulo = titulo;
            _contenido = contenido;
            _mensaje = mensaje;
            _colorFondo = Console.BackgroundColor;
            ColorTexto = Console.ForegroundColor;
        }
        /// <summary>
        /// Crea un menú a partir de su altura, ancho, estilo de línea del marco, titulo, contenido principal y mensaje, que empieza en la posicion (0, 0).
        /// </summary>
        /// <param name="alto">Altura del marco.</param>
        /// <param name="ancho">Ancho del marco.</param>
        /// <param name="estiloMarco">Estilo de la línea del marco.</param>
        /// <param name="titulo">Título del menú.</param>
        /// <param name="contenido">Contenido principal del menú.</param>
        /// <param name="mensaje">Mensaje al pié del menú</param>
        public Menu(int alto, int ancho, EstiloMarco estiloMarco, string titulo, string[] contenido, string mensaje)
        {
            _marco = new Marco(new Coordenada(0, 0), estiloMarco);
            Alto = alto;
            Ancho = ancho;
            _titulo = titulo;
            _contenido = contenido;
            _mensaje = mensaje;
            _colorFondo = Console.BackgroundColor;
            ColorTexto = Console.ForegroundColor;

        }
        /// <summary>
        /// Crea un menú a partir de su esquina superior derecha, alto, ancho, estilo del marco, color del marco, título, contenido y mensaje.
        /// </summary>
        /// <param name="esquinaSuperiorIzquierda">Esquina superior izquierda del marco.</param>
        /// <param name="alto">Altura del marco.</param>
        /// <param name="ancho">Ancho del marco.</param>
        /// <param name="estiloMarco">Estilo de la línea del marco.</param>
        /// <param name="colorMarco">Color de las líneas del marco.</param>
        /// <param name="titulo">Título del menú.</param>
        /// <param name="contenido">Contenido principal del menú.</param>
        /// <param name="mensaje">Mensaje al pié del menú</param>
        public Menu(Coordenada esquinaSuperiorIzquierda, int alto, int ancho, EstiloMarco estiloMarco, ConsoleColor colorMarco, string titulo, string[] contenido, string mensaje)
        {
            _marco = new Marco(esquinaSuperiorIzquierda, estiloMarco, colorMarco);
            Alto = alto;
            Ancho = ancho;
            _titulo = titulo;
            _contenido = contenido;
            _mensaje = mensaje;
            _colorFondo = Console.BackgroundColor;
            ColorTexto = Console.ForegroundColor;
        }
        /// <summary>
        /// Crea un menú a partir de su esquina superior izquierda, alto, ancho, estilo del marco, color del marco, titulo, contenido, mensaje, color de fondo y color del texto.
        /// </summary>
        /// <param name="esquinaSuperiorIzquierda">Esquina superior izquierda del marco.</param>
        /// <param name="alto">Altura del marco.</param>
        /// <param name="ancho">Ancho del marco.</param>
        /// <param name="estiloMarco">Estilo de la línea del marco.</param>
        /// <param name="colorMarco">Color de las líneas del marco.</param>
        /// <param name="titulo">Título del menú.</param>
        /// <param name="contenido">Contenido principal del menú.</param>
        /// <param name="mensaje">Mensaje al pié del menú</param>
        /// <param name="colorFondo">Color de fondo del menú.</param>
        /// <param name="colorTexto">Color de todo el texto del menú.</param>
        public Menu(Coordenada esquinaSuperiorIzquierda, int alto, int ancho, EstiloMarco estiloMarco, ConsoleColor colorMarco, string titulo, string[] contenido, string mensaje, ConsoleColor colorFondo, ConsoleColor colorTexto)
        {
            _marco = new Marco(esquinaSuperiorIzquierda, estiloMarco, colorMarco);
            Alto = alto;
            Ancho = ancho;
            _titulo = titulo;
            _contenido = contenido;
            _mensaje = mensaje;
            _colorFondo = colorFondo;
            ColorTexto = colorTexto;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="esquinaSuperiorIzquierda">Esquina superior izquierda del marco.</param>
        /// <param name="esquinaInferiorDerecha">Esquina inferior derecha del marco.</param>
        /// <param name="estiloMarco">Estilo de la línea del marco.</param>
        /// <param name="colorMarco">Color de las líneas del marco.</param>
        /// <param name="titulo">Título del menú.</param>
        /// <param name="contenido">Contenido principal del menú.</param>
        /// <param name="mensaje">Mensaje al pié del menú</param>
        public Menu(Coordenada esquinaSuperiorIzquierda, Coordenada esquinaInferiorDerecha, EstiloMarco estiloMarco, ConsoleColor colorMarco, string titulo, string[] contenido, string mensaje)
        {

            _marco = new Marco(esquinaSuperiorIzquierda, esquinaInferiorDerecha, estiloMarco, colorMarco);
            if (Alto < MINIMO_ALTURA)
                Alto = MINIMO_ALTURA;
            if (Ancho < MINIMO_ANCHO)
                Ancho = MINIMO_ANCHO;
            _titulo = titulo;
            _contenido = contenido;
            _mensaje = mensaje;
            _colorFondo = Console.BackgroundColor;
            ColorTexto = Console.ForegroundColor;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="esquinaSuperiorIzquierda">Esquina superior izquierda del marco.</param>
        /// <param name="esquinaInferiorDerecha">Esquina inferior derecha del marco.</param>
        /// <param name="estiloMarco">Estilo de la línea del marco.</param>
        /// <param name="colorMarco">Color de las líneas del marco.</param>
        /// <param name="titulo">Título del menú.</param>
        /// <param name="contenido">Contenido principal del menú.</param>
        /// <param name="mensaje">Mensaje al pié del menú</param>
        /// <param name="colorFondo">Color del fondo del menú.</param>
        /// <param name="colorTexto">Color de todo el texto del menú.</param>
        public Menu(Coordenada esquinaSuperiorIzquierda, Coordenada esquinaInferiorDerecha, EstiloMarco estiloMarco, ConsoleColor colorMarco, string titulo, string[] contenido, string mensaje, ConsoleColor colorFondo, ConsoleColor colorTexto)
        {

            _marco = new Marco(esquinaSuperiorIzquierda, esquinaInferiorDerecha, estiloMarco, colorMarco);
            if (Alto < MINIMO_ALTURA)
                Alto = MINIMO_ALTURA;
            if (Ancho < MINIMO_ANCHO)
                Ancho = MINIMO_ANCHO;
            _titulo = titulo;
            _contenido = contenido;
            _mensaje = mensaje;
            _colorFondo = colorFondo;
            ColorTexto = colorTexto;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Muestra el menú por pantalla.
        /// </summary>
        public void Mostrar()
        {
            ConsoleColor colorTextoEntrada = Console.ForegroundColor;
            ConsoleColor colorFondoEntrada = Console.BackgroundColor;
            Console.BackgroundColor = ColorFondo;
            LINEA_TITULO = SuperiorIzquierda.Top + 1;
            PRIMERA_LINEA_OPCIONES = SuperiorIzquierda.Top + 3;
            MAXIMO_OPCIONES = Alto - 6;
            LINEA_MENSAJE = InferiorDerecha.Top - 1;
            COMIENZO_LINEA = SuperiorIzquierda.Left + 1;
            LONGITUD_LINEA = Ancho - 2;
            MostrarMarco();
            MostrarTitulo();
            MostrarContenido();
            MostrarMensaje();
            Console.BackgroundColor = colorFondoEntrada;
            Console.ForegroundColor = colorTextoEntrada;
        }
        /// <summary>
        /// Mostrar marco con el número de líneas especificadas (0, 1 ó 2).
        /// </summary>
        private void MostrarMarco()
        {
            char[] marcoElegido = new char[8];
            linea = SuperiorIzquierda.Top;
            DefinirJuegoCaracteres(marcoElegido);
            ConsoleColor colorTextoEntrada = Console.ForegroundColor;
            Console.Clear();
            Console.ForegroundColor = ColorMarco;
            MostrarMarcoTitulo(marcoElegido);
            MostrarMarcoContenido(marcoElegido);
            MostrarMarcoMensaje(marcoElegido);
            Console.ForegroundColor = colorTextoEntrada;
        }

        private void DefinirJuegoCaracteres(char[] marcoElegido)
        {
            char[] marcoTransparente = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
            char[] marcoSimple = { '┌', '┐', '└', '┘', '├', '┤', '│', '─' };
            char[] marcoDoble = { '╔', '╗', '╚', '╝', '╠', '╣', '║', '═' };
            if (_marco._estiloMarco == EstiloMarco.Transparente)
                marcoTransparente.CopyTo(marcoElegido, 0);
            else if (_marco._estiloMarco == EstiloMarco.Simple)
                marcoSimple.CopyTo(marcoElegido, 0);
            else if (_marco._estiloMarco == EstiloMarco.Doble)
                marcoDoble.CopyTo(marcoElegido, 0);
        }

        private void MostrarMarcoTitulo(char[] marcoElegido)
        {
            Console.CursorTop = linea++;
            Console.CursorLeft = SuperiorIzquierda.Left;
            Console.WriteLine(marcoElegido[0].ToString().PadRight(Ancho - 1, marcoElegido[7]) + marcoElegido[1]);
            Console.CursorTop = linea++;
            Console.CursorLeft = SuperiorIzquierda.Left;
            Console.WriteLine(marcoElegido[6].ToString().PadRight(Ancho - 1) + marcoElegido[6]);
            Console.CursorTop = linea++;
            Console.CursorLeft = SuperiorIzquierda.Left;
            Console.WriteLine(marcoElegido[4].ToString().PadRight(Ancho - 1, marcoElegido[7]) + marcoElegido[5]);
        }

        private void MostrarMarcoContenido(char[] marcoElegido)
        {
            for (int i = 0; i < Alto - 6; i++)
            {
                Console.CursorTop = linea++;
                Console.CursorLeft = SuperiorIzquierda.Left;
                Console.WriteLine(marcoElegido[6].ToString().PadRight(Ancho - 1) + marcoElegido[6]);
            }
        }

        private void MostrarMarcoMensaje(char[] marcoElegido)
        {
            Console.CursorTop = linea++;
            Console.CursorLeft = SuperiorIzquierda.Left;
            Console.WriteLine(marcoElegido[4].ToString().PadRight(Ancho - 1, marcoElegido[7]) + marcoElegido[5]);
            Console.CursorTop = linea++;
            Console.CursorLeft = SuperiorIzquierda.Left;
            Console.WriteLine(marcoElegido[6].ToString().PadRight(Ancho - 1) + marcoElegido[6]);
            Console.CursorTop = linea;
            Console.CursorLeft = SuperiorIzquierda.Left;
            Console.WriteLine(marcoElegido[2].ToString().PadRight(Ancho - 1, marcoElegido[7]) + marcoElegido[3]);
            Console.CursorTop = 0;
            Console.CursorLeft = 0;
        }
        
        /// <summary>
        /// Muestra el título del menú.
        /// </summary>
        private void MostrarTitulo()
        {

            Console.CursorTop = LINEA_TITULO;
            Console.ForegroundColor = _colorTitulo;
            if (_titulo.Length > LONGITUD_LINEA)
            {
                Console.CursorLeft = COMIENZO_LINEA;
                Console.Write(_titulo.Substring(0, LONGITUD_LINEA - 3).PadRight(LONGITUD_LINEA, '.'));
            }
            else
                if (_titulo.Length != 0)
            {
                Console.CursorLeft = COMIENZO_LINEA + ((LONGITUD_LINEA - _titulo.Length) / 2);
                Console.Write(_titulo);
            }
        }
        /// <summary>
        /// Muestra el contenido principal del menú.
        /// </summary>
        private void MostrarContenido()
        {
            Console.ForegroundColor = _colorContenido;
            for (int i = 0; i < MAXIMO_OPCIONES && i < _contenido.Length; i++)
            {
                Console.CursorLeft = COMIENZO_LINEA;
                Console.CursorTop = PRIMERA_LINEA_OPCIONES + i;
                if (_contenido[i].Length > LONGITUD_LINEA)
                    Console.Write(_contenido[i].Substring(0, LONGITUD_LINEA - 3).PadRight(LONGITUD_LINEA, '.'));
                else
                    Console.Write(_contenido[i]);
            }
        }
        /// <summary>
        /// Muestra el mensaje al pie del menú.
        /// </summary>
        private void MostrarMensaje()
        {
            Console.ForegroundColor = _colorMensaje;
            Console.CursorLeft = COMIENZO_LINEA;
            Console.CursorTop = LINEA_MENSAJE;
            if (_mensaje.Length > LONGITUD_LINEA)
            {
                Console.Write(_mensaje.Substring(0, LONGITUD_LINEA - 4).PadRight(LONGITUD_LINEA - 1, '.'));
            }
            else
                if (_mensaje.Length != 0)
            {
                Console.Write(_mensaje);

            }
        }
        #endregion
    }
    

}
