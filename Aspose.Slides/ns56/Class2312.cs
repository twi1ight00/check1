using System;
using System.Xml;

namespace ns56;

internal class Class2312 : Class1351
{
	public delegate Class2312 Delegate2683();

	public delegate void Delegate2684(Class2312 elementData);

	public delegate void Delegate2685(Class2312 elementData);

	public const bool bool_0 = true;

	public const bool bool_1 = true;

	public const bool bool_2 = true;

	public Class1816.Delegate1327 delegate1327_0;

	public Class1816.Delegate1329 delegate1329_0;

	public Class1353.Delegate21 delegate21_0;

	public Class1353.Delegate23 delegate23_0;

	public Class2259.Delegate2524 delegate2524_0;

	public Class2259.Delegate2526 delegate2526_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private Class2227 class2227_0;

	private Class1816 class1816_0;

	private Class1353 class1353_0;

	private Class2259 class2259_0;

	private Class1889 class1889_0;

	public bool ShowMasterSp
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public bool ShowMasterPhAnim
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public bool Show
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public Class2227 CSld => class2227_0;

	public Class1816 ClrMapOvr => class1816_0;

	public Class1353 Transition => class1353_0;

	public Class2259 Timing => class2259_0;

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
				case "extLst":
					class1889_0 = new Class1889(reader);
					break;
				case "timing":
					class2259_0 = new Class2259(reader);
					break;
				case "transition":
					class1353_0 = new Class1353(reader);
					break;
				case "clrMapOvr":
					class1816_0 = new Class1816(reader);
					break;
				case "cSld":
					class2227_0 = new Class2227(reader);
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
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "show":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showMasterPhAnim":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showMasterSp":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2312(XmlReader reader)
		: base(reader)
	{
	}

	public Class2312()
	{
	}

	protected override void vmethod_1()
	{
		bool_3 = true;
		bool_4 = true;
		bool_5 = true;
	}

	protected override void vmethod_2()
	{
		delegate1327_0 = method_3;
		delegate1329_0 = method_4;
		delegate21_0 = method_5;
		delegate23_0 = method_6;
		delegate2524_0 = method_7;
		delegate2526_0 = method_8;
		delegate1534_0 = method_9;
		delegate1535_0 = method_10;
	}

	protected override void vmethod_3()
	{
		class2227_0 = new Class2227();
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
		if (!bool_3)
		{
			writer.WriteAttributeString("showMasterSp", bool_3 ? "1" : "0");
		}
		if (!bool_4)
		{
			writer.WriteAttributeString("showMasterPhAnim", bool_4 ? "1" : "0");
		}
		if (!bool_5)
		{
			writer.WriteAttributeString("show", bool_5 ? "1" : "0");
		}
		class2227_0.vmethod_4("p", writer, "cSld");
		if (class1816_0 != null)
		{
			class1816_0.vmethod_4("p", writer, "clrMapOvr");
		}
		if (class1353_0 != null)
		{
			class1353_0.vmethod_4("p", writer, "transition");
		}
		if (class2259_0 != null)
		{
			class2259_0.vmethod_4("p", writer, "timing");
		}
		if (class1889_0 != null)
		{
			class1889_0.vmethod_4("p", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1816 method_3()
	{
		if (class1816_0 != null)
		{
			throw new Exception("Only one <clrMapOvr> element can be added.");
		}
		class1816_0 = new Class1816();
		return class1816_0;
	}

	private void method_4(Class1816 _clrMapOvr)
	{
		class1816_0 = _clrMapOvr;
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

	private Class1885 method_9()
	{
		if (class1889_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1889_0 = new Class1889();
		return class1889_0;
	}

	private void method_10(Class1885 _extLst)
	{
		class1889_0 = (Class1889)_extLst;
	}
}
