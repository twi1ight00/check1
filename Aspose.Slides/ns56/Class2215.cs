using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2215 : Class1351
{
	public delegate Class2215 Delegate2381();

	public delegate void Delegate2382(Class2215 elementData);

	public delegate void Delegate2383(Class2215 elementData);

	public const string string_0 = "";

	public const string string_1 = "http://schemas.openxmlformats.org/drawingml/2006/diagram";

	public Class2187.Delegate2293 delegate2293_0;

	public Class2187.Delegate2294 delegate2294_0;

	public Class2186.Delegate2290 delegate2290_0;

	public Class2186.Delegate2291 delegate2291_0;

	public Class2184.Delegate2284 delegate2284_0;

	public Class2184.Delegate2286 delegate2286_0;

	public Class1916.Delegate1615 delegate1615_0;

	public Class1916.Delegate1617 delegate1617_0;

	public Class2189.Delegate2299 delegate2299_0;

	public Class2189.Delegate2300 delegate2300_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private string string_2;

	private string string_3;

	private List<Class2187> list_0;

	private List<Class2186> list_1;

	private Class2184 class2184_0;

	private Class1916 class1916_0;

	private List<Class2189> list_2;

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

	public Class2187[] TitleList => list_0.ToArray();

	public Class2186[] DescList => list_1.ToArray();

	public Class2184 CatLst => class2184_0;

	public Class1916 Scene3d => class1916_0;

	public Class2189[] StyleLblList => list_2.ToArray();

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
					Class2187 item3 = new Class2187(reader);
					list_0.Add(item3);
					break;
				}
				case "desc":
				{
					Class2186 item2 = new Class2186(reader);
					list_1.Add(item2);
					break;
				}
				case "catLst":
					class2184_0 = new Class2184(reader);
					break;
				case "scene3d":
					class1916_0 = new Class1916(reader);
					break;
				case "styleLbl":
				{
					Class2189 item = new Class2189(reader);
					list_2.Add(item);
					break;
				}
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

	public Class2215(XmlReader reader)
		: base(reader)
	{
	}

	public Class2215()
	{
	}

	protected override void vmethod_1()
	{
		string_2 = "";
		string_3 = "http://schemas.openxmlformats.org/drawingml/2006/diagram";
		list_0 = new List<Class2187>();
		list_1 = new List<Class2186>();
		list_2 = new List<Class2189>();
	}

	protected override void vmethod_2()
	{
		delegate2293_0 = method_3;
		delegate2294_0 = method_4;
		delegate2290_0 = method_5;
		delegate2291_0 = method_6;
		delegate2284_0 = method_7;
		delegate2286_0 = method_8;
		delegate1615_0 = method_9;
		delegate1617_0 = method_10;
		delegate2299_0 = method_11;
		delegate2300_0 = method_12;
		delegate1534_0 = method_13;
		delegate1535_0 = method_14;
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
		foreach (Class2187 item in list_0)
		{
			item.vmethod_4("dgm", writer, "title");
		}
		foreach (Class2186 item2 in list_1)
		{
			item2.vmethod_4("dgm", writer, "desc");
		}
		if (class2184_0 != null)
		{
			class2184_0.vmethod_4("dgm", writer, "catLst");
		}
		if (class1916_0 != null)
		{
			class1916_0.vmethod_4("dgm", writer, "scene3d");
		}
		foreach (Class2189 item3 in list_2)
		{
			item3.vmethod_4("dgm", writer, "styleLbl");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("dgm", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2187 method_3()
	{
		Class2187 @class = new Class2187();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2187 elementData)
	{
		list_0.Add(elementData);
	}

	private Class2186 method_5()
	{
		Class2186 @class = new Class2186();
		list_1.Add(@class);
		return @class;
	}

	private void method_6(Class2186 elementData)
	{
		list_1.Add(elementData);
	}

	private Class2184 method_7()
	{
		if (class2184_0 != null)
		{
			throw new Exception("Only one <catLst> element can be added.");
		}
		class2184_0 = new Class2184();
		return class2184_0;
	}

	private void method_8(Class2184 _catLst)
	{
		class2184_0 = _catLst;
	}

	private Class1916 method_9()
	{
		if (class1916_0 != null)
		{
			throw new Exception("Only one <scene3d> element can be added.");
		}
		class1916_0 = new Class1916();
		return class1916_0;
	}

	private void method_10(Class1916 _scene3d)
	{
		class1916_0 = _scene3d;
	}

	private Class2189 method_11()
	{
		Class2189 @class = new Class2189();
		list_2.Add(@class);
		return @class;
	}

	private void method_12(Class2189 elementData)
	{
		list_2.Add(elementData);
	}

	private Class1885 method_13()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_14(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}
}
