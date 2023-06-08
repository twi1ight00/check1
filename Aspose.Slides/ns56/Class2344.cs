using System;
using System.Globalization;
using System.Xml;

namespace ns56;

internal class Class2344 : Class1351
{
	public delegate Class2344 Delegate2771();

	public delegate void Delegate2772(Class2344 elementData);

	private string string_0;

	private int int_0;

	private string string_1;

	private string string_2;

	private Class2605 class2605_0;

	public string Fmtid
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

	public int Pid
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public string Name
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

	internal string LinkTarget
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

	public Class2605 PropertyValue
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
				case "vector":
					reader.Skip();
					flag = true;
					break;
				case "array":
					reader.Skip();
					flag = true;
					break;
				case "blob":
					reader.Skip();
					flag = true;
					break;
				case "oblob":
					reader.Skip();
					flag = true;
					break;
				case "empty":
					reader.Skip();
					flag = true;
					break;
				case "null":
					reader.Skip();
					flag = true;
					break;
				case "i1":
					reader.Skip();
					flag = true;
					break;
				case "i2":
					reader.Skip();
					flag = true;
					break;
				case "i4":
					reader.Read();
					class2605_0 = new Class2605("i4", int.Parse(reader.Value));
					break;
				case "i8":
					reader.Skip();
					flag = true;
					break;
				case "int":
					reader.Skip();
					flag = true;
					break;
				case "ui1":
					reader.Skip();
					flag = true;
					break;
				case "ui2":
					reader.Skip();
					flag = true;
					break;
				case "ui4":
					reader.Skip();
					flag = true;
					break;
				case "ui8":
					reader.Skip();
					flag = true;
					break;
				case "uint":
					reader.Skip();
					flag = true;
					break;
				case "r4":
					reader.Read();
					class2605_0 = new Class2605("r4", float.Parse(reader.Value));
					break;
				case "r8":
					reader.Read();
					class2605_0 = new Class2605("r8", double.Parse(reader.Value));
					break;
				case "decimal":
					reader.Skip();
					flag = true;
					break;
				case "lpstr":
					reader.Skip();
					flag = true;
					break;
				case "lpwstr":
					reader.Read();
					class2605_0 = new Class2605("lpwstr", reader.Value);
					break;
				case "bstr":
					reader.Skip();
					flag = true;
					break;
				case "date":
					reader.Skip();
					flag = true;
					break;
				case "filetime":
					reader.Read();
					class2605_0 = new Class2605("filetime", DateTime.Parse(reader.Value, CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal));
					break;
				case "bool":
					reader.Read();
					class2605_0 = new Class2605("bool", XmlConvert.ToBoolean(reader.Value));
					break;
				case "cy":
					reader.Skip();
					flag = true;
					break;
				case "error":
					reader.Skip();
					flag = true;
					break;
				case "stream":
					reader.Skip();
					flag = true;
					break;
				case "ostream":
					reader.Skip();
					flag = true;
					break;
				case "storage":
					reader.Skip();
					flag = true;
					break;
				case "ostorage":
					reader.Skip();
					flag = true;
					break;
				case "vstream":
					reader.Skip();
					flag = true;
					break;
				case "clsid":
					reader.Skip();
					flag = true;
					break;
				case "cf":
					reader.Skip();
					flag = true;
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
		string namespaceURI = reader.NamespaceURI;
		while (reader.MoveToNextAttribute())
		{
			if (!(reader.Prefix == "xmlns"))
			{
				switch ((reader.LookupNamespace(reader.Prefix) == namespaceURI) ? reader.LocalName : reader.Name)
				{
				case "linkTarget":
					string_2 = reader.Value;
					break;
				case "name":
					string_1 = reader.Value;
					break;
				case "pid":
					int_0 = XmlConvert.ToInt32(reader.Value);
					break;
				case "fmtid":
					string_0 = reader.Value;
					break;
				default:
					throw new Exception("Unknown attribute \"" + reader.Name + "\"");
				}
			}
		}
		reader.MoveToElement();
	}

	internal Class2344(XmlReader reader)
		: base(reader)
	{
	}

	internal Class2344()
	{
	}

	protected override void vmethod_1()
	{
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
		writer.WriteAttributeString("fmtid", string_0);
		writer.WriteAttributeString("pid", XmlConvert.ToString(int_0));
		if (string_1 != null)
		{
			writer.WriteAttributeString("name", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("linkTarget", string_2);
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "i4":
				writer.WriteElementString("vt:i4", XmlConvert.ToString((int)class2605_0.Object));
				break;
			case "r4":
				writer.WriteElementString("vt:r4", XmlConvert.ToString((float)class2605_0.Object));
				break;
			case "r8":
				writer.WriteElementString("vt:r8", XmlConvert.ToString((double)class2605_0.Object));
				break;
			case "lpwstr":
				writer.WriteElementString("vt:lpwstr", (string)class2605_0.Object);
				break;
			case "filetime":
				writer.WriteElementString("vt:filetime", XmlConvert.ToString((DateTime)class2605_0.Object));
				break;
			case "bool":
				writer.WriteElementString("vt:bool", XmlConvert.ToString((bool)class2605_0.Object));
				break;
			}
		}
		writer.WriteEndElement();
	}

	public Class2605 method_3(object value)
	{
		if (class2605_0 != null)
		{
			throw new Exception("PropertyValue already is initialized.");
		}
		if (value is string)
		{
			class2605_0 = new Class2605("lpwstr", value);
		}
		else if (value is DateTime)
		{
			class2605_0 = new Class2605("filetime", value);
		}
		else if (value is bool)
		{
			class2605_0 = new Class2605("bool", value);
		}
		else if (value is int)
		{
			class2605_0 = new Class2605("i4", value);
		}
		else if (value is float)
		{
			class2605_0 = new Class2605("r4", value);
		}
		else if (value is double)
		{
			class2605_0 = new Class2605("r8", value);
		}
		return class2605_0;
	}
}
