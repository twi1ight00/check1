using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1663 : Class1351
{
	public delegate Class1663 Delegate868();

	public delegate void Delegate869(Class1663 elementData);

	public delegate void Delegate870(Class1663 elementData);

	public const bool bool_0 = true;

	public const bool bool_1 = false;

	public const bool bool_2 = true;

	public const bool bool_3 = true;

	public const bool bool_4 = false;

	public const uint uint_0 = 0u;

	public const int int_0 = 1;

	public const bool bool_5 = true;

	public const bool bool_6 = false;

	public const uint uint_1 = 30u;

	public Class1662.Delegate865 delegate865_0;

	public Class1662.Delegate866 delegate866_0;

	private Guid guid_0;

	private Guid guid_1;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private uint uint_2;

	private int int_1;

	private bool bool_12;

	private bool bool_13;

	private uint uint_3;

	private List<Class1662> list_0;

	public static readonly Guid guid_2 = Guid.Empty;

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

	public Guid LastGuid
	{
		get
		{
			return guid_1;
		}
		set
		{
			guid_1 = value;
		}
	}

	public bool Shared
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

	public bool DiskRevisions
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

	public bool History
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

	public bool TrackRevisions
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

	public bool Exclusive
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

	public uint RevisionId
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

	public int Version
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public bool KeepChangeHistory
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

	public bool Protected
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

	public uint PreserveHistory
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

	public Class1662[] HeaderList => list_0.ToArray();

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
				string localName2;
				if ((localName2 = reader.LocalName) != null && localName2 == "header")
				{
					Class1662 item = new Class1662(reader);
					list_0.Add(item);
				}
				else
				{
					reader.Skip();
					flag = true;
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
				case "lastGuid":
					guid_1 = new Guid(reader.Value);
					break;
				case "shared":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "diskRevisions":
					bool_8 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "history":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "trackRevisions":
					bool_10 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "exclusive":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "revisionId":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "version":
					int_1 = XmlConvert.ToInt32(reader.Value);
					break;
				case "keepChangeHistory":
					bool_12 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "protected":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "preserveHistory":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1663(XmlReader reader)
		: base(reader)
	{
	}

	public Class1663()
	{
	}

	protected override void vmethod_1()
	{
		guid_0 = Guid.Empty;
		guid_1 = guid_2;
		bool_7 = true;
		bool_8 = false;
		bool_9 = true;
		bool_10 = true;
		bool_11 = false;
		uint_2 = 0u;
		int_1 = 1;
		bool_12 = true;
		bool_13 = false;
		uint_3 = 30u;
		list_0 = new List<Class1662>();
	}

	protected override void vmethod_2()
	{
		delegate865_0 = method_3;
		delegate866_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("ssml", elementName, "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		writer.WriteAttributeString("guid", "{" + XmlConvert.ToString(guid_0).ToUpper() + "}");
		if (guid_1 != guid_2)
		{
			writer.WriteAttributeString("lastGuid", "{" + XmlConvert.ToString(guid_1).ToUpper() + "}");
		}
		if (!bool_7)
		{
			writer.WriteAttributeString("shared", bool_7 ? "1" : "0");
		}
		if (bool_8)
		{
			writer.WriteAttributeString("diskRevisions", bool_8 ? "1" : "0");
		}
		if (!bool_9)
		{
			writer.WriteAttributeString("history", bool_9 ? "1" : "0");
		}
		if (!bool_10)
		{
			writer.WriteAttributeString("trackRevisions", bool_10 ? "1" : "0");
		}
		if (bool_11)
		{
			writer.WriteAttributeString("exclusive", bool_11 ? "1" : "0");
		}
		if (uint_2 != 0)
		{
			writer.WriteAttributeString("revisionId", XmlConvert.ToString(uint_2));
		}
		if (int_1 != 1)
		{
			writer.WriteAttributeString("version", XmlConvert.ToString(int_1));
		}
		if (!bool_12)
		{
			writer.WriteAttributeString("keepChangeHistory", bool_12 ? "1" : "0");
		}
		if (bool_13)
		{
			writer.WriteAttributeString("protected", bool_13 ? "1" : "0");
		}
		if (uint_3 != 30)
		{
			writer.WriteAttributeString("preserveHistory", XmlConvert.ToString(uint_3));
		}
		foreach (Class1662 item in list_0)
		{
			item.vmethod_4("ssml", writer, "header");
		}
		writer.WriteEndElement();
	}

	private Class1662 method_3()
	{
		Class1662 @class = new Class1662();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1662 elementData)
	{
		list_0.Add(elementData);
	}
}
