using RE_example.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE_example
{
    class Program
    {
        static void HR()
        {
            Console.WriteLine("\n\t------\n");
        }

        static void H1(string heading)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n\t{heading.ToUpper()}\n");
            Console.ResetColor();
        }

        static Random r = new Random();

        static void Main(string[] args)
        {
            GameLogic gl = new GameLogic();
            gl.GenerateEnemies();

            H1("enemies from list to array, using foreach loop");

            foreach (var item in gl.GetEnemiesToArray())
                Console.WriteLine(item);

            H1("sending 20 random damages to all enemies, watching event result");

            for (int i = 0; i < 20; i++)
            {
                foreach (IZombie item in gl.Enemies)
                {
                    item.TakeDamage(r.Next(1,45));
                }
            }

        }
    }
}
