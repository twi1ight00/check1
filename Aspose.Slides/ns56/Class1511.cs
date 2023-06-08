using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1511 : Class1351
{
	public delegate Class1511 Delegate412();

	public delegate void Delegate413(Class1511 elementData);

	public delegate void Delegate414(Class1511 elementData);

	public const bool bool_0 = false;

	public Class1510.Delegate409 delegate409_0;

	public Class1510.Delegate410 delegate410_0;

	private uint uint_0;

	private bool bool_1;

	private List<Class1510> list_0;

	public uint SheetId
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public bool RefreshError
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public Class1510[] RowList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "row")
				{
					Class1510 item = new Class1510(reader);
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
				case "refreshError":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "sheetId":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1511(XmlReader reader)
		: base(reader)
	{
	}

	public Class1511()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = false;
		list_0 = new List<Class1510>();
	}

	protected override void vmethod_2()
	{
		delegate409_0 = method_3;
		delegate410_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("sheetId", XmlConvert.ToString(uint_0));
		if (bool_1)
		{
			writer.WriteAttributeString("refreshError", bool_1 ? "1" : "0");
		}
		foreach (Class1510 item in list_0)
		{
			item.vmethod_4("ssml", writer, "row");
		}
		writer.WriteEndElement();
	}

	private Class1510 method_3()
	{
		Class1510 @class = new Class1510();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1510 elementData)
	{
		list_0.Add(elementData);
	}
}
