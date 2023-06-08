using System;
using System.Xml;

namespace ns56;

internal class Class2346 : Class1351
{
	private Class2345 class2345_0;

	public Class2345 GraphicData => class2345_0;

	protected override void vmethod_0(XmlReader reader)
	{
		string localName = reader.LocalName;
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
				if ((localName2 = reader.LocalName) == null || !(localName2 == "graphicData"))
				{
					throw new Exception("Unknown element \"" + reader.LocalName + "\"");
				}
				class2345_0 = new Class2345(reader);
				flag = reader.LocalName == localName;
			}
		}
	}

	internal Class2346(XmlReader reader)
		: base(reader)
	{
	}

	internal Class2346()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
		class2345_0 = new Class2345();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class2345_0.vmethod_4("a", writer, "graphicData");
		writer.WriteEndElement();
	}
}
