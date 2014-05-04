using System;
using System.Collections.Generic;

namespace textovka
{
	public class Lucka
	{
		private Location location;
		private List<IItem> Inventory { get; set; }
		private TimeSpan timeAwake;

		public Lucka ()
		{
			Inventory = new List<IItem>();
			Inventory.Add(new BaseItem("dummy 2"));
		}

		public void Go(int roomId)
		{
		}

		public void Go(string direction)
		{
		}

		public void Use (string item)
		{

		}

		public void TalkTo (string npc)
		{
		}
	}
}

