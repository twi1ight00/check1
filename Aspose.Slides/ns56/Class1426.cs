using System;
using System.Xml;

namespace ns56;

internal class Class1426 : Class1351
{
	public delegate Class1426 Delegate240();

	public delegate void Delegate241(Class1426 elementData);

	public delegate void Delegate242(Class1426 elementData);

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private Class1370 class1370_0;

	private Class1425 class1425_0;

	private Class1502 class1502_0;

	public Class1370 Authors => class1370_0;

	public Class1425 CommentList => class1425_0;

	public Class1502 ExtLst => class1502_0;

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
				case "extLst":
					class1502_0 = new Class1502(reader);
					break;
				case "commentList":
					class1425_0 = new Class1425(reader);
					break;
				case "authors":
					class1370_0 = new Class1370(reader);
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

	public Class1426(XmlReader reader)
		: base(reader)
	{
	}

	public Class1426()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate385_0 = method_3;
		delegate387_0 = method_4;
	}

	protected override void vmethod_3()
	{
		class1370_0 = new Class1370();
		class1425_0 = new Class1425();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("ssml", elementName, "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
		class1370_0.vmethod_4("ssml", writer, "authors");
		class1425_0.vmethod_4("ssml", writer, "commentList");
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1502 method_3()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_4(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
