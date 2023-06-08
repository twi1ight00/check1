using System.Xml;
using Aspose.Slides.SlideShow;

namespace ns56;

internal class Class2230 : Class1351
{
	public delegate Class2230 Delegate2428();

	public delegate void Delegate2429(Class2230 elementData);

	public delegate void Delegate2430(Class2230 elementData);

	private TransitionCornerDirectionType transitionCornerDirectionType_0;

	public static readonly TransitionCornerDirectionType transitionCornerDirectionType_1 = Class2601.smethod_0("lu");

	public TransitionCornerDirectionType Dir
	{
		get
		{
			return transitionCornerDirectionType_0;
		}
		set
		{
			transitionCornerDirectionType_0 = value;
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
				transitionCornerDirectionType_0 = Class2601.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2230(XmlReader reader)
		: base(reader)
	{
	}

	public Class2230()
	{
	}

	protected override void vmethod_1()
	{
		transitionCornerDirectionType_0 = transitionCornerDirectionType_1;
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
		if (transitionCornerDirectionType_0 != transitionCornerDirectionType_1)
		{
			writer.WriteAttributeString("dir", Class2601.smethod_1(transitionCornerDirectionType_0));
		}
		writer.WriteEndElement();
	}
}
