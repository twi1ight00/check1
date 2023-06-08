using System;
using System.Xml;

namespace ns56;

internal class Class2299 : Class1351
{
	public delegate Class2299 Delegate2644();

	public delegate void Delegate2645(Class2299 elementData);

	public delegate void Delegate2646(Class2299 elementData);

	public const string string_0 = "indefinite";

	public const string string_1 = "";

	public Class2272.Delegate2563 delegate2563_0;

	public Class2272.Delegate2565 delegate2565_0;

	private string string_2;

	private string string_3;

	private Class2272 class2272_0;

	public string Tm
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public string Fmla
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public Class2272 Val => class2272_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "val")
				{
					class2272_0 = new Class2272(reader);
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
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "fmla":
					string_3 = reader.Value;
					break;
				case "tm":
					string_2 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2299(XmlReader reader)
		: base(reader)
	{
	}

	public Class2299()
	{
	}

	protected override void vmethod_1()
	{
		string_2 = "indefinite";
		string_3 = "";
	}

	protected override void vmethod_2()
	{
		delegate2563_0 = method_3;
		delegate2565_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_2 != "indefinite")
		{
			writer.WriteAttributeString("tm", string_2);
		}
		if (string_3 != "")
		{
			writer.WriteAttributeString("fmla", string_3);
		}
		if (class2272_0 != null)
		{
			class2272_0.vmethod_4("p", writer, "val");
		}
		writer.WriteEndElement();
	}

	private Class2272 method_3()
	{
		if (class2272_0 != null)
		{
			throw new Exception("Only one <val> element can be added.");
		}
		class2272_0 = new Class2272();
		return class2272_0;
	}

	private void method_4(Class2272 _val)
	{
		class2272_0 = _val;
	}
}
