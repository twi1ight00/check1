using System;
using System.Xml;

namespace ns56;

internal class Class2259 : Class1351
{
	public delegate Class2259 Delegate2524();

	public delegate void Delegate2525(Class2259 elementData);

	public delegate void Delegate2526(Class2259 elementData);

	public Class2264.Delegate2539 delegate2539_0;

	public Class2264.Delegate2541 delegate2541_0;

	public Class2224.Delegate2408 delegate2408_0;

	public Class2224.Delegate2410 delegate2410_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class2264 class2264_0;

	private Class2224 class2224_0;

	private Class1889 class1889_0;

	public Class2264 TnLst => class2264_0;

	public Class2224 BldLst => class2224_0;

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
				case "bldLst":
					class2224_0 = new Class2224(reader);
					break;
				case "tnLst":
					class2264_0 = new Class2264(reader);
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

	public Class2259(XmlReader reader)
		: base(reader)
	{
	}

	public Class2259()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2539_0 = method_3;
		delegate2541_0 = method_4;
		delegate2408_0 = method_5;
		delegate2410_0 = method_6;
		delegate1534_0 = method_7;
		delegate1535_0 = method_8;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class2264_0 != null)
		{
			class2264_0.vmethod_4("p", writer, "tnLst");
		}
		if (class2224_0 != null)
		{
			class2224_0.vmethod_4("p", writer, "bldLst");
		}
		if (class1889_0 != null)
		{
			class1889_0.vmethod_4("p", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2264 method_3()
	{
		if (class2264_0 != null)
		{
			throw new Exception("Only one <tnLst> element can be added.");
		}
		class2264_0 = new Class2264();
		return class2264_0;
	}

	private void method_4(Class2264 _tnLst)
	{
		class2264_0 = _tnLst;
	}

	private Class2224 method_5()
	{
		if (class2224_0 != null)
		{
			throw new Exception("Only one <bldLst> element can be added.");
		}
		class2224_0 = new Class2224();
		return class2224_0;
	}

	private void method_6(Class2224 _bldLst)
	{
		class2224_0 = _bldLst;
	}

	private Class1885 method_7()
	{
		if (class1889_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1889_0 = new Class1889();
		return class1889_0;
	}

	private void method_8(Class1885 _extLst)
	{
		class1889_0 = (Class1889)_extLst;
	}
}
