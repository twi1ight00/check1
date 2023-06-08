using System;
using System.Xml;

namespace ns56;

internal class Class1770 : Class1351
{
	public delegate Class1770 Delegate1189();

	public delegate void Delegate1190(Class1770 elementData);

	public delegate void Delegate1191(Class1770 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = true;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const bool bool_4 = true;

	public const double double_0 = double.NaN;

	public const bool bool_5 = false;

	public const uint uint_0 = uint.MaxValue;

	public const byte byte_0 = 0;

	public const byte byte_1 = 0;

	public const byte byte_2 = 0;

	public const uint uint_1 = uint.MaxValue;

	public const bool bool_6 = false;

	public const bool bool_7 = false;

	public const bool bool_8 = false;

	public const bool bool_9 = false;

	public Class1383.Delegate111 delegate111_0;

	public Class1383.Delegate113 delegate113_0;

	public Class1616.Delegate727 delegate727_0;

	public Class1616.Delegate729 delegate729_0;

	public Class1726.Delegate1057 delegate1057_0;

	public Class1726.Delegate1059 delegate1059_0;

	public Class1390.Delegate132 delegate132_0;

	public Class1390.Delegate134 delegate134_0;

	public Class1392.Delegate138 delegate138_0;

	public Class1392.Delegate140 delegate140_0;

	public Class1495.Delegate362 delegate362_0;

	public Class1495.Delegate364 delegate364_0;

	public Class1575.Delegate604 delegate604_0;

	public Class1575.Delegate606 delegate606_0;

	public Class1573.Delegate598 delegate598_0;

	public Class1573.Delegate600 delegate600_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private string string_0;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	private bool bool_14;

	private string string_1;

	private double double_1;

	private bool bool_15;

	private uint uint_2;

	private byte byte_3;

	private byte byte_4;

	private byte byte_5;

	private uint uint_3;

	private bool bool_16;

	private bool bool_17;

	private bool bool_18;

	private bool bool_19;

	private Class1385 class1385_0;

	private Class1382 class1382_0;

	private Class1383 class1383_0;

	private Class1616 class1616_0;

	private Class1726 class1726_0;

	private Class1390 class1390_0;

	private Class1392 class1392_0;

	private Class1495 class1495_0;

	private Class1575 class1575_0;

	private Class1573 class1573_0;

	private Class1502 class1502_0;

	public string R_Id
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

	public bool Invalid
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

	public bool SaveData
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

	public bool RefreshOnLoad
	{
		get
		{
			return bool_12;
		}
		set
		{
			bool_12 = value;
		}
	}

	public bool OptimizeMemory
	{
		get
		{
			return bool_13;
		}
		set
		{
			bool_13 = value;
		}
	}

	public bool EnableRefresh
	{
		get
		{
			return bool_14;
		}
		set
		{
			bool_14 = value;
		}
	}

	public string RefreshedBy
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

	public double RefreshedDate
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

	public bool BackgroundQuery
	{
		get
		{
			return bool_15;
		}
		set
		{
			bool_15 = value;
		}
	}

	public uint MissingItemsLimit
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	public byte CreatedVersion
	{
		get
		{
			return byte_3;
		}
		set
		{
			byte_3 = value;
		}
	}

	public byte RefreshedVersion
	{
		get
		{
			return byte_4;
		}
		set
		{
			byte_4 = value;
		}
	}

	public byte MinRefreshableVersion
	{
		get
		{
			return byte_5;
		}
		set
		{
			byte_5 = value;
		}
	}

	public uint RecordCount
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

	public bool UpgradeOnRefresh
	{
		get
		{
			return bool_16;
		}
		set
		{
			bool_16 = value;
		}
	}

	public bool TupleCacheAttr
	{
		get
		{
			return bool_17;
		}
		set
		{
			bool_17 = value;
		}
	}

	public bool SupportSubquery
	{
		get
		{
			return bool_18;
		}
		set
		{
			bool_18 = value;
		}
	}

	public bool SupportAdvancedDrill
	{
		get
		{
			return bool_19;
		}
		set
		{
			bool_19 = value;
		}
	}

	public Class1385 CacheSource => class1385_0;

	public Class1382 CacheFields => class1382_0;

	public Class1383 CacheHierarchies => class1383_0;

	public Class1616 Kpis => class1616_0;

	public Class1726 TupleCache => class1726_0;

	public Class1390 CalculatedItems => class1390_0;

	public Class1392 CalculatedMembers => class1392_0;

	public Class1495 Dimensions => class1495_0;

	public Class1575 MeasureGroups => class1575_0;

	public Class1573 Maps => class1573_0;

	public Class1502 ExtLst => class1502_0;

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
				case "cacheSource":
					class1385_0 = new Class1385(reader);
					break;
				case "cacheFields":
					class1382_0 = new Class1382(reader);
					break;
				case "cacheHierarchies":
					class1383_0 = new Class1383(reader);
					break;
				case "kpis":
					class1616_0 = new Class1616(reader);
					break;
				case "tupleCache":
					class1726_0 = new Class1726(reader);
					break;
				case "calculatedItems":
					class1390_0 = new Class1390(reader);
					break;
				case "calculatedMembers":
					class1392_0 = new Class1392(reader);
					break;
				case "dimensions":
					class1495_0 = new Class1495(reader);
					break;
				case "measureGroups":
					class1575_0 = new Class1575(reader);
					break;
				case "maps":
					class1573_0 = new Class1573(reader);
					break;
				case "extLst":
					class1502_0 = new Class1502(reader);
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
				case "r:id":
					string_0 = reader.Value;
					break;
				case "invalid":
					bool_10 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "saveData":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "refreshOnLoad":
					bool_12 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "optimizeMemory":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "enableRefresh":
					bool_14 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "refreshedBy":
					string_1 = reader.Value;
					break;
				case "refreshedDate":
					double_1 = ToDouble(reader.Value);
					break;
				case "backgroundQuery":
					bool_15 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "missingItemsLimit":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "createdVersion":
					byte_3 = XmlConvert.ToByte(reader.Value);
					break;
				case "refreshedVersion":
					byte_4 = XmlConvert.ToByte(reader.Value);
					break;
				case "minRefreshableVersion":
					byte_5 = XmlConvert.ToByte(reader.Value);
					break;
				case "recordCount":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "upgradeOnRefresh":
					bool_16 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "tupleCache":
					bool_17 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "supportSubquery":
					bool_18 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "supportAdvancedDrill":
					bool_19 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1770(XmlReader reader)
		: base(reader)
	{
	}

	public Class1770()
	{
	}

	protected override void vmethod_1()
	{
		bool_10 = false;
		bool_11 = true;
		bool_12 = false;
		bool_13 = false;
		bool_14 = true;
		double_1 = double.NaN;
		bool_15 = false;
		uint_2 = uint.MaxValue;
		byte_3 = 0;
		byte_4 = 0;
		byte_5 = 0;
		uint_3 = uint.MaxValue;
		bool_16 = false;
		bool_17 = false;
		bool_18 = false;
		bool_19 = false;
	}

	protected override void vmethod_2()
	{
		delegate111_0 = method_3;
		delegate113_0 = method_4;
		delegate727_0 = method_5;
		delegate729_0 = method_6;
		delegate1057_0 = method_7;
		delegate1059_0 = method_8;
		delegate132_0 = method_9;
		delegate134_0 = method_10;
		delegate138_0 = method_11;
		delegate140_0 = method_12;
		delegate362_0 = method_13;
		delegate364_0 = method_14;
		delegate604_0 = method_15;
		delegate606_0 = method_16;
		delegate598_0 = method_17;
		delegate600_0 = method_18;
		delegate385_0 = method_19;
		delegate387_0 = method_20;
	}

	protected override void vmethod_3()
	{
		class1385_0 = new Class1385();
		class1382_0 = new Class1382();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("ssml", elementName, "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("r:id", string_0);
		}
		if (bool_10)
		{
			writer.WriteAttributeString("invalid", bool_10 ? "1" : "0");
		}
		if (!bool_11)
		{
			writer.WriteAttributeString("saveData", bool_11 ? "1" : "0");
		}
		if (bool_12)
		{
			writer.WriteAttributeString("refreshOnLoad", bool_12 ? "1" : "0");
		}
		if (bool_13)
		{
			writer.WriteAttributeString("optimizeMemory", bool_13 ? "1" : "0");
		}
		if (!bool_14)
		{
			writer.WriteAttributeString("enableRefresh", bool_14 ? "1" : "0");
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("refreshedBy", string_1);
		}
		if (!double.IsNaN(double_1))
		{
			writer.WriteAttributeString("refreshedDate", XmlConvert.ToString(double_1));
		}
		if (bool_15)
		{
			writer.WriteAttributeString("backgroundQuery", bool_15 ? "1" : "0");
		}
		if (uint_2 != uint.MaxValue)
		{
			writer.WriteAttributeString("missingItemsLimit", XmlConvert.ToString(uint_2));
		}
		if (byte_3 != 0)
		{
			writer.WriteAttributeString("createdVersion", XmlConvert.ToString(byte_3));
		}
		if (byte_4 != 0)
		{
			writer.WriteAttributeString("refreshedVersion", XmlConvert.ToString(byte_4));
		}
		if (byte_5 != 0)
		{
			writer.WriteAttributeString("minRefreshableVersion", XmlConvert.ToString(byte_5));
		}
		if (uint_3 != uint.MaxValue)
		{
			writer.WriteAttributeString("recordCount", XmlConvert.ToString(uint_3));
		}
		if (bool_16)
		{
			writer.WriteAttributeString("upgradeOnRefresh", bool_16 ? "1" : "0");
		}
		if (bool_17)
		{
			writer.WriteAttributeString("tupleCache", bool_17 ? "1" : "0");
		}
		if (bool_18)
		{
			writer.WriteAttributeString("supportSubquery", bool_18 ? "1" : "0");
		}
		if (bool_19)
		{
			writer.WriteAttributeString("supportAdvancedDrill", bool_19 ? "1" : "0");
		}
		class1385_0.vmethod_4("ssml", writer, "cacheSource");
		class1382_0.vmethod_4("ssml", writer, "cacheFields");
		if (class1383_0 != null)
		{
			class1383_0.vmethod_4("ssml", writer, "cacheHierarchies");
		}
		if (class1616_0 != null)
		{
			class1616_0.vmethod_4("ssml", writer, "kpis");
		}
		if (class1726_0 != null)
		{
			class1726_0.vmethod_4("ssml", writer, "tupleCache");
		}
		if (class1390_0 != null)
		{
			class1390_0.vmethod_4("ssml", writer, "calculatedItems");
		}
		if (class1392_0 != null)
		{
			class1392_0.vmethod_4("ssml", writer, "calculatedMembers");
		}
		if (class1495_0 != null)
		{
			class1495_0.vmethod_4("ssml", writer, "dimensions");
		}
		if (class1575_0 != null)
		{
			class1575_0.vmethod_4("ssml", writer, "measureGroups");
		}
		if (class1573_0 != null)
		{
			class1573_0.vmethod_4("ssml", writer, "maps");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1383 method_3()
	{
		if (class1383_0 != null)
		{
			throw new Exception("Only one <cacheHierarchies> element can be added.");
		}
		class1383_0 = new Class1383();
		return class1383_0;
	}

	private void method_4(Class1383 _cacheHierarchies)
	{
		class1383_0 = _cacheHierarchies;
	}

	private Class1616 method_5()
	{
		if (class1616_0 != null)
		{
			throw new Exception("Only one <kpis> element can be added.");
		}
		class1616_0 = new Class1616();
		return class1616_0;
	}

	private void method_6(Class1616 _kpis)
	{
		class1616_0 = _kpis;
	}

	private Class1726 method_7()
	{
		if (class1726_0 != null)
		{
			throw new Exception("Only one <tupleCache> element can be added.");
		}
		class1726_0 = new Class1726();
		return class1726_0;
	}

	private void method_8(Class1726 _tupleCache)
	{
		class1726_0 = _tupleCache;
	}

	private Class1390 method_9()
	{
		if (class1390_0 != null)
		{
			throw new Exception("Only one <calculatedItems> element can be added.");
		}
		class1390_0 = new Class1390();
		return class1390_0;
	}

	private void method_10(Class1390 _calculatedItems)
	{
		class1390_0 = _calculatedItems;
	}

	private Class1392 method_11()
	{
		if (class1392_0 != null)
		{
			throw new Exception("Only one <calculatedMembers> element can be added.");
		}
		class1392_0 = new Class1392();
		return class1392_0;
	}

	private void method_12(Class1392 _calculatedMembers)
	{
		class1392_0 = _calculatedMembers;
	}

	private Class1495 method_13()
	{
		if (class1495_0 != null)
		{
			throw new Exception("Only one <dimensions> element can be added.");
		}
		class1495_0 = new Class1495();
		return class1495_0;
	}

	private void method_14(Class1495 _dimensions)
	{
		class1495_0 = _dimensions;
	}

	private Class1575 method_15()
	{
		if (class1575_0 != null)
		{
			throw new Exception("Only one <measureGroups> element can be added.");
		}
		class1575_0 = new Class1575();
		return class1575_0;
	}

	private void method_16(Class1575 _measureGroups)
	{
		class1575_0 = _measureGroups;
	}

	private Class1573 method_17()
	{
		if (class1573_0 != null)
		{
			throw new Exception("Only one <maps> element can be added.");
		}
		class1573_0 = new Class1573();
		return class1573_0;
	}

	private void method_18(Class1573 _maps)
	{
		class1573_0 = _maps;
	}

	private Class1502 method_19()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_20(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
