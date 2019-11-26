using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cichelli
{
    class Cichelli
    {
        public static List<Cichelli> list = new List<Cichelli>();
        //
        public static readonly int MAX_G_VALUE = 4; // Maximum possible G value
        public char letter;         // body of cichelli
        public int gValue = 0;      // default value
        public int occurrences = 1; // default value
                                    //

        public Cichelli(char letter)
        {
            this.letter = letter;
            //
            // Eğer önceden varsa üzerine ekle
            // Eğer ilk defa oluyorsa da yeni ekle 0 olarak.
            //
            int pid = FindCichelli(letter);
            if (pid != -1)
            {
                // Already in a list
                list[pid].occurrences++;
            }
            else
            {
                // First member of this letter
                list.Add(this);
            }
        }


        //
        // STATIC
        //

        public static int h(string word)
        {
            int size = word.Length;
            int fLetter = g(GetFirstLetter(word));
            int lLatter = g(GetLastLetter(word));
            return size + fLetter + lLatter;
        }

        public static int g(char letter)
        {
            return list[FindCichelli(letter)].gValue;
        }

        public static void ClearGValues(int index)
        {
            for (int i = index; i < list.Count; i++)
            {
                list[i].gValue = 0;
            }
        }

        public static int GetOccurrence(char letter)
        {
            return list[FindCichelli(letter)].occurrences;
        }

        public static int FirstLetterOccurrence(string word)
        {
            return GetOccurrence(GetFirstLetter(word));
        }

        public static int LastLetterOccurrence(string word)
        {
            return GetOccurrence(GetLastLetter(word));
        }

        public static bool IncreaseFirstLetterG(string word)
        {
            char letter = GetFirstLetter(word);
            int index = FindCichelli(letter);
            if (list[index].gValue < 4)
            {
                list[index].gValue++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IncreaseLastLetterG(string word)
        {
            char letter = GetLastLetter(word);
            int index = FindCichelli(letter);
            if (list[index].gValue < 4)
            {
                list[index].gValue++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static char GetFirstLetter(string word)
        {
            if (word != String.Empty)
            {
                return word[0];
            }
            else
            {
                return '~';
            }
        }

        public static char GetLastLetter(string word)
        {
            if (word != String.Empty)
            {
                return word[word.Length - 1];
            }
            else
            {
                return '~';
            }
        }

        public static int Mod(int number, int mod)
        {
            return number % mod;
        }

        public static void InsertionSort()
        {
            // Insertion Sort
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (list[j - 1].occurrences > list[i].occurrences)
                    {
                        Cichelli temp = list[j - 1];
                        list[j - 1] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }

        public static void SelectionSort()
        {
            // Selection Sort
            int min = -1;
            for (int i = 0; i < list.Count; i++)
            {
                min = list[i].occurrences;
                int index = -1;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j].occurrences > min)
                    {
                        min = list[j].occurrences;
                        index = j;
                    }
                }
                if (index != -1)
                {
                    Cichelli temp = list[index];
                    list[index] = list[i];
                    list[i] = temp;
                }
            }
        }

        private static int FindCichelli(char letter)
        {
            // Linear Search
            for (int i = 0; i < list.Count; i++)
            {
                Cichelli temp = list[i];
                if (temp.letter.Equals(letter))
                {
                    // Found
                    return i;
                }
            }
            return -1;
        }

        public override string ToString()
        {
            return String.Format("{0} {1,2} {2,2}", letter, occurrences, gValue);
        }
    }
}