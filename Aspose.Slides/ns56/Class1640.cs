using System.Globalization;
using System.Xml;

namespace ns56;

internal class Class1640 : Class1351
{
	public delegate Class1640 Delegate799();

	public delegate void Delegate800(Class1640 elementData);

	public delegate void Delegate801(Class1640 elementData);

	public const ushort ushort_0 = ushort.MaxValue;

	private ushort ushort_1;

	private string string_0;

	private string string_1;

	private string string_2;

	public ushort Password
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

	public string Sqref
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

	public string Name
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

	public string SecurityDescriptor
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
				case "securityDescriptor":
					string_2 = reader.Value;
					break;
				case "name":
					string_1 = reader.Value;
					break;
				case "sqref":
					string_0 = reader.Value;
					break;
				case "password":
					ushort_1 = ushort.Parse(reader.Value, NumberStyles.HexNumber);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1640(XmlReader reader)
		: base(reader)
	{
	}

	public Class1640()
	{
	}

	protected override void vmethod_1()
	{
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
		if (ushort_1 != ushort.MaxValue)
		{
			writer.WriteAttributeString("password", (ushort_1 & 0xFFFF).ToString("X4"));
		}
		writer.WriteAttributeString("sqref", string_0);
		writer.WriteAttributeString("name", string_1);
		if (string_2 != null)
		{
			writer.WriteAttributeString("securityDescriptor", string_2);
		}
		writer.WriteEndElement();
	}
}
