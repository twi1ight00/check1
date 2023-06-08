using System.Xml;

namespace ns56;

internal abstract class Class2015 : Class1351
{
	public abstract Class1880 CNvPr { get; }

	public abstract Class1881 CNvSpPr { get; }

	public virtual Class2221 NvPr => null;

	public Class2015(XmlReader reader)
		: base(reader)
	{
	}

	public Class2015()
	{
	}
}
