using System;
using System.Xml;

namespace ns56;

internal class Class2314 : Class1351
{
	public delegate Class2314 Delegate2689();

	public delegate void Delegate2690(Class2314 elementData);

	public delegate void Delegate2691(Class2314 elementData);

	public const bool bool_0 = false;

	public Class2253.Delegate2506 delegate2506_0;

	public Class2253.Delegate2508 delegate2508_0;

	public Class1353.Delegate21 delegate21_0;

	public Class1353.Delegate23 delegate23_0;

	public Class2259.Delegate2524 delegate2524_0;

	public Class2259.Delegate2526 delegate2526_0;

	public Class2238.Delegate2458 delegate2458_0;

	public Class2238.Delegate2460 delegate2460_0;

	public Class2257.Delegate2518 delegate2518_0;

	public Class2257.Delegate2520 delegate2520_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private bool bool_1;

	private Class2227 class2227_0;

	private Class1815 class1815_0;

	private Class2253 class2253_0;

	private Class1353 class1353_0;

	private Class2259 class2259_0;

	private Class2238 class2238_0;

	private Class2257 class2257_0;

	private Class1889 class1889_0;

	public bool Preserve
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public Class2227 CSld => class2227_0;

	public Class1815 ClrMap => class1815_0;

	public Class2253 SldLayoutIdLst => class2253_0;

	public Class1353 Transition => class1353_0;

	public Class2259 Timing => class2259_0;

	public Class2238 Hf => class2238_0;

	public Class2257 TxStyles => class2257_0;

	public Class1885 ExtLst => class1889_0;

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
				case "cSld":
					class2227_0 = new Class2227(reader);
					break;
				case "clrMap":
					class1815_0 = new Class1815(reader);
					break;
				case "sldLayoutIdLst":
					class2253_0 = new Class2253(reader);
					break;
				case "transition":
					class1353_0 = new Class1353(reader);
					break;
				case "timing":
					class2259_0 = new Class2259(reader);
					break;
				case "hf":
					class2238_0 = new Class2238(reader);
					break;
				case "txStyles":
					class2257_0 = new Class2257(reader);
					break;
				case "extLst":
					class1889_0 = new Class1889(reader);
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "preserve")
			{
				bool_1 = XmlConvert.ToBoolean(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2314(XmlReader reader)
		: base(reader)
	{
	}

	public Class2314()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = false;
	}

	protected override void vmethod_2()
	{
		delegate2506_0 = method_3;
		delegate2508_0 = method_4;
		delegate21_0 = method_5;
		delegate23_0 = method_6;
		delegate2524_0 = method_7;
		delegate2526_0 = method_8;
		delegate2458_0 = method_9;
		delegate2460_0 = method_10;
		delegate2518_0 = method_11;
		delegate2520_0 = method_12;
		delegate1534_0 = method_13;
		delegate1535_0 = method_14;
	}

	protected override void vmethod_3()
	{
		class2227_0 = new Class2227();
		class1815_0 = new Class1815();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("p", elementName, "http://schemas.openxmlformats.org/presentationml/2006/main");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/drawingml/2006/main") == null)
		{
			writer.WriteAttributeString("xmlns", "a", null, "http://schemas.openxmlformats.org/drawingml/2006/main");
		}
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		if (writer.LookupPrefix("http://schemas.microsoft.com/office/powerpoint/2010/main") == null)
		{
			writer.WriteAttributeString("xmlns", "p14", null, "http://schemas.microsoft.com/office/powerpoint/2010/main");
		}
		if (writer.LookupPrefix("http://schemas.microsoft.com/office/powerpoint/2012/main") == null)
		{
			writer.WriteAttributeString("xmlns", "p15", null, "http://schemas.microsoft.com/office/powerpoint/2012/main");
		}
		if (bool_1)
		{
			writer.WriteAttributeString("preserve", bool_1 ? "1" : "0");
		}
		class2227_0.vmethod_4("p", writer, "cSld");
		class1815_0.vmethod_4("p", writer, "clrMap");
		if (class2253_0 != null)
		{
			class2253_0.vmethod_4("p", writer, "sldLayoutIdLst");
		}
		if (class1353_0 != null)
		{
			class1353_0.vmethod_4("p", writer, "transition");
		}
		if (class2259_0 != null)
		{
			class2259_0.vmethod_4("p", writer, "timing");
		}
		if (class2238_0 != null)
		{
			class2238_0.vmethod_4("p", writer, "hf");
		}
		if (class2257_0 != null)
		{
			class2257_0.vmethod_4("p", writer, "txStyles");
		}
		if (class1889_0 != null)
		{
			class1889_0.vmethod_4("p", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2253 method_3()
	{
		if (class2253_0 != null)
		{
			throw new Exception("Only one <sldLayoutIdLst> element can be added.");
		}
		class2253_0 = new Class2253();
		return class2253_0;
	}

	private void method_4(Class2253 _sldLayoutIdLst)
	{
		class2253_0 = _sldLayoutIdLst;
	}

	private Class1353 method_5()
	{
		if (class1353_0 != null)
		{
			throw new Exception("Only one <transition> element can be added.");
		}
		class1353_0 = new Class1353();
		return class1353_0;
	}

	private void method_6(Class1353 _transition)
	{
		class1353_0 = _transition;
	}

	private Class2259 method_7()
	{
		if (class2259_0 != null)
		{
			throw new Exception("Only one <timing> element can be added.");
		}
		class2259_0 = new Class2259();
		return class2259_0;
	}

	private void method_8(Class2259 _timing)
	{
		class2259_0 = _timing;
	}

	private Class2238 method_9()
	{
		if (class2238_0 != null)
		{
			throw new Exception("Only one <hf> element can be added.");
		}
		class2238_0 = new Class2238();
		return class2238_0;
	}

	private void method_10(Class2238 _hf)
	{
		class2238_0 = _hf;
	}

	private Class2257 method_11()
	{
		if (class2257_0 != null)
		{
			throw new Exception("Only one <txStyles> element can be added.");
		}
		class2257_0 = new Class2257();
		return class2257_0;
	}

	private void method_12(Class2257 _txStyles)
	{
		class2257_0 = _txStyles;
	}

	private Class1885 method_13()
	{
		if (class1889_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1889_0 = new Class1889();
		return class1889_0;
	}

	private void method_14(Class1885 _extLst)
	{
		class1889_0 = (Class1889)_extLst;
	}
}
