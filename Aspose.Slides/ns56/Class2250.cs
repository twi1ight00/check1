using System.Xml;
using Aspose.Slides.SlideShow;

namespace ns56;

internal class Class2250 : Class1351
{
	public delegate Class2250 Delegate2497();

	public delegate void Delegate2498(Class2250 elementData);

	public delegate void Delegate2499(Class2250 elementData);

	private TransitionSideDirectionType transitionSideDirectionType_0;

	public static readonly TransitionSideDirectionType transitionSideDirectionType_1 = Class2604.smethod_0("l");

	public TransitionSideDirectionType Dir
	{
		get
		{
			return transitionSideDirectionType_0;
		}
		set
		{
			transitionSideDirectionType_0 = value;
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
				transitionSideDirectionType_0 = Class2604.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2250(XmlReader reader)
		: base(reader)
	{
	}

	public Class2250()
	{
	}

	protected override void vmethod_1()
	{
		transitionSideDirectionType_0 = transitionSideDirectionType_1;
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
		if (transitionSideDirectionType_0 != transitionSideDirectionType_1)
		{
			writer.WriteAttributeString("dir", Class2604.smethod_1(transitionSideDirectionType_0));
		}
		writer.WriteEndElement();
	}
}
