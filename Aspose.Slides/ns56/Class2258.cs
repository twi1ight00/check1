using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class2258 : Class1351
{
	public delegate Class2258 Delegate2521();

	public delegate void Delegate2523(Class2258 elementData);

	public delegate void Delegate2522(Class2258 elementData);

	private double double_0;

	private double double_1;

	private SlideSizeType slideSizeType_0;

	public static readonly SlideSizeType slideSizeType_1 = Class2558.smethod_0("custom");

	public double Cx
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

	public double Cy
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public SlideSizeType Type
	{
		get
		{
			return slideSizeType_0;
		}
		set
		{
			slideSizeType_0 = value;
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
				case "type":
					slideSizeType_0 = Class2558.smethod_0(reader.Value);
					break;
				case "cy":
					double_1 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "cx":
					double_0 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2258(XmlReader reader)
		: base(reader)
	{
	}

	public Class2258()
	{
	}

	protected override void vmethod_1()
	{
		double_0 = double.NaN;
		double_1 = double.NaN;
		slideSizeType_0 = slideSizeType_1;
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
		writer.WriteAttributeString("cx", XmlConvert.ToString((long)Math.Round(double_0 * 12700.0)));
		writer.WriteAttributeString("cy", XmlConvert.ToString((long)Math.Round(double_1 * 12700.0)));
		if (slideSizeType_0 != slideSizeType_1)
		{
			writer.WriteAttributeString("type", Class2558.smethod_1(slideSizeType_0));
		}
		writer.WriteEndElement();
	}
}
