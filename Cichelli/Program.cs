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
        static string[] words = { "GNAT", "RAT", "CAT", "ANT", "DOG", "CHIMP", "TOAD", "HORSE", "ELEPHANT", "FISH" };
        //static string[] words = { "ARDA","BERKE", "EMRE", "FURKAN", "GOKSEL","ARKADASLAR","CATISIN"};
        static string[] placed = new string[words.Length];

        static void Main(string[] args)
        {

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
                if (placed[h].Equals(" "))
                {
                    // it's empty
                    placed[h] = words[i];
                }
                else
                {
                    Cichelli.list[Cichelli.list.Count - 1].gValue++;
                    for (int j = Cichelli.list.Count - 1; j >= 0; j--)
                    {
                        if (Cichelli.list[j].gValue > Cichelli.MAX_G_VALUE)
                        {
                            Cichelli.list[j].gValue = 0;
                            if (j > 0)
                            {
                                Cichelli.list[j - 1].gValue++;
                                if (Cichelli.list[0].gValue == Cichelli.MAX_G_VALUE)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    ClearPlaced();
                    i = -1;
                }

            }
            draw();
            Console.WriteLine("DONE!!!");
            Console.ReadKey();
        }
        static void ClearPlaced()
        {
            for (int i = 0; i < placed.Length; i++)
            {
                placed[i] = " ";
            }
        }

        static void draw()
        {
            Console.Clear();
            // DRAW WORD TABLE
            for (int i = 0; i < words.Length; i++)
            {
                Console.SetCursorPosition(5, i + 3);
                Console.WriteLine("| {0,14} | ({1,2})", words[i], Cichelli.Mod(Cichelli.h(words[i]), words.Length));
            }

            for (int i = 0; i < Cichelli.list.Count; i++)
            {
                Console.SetCursorPosition(40, i + 3);
                Console.WriteLine("{0}({2,2}) | {1}", Cichelli.list[i].letter, Cichelli.list[i].gValue, Cichelli.list[i].occurrences);
            }

            // DRAW CICHELLI TABLE
            for (int i = 0; i < words.Length; i++)
            {
                Console.SetCursorPosition(65, i + 3);
                Console.WriteLine("{0,2} | {1,-14}|", i, placed[i]);
            }
            Console.WriteLine("\n\n\n\n");
        }
    }
}


/*string word = words[i];
int flo = Cichelli.FirstLetterOccurrence(word);
int llo = Cichelli.LastLetterOccurrence(word);
if (flo < llo)
{
    // first letter
    if (!Cichelli.IncreaseFirstLetterG(word))
    {
    }
}*/

/*
 * for (int i = 0; i < words.Length; i++)
        {
            int h = Cichelli.Mod(Cichelli.h(words[i]), words.Length);
            if (placed[h].Equals(" "))
            {
                // it's empty
                placed[h] = words[i];
                if (i == issueIndex)
                {
                    letterIndex++; //= Cichelli.list.Count - 1; //++
                    issueIndex = -1;
                }
            }
            else
            {
                if (Cichelli.list[letterIndex].gValue < 4)
                {
                    Cichelli.list[letterIndex].gValue++;
                }
                else
                {
                    issueIndex = i - 1;
                    Cichelli.ClearGValues(letterIndex);
                    letterIndex--;
                    if (Cichelli.list[letterIndex].gValue < 4)
                    {
                        Cichelli.list[letterIndex].gValue++;
                    }
                    else
                    {
                        letterIndex--;
                    }
                }
                ClearPlaced();
                i = -1;
            }
            draw();

            Console.WriteLine("Issue: " + issueIndex);
            Console.WriteLine("Letter Index: " + letterIndex);
            Console.ReadKey();
        }
*/
