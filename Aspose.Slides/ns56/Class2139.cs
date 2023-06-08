using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2139 : Class1351
{
	public delegate Class2139 Delegate2149();

	public delegate void Delegate2150(Class2139 elementData);

	public delegate void Delegate2151(Class2139 elementData);

	public const string string_0 = "";

	public const string string_1 = "http://schemas.openxmlformats.org/drawingml/2006/diagram";

	public Class2161.Delegate2215 delegate2215_0;

	public Class2161.Delegate2216 delegate2216_0;

	public Class2160.Delegate2212 delegate2212_0;

	public Class2160.Delegate2213 delegate2213_0;

	public Class2158.Delegate2206 delegate2206_0;

	public Class2158.Delegate2208 delegate2208_0;

	public Class2162.Delegate2218 delegate2218_0;

	public Class2162.Delegate2219 delegate2219_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private string string_2;

	private string string_3;

	private List<Class2161> list_0;

	private List<Class2160> list_1;

	private Class2158 class2158_0;

	private List<Class2162> list_2;

	private Class1886 class1886_0;

	public string UniqueId
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public string MinVer
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

	public Class2161[] TitleList => list_0.ToArray();

	public Class2160[] DescList => list_1.ToArray();

	public Class2158 CatLst => class2158_0;

	public Class2162[] StyleLblList => list_2.ToArray();

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
				case "extLst":
					class1886_0 = new Class1886(reader);
					break;
				case "styleLbl":
				{
					Class2162 item3 = new Class2162(reader);
					list_2.Add(item3);
					break;
				}
				case "catLst":
					class2158_0 = new Class2158(reader);
					break;
				case "desc":
				{
					Class2160 item2 = new Class2160(reader);
					list_1.Add(item2);
					break;
				}
				case "title":
				{
					Class2161 item = new Class2161(reader);
					list_0.Add(item);
					break;
				}
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
				case "minVer":
					string_3 = reader.Value;
					break;
				case "uniqueId":
					string_2 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2139(XmlReader reader)
		: base(reader)
	{
	}

	public Class2139()
	{
	}

	protected override void vmethod_1()
	{
		string_2 = "";
		string_3 = "http://schemas.openxmlformats.org/drawingml/2006/diagram";
		list_0 = new List<Class2161>();
		list_1 = new List<Class2160>();
		list_2 = new List<Class2162>();
	}

	protected override void vmethod_2()
	{
		delegate2215_0 = method_3;
		delegate2216_0 = method_4;
		delegate2212_0 = method_5;
		delegate2213_0 = method_6;
		delegate2206_0 = method_7;
		delegate2208_0 = method_8;
		delegate2218_0 = method_9;
		delegate2219_0 = method_10;
		delegate1534_0 = method_11;
		delegate1535_0 = method_12;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("dgm", elementName, "http://schemas.openxmlformats.org/drawingml/2006/diagram");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/drawingml/2006/main") == null)
		{
			writer.WriteAttributeString("xmlns", "a", null, "http://schemas.openxmlformats.org/drawingml/2006/main");
		}
		if (string_2 != "")
		{
			writer.WriteAttributeString("uniqueId", string_2);
		}
		if (string_3 != "http://schemas.openxmlformats.org/drawingml/2006/diagram")
		{
			writer.WriteAttributeString("minVer", string_3);
		}
		foreach (Class2161 item in list_0)
		{
			item.vmethod_4("dgm", writer, "title");
		}
		foreach (Class2160 item2 in list_1)
		{
			item2.vmethod_4("dgm", writer, "desc");
		}
		if (class2158_0 != null)
		{
			class2158_0.vmethod_4("dgm", writer, "catLst");
		}
		foreach (Class2162 item3 in list_2)
		{
			item3.vmethod_4("dgm", writer, "styleLbl");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("dgm", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2161 method_3()
	{
		Class2161 @class = new Class2161();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2161 elementData)
	{
		list_0.Add(elementData);
	}

	private Class2160 method_5()
	{
		Class2160 @class = new Class2160();
		list_1.Add(@class);
		return @class;
	}

	private void method_6(Class2160 elementData)
	{
		list_1.Add(elementData);
	}

	private Class2158 method_7()
	{
		if (class2158_0 != null)
		{
			throw new Exception("Only one <catLst> element can be added.");
		}
		class2158_0 = new Class2158();
		return class2158_0;
	}

	private void method_8(Class2158 _catLst)
	{
		class2158_0 = _catLst;
	}

	private Class2162 method_9()
	{
		Class2162 @class = new Class2162();
		list_2.Add(@class);
		return @class;
	}

	private void method_10(Class2162 elementData)
	{
		list_2.Add(elementData);
	}

	private Class1885 method_11()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_12(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}
}
