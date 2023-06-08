using System.Xml;

namespace ns56;

internal abstract class Class1995 : Class1351
{
	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class2605.Delegate2773 delegate2773_0;

	public abstract Class1999 NvGrpSpPr { get; }

	public abstract Class1861 GrpSpPr { get; }

	public abstract Class2605[] ShapeList { get; }

	public virtual Class1885 ExtLst => null;

	protected Class1995(XmlReader reader)
		: base(reader)
	{
	}

	protected Class1995()
	{
	}
}
