using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1388 : Class1351
{
	public delegate void Delegate128(Class1388 elementData);

	public delegate Class1388 Delegate126();

	public delegate void Delegate127(Class1388 elementData);

	public const uint uint_0 = uint.MaxValue;

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const uint uint_1 = 100u;

	public const double double_0 = 0.001;

	public const bool bool_2 = true;

	public const bool bool_3 = true;

	public const bool bool_4 = true;

	public const bool bool_5 = true;

	public const uint uint_2 = uint.MaxValue;

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	private uint uint_3;

	private Enum185 enum185_0;

	private bool bool_6;

	private Enum234 enum234_0;

	private bool bool_7;

	private uint uint_4;

	private double double_1;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private uint uint_5;

	private NullableBool nullableBool_1;

	public static readonly Enum185 enum185_1 = Class2351.smethod_0("auto");

	public static readonly Enum234 enum234_1 = Class2401.smethod_0("A1");

	public uint CalcId
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
		}
	}

	public Enum185 CalcMode
	{
		get
		{
			return enum185_0;
		}
		set
		{
			enum185_0 = value;
		}
	}

	public bool FullCalcOnLoad
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

	public Enum234 RefMode
	{
		get
		{
			return enum234_0;
		}
		set
		{
			enum234_0 = value;
		}
	}

	public bool Iterate
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

	public uint IterateCount
	{
		get
		{
			return uint_4;
		}
		set
		{
			uint_4 = value;
		}
	}

	public double IterateDelta
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

	public bool FullPrecision
	{
		get
		{
			return bool_8;
		}
		set
		{
			bool_8 = value;
		}
	}

	public bool CalcCompleted
	{
		get
		{
			return bool_9;
		}
		set
		{
			bool_9 = value;
		}
	}

	public bool CalcOnSave
	{
		get
		{
			return bool_10;
		}
		set
		{
			bool_10 = value;
		}
	}

	public bool ConcurrentCalc
	{
		get
		{
			return bool_11;
		}
		set
		{
			bool_11 = value;
		}
	}

	public uint ConcurrentManualCount
	{
		get
		{
			return uint_5;
		}
		set
		{
			uint_5 = value;
		}
	}

	public NullableBool ForceFullCalc
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
				case "calcId":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "calcMode":
					enum185_0 = Class2351.smethod_0(reader.Value);
					break;
				case "fullCalcOnLoad":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "refMode":
					enum234_0 = Class2401.smethod_0(reader.Value);
					break;
				case "iterate":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "iterateCount":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "iterateDelta":
					double_1 = ToDouble(reader.Value);
					break;
				case "fullPrecision":
					bool_8 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "calcCompleted":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "calcOnSave":
					bool_10 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "concurrentCalc":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "concurrentManualCount":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "forceFullCalc":
					nullableBool_1 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1388(XmlReader reader)
		: base(reader)
	{
	}

	public Class1388()
	{
	}

	protected override void vmethod_1()
	{
		uint_3 = uint.MaxValue;
		enum185_0 = enum185_1;
		bool_6 = false;
		enum234_0 = enum234_1;
		bool_7 = false;
		uint_4 = 100u;
		double_1 = 0.001;
		bool_8 = true;
		bool_9 = true;
		bool_10 = true;
		bool_11 = true;
		uint_5 = uint.MaxValue;
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
		if (uint_3 != uint.MaxValue)
		{
			writer.WriteAttributeString("calcId", XmlConvert.ToString(uint_3));
		}
		if (enum185_0 != enum185_1)
		{
			writer.WriteAttributeString("calcMode", Class2351.smethod_1(enum185_0));
		}
		if (bool_6)
		{
			writer.WriteAttributeString("fullCalcOnLoad", bool_6 ? "1" : "0");
		}
		if (enum234_0 != enum234_1)
		{
			writer.WriteAttributeString("refMode", Class2401.smethod_1(enum234_0));
		}
		if (bool_7)
		{
			writer.WriteAttributeString("iterate", bool_7 ? "1" : "0");
		}
		if (uint_4 != 100)
		{
			writer.WriteAttributeString("iterateCount", XmlConvert.ToString(uint_4));
		}
		if (double_1 != 0.001)
		{
			writer.WriteAttributeString("iterateDelta", XmlConvert.ToString(double_1));
		}
		if (!bool_8)
		{
			writer.WriteAttributeString("fullPrecision", bool_8 ? "1" : "0");
		}
		if (!bool_9)
		{
			writer.WriteAttributeString("calcCompleted", bool_9 ? "1" : "0");
		}
		if (!bool_10)
		{
			writer.WriteAttributeString("calcOnSave", bool_10 ? "1" : "0");
		}
		if (!bool_11)
		{
			writer.WriteAttributeString("concurrentCalc", bool_11 ? "1" : "0");
		}
		if (uint_5 != uint.MaxValue)
		{
			writer.WriteAttributeString("concurrentManualCount", XmlConvert.ToString(uint_5));
		}
		if (nullableBool_1 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("forceFullCalc", (nullableBool_1 == NullableBool.True) ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
