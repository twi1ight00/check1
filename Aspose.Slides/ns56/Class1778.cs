using System;
using System.Xml;
using ns46;

namespace ns56;

internal class Class1778 : Class1351
{
	public delegate Class1778 Delegate1213();

	public delegate void Delegate1214(Class1778 elementData);

	public delegate void Delegate1215(Class1778 elementData);

	private const string string_0 = "v";

	private const string string_1 = "urn:schemas-microsoft-com:vml";

	public Class2228.Delegate2422 delegate2422_0;

	public Class2228.Delegate2424 delegate2424_0;

	public Class2228.Delegate2422 delegate2422_1;

	public Class2228.Delegate2424 delegate2424_1;

	private Class2228 class2228_0;

	private Class2228 class2228_1;

	public Class2228 Fallback => class2228_0;

	public Class2228 Choice_v => class2228_1;

	protected override void vmethod_0(XmlReader reader)
	{
		if (Class1120.list_0.Contains("urn:schemas-microsoft-com:vml"))
		{
			class2228_1 = new Class2228(reader);
		}
		else
		{
			class2228_0 = new Class2228(reader);
		}
	}

	internal Class1778(XmlReader reader)
		: base(reader)
	{
	}

	internal Class1778()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2422_0 = method_2;
		delegate2424_0 = method_3;
		delegate2422_1 = method_4;
		delegate2424_1 = method_5;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		if (class2228_1 != null)
		{
			writer.WriteStartElement("mc", "AlternateContent", "http://schemas.openxmlformats.org/markup-compatibility/2006");
			if (class2228_1 != null)
			{
				writer.WriteStartElement("mc", "Choice", null);
				writer.WriteAttributeString("xmlns", "v", null, "urn:schemas-microsoft-com:vml");
				writer.WriteAttributeString("Requires", "v");
				class2228_1.vmethod_4("p", writer, "control");
				writer.WriteEndElement();
			}
			if (class2228_0 != null)
			{
				writer.WriteStartElement("mc", "Fallback", null);
				class2228_0.vmethod_4(prefix, writer, "control");
				writer.WriteEndElement();
			}
			writer.WriteEndElement();
		}
		else if (class2228_0 != null)
		{
			class2228_0.vmethod_4(prefix, writer, "control");
		}
	}

	private Class2228 method_2()
	{
		if (class2228_0 != null)
		{
			throw new Exception("Only one <control> element can be added.");
		}
		class2228_0 = new Class2228();
		return class2228_0;
	}

	private void method_3(Class2228 _fallback)
	{
		class2228_0 = _fallback;
	}

	private Class2228 method_4()
	{
		if (class2228_1 != null)
		{
			throw new Exception("Only one <control> element can be added.");
		}
		class2228_1 = new Class2228();
		return class2228_1;
	}

	private void method_5(Class2228 _choice_v)
	{
		class2228_1 = _choice_v;
	}
}
