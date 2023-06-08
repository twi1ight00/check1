using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1582 : Class1351
{
	public delegate Class1582 Delegate625();

	public delegate void Delegate626(Class1582 elementData);

	public delegate void Delegate627(Class1582 elementData);

	public Class1589.Delegate646 delegate646_0;

	public Class1589.Delegate648 delegate648_0;

	public Class1587.Delegate640 delegate640_0;

	public Class1587.Delegate642 delegate642_0;

	public Class1569.Delegate586 delegate586_0;

	public Class1569.Delegate588 delegate588_0;

	public Class1537.Delegate490 delegate490_0;

	public Class1537.Delegate491 delegate491_0;

	public Class1584.Delegate631 delegate631_0;

	public Class1584.Delegate633 delegate633_0;

	public Class1584.Delegate631 delegate631_1;

	public Class1584.Delegate633 delegate633_1;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private Class1589 class1589_0;

	private Class1587 class1587_0;

	private Class1569 class1569_0;

	private List<Class1537> list_0;

	private Class1584 class1584_0;

	private Class1584 class1584_1;

	private Class1502 class1502_0;

	public Class1589 MetadataTypes => class1589_0;

	public Class1587 MetadataStrings => class1587_0;

	public Class1569 MdxMetadata => class1569_0;

	public Class1537[] FutureMetadataList => list_0.ToArray();

	public Class1584 CellMetadata => class1584_0;

	public Class1584 ValueMetadata => class1584_1;

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
				case "metadataTypes":
					class1589_0 = new Class1589(reader);
					break;
				case "metadataStrings":
					class1587_0 = new Class1587(reader);
					break;
				case "mdxMetadata":
					class1569_0 = new Class1569(reader);
					break;
				case "futureMetadata":
				{
					Class1537 item = new Class1537(reader);
					list_0.Add(item);
					break;
				}
				case "cellMetadata":
					class1584_0 = new Class1584(reader);
					break;
				case "valueMetadata":
					class1584_1 = new Class1584(reader);
					break;
				case "extLst":
					class1502_0 = new Class1502(reader);
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

	public Class1582(XmlReader reader)
		: base(reader)
	{
	}

	public Class1582()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1537>();
	}

	protected override void vmethod_2()
	{
		delegate646_0 = method_3;
		delegate648_0 = method_4;
		delegate640_0 = method_5;
		delegate642_0 = method_6;
		delegate586_0 = method_7;
		delegate588_0 = method_8;
		delegate490_0 = method_9;
		delegate491_0 = method_10;
		delegate631_0 = method_11;
		delegate633_0 = method_12;
		delegate631_1 = method_13;
		delegate633_1 = method_14;
		delegate385_0 = method_15;
		delegate387_0 = method_16;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("ssml", elementName, "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
		if (class1589_0 != null)
		{
			class1589_0.vmethod_4("ssml", writer, "metadataTypes");
		}
		if (class1587_0 != null)
		{
			class1587_0.vmethod_4("ssml", writer, "metadataStrings");
		}
		if (class1569_0 != null)
		{
			class1569_0.vmethod_4("ssml", writer, "mdxMetadata");
		}
		foreach (Class1537 item in list_0)
		{
			item.vmethod_4("ssml", writer, "futureMetadata");
		}
		if (class1584_0 != null)
		{
			class1584_0.vmethod_4("ssml", writer, "cellMetadata");
		}
		if (class1584_1 != null)
		{
			class1584_1.vmethod_4("ssml", writer, "valueMetadata");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1589 method_3()
	{
		if (class1589_0 != null)
		{
			throw new Exception("Only one <metadataTypes> element can be added.");
		}
		class1589_0 = new Class1589();
		return class1589_0;
	}

	private void method_4(Class1589 _metadataTypes)
	{
		class1589_0 = _metadataTypes;
	}

	private Class1587 method_5()
	{
		if (class1587_0 != null)
		{
			throw new Exception("Only one <metadataStrings> element can be added.");
		}
		class1587_0 = new Class1587();
		return class1587_0;
	}

	private void method_6(Class1587 _metadataStrings)
	{
		class1587_0 = _metadataStrings;
	}

	private Class1569 method_7()
	{
		if (class1569_0 != null)
		{
			throw new Exception("Only one <mdxMetadata> element can be added.");
		}
		class1569_0 = new Class1569();
		return class1569_0;
	}

	private void method_8(Class1569 _mdxMetadata)
	{
		class1569_0 = _mdxMetadata;
	}

	private Class1537 method_9()
	{
		Class1537 @class = new Class1537();
		list_0.Add(@class);
		return @class;
	}

	private void method_10(Class1537 elementData)
	{
		list_0.Add(elementData);
	}

	private Class1584 method_11()
	{
		if (class1584_0 != null)
		{
			throw new Exception("Only one <cellMetadata> element can be added.");
		}
		class1584_0 = new Class1584();
		return class1584_0;
	}

	private void method_12(Class1584 _cellMetadata)
	{
		class1584_0 = _cellMetadata;
	}

	private Class1584 method_13()
	{
		if (class1584_1 != null)
		{
			throw new Exception("Only one <valueMetadata> element can be added.");
		}
		class1584_1 = new Class1584();
		return class1584_1;
	}

	private void method_14(Class1584 _valueMetadata)
	{
		class1584_1 = _valueMetadata;
	}

	private Class1502 method_15()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_16(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
