using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class2097 : Class1351
{
	public delegate Class2097 Delegate2009();

	public delegate void Delegate2011(Class2097 elementData);

	public delegate void Delegate2010(Class2097 elementData);

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	private string string_0;

	private NullableBool nullableBool_1;

	public string FormatCode
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

	public NullableBool SourceLinked
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
				case "sourceLinked":
					nullableBool_1 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "formatCode":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2097(XmlReader reader)
		: base(reader)
	{
	}

	public Class2097()
	{
	}

	protected override void vmethod_1()
	{
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
		writer.WriteAttributeString("formatCode", string_0);
		if (nullableBool_1 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("sourceLinked", (nullableBool_1 == NullableBool.True) ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
