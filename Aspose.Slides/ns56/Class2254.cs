using System;
using System.Xml;

namespace ns56;

internal class Class2254 : Class1351
{
	public delegate Class2254 Delegate2509();

	public delegate void Delegate2510(Class2254 elementData);

	public delegate void Delegate2511(Class2254 elementData);

	public const uint uint_0 = uint.MaxValue;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private uint uint_1;

	private string string_0;

	private Class1888 class1888_0;

	public uint Id
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

	public Class1885 ExtLst => class1888_0;

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
					class1888_0 = new Class1888(reader);
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
				case "r:id":
					string_0 = reader.Value;
					break;
				case "id":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2254(XmlReader reader)
		: base(reader)
	{
	}

	public Class2254()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = uint.MaxValue;
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
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("id", XmlConvert.ToString(uint_1));
		}
		writer.WriteAttributeString("r:id", string_0);
		if (class1888_0 != null)
		{
			class1888_0.vmethod_4("p", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1885 method_3()
	{
		if (class1888_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1888_0 = new Class1888();
		return class1888_0;
	}

	private void method_4(Class1885 _extLst)
	{
		class1888_0 = (Class1888)_extLst;
	}
}
