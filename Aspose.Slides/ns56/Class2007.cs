using System.Xml;

namespace ns56;

internal abstract class Class2007 : Class1351
{
	public delegate Class2007 Delegate1836();

	public delegate void Delegate1837(Class2007 elementData);

	public abstract Class1880 CNvPr { get; }

	public abstract Class1884 CNvPicPr { get; }

	public virtual Class2221 NvPr => null;

	public Class2007(XmlReader reader)
		: base(reader)
	{
	}

	public Class2007()
	{
	}
}
