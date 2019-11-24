using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cichelli
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "CALLIOPE", "CLIO", "ERATO", "EUTERPE", "MELPOMENE", "POLYHYMNIA", "TERPSICHORE", "THALIA", "URANIA" };
            for (int i = 0; i < words.Length; i++)
            {
                new Cichelli(Cichelli.GetFirstLetter(words[i]));
                new Cichelli(Cichelli.GetLastLetter(words[i]));
            }
            Cichelli.SelectionSort();
            //

            // DRAW WORD TABLE
            for (int i = 0; i < words.Length; i++)
            {
                Console.SetCursorPosition(5, i + 3);
                Console.WriteLine("| {0,14} | ({1,2})", words[i], Cichelli.Mod(Cichelli.h(words[i]), words.Length));
            }

            for (int i = 0; i < Cichelli.list.Count; i++)
            {
                Console.SetCursorPosition(40, i + 3);
                Console.WriteLine("{0} | {1}", Cichelli.list[i].letter, Cichelli.list[i].gValue);
            }

            // DRAW CICHELLI TABLE
            for (int i = 0; i < words.Length; i++)
            {
                Console.SetCursorPosition(65, i + 3);
                Console.WriteLine("{0,2} | {1,-14}|", i, words[i]);
            }
            Console.WriteLine("\n\n\n");





            //new Cichelli
            /*string jellyebanci =  "GOKSELKUCUKSAHINARDAFAGGOTTHICCBOIANAKINDVANKVALKERXDMADAFAKA";
            foreach (var item in jellyebanci)
            {
                new Cichelli(item);
            }
            //Cichelli.InsertionSort();
            Cichelli.SelectionSort();
            foreach (var item in Cichelli.list)
            {
                Console.WriteLine(item.ToString());
            }*/
        }
    }
}
