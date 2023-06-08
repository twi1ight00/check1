using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2276 : Class1351
{
	public delegate Class2276 Delegate2575();

	public delegate void Delegate2576(Class2276 elementData);

	public delegate void Delegate2577(Class2276 elementData);

	private List<string> list_0;

	public string[] AttrNameList => list_0.ToArray();

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
			if (reader.NodeType != XmlNodeType.Element)
			{
				continue;
			}
			string localName2;
			if ((localName2 = reader.LocalName) != null && localName2 == "attrName")
			{
				string text = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						text += reader.ReadString();
					}
					list_0.Add(text);
				}
			}
			else
			{
				reader.Skip();
				flag = true;
			}
		}
	}

	private void method_2(XmlReader reader)
	{
	}

	public Class2276(XmlReader reader)
		: base(reader)
	{
	}

	public Class2276()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<string>();
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (string item in list_0)
		{
			method_1("p", writer, "attrName", item);
		}
		writer.WriteEndElement();
	}

	public void method_3(string str)
	{
		list_0.Add(str);
	}
}
