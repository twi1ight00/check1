using ns33;
using ns57;

namespace ns56;

internal class Class2600
{
	internal static readonly Class1151 class1151_0 = new Class1151("onBegin", "onEnd", "begin", "end", "onClick", "onDblClick", "onMouseOver", "onMouseOut", "onNext", "onPrev", "onStopAudio", "onMediaBookmark");

	public static Enum277 smethod_0(string xmlValue)
	{
		return (Enum277)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum277 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
