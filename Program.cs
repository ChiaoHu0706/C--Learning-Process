using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace FakeRandom
{
    internal class Program
    {
        static void Main(string[] args)
        {

            FakeRandom RN = new FakeRandom();
            Random random= new Random();
            Console.WriteLine("How many do you want generate Nunber?");
            int time =int.Parse(Console.ReadLine());
            Console.WriteLine("Please input Min Number :　");
            int min = int.Parse(Console.ReadLine()); 
            Console.WriteLine("Please input Max Number : ");
            int max = int.Parse(Console.ReadLine());
            for (int i = 1; i <=time; i++)
            {
                long X= RN.Next(min,max+1);
                int Y = random.Next(min, max+1);
                Console.WriteLine(i+". " + X +"         Origin C# Random function generate Number　:　"+ Y );
            }
            Console.ReadKey();
        }
    }
    public class FakeRandom
    {
        private long a = 1664525;
        private long c = 1013904223;
        private long m = (long)Math.Pow(2, 31);
        private long seed;

        public FakeRandom()
        {
            seed = DateTime.Now.Ticks % m;
        }

        public FakeRandom(long seed)
        {
            seed = seed % m;
        }

        public int Next(int min, int max)
        {
            seed = (a * seed + c) % m;
            double normal = (double)seed / (m - 1);
            int value = (int)Math.Round((max - min) * normal + min);
            return value;
        }
    }
    
}
