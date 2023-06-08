using System;
using System.Xml;

namespace ns56;

internal class Class2197 : Class1351
{
	public delegate Class2197 Delegate2327();

	public delegate void Delegate2328(Class2197 elementData);

	public delegate void Delegate2329(Class2197 elementData);

	public const bool bool_0 = true;

	public const bool bool_1 = true;

	public Class1816.Delegate1327 delegate1327_0;

	public Class1816.Delegate1329 delegate1329_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private bool bool_2;

	private bool bool_3;

	private Class2227 class2227_0;

	private Class1816 class1816_0;

	private Class1889 class1889_0;

	public bool ShowMasterSp
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool ShowMasterPhAnim
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

	public Class2227 CSld => class2227_0;

	public Class1816 ClrMapOvr => class1816_0;

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
				case "showMasterPhAnim":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showMasterSp":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2197(XmlReader reader)
		: base(reader)
	{
	}

	public Class2197()
	{
	}

	protected override void vmethod_1()
	{
		bool_2 = true;
		bool_3 = true;
	}

	protected override void vmethod_2()
	{
		delegate1327_0 = method_3;
		delegate1329_0 = method_4;
		delegate1534_0 = method_5;
		delegate1535_0 = method_6;
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
		if (!bool_2)
		{
			writer.WriteAttributeString("showMasterSp", bool_2 ? "1" : "0");
		}
		if (!bool_3)
		{
			writer.WriteAttributeString("showMasterPhAnim", bool_3 ? "1" : "0");
		}
		class2227_0.vmethod_4("p", writer, "cSld");
		if (class1816_0 != null)
		{
			class1816_0.vmethod_4("p", writer, "clrMapOvr");
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

	private Class1885 method_5()
	{
		if (class1889_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1889_0 = new Class1889();
		return class1889_0;
	}

	private void method_6(Class1885 _extLst)
	{
		class1889_0 = (Class1889)_extLst;
	}
}
