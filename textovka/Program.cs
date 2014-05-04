using System;

namespace textovka
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Ahoj, Lucie :-)");

			World world = new World (new DateTime(2020,4,24,8,12,13));
			Console.WriteLine ("Dnes je: "+world.time.Date.ToString("d. M. yyyy"));
			Console.WriteLine ("Aktuální čas: " + world.time.TimeOfDay.ToString("hh':'mm"));
			Console.WriteLine ("Aktuální teplota: " + world.weather.ToString ("F1") + " °C, Provoz na silnicích: " + world.traffic.ToString("P0"));
			Console.WriteLine ("");
			Console.WriteLine ("Máš 2 nové maily.");
			Console.WriteLine ("");
			Console.WriteLine ("@doma> možnosti");
			Console.WriteLine ("jdi, inventář, použij, čekej");
			Console.WriteLine ("@doma> inventář");
			Console.WriteLine ("mobil, notebook, peníze");
			Console.Write ("@doma> ");

			BaseItem baseitem = new BaseItem ();
		}

	}
}
