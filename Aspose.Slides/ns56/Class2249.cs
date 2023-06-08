using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class2249 : Class1351
{
	public delegate Class2249 Delegate2492();

	public delegate void Delegate2494(Class2249 elementData);

	public delegate void Delegate2493(Class2249 elementData);

	public const uint uint_0 = 0u;

	public const bool bool_0 = false;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private PlaceholderType placeholderType_0;

	private Orientation orientation_0;

	private PlaceholderSize placeholderSize_0;

	private uint uint_1;

	private bool bool_1;

	private Class1889 class1889_0;

	public static readonly PlaceholderType placeholderType_1 = Class2545.smethod_0("obj");

	public static readonly Orientation orientation_1 = Class2526.smethod_0("horz");

	public static readonly PlaceholderSize placeholderSize_1 = Class2544.smethod_0("full");

	public PlaceholderType Type
	{
		get
		{
			return placeholderType_0;
		}
		set
		{
			placeholderType_0 = value;
		}
	}

	public Orientation Orient
	{
		get
		{
			return orientation_0;
		}
		set
		{
			orientation_0 = value;
		}
	}

	public PlaceholderSize Sz
	{
		get
		{
			return placeholderSize_0;
		}
		set
		{
			placeholderSize_0 = value;
		}
	}

	public uint Idx
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public bool HasCustomPrompt
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
				string localName2;
				if ((localName2 = reader.LocalName) != null && localName2 == "extLst")
				{
					class1889_0 = new Class1889(reader);
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
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "hasCustomPrompt":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "idx":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "sz":
					placeholderSize_0 = Class2544.smethod_0(reader.Value);
					break;
				case "orient":
					orientation_0 = Class2526.smethod_0(reader.Value);
					break;
				case "type":
					placeholderType_0 = Class2545.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2249(XmlReader reader)
		: base(reader)
	{
	}

	public Class2249()
	{
	}

	protected override void vmethod_1()
	{
		placeholderType_0 = placeholderType_1;
		orientation_0 = orientation_1;
		placeholderSize_0 = placeholderSize_1;
		uint_1 = 0u;
		bool_1 = false;
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
		if (placeholderType_0 != placeholderType_1)
		{
			writer.WriteAttributeString("type", Class2545.smethod_1(placeholderType_0));
		}
		if (orientation_0 != orientation_1)
		{
			writer.WriteAttributeString("orient", Class2526.smethod_1(orientation_0));
		}
		if (placeholderSize_0 != placeholderSize_1)
		{
			writer.WriteAttributeString("sz", Class2544.smethod_1(placeholderSize_0));
		}
		if (uint_1 != 0)
		{
			writer.WriteAttributeString("idx", XmlConvert.ToString(uint_1));
		}
		if (bool_1)
		{
			writer.WriteAttributeString("hasCustomPrompt", bool_1 ? "1" : "0");
		}
		if (class1889_0 != null)
		{
			class1889_0.vmethod_4("p", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1885 method_3()
	{
		if (class1889_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1889_0 = new Class1889();
		return class1889_0;
	}

	private void method_4(Class1885 _extLst)
	{
		class1889_0 = (Class1889)_extLst;
	}
}
