using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu;
            menu = new Menu(new Coordenada(200, 15), new Coordenada(5, 5), EstiloMarco.Doble, "Menú", new string[] { "hola", "primo", "sgfsdhsdgshsdf", "hola", "primo", "sgfsdhsdgshsdf", "hola", "primo", "sgfsdhsdgshsdf", "hola", "primo", "sgfsdhsdgshsdf" }, "hola ayayayayayayayaayyaayayyaayyyaay");
            menu.Mostrar();

            Console.ReadKey();
            //menu.ColorMarco = ConsoleColor.Red;
            //menu.ColorTexto = ConsoleColor.DarkCyan;
            //menu.Ancho = 20;
            //menu.Mostrar();
            //Console.ReadKey();
            //menu.ColorTitulo = ConsoleColor.DarkGreen;
            //menu.ColorFondo = ConsoleColor.Gray;
            //menu.ColorContenido = ConsoleColor.DarkMagenta;
            //menu.ColorMensaje = ConsoleColor.DarkCyan;
            //menu.Mostrar();
            //Console.ReadKey();
            menu = new Menu(10, 30, EstiloMarco.Doble, "MENU", new string[] { "hola", "ke", "ase" }, "Cuentame lo ke ase!!");
            menu.Mostrar();
            Console.ReadKey();
        }
    }
}