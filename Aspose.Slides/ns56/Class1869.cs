using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1869 : Class1351
{
	public delegate Class1869 Delegate1486();

	public delegate void Delegate1487(Class1869 elementData);

	public delegate void Delegate1488(Class1869 elementData);

	public Class1925.Delegate1642 delegate1642_0;

	public Class1925.Delegate1644 delegate1644_0;

	private LightRigPresetType lightRigPresetType_0;

	private LightingDirection lightingDirection_0;

	private Class1925 class1925_0;

	public LightRigPresetType Rig
	{
		get
		{
			return lightRigPresetType_0;
		}
		set
		{
			lightRigPresetType_0 = value;
		}
	}

	public LightingDirection Dir
	{
		get
		{
			return lightingDirection_0;
		}
		set
		{
			lightingDirection_0 = value;
		}
	}

	public Class1925 Rot => class1925_0;

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
				string localName2;
				if ((localName2 = reader.LocalName) != null && localName2 == "rot")
				{
					class1925_0 = new Class1925(reader);
					continue;
				}
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
					lightingDirection_0 = Class2533.smethod_0(reader.Value);
					break;
				case "rig":
					lightRigPresetType_0 = Class2534.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1869(XmlReader reader)
		: base(reader)
	{
	}

	public Class1869()
	{
	}

	protected override void vmethod_1()
	{
		lightRigPresetType_0 = LightRigPresetType.NotDefined;
		lightingDirection_0 = LightingDirection.NotDefined;
	}

	protected override void vmethod_2()
	{
		delegate1642_0 = method_3;
		delegate1644_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("rig", Class2534.smethod_1(lightRigPresetType_0));
		writer.WriteAttributeString("dir", Class2533.smethod_1(lightingDirection_0));
		if (class1925_0 != null)
		{
			class1925_0.vmethod_4("a", writer, "rot");
		}
		writer.WriteEndElement();
	}

	private Class1925 method_3()
	{
		if (class1925_0 != null)
		{
			throw new Exception("Only one <rot> element can be added.");
		}
		class1925_0 = new Class1925();
		return class1925_0;
	}

	private void method_4(Class1925 _rot)
	{
		class1925_0 = _rot;
	}
}
