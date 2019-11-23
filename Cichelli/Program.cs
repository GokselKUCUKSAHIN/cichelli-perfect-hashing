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

            string jellyebanci =  "GOKSELKUCUKSAHINARDAFAGGOTTHICCBOIANAKINDVANKVALKERXDMADAFAKA";
            foreach (var item in jellyebanci)
            {
                new Cichelli(item);
            }
            //Cichelli.InsertionSort();
            Cichelli.SelectionSort();
            foreach (var item in Cichelli.list)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
