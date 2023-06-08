using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1425 : Class1351
{
	public delegate Class1425 Delegate237();

	public delegate void Delegate238(Class1425 elementData);

	public delegate void Delegate239(Class1425 elementData);

	public Class1424.Delegate234 delegate234_0;

	public Class1424.Delegate235 delegate235_0;

	private List<Class1424> list_0;

	public Class1424[] CommentList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "comment")
				{
					Class1424 item = new Class1424(reader);
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
	}

	public Class1425(XmlReader reader)
		: base(reader)
	{
	}

	public Class1425()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1424>();
	}

	protected override void vmethod_2()
	{
		delegate234_0 = method_3;
		delegate235_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1424 item in list_0)
		{
			item.vmethod_4("ssml", writer, "comment");
		}
		writer.WriteEndElement();
	}

	private Class1424 method_3()
	{
		Class1424 @class = new Class1424();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1424 elementData)
	{
		list_0.Add(elementData);
	}
}
