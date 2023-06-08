using System.Xml;
using Aspose.Slides.SlideShow;

namespace ns56;

internal class Class1358 : Class1351
{
	public delegate Class1358 Delegate36();

	public delegate void Delegate37(Class1358 elementData);

	public delegate void Delegate38(Class1358 elementData);

	public const bool bool_0 = false;

	private TransitionInOutDirectionType transitionInOutDirectionType_0;

	private bool bool_1;

	public static readonly TransitionInOutDirectionType transitionInOutDirectionType_1 = Class2603.smethod_0("in");

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

	public bool HasBounce
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
				case "hasBounce":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "dir":
					transitionInOutDirectionType_0 = Class2603.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1358(XmlReader reader)
		: base(reader)
	{
	}

	public Class1358()
	{
	}

	protected override void vmethod_1()
	{
		transitionInOutDirectionType_0 = transitionInOutDirectionType_1;
		bool_1 = false;
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
		if (bool_1)
		{
			writer.WriteAttributeString("hasBounce", bool_1 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
