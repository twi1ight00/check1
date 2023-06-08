using System;
using System.Xml;

namespace ns56;

internal class Class2284 : Class1351
{
	public delegate Class2284 Delegate2599();

	public delegate void Delegate2600(Class2284 elementData);

	public delegate void Delegate2601(Class2284 elementData);

	public const bool bool_0 = false;

	public Class2605.Delegate2773 delegate2773_0;

	private string string_0;

	private uint uint_0;

	private bool bool_1;

	private Class2605 class2605_0;

	public string Spid
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

	public uint GrpId
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public bool UiExpand
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

	public Class2605 BuildProperties
	{
		get
		{
			return class2605_0;
		}
		set
		{
			class2605_0 = value;
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
				switch (reader.LocalName)
				{
				case "bldSub":
					class2605_0 = new Class2605("bldSub", new Class1798(reader));
					break;
				case "bldAsOne":
					class2605_0 = new Class2605("bldAsOne", new Class2235(reader));
					break;
				default:
					reader.Skip();
					flag = true;
					break;
				}
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
				case "uiExpand":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "grpId":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "spid":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2284(XmlReader reader)
		: base(reader)
	{
	}

	public Class2284()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = false;
	}

	protected override void vmethod_2()
	{
		delegate2773_0 = method_3;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("spid", string_0);
		writer.WriteAttributeString("grpId", XmlConvert.ToString(uint_0));
		if (bool_1)
		{
			writer.WriteAttributeString("uiExpand", bool_1 ? "1" : "0");
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "bldSub":
				((Class1798)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "bldAsOne":
				((Class2235)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("BuildProperties already is initialized.");
		}
		switch (elementName)
		{
		case "bldSub":
			class2605_0 = new Class2605("bldSub", new Class1798());
			break;
		case "bldAsOne":
			class2605_0 = new Class2605("bldAsOne", new Class2235());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
