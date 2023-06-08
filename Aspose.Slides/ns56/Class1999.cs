using System.Xml;

namespace ns56;

internal abstract class Class1999 : Class1351
{
	public abstract Class1880 CNvPr { get; }

	public abstract Class1883 CNvGrpSpPr { get; }

	public virtual Class2221 NvPr => null;

	public Class1999(XmlReader reader)
		: base(reader)
	{
	}

	public Class1999()
	{
	}
}
