using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class2270 : Class1351
{
	public delegate Class2270 Delegate2557();

	public delegate void Delegate2558(Class2270 elementData);

	public delegate void Delegate2559(Class2270 elementData);

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const float float_0 = float.NaN;

	public Class2292.Delegate2623 delegate2623_0;

	public Class2292.Delegate2625 delegate2625_0;

	public Class2292.Delegate2623 delegate2623_1;

	public Class2292.Delegate2625 delegate2625_1;

	public Class2292.Delegate2623 delegate2623_2;

	public Class2292.Delegate2625 delegate2625_2;

	private NullableBool nullableBool_1;

	private float float_1;

	private Class2281 class2281_0;

	private Class2292 class2292_0;

	private Class2292 class2292_1;

	private Class2292 class2292_2;

	public NullableBool ZoomContents
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

	public float P14_BounceEnd
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

	public Class2281 CBhvr => class2281_0;

	public Class2292 By => class2292_0;

	public Class2292 From => class2292_1;

	public Class2292 To => class2292_2;

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
				case "to":
					class2292_2 = new Class2292(reader);
					break;
				case "from":
					class2292_1 = new Class2292(reader);
					break;
				case "by":
					class2292_0 = new Class2292(reader);
					break;
				case "cBhvr":
					class2281_0 = new Class2281(reader);
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
				case "p14:bounceEnd":
					float_1 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "zoomContents":
					nullableBool_1 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2270(XmlReader reader)
		: base(reader)
	{
	}

	public Class2270()
	{
	}

	protected override void vmethod_1()
	{
		nullableBool_1 = NullableBool.NotDefined;
		float_1 = float.NaN;
	}

	protected override void vmethod_2()
	{
		delegate2623_0 = method_3;
		delegate2625_0 = method_4;
		delegate2623_1 = method_5;
		delegate2625_1 = method_6;
		delegate2623_2 = method_7;
		delegate2625_2 = method_8;
	}

	protected override void vmethod_3()
	{
		class2281_0 = new Class2281();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (nullableBool_1 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("zoomContents", (nullableBool_1 == NullableBool.True) ? "1" : "0");
		}
		if (!float.IsNaN(float_1))
		{
			writer.WriteAttributeString("p14:bounceEnd", XmlConvert.ToString((int)Math.Round(float_1 * 1000f)));
		}
		class2281_0.vmethod_4("p", writer, "cBhvr");
		if (class2292_0 != null)
		{
			class2292_0.vmethod_4("p", writer, "by");
		}
		if (class2292_1 != null)
		{
			class2292_1.vmethod_4("p", writer, "from");
		}
		if (class2292_2 != null)
		{
			class2292_2.vmethod_4("p", writer, "to");
		}
		writer.WriteEndElement();
	}

	private Class2292 method_3()
	{
		if (class2292_0 != null)
		{
			throw new Exception("Only one <by> element can be added.");
		}
		class2292_0 = new Class2292();
		return class2292_0;
	}

	private void method_4(Class2292 _by)
	{
		class2292_0 = _by;
	}

	private Class2292 method_5()
	{
		if (class2292_1 != null)
		{
			throw new Exception("Only one <from> element can be added.");
		}
		class2292_1 = new Class2292();
		return class2292_1;
	}

	private void method_6(Class2292 _from)
	{
		class2292_1 = _from;
	}

	private Class2292 method_7()
	{
		if (class2292_2 != null)
		{
			throw new Exception("Only one <to> element can be added.");
		}
		class2292_2 = new Class2292();
		return class2292_2;
	}

	private void method_8(Class2292 _to)
	{
		class2292_2 = _to;
	}
}
