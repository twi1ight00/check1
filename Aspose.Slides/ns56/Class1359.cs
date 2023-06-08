using System.Xml;
using Aspose.Slides.SlideShow;

namespace ns56;

internal class Class1359 : Class1351
{
	public delegate Class1359 Delegate39();

	public delegate void Delegate40(Class1359 elementData);

	public delegate void Delegate41(Class1359 elementData);

	private TransitionSideDirectionType transitionSideDirectionType_0;

	private TransitionPattern transitionPattern_0;

	public static readonly TransitionSideDirectionType transitionSideDirectionType_1 = Class2604.smethod_0("l");

	public static readonly TransitionPattern transitionPattern_1 = Class2431.smethod_0("diamond");

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

	public TransitionPattern Pattern
	{
		get
		{
			return transitionPattern_0;
		}
		set
		{
			transitionPattern_0 = value;
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
				case "pattern":
					transitionPattern_0 = Class2431.smethod_0(reader.Value);
					break;
				case "dir":
					transitionSideDirectionType_0 = Class2604.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1359(XmlReader reader)
		: base(reader)
	{
	}

	public Class1359()
	{
	}

	protected override void vmethod_1()
	{
		transitionSideDirectionType_0 = transitionSideDirectionType_1;
		transitionPattern_0 = transitionPattern_1;
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
		if (transitionPattern_0 != transitionPattern_1)
		{
			writer.WriteAttributeString("pattern", Class2431.smethod_1(transitionPattern_0));
		}
		writer.WriteEndElement();
	}
}
