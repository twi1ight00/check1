using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1779 : Class1351
{
	public delegate Class1779 Delegate1216();

	public delegate void Delegate1217(Class1779 elementData);

	public delegate void Delegate1218(Class1779 elementData);

	public const Enum309 enum309_0 = Enum309.const_0;

	public Class1780.Delegate1219 delegate1219_0;

	public Class1780.Delegate1220 delegate1220_0;

	private Enum309 enum309_1;

	private string string_0;

	private List<Class1780> list_0;

	public Enum309 Persistence
	{
		get
		{
			return enum309_1;
		}
		set
		{
			enum309_1 = value;
		}
	}

	public string R_Id
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class1780[] OcxPrList => list_0.ToArray();

	protected override void vmethod_0(XmlReader reader)
	{
		string localName = reader.LocalName;
		method_2(reader);
		if (reader.IsEmptyElement)
		{
			return;
		}
		bool flag = false;
		while (((flag && !reader.EOF) || reader.Read()) && (reader.NodeType != XmlNodeType.EndElement || !(reader.LocalName == localName)))
		{
			flag = false;
			if (reader.NodeType == XmlNodeType.Element)
			{
				string localName2;
				if ((localName2 = reader.LocalName) != null && localName2 == "ocxPr")
				{
					Class1780 item = new Class1780(reader);
					list_0.Add(item);
				}
				else
				{
					reader.Skip();
					flag = true;
				}
			}
		}
	}

	private void method_2(XmlReader reader)
	{
		while (reader.MoveToNextAttribute())
		{
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "r:id":
					string_0 = reader.Value;
					break;
				case "persistence":
					enum309_1 = Class2437.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1779(XmlReader reader)
		: base(reader)
	{
	}

	public Class1779()
	{
	}

	protected override void vmethod_1()
	{
		enum309_1 = Enum309.const_0;
		list_0 = new List<Class1780>();
	}

	protected override void vmethod_2()
	{
		delegate1219_0 = method_3;
		delegate1220_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum309_1 != 0)
		{
			writer.WriteAttributeString("persistence", Class2437.smethod_1(enum309_1));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("r:id", string_0);
		}
		foreach (Class1780 item in list_0)
		{
			item.vmethod_4("ax", writer, "ocxPr");
		}
		writer.WriteEndElement();
	}

	private Class1780 method_3()
	{
		Class1780 @class = new Class1780();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1780 elementData)
	{
		list_0.Add(elementData);
	}
}
