using Aspose.Slides.Charts;
using ns33;

namespace ns56;

internal class Class2543
{
	public static readonly Class1151 class1151_0 = new Class1151("stack", "stackScale", "stretch");

	public static PictureType smethod_0(string xmlValue)
	{
		return (PictureType)class1151_0[xmlValue];
	}

	public static string smethod_1(PictureType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
