using System.Globalization;
using System.Xml;

namespace ns56;

internal class Class1520 : Class1351
{
	public delegate void Delegate441(Class1520 elementData);

	public delegate Class1520 Delegate439();

	public delegate void Delegate440(Class1520 elementData);

	public const bool bool_0 = false;

	public const ushort ushort_0 = ushort.MaxValue;

	private bool bool_1;

	private string string_0;

	private ushort ushort_1;

	public bool ReadOnlyRecommended
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

	public ushort ReservationPassword
	{
		get
		{
			return ushort_1;
		}
		set
		{
			ushort_1 = value;
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
				case "reservationPassword":
					ushort_1 = ushort.Parse(reader.Value, NumberStyles.HexNumber);
					break;
				case "userName":
					string_0 = reader.Value;
					break;
				case "readOnlyRecommended":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1520(XmlReader reader)
		: base(reader)
	{
	}

	public Class1520()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = false;
		ushort_1 = ushort.MaxValue;
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
		if (bool_1)
		{
			writer.WriteAttributeString("readOnlyRecommended", bool_1 ? "1" : "0");
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("userName", string_0);
		}
		if (ushort_1 != ushort.MaxValue)
		{
			writer.WriteAttributeString("reservationPassword", (ushort_1 & 0xFFFF).ToString("X4"));
		}
		writer.WriteEndElement();
	}
}
