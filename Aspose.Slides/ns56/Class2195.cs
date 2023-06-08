using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2195 : Class1351
{
	public delegate Class2195 Delegate2321();

	public delegate void Delegate2322(Class2195 elementData);

	public delegate void Delegate2323(Class2195 elementData);

	public const string string_0 = "";

	public const string string_1 = "http://schemas.openxmlformats.org/drawingml/2006/diagram";

	public const string string_2 = "";

	public Class2173.Delegate2251 delegate2251_0;

	public Class2173.Delegate2252 delegate2252_0;

	public Class2166.Delegate2230 delegate2230_0;

	public Class2166.Delegate2231 delegate2231_0;

	public Class2150.Delegate2182 delegate2182_0;

	public Class2150.Delegate2184 delegate2184_0;

	public Class2183.Delegate2281 delegate2281_0;

	public Class2183.Delegate2283 delegate2283_0;

	public Class2183.Delegate2281 delegate2281_1;

	public Class2183.Delegate2283 delegate2283_1;

	public Class2183.Delegate2281 delegate2281_2;

	public Class2183.Delegate2283 delegate2283_2;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private string string_3;

	private string string_4;

	private string string_5;

	private List<Class2173> list_0;

	private List<Class2166> list_1;

	private Class2150 class2150_0;

	private Class2183 class2183_0;

	private Class2183 class2183_1;

	private Class2183 class2183_2;

	private Class2171 class2171_0;

	private Class1886 class1886_0;

	public string UniqueId
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public string MinVer
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public string DefStyle
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public Class2173[] TitleList => list_0.ToArray();

	public Class2166[] DescList => list_1.ToArray();

	public Class2150 CatLst => class2150_0;

	public Class2183 SampData => class2183_0;

	public Class2183 StyleData => class2183_1;

	public Class2183 ClrData => class2183_2;

	public Class2171 LayoutNode => class2171_0;

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
				case "title":
				{
					Class2173 item2 = new Class2173(reader);
					list_0.Add(item2);
					break;
				}
				case "desc":
				{
					Class2166 item = new Class2166(reader);
					list_1.Add(item);
					break;
				}
				case "catLst":
					class2150_0 = new Class2150(reader);
					break;
				case "sampData":
					class2183_0 = new Class2183(reader);
					break;
				case "styleData":
					class2183_1 = new Class2183(reader);
					break;
				case "clrData":
					class2183_2 = new Class2183(reader);
					break;
				case "layoutNode":
					class2171_0 = new Class2171(reader);
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
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "defStyle":
					string_5 = reader.Value;
					break;
				case "minVer":
					string_4 = reader.Value;
					break;
				case "uniqueId":
					string_3 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2195(XmlReader reader)
		: base(reader)
	{
	}

	public Class2195()
	{
	}

	protected override void vmethod_1()
	{
		string_3 = "";
		string_4 = "http://schemas.openxmlformats.org/drawingml/2006/diagram";
		string_5 = "";
		list_0 = new List<Class2173>();
		list_1 = new List<Class2166>();
	}

	protected override void vmethod_2()
	{
		delegate2251_0 = method_3;
		delegate2252_0 = method_4;
		delegate2230_0 = method_5;
		delegate2231_0 = method_6;
		delegate2182_0 = method_7;
		delegate2184_0 = method_8;
		delegate2281_0 = method_9;
		delegate2283_0 = method_10;
		delegate2281_1 = method_11;
		delegate2283_1 = method_12;
		delegate2281_2 = method_13;
		delegate2283_2 = method_14;
		delegate1534_0 = method_15;
		delegate1535_0 = method_16;
	}

	protected override void vmethod_3()
	{
		class2171_0 = new Class2171();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("dgm", elementName, "http://schemas.openxmlformats.org/drawingml/2006/diagram");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/drawingml/2006/main") == null)
		{
			writer.WriteAttributeString("xmlns", "a", null, "http://schemas.openxmlformats.org/drawingml/2006/main");
		}
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		if (string_3 != "")
		{
			writer.WriteAttributeString("uniqueId", string_3);
		}
		if (string_4 != "http://schemas.openxmlformats.org/drawingml/2006/diagram")
		{
			writer.WriteAttributeString("minVer", string_4);
		}
		if (string_5 != "")
		{
			writer.WriteAttributeString("defStyle", string_5);
		}
		foreach (Class2173 item in list_0)
		{
			item.vmethod_4("dgm", writer, "title");
		}
		foreach (Class2166 item2 in list_1)
		{
			item2.vmethod_4("dgm", writer, "desc");
		}
		if (class2150_0 != null)
		{
			class2150_0.vmethod_4("dgm", writer, "catLst");
		}
		if (class2183_0 != null)
		{
			class2183_0.vmethod_4("dgm", writer, "sampData");
		}
		if (class2183_1 != null)
		{
			class2183_1.vmethod_4("dgm", writer, "styleData");
		}
		if (class2183_2 != null)
		{
			class2183_2.vmethod_4("dgm", writer, "clrData");
		}
		class2171_0.vmethod_4("dgm", writer, "layoutNode");
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("dgm", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2173 method_3()
	{
		Class2173 @class = new Class2173();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2173 elementData)
	{
		list_0.Add(elementData);
	}

	private Class2166 method_5()
	{
		Class2166 @class = new Class2166();
		list_1.Add(@class);
		return @class;
	}

	private void method_6(Class2166 elementData)
	{
		list_1.Add(elementData);
	}

	private Class2150 method_7()
	{
		if (class2150_0 != null)
		{
			throw new Exception("Only one <catLst> element can be added.");
		}
		class2150_0 = new Class2150();
		return class2150_0;
	}

	private void method_8(Class2150 _catLst)
	{
		class2150_0 = _catLst;
	}

	private Class2183 method_9()
	{
		if (class2183_0 != null)
		{
			throw new Exception("Only one <sampData> element can be added.");
		}
		class2183_0 = new Class2183();
		return class2183_0;
	}

	private void method_10(Class2183 _sampData)
	{
		class2183_0 = _sampData;
	}

	private Class2183 method_11()
	{
		if (class2183_1 != null)
		{
			throw new Exception("Only one <styleData> element can be added.");
		}
		class2183_1 = new Class2183();
		return class2183_1;
	}

	private void method_12(Class2183 _styleData)
	{
		class2183_1 = _styleData;
	}

	private Class2183 method_13()
	{
		if (class2183_2 != null)
		{
			throw new Exception("Only one <clrData> element can be added.");
		}
		class2183_2 = new Class2183();
		return class2183_2;
	}

	private void method_14(Class2183 _clrData)
	{
		class2183_2 = _clrData;
	}

	private Class1885 method_15()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_16(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}
}
