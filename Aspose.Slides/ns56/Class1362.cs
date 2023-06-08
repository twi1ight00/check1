using System.Xml;
using Aspose.Slides.SlideShow;

namespace ns56;

internal class Class1362 : Class1351
{
	public delegate Class1362 Delegate48();

	public delegate void Delegate49(Class1362 elementData);

	public delegate void Delegate50(Class1362 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	private TransitionSideDirectionType transitionSideDirectionType_0;

	private bool bool_2;

	private bool bool_3;

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

	public bool IsContent
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool IsInverted
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
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
				case "isInverted":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "isContent":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "dir":
					transitionSideDirectionType_0 = Class2604.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1362(XmlReader reader)
		: base(reader)
	{
	}

	public Class1362()
	{
	}

	protected override void vmethod_1()
	{
		transitionSideDirectionType_0 = transitionSideDirectionType_1;
		bool_2 = false;
		bool_3 = false;
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
		if (bool_2)
		{
			writer.WriteAttributeString("isContent", bool_2 ? "1" : "0");
		}
		if (bool_3)
		{
			writer.WriteAttributeString("isInverted", bool_3 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
