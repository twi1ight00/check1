using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1371 : Class1351
{
	public delegate void Delegate77(Class1371 elementData);

	public delegate Class1371 Delegate75();

	public delegate void Delegate76(Class1371 elementData);

	public Class1524.Delegate451 delegate451_0;

	public Class1524.Delegate452 delegate452_0;

	public Class1706.Delegate997 delegate997_0;

	public Class1706.Delegate999 delegate999_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private string string_0;

	private List<Class1524> list_0;

	private Class1706 class1706_0;

	private Class1502 class1502_0;

	public string Ref
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class1524[] FilterColumnList => list_0.ToArray();

	public Class1706 SortState => class1706_0;

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
				case "sortState":
					class1706_0 = new Class1706(reader);
					break;
				case "filterColumn":
				{
					Class1524 item = new Class1524(reader);
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
		while (reader.MoveToNextAttribute())
		{
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "ref")
			{
				string_0 = reader.Value;
			}
		}
		reader.MoveToElement();
	}

	public Class1371(XmlReader reader)
		: base(reader)
	{
	}

	public Class1371()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1524>();
	}

	protected override void vmethod_2()
	{
		delegate451_0 = method_3;
		delegate452_0 = method_4;
		delegate997_0 = method_5;
		delegate999_0 = method_6;
		delegate385_0 = method_7;
		delegate387_0 = method_8;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_0 != null)
		{
			writer.WriteAttributeString("ref", string_0);
		}
		foreach (Class1524 item in list_0)
		{
			item.vmethod_4("ssml", writer, "filterColumn");
		}
		if (class1706_0 != null)
		{
			class1706_0.vmethod_4("ssml", writer, "sortState");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1524 method_3()
	{
		Class1524 @class = new Class1524();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1524 elementData)
	{
		list_0.Add(elementData);
	}

	private Class1706 method_5()
	{
		if (class1706_0 != null)
		{
			throw new Exception("Only one <sortState> element can be added.");
		}
		class1706_0 = new Class1706();
		return class1706_0;
	}

	private void method_6(Class1706 _sortState)
	{
		class1706_0 = _sortState;
	}

	private Class1502 method_7()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_8(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
