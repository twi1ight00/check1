using System;
using System.Xml;
using ns46;

namespace ns56;

internal class Class1353 : Class1351
{
	public delegate Class1353 Delegate21();

	public delegate void Delegate22(Class1353 elementData);

	public delegate void Delegate23(Class1353 elementData);

	private const string string_0 = "p15";

	private const string string_1 = "http://schemas.microsoft.com/office/powerpoint/2012/main";

	private const string string_2 = "p14";

	private const string string_3 = "http://schemas.microsoft.com/office/powerpoint/2010/main";

	public Class2260.Delegate2527 delegate2527_0;

	public Class2260.Delegate2529 delegate2529_0;

	public Class2260.Delegate2527 delegate2527_1;

	public Class2260.Delegate2529 delegate2529_1;

	public Class2260.Delegate2527 delegate2527_2;

	public Class2260.Delegate2529 delegate2529_2;

	private Class2260 class2260_0;

	private Class2260 class2260_1;

	private Class2260 class2260_2;

	public Class2260 Fallback => class2260_0;

	public Class2260 Choice_p15 => class2260_1;

	public Class2260 Choice_p14 => class2260_2;

	protected override void vmethod_0(XmlReader reader)
	{
		if (Class1120.list_0.Contains("http://schemas.microsoft.com/office/powerpoint/2012/main"))
		{
			class2260_1 = new Class2260(reader);
		}
		else if (Class1120.list_0.Contains("http://schemas.microsoft.com/office/powerpoint/2010/main"))
		{
			class2260_2 = new Class2260(reader);
		}
		else
		{
			class2260_0 = new Class2260(reader);
		}
	}

	internal Class1353(XmlReader reader)
		: base(reader)
	{
	}

	internal Class1353()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2527_0 = method_2;
		delegate2529_0 = method_3;
		delegate2527_1 = method_4;
		delegate2529_1 = method_5;
		delegate2527_2 = method_6;
		delegate2529_2 = method_7;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		if (class2260_1 == null && class2260_2 == null)
		{
			if (class2260_0 != null)
			{
				class2260_0.vmethod_4(prefix, writer, "transition");
			}
			return;
		}
		writer.WriteStartElement("mc", "AlternateContent", "http://schemas.openxmlformats.org/markup-compatibility/2006");
		if (class2260_1 != null)
		{
			writer.WriteStartElement("mc", "Choice", null);
			writer.WriteAttributeString("xmlns", "p15", null, "http://schemas.microsoft.com/office/powerpoint/2012/main");
			writer.WriteAttributeString("Requires", "p15");
			class2260_1.vmethod_4("p", writer, "transition");
			writer.WriteEndElement();
		}
		if (class2260_2 != null)
		{
			writer.WriteStartElement("mc", "Choice", null);
			writer.WriteAttributeString("xmlns", "p14", null, "http://schemas.microsoft.com/office/powerpoint/2010/main");
			writer.WriteAttributeString("Requires", "p14");
			class2260_2.vmethod_4("p", writer, "transition");
			writer.WriteEndElement();
		}
		if (class2260_0 != null)
		{
			writer.WriteStartElement("mc", "Fallback", null);
			class2260_0.vmethod_4(prefix, writer, "transition");
			writer.WriteEndElement();
		}
		writer.WriteEndElement();
	}

	private Class2260 method_2()
	{
		if (class2260_0 != null)
		{
			throw new Exception("Only one <transition> element can be added.");
		}
		class2260_0 = new Class2260();
		return class2260_0;
	}

	private void method_3(Class2260 _fallback)
	{
		class2260_0 = _fallback;
	}

	private Class2260 method_4()
	{
		if (class2260_1 != null)
		{
			throw new Exception("Only one <transition> element can be added.");
		}
		class2260_1 = new Class2260();
		return class2260_1;
	}

	private void method_5(Class2260 _choice_p15)
	{
		class2260_1 = _choice_p15;
	}

	private Class2260 method_6()
	{
		if (class2260_2 != null)
		{
			throw new Exception("Only one <transition> element can be added.");
		}
		class2260_2 = new Class2260();
		return class2260_2;
	}

	private void method_7(Class2260 _choice_p14)
	{
		class2260_2 = _choice_p14;
	}
}
