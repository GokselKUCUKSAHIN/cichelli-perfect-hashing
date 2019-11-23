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
            //new Cichelli

            string jellyebanci =  "GOKSEL KUCUKSAHIN ARDA FAGGOT THICC BOI ANAKIN DVANKVALKER XD MADA FAKA";
            foreach (var item in jellyebanci)
            {
                new Cichelli(item);
            }
            Cichelli.InsertionSort();
            foreach (var item in Cichelli.list)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
