using System;
using System.Xml;

namespace ns56;

internal class Class2306 : Class1351
{
	public delegate Class2306 Delegate2665();

	public delegate void Delegate2666(Class2306 elementData);

	public delegate void Delegate2667(Class2306 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private Class2605 class2605_0;

	public Class2605 Target
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
				case "bmkTgt":
					class2605_0 = new Class2605("bmkTgt", new Class1361(reader));
					break;
				case "inkTgt":
					class2605_0 = new Class2605("inkTgt", new Class2295(reader));
					break;
				case "spTgt":
					class2605_0 = new Class2605("spTgt", new Class2294(reader));
					break;
				case "sndTgt":
					class2605_0 = new Class2605("sndTgt", new Class1838(reader));
					break;
				case "sldTgt":
					class2605_0 = new Class2605("sldTgt", new Class2235(reader));
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
	}

	public Class2306(XmlReader reader)
		: base(reader)
	{
	}

	public Class2306()
	{
	}

	protected override void vmethod_1()
	{
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
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "bmkTgt":
				((Class1361)class2605_0.Object).vmethod_4("p14", writer, class2605_0.Name);
				break;
			case "inkTgt":
				((Class2295)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "spTgt":
				((Class2294)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "sndTgt":
				((Class1838)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "sldTgt":
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
			throw new Exception("Target already is initialized.");
		}
		switch (elementName)
		{
		case "bmkTgt":
			class2605_0 = new Class2605("bmkTgt", new Class1361());
			break;
		case "inkTgt":
			class2605_0 = new Class2605("inkTgt", new Class2295());
			break;
		case "spTgt":
			class2605_0 = new Class2605("spTgt", new Class2294());
			break;
		case "sndTgt":
			class2605_0 = new Class2605("sndTgt", new Class1838());
			break;
		case "sldTgt":
			class2605_0 = new Class2605("sldTgt", new Class2235());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
