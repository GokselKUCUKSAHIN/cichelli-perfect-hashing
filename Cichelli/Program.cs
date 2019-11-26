using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cichelli
{
    class Program
    {
        //static string[] words = { "CALLIOPE", "CLIO", "ERATO", "EUTERPE", "MELPOMENE", "POLYHYMNIA", "TERPSICHORE", "THALIA", "URANIA" };
        //static string[] words = { "KAAN", "GOKSEL", "MEHMET", "ARDA", "KONTRA", "ATAK", "MADA" };
        //static string[] words = { "GNAT", "RAT", "CAT", "ANT", "DOG", "CHIMP", "TOAD" };// , "HORSE", "ELEPHANT", "FISH" ,"RABBIT"};
        static string[] words = { "GNAT", "RAT", "CAT", "ANT", "DOG", "CHIMP", "TOAD", "HORSE", "ELEPHANT", "FISH", "RABBIT" };
        //static string[] words = { "ARDA","BERKE", "EMRE", "FURKAN", "GOKSEL","ARKADASLAR","CATISIN"};
        static string[] placed = new string[words.Length];

        static void Main(string[] args)
        {
            Array.Sort(words);

            for (int i = 0; i < words.Length; i++)
            {
                new Cichelli(Cichelli.GetFirstLetter(words[i]));
                new Cichelli(Cichelli.GetLastLetter(words[i]));
            }
            Cichelli.SelectionSort();
            ClearPlaced();
            //
            for (int i = 0; i < words.Length; i++)
            {
                int h = Cichelli.Mod(Cichelli.h(words[i]), words.Length);
                if (placed[h].Equals(String.Empty))
                {
                    // it's empty
                    placed[h] = words[i];
                }
                else
                {
                    //
                    // BRUTE FORCE BTW
                    //
                    /*NEED TO BE UPGRADE*/
                    Cichelli.list[Cichelli.list.Count - 1].gValue++; // last index of list
                    for (int j = Cichelli.list.Count - 1; j >= 0; j--) // for last index to 1
                    {
                        if (Cichelli.list[j].gValue > Cichelli.MAX_G_VALUE)
                        {
                            // OverFlow!
                            Cichelli.list[j].gValue = 0; // RESET
                            if (j > 0) // For avoid index of range exception
                            {
                                Cichelli.list[j - 1].gValue++; // increase prev index by 1
                                if (Cichelli.list[0].gValue == Cichelli.MAX_G_VALUE) // if 0th index max value then there is no solution at all
                                {
                                    break; // break it down
                                }
                            }
                        }
                    }
                    //
                    ClearPlaced();
                    i = -1;
                }
                // One Bye ONE MODE
                //draw();
                //Console.ReadKey();
            }
            draw();
            Console.WriteLine("DONE!!!");
            Console.ReadKey();
        }
        static void ClearPlaced()
        {
            for (int i = 0; i < placed.Length; i++)
            {
                placed[i] = String.Empty; //Empty String
            }
        }

        static void draw()
        {
            Console.Clear();
            // DRAW WORD TABLE
            for (int i = 0; i < words.Length; i++)
            {
                Console.SetCursorPosition(3, i + 3);
                Console.WriteLine("| {0,14} | ({2,2} + {3,2} + {4,2}) mod({5,2}) = ({1,2})", words[i], Cichelli.Mod(Cichelli.h(words[i]), words.Length),
                    Cichelli.g(Cichelli.GetFirstLetter(words[i])), Cichelli.g(Cichelli.GetLastLetter(words[i])), words[i].Length, words.Length);
            }

            for (int i = 0; i < Cichelli.list.Count; i++)
            {
                Console.SetCursorPosition(62, i + 3);
                Console.WriteLine("{0}({2,2}) | {1}", Cichelli.list[i].letter, Cichelli.list[i].gValue, Cichelli.list[i].occurrences);
            }

            // DRAW CICHELLI TABLE
            for (int i = 0; i < words.Length; i++)
            {
                Console.SetCursorPosition(80, i + 3);
                Console.WriteLine("{0,2} | {1,-14}|", i, placed[i]);
            }
            Console.WriteLine("\n\n\n\n");
        }
    }
}