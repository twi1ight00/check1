using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2328 : Class1351
{
	public delegate Class2328 Delegate2731();

	public delegate void Delegate2732(Class2328 elementData);

	public delegate void Delegate2733(Class2328 elementData);

	public Class2329.Delegate2734 delegate2734_0;

	public Class2329.Delegate2735 delegate2735_0;

	private List<Class2329> list_0;

	public Class2329[] HList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "h")
				{
					Class2329 item = new Class2329(reader);
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

	public Class2328(XmlReader reader)
		: base(reader)
	{
	}

	public Class2328()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2329>();
	}

	protected override void vmethod_2()
	{
		delegate2734_0 = method_3;
		delegate2735_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class2329 item in list_0)
		{
			item.vmethod_4("v", writer, "h");
		}
		writer.WriteEndElement();
	}

	private Class2329 method_3()
	{
		Class2329 @class = new Class2329();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2329 elementData)
	{
		list_0.Add(elementData);
	}
}
