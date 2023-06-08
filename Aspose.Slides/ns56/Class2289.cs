using System.Xml;

namespace ns56;

internal class Class2289 : Class1351
{
	public delegate Class2289 Delegate2614();

	public delegate void Delegate2615(Class2289 elementData);

	public delegate void Delegate2616(Class2289 elementData);

	public const bool bool_0 = false;

	private bool bool_1;

	private Class2282 class2282_0;

	public bool FullScrn
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

	public Class2282 CMediaNode => class2282_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "cMediaNode")
				{
					class2282_0 = new Class2282(reader);
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "fullScrn")
			{
				bool_1 = XmlConvert.ToBoolean(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2289(XmlReader reader)
		: base(reader)
	{
	}

	public Class2289()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = false;
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
		class2282_0 = new Class2282();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (bool_1)
		{
			writer.WriteAttributeString("fullScrn", bool_1 ? "1" : "0");
		}
		class2282_0.vmethod_4("p", writer, "cMediaNode");
		writer.WriteEndElement();
	}
}
