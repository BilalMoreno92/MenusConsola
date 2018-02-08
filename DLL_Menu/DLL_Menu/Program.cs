﻿using System;
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

            Menu menu = new Menu(new Coordenada(5, 5), new Coordenada(20, 15), EstiloMarco.Doble, "Menú", new string[] { "hola", "primo", "sgfsdhsdgshsdf", "hola", "primo", "sgfsdhsdgshsdf", "hola", "primo", "sgfsdhsdgshsdf", "hola", "primo", "sgfsdhsdgshsdf" }, "hola ayayayayayayayaayyaayayyaayyyaay");
            menu.Mostrar();
          
            Console.ReadKey();
            menu.Marco.ColorMarco = ConsoleColor.Red;
            menu.ColorTexto = ConsoleColor.DarkCyan;
            menu.Marco.Ancho = 20;
            menu.Mostrar();
            Console.ReadKey();
            menu.ColorTitulo = ConsoleColor.DarkGreen;
            menu.ColorFondo = ConsoleColor.Gray;
            menu.ColorContenido = ConsoleColor.DarkMagenta;
            menu.ColorMensaje = ConsoleColor.DarkCyan;
            menu.Mostrar();
            Console.ReadKey();
        }
    }
}