using System;
using System.Xml;
using Aspose.Slides;
using ns57;

namespace ns56;

internal class Class2283 : Class1351
{
	public delegate Class2283 Delegate2596();

	public delegate void Delegate2597(Class2283 elementData);

	public delegate void Delegate2598(Class2283 elementData);

	public const int int_0 = -1;

	public const long long_0 = -2147483649L;

	public const Enum296 enum296_0 = Enum296.const_0;

	public const long long_1 = -2147483649L;

	public const string string_0 = "1000";

	public const float float_0 = 100f;

	public const float float_1 = 0f;

	public const float float_2 = 0f;

	public const bool bool_0 = false;

	public const Enum298 enum298_0 = Enum298.const_0;

	public const Enum289 enum289_0 = Enum289.const_0;

	public const Enum300 enum300_0 = Enum300.const_0;

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const Enum293 enum293_0 = Enum293.const_0;

	public const int int_1 = -1;

	public const uint uint_0 = uint.MaxValue;

	public const NullableBool nullableBool_1 = NullableBool.NotDefined;

	public const Enum303 enum303_0 = Enum303.const_0;

	public const NullableBool nullableBool_2 = NullableBool.NotDefined;

	public const float float_3 = float.NaN;

	public Class2302.Delegate2653 delegate2653_0;

	public Class2302.Delegate2655 delegate2655_0;

	public Class2302.Delegate2653 delegate2653_1;

	public Class2302.Delegate2655 delegate2655_1;

	public Class2301.Delegate2650 delegate2650_0;

	public Class2301.Delegate2652 delegate2652_0;

	public Class2285.Delegate2602 delegate2602_0;

	public Class2285.Delegate2604 delegate2604_0;

	public Class2264.Delegate2539 delegate2539_0;

	public Class2264.Delegate2541 delegate2541_0;

	public Class2264.Delegate2539 delegate2539_1;

	public Class2264.Delegate2541 delegate2541_1;

	private int int_2;

	private long long_2;

	private Enum296 enum296_1;

	private long long_3;

	private string string_1;

	private string string_2;

	private string string_3;

	private float float_4;

	private float float_5;

	private float float_6;

	private bool bool_1;

	private Enum298 enum298_1;

	private Enum289 enum289_1;

	private Enum300 enum300_1;

	private string string_4;

	private string string_5;

	private NullableBool nullableBool_3;

	private Enum293 enum293_1;

	private int int_3;

	private uint uint_1;

	private NullableBool nullableBool_4;

	private Enum303 enum303_1;

	private NullableBool nullableBool_5;

	private float float_7;

	private Class2302 class2302_0;

	private Class2302 class2302_1;

	private Class2301 class2301_0;

	private Class2285 class2285_0;

	private Class2264 class2264_0;

	private Class2264 class2264_1;

	public int Id
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

	public long PresetID
	{
		get
		{
			return long_2;
		}
		set
		{
			long_2 = value;
		}
	}

	public Enum296 PresetClass
	{
		get
		{
			return enum296_1;
		}
		set
		{
			enum296_1 = value;
		}
	}

	public long PresetSubtype
	{
		get
		{
			return long_3;
		}
		set
		{
			long_3 = value;
		}
	}

	public string Dur
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

	public string RepeatCount
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public string RepeatDur
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public float Spd
	{
		get
		{
			return float_4;
		}
		set
		{
			float_4 = value;
		}
	}

	public float Accel
	{
		get
		{
			return float_5;
		}
		set
		{
			float_5 = value;
		}
	}

	public float Decel
	{
		get
		{
			return float_6;
		}
		set
		{
			float_6 = value;
		}
	}

	public bool AutoRev
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public Enum298 Restart
	{
		get
		{
			return enum298_1;
		}
		set
		{
			enum298_1 = value;
		}
	}

	public Enum289 Fill
	{
		get
		{
			return enum289_1;
		}
		set
		{
			enum289_1 = value;
		}
	}

	public Enum300 SyncBehavior
	{
		get
		{
			return enum300_1;
		}
		set
		{
			enum300_1 = value;
		}
	}

	public string TmFilter
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public string EvtFilter
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public NullableBool Display
	{
		get
		{
			return nullableBool_3;
		}
		set
		{
			nullableBool_3 = value;
		}
	}

	public Enum293 MasterRel
	{
		get
		{
			return enum293_1;
		}
		set
		{
			enum293_1 = value;
		}
	}

	public int BldLvl
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public uint GrpId
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

	public NullableBool AfterEffect
	{
		get
		{
			return nullableBool_4;
		}
		set
		{
			nullableBool_4 = value;
		}
	}

	public Enum303 NodeType
	{
		get
		{
			return enum303_1;
		}
		set
		{
			enum303_1 = value;
		}
	}

	public NullableBool NodePh
	{
		get
		{
			return nullableBool_5;
		}
		set
		{
			nullableBool_5 = value;
		}
	}

	public float P14_PresetBounceEnd
	{
		get
		{
			return float_7;
		}
		set
		{
			float_7 = value;
		}
	}

	public Class2302 StCondLst => class2302_0;

	public Class2302 EndCondLst => class2302_1;

	public Class2301 EndSync => class2301_0;

	public Class2285 Iterate => class2285_0;

	public Class2264 ChildTnLst => class2264_0;

	public Class2264 SubTnLst => class2264_1;

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
				case "stCondLst":
					class2302_0 = new Class2302(reader);
					break;
				case "endCondLst":
					class2302_1 = new Class2302(reader);
					break;
				case "endSync":
					class2301_0 = new Class2301(reader);
					break;
				case "iterate":
					class2285_0 = new Class2285(reader);
					break;
				case "childTnLst":
					class2264_0 = new Class2264(reader);
					break;
				case "subTnLst":
					class2264_1 = new Class2264(reader);
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
				case "id":
					int_2 = XmlConvert.ToInt32(reader.Value);
					break;
				case "presetID":
					long_2 = XmlConvert.ToInt32(reader.Value);
					break;
				case "presetClass":
					enum296_1 = Class2596.smethod_0(reader.Value);
					break;
				case "presetSubtype":
					long_3 = XmlConvert.ToInt32(reader.Value);
					break;
				case "dur":
					string_1 = reader.Value;
					break;
				case "repeatCount":
					string_2 = reader.Value;
					break;
				case "repeatDur":
					string_3 = reader.Value;
					break;
				case "spd":
					float_4 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "accel":
					float_5 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "decel":
					float_6 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "autoRev":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "restart":
					enum298_1 = Class2597.smethod_0(reader.Value);
					break;
				case "fill":
					enum289_1 = Class2594.smethod_0(reader.Value);
					break;
				case "syncBehavior":
					enum300_1 = Class2598.smethod_0(reader.Value);
					break;
				case "tmFilter":
					string_4 = reader.Value;
					break;
				case "evtFilter":
					string_5 = reader.Value;
					break;
				case "display":
					nullableBool_3 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "masterRel":
					enum293_1 = Class2595.smethod_0(reader.Value);
					break;
				case "bldLvl":
					int_3 = XmlConvert.ToInt32(reader.Value);
					break;
				case "grpId":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "afterEffect":
					nullableBool_4 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "nodeType":
					enum303_1 = Class2599.smethod_0(reader.Value);
					break;
				case "nodePh":
					nullableBool_5 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "p14:presetBounceEnd":
					float_7 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2283(XmlReader reader)
		: base(reader)
	{
	}

	public Class2283()
	{
	}

	protected override void vmethod_1()
	{
		int_2 = -1;
		long_2 = -2147483649L;
		enum296_1 = Enum296.const_0;
		long_3 = -2147483649L;
		string_2 = "1000";
		float_4 = 100f;
		float_5 = 0f;
		float_6 = 0f;
		bool_1 = false;
		enum298_1 = Enum298.const_0;
		enum289_1 = Enum289.const_0;
		enum300_1 = Enum300.const_0;
		nullableBool_3 = NullableBool.NotDefined;
		enum293_1 = Enum293.const_0;
		int_3 = -1;
		uint_1 = uint.MaxValue;
		nullableBool_4 = NullableBool.NotDefined;
		enum303_1 = Enum303.const_0;
		nullableBool_5 = NullableBool.NotDefined;
		float_7 = float.NaN;
	}

	protected override void vmethod_2()
	{
		delegate2653_0 = method_3;
		delegate2655_0 = method_4;
		delegate2653_1 = method_5;
		delegate2655_1 = method_6;
		delegate2650_0 = method_7;
		delegate2652_0 = method_8;
		delegate2602_0 = method_9;
		delegate2604_0 = method_10;
		delegate2539_0 = method_11;
		delegate2541_0 = method_12;
		delegate2539_1 = method_13;
		delegate2541_1 = method_14;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (int_2 != -1)
		{
			writer.WriteAttributeString("id", XmlConvert.ToString(int_2));
		}
		if (long_2 != -2147483649L)
		{
			writer.WriteAttributeString("presetID", XmlConvert.ToString(long_2));
		}
		if (enum296_1 != Enum296.const_0)
		{
			writer.WriteAttributeString("presetClass", Class2596.smethod_1(enum296_1));
		}
		if (long_3 != -2147483649L)
		{
			writer.WriteAttributeString("presetSubtype", XmlConvert.ToString(long_3));
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("dur", string_1);
		}
		if (string_2 != "1000")
		{
			writer.WriteAttributeString("repeatCount", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("repeatDur", string_3);
		}
		if (float_4 != 100f)
		{
			writer.WriteAttributeString("spd", XmlConvert.ToString((int)Math.Round(float_4 * 1000f)));
		}
		if (float_5 != 0f)
		{
			writer.WriteAttributeString("accel", XmlConvert.ToString((int)Math.Round(float_5 * 1000f)));
		}
		if (float_6 != 0f)
		{
			writer.WriteAttributeString("decel", XmlConvert.ToString((int)Math.Round(float_6 * 1000f)));
		}
		if (bool_1)
		{
			writer.WriteAttributeString("autoRev", bool_1 ? "1" : "0");
		}
		if (enum298_1 != Enum298.const_0)
		{
			writer.WriteAttributeString("restart", Class2597.smethod_1(enum298_1));
		}
		if (enum289_1 != Enum289.const_0)
		{
			writer.WriteAttributeString("fill", Class2594.smethod_1(enum289_1));
		}
		if (enum300_1 != Enum300.const_0)
		{
			writer.WriteAttributeString("syncBehavior", Class2598.smethod_1(enum300_1));
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("tmFilter", string_4);
		}
		if (string_5 != null)
		{
			writer.WriteAttributeString("evtFilter", string_5);
		}
		if (nullableBool_3 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("display", (nullableBool_3 == NullableBool.True) ? "1" : "0");
		}
		if (enum293_1 != Enum293.const_0)
		{
			writer.WriteAttributeString("masterRel", Class2595.smethod_1(enum293_1));
		}
		if (int_3 != -1)
		{
			writer.WriteAttributeString("bldLvl", XmlConvert.ToString(int_3));
		}
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("grpId", XmlConvert.ToString(uint_1));
		}
		if (nullableBool_4 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("afterEffect", (nullableBool_4 == NullableBool.True) ? "1" : "0");
		}
		if (enum303_1 != Enum303.const_0)
		{
			writer.WriteAttributeString("nodeType", Class2599.smethod_1(enum303_1));
		}
		if (nullableBool_5 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("nodePh", (nullableBool_5 == NullableBool.True) ? "1" : "0");
		}
		if (!float.IsNaN(float_7))
		{
			writer.WriteAttributeString("p14:presetBounceEnd", XmlConvert.ToString((int)Math.Round(float_7 * 1000f)));
		}
		if (class2302_0 != null)
		{
			class2302_0.vmethod_4("p", writer, "stCondLst");
		}
		if (class2302_1 != null)
		{
			class2302_1.vmethod_4("p", writer, "endCondLst");
		}
		if (class2301_0 != null)
		{
			class2301_0.vmethod_4("p", writer, "endSync");
		}
		if (class2285_0 != null)
		{
			class2285_0.vmethod_4("p", writer, "iterate");
		}
		if (class2264_0 != null)
		{
			class2264_0.vmethod_4("p", writer, "childTnLst");
		}
		if (class2264_1 != null)
		{
			class2264_1.vmethod_4("p", writer, "subTnLst");
		}
		writer.WriteEndElement();
	}

	private Class2302 method_3()
	{
		if (class2302_0 != null)
		{
			throw new Exception("Only one <stCondLst> element can be added.");
		}
		class2302_0 = new Class2302();
		return class2302_0;
	}

	private void method_4(Class2302 _stCondLst)
	{
		class2302_0 = _stCondLst;
	}

	private Class2302 method_5()
	{
		if (class2302_1 != null)
		{
			throw new Exception("Only one <endCondLst> element can be added.");
		}
		class2302_1 = new Class2302();
		return class2302_1;
	}

	private void method_6(Class2302 _endCondLst)
	{
		class2302_1 = _endCondLst;
	}

	private Class2301 method_7()
	{
		if (class2301_0 != null)
		{
			throw new Exception("Only one <endSync> element can be added.");
		}
		class2301_0 = new Class2301();
		return class2301_0;
	}

	private void method_8(Class2301 _endSync)
	{
		class2301_0 = _endSync;
	}

	private Class2285 method_9()
	{
		if (class2285_0 != null)
		{
			throw new Exception("Only one <iterate> element can be added.");
		}
		class2285_0 = new Class2285();
		return class2285_0;
	}

	private void method_10(Class2285 _iterate)
	{
		class2285_0 = _iterate;
	}

	private Class2264 method_11()
	{
		if (class2264_0 != null)
		{
			throw new Exception("Only one <childTnLst> element can be added.");
		}
		class2264_0 = new Class2264();
		return class2264_0;
	}

	private void method_12(Class2264 _childTnLst)
	{
		class2264_0 = _childTnLst;
	}

	private Class2264 method_13()
	{
		if (class2264_1 != null)
		{
			throw new Exception("Only one <subTnLst> element can be added.");
		}
		class2264_1 = new Class2264();
		return class2264_1;
	}

	private void method_14(Class2264 _subTnLst)
	{
		class2264_1 = _subTnLst;
	}
}
