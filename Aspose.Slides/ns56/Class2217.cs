using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2217 : Class1351
{
	public delegate Class2217 Delegate2387();

	public delegate void Delegate2388(Class2217 elementData);

	public delegate void Delegate2389(Class2217 elementData);

	public Class2218.Delegate2390 delegate2390_0;

	public Class2218.Delegate2391 delegate2391_0;

	private Enum353 enum353_0;

	private uint uint_0;

	private List<Class2218> list_0;

	public static readonly Enum353 enum353_1 = Class2489.smethod_0("f");

	public Enum353 Recolorstate
	{
		get
		{
			return enum353_0;
		}
		set
		{
			enum353_0 = value;
		}
	}

	public uint Numcolors
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public Class2218[] RecolorinfoentryList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "recolorinfoentry")
				{
					Class2218 item = new Class2218(reader);
					list_0.Add(item);
				}
				else
				{
					reader.Skip();
					flag = true;
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
				case "numcolors":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "recolorstate":
					enum353_0 = Class2489.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2217(XmlReader reader)
		: base(reader)
	{
	}

	public Class2217()
	{
	}

	protected override void vmethod_1()
	{
		enum353_0 = enum353_1;
		list_0 = new List<Class2218>();
	}

	protected override void vmethod_2()
	{
		delegate2390_0 = method_3;
		delegate2391_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum353_0 != enum353_1)
		{
			writer.WriteAttributeString("recolorstate", Class2489.smethod_1(enum353_0));
		}
		writer.WriteAttributeString("numcolors", XmlConvert.ToString(uint_0));
		foreach (Class2218 item in list_0)
		{
			item.vmethod_4("ppt", writer, "recolorinfoentry");
		}
		writer.WriteEndElement();
	}

	private Class2218 method_3()
	{
		Class2218 @class = new Class2218();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2218 elementData)
	{
		list_0.Add(elementData);
	}
}
