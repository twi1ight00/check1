using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
[Guid("F167E33E-B57B-4CDF-82D8-A93A0076FB2B")]
public class PortionFactory : IPortionFactory
{
	public IPortion CreatePortion()
	{
		return new Portion();
	}

	public IPortion CreatePortion(string str)
	{
		return new Portion(str);
	}

	public IPortion CreatePortion(IPortion portion)
	{
		return new Portion(portion as Portion);
	}
}
