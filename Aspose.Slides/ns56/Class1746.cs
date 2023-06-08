using System.Globalization;
using System.Xml;

namespace ns56;

internal class Class1746 : Class1351
{
	public delegate void Delegate1119(Class1746 elementData);

	public delegate Class1746 Delegate1117();

	public delegate void Delegate1118(Class1746 elementData);

	public const ushort ushort_0 = ushort.MaxValue;

	public const ushort ushort_1 = ushort.MaxValue;

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	private ushort ushort_2;

	private ushort ushort_3;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	public ushort WorkbookPassword
	{
		get
		{
			return ushort_2;
		}
		set
		{
			ushort_2 = value;
		}
	}

	public ushort RevisionsPassword
	{
		get
		{
			return ushort_3;
		}
		set
		{
			ushort_3 = value;
		}
	}

	public bool LockStructure
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public bool LockWindows
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public bool LockRevision
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
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
				case "lockRevision":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "lockWindows":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "lockStructure":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "revisionsPassword":
					ushort_3 = ushort.Parse(reader.Value, NumberStyles.HexNumber);
					break;
				case "workbookPassword":
					ushort_2 = ushort.Parse(reader.Value, NumberStyles.HexNumber);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1746(XmlReader reader)
		: base(reader)
	{
	}

	public Class1746()
	{
	}

	protected override void vmethod_1()
	{
		ushort_2 = ushort.MaxValue;
		ushort_3 = ushort.MaxValue;
		bool_3 = false;
		bool_4 = false;
		bool_5 = false;
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
		if (ushort_2 != ushort.MaxValue)
		{
			writer.WriteAttributeString("workbookPassword", (ushort_2 & 0xFFFF).ToString("X4"));
		}
		if (ushort_3 != ushort.MaxValue)
		{
			writer.WriteAttributeString("revisionsPassword", (ushort_3 & 0xFFFF).ToString("X4"));
		}
		if (bool_3)
		{
			writer.WriteAttributeString("lockStructure", bool_3 ? "1" : "0");
		}
		if (bool_4)
		{
			writer.WriteAttributeString("lockWindows", bool_4 ? "1" : "0");
		}
		if (bool_5)
		{
			writer.WriteAttributeString("lockRevision", bool_5 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
