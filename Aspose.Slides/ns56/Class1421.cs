using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1421 : Class1351
{
	public delegate Class1421 Delegate225();

	public delegate void Delegate227(Class1421 elementData);

	public delegate void Delegate226(Class1421 elementData);

	public Class1407.Delegate183 delegate183_0;

	public Class1407.Delegate184 delegate184_0;

	public Class1419.Delegate219 delegate219_0;

	public Class1419.Delegate220 delegate220_0;

	private List<Class1407> list_0;

	private List<Class1419> list_1;

	public Class1407[] CfvoList => list_0.ToArray();

	public Class1419[] ColorList => list_1.ToArray();

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
				switch (reader.LocalName)
				{
				case "color":
				{
					Class1419 item2 = new Class1419(reader);
					list_1.Add(item2);
					break;
				}
				case "cfvo":
				{
					Class1407 item = new Class1407(reader);
					list_0.Add(item);
					break;
				}
				default:
					reader.Skip();
					flag = true;
					break;
				}
			}
		}
	}

	private void method_2(XmlReader reader)
	{
	}

	public Class1421(XmlReader reader)
		: base(reader)
	{
	}

	public Class1421()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1407>();
		list_1 = new List<Class1419>();
	}

	protected override void vmethod_2()
	{
		delegate183_0 = method_3;
		delegate184_0 = method_4;
		delegate219_0 = method_5;
		delegate220_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1407 item in list_0)
		{
			item.vmethod_4("ssml", writer, "cfvo");
		}
		foreach (Class1419 item2 in list_1)
		{
			item2.vmethod_4("ssml", writer, "color");
		}
		writer.WriteEndElement();
	}

	private Class1407 method_3()
	{
		Class1407 @class = new Class1407();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1407 elementData)
	{
		list_0.Add(elementData);
	}

	private Class1419 method_5()
	{
		Class1419 @class = new Class1419();
		list_1.Add(@class);
		return @class;
	}

	private void method_6(Class1419 elementData)
	{
		list_1.Add(elementData);
	}
}
