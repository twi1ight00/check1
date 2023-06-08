using System;
using System.Xml;

namespace ns56;

internal class Class1535 : Class1351
{
	public delegate void Delegate486(Class1535 elementData);

	public delegate Class1535 Delegate484();

	public delegate void Delegate485(Class1535 elementData);

	public const uint uint_0 = 16u;

	public Class1534.Delegate481 delegate481_0;

	public Class1534.Delegate483 delegate483_0;

	private uint uint_1;

	private Class1534 class1534_0;

	public uint BuiltInGroupCount
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public Class1534 FunctionGroup => class1534_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "functionGroup")
				{
					class1534_0 = new Class1534(reader);
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
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "builtInGroupCount")
			{
				uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1535(XmlReader reader)
		: base(reader)
	{
	}

	public Class1535()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = 16u;
	}

	protected override void vmethod_2()
	{
		delegate481_0 = method_3;
		delegate483_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (uint_1 != 16)
		{
			writer.WriteAttributeString("builtInGroupCount", XmlConvert.ToString(uint_1));
		}
		if (class1534_0 != null)
		{
			class1534_0.vmethod_4("ssml", writer, "functionGroup");
		}
		writer.WriteEndElement();
	}

	private Class1534 method_3()
	{
		if (class1534_0 != null)
		{
			throw new Exception("Only one <functionGroup> element can be added.");
		}
		class1534_0 = new Class1534();
		return class1534_0;
	}

	private void method_4(Class1534 _functionGroup)
	{
		class1534_0 = _functionGroup;
	}
}
