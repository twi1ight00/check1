using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1396 : Class1351
{
	public delegate void Delegate152(Class1396 elementData);

	public delegate Class1396 Delegate150();

	public delegate void Delegate151(Class1396 elementData);

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const NullableBool nullableBool_1 = NullableBool.NotDefined;

	private NullableBool nullableBool_2;

	private NullableBool nullableBool_3;

	public NullableBool Locked
	{
		get
		{
			return nullableBool_2;
		}
		set
		{
			nullableBool_2 = value;
		}
	}

	public NullableBool Hidden
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
				case "hidden":
					nullableBool_3 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "locked":
					nullableBool_2 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1396(XmlReader reader)
		: base(reader)
	{
	}

	public Class1396()
	{
	}

	protected override void vmethod_1()
	{
		nullableBool_2 = NullableBool.NotDefined;
		nullableBool_3 = NullableBool.NotDefined;
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
		if (nullableBool_2 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("locked", (nullableBool_2 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_3 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("hidden", (nullableBool_3 == NullableBool.True) ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
