using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1370 : Class1351
{
	public delegate Class1370 Delegate72();

	public delegate void Delegate73(Class1370 elementData);

	public delegate void Delegate74(Class1370 elementData);

	private List<string> list_0;

	public string[] AuthorList => list_0.ToArray();

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
			if ((localName2 = reader.LocalName) != null && localName2 == "author")
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

	public Class1370(XmlReader reader)
		: base(reader)
	{
	}

	public Class1370()
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
			method_1("ssml", writer, "author", item);
		}
		writer.WriteEndElement();
	}

	public void AddAuthor(string str)
	{
		list_0.Add(str);
	}
}
