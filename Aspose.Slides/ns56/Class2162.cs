using System;
using System.Xml;

namespace ns56;

internal class Class2162 : Class1351
{
	public delegate Class2162 Delegate2218();

	public delegate void Delegate2219(Class2162 elementData);

	public delegate void Delegate2220(Class2162 elementData);

	public Class2155.Delegate2197 delegate2197_0;

	public Class2155.Delegate2199 delegate2199_0;

	public Class2155.Delegate2197 delegate2197_1;

	public Class2155.Delegate2199 delegate2199_1;

	public Class2155.Delegate2197 delegate2197_2;

	public Class2155.Delegate2199 delegate2199_2;

	public Class2155.Delegate2197 delegate2197_3;

	public Class2155.Delegate2199 delegate2199_3;

	public Class2155.Delegate2197 delegate2197_4;

	public Class2155.Delegate2199 delegate2199_4;

	public Class2155.Delegate2197 delegate2197_5;

	public Class2155.Delegate2199 delegate2199_5;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private string string_0;

	private Class2155 class2155_0;

	private Class2155 class2155_1;

	private Class2155 class2155_2;

	private Class2155 class2155_3;

	private Class2155 class2155_4;

	private Class2155 class2155_5;

	private Class1886 class1886_0;

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class2155 FillClrLst => class2155_0;

	public Class2155 LinClrLst => class2155_1;

	public Class2155 EffectClrLst => class2155_2;

	public Class2155 TxLinClrLst => class2155_3;

	public Class2155 TxFillClrLst => class2155_4;

	public Class2155 TxEffectClrLst => class2155_5;

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
				case "fillClrLst":
					class2155_0 = new Class2155(reader);
					break;
				case "linClrLst":
					class2155_1 = new Class2155(reader);
					break;
				case "effectClrLst":
					class2155_2 = new Class2155(reader);
					break;
				case "txLinClrLst":
					class2155_3 = new Class2155(reader);
					break;
				case "txFillClrLst":
					class2155_4 = new Class2155(reader);
					break;
				case "txEffectClrLst":
					class2155_5 = new Class2155(reader);
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
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "name")
			{
				string_0 = reader.Value;
			}
		}
		reader.MoveToElement();
	}

	public Class2162(XmlReader reader)
		: base(reader)
	{
	}

	public Class2162()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2197_0 = method_3;
		delegate2199_0 = method_4;
		delegate2197_1 = method_5;
		delegate2199_1 = method_6;
		delegate2197_2 = method_7;
		delegate2199_2 = method_8;
		delegate2197_3 = method_9;
		delegate2199_3 = method_10;
		delegate2197_4 = method_11;
		delegate2199_4 = method_12;
		delegate2197_5 = method_13;
		delegate2199_5 = method_14;
		delegate1534_0 = method_15;
		delegate1535_0 = method_16;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("name", string_0);
		if (class2155_0 != null)
		{
			class2155_0.vmethod_4("dgm", writer, "fillClrLst");
		}
		if (class2155_1 != null)
		{
			class2155_1.vmethod_4("dgm", writer, "linClrLst");
		}
		if (class2155_2 != null)
		{
			class2155_2.vmethod_4("dgm", writer, "effectClrLst");
		}
		if (class2155_3 != null)
		{
			class2155_3.vmethod_4("dgm", writer, "txLinClrLst");
		}
		if (class2155_4 != null)
		{
			class2155_4.vmethod_4("dgm", writer, "txFillClrLst");
		}
		if (class2155_5 != null)
		{
			class2155_5.vmethod_4("dgm", writer, "txEffectClrLst");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("dgm", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2155 method_3()
	{
		if (class2155_0 != null)
		{
			throw new Exception("Only one <fillClrLst> element can be added.");
		}
		class2155_0 = new Class2155();
		return class2155_0;
	}

	private void method_4(Class2155 _fillClrLst)
	{
		class2155_0 = _fillClrLst;
	}

	private Class2155 method_5()
	{
		if (class2155_1 != null)
		{
			throw new Exception("Only one <linClrLst> element can be added.");
		}
		class2155_1 = new Class2155();
		return class2155_1;
	}

	private void method_6(Class2155 _linClrLst)
	{
		class2155_1 = _linClrLst;
	}

	private Class2155 method_7()
	{
		if (class2155_2 != null)
		{
			throw new Exception("Only one <effectClrLst> element can be added.");
		}
		class2155_2 = new Class2155();
		return class2155_2;
	}

	private void method_8(Class2155 _effectClrLst)
	{
		class2155_2 = _effectClrLst;
	}

	private Class2155 method_9()
	{
		if (class2155_3 != null)
		{
			throw new Exception("Only one <txLinClrLst> element can be added.");
		}
		class2155_3 = new Class2155();
		return class2155_3;
	}

	private void method_10(Class2155 _txLinClrLst)
	{
		class2155_3 = _txLinClrLst;
	}

	private Class2155 method_11()
	{
		if (class2155_4 != null)
		{
			throw new Exception("Only one <txFillClrLst> element can be added.");
		}
		class2155_4 = new Class2155();
		return class2155_4;
	}

	private void method_12(Class2155 _txFillClrLst)
	{
		class2155_4 = _txFillClrLst;
	}

	private Class2155 method_13()
	{
		if (class2155_5 != null)
		{
			throw new Exception("Only one <txEffectClrLst> element can be added.");
		}
		class2155_5 = new Class2155();
		return class2155_5;
	}

	private void method_14(Class2155 _txEffectClrLst)
	{
		class2155_5 = _txEffectClrLst;
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
