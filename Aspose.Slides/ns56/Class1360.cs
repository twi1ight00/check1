using System.Xml;
using Aspose.Slides.SlideShow;

namespace ns56;

internal class Class1360 : Class1351
{
	public delegate Class1360 Delegate42();

	public delegate void Delegate43(Class1360 elementData);

	public delegate void Delegate44(Class1360 elementData);

	private TransitionLeftRightDirectionType transitionLeftRightDirectionType_0;

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
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "dir")
			{
				transitionLeftRightDirectionType_0 = Class2430.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1360(XmlReader reader)
		: base(reader)
	{
	}

	public Class1360()
	{
	}

	protected override void vmethod_1()
	{
		transitionLeftRightDirectionType_0 = TransitionLeftRightDirectionType.Right;
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
		writer.WriteAttributeString("dir", Class2430.smethod_1(transitionLeftRightDirectionType_0));
		writer.WriteEndElement();
	}
}
