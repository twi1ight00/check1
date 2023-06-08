using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2548
{
	private static readonly Class1151 class1151_0 = new Class1151("solid", "dot", "dash", "lgDash", "dashDot", "lgDashDot", "lgDashDotDot", "sysDash", "sysDot", "sysDashDot", "sysDashDotDot");

	public static LineDashStyle smethod_0(string xmlValue)
	{
		return (LineDashStyle)class1151_0[xmlValue];
	}

	public static string smethod_1(LineDashStyle domValue)
	{
		return class1151_0[(int)domValue];
	}
}
