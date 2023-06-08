using System;
using System.Xml;

namespace ns56;

internal class Class2183 : Class1351
{
	public delegate Class2183 Delegate2281();

	public delegate void Delegate2282(Class2183 elementData);

	public delegate void Delegate2283(Class2183 elementData);

	public const bool bool_0 = false;

	public Class2165.Delegate2227 delegate2227_0;

	public Class2165.Delegate2229 delegate2229_0;

	private bool bool_1;

	private Class2165 class2165_0;

	public bool UseDef
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public Class2165 DataModel => class2165_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "dataModel")
				{
					class2165_0 = new Class2165(reader);
					continue;
				}
				reader.Skip();
				flag = true;
			}
		}
	}

	private void method_2(XmlReader reader)
	{
		while (reader.MoveToNextAttribute())
		{
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "useDef")
			{
				bool_1 = XmlConvert.ToBoolean(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2183(XmlReader reader)
		: base(reader)
	{
	}

	public Class2183()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = false;
	}

	protected override void vmethod_2()
	{
		delegate2227_0 = method_3;
		delegate2229_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (bool_1)
		{
			writer.WriteAttributeString("useDef", bool_1 ? "1" : "0");
		}
		if (class2165_0 != null)
		{
			class2165_0.vmethod_4("dgm", writer, "dataModel");
		}
		writer.WriteEndElement();
	}

	private Class2165 method_3()
	{
		if (class2165_0 != null)
		{
			throw new Exception("Only one <dataModel> element can be added.");
		}
		class2165_0 = new Class2165();
		return class2165_0;
	}

	private void method_4(Class2165 _dataModel)
	{
		class2165_0 = _dataModel;
	}
}
