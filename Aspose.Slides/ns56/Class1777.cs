using System;
using System.Xml;
using ns46;

namespace ns56;

internal class Class1777 : Class1351
{
	public delegate Class1777 Delegate1210();

	public delegate void Delegate1211(Class1777 elementData);

	public delegate void Delegate1212(Class1777 elementData);

	private const string string_0 = "c14";

	private const string string_1 = "http://schemas.microsoft.com/office/drawing/2007/8/2/chart";

	public Class2122.Delegate2094 delegate2094_0;

	public Class2122.Delegate2096 delegate2096_0;

	public Class1355.Delegate27 delegate27_0;

	public Class1355.Delegate29 delegate29_0;

	private Class2122 class2122_0;

	private Class1355 class1355_0;

	public Class2122 Fallback => class2122_0;

	public Class1355 Choice_c14 => class1355_0;

	protected override void vmethod_0(XmlReader reader)
	{
		if (Class1120.list_0.Contains("http://schemas.microsoft.com/office/drawing/2007/8/2/chart"))
		{
			class1355_0 = new Class1355(reader);
		}
		else
		{
			class2122_0 = new Class2122(reader);
		}
	}

	internal Class1777(XmlReader reader)
		: base(reader)
	{
	}

	internal Class1777()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2094_0 = method_2;
		delegate2096_0 = method_3;
		delegate27_0 = method_4;
		delegate29_0 = method_5;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		if (class1355_0 != null)
		{
			writer.WriteStartElement("mc", "AlternateContent", "http://schemas.openxmlformats.org/markup-compatibility/2006");
			if (class1355_0 != null)
			{
				writer.WriteStartElement("mc", "Choice", null);
				writer.WriteAttributeString("xmlns", "c14", null, "http://schemas.microsoft.com/office/drawing/2007/8/2/chart");
				writer.WriteAttributeString("Requires", "c14");
				class1355_0.vmethod_4("cht14", writer, "style");
				writer.WriteEndElement();
			}
			if (class2122_0 != null)
			{
				writer.WriteStartElement("mc", "Fallback", null);
				class2122_0.vmethod_4(prefix, writer, "style");
				writer.WriteEndElement();
			}
			writer.WriteEndElement();
		}
		else if (class2122_0 != null)
		{
			class2122_0.vmethod_4(prefix, writer, "style");
		}
	}

	private Class2122 method_2()
	{
		if (class2122_0 != null)
		{
			throw new Exception("Only one <style> element can be added.");
		}
		class2122_0 = new Class2122();
		return class2122_0;
	}

	private void method_3(Class2122 _fallback)
	{
		class2122_0 = _fallback;
	}

	private Class1355 method_4()
	{
		if (class1355_0 != null)
		{
			throw new Exception("Only one <style> element can be added.");
		}
		class1355_0 = new Class1355();
		return class1355_0;
	}

	private void method_5(Class1355 _choice_c14)
	{
		class1355_0 = _choice_c14;
	}
}
