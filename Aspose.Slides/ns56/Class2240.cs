using System.Xml;
using Aspose.Slides.SlideShow;

namespace ns56;

internal class Class2240 : Class1351
{
	public delegate Class2240 Delegate2464();

	public delegate void Delegate2465(Class2240 elementData);

	public delegate void Delegate2466(Class2240 elementData);

	private TransitionInOutDirectionType transitionInOutDirectionType_0;

	public static readonly TransitionInOutDirectionType transitionInOutDirectionType_1 = Class2603.smethod_0("out");

	public TransitionInOutDirectionType Dir
	{
		get
		{
			return transitionInOutDirectionType_0;
		}
		set
		{
			transitionInOutDirectionType_0 = value;
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
				transitionInOutDirectionType_0 = Class2603.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2240(XmlReader reader)
		: base(reader)
	{
	}

	public Class2240()
	{
	}

	protected override void vmethod_1()
	{
		transitionInOutDirectionType_0 = transitionInOutDirectionType_1;
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
		if (transitionInOutDirectionType_0 != transitionInOutDirectionType_1)
		{
			writer.WriteAttributeString("dir", Class2603.smethod_1(transitionInOutDirectionType_0));
		}
		writer.WriteEndElement();
	}
}
