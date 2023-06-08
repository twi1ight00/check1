using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1815 : Class1351
{
	public delegate Class1815 Delegate1324();

	public delegate void Delegate1325(Class1815 elementData);

	public delegate void Delegate1326(Class1815 elementData);

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private ColorSchemeIndex colorSchemeIndex_0;

	private ColorSchemeIndex colorSchemeIndex_1;

	private ColorSchemeIndex colorSchemeIndex_2;

	private ColorSchemeIndex colorSchemeIndex_3;

	private ColorSchemeIndex colorSchemeIndex_4;

	private ColorSchemeIndex colorSchemeIndex_5;

	private ColorSchemeIndex colorSchemeIndex_6;

	private ColorSchemeIndex colorSchemeIndex_7;

	private ColorSchemeIndex colorSchemeIndex_8;

	private ColorSchemeIndex colorSchemeIndex_9;

	private ColorSchemeIndex colorSchemeIndex_10;

	private ColorSchemeIndex colorSchemeIndex_11;

	private Class1886 class1886_0;

	public ColorSchemeIndex Bg1
	{
		get
		{
			return colorSchemeIndex_0;
		}
		set
		{
			colorSchemeIndex_0 = value;
		}
	}

	public ColorSchemeIndex Tx1
	{
		get
		{
			return colorSchemeIndex_1;
		}
		set
		{
			colorSchemeIndex_1 = value;
		}
	}

	public ColorSchemeIndex Bg2
	{
		get
		{
			return colorSchemeIndex_2;
		}
		set
		{
			colorSchemeIndex_2 = value;
		}
	}

	public ColorSchemeIndex Tx2
	{
		get
		{
			return colorSchemeIndex_3;
		}
		set
		{
			colorSchemeIndex_3 = value;
		}
	}

	public ColorSchemeIndex Accent1
	{
		get
		{
			return colorSchemeIndex_4;
		}
		set
		{
			colorSchemeIndex_4 = value;
		}
	}

	public ColorSchemeIndex Accent2
	{
		get
		{
			return colorSchemeIndex_5;
		}
		set
		{
			colorSchemeIndex_5 = value;
		}
	}

	public ColorSchemeIndex Accent3
	{
		get
		{
			return colorSchemeIndex_6;
		}
		set
		{
			colorSchemeIndex_6 = value;
		}
	}

	public ColorSchemeIndex Accent4
	{
		get
		{
			return colorSchemeIndex_7;
		}
		set
		{
			colorSchemeIndex_7 = value;
		}
	}

	public ColorSchemeIndex Accent5
	{
		get
		{
			return colorSchemeIndex_8;
		}
		set
		{
			colorSchemeIndex_8 = value;
		}
	}

	public ColorSchemeIndex Accent6
	{
		get
		{
			return colorSchemeIndex_9;
		}
		set
		{
			colorSchemeIndex_9 = value;
		}
	}

	public ColorSchemeIndex Hlink
	{
		get
		{
			return colorSchemeIndex_10;
		}
		set
		{
			colorSchemeIndex_10 = value;
		}
	}

	public ColorSchemeIndex FolHlink
	{
		get
		{
			return colorSchemeIndex_11;
		}
		set
		{
			colorSchemeIndex_11 = value;
		}
	}

	public Class1885 ExtLst => class1886_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "extLst")
				{
					class1886_0 = new Class1886(reader);
					continue;
				}
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
				case "bg1":
					colorSchemeIndex_0 = Class2521.smethod_0(reader.Value);
					break;
				case "tx1":
					colorSchemeIndex_1 = Class2521.smethod_0(reader.Value);
					break;
				case "bg2":
					colorSchemeIndex_2 = Class2521.smethod_0(reader.Value);
					break;
				case "tx2":
					colorSchemeIndex_3 = Class2521.smethod_0(reader.Value);
					break;
				case "accent1":
					colorSchemeIndex_4 = Class2521.smethod_0(reader.Value);
					break;
				case "accent2":
					colorSchemeIndex_5 = Class2521.smethod_0(reader.Value);
					break;
				case "accent3":
					colorSchemeIndex_6 = Class2521.smethod_0(reader.Value);
					break;
				case "accent4":
					colorSchemeIndex_7 = Class2521.smethod_0(reader.Value);
					break;
				case "accent5":
					colorSchemeIndex_8 = Class2521.smethod_0(reader.Value);
					break;
				case "accent6":
					colorSchemeIndex_9 = Class2521.smethod_0(reader.Value);
					break;
				case "hlink":
					colorSchemeIndex_10 = Class2521.smethod_0(reader.Value);
					break;
				case "folHlink":
					colorSchemeIndex_11 = Class2521.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1815(XmlReader reader)
		: base(reader)
	{
	}

	public Class1815()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1534_0 = method_3;
		delegate1535_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("bg1", Class2521.smethod_1(colorSchemeIndex_0));
		writer.WriteAttributeString("tx1", Class2521.smethod_1(colorSchemeIndex_1));
		writer.WriteAttributeString("bg2", Class2521.smethod_1(colorSchemeIndex_2));
		writer.WriteAttributeString("tx2", Class2521.smethod_1(colorSchemeIndex_3));
		writer.WriteAttributeString("accent1", Class2521.smethod_1(colorSchemeIndex_4));
		writer.WriteAttributeString("accent2", Class2521.smethod_1(colorSchemeIndex_5));
		writer.WriteAttributeString("accent3", Class2521.smethod_1(colorSchemeIndex_6));
		writer.WriteAttributeString("accent4", Class2521.smethod_1(colorSchemeIndex_7));
		writer.WriteAttributeString("accent5", Class2521.smethod_1(colorSchemeIndex_8));
		writer.WriteAttributeString("accent6", Class2521.smethod_1(colorSchemeIndex_9));
		writer.WriteAttributeString("hlink", Class2521.smethod_1(colorSchemeIndex_10));
		writer.WriteAttributeString("folHlink", Class2521.smethod_1(colorSchemeIndex_11));
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1885 method_3()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_4(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}
}
