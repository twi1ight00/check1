using System;
using System.Xml;

namespace ns56;

internal class Class2238 : Class1351
{
	public delegate Class2238 Delegate2458();

	public delegate void Delegate2460(Class2238 elementData);

	public delegate void Delegate2459(Class2238 elementData);

	public const bool bool_0 = true;

	public const bool bool_1 = true;

	public const bool bool_2 = true;

	public const bool bool_3 = true;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private Class1889 class1889_0;

	public bool SldNum
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public bool Hdr
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public bool Ftr
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public bool Dt
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
		}
	}

	public Class1885 ExtLst => class1889_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "extLst")
				{
					class1889_0 = new Class1889(reader);
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
				case "dt":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "ftr":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "hdr":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "sldNum":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2238(XmlReader reader)
		: base(reader)
	{
	}

	public Class2238()
	{
	}

	protected override void vmethod_1()
	{
		bool_4 = true;
		bool_5 = true;
		bool_6 = true;
		bool_7 = true;
	}

	protected override void vmethod_2()
	{
		delegate1534_0 = method_3;
		delegate1535_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (!bool_4)
		{
			writer.WriteAttributeString("sldNum", bool_4 ? "1" : "0");
		}
		if (!bool_5)
		{
			writer.WriteAttributeString("hdr", bool_5 ? "1" : "0");
		}
		if (!bool_6)
		{
			writer.WriteAttributeString("ftr", bool_6 ? "1" : "0");
		}
		if (!bool_7)
		{
			writer.WriteAttributeString("dt", bool_7 ? "1" : "0");
		}
		if (class1889_0 != null)
		{
			class1889_0.vmethod_4("p", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1885 method_3()
	{
		if (class1889_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1889_0 = new Class1889();
		return class1889_0;
	}

	private void method_4(Class1885 _extLst)
	{
		class1889_0 = (Class1889)_extLst;
	}
}
