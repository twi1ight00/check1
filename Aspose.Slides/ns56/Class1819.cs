using System;
using System.Xml;

namespace ns56;

internal class Class1819 : Class1351
{
	public delegate Class1819 Delegate1336();

	public delegate void Delegate1337(Class1819 elementData);

	public delegate void Delegate1338(Class1819 elementData);

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private string string_0;

	private Class1814 class1814_0;

	private Class1814 class1814_1;

	private Class1814 class1814_2;

	private Class1814 class1814_3;

	private Class1814 class1814_4;

	private Class1814 class1814_5;

	private Class1814 class1814_6;

	private Class1814 class1814_7;

	private Class1814 class1814_8;

	private Class1814 class1814_9;

	private Class1814 class1814_10;

	private Class1814 class1814_11;

	private Class1886 class1886_0;

	public string Name
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

	public Class1814 Dk1 => class1814_0;

	public Class1814 Lt1 => class1814_1;

	public Class1814 Dk2 => class1814_2;

	public Class1814 Lt2 => class1814_3;

	public Class1814 Accent1 => class1814_4;

	public Class1814 Accent2 => class1814_5;

	public Class1814 Accent3 => class1814_6;

	public Class1814 Accent4 => class1814_7;

	public Class1814 Accent5 => class1814_8;

	public Class1814 Accent6 => class1814_9;

	public Class1814 Hlink => class1814_10;

	public Class1814 FolHlink => class1814_11;

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
				switch (reader.LocalName)
				{
				case "dk1":
					class1814_0 = new Class1814(reader);
					break;
				case "lt1":
					class1814_1 = new Class1814(reader);
					break;
				case "dk2":
					class1814_2 = new Class1814(reader);
					break;
				case "lt2":
					class1814_3 = new Class1814(reader);
					break;
				case "accent1":
					class1814_4 = new Class1814(reader);
					break;
				case "accent2":
					class1814_5 = new Class1814(reader);
					break;
				case "accent3":
					class1814_6 = new Class1814(reader);
					break;
				case "accent4":
					class1814_7 = new Class1814(reader);
					break;
				case "accent5":
					class1814_8 = new Class1814(reader);
					break;
				case "accent6":
					class1814_9 = new Class1814(reader);
					break;
				case "hlink":
					class1814_10 = new Class1814(reader);
					break;
				case "folHlink":
					class1814_11 = new Class1814(reader);
					break;
				case "extLst":
					class1886_0 = new Class1886(reader);
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
				string_0 = reader.Value;
			}
		}
		reader.MoveToElement();
	}

	public Class1819(XmlReader reader)
		: base(reader)
	{
	}

	public Class1819()
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
		class1814_0 = new Class1814();
		class1814_1 = new Class1814();
		class1814_2 = new Class1814();
		class1814_3 = new Class1814();
		class1814_4 = new Class1814();
		class1814_5 = new Class1814();
		class1814_6 = new Class1814();
		class1814_7 = new Class1814();
		class1814_8 = new Class1814();
		class1814_9 = new Class1814();
		class1814_10 = new Class1814();
		class1814_11 = new Class1814();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("name", string_0);
		class1814_0.vmethod_4("a", writer, "dk1");
		class1814_1.vmethod_4("a", writer, "lt1");
		class1814_2.vmethod_4("a", writer, "dk2");
		class1814_3.vmethod_4("a", writer, "lt2");
		class1814_4.vmethod_4("a", writer, "accent1");
		class1814_5.vmethod_4("a", writer, "accent2");
		class1814_6.vmethod_4("a", writer, "accent3");
		class1814_7.vmethod_4("a", writer, "accent4");
		class1814_8.vmethod_4("a", writer, "accent5");
		class1814_9.vmethod_4("a", writer, "accent6");
		class1814_10.vmethod_4("a", writer, "hlink");
		class1814_11.vmethod_4("a", writer, "folHlink");
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
