using System.Xml;

namespace ns56;

internal abstract class Class1986 : Class1351
{
	public delegate Class1986 Delegate1819();

	public delegate void Delegate1820(Class1986 elementData);

	public abstract Class1880 CNvPr { get; }

	public abstract Class1879 CNvCxnSpPr { get; }

	public virtual Class2221 NvPr => null;

	public Class1986(XmlReader reader)
		: base(reader)
	{
	}

	public Class1986()
	{
	}
}
