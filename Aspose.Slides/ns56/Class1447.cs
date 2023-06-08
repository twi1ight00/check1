using System.Xml;

namespace ns56;

internal class Class1447 : Class1351
{
	public delegate void Delegate304(Class1447 elementData);

	public delegate Class1447 Delegate303();

	private string[] string_0 = new string[4] { "http://schemas.openxmlformats.org/presentationml/2006/main", "http://schemas.openxmlformats.org/drawingml/2006/main", "http://schemas.openxmlformats.org/drawingml/2006/chart", "http://schemas.openxmlformats.org/officeDocument/2006/relationships" };

	private string string_1;

	public virtual string OuterXml
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

	protected override void vmethod_0(XmlReader reader)
	{
		string_1 = reader.ReadOuterXml();
	}

	internal Class1447(XmlReader reader)
		: base(reader)
	{
	}

	internal Class1447()
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
		string text = OuterXml;
		string[] array = string_0;
		foreach (string text2 in array)
		{
			string text3 = writer.LookupPrefix(text2);
			if (text3 != null)
			{
				text = text.Replace(" xmlns:" + text3 + "=\"" + text2 + "\"", "");
			}
		}
		writer.WriteRaw(text);
	}
}
