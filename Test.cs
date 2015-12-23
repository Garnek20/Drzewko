using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace drzewko
{
    class Test
    {
        public void testDrzewa()
        {
            Drzewo<int, int> drzewo = new Drzewo<int, int>();

            Console.WriteLine("A:");
            int A = int.Parse(Console.ReadLine());

            Console.WriteLine("M:");
            int M = int.Parse(Console.ReadLine());

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Random random = new Random();
            int los;

            for (int i = 0; i < A; i++)
            {
                los = random.Next(1, M); //zmienna okreslajaca klucz
                drzewo.dodaj(i, los);
            }

            Console.WriteLine("B:");
            int B = int.Parse(Console.ReadLine());

            Console.WriteLine("N:");
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < B; i++)
            {
                los = random.Next(1, N); //zmienna okreslajaca klucz
                drzewo.dodaj(i, los);
                drzewo.usun();
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadLine();
        }

        public void testListy()
        {
            PosortowanaLista<int, int> lista = new PosortowanaLista<int, int>();

            Console.WriteLine("A:");
            int A = int.Parse(Console.ReadLine());

            Console.WriteLine("M:");
            int M = int.Parse(Console.ReadLine());

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Random random = new Random();
            int los;

            for (int i = 0; i < A; i++)
            {
                los = random.Next(1, M); //zmienna okreslajaca klucz
                lista.dodaj(i, los);
            }

            Console.WriteLine("B:");
            int B = int.Parse(Console.ReadLine());

            Console.WriteLine("N:");
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < B; i++)
            {
                los = random.Next(1, N); //zmienna okreslajaca klucz
                lista.dodaj(i, los);
                lista.usun();
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadLine();
        } 
        }
}
