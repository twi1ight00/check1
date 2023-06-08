using System.Xml;

namespace ns56;

internal abstract class Class1992 : Class1351
{
	public delegate Class1992 Delegate1825();

	public delegate void Delegate1826(Class1992 elementData);

	public abstract Class1880 CNvPr { get; }

	public abstract Class1882 CNvGraphicFramePr { get; }

	public virtual Class2221 NvPr => null;

	public Class1992(XmlReader reader)
		: base(reader)
	{
	}

	public Class1992()
	{
	}
}
