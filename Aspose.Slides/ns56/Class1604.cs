using System;
using System.Xml;

namespace ns56;

internal class Class1604 : Class1351
{
	public delegate Class1604 Delegate691();

	public delegate void Delegate692(Class1604 elementData);

	public delegate void Delegate693(Class1604 elementData);

	public const uint uint_0 = uint.MaxValue;

	public const int int_0 = 0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private int int_1;

	private uint uint_1;

	private int int_2;

	private string string_0;

	private string string_1;

	private Class1502 class1502_0;

	public int Fld
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public uint Item
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public int Hier
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public string Name
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

	public string Cap
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

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
				string localName2;
				if ((localName2 = reader.LocalName) != null && localName2 == "extLst")
				{
					class1502_0 = new Class1502(reader);
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
				case "cap":
					string_1 = reader.Value;
					break;
				case "name":
					string_0 = reader.Value;
					break;
				case "hier":
					int_2 = XmlConvert.ToInt32(reader.Value);
					break;
				case "item":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "fld":
					int_1 = XmlConvert.ToInt32(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1604(XmlReader reader)
		: base(reader)
	{
	}

	public Class1604()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = uint.MaxValue;
		int_2 = 0;
	}

	protected override void vmethod_2()
	{
		delegate385_0 = method_3;
		delegate387_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("fld", XmlConvert.ToString(int_1));
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("item", XmlConvert.ToString(uint_1));
		}
		if (int_2 != 0)
		{
			writer.WriteAttributeString("hier", XmlConvert.ToString(int_2));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("name", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("cap", string_1);
		}
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
