using System;
using System.Xml;

namespace ns56;

internal class Class2178 : Class1351
{
	public delegate Class2178 Delegate2266();

	public delegate void Delegate2267(Class2178 elementData);

	public delegate void Delegate2268(Class2178 elementData);

	public const string string_0 = "none";

	public const string string_1 = "all";

	public const string string_2 = "true";

	public const string string_3 = "1";

	public const string string_4 = "0";

	public const string string_5 = "1";

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private string string_6;

	private string string_7;

	private string string_8;

	private string string_9;

	private string string_10;

	private string string_11;

	private Class1886 class1886_0;

	public string Axis
	{
		get
		{
			return string_6;
		}
		set
		{
			string_6 = value;
		}
	}

	public string PtType
	{
		get
		{
			return string_7;
		}
		set
		{
			string_7 = value;
		}
	}

	public string HideLastTrans
	{
		get
		{
			return string_8;
		}
		set
		{
			string_8 = value;
		}
	}

	public string St
	{
		get
		{
			return string_9;
		}
		set
		{
			string_9 = value;
		}
	}

	public string Cnt
	{
		get
		{
			return string_10;
		}
		set
		{
			string_10 = value;
		}
	}

	public string Step
	{
		get
		{
			return string_11;
		}
		set
		{
			string_11 = value;
		}
	}

	public Class1885 ExtLst => class1886_0;

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
					class1886_0 = new Class1886(reader);
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
				case "axis":
					string_6 = reader.Value;
					break;
				case "ptType":
					string_7 = reader.Value;
					break;
				case "hideLastTrans":
					string_8 = reader.Value;
					break;
				case "st":
					string_9 = reader.Value;
					break;
				case "cnt":
					string_10 = reader.Value;
					break;
				case "step":
					string_11 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2178(XmlReader reader)
		: base(reader)
	{
	}

	public Class2178()
	{
	}

	protected override void vmethod_1()
	{
		string_6 = "none";
		string_7 = "all";
		string_8 = "true";
		string_9 = "1";
		string_10 = "0";
		string_11 = "1";
	}

	protected override void vmethod_2()
	{
		delegate1534_0 = method_3;
		delegate1535_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_6 != "none")
		{
			writer.WriteAttributeString("axis", string_6);
		}
		if (string_7 != "all")
		{
			writer.WriteAttributeString("ptType", string_7);
		}
		if (string_8 != "true")
		{
			writer.WriteAttributeString("hideLastTrans", string_8);
		}
		if (string_9 != "1")
		{
			writer.WriteAttributeString("st", string_9);
		}
		if (string_10 != "0")
		{
			writer.WriteAttributeString("cnt", string_10);
		}
		if (string_11 != "1")
		{
			writer.WriteAttributeString("step", string_11);
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("dgm", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1885 method_3()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_4(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}
}
