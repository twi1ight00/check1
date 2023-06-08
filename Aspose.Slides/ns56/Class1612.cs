using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1612 : Class1351
{
	public delegate Class1612 Delegate715();

	public delegate void Delegate716(Class1612 elementData);

	public delegate void Delegate717(Class1612 elementData);

	public const int int_0 = 0;

	public const bool bool_0 = false;

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const double double_0 = double.NaN;

	public const int int_1 = 0;

	private string string_0;

	private int int_2;

	private Enum226 enum226_0;

	private bool bool_1;

	private string string_1;

	private NullableBool nullableBool_1;

	private double double_1;

	private int int_3;

	private string string_2;

	private string string_3;

	public static readonly Enum226 enum226_1 = Class2393.smethod_0("prompt");

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

	public int SqlType
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public Enum226 ParameterType
	{
		get
		{
			return enum226_0;
		}
		set
		{
			enum226_0 = value;
		}
	}

	public bool RefreshOnChange
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

	public string Prompt
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

	public NullableBool Boolean
	{
		get
		{
			return nullableBool_1;
		}
		set
		{
			nullableBool_1 = value;
		}
	}

	public double Double
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public int Integer
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public string String
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

	public string Cell
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
				_ = reader.LocalName;
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
				case "name":
					string_0 = reader.Value;
					break;
				case "sqlType":
					int_2 = XmlConvert.ToInt32(reader.Value);
					break;
				case "parameterType":
					enum226_0 = Class2393.smethod_0(reader.Value);
					break;
				case "refreshOnChange":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "prompt":
					string_1 = reader.Value;
					break;
				case "boolean":
					nullableBool_1 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "double":
					double_1 = ToDouble(reader.Value);
					break;
				case "integer":
					int_3 = XmlConvert.ToInt32(reader.Value);
					break;
				case "string":
					string_2 = reader.Value;
					break;
				case "cell":
					string_3 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1612(XmlReader reader)
		: base(reader)
	{
	}

	public Class1612()
	{
	}

	protected override void vmethod_1()
	{
		int_2 = 0;
		enum226_0 = enum226_1;
		bool_1 = false;
		nullableBool_1 = NullableBool.NotDefined;
		double_1 = double.NaN;
		int_3 = 0;
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
		if (string_0 != null)
		{
			writer.WriteAttributeString("name", string_0);
		}
		if (int_2 != 0)
		{
			writer.WriteAttributeString("sqlType", XmlConvert.ToString(int_2));
		}
		if (enum226_0 != enum226_1)
		{
			writer.WriteAttributeString("parameterType", Class2393.smethod_1(enum226_0));
		}
		if (bool_1)
		{
			writer.WriteAttributeString("refreshOnChange", bool_1 ? "1" : "0");
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("prompt", string_1);
		}
		if (nullableBool_1 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("boolean", (nullableBool_1 == NullableBool.True) ? "1" : "0");
		}
		if (!double.IsNaN(double_1))
		{
			writer.WriteAttributeString("double", XmlConvert.ToString(double_1));
		}
		if (int_3 != 0)
		{
			writer.WriteAttributeString("integer", XmlConvert.ToString(int_3));
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("string", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("cell", string_3);
		}
		writer.WriteEndElement();
	}
}
