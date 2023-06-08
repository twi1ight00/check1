using System;
using System.Xml;

namespace ns56;

internal class Class1564 : Class1351
{
	public delegate Class1564 Delegate571();

	public delegate void Delegate572(Class1564 elementData);

	public delegate void Delegate573(Class1564 elementData);

	public Class1447.Delegate303 delegate303_0;

	public Class1447.Delegate304 delegate304_0;

	private uint uint_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private Class1448 class1448_0;

	public uint ID
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

	public string Name
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

	public string RootElement
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

	public string SchemaID
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

	public bool ShowImportExportValidationErrors
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public bool AutoFit
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

	public bool Append
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

	public bool PreserveSortAFLayout
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

	public bool PreserveFormat
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public Class1448 DataBinding => class1448_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "DataBinding")
				{
					class1448_0 = new Class1448(reader);
					flag = true;
				}
				else
				{
					reader.Skip();
					flag = true;
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
				case "ID":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "Name":
					string_0 = reader.Value;
					break;
				case "RootElement":
					string_1 = reader.Value;
					break;
				case "SchemaID":
					string_2 = reader.Value;
					break;
				case "ShowImportExportValidationErrors":
					bool_0 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "AutoFit":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "Append":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "PreserveSortAFLayout":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "PreserveFormat":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1564(XmlReader reader)
		: base(reader)
	{
	}

	public Class1564()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate303_0 = method_3;
		delegate304_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("ID", XmlConvert.ToString(uint_0));
		writer.WriteAttributeString("Name", string_0);
		writer.WriteAttributeString("RootElement", string_1);
		writer.WriteAttributeString("SchemaID", string_2);
		writer.WriteAttributeString("ShowImportExportValidationErrors", bool_0 ? "1" : "0");
		writer.WriteAttributeString("AutoFit", bool_1 ? "1" : "0");
		writer.WriteAttributeString("Append", bool_2 ? "1" : "0");
		writer.WriteAttributeString("PreserveSortAFLayout", bool_3 ? "1" : "0");
		writer.WriteAttributeString("PreserveFormat", bool_4 ? "1" : "0");
		if (class1448_0 != null)
		{
			class1448_0.vmethod_4("ssml", writer, "DataBinding");
		}
		writer.WriteEndElement();
	}

	private Class1447 method_3()
	{
		if (class1448_0 != null)
		{
			throw new Exception("Only one <dataBinding> element can be added.");
		}
		class1448_0 = new Class1448();
		return class1448_0;
	}

	private void method_4(Class1447 _dataBinding)
	{
		class1448_0 = (Class1448)_dataBinding;
	}
}
