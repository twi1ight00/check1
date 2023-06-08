using System;
using System.Globalization;
using System.Xml;

namespace ns56;

internal class Class1662 : Class1351
{
	public delegate Class1662 Delegate865();

	public delegate void Delegate866(Class1662 elementData);

	public delegate void Delegate867(Class1662 elementData);

	public const uint uint_0 = uint.MaxValue;

	public const uint uint_1 = uint.MaxValue;

	public Class1655.Delegate844 delegate844_0;

	public Class1655.Delegate846 delegate846_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private Guid guid_0;

	private DateTime dateTime_0;

	private uint uint_2;

	private string string_0;

	private string string_1;

	private uint uint_3;

	private uint uint_4;

	private Class1693 class1693_0;

	private Class1655 class1655_0;

	private Class1502 class1502_0;

	public Guid Guid
	{
		get
		{
			return guid_0;
		}
		set
		{
			guid_0 = value;
		}
	}

	public DateTime DateTime
	{
		get
		{
			return dateTime_0;
		}
		set
		{
			dateTime_0 = value;
		}
	}

	public uint MaxSheetId
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

	public string UserName
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

	public string R_Id
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

	public uint MinRId
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

	public uint MaxRId
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

	public Class1693 SheetIdMap => class1693_0;

	public Class1655 ReviewedList => class1655_0;

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
				case "extLst":
					class1502_0 = new Class1502(reader);
					break;
				case "reviewedList":
					class1655_0 = new Class1655(reader);
					break;
				case "sheetIdMap":
					class1693_0 = new Class1693(reader);
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
				case "guid":
					guid_0 = new Guid(reader.Value);
					break;
				case "dateTime":
					dateTime_0 = DateTime.Parse(reader.Value, CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal);
					break;
				case "maxSheetId":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "userName":
					string_0 = reader.Value;
					break;
				case "r:id":
					string_1 = reader.Value;
					break;
				case "minRId":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "maxRId":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1662(XmlReader reader)
		: base(reader)
	{
	}

	public Class1662()
	{
	}

	protected override void vmethod_1()
	{
		guid_0 = Guid.Empty;
		dateTime_0 = DateTime.MinValue;
		uint_3 = uint.MaxValue;
		uint_4 = uint.MaxValue;
	}

	protected override void vmethod_2()
	{
		delegate844_0 = method_3;
		delegate846_0 = method_4;
		delegate385_0 = method_5;
		delegate387_0 = method_6;
	}

	protected override void vmethod_3()
	{
		class1693_0 = new Class1693();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("guid", "{" + XmlConvert.ToString(guid_0).ToUpper() + "}");
		writer.WriteAttributeString("dateTime", XmlConvert.ToString(dateTime_0, "yyyy-MM-ddTHH:mm:ss.fff"));
		writer.WriteAttributeString("maxSheetId", XmlConvert.ToString(uint_2));
		writer.WriteAttributeString("userName", string_0);
		writer.WriteAttributeString("r:id", string_1);
		if (uint_3 != uint.MaxValue)
		{
			writer.WriteAttributeString("minRId", XmlConvert.ToString(uint_3));
		}
		if (uint_4 != uint.MaxValue)
		{
			writer.WriteAttributeString("maxRId", XmlConvert.ToString(uint_4));
		}
		class1693_0.vmethod_4("ssml", writer, "sheetIdMap");
		if (class1655_0 != null)
		{
			class1655_0.vmethod_4("ssml", writer, "reviewedList");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1655 method_3()
	{
		if (class1655_0 != null)
		{
			throw new Exception("Only one <reviewedList> element can be added.");
		}
		class1655_0 = new Class1655();
		return class1655_0;
	}

	private void method_4(Class1655 _reviewedList)
	{
		class1655_0 = _reviewedList;
	}

	private Class1502 method_5()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_6(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
