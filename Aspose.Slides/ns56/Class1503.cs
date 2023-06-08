using System;
using System.Xml;

namespace ns56;

internal class Class1503 : Class1351
{
	public delegate Class1503 Delegate388();

	public delegate void Delegate389(Class1503 elementData);

	public delegate void Delegate390(Class1503 elementData);

	public Class1514.Delegate421 delegate421_0;

	public Class1514.Delegate423 delegate423_0;

	public Class1506.Delegate397 delegate397_0;

	public Class1506.Delegate399 delegate399_0;

	public Class1512.Delegate415 delegate415_0;

	public Class1512.Delegate417 delegate417_0;

	private string string_0;

	private Class1514 class1514_0;

	private Class1506 class1506_0;

	private Class1512 class1512_0;

	public string R_Id
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

	public Class1514 SheetNames => class1514_0;

	public Class1506 DefinedNames => class1506_0;

	public Class1512 SheetDataSet => class1512_0;

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
				case "sheetDataSet":
					class1512_0 = new Class1512(reader);
					break;
				case "definedNames":
					class1506_0 = new Class1506(reader);
					break;
				case "sheetNames":
					class1514_0 = new Class1514(reader);
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
		while (reader.MoveToNextAttribute())
		{
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "r:id")
			{
				string_0 = reader.Value;
			}
		}
		reader.MoveToElement();
	}

	public Class1503(XmlReader reader)
		: base(reader)
	{
	}

	public Class1503()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate421_0 = method_3;
		delegate423_0 = method_4;
		delegate397_0 = method_5;
		delegate399_0 = method_6;
		delegate415_0 = method_7;
		delegate417_0 = method_8;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("r:id", string_0);
		if (class1514_0 != null)
		{
			class1514_0.vmethod_4("ssml", writer, "sheetNames");
		}
		if (class1506_0 != null)
		{
			class1506_0.vmethod_4("ssml", writer, "definedNames");
		}
		if (class1512_0 != null)
		{
			class1512_0.vmethod_4("ssml", writer, "sheetDataSet");
		}
		writer.WriteEndElement();
	}

	private Class1514 method_3()
	{
		if (class1514_0 != null)
		{
			throw new Exception("Only one <sheetNames> element can be added.");
		}
		class1514_0 = new Class1514();
		return class1514_0;
	}

	private void method_4(Class1514 _sheetNames)
	{
		class1514_0 = _sheetNames;
	}

	private Class1506 method_5()
	{
		if (class1506_0 != null)
		{
			throw new Exception("Only one <definedNames> element can be added.");
		}
		class1506_0 = new Class1506();
		return class1506_0;
	}

	private void method_6(Class1506 _definedNames)
	{
		class1506_0 = _definedNames;
	}

	private Class1512 method_7()
	{
		if (class1512_0 != null)
		{
			throw new Exception("Only one <sheetDataSet> element can be added.");
		}
		class1512_0 = new Class1512();
		return class1512_0;
	}

	private void method_8(Class1512 _sheetDataSet)
	{
		class1512_0 = _sheetDataSet;
	}
}
