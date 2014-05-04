using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.IO;

namespace textovka
{
	public class BaseItem : IItem
	{
		#region Field Region
		public ItemStatus status { get; private set; }

		public string name { get; protected set;}

		public string description { get; protected set;}

		public int price { get; protected set;}
		public float weight { get; protected set; }
		#endregion

		public XmlSchema GetSchema()
		{
			return null;
		}

		public BaseItem (string name)
		{
			XmlSerializer deserializer = new XmlSerializer (typeof(BaseItem));
			TextReader textReader = new StreamReader ("Items/"+name+".xml");
			BaseItem item = (BaseItem)deserializer.Deserialize (textReader);
			textReader.Close ();
			this.name = item.name;
			this.price = item.price;
			this.status = item.status;
			this.weight = item.weight;
			this.description = item.description;
		}
			
		public BaseItem ()
		{
			status = ItemStatus.OK;
			name = "dummy";
			description = "Dummy description.";
			price = 0;
			weight = 0;
		}

		~BaseItem()
		{
			XmlTextWriter textWriter = new XmlTextWriter (Path.Combine("Items",name+".xml"), System.Text.Encoding.UTF8);
			XmlSerializer serializer = new XmlSerializer (typeof(BaseItem));
			serializer.Serialize (textWriter, this);
			textWriter.Close ();
		}
	}
}

