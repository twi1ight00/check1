using System;
using System.Xml;

namespace ns56;

internal class Class1367 : Class1351
{
	public delegate Class1367 Delegate63();

	public delegate void Delegate65(Class1367 elementData);

	public delegate void Delegate64(Class1367 elementData);

	public const string string_0 = "";

	public const bool bool_0 = false;

	public const double double_0 = double.NaN;

	public const double double_1 = double.NaN;

	public Class2004.Delegate1833 delegate1833_0;

	public Class2004.Delegate1834 delegate1834_0;

	public Class2605.Delegate2773 delegate2773_0;

	private string string_1;

	private string string_2;

	private bool bool_1;

	private string string_3;

	private double double_2;

	private double double_3;

	private string string_4;

	private Class2605 class2605_0;

	private Class2006 class2006_0;

	public string Spid
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public string Name
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public bool ShowAsIcon
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

	public string R_Id
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public double ImgW
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	public double ImgH
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
		}
	}

	public string ProgId
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public Class2605 OleObject
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

	public Class2004 Pic => class2006_0;

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
				case "pic":
					class2006_0 = new Class2006(reader);
					break;
				case "link":
					class2605_0 = new Class2605("link", new Class1369(reader));
					break;
				case "embed":
					class2605_0 = new Class2605("embed", new Class1368(reader));
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
				case "spid":
					string_1 = reader.Value;
					break;
				case "name":
					string_2 = reader.Value;
					break;
				case "showAsIcon":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "r:id":
					string_3 = reader.Value;
					break;
				case "imgW":
					double_2 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "imgH":
					double_3 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "progId":
					string_4 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1367(XmlReader reader)
		: base(reader)
	{
	}

	public Class1367()
	{
	}

	protected override void vmethod_1()
	{
		string_2 = "";
		bool_1 = false;
		double_2 = double.NaN;
		double_3 = double.NaN;
	}

	protected override void vmethod_2()
	{
		delegate2773_0 = method_5;
		delegate1833_0 = method_3;
		delegate1834_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("p", elementName, "http://schemas.openxmlformats.org/presentationml/2006/main");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/drawingml/2006/main") == null)
		{
			writer.WriteAttributeString("xmlns", "a", null, "http://schemas.openxmlformats.org/drawingml/2006/main");
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("spid", string_1);
		}
		if (string_2 != "")
		{
			writer.WriteAttributeString("name", string_2);
		}
		if (bool_1)
		{
			writer.WriteAttributeString("showAsIcon", bool_1 ? "1" : "0");
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("r:id", string_3);
		}
		if (!double.IsNaN(double_2))
		{
			writer.WriteAttributeString("imgW", XmlConvert.ToString((long)Math.Round(double_2 * 12700.0)));
		}
		if (!double.IsNaN(double_3))
		{
			writer.WriteAttributeString("imgH", XmlConvert.ToString((long)Math.Round(double_3 * 12700.0)));
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("progId", string_4);
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "link":
				((Class1369)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "embed":
				((Class1368)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			}
		}
		if (class2006_0 != null)
		{
			class2006_0.vmethod_4("p", writer, "pic");
		}
		writer.WriteEndElement();
	}

	private Class2004 method_3()
	{
		if (class2006_0 != null)
		{
			throw new Exception("Only one <pic> element can be added.");
		}
		class2006_0 = new Class2006();
		return class2006_0;
	}

	private void method_4(Class2004 _pic)
	{
		class2006_0 = (Class2006)_pic;
	}

	private Class2605 method_5(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("OleObject already is initialized.");
		}
		switch (elementName)
		{
		case "link":
			class2605_0 = new Class2605("link", new Class1369());
			break;
		case "embed":
			class2605_0 = new Class2605("embed", new Class1368());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
