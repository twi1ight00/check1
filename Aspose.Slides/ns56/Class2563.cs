using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2563
{
	private static readonly Class1151 class1151_0 = new Class1151("scrollBar", "background", "activeCaption", "inactiveCaption", "menu", "window", "windowFrame", "menuText", "windowText", "captionText", "activeBorder", "inactiveBorder", "appWorkspace", "highlight", "highlightText", "btnFace", "btnShadow", "grayText", "btnText", "inactiveCaptionText", "btnHighlight", "3dDkShadow", "3dLight", "infoText", "infoBk", "hotLight", "gradientActiveCaption", "gradientInactiveCaption", "menuHighlight", "menuBar");

	public static SystemColor smethod_0(string xmlValue)
	{
		return (SystemColor)class1151_0[xmlValue];
	}

	public static string smethod_1(SystemColor domValue)
	{
		return class1151_0[(int)domValue];
	}
}
