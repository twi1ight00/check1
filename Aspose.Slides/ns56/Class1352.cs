using System;
using System.Xml;
using ns46;

namespace ns56;

internal class Class1352 : Class1351
{
	public delegate Class1352 Delegate18();

	public delegate void Delegate19(Class1352 elementData);

	public delegate void Delegate20(Class1352 elementData);

	private const string string_0 = "v";

	private const string string_1 = "urn:schemas-microsoft-com:vml";

	public Class1367.Delegate63 delegate63_0;

	public Class1367.Delegate65 delegate65_0;

	public Class1367.Delegate63 delegate63_1;

	public Class1367.Delegate65 delegate65_1;

	private Class1367 class1367_0;

	private Class1367 class1367_1;

	public Class1367 Fallback => class1367_0;

	public Class1367 Choice_v => class1367_1;

	protected override void vmethod_0(XmlReader reader)
	{
		if (Class1120.list_0.Contains("urn:schemas-microsoft-com:vml"))
		{
			class1367_1 = new Class1367(reader);
		}
		else
		{
			class1367_0 = new Class1367(reader);
		}
	}

	internal Class1352(XmlReader reader)
		: base(reader)
	{
	}

	internal Class1352()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate63_0 = method_2;
		delegate65_0 = method_3;
		delegate63_1 = method_4;
		delegate65_1 = method_5;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		if (class1367_1 != null)
		{
			writer.WriteStartElement("mc", "AlternateContent", "http://schemas.openxmlformats.org/markup-compatibility/2006");
			if (class1367_1 != null)
			{
				writer.WriteStartElement("mc", "Choice", null);
				writer.WriteAttributeString("xmlns", "v", null, "urn:schemas-microsoft-com:vml");
				writer.WriteAttributeString("Requires", "v");
				class1367_1.vmethod_4("p", writer, "oleObj");
				writer.WriteEndElement();
			}
			if (class1367_0 != null)
			{
				writer.WriteStartElement("mc", "Fallback", null);
				class1367_0.vmethod_4(prefix, writer, "oleObj");
				writer.WriteEndElement();
			}
			writer.WriteEndElement();
		}
		else if (class1367_0 != null)
		{
			class1367_0.vmethod_4(prefix, writer, "oleObj");
		}
	}

	private Class1367 method_2()
	{
		if (class1367_0 != null)
		{
			throw new Exception("Only one <oleObj> element can be added.");
		}
		class1367_0 = new Class1367();
		return class1367_0;
	}

	private void method_3(Class1367 _fallback)
	{
		class1367_0 = _fallback;
	}

	private Class1367 method_4()
	{
		if (class1367_1 != null)
		{
			throw new Exception("Only one <oleObj> element can be added.");
		}
		class1367_1 = new Class1367();
		return class1367_1;
	}

	private void method_5(Class1367 _choice_v)
	{
		class1367_1 = _choice_v;
	}
}
