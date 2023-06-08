using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class2168 : Class1351
{
	public delegate Class2168 Delegate2236();

	public delegate void Delegate2237(Class2168 elementData);

	public delegate void Delegate2238(Class2168 elementData);

	public const int int_0 = 0;

	public const int int_1 = 0;

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const NullableBool nullableBool_1 = NullableBool.NotDefined;

	public const int int_2 = 0;

	public const NullableBool nullableBool_2 = NullableBool.NotDefined;

	public const NullableBool nullableBool_3 = NullableBool.NotDefined;

	public const int int_3 = 0;

	public const int int_4 = 0;

	public const int int_5 = 0;

	public const int int_6 = 0;

	public const NullableBool nullableBool_4 = NullableBool.NotDefined;

	public const int int_7 = 0;

	public const int int_8 = 0;

	public const int int_9 = 0;

	public const int int_10 = 0;

	public const int int_11 = 0;

	public const int int_12 = 0;

	public Class2172.Delegate2248 delegate2248_0;

	public Class2172.Delegate2250 delegate2250_0;

	public Class1922.Delegate1633 delegate1633_0;

	public Class1922.Delegate1635 delegate1635_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private int int_13;

	private int int_14;

	private string string_3;

	private string string_4;

	private string string_5;

	private string string_6;

	private string string_7;

	private string string_8;

	private NullableBool nullableBool_5;

	private string string_9;

	private NullableBool nullableBool_6;

	private int int_15;

	private NullableBool nullableBool_7;

	private NullableBool nullableBool_8;

	private int int_16;

	private int int_17;

	private int int_18;

	private int int_19;

	private NullableBool nullableBool_9;

	private int int_20;

	private int int_21;

	private int int_22;

	private int int_23;

	private int int_24;

	private int int_25;

	private Class2172 class2172_0;

	private Class1922 class1922_0;

	public string PresAssocID
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

	public string PresName
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

	public string PresStyleLbl
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

	public int PresStyleIdx
	{
		get
		{
			return int_13;
		}
		set
		{
			int_13 = value;
		}
	}

	public int PresStyleCnt
	{
		get
		{
			return int_14;
		}
		set
		{
			int_14 = value;
		}
	}

	public string LoTypeId
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

	public string LoCatId
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

	public string QsTypeId
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

	public string QsCatId
	{
		get
		{
			return string_6;
		}
		set
		{
			string_6 = value;
		}
	}

	public string CsTypeId
	{
		get
		{
			return string_7;
		}
		set
		{
			string_7 = value;
		}
	}

	public string CsCatId
	{
		get
		{
			return string_8;
		}
		set
		{
			string_8 = value;
		}
	}

	public NullableBool Coherent3DOff
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

	public string PhldrT
	{
		get
		{
			return string_9;
		}
		set
		{
			string_9 = value;
		}
	}

	public NullableBool Phldr
	{
		get
		{
			return nullableBool_6;
		}
		set
		{
			nullableBool_6 = value;
		}
	}

	public int CustAng
	{
		get
		{
			return int_15;
		}
		set
		{
			int_15 = value;
		}
	}

	public NullableBool CustFlipVert
	{
		get
		{
			return nullableBool_7;
		}
		set
		{
			nullableBool_7 = value;
		}
	}

	public NullableBool CustFlipHor
	{
		get
		{
			return nullableBool_8;
		}
		set
		{
			nullableBool_8 = value;
		}
	}

	public int CustSzX
	{
		get
		{
			return int_16;
		}
		set
		{
			int_16 = value;
		}
	}

	public int CustSzY
	{
		get
		{
			return int_17;
		}
		set
		{
			int_17 = value;
		}
	}

	public int CustScaleX
	{
		get
		{
			return int_18;
		}
		set
		{
			int_18 = value;
		}
	}

	public int CustScaleY
	{
		get
		{
			return int_19;
		}
		set
		{
			int_19 = value;
		}
	}

	public NullableBool CustT
	{
		get
		{
			return nullableBool_9;
		}
		set
		{
			nullableBool_9 = value;
		}
	}

	public int CustLinFactX
	{
		get
		{
			return int_20;
		}
		set
		{
			int_20 = value;
		}
	}

	public int CustLinFactY
	{
		get
		{
			return int_21;
		}
		set
		{
			int_21 = value;
		}
	}

	public int CustLinFactNeighborX
	{
		get
		{
			return int_22;
		}
		set
		{
			int_22 = value;
		}
	}

	public int CustLinFactNeighborY
	{
		get
		{
			return int_23;
		}
		set
		{
			int_23 = value;
		}
	}

	public int CustRadScaleRad
	{
		get
		{
			return int_24;
		}
		set
		{
			int_24 = value;
		}
	}

	public int CustRadScaleInc
	{
		get
		{
			return int_25;
		}
		set
		{
			int_25 = value;
		}
	}

	public Class2172 PresLayoutVars => class2172_0;

	public Class1922 Style => class1922_0;

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
				case "style":
					class1922_0 = new Class1922(reader);
					break;
				case "presLayoutVars":
					class2172_0 = new Class2172(reader);
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
				case "presAssocID":
					string_0 = reader.Value;
					break;
				case "presName":
					string_1 = reader.Value;
					break;
				case "presStyleLbl":
					string_2 = reader.Value;
					break;
				case "presStyleIdx":
					int_13 = XmlConvert.ToInt32(reader.Value);
					break;
				case "presStyleCnt":
					int_14 = XmlConvert.ToInt32(reader.Value);
					break;
				case "loTypeId":
					string_3 = reader.Value;
					break;
				case "loCatId":
					string_4 = reader.Value;
					break;
				case "qsTypeId":
					string_5 = reader.Value;
					break;
				case "qsCatId":
					string_6 = reader.Value;
					break;
				case "csTypeId":
					string_7 = reader.Value;
					break;
				case "csCatId":
					string_8 = reader.Value;
					break;
				case "coherent3DOff":
					nullableBool_5 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "phldrT":
					string_9 = reader.Value;
					break;
				case "phldr":
					nullableBool_6 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "custAng":
					int_15 = XmlConvert.ToInt32(reader.Value);
					break;
				case "custFlipVert":
					nullableBool_7 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "custFlipHor":
					nullableBool_8 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "custSzX":
					int_16 = XmlConvert.ToInt32(reader.Value);
					break;
				case "custSzY":
					int_17 = XmlConvert.ToInt32(reader.Value);
					break;
				case "custScaleX":
					int_18 = XmlConvert.ToInt32(reader.Value);
					break;
				case "custScaleY":
					int_19 = XmlConvert.ToInt32(reader.Value);
					break;
				case "custT":
					nullableBool_9 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "custLinFactX":
					int_20 = XmlConvert.ToInt32(reader.Value);
					break;
				case "custLinFactY":
					int_21 = XmlConvert.ToInt32(reader.Value);
					break;
				case "custLinFactNeighborX":
					int_22 = XmlConvert.ToInt32(reader.Value);
					break;
				case "custLinFactNeighborY":
					int_23 = XmlConvert.ToInt32(reader.Value);
					break;
				case "custRadScaleRad":
					int_24 = XmlConvert.ToInt32(reader.Value);
					break;
				case "custRadScaleInc":
					int_25 = XmlConvert.ToInt32(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2168(XmlReader reader)
		: base(reader)
	{
	}

	public Class2168()
	{
	}

	protected override void vmethod_1()
	{
		int_13 = 0;
		int_14 = 0;
		nullableBool_5 = NullableBool.NotDefined;
		nullableBool_6 = NullableBool.NotDefined;
		int_15 = 0;
		nullableBool_7 = NullableBool.NotDefined;
		nullableBool_8 = NullableBool.NotDefined;
		int_16 = 0;
		int_17 = 0;
		int_18 = 0;
		int_19 = 0;
		nullableBool_9 = NullableBool.NotDefined;
		int_20 = 0;
		int_21 = 0;
		int_22 = 0;
		int_23 = 0;
		int_24 = 0;
		int_25 = 0;
	}

	protected override void vmethod_2()
	{
		delegate2248_0 = method_3;
		delegate2250_0 = method_4;
		delegate1633_0 = method_5;
		delegate1635_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_0 != null)
		{
			writer.WriteAttributeString("presAssocID", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("presName", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("presStyleLbl", string_2);
		}
		if (int_13 != 0)
		{
			writer.WriteAttributeString("presStyleIdx", XmlConvert.ToString(int_13));
		}
		if (int_14 != 0)
		{
			writer.WriteAttributeString("presStyleCnt", XmlConvert.ToString(int_14));
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("loTypeId", string_3);
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("loCatId", string_4);
		}
		if (string_5 != null)
		{
			writer.WriteAttributeString("qsTypeId", string_5);
		}
		if (string_6 != null)
		{
			writer.WriteAttributeString("qsCatId", string_6);
		}
		if (string_7 != null)
		{
			writer.WriteAttributeString("csTypeId", string_7);
		}
		if (string_8 != null)
		{
			writer.WriteAttributeString("csCatId", string_8);
		}
		if (nullableBool_5 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("coherent3DOff", (nullableBool_5 == NullableBool.True) ? "1" : "0");
		}
		if (string_9 != null)
		{
			writer.WriteAttributeString("phldrT", string_9);
		}
		if (nullableBool_6 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("phldr", (nullableBool_6 == NullableBool.True) ? "1" : "0");
		}
		if (int_15 != 0)
		{
			writer.WriteAttributeString("custAng", XmlConvert.ToString(int_15));
		}
		if (nullableBool_7 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("custFlipVert", (nullableBool_7 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_8 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("custFlipHor", (nullableBool_8 == NullableBool.True) ? "1" : "0");
		}
		if (int_16 != 0)
		{
			writer.WriteAttributeString("custSzX", XmlConvert.ToString(int_16));
		}
		if (int_17 != 0)
		{
			writer.WriteAttributeString("custSzY", XmlConvert.ToString(int_17));
		}
		if (int_18 != 0)
		{
			writer.WriteAttributeString("custScaleX", XmlConvert.ToString(int_18));
		}
		if (int_19 != 0)
		{
			writer.WriteAttributeString("custScaleY", XmlConvert.ToString(int_19));
		}
		if (nullableBool_9 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("custT", (nullableBool_9 == NullableBool.True) ? "1" : "0");
		}
		if (int_20 != 0)
		{
			writer.WriteAttributeString("custLinFactX", XmlConvert.ToString(int_20));
		}
		if (int_21 != 0)
		{
			writer.WriteAttributeString("custLinFactY", XmlConvert.ToString(int_21));
		}
		if (int_22 != 0)
		{
			writer.WriteAttributeString("custLinFactNeighborX", XmlConvert.ToString(int_22));
		}
		if (int_23 != 0)
		{
			writer.WriteAttributeString("custLinFactNeighborY", XmlConvert.ToString(int_23));
		}
		if (int_24 != 0)
		{
			writer.WriteAttributeString("custRadScaleRad", XmlConvert.ToString(int_24));
		}
		if (int_25 != 0)
		{
			writer.WriteAttributeString("custRadScaleInc", XmlConvert.ToString(int_25));
		}
		if (class2172_0 != null)
		{
			class2172_0.vmethod_4("dgm", writer, "presLayoutVars");
		}
		if (class1922_0 != null)
		{
			class1922_0.vmethod_4("dgm", writer, "style");
		}
		writer.WriteEndElement();
	}

	private Class2172 method_3()
	{
		if (class2172_0 != null)
		{
			throw new Exception("Only one <presLayoutVars> element can be added.");
		}
		class2172_0 = new Class2172();
		return class2172_0;
	}

	private void method_4(Class2172 _presLayoutVars)
	{
		class2172_0 = _presLayoutVars;
	}

	private Class1922 method_5()
	{
		if (class1922_0 != null)
		{
			throw new Exception("Only one <style> element can be added.");
		}
		class1922_0 = new Class1922();
		return class1922_0;
	}

	private void method_6(Class1922 _style)
	{
		class1922_0 = _style;
	}
}
