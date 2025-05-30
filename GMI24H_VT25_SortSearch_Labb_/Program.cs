﻿using AlgorithmLib;
using System.Diagnostics;


namespace GMI24H_VT25_SortSearch_Labb_
{

    internal class Program
    {
        static void Main(string[] args)
        {
            //Här är kod som kan användas om man vill jobba med dataströmmar (som ligger i Generator-katalogen och skapas som ström utifrån en given seed). 
            const int numberOfPosts = 1000;
            const int seed = 123;
            int[] intArr = new[] { 9, 7, 10, 3, 2 };
            int fakeIndex =  numberOfPosts - 1;
            var generator = new RandomLogGenerator();
            var logs = generator.GenerateLogs(numberOfPosts, seed).ToList();


            //Skriver ut de fem första posterna i listan med LogEntry-typer. 
            Console.WriteLine("förhandsvisning av loggdata:");
            foreach (var entry in logs.Take(5))
            {
                Console.WriteLine(entry);
            }

            //Eftersom metoderna i SortingManager och SearchingManager-klasserna inte är statiska så behöver vi instansiera objekt av dessa klasser.
            //Eftersom vi gjort våra Sorting- och SearchingManager-klasserna generiska (<T>) behöver vi även ange vilken typ av data det
            //är som vi vill sortera eller söka efter. Vi anger datatyp i "diamanten" <>.
            var sorter = new SortingManager<DateTime>();
            var sorter2 = new SortingManager<string>();
            var searcher = new SearchingManager<string>();
            var testSorter = new SortingManager<int>();

            //Välj vilka data som ska plockas ut ur loggarna och jämföras. T.ex. Int eller strängar. Här behöver
            //vi tänka på att välja samma datatyp som vi vill köra våra algoritmer på, dvs. de vi bestämde oss för
            //när vi instansierade SortingManager och SearchingManager. I det här exemplet är det strängar.
            //Därför skapar vi en lista av strängar dit vi kan spara våra ip-adresser.
            //Vi använder LINQ för att selektera ut ip-adress-propertyn från varje enskilt logentry-post i logs-listan. 
            
            List<DateTime> timestamps = logs.Select(entry => entry.Timestamp).ToList();
            List<string> ipAdresses = logs.Select(entry => entry.IpAddress).ToList();

            string testIp = "999.999.999.999";
            
            List<DateTime> sortedTimestamps = new List<DateTime>(timestamps);
            ipAdresses[fakeIndex] = testIp;
            sorter2.MergeSort(ipAdresses);

            int index = 1; 
            
            
            //Console.WriteLine(index);
            
            //Console.WriteLine(ipAdresses[index]);


            //Console.ReadKey();
            
            Console.WriteLine($"Totalt antal rader inlästa: {logs.Count}");
            TimeSpan avgTime = new TimeSpan(0);
            //sorter.QuickSort(timestamps, 0, timestamps.Count - 1 );
            int checkIndex = 0;
            
            for (int i = 0; i < 10000; i++)
            {

              Console.WriteLine($"Processing iteration {i + 1}/100 ({i + 1}% complete)");
              Stopwatch sw = Stopwatch.StartNew();
              index = searcher.LasVegasSearch(ipAdresses, testIp);
              sw.Stop();
              
              
              TimeSpan elapsedTime = sw.Elapsed;
              avgTime += elapsedTime;
              
              if (ipAdresses[index] != testIp)
              {
                  checkIndex++;
              }
              
             
                
              //Console.WriteLine($"QuickSort: {elapsedTime.TotalMilliseconds} ms");
              Console.Clear();
            }
            
            Console.WriteLine((avgTime.TotalMilliseconds/100) + " ms");
            Console.WriteLine($"Antal missar: {checkIndex}");
            Console.WriteLine((index));
            
            //testSorter.MergeSort(intArr);
            //sorter.MergeSort(timestamps);
            
            
            //Console.WriteLine("förhandsvisning av sorterad data:");
            //foreach (var i in intArr.Take(5))
            //{
            //    Console.WriteLine(i);
            //}
            
            Console.WriteLine("förhandsvisning av sorterad data:");
            foreach (var timestamp in timestamps.Take(5))
            {
                Console.WriteLine(timestamp);
            }
            
        }
    }
}
