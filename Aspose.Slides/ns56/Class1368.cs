using System;
using System.Xml;

namespace ns56;

internal class Class1368 : Class1351
{
	public delegate Class1368 Delegate66();

	public delegate void Delegate67(Class1368 elementData);

	public delegate void Delegate68(Class1368 elementData);

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Enum181 enum181_0;

	private Class1888 class1888_0;

	public static readonly Enum181 enum181_1 = Class2347.smethod_0("none");

	public Enum181 FollowColorScheme
	{
		get
		{
			return enum181_0;
		}
		set
		{
			enum181_0 = value;
		}
	}

	public Class1885 ExtLst => class1888_0;

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
				string localName2;
				if ((localName2 = reader.LocalName) != null && localName2 == "extLst")
				{
					class1888_0 = new Class1888(reader);
					continue;
				}
				reader.Skip();
				flag = true;
			}
		}
	}

	private void method_2(XmlReader reader)
	{
		while (reader.MoveToNextAttribute())
		{
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "followColorScheme")
			{
				enum181_0 = Class2347.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1368(XmlReader reader)
		: base(reader)
	{
	}

	public Class1368()
	{
	}

	protected override void vmethod_1()
	{
		enum181_0 = enum181_1;
	}

	protected override void vmethod_2()
	{
		delegate1534_0 = method_3;
		delegate1535_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum181_0 != enum181_1)
		{
			writer.WriteAttributeString("followColorScheme", Class2347.smethod_1(enum181_0));
		}
		if (class1888_0 != null)
		{
			class1888_0.vmethod_4("p", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1885 method_3()
	{
		if (class1888_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1888_0 = new Class1888();
		return class1888_0;
	}

	private void method_4(Class1885 _extLst)
	{
		class1888_0 = (Class1888)_extLst;
	}
}
