using System.Xml;

namespace ns56;

internal class Class1922 : Class1351
{
	public delegate Class1922 Delegate1633();

	public delegate void Delegate1635(Class1922 elementData);

	public delegate void Delegate1634(Class1922 elementData);

	private Class1929 class1929_0;

	private Class1929 class1929_1;

	private Class1929 class1929_2;

	private Class1846 class1846_0;

	public Class1929 LnRef => class1929_0;

	public Class1929 FillRef => class1929_1;

	public Class1929 EffectRef => class1929_2;

	public Class1846 FontRef => class1846_0;

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
				case "fontRef":
					class1846_0 = new Class1846(reader);
					break;
				case "effectRef":
					class1929_2 = new Class1929(reader);
					break;
				case "fillRef":
					class1929_1 = new Class1929(reader);
					break;
				case "lnRef":
					class1929_0 = new Class1929(reader);
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
	}

	public Class1922(XmlReader reader)
		: base(reader)
	{
	}

	public Class1922()
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
		class1929_0 = new Class1929();
		class1929_1 = new Class1929();
		class1929_2 = new Class1929();
		class1846_0 = new Class1846();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class1929_0.vmethod_4("a", writer, "lnRef");
		class1929_1.vmethod_4("a", writer, "fillRef");
		class1929_2.vmethod_4("a", writer, "effectRef");
		class1846_0.vmethod_4("a", writer, "fontRef");
		writer.WriteEndElement();
	}
}
