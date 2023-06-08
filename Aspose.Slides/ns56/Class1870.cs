using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1870 : Class1351
{
	public delegate Class1870 Delegate1489();

	public delegate void Delegate1490(Class1870 elementData);

	public delegate void Delegate1491(Class1870 elementData);

	public const float float_0 = float.NaN;

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	private float float_1;

	private NullableBool nullableBool_1;

	public float Ang
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

	public NullableBool Scaled
	{
		get
		{
			return nullableBool_1;
		}
		set
		{
			nullableBool_1 = value;
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
				case "scaled":
					nullableBool_1 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "ang":
					float_1 = (float)XmlConvert.ToInt32(reader.Value) / 60000f;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1870(XmlReader reader)
		: base(reader)
	{
	}

	public Class1870()
	{
	}

	protected override void vmethod_1()
	{
		float_1 = float.NaN;
		nullableBool_1 = NullableBool.NotDefined;
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
		if (!float.IsNaN(float_1))
		{
			writer.WriteAttributeString("ang", XmlConvert.ToString((int)Math.Round(float_1 * 60000f)));
		}
		if (nullableBool_1 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("scaled", (nullableBool_1 == NullableBool.True) ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
