using System.Xml;

namespace ns56;

internal class Class1928 : Class1351
{
	public delegate Class1928 Delegate1651();

	public delegate void Delegate1652(Class1928 elementData);

	public delegate void Delegate1653(Class1928 elementData);

	public const string string_0 = "";

	private string string_1;

	private Class1843 class1843_0;

	private Class1876 class1876_0;

	private Class1837 class1837_0;

	private Class1803 class1803_0;

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

	public Class1843 FillStyleLst => class1843_0;

	public Class1876 LnStyleLst => class1876_0;

	public Class1837 EffectStyleLst => class1837_0;

	public Class1803 BgFillStyleLst => class1803_0;

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
				case "bgFillStyleLst":
					class1803_0 = new Class1803(reader);
					break;
				case "effectStyleLst":
					class1837_0 = new Class1837(reader);
					break;
				case "lnStyleLst":
					class1876_0 = new Class1876(reader);
					break;
				case "fillStyleLst":
					class1843_0 = new Class1843(reader);
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
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "name")
			{
				string_1 = reader.Value;
			}
		}
		reader.MoveToElement();
	}

	public Class1928(XmlReader reader)
		: base(reader)
	{
	}

	public Class1928()
	{
	}

	protected override void vmethod_1()
	{
		string_1 = "";
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
		class1843_0 = new Class1843();
		class1876_0 = new Class1876();
		class1837_0 = new Class1837();
		class1803_0 = new Class1803();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_1 != "")
		{
			writer.WriteAttributeString("name", string_1);
		}
		class1843_0.vmethod_4("a", writer, "fillStyleLst");
		class1876_0.vmethod_4("a", writer, "lnStyleLst");
		class1837_0.vmethod_4("a", writer, "effectStyleLst");
		class1803_0.vmethod_4("a", writer, "bgFillStyleLst");
		writer.WriteEndElement();
	}
}
