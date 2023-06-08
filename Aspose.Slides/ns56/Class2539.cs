using Aspose.Slides.Charts;
using ns33;

namespace ns56;

internal class Class2539
{
	internal static readonly Class1151 class1151_0 = new Class1151("circle", "dash", "diamond", "dot", "none", "picture", "plus", "square", "star", "triangle", "x");

	public static MarkerStyleType smethod_0(string xmlValue)
	{
		return (MarkerStyleType)class1151_0[xmlValue];
	}

	public static string smethod_1(MarkerStyleType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
