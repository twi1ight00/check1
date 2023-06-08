using System.Xml;
using Aspose.Slides.SlideShow;

namespace ns56;

internal class Class1363 : Class1351
{
	public delegate Class1363 Delegate51();

	public delegate void Delegate52(Class1363 elementData);

	public delegate void Delegate53(Class1363 elementData);

	public const bool bool_0 = false;

	private bool bool_1;

	private TransitionLeftRightDirectionType transitionLeftRightDirectionType_0;

	public static readonly TransitionLeftRightDirectionType transitionLeftRightDirectionType_1 = Class2430.smethod_0("l");

	public bool ThruBlk
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

	public TransitionLeftRightDirectionType Dir
	{
		get
		{
			return transitionLeftRightDirectionType_0;
		}
		set
		{
			transitionLeftRightDirectionType_0 = value;
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
				case "dir":
					transitionLeftRightDirectionType_0 = Class2430.smethod_0(reader.Value);
					break;
				case "thruBlk":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1363(XmlReader reader)
		: base(reader)
	{
	}

	public Class1363()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = false;
		transitionLeftRightDirectionType_0 = transitionLeftRightDirectionType_1;
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
		if (bool_1)
		{
			writer.WriteAttributeString("thruBlk", bool_1 ? "1" : "0");
		}
		if (transitionLeftRightDirectionType_0 != transitionLeftRightDirectionType_1)
		{
			writer.WriteAttributeString("dir", Class2430.smethod_1(transitionLeftRightDirectionType_0));
		}
		writer.WriteEndElement();
	}
}
