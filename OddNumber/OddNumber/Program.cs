using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OddNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.  Check if number is a prime
            //2.  Run a counter keeping track of numbers

            int primeCount = 1000;
            int primeSum;
            bool isPrime;

            for (int i = 0; i <= primeCount; i++)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
