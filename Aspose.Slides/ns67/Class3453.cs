using System;

namespace ns67;

internal sealed class Class3453 : ICloneable
{
	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	public float Red
	{
		get
		{
			return float_0;
		}
		set
		{
			if (!Class3430.smethod_1(value))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			float_0 = value;
		}
	}

	public float Green
	{
		get
		{
			return float_1;
		}
		set
		{
			if (!Class3430.smethod_1(value))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			float_1 = value;
		}
	}

	public float Blue
	{
		get
		{
			return float_2;
		}
		set
		{
			if (!Class3430.smethod_1(value))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			float_2 = value;
		}
	}

	public float Alpha
	{
		get
		{
			return float_3;
		}
		set
		{
			if (!Class3430.smethod_1(value))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			float_3 = value;
		}
	}

	public Class3453(float red, float green, float blue, float alpha)
	{
		float_0 = red;
		float_1 = green;
		float_2 = blue;
		float_3 = alpha;
	}

	public Class3453 method_0(float alpha)
	{
		return new Class3453(float_0, float_1, float_2, alpha);
	}

	public static Class3453 smethod_0(int hue, float liminance, float saturation, float alpha)
	{
		throw new NotImplementedException();
	}

	public static Class3453 smethod_1(int red, int green, int blue)
	{
		return new Class3453((float)red / 256f, (float)green / 256f, (float)blue / 256f, 0f);
	}

	public static Class3453 smethod_2(string presetColorValue, float alpha)
	{
		return presetColorValue switch
		{
			"aliceBlue" => smethod_1(240, 248, 255).method_0(alpha), 
			"antiqueWhite" => smethod_1(250, 235, 215).method_0(alpha), 
			"aqua" => smethod_1(0, 255, 255).method_0(alpha), 
			"aquamarine" => smethod_1(127, 255, 212).method_0(alpha), 
			"azure" => smethod_1(240, 255, 255).method_0(alpha), 
			"beige" => smethod_1(245, 245, 220).method_0(alpha), 
			"bisque" => smethod_1(255, 228, 196).method_0(alpha), 
			"black" => smethod_1(0, 0, 0).method_0(alpha), 
			"blanchedAlmond" => smethod_1(255, 235, 205).method_0(alpha), 
			"blue" => smethod_1(0, 0, 255).method_0(alpha), 
			"blueViolet" => smethod_1(138, 43, 226).method_0(alpha), 
			"brown" => smethod_1(165, 42, 42).method_0(alpha), 
			"burlyWood" => smethod_1(222, 184, 135).method_0(alpha), 
			"cadetBlue" => smethod_1(95, 158, 160).method_0(alpha), 
			"chartreuse" => smethod_1(127, 255, 0).method_0(alpha), 
			"chocolate" => smethod_1(210, 105, 30).method_0(alpha), 
			"coral" => smethod_1(255, 127, 80).method_0(alpha), 
			"cornflowerBlue" => smethod_1(100, 149, 237).method_0(alpha), 
			"cornsilk" => smethod_1(255, 248, 220).method_0(alpha), 
			"crimson" => smethod_1(220, 20, 60).method_0(alpha), 
			"cyan" => smethod_1(0, 255, 255).method_0(alpha), 
			"darkBlue" => smethod_1(0, 0, 139).method_0(alpha), 
			"darkCyan" => smethod_1(0, 139, 139).method_0(alpha), 
			"darkGoldenrod" => smethod_1(184, 134, 11).method_0(alpha), 
			"darkGray" => smethod_1(169, 169, 169).method_0(alpha), 
			"darkGreen" => smethod_1(0, 100, 0).method_0(alpha), 
			"darkGrey" => smethod_1(169, 169, 169).method_0(alpha), 
			"darkKhaki" => smethod_1(189, 183, 107).method_0(alpha), 
			"darkMagenta" => smethod_1(139, 0, 139).method_0(alpha), 
			"darkOliveGreen" => smethod_1(85, 107, 47).method_0(alpha), 
			"darkOrange" => smethod_1(255, 140, 0).method_0(alpha), 
			"darkOrchid" => smethod_1(153, 50, 204).method_0(alpha), 
			"darkRed" => smethod_1(139, 0, 0).method_0(alpha), 
			"darkSalmon" => smethod_1(233, 150, 122).method_0(alpha), 
			"darkSeaGreen" => smethod_1(143, 188, 143).method_0(alpha), 
			"darkSlateBlue" => smethod_1(72, 61, 139).method_0(alpha), 
			"darkSlateGray" => smethod_1(47, 79, 79).method_0(alpha), 
			"darkSlateGrey" => smethod_1(47, 79, 79).method_0(alpha), 
			"darkTurquoise" => smethod_1(0, 206, 209).method_0(alpha), 
			"darkViolet" => smethod_1(148, 0, 211).method_0(alpha), 
			"deepPink" => smethod_1(255, 20, 147).method_0(alpha), 
			"deepSkyBlue" => smethod_1(0, 191, 255).method_0(alpha), 
			"dimGray" => smethod_1(105, 105, 105).method_0(alpha), 
			"dimGrey" => smethod_1(105, 105, 105).method_0(alpha), 
			"dkBlue" => smethod_1(0, 0, 139).method_0(alpha), 
			"dkCyan" => smethod_1(0, 139, 139).method_0(alpha), 
			"dkGoldenrod" => smethod_1(184, 134, 11).method_0(alpha), 
			"dkGray" => smethod_1(169, 169, 169).method_0(alpha), 
			"dkGreen" => smethod_1(0, 100, 0).method_0(alpha), 
			"dkGrey" => smethod_1(169, 169, 169).method_0(alpha), 
			"dkKhaki" => smethod_1(189, 183, 107).method_0(alpha), 
			"dkMagenta" => smethod_1(139, 0, 139).method_0(alpha), 
			"dkOliveGreen" => smethod_1(85, 107, 47).method_0(alpha), 
			"dkOrange" => smethod_1(255, 140, 0).method_0(alpha), 
			"dkOrchid" => smethod_1(153, 50, 204).method_0(alpha), 
			"dkRed" => smethod_1(139, 0, 0).method_0(alpha), 
			"dkSalmon" => smethod_1(233, 150, 122).method_0(alpha), 
			"dkSeaGreen" => smethod_1(143, 188, 139).method_0(alpha), 
			"dkSlateBlue" => smethod_1(72, 61, 139).method_0(alpha), 
			"dkSlateGray" => smethod_1(47, 79, 79).method_0(alpha), 
			"dkSlateGrey" => smethod_1(47, 79, 79).method_0(alpha), 
			"dkTurquoise" => smethod_1(0, 206, 209).method_0(alpha), 
			"dkViolet" => smethod_1(148, 0, 211).method_0(alpha), 
			"dodgerBlue" => smethod_1(30, 144, 255).method_0(alpha), 
			"firebrick" => smethod_1(178, 34, 34).method_0(alpha), 
			"floralWhite" => smethod_1(255, 250, 240).method_0(alpha), 
			"forestGreen" => smethod_1(34, 139, 34).method_0(alpha), 
			"fuchsia" => smethod_1(255, 0, 255).method_0(alpha), 
			"gainsboro" => smethod_1(220, 220, 220).method_0(alpha), 
			"ghostWhite" => smethod_1(248, 248, 255).method_0(alpha), 
			"gold" => smethod_1(255, 215, 0).method_0(alpha), 
			"goldenrod" => smethod_1(218, 165, 32).method_0(alpha), 
			"gray" => smethod_1(128, 128, 128).method_0(alpha), 
			"green" => smethod_1(0, 128, 0).method_0(alpha), 
			"greenYellow" => smethod_1(173, 255, 47).method_0(alpha), 
			"grey" => smethod_1(128, 128, 128).method_0(alpha), 
			"honeydew" => smethod_1(240, 255, 240).method_0(alpha), 
			"hotPink" => smethod_1(255, 105, 180).method_0(alpha), 
			"indianRed" => smethod_1(205, 92, 92).method_0(alpha), 
			"indigo" => smethod_1(75, 0, 130).method_0(alpha), 
			"ivory" => smethod_1(255, 255, 240).method_0(alpha), 
			"khaki" => smethod_1(240, 230, 140).method_0(alpha), 
			"lavender" => smethod_1(230, 230, 250).method_0(alpha), 
			"lavenderBlush" => smethod_1(255, 240, 245).method_0(alpha), 
			"lawnGreen" => smethod_1(124, 252, 0).method_0(alpha), 
			"lemonChiffon" => smethod_1(255, 250, 205).method_0(alpha), 
			"lightBlue" => smethod_1(173, 216, 230).method_0(alpha), 
			"lightCoral" => smethod_1(240, 128, 128).method_0(alpha), 
			"lightCyan" => smethod_1(224, 255, 255).method_0(alpha), 
			"lightGoldenrodYellow" => smethod_1(250, 250, 210).method_0(alpha), 
			"lightGray" => smethod_1(211, 211, 211).method_0(alpha), 
			"lightGreen" => smethod_1(144, 238, 144).method_0(alpha), 
			"lightGrey" => smethod_1(211, 211, 211).method_0(alpha), 
			"lightPink" => smethod_1(255, 182, 193).method_0(alpha), 
			"lightSalmon" => smethod_1(255, 160, 122).method_0(alpha), 
			"lightSeaGreen" => smethod_1(32, 178, 170).method_0(alpha), 
			"lightSkyBlue" => smethod_1(135, 206, 250).method_0(alpha), 
			"lightSlateGray" => smethod_1(119, 136, 153).method_0(alpha), 
			"lightSlateGrey" => smethod_1(119, 136, 153).method_0(alpha), 
			"lightSteelBlue" => smethod_1(176, 196, 222).method_0(alpha), 
			"lightYellow" => smethod_1(255, 255, 224).method_0(alpha), 
			"lime" => smethod_1(0, 255, 0).method_0(alpha), 
			"limeGreen" => smethod_1(50, 205, 50).method_0(alpha), 
			"linen" => smethod_1(250, 240, 230).method_0(alpha), 
			"ltBlue" => smethod_1(173, 216, 230).method_0(alpha), 
			"ltCoral" => smethod_1(240, 128, 128).method_0(alpha), 
			"ltCyan" => smethod_1(224, 255, 255).method_0(alpha), 
			"ltGoldenrodYellow" => smethod_1(250, 250, 120).method_0(alpha), 
			"ltGray" => smethod_1(211, 211, 211).method_0(alpha), 
			"ltGreen" => smethod_1(144, 238, 144).method_0(alpha), 
			"ltGrey" => smethod_1(211, 211, 211).method_0(alpha), 
			"ltPink" => smethod_1(255, 182, 193).method_0(alpha), 
			"ltSalmon" => smethod_1(255, 160, 122).method_0(alpha), 
			"ltSeaGreen" => smethod_1(32, 178, 170).method_0(alpha), 
			"ltSkyBlue" => smethod_1(135, 206, 250).method_0(alpha), 
			"ltSlateGray" => smethod_1(119, 136, 153).method_0(alpha), 
			"ltSlateGrey" => smethod_1(119, 136, 153).method_0(alpha), 
			"ltSteelBlue" => smethod_1(176, 196, 222).method_0(alpha), 
			"ltYellow" => smethod_1(255, 255, 224).method_0(alpha), 
			"magenta" => smethod_1(255, 0, 255).method_0(alpha), 
			"maroon" => smethod_1(128, 0, 0).method_0(alpha), 
			"medAquamarine" => smethod_1(102, 205, 170).method_0(alpha), 
			"medBlue" => smethod_1(0, 0, 205).method_0(alpha), 
			"mediumAquamarine" => smethod_1(102, 205, 170).method_0(alpha), 
			"mediumBlue" => smethod_1(0, 0, 205).method_0(alpha), 
			"mediumOrchid" => smethod_1(186, 85, 211).method_0(alpha), 
			"mediumPurple" => smethod_1(147, 112, 219).method_0(alpha), 
			"mediumSeaGreen" => smethod_1(60, 179, 113).method_0(alpha), 
			"mediumSlateBlue" => smethod_1(123, 104, 238).method_0(alpha), 
			"mediumSpringGreen" => smethod_1(0, 250, 154).method_0(alpha), 
			"mediumTurquoise" => smethod_1(72, 209, 204).method_0(alpha), 
			"mediumVioletRed" => smethod_1(199, 21, 133).method_0(alpha), 
			"medOrchid" => smethod_1(186, 85, 211).method_0(alpha), 
			"medPurple" => smethod_1(147, 112, 219).method_0(alpha), 
			"medSeaGreen" => smethod_1(60, 179, 113).method_0(alpha), 
			"medSlateBlue" => smethod_1(123, 104, 238).method_0(alpha), 
			"medSpringGreen" => smethod_1(0, 250, 154).method_0(alpha), 
			"medTurquoise" => smethod_1(72, 209, 204).method_0(alpha), 
			"medVioletRed" => smethod_1(199, 21, 133).method_0(alpha), 
			"midnightBlue" => smethod_1(25, 25, 112).method_0(alpha), 
			"mintCream" => smethod_1(245, 255, 250).method_0(alpha), 
			"mistyRose" => smethod_1(255, 228, 225).method_0(alpha), 
			"moccasin" => smethod_1(255, 228, 181).method_0(alpha), 
			"navajoWhite" => smethod_1(255, 222, 173).method_0(alpha), 
			"navy" => smethod_1(0, 0, 128).method_0(alpha), 
			"oldLace" => smethod_1(253, 245, 230).method_0(alpha), 
			"olive" => smethod_1(128, 128, 0).method_0(alpha), 
			"oliveDrab" => smethod_1(107, 142, 35).method_0(alpha), 
			"orange" => smethod_1(255, 165, 0).method_0(alpha), 
			"orangeRed" => smethod_1(255, 69, 0).method_0(alpha), 
			"orchid" => smethod_1(218, 112, 214).method_0(alpha), 
			"paleGoldenrod" => smethod_1(238, 232, 170).method_0(alpha), 
			"paleGreen" => smethod_1(152, 251, 152).method_0(alpha), 
			"paleTurquoise" => smethod_1(175, 238, 238).method_0(alpha), 
			"paleVioletRed" => smethod_1(219, 112, 147).method_0(alpha), 
			"papayaWhip" => smethod_1(255, 239, 213).method_0(alpha), 
			"peachPuff" => smethod_1(255, 218, 185).method_0(alpha), 
			"peru" => smethod_1(205, 133, 63).method_0(alpha), 
			"pink" => smethod_1(255, 192, 203).method_0(alpha), 
			"plum" => smethod_1(221, 160, 221).method_0(alpha), 
			"powderBlue" => smethod_1(176, 224, 230).method_0(alpha), 
			"purple" => smethod_1(128, 0, 128).method_0(alpha), 
			"red" => smethod_1(255, 0, 0).method_0(alpha), 
			"rosyBrown" => smethod_1(188, 143, 143).method_0(alpha), 
			"royalBlue" => smethod_1(65, 105, 225).method_0(alpha), 
			"saddleBrown" => smethod_1(139, 69, 19).method_0(alpha), 
			"salmon" => smethod_1(250, 128, 114).method_0(alpha), 
			"sandyBrown" => smethod_1(244, 164, 96).method_0(alpha), 
			"seaGreen" => smethod_1(46, 139, 87).method_0(alpha), 
			"seaShell" => smethod_1(255, 245, 238).method_0(alpha), 
			"sienna" => smethod_1(160, 82, 45).method_0(alpha), 
			"silver" => smethod_1(192, 192, 192).method_0(alpha), 
			"skyBlue" => smethod_1(135, 206, 235).method_0(alpha), 
			"slateBlue" => smethod_1(106, 90, 205).method_0(alpha), 
			"slateGray" => smethod_1(112, 128, 144).method_0(alpha), 
			"slateGrey" => smethod_1(112, 128, 144).method_0(alpha), 
			"snow" => smethod_1(255, 250, 250).method_0(alpha), 
			"springGreen" => smethod_1(0, 255, 127).method_0(alpha), 
			"steelBlue" => smethod_1(70, 130, 180).method_0(alpha), 
			"tan" => smethod_1(210, 180, 140).method_0(alpha), 
			"teal" => smethod_1(0, 128, 128).method_0(alpha), 
			"thistle" => smethod_1(216, 191, 216).method_0(alpha), 
			"tomato" => smethod_1(255, 99, 71).method_0(alpha), 
			"turquoise" => smethod_1(64, 224, 208).method_0(alpha), 
			"violet" => smethod_1(238, 130, 238).method_0(alpha), 
			"wheat" => smethod_1(245, 222, 179).method_0(alpha), 
			"white" => smethod_1(255, 255, 255).method_0(alpha), 
			"whiteSmoke" => smethod_1(245, 245, 245).method_0(alpha), 
			"yellow" => smethod_1(255, 255, 0).method_0(alpha), 
			"yellowGreen" => smethod_1(154, 205, 50).method_0(alpha), 
			_ => throw new ArgumentOutOfRangeException("presetColorValue"), 
		};
	}

	public static Class3453 smethod_3(Class3454 scheme, string schemeColorValue)
	{
		return schemeColorValue switch
		{
			"accent1" => scheme.AccentColor1, 
			"accent2" => scheme.AccentColor2, 
			"accent3" => scheme.AccentColor3, 
			"accent4" => scheme.AccentColor4, 
			"accent5" => scheme.AccentColor5, 
			"accent6" => scheme.AccentColor6, 
			"bg1" => scheme.BackgroundColor1, 
			"bg2" => scheme.BackgroundColor2, 
			"dk1" => scheme.DarkColor1, 
			"dk2" => scheme.DarkColor2, 
			"folHlink" => scheme.FollowedHyperlinkColor, 
			"hlink" => scheme.HyperlinkColor, 
			"lt1" => scheme.LightColor1, 
			"lt2" => scheme.LightColor2, 
			"phClr" => scheme.StyleColor, 
			"tx1" => scheme.TextColor1, 
			"tx2" => scheme.TextColor2, 
			_ => throw new ArgumentOutOfRangeException("schemeColorValue"), 
		};
	}

	public static Class3453 smethod_4(float red, float green, float blue)
	{
		return new Class3453(red, green, blue, 0f);
	}

	public static Class3453 smethod_5(string value, Class3453 lastColor)
	{
		if (value != null)
		{
			throw new NotImplementedException("Color.MakeSystemColor");
		}
		switch (value)
		{
		default:
			throw new ArgumentOutOfRangeException("value");
		case "3dDkShadow":
		case "3dLight":
		case "activeBorder":
		case "activeCaption":
		case "appWorkspace":
		case "background":
		case "btnFace":
		case "btnHighlight":
		case "btnShadow":
		case "btnText":
		case "captionText":
		case "gradientActiveCaption":
		case "gradientInactiveCaption":
		case "grayText":
		case "highlight":
		case "highlightText":
		case "hotLight":
		case "inactiveBorder":
		case "inactiveCaption":
		case "inactiveCaptionText":
		case "infoBk":
		case "infoText":
		case "menu":
		case "menuBar":
		case "menuHighlight":
		case "menuText":
		case "scrollBar":
		case "window":
		case "windowFrame":
		case "windowText":
			return lastColor.method_1();
		}
	}

	public object Clone()
	{
		return method_1();
	}

	public Class3453 method_1()
	{
		return new Class3453(float_0, float_1, float_2, float_3);
	}
}
