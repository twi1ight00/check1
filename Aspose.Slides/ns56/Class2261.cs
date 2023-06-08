using System.Xml;
using Aspose.Slides;
using Aspose.Slides.SlideShow;

namespace ns56;

internal class Class2261 : Class1351
{
	public delegate Class2261 Delegate2530();

	public delegate void Delegate2531(Class2261 elementData);

	public delegate void Delegate2532(Class2261 elementData);

	private Orientation orientation_0;

	private TransitionInOutDirectionType transitionInOutDirectionType_0;

	public static readonly Orientation orientation_1 = Class2526.smethod_0("horz");

	public static readonly TransitionInOutDirectionType transitionInOutDirectionType_1 = Class2603.smethod_0("out");

	public Orientation Orient
	{
		get
		{
			return orientation_0;
		}
		set
		{
			orientation_0 = value;
		}
	}

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
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "dir":
					transitionInOutDirectionType_0 = Class2603.smethod_0(reader.Value);
					break;
				case "orient":
					orientation_0 = Class2526.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2261(XmlReader reader)
		: base(reader)
	{
	}

	public Class2261()
	{
	}

	protected override void vmethod_1()
	{
		orientation_0 = orientation_1;
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
		if (orientation_0 != orientation_1)
		{
			writer.WriteAttributeString("orient", Class2526.smethod_1(orientation_0));
		}
		if (transitionInOutDirectionType_0 != transitionInOutDirectionType_1)
		{
			writer.WriteAttributeString("dir", Class2603.smethod_1(transitionInOutDirectionType_0));
		}
		writer.WriteEndElement();
	}
}
