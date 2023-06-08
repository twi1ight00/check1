using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1944 : Class1351
{
	public delegate Class1944 Delegate1699();

	public delegate void Delegate1700(Class1944 elementData);

	public delegate void Delegate1701(Class1944 elementData);

	public const int int_0 = 1;

	private NumberedBulletStyle numberedBulletStyle_0;

	private int int_1;

	public NumberedBulletStyle Type
	{
		get
		{
			return numberedBulletStyle_0;
		}
		set
		{
			numberedBulletStyle_0 = value;
		}
	}

	public int StartAt
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

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
				_ = reader.LocalName;
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
				case "startAt":
					int_1 = XmlConvert.ToInt32(reader.Value);
					break;
				case "type":
					numberedBulletStyle_0 = Class2565.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1944(XmlReader reader)
		: base(reader)
	{
	}

	public Class1944()
	{
	}

	protected override void vmethod_1()
	{
		numberedBulletStyle_0 = NumberedBulletStyle.BulletAlphaLCPeriod;
		int_1 = 1;
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("type", Class2565.smethod_1(numberedBulletStyle_0));
		if (int_1 != 1)
		{
			writer.WriteAttributeString("startAt", XmlConvert.ToString(int_1));
		}
		writer.WriteEndElement();
	}
}
