using System;
using System.Xml;

namespace ns56;

internal class Class1976 : Class1351
{
	public delegate void Delegate1797(Class1976 elementData);

	public delegate Class1976 Delegate1795();

	public delegate void Delegate1796(Class1976 elementData);

	public const float float_0 = 0f;

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public Class1903.Delegate1576 delegate1576_0;

	public Class1903.Delegate1578 delegate1578_0;

	public Class1906.Delegate1585 delegate1585_0;

	public Class1906.Delegate1587 delegate1587_0;

	private float float_1;

	private bool bool_2;

	private bool bool_3;

	private Class1903 class1903_0;

	private Class1906 class1906_0;

	public float Rot
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public bool FlipH
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool FlipV
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public Class1903 Off => class1903_0;

	public Class1906 Ext => class1906_0;

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
				case "ext":
					class1906_0 = new Class1906(reader);
					break;
				case "off":
					class1903_0 = new Class1903(reader);
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
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "flipV":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "flipH":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "rot":
					float_1 = (float)XmlConvert.ToInt32(reader.Value) / 60000f;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1976(XmlReader reader)
		: base(reader)
	{
	}

	public Class1976()
	{
	}

	protected override void vmethod_1()
	{
		float_1 = 0f;
		bool_2 = false;
		bool_3 = false;
	}

	protected override void vmethod_2()
	{
		delegate1576_0 = method_3;
		delegate1578_0 = method_4;
		delegate1585_0 = method_5;
		delegate1587_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (float_1 != 0f)
		{
			writer.WriteAttributeString("rot", XmlConvert.ToString((int)Math.Round(float_1 * 60000f)));
		}
		if (bool_2)
		{
			writer.WriteAttributeString("flipH", bool_2 ? "1" : "0");
		}
		if (bool_3)
		{
			writer.WriteAttributeString("flipV", bool_3 ? "1" : "0");
		}
		if (class1903_0 != null)
		{
			class1903_0.vmethod_4("a", writer, "off");
		}
		if (class1906_0 != null)
		{
			class1906_0.vmethod_4("a", writer, "ext");
		}
		writer.WriteEndElement();
	}

	private Class1903 method_3()
	{
		if (class1903_0 != null)
		{
			throw new Exception("Only one <off> element can be added.");
		}
		class1903_0 = new Class1903();
		return class1903_0;
	}

	private void method_4(Class1903 _off)
	{
		class1903_0 = _off;
	}

	private Class1906 method_5()
	{
		if (class1906_0 != null)
		{
			throw new Exception("Only one <ext> element can be added.");
		}
		class1906_0 = new Class1906();
		return class1906_0;
	}

	private void method_6(Class1906 _ext)
	{
		class1906_0 = _ext;
	}
}
