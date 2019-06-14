using System;

namespace HP_PLConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Menu m = new Menu();
            m.menu();
        }
    }
}
