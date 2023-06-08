using System.Xml;

namespace ns56;

internal class Class2144 : Class1351
{
	public delegate Class2144 Delegate2164();

	public delegate void Delegate2165(Class2144 elementData);

	public delegate void Delegate2166(Class2144 elementData);

	private uint uint_0;

	private double double_0;

	public uint Idx
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public double Val
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

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
				_ = reader.LocalName;
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
				case "val":
					double_0 = ToDouble(reader.Value);
					break;
				case "idx":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2144(XmlReader reader)
		: base(reader)
	{
	}

	public Class2144()
	{
	}

	protected override void vmethod_1()
	{
		double_0 = double.NaN;
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("idx", XmlConvert.ToString(uint_0));
		writer.WriteAttributeString("val", XmlConvert.ToString(double_0));
		writer.WriteEndElement();
	}
}
