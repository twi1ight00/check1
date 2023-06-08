using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2551
{
	private static readonly Class1151 class1151_0 = new Class1151("shdw1", "shdw10", "shdw11", "shdw12", "shdw13", "shdw14", "shdw15", "shdw16", "shdw17", "shdw18", "shdw19", "shdw2", "shdw20", "shdw3", "shdw4", "shdw5", "shdw6", "shdw7", "shdw8", "shdw9");

	public static PresetShadowType smethod_0(string xmlValue)
	{
		return (PresetShadowType)class1151_0[xmlValue];
	}

	public static string smethod_1(PresetShadowType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
