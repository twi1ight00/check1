using System.Xml;

namespace ns56;

internal class Class2296 : Class1351
{
	public delegate Class2296 Delegate2635();

	public delegate void Delegate2636(Class2296 elementData);

	public delegate void Delegate2637(Class2296 elementData);

	public const uint uint_0 = 0u;

	private uint uint_1;

	private Class2264 class2264_0;

	public uint Lvl
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

	public Class2264 TnLst => class2264_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "tnLst")
				{
					class2264_0 = new Class2264(reader);
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "lvl")
			{
				uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2296(XmlReader reader)
		: base(reader)
	{
	}

	public Class2296()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = 0u;
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
		class2264_0 = new Class2264();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (uint_1 != 0)
		{
			writer.WriteAttributeString("lvl", XmlConvert.ToString(uint_1));
		}
		class2264_0.vmethod_4("p", writer, "tnLst");
		writer.WriteEndElement();
	}
}
