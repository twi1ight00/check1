using System;
using System.Xml;

namespace ns56;

internal class Class1391 : Class1351
{
	public delegate Class1391 Delegate135();

	public delegate void Delegate136(Class1391 elementData);

	public delegate void Delegate137(Class1391 elementData);

	public const int int_0 = 0;

	public const bool bool_0 = false;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private int int_1;

	private bool bool_1;

	private Class1502 class1502_0;

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

	public string Mdx
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

	public string MemberName
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

	public string Hierarchy
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

	public string Parent
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

	public int SolveOrder
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public bool Set
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
				case "name":
					string_0 = reader.Value;
					break;
				case "mdx":
					string_1 = reader.Value;
					break;
				case "memberName":
					string_2 = reader.Value;
					break;
				case "hierarchy":
					string_3 = reader.Value;
					break;
				case "parent":
					string_4 = reader.Value;
					break;
				case "solveOrder":
					int_1 = XmlConvert.ToInt32(reader.Value);
					break;
				case "set":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1391(XmlReader reader)
		: base(reader)
	{
	}

	public Class1391()
	{
	}

	protected override void vmethod_1()
	{
		int_1 = 0;
		bool_1 = false;
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
		writer.WriteAttributeString("name", string_0);
		writer.WriteAttributeString("mdx", string_1);
		if (string_2 != null)
		{
			writer.WriteAttributeString("memberName", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("hierarchy", string_3);
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("parent", string_4);
		}
		if (int_1 != 0)
		{
			writer.WriteAttributeString("solveOrder", XmlConvert.ToString(int_1));
		}
		if (bool_1)
		{
			writer.WriteAttributeString("set", bool_1 ? "1" : "0");
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
