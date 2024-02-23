using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System;
using System.IO;
namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<tabor> taborok = new List<tabor>();

            //1. feladat
            StreamReader sr = new StreamReader("taborok.txt");
            while (!sr.EndOfStream)
            {
                taborok.Add(new tabor(sr.ReadLine()));
            }
            sr.Close();


            //2. feladat
            var taborokSzama = taborok.Count;
            var elsoTaborRogzitve = taborok[0].tema;
            var utolsoTaborRogzitve = taborok[taborokSzama - 1].tema;
            Console.WriteLine("2.feladat");
            Console.WriteLine($"Az adatsorok szama: {taborokSzama}");
            Console.WriteLine($"Az elosszor rogzitett tabor temaja: {elsoTaborRogzitve}");
            Console.WriteLine($"Az utoljara rogzitett tabor temaja: {utolsoTaborRogzitve}");

            //3. feladat
            var zeneiTaborokKezdese = taborok.Where(x => x.tema == "zenei").Select(x => x.taborkezdesH).ToList();
            var zeneiTaborokKezdeseN = taborok.Where(x => x.tema == "zenei").Select(x => x.taborkezdesN).ToList();
            Console.WriteLine("3.feladat");
            for (int i = 0; i < zeneiTaborokKezdese.Count; i++)
            {
                Console.WriteLine($"zenei tabor kezdodott: {zeneiTaborokKezdese[i]}. hó {zeneiTaborokKezdeseN[i]}. napján");
            }

            //4. feladat
            var legtobbBetujel = taborok.Max(x => x.betujelek.Length);
            var legtobbBetujelTabor = taborok.Where(x => x.betujelek.Length == legtobbBetujel).Select(x => x.tema).First();
            var legtobbBetujelTaborKezdese = taborok.Where(x => x.betujelek.Length == legtobbBetujel).Select(x => x.taborkezdesH).First();
            var legtobbBetujelTaborKezdeseN = taborok.Where(x => x.betujelek.Length == legtobbBetujel).Select(x => x.taborkezdesN).First();
            Console.WriteLine("4.feladat");
            Console.WriteLine($"{legtobbBetujelTaborKezdese} {legtobbBetujelTaborKezdeseN} {legtobbBetujelTabor}");


            //5. feladat
            //sorszam(8, 31);


            //6. feladat
            Console.WriteLine("6.feladat");
            Console.Write("hó: ");
            var h = Convert.ToInt32(Console.ReadLine());
            Console.Write("nap: ");
            var n = Convert.ToInt32(Console.ReadLine());
            var taborokSzamaEkkor = taborok.Where(x => x.taborkezdesH <= h && x.taborvegeH >= h && x.taborkezdesN <= n && x.taborvegeN >= n).Count();
            Console.WriteLine($"Ekkor {taborokSzamaEkkor} tabor zajlik");

            //7. feladat
            Console.WriteLine("7.feladat");
            Console.Write("Adja meg egy tanuló betűjelét: ");
            var betujel = Console.ReadLine();
            var hanyTaborban = taborok.Where(x => x.betujelek.Contains(betujel)).Count();
            var temp = hanyTaborban;
            StreamWriter sw = new StreamWriter("egytanulo.txt");
            foreach (var tabor in taborok.OrderBy(x => x.taborkezdesH).ThenBy(x => x.taborkezdesN))
            {
                if (tabor.betujelek.Contains(betujel))
                {
                    sw.WriteLine($"{tabor.taborkezdesH}.{tabor.taborkezdesN}-{tabor.taborvegeH}.{tabor.taborvegeN} {tabor.tema}");
                }
            }


            sw.Close();


            var egytanulo = new List<(int, int)>();
            var egytanuloTema = new List<string>();
            StreamReader sr2 = new StreamReader("egytanulo.txt");
            while (!sr2.EndOfStream)
            {
                var line = sr2.ReadLine();
                var parts = line.Split(' ');
                var dateParts = parts[0].Split('-');
                var start = dateParts[0].Split('.');
                var end = dateParts[1].Split('.');
                egytanulo.Add((Convert.ToInt32(start[0]), Convert.ToInt32(start[1])));
                egytanulo.Add((Convert.ToInt32(end[0]), Convert.ToInt32(end[1])));
                egytanuloTema.Add(parts[1]);
            }
            sr2.Close();
            var egytanuloSzama = egytanulo.Count;
            for (int i = 0; i < egytanuloSzama; i += 2)
            {
                for (int j = 0; j < egytanuloSzama; j += 2)
                {
                    if (i != j)
                    {
                        if (egytanulo[i].Item1 <= egytanulo[j].Item1 && egytanulo[i].Item2 >= egytanulo[j].Item1)
                        {
                            if (egytanuloTema[i / 2] == egytanuloTema[j / 2])
                            {
                                temp--;
                            }
                        }
                    }
                }
            }
            if (temp == hanyTaborban)
            {
                Console.WriteLine("Elemehet mindegyik taborba");
            }
            else
            {
                Console.WriteLine("Nem mehet el mindegyik taborba");
            }










            Console.ReadKey();
        }

        public static int sorszam(int honap, int nap)
        {
            string[] honapok = new string[] { "junius", "julius", "augusztus" };
            int[] napok = new int[] { 15, 31, 31 };

            int napszam = 0;
            for (int i = 0; i < honap - 6; i++)
            {
                napszam += napok[i];
            }
            napszam += nap;
            
            return napszam;


        }
    }
}