using System;
using System.Xml;

namespace ns56;

internal class Class2221 : Class1351
{
	public delegate Class2221 Delegate2399();

	public delegate void Delegate2400(Class2221 elementData);

	public delegate void Delegate2401(Class2221 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public Class2249.Delegate2492 delegate2492_0;

	public Class2249.Delegate2494 delegate2494_0;

	public Class2232.Delegate2434 delegate2434_0;

	public Class2232.Delegate2436 delegate2436_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class2605.Delegate2773 delegate2773_0;

	private bool bool_2;

	private bool bool_3;

	private Class2249 class2249_0;

	private Class2605 class2605_0;

	private Class2232 class2232_0;

	private Class1888 class1888_0;

	public bool IsPhoto
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

	public bool UserDrawn
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

	public Class2249 Ph => class2249_0;

	public Class2605 Media
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

	public Class2232 CustDataLst => class2232_0;

	public Class1885 ExtLst => class1888_0;

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
				case "ph":
					class2249_0 = new Class2249(reader);
					break;
				case "audioCd":
					class2605_0 = new Class2605("audioCd", new Class1799(reader));
					break;
				case "wavAudioFile":
					class2605_0 = new Class2605("wavAudioFile", new Class1838(reader));
					break;
				case "audioFile":
					class2605_0 = new Class2605("audioFile", new Class1801(reader));
					break;
				case "videoFile":
					class2605_0 = new Class2605("videoFile", new Class1979(reader));
					break;
				case "quickTimeFile":
					class2605_0 = new Class2605("quickTimeFile", new Class1912(reader));
					break;
				case "custDataLst":
					class2232_0 = new Class2232(reader);
					break;
				case "extLst":
					class1888_0 = new Class1888(reader);
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
				case "userDrawn":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "isPhoto":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2221(XmlReader reader)
		: base(reader)
	{
	}

	public Class2221()
	{
	}

	protected override void vmethod_1()
	{
		bool_2 = false;
		bool_3 = false;
	}

	protected override void vmethod_2()
	{
		delegate2492_0 = method_3;
		delegate2494_0 = method_4;
		delegate2773_0 = method_9;
		delegate2434_0 = method_5;
		delegate2436_0 = method_6;
		delegate1534_0 = method_7;
		delegate1535_0 = method_8;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (bool_2)
		{
			writer.WriteAttributeString("isPhoto", bool_2 ? "1" : "0");
		}
		if (bool_3)
		{
			writer.WriteAttributeString("userDrawn", bool_3 ? "1" : "0");
		}
		if (class2249_0 != null)
		{
			class2249_0.vmethod_4("p", writer, "ph");
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "quickTimeFile":
				((Class1912)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "videoFile":
				((Class1979)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "audioFile":
				((Class1801)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "wavAudioFile":
				((Class1838)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "audioCd":
				((Class1799)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			}
		}
		if (class2232_0 != null)
		{
			class2232_0.vmethod_4("p", writer, "custDataLst");
		}
		if (class1888_0 != null)
		{
			class1888_0.vmethod_4("p", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2249 method_3()
	{
		if (class2249_0 != null)
		{
			throw new Exception("Only one <ph> element can be added.");
		}
		class2249_0 = new Class2249();
		return class2249_0;
	}

	private void method_4(Class2249 _ph)
	{
		class2249_0 = _ph;
	}

	private Class2232 method_5()
	{
		if (class2232_0 != null)
		{
			throw new Exception("Only one <custDataLst> element can be added.");
		}
		class2232_0 = new Class2232();
		return class2232_0;
	}

	private void method_6(Class2232 _custDataLst)
	{
		class2232_0 = _custDataLst;
	}

	private Class1885 method_7()
	{
		if (class1888_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1888_0 = new Class1888();
		return class1888_0;
	}

	private void method_8(Class1885 _extLst)
	{
		class1888_0 = (Class1888)_extLst;
	}

	private Class2605 method_9(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("Media already is initialized.");
		}
		switch (elementName)
		{
		case "quickTimeFile":
			class2605_0 = new Class2605("quickTimeFile", new Class1912());
			break;
		case "videoFile":
			class2605_0 = new Class2605("videoFile", new Class1979());
			break;
		case "audioFile":
			class2605_0 = new Class2605("audioFile", new Class1801());
			break;
		case "wavAudioFile":
			class2605_0 = new Class2605("wavAudioFile", new Class1838());
			break;
		case "audioCd":
			class2605_0 = new Class2605("audioCd", new Class1799());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
