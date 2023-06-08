using System;
using System.Globalization;
using System.Xml;

namespace ns56;

internal class Class2226 : Class1351
{
	public delegate Class2226 Delegate2414();

	public delegate void Delegate2415(Class2226 elementData);

	public delegate void Delegate2416(Class2226 elementData);

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private uint uint_0;

	private DateTime dateTime_0;

	private uint uint_1;

	private Class1903 class1903_0;

	private string string_0;

	private Class1889 class1889_0;

	public static readonly DateTime dateTime_1 = DateTime.MinValue;

	public uint AuthorId
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

	public DateTime Dt
	{
		get
		{
			return dateTime_0;
		}
		set
		{
			dateTime_0 = value;
		}
	}

	public uint Idx
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

	public Class1903 Pos => class1903_0;

	public string Text
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

	public Class1885 ExtLst => class1889_0;

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
			if (reader.NodeType != XmlNodeType.Element)
			{
				continue;
			}
			switch (reader.LocalName)
			{
			case "extLst":
				class1889_0 = new Class1889(reader);
				break;
			case "text":
				string_0 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_0 += reader.ReadString();
					}
				}
				break;
			case "pos":
				class1903_0 = new Class1903(reader);
				break;
			default:
				reader.Skip();
				flag = true;
				break;
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
				case "idx":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "dt":
					dateTime_0 = DateTime.Parse(reader.Value, CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal);
					break;
				case "authorId":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2226(XmlReader reader)
		: base(reader)
	{
	}

	public Class2226()
	{
	}

	protected override void vmethod_1()
	{
		dateTime_0 = dateTime_1;
	}

	protected override void vmethod_2()
	{
		delegate1534_0 = method_3;
		delegate1535_0 = method_4;
	}

	protected override void vmethod_3()
	{
		class1903_0 = new Class1903();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("authorId", XmlConvert.ToString(uint_0));
		if (dateTime_0 != dateTime_1)
		{
			writer.WriteAttributeString("dt", XmlConvert.ToString(dateTime_0, "yyyy-MM-ddTHH:mm:ss.fff"));
		}
		writer.WriteAttributeString("idx", XmlConvert.ToString(uint_1));
		class1903_0.vmethod_4("p", writer, "pos");
		method_1("p", writer, "text", string_0);
		if (class1889_0 != null)
		{
			class1889_0.vmethod_4("p", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1885 method_3()
	{
		if (class1889_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1889_0 = new Class1889();
		return class1889_0;
	}

	private void method_4(Class1885 _extLst)
	{
		class1889_0 = (Class1889)_extLst;
	}
}
