using System;
using System.Xml;
using ns57;

namespace ns56;

internal class Class2268 : Class1351
{
	public delegate Class2268 Delegate2551();

	public delegate void Delegate2552(Class2268 elementData);

	public delegate void Delegate2553(Class2268 elementData);

	public const Enum282 enum282_0 = Enum282.const_0;

	public const Enum283 enum283_0 = Enum283.const_0;

	public const float float_0 = float.NaN;

	public const float float_1 = float.NaN;

	public Class2292.Delegate2623 delegate2623_0;

	public Class2292.Delegate2625 delegate2625_0;

	public Class2292.Delegate2623 delegate2623_1;

	public Class2292.Delegate2625 delegate2625_1;

	public Class2292.Delegate2623 delegate2623_2;

	public Class2292.Delegate2625 delegate2625_2;

	public Class2292.Delegate2623 delegate2623_3;

	public Class2292.Delegate2625 delegate2625_3;

	private Enum282 enum282_1;

	private string string_0;

	private Enum283 enum283_1;

	private float float_2;

	private string string_1;

	private float float_3;

	private Class2281 class2281_0;

	private Class2292 class2292_0;

	private Class2292 class2292_1;

	private Class2292 class2292_2;

	private Class2292 class2292_3;

	public Enum282 Origin
	{
		get
		{
			return enum282_1;
		}
		set
		{
			enum282_1 = value;
		}
	}

	public string Path
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

	public Enum283 PathEditMode
	{
		get
		{
			return enum283_1;
		}
		set
		{
			enum283_1 = value;
		}
	}

	public float RAng
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	public string PtsTypes
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

	public float P14_BounceEnd
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	public Class2281 CBhvr => class2281_0;

	public Class2292 By => class2292_0;

	public Class2292 From => class2292_1;

	public Class2292 To => class2292_2;

	public Class2292 RCtr => class2292_3;

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
				case "rCtr":
					class2292_3 = new Class2292(reader);
					break;
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
				case "origin":
					enum282_1 = Class2584.smethod_0(reader.Value);
					break;
				case "path":
					string_0 = reader.Value;
					break;
				case "pathEditMode":
					enum283_1 = Class2585.smethod_0(reader.Value);
					break;
				case "rAng":
					float_2 = (float)XmlConvert.ToInt32(reader.Value) / 60000f;
					break;
				case "ptsTypes":
					string_1 = reader.Value;
					break;
				case "p14:bounceEnd":
					float_3 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2268(XmlReader reader)
		: base(reader)
	{
	}

	public Class2268()
	{
	}

	protected override void vmethod_1()
	{
		enum282_1 = Enum282.const_0;
		enum283_1 = Enum283.const_0;
		float_2 = float.NaN;
		float_3 = float.NaN;
	}

	protected override void vmethod_2()
	{
		delegate2623_0 = method_3;
		delegate2625_0 = method_4;
		delegate2623_1 = method_5;
		delegate2625_1 = method_6;
		delegate2623_2 = method_7;
		delegate2625_2 = method_8;
		delegate2623_3 = method_9;
		delegate2625_3 = method_10;
	}

	protected override void vmethod_3()
	{
		class2281_0 = new Class2281();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum282_1 != Enum282.const_0)
		{
			writer.WriteAttributeString("origin", Class2584.smethod_1(enum282_1));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("path", string_0);
		}
		if (enum283_1 != Enum283.const_0)
		{
			writer.WriteAttributeString("pathEditMode", Class2585.smethod_1(enum283_1));
		}
		if (!float.IsNaN(float_2))
		{
			writer.WriteAttributeString("rAng", XmlConvert.ToString((int)Math.Round(float_2 * 60000f)));
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("ptsTypes", string_1);
		}
		if (!float.IsNaN(float_3))
		{
			writer.WriteAttributeString("p14:bounceEnd", XmlConvert.ToString((int)Math.Round(float_3 * 1000f)));
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
		if (class2292_3 != null)
		{
			class2292_3.vmethod_4("p", writer, "rCtr");
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

	private Class2292 method_9()
	{
		if (class2292_3 != null)
		{
			throw new Exception("Only one <rCtr> element can be added.");
		}
		class2292_3 = new Class2292();
		return class2292_3;
	}

	private void method_10(Class2292 _rCtr)
	{
		class2292_3 = _rCtr;
	}
}
