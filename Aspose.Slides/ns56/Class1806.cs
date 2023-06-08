using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1806 : Class1351
{
	public delegate Class1806 Delegate1297();

	public delegate void Delegate1298(Class1806 elementData);

	public delegate void Delegate1299(Class1806 elementData);

	public const double double_0 = 6.0;

	public const double double_1 = 6.0;

	private double double_2;

	private double double_3;

	private BevelPresetType bevelPresetType_0;

	public static readonly BevelPresetType bevelPresetType_1 = Class2516.smethod_0("circle");

	public double W
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	public double H
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
		}
	}

	public BevelPresetType Prst
	{
		get
		{
			return bevelPresetType_0;
		}
		set
		{
			bevelPresetType_0 = value;
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
				case "prst":
					bevelPresetType_0 = Class2516.smethod_0(reader.Value);
					break;
				case "h":
					double_3 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "w":
					double_2 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1806(XmlReader reader)
		: base(reader)
	{
	}

	public Class1806()
	{
	}

	protected override void vmethod_1()
	{
		double_2 = 6.0;
		double_3 = 6.0;
		bevelPresetType_0 = bevelPresetType_1;
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
		if (double_2 != 6.0)
		{
			writer.WriteAttributeString("w", XmlConvert.ToString((long)Math.Round(double_2 * 12700.0)));
		}
		if (double_3 != 6.0)
		{
			writer.WriteAttributeString("h", XmlConvert.ToString((long)Math.Round(double_3 * 12700.0)));
		}
		if (bevelPresetType_0 != bevelPresetType_1)
		{
			writer.WriteAttributeString("prst", Class2516.smethod_1(bevelPresetType_0));
		}
		writer.WriteEndElement();
	}
}
