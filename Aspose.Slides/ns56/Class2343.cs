using System;
using System.Globalization;
using System.Xml;

namespace ns56;

internal class Class2343 : Class1351
{
	internal delegate Class2343 Delegate2769();

	internal delegate void Delegate2770(Class2343 elementData);

	internal const string string_0 = "";

	internal const string string_1 = "";

	internal const string string_2 = "";

	internal const string string_3 = "";

	internal const string string_4 = "";

	internal const string string_5 = "";

	internal const string string_6 = "";

	internal const string string_7 = "";

	internal const string string_8 = "";

	internal const string string_9 = "";

	private string string_10;

	private string string_11;

	private string string_12;

	private DateTime dateTime_0;

	private string string_13;

	private string string_14;

	private string string_15;

	private string string_16;

	private DateTime dateTime_1;

	private DateTime dateTime_2;

	private string string_17;

	private string string_18;

	private string string_19;

	internal static readonly DateTime dateTime_3 = DateTime.MinValue;

	internal static readonly DateTime dateTime_4 = DateTime.MinValue;

	internal static readonly DateTime dateTime_5 = DateTime.MinValue;

	public string Category
	{
		get
		{
			return string_10;
		}
		set
		{
			string_10 = value;
		}
	}

	public string ContentStatus
	{
		get
		{
			return string_11;
		}
		set
		{
			string_11 = value;
		}
	}

	public string ContentType
	{
		get
		{
			return string_12;
		}
		set
		{
			string_12 = value;
		}
	}

	public DateTime Created
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

	public string Creator
	{
		get
		{
			return string_13;
		}
		set
		{
			string_13 = value;
		}
	}

	public string Description
	{
		get
		{
			return string_14;
		}
		set
		{
			string_14 = value;
		}
	}

	public string Keywords
	{
		get
		{
			return string_15;
		}
		set
		{
			string_15 = value;
		}
	}

	public string LastModifiedBy
	{
		get
		{
			return string_16;
		}
		set
		{
			string_16 = value;
		}
	}

	public DateTime LastPrinted
	{
		get
		{
			return dateTime_1;
		}
		set
		{
			dateTime_1 = value;
		}
	}

	public DateTime Modified
	{
		get
		{
			return dateTime_2;
		}
		set
		{
			dateTime_2 = value;
		}
	}

	public string Revision
	{
		get
		{
			return string_17;
		}
		set
		{
			string_17 = value;
		}
	}

	public string Subject
	{
		get
		{
			return string_18;
		}
		set
		{
			string_18 = value;
		}
	}

	public string Title
	{
		get
		{
			return string_19;
		}
		set
		{
			string_19 = value;
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
				switch (reader.LocalName)
				{
				case "category":
					reader.Read();
					string_10 = reader.Value;
					break;
				case "contentStatus":
					reader.Read();
					string_11 = reader.Value;
					break;
				case "contentType":
					reader.Read();
					string_12 = reader.Value;
					break;
				case "created":
					reader.Read();
					dateTime_0 = DateTime.Parse(reader.Value, CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal);
					break;
				case "creator":
					reader.Read();
					string_13 = reader.Value;
					break;
				case "description":
					reader.Read();
					string_14 = reader.Value;
					break;
				case "identifier":
					reader.Skip();
					flag = true;
					break;
				case "keywords":
					reader.Read();
					string_15 = reader.Value;
					break;
				case "language":
					reader.Skip();
					flag = true;
					break;
				case "lastModifiedBy":
					reader.Read();
					string_16 = reader.Value;
					break;
				case "lastPrinted":
					reader.Read();
					dateTime_1 = DateTime.Parse(reader.Value, CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal);
					break;
				case "modified":
					reader.Read();
					dateTime_2 = DateTime.Parse(reader.Value, CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal);
					break;
				case "revision":
					reader.Read();
					string_17 = reader.Value;
					break;
				case "subject":
					reader.Read();
					string_18 = reader.Value;
					break;
				case "title":
					reader.Read();
					string_19 = reader.Value;
					break;
				case "version":
					reader.Skip();
					flag = true;
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
	}

	public Class2343(XmlReader reader)
		: base(reader)
	{
	}

	public Class2343()
	{
	}

	protected override void vmethod_1()
	{
		string_10 = "";
		string_11 = "";
		string_12 = "";
		dateTime_0 = dateTime_3;
		string_13 = "";
		string_14 = "";
		string_15 = "";
		string_16 = "";
		dateTime_1 = dateTime_4;
		dateTime_2 = dateTime_5;
		string_17 = "";
		string_18 = "";
		string_19 = "";
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("cp", elementName, "http://schemas.openxmlformats.org/package/2006/metadata/core-properties");
		writer.WriteAttributeString("xmlns", "dc", null, "http://purl.org/dc/elements/1.1/");
		writer.WriteAttributeString("xmlns", "dcterms", null, "http://purl.org/dc/terms/");
		writer.WriteAttributeString("xmlns", "dcmitype", null, "http://purl.org/dc/dcmitype/");
		writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
		if (string_19 != "")
		{
			writer.WriteElementString("dc:title", string_19);
		}
		if (string_10 != "")
		{
			writer.WriteElementString("cp:category", string_10);
		}
		if (string_11 != "")
		{
			writer.WriteElementString("cp:contentStatus", string_11);
		}
		if (string_12 != "")
		{
			writer.WriteElementString("cp:contentType", string_12);
		}
		if (string_13 != "")
		{
			writer.WriteElementString("dc:creator", string_13);
		}
		if (string_14 != "")
		{
			writer.WriteElementString("dc:description", string_14);
		}
		if (string_15 != "")
		{
			writer.WriteElementString("cp:keywords", string_15);
		}
		if (string_16 != "")
		{
			writer.WriteElementString("cp:lastModifiedBy", string_16);
		}
		if (string_17 != "")
		{
			writer.WriteElementString("cp:revision", string_17);
		}
		if (dateTime_1 != DateTime.MinValue)
		{
			writer.WriteElementString("cp:lastPrinted", XmlConvert.ToString(dateTime_1, "yyyy-MM-ddTHH:mm:ss.fff"));
		}
		if (dateTime_0 != DateTime.MinValue)
		{
			writer.WriteStartElement("dcterms", "created", null);
			writer.WriteAttributeString("xsi", "type", null, "dcterms:W3CDTF");
			writer.WriteString(XmlConvert.ToString(dateTime_0, "yyyy-MM-ddTHH:mm:ssZ"));
			writer.WriteEndElement();
		}
		if (dateTime_2 != DateTime.MinValue)
		{
			writer.WriteStartElement("dcterms", "modified", null);
			writer.WriteAttributeString("xsi", "type", null, "dcterms:W3CDTF");
			writer.WriteString(XmlConvert.ToString(dateTime_2, "yyyy-MM-ddTHH:mm:ssZ"));
			writer.WriteEndElement();
		}
		if (string_18 != "")
		{
			writer.WriteElementString("dc:subject", string_18);
		}
		writer.WriteEndElement();
	}
}
