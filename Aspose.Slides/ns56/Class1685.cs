using System;
using System.Globalization;
using System.Xml;

namespace ns56;

internal class Class1685 : Class1351
{
	public delegate Class1685 Delegate934();

	public delegate void Delegate935(Class1685 elementData);

	public delegate void Delegate936(Class1685 elementData);

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private Guid guid_0;

	private string string_0;

	private int int_0;

	private DateTime dateTime_0;

	private Class1502 class1502_0;

	public Guid Guid
	{
		get
		{
			return guid_0;
		}
		set
		{
			guid_0 = value;
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

	public int Id
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

	public DateTime DateTime
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

	public Class1502 ExtLst => class1502_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "extLst")
				{
					class1502_0 = new Class1502(reader);
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
				case "dateTime":
					dateTime_0 = DateTime.Parse(reader.Value, CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal);
					break;
				case "id":
					int_0 = XmlConvert.ToInt32(reader.Value);
					break;
				case "name":
					string_0 = reader.Value;
					break;
				case "guid":
					guid_0 = new Guid(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1685(XmlReader reader)
		: base(reader)
	{
	}

	public Class1685()
	{
	}

	protected override void vmethod_1()
	{
		guid_0 = Guid.Empty;
		dateTime_0 = DateTime.MinValue;
	}

	protected override void vmethod_2()
	{
		delegate385_0 = method_3;
		delegate387_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("guid", "{" + XmlConvert.ToString(guid_0).ToUpper() + "}");
		writer.WriteAttributeString("name", string_0);
		writer.WriteAttributeString("id", XmlConvert.ToString(int_0));
		writer.WriteAttributeString("dateTime", XmlConvert.ToString(dateTime_0, "yyyy-MM-ddTHH:mm:ss.fff"));
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1502 method_3()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_4(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
