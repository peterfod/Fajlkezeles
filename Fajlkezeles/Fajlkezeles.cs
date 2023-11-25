using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fajlkezeles
{
	class Ber
	{
		public string nev { get; private set; }
		public string neme { get; private set; }
		public string reszleg { get; private set; }
		public string belepes { get; private set; }
		public int ber { get; private set; }

		public Ber(string sor)
		{
			string[] reszek = sor.Split(';');
			nev = reszek[0];
			neme = reszek[1];
			reszleg = reszek[2];
			belepes = reszek[3];
			ber = int.Parse(reszek[4]);
		}
	}
	class Fajlkezeles
	{
		static void Main(string[] args)
		{
			StreamReader sr = new StreamReader("../../berek2020.txt", Encoding.UTF8);
			List<Ber> lista = new List<Ber>();

			string elsosor = sr.ReadLine();

			while (!sr.EndOfStream)
			{
				Ber sor = new Ber(sr.ReadLine());
				lista.Add(sor);
			}
			sr.Close();

			/*			//Osztály nélkül:
						StreamReader be = new StreamReader("../../berek2020.txt");
						List<string[]> berek = new List<string[]>();
						string line;
						string[] reszek;
						while (!be.EndOfStream)
						{
							line = be.ReadLine();
							reszek = line.Split(';');
							berek.Add(reszek);
						}
						be.Close();

						for (int i = 0; i < berek.Count; i++)
						{
							Console.WriteLine(berek[i][0] + " " + berek[i][1]);
						}*/

			//3. feladat
			Console.WriteLine($"3. feladat: Dolgozók száma: {lista.Count} fő");

			var asztalosok = from a in lista
							 where a.reszleg == "asztalosműhely"
							 select a;

			foreach (var item in asztalosok)
			{
				Console.WriteLine(item.nev + " " + item.reszleg);

			}

			//**************** File-ba írás **********************
			//StreamWriter sw = new StreamWriter(@"E:\Temp\kiir.txt", append: true);
			//StreamWriter sw = new StreamWriter("../../asztalos2020.txt", false, Encoding.UTF8); //append false
			StreamWriter sw = new StreamWriter("../../asztalos2020.txt");

			sw.WriteLine(elsosor);
			foreach (var item in asztalosok)
			{
				sw.WriteLine($"{item.nev};{item.neme};{item.reszleg};{item.belepes};{item.ber}");

			}
			//sw.Flush();
			sw.Close();
			Console.WriteLine("Az asztalosok száma: " + asztalosok.Count());
			Console.ReadKey();
		}
	}
}
