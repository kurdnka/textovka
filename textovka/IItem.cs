using System;

namespace textovka
{
	public interface IItem
	{
		ItemStatus status { get; }

		string name { get; }

		string description { get; }

		int price { get; }
		float weight { get; }

	}
}

