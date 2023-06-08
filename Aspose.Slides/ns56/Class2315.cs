using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2315 : Class1351
{
	public delegate Class2315 Delegate2692();

	public delegate void Delegate2693(Class2315 elementData);

	public delegate void Delegate2694(Class2315 elementData);

	public Class1939.Delegate1684 delegate1684_0;

	public Class1939.Delegate1686 delegate1686_0;

	public Class1940.Delegate1687 delegate1687_0;

	public Class1940.Delegate1688 delegate1688_0;

	private Class1939 class1939_0;

	private Class1937 class1937_0;

	private List<Class1940> list_0;

	public Class1939 TblPr => class1939_0;

	public Class1937 TblGrid => class1937_0;

	public Class1940[] TrList => list_0.ToArray();

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
				case "tr":
				{
					Class1940 item = new Class1940(reader);
					list_0.Add(item);
					break;
				}
				case "tblGrid":
					class1937_0 = new Class1937(reader);
					break;
				case "tblPr":
					class1939_0 = new Class1939(reader);
					break;
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

	public Class2315(XmlReader reader)
		: base(reader)
	{
	}

	public Class2315()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1940>();
	}

	protected override void vmethod_2()
	{
		delegate1684_0 = method_3;
		delegate1686_0 = method_4;
		delegate1687_0 = method_5;
		delegate1688_0 = method_6;
	}

	protected override void vmethod_3()
	{
		class1937_0 = new Class1937();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("a", elementName, "http://schemas.openxmlformats.org/drawingml/2006/main");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		if (class1939_0 != null)
		{
			class1939_0.vmethod_4("a", writer, "tblPr");
		}
		class1937_0.vmethod_4("a", writer, "tblGrid");
		foreach (Class1940 item in list_0)
		{
			item.vmethod_4("a", writer, "tr");
		}
		writer.WriteEndElement();
	}

	private Class1939 method_3()
	{
		if (class1939_0 != null)
		{
			throw new Exception("Only one <tblPr> element can be added.");
		}
		class1939_0 = new Class1939();
		return class1939_0;
	}

	private void method_4(Class1939 _tblPr)
	{
		class1939_0 = _tblPr;
	}

	private Class1940 method_5()
	{
		Class1940 @class = new Class1940();
		list_0.Add(@class);
		return @class;
	}

	private void method_6(Class1940 elementData)
	{
		list_0.Add(elementData);
	}
}
