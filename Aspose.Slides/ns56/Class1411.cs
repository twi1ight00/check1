using System;
using System.Xml;

namespace ns56;

internal class Class1411 : Class1351
{
	public delegate Class1411 Delegate195();

	public delegate void Delegate197(Class1411 elementData);

	public delegate void Delegate196(Class1411 elementData);

	public const bool bool_0 = true;

	public Class1419.Delegate219 delegate219_0;

	public Class1419.Delegate221 delegate221_0;

	private bool bool_1;

	private string string_0;

	private Class1419 class1419_0;

	public bool Published
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

	public string CodeName
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class1419 TabColor => class1419_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "tabColor")
				{
					class1419_0 = new Class1419(reader);
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
				case "codeName":
					string_0 = reader.Value;
					break;
				case "published":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1411(XmlReader reader)
		: base(reader)
	{
	}

	public Class1411()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = true;
	}

	protected override void vmethod_2()
	{
		delegate219_0 = method_3;
		delegate221_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (!bool_1)
		{
			writer.WriteAttributeString("published", bool_1 ? "1" : "0");
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("codeName", string_0);
		}
		if (class1419_0 != null)
		{
			class1419_0.vmethod_4("ssml", writer, "tabColor");
		}
		writer.WriteEndElement();
	}

	private Class1419 method_3()
	{
		if (class1419_0 != null)
		{
			throw new Exception("Only one <tabColor> element can be added.");
		}
		class1419_0 = new Class1419();
		return class1419_0;
	}

	private void method_4(Class1419 _tabColor)
	{
		class1419_0 = _tabColor;
	}
}
