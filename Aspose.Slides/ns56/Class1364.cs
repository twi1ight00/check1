using System.Xml;
using Aspose.Slides.SlideShow;

namespace ns56;

internal class Class1364 : Class1351
{
	public delegate Class1364 Delegate54();

	public delegate void Delegate55(Class1364 elementData);

	public delegate void Delegate56(Class1364 elementData);

	private TransitionCornerAndCenterDirectionType transitionCornerAndCenterDirectionType_0;

	public static readonly TransitionCornerAndCenterDirectionType transitionCornerAndCenterDirectionType_1 = Class2429.smethod_0("center");

	public TransitionCornerAndCenterDirectionType Dir
	{
		get
		{
			return transitionCornerAndCenterDirectionType_0;
		}
		set
		{
			transitionCornerAndCenterDirectionType_0 = value;
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
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "dir")
			{
				transitionCornerAndCenterDirectionType_0 = Class2429.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1364(XmlReader reader)
		: base(reader)
	{
	}

	public Class1364()
	{
	}

	protected override void vmethod_1()
	{
		transitionCornerAndCenterDirectionType_0 = transitionCornerAndCenterDirectionType_1;
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
		if (transitionCornerAndCenterDirectionType_0 != transitionCornerAndCenterDirectionType_1)
		{
			writer.WriteAttributeString("dir", Class2429.smethod_1(transitionCornerAndCenterDirectionType_0));
		}
		writer.WriteEndElement();
	}
}
