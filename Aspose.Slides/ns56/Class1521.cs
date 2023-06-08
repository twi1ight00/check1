using System;
using System.Xml;

namespace ns56;

internal class Class1521 : Class1351
{
	public delegate void Delegate444(Class1521 elementData);

	public delegate Class1521 Delegate442();

	public delegate void Delegate443(Class1521 elementData);

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private Guid guid_0;

	public static readonly Guid guid_1 = Guid.Empty;

	public string AppName
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

	public string LastEdited
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

	public string LowestEdited
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

	public string RupBuild
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

	public Guid CodeName
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
				case "codeName":
					guid_0 = new Guid(reader.Value);
					break;
				case "rupBuild":
					string_3 = reader.Value;
					break;
				case "lowestEdited":
					string_2 = reader.Value;
					break;
				case "lastEdited":
					string_1 = reader.Value;
					break;
				case "appName":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1521(XmlReader reader)
		: base(reader)
	{
	}

	public Class1521()
	{
	}

	protected override void vmethod_1()
	{
		guid_0 = guid_1;
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
			writer.WriteAttributeString("appName", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("lastEdited", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("lowestEdited", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("rupBuild", string_3);
		}
		if (guid_0 != guid_1)
		{
			writer.WriteAttributeString("codeName", "{" + XmlConvert.ToString(guid_0).ToUpper() + "}");
		}
		writer.WriteEndElement();
	}
}
