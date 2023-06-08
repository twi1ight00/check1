using System;
using System.Xml;

namespace ns56;

internal class Class1413 : Class1351
{
	public delegate Class1413 Delegate201();

	public delegate void Delegate202(Class1413 elementData);

	public delegate void Delegate203(Class1413 elementData);

	public const bool bool_0 = false;

	public const uint uint_0 = 100u;

	public const bool bool_1 = false;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private bool bool_2;

	private uint uint_1;

	private uint uint_2;

	private bool bool_3;

	private Class1502 class1502_0;

	public bool TabSelected
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

	public uint ZoomScale
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

	public uint WorkbookViewId
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	public bool ZoomToFit
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
				case "zoomToFit":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "workbookViewId":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "zoomScale":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "tabSelected":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1413(XmlReader reader)
		: base(reader)
	{
	}

	public Class1413()
	{
	}

	protected override void vmethod_1()
	{
		bool_2 = false;
		uint_1 = 100u;
		bool_3 = false;
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
		if (bool_2)
		{
			writer.WriteAttributeString("tabSelected", bool_2 ? "1" : "0");
		}
		if (uint_1 != 100)
		{
			writer.WriteAttributeString("zoomScale", XmlConvert.ToString(uint_1));
		}
		writer.WriteAttributeString("workbookViewId", XmlConvert.ToString(uint_2));
		if (bool_3)
		{
			writer.WriteAttributeString("zoomToFit", bool_3 ? "1" : "0");
		}
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
