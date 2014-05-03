using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace textovka
{
	public struct DayMonth
	{
		public int day;
		public int month;

		public static DayMonth ToDayMonth(DateTime t)
		{
			return new DayMonth { day = t.Day, month = t.Month };
		}
	}

	public class World
	{
		public DateTime time;
		public double weather;
		public double traffic;
		List<DayMonth> holidays;

		public World (DateTime t, double w=-100.0)
		{
			time = t;
			if (w == -100.0)
				UpdateWeather ();
			else
				weather = w;
			LoadHolidays ();
			UpdateTraffic ();
		}

		public void LoadHolidays ()
		{
			holidays = new List<DayMonth> ();

			XDocument xhol = XDocument.Load("world/holidays.xml");

			foreach (XElement m in xhol.Elements()) {
				foreach (XElement d in m.Elements()) {
					holidays.Add (new DayMonth{ day = Convert.ToByte(d.Attribute("num").Value), month = Convert.ToByte(m.Attribute("num").Value) });
				}
			}
		}

		public void UpdateWeather()
		{
			Random r = new Random ();
			weather = Math.Sin ((time.Month - 1) / 12.0 * Math.PI) * 40.0 - 20 + 10*Math.Sin(time.Hour/24*Math.PI)  + (r.NextDouble () - 0.5) * 10;
		}

		public void AddToTime(TimeSpan dt)
		{
			time += dt;
			UpdateWeather ();
			UpdateTraffic ();
		}

		public void UpdateTraffic()
		{
			if (holidays.Contains (DayMonth.ToDayMonth (time)) || (int)time.DayOfWeek > 5)
				traffic = 0.2;
			else if ((int) time.DayOfWeek % 4 == 1)
				traffic = 0.7;
			else
				traffic = 0.6;
			double x = time.Hour;
			double y = 0.2 - 0.8*(Math.Pow((Math.Cos ((x - 1) / 24.0 * Math.PI)), 6.0) - 
				0.5 * Math.Pow(Math.Cos ((x - 1) / 24.0 * Math.PI), 4.0));
			traffic += y;
		}
	}
}
	