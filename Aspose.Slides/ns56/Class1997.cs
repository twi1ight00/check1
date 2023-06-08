using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1997 : Class1995
{
	public delegate void Delegate2311(Class1997 elementData);

	private Class2001 class2001_0;

	private Class1861 class1861_0;

	private List<Class2605> list_0;

	private Class1886 class1886_0;

	public override Class1999 NvGrpSpPr => class2001_0;

	public override Class1861 GrpSpPr => class1861_0;

	public override Class2605[] ShapeList => list_0.ToArray();

	public override Class1885 ExtLst => class1886_0;

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
				case "grpSp":
				{
					Class1997 obj2 = new Class1997(reader);
					list_0.Add(new Class2605("grpSp", obj2));
					break;
				}
				case "sp":
				{
					Class2013 obj = new Class2013(reader);
					list_0.Add(new Class2605("sp", obj));
					break;
				}
				case "grpSpPr":
					class1861_0 = new Class1861(reader);
					break;
				case "nvGrpSpPr":
					class2001_0 = new Class2001(reader);
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
	}

	public Class1997(XmlReader reader)
		: base(reader)
	{
	}

	public Class1997()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2605>();
	}

	protected override void vmethod_2()
	{
		delegate2773_0 = method_5;
		delegate1534_0 = method_3;
		delegate1535_0 = method_4;
	}

	protected override void vmethod_3()
	{
		class2001_0 = new Class2001();
		class1861_0 = new Class1861();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class2001_0.vmethod_4("dsp", writer, "nvGrpSpPr");
		class1861_0.vmethod_4("dsp", writer, "grpSpPr");
		foreach (Class2605 item in list_0)
		{
			switch (item.Name)
			{
			case "grpSp":
				((Class1997)item.Object).vmethod_4("dsp", writer, item.Name);
				break;
			case "sp":
				((Class2013)item.Object).vmethod_4("dsp", writer, item.Name);
				break;
			}
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("dsp", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1885 method_3()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_4(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}

	private Class2605 method_5(string elementName)
	{
		Class2605 @class = elementName switch
		{
			"grpSp" => new Class2605("grpSp", new Class1997()), 
			"sp" => new Class2605("sp", new Class2013()), 
			_ => throw new Exception("Wrong element: " + elementName), 
		};
		list_0.Add(@class);
		return @class;
	}

	public void method_6(Class2605 obj)
	{
		list_0.Add(obj);
	}
}
