using System.Xml;

namespace ns56;

internal class Class2303 : Class1351
{
	public delegate Class2303 Delegate2656();

	public delegate void Delegate2657(Class2303 elementData);

	public delegate void Delegate2658(Class2303 elementData);

	private Class2283 class2283_0;

	public Class2283 CTn => class2283_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "cTn")
				{
					class2283_0 = new Class2283(reader);
					continue;
				}
				reader.Skip();
				flag = true;
			}
		}
	}

	private void method_2(XmlReader reader)
	{
	}

	public Class2303(XmlReader reader)
		: base(reader)
	{
	}

	public Class2303()
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
		class2283_0 = new Class2283();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class2283_0.vmethod_4("p", writer, "cTn");
		writer.WriteEndElement();
	}
}
