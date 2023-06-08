using System.Collections;
using Aspose.Words;
using x2845e7a1a7dc898b;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using x9e34b6f7e9185197;
using xf989f31a236ff98c;

namespace xda075892eccab2ad;

internal class xf2a0216b53787578
{
	private static readonly Hashtable x3651c627ebb0cbd8;

	private static readonly Hashtable xab0381e77e622b1e;

	private static readonly Hashtable x9016dc159e1b0fc8;

	private static readonly Hashtable x54a57ef9de8326e8;

	internal static int xae88295ea6bfc819(string xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		Hashtable x12fedb3de1c57ea = (x5fbb1a9c98604ef5 ? x3651c627ebb0cbd8 : x9016dc159e1b0fc8);
		return (int)x682712679dbc585a.xce92de628aa023cf(x12fedb3de1c57ea, xbcea506a33cf9111, x448900fcb384c333.xbb83e98a4db859fa);
	}

	internal static string xd16e1d14e9bd81a9(int xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		Hashtable x12fedb3de1c57ea = (x5fbb1a9c98604ef5 ? xab0381e77e622b1e : x54a57ef9de8326e8);
		return (string)x682712679dbc585a.xce92de628aa023cf(x12fedb3de1c57ea, (x448900fcb384c333)xbcea506a33cf9111, "");
	}

	internal static string xd16e1d14e9bd81a9(int xbcea506a33cf9111, bool xc34d6823beed57a1, bool x5fbb1a9c98604ef5)
	{
		if (xbcea506a33cf9111 == 1024 && !xc34d6823beed57a1)
		{
			if (!x5fbb1a9c98604ef5)
			{
				return "EN-US";
			}
			return "en-US";
		}
		Hashtable x12fedb3de1c57ea = (x5fbb1a9c98604ef5 ? xab0381e77e622b1e : x54a57ef9de8326e8);
		return (string)x682712679dbc585a.xce92de628aa023cf(x12fedb3de1c57ea, (x448900fcb384c333)xbcea506a33cf9111, "");
	}

	internal static x4a2f68a519ee2183 x7e8ef68ffbe367c2(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "circle":
			return x4a2f68a519ee2183.xcc4f8cd12606a197;
		case "comma":
			return x4a2f68a519ee2183.x729684579d564d8e;
		case "dot":
			return x4a2f68a519ee2183.x3cb6807e93737c2d;
		case "underDot":
		case "under-dot":
			return x4a2f68a519ee2183.xe2ef50de35a099e5;
		default:
			return x4a2f68a519ee2183.x4d0b9d4447ba7566;
		}
	}

	internal static string xfba68e7827d45487(x4a2f68a519ee2183 xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case x4a2f68a519ee2183.xcc4f8cd12606a197:
			return "circle";
		case x4a2f68a519ee2183.x729684579d564d8e:
			return "comma";
		case x4a2f68a519ee2183.x3cb6807e93737c2d:
			return "dot";
		case x4a2f68a519ee2183.xe2ef50de35a099e5:
			if (!x5fbb1a9c98604ef5)
			{
				return "under-dot";
			}
			return "underDot";
		default:
			return "";
		}
	}

	internal static x69ec038defa753a8 xc41b20051fb66652(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"round" => x69ec038defa753a8.xf70561660feeaf26, 
			"angle" => x69ec038defa753a8.x6b1fe03343d9a6a4, 
			"square" => x69ec038defa753a8.xed2a37919fe44f03, 
			"curly" => x69ec038defa753a8.x9f87fe57bd193d0a, 
			_ => x69ec038defa753a8.x4d0b9d4447ba7566, 
		};
	}

	internal static string x2c048b7927e29eb0(x69ec038defa753a8 xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			x69ec038defa753a8.xf70561660feeaf26 => "round", 
			x69ec038defa753a8.x6b1fe03343d9a6a4 => "angle", 
			x69ec038defa753a8.xed2a37919fe44f03 => "square", 
			x69ec038defa753a8.x9f87fe57bd193d0a => "curly", 
			_ => "", 
		};
	}

	internal static xd0fe745f27933c97 x83cf18965d4863b4(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"majorAscii" => xd0fe745f27933c97.xda51a4646f9f1d2d, 
			"majorBidi" => xd0fe745f27933c97.xaeb730a64aee20c9, 
			"majorEastAsia" => xd0fe745f27933c97.x30b70c795933534f, 
			"majorHAnsi" => xd0fe745f27933c97.x66341c066a75e7f9, 
			"minorAscii" => xd0fe745f27933c97.x66d2ceccc2db37c1, 
			"minorBidi" => xd0fe745f27933c97.x6a2e55c2ebf144a4, 
			"minorEastAsia" => xd0fe745f27933c97.xd0e706f7fa6c84d1, 
			"minorHAnsi" => xd0fe745f27933c97.xb5416fb0ca9c28ab, 
			_ => xd0fe745f27933c97.x4d0b9d4447ba7566, 
		};
	}

	internal static string x7b00dd48d64c2892(xd0fe745f27933c97 xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			xd0fe745f27933c97.xda51a4646f9f1d2d => "majorAscii", 
			xd0fe745f27933c97.xaeb730a64aee20c9 => "majorBidi", 
			xd0fe745f27933c97.x30b70c795933534f => "majorEastAsia", 
			xd0fe745f27933c97.x66341c066a75e7f9 => "majorHAnsi", 
			xd0fe745f27933c97.x66d2ceccc2db37c1 => "minorAscii", 
			xd0fe745f27933c97.x6a2e55c2ebf144a4 => "minorBidi", 
			xd0fe745f27933c97.xd0e706f7fa6c84d1 => "minorEastAsia", 
			xd0fe745f27933c97.xb5416fb0ca9c28ab => "minorHAnsi", 
			_ => "", 
		};
	}

	internal static x000f21cbda739311 xf2bfcf7101dcb000(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "eastAsia":
		case "fareast":
			return x000f21cbda739311.x7c8c2d13fa5b79fa;
		case "cs":
			return x000f21cbda739311.xd4e922ceeed89b74;
		default:
			return x000f21cbda739311.x22a0fbb9469b35e1;
		}
	}

	internal static string x4c5ac47dff1200ed(x000f21cbda739311 xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case x000f21cbda739311.x7c8c2d13fa5b79fa:
			if (!x5fbb1a9c98604ef5)
			{
				return "fareast";
			}
			return "eastAsia";
		case x000f21cbda739311.xd4e922ceeed89b74:
			return "cs";
		default:
			return "default";
		}
	}

	internal static xb298f2d4a3b9607a x79ef6054f168893e(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"none" => xb298f2d4a3b9607a.x4d0b9d4447ba7566, 
			"left" => xb298f2d4a3b9607a.x72d92bd1aff02e37, 
			"right" => xb298f2d4a3b9607a.x419ba17a5322627b, 
			"all" => xb298f2d4a3b9607a.x95c57ee794bc0aec, 
			_ => xb298f2d4a3b9607a.x4d0b9d4447ba7566, 
		};
	}

	internal static string x3eeaa9c8690f9db0(xb298f2d4a3b9607a xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			xb298f2d4a3b9607a.x4d0b9d4447ba7566 => "none", 
			xb298f2d4a3b9607a.x72d92bd1aff02e37 => "left", 
			xb298f2d4a3b9607a.x419ba17a5322627b => "right", 
			xb298f2d4a3b9607a.x95c57ee794bc0aec => "all", 
			_ => "", 
		};
	}

	internal static char x5e8e32872393aa9a(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "page":
			return '\f';
		case "column":
			return '\u000e';
		case "textWrapping":
		case "text-wrapping":
			return '\v';
		default:
			return ' ';
		}
	}

	internal static string x832f3daadc37ea45(char xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case '\f':
			return "page";
		case '\u000e':
			return "column";
		case '\v':
			if (!x5fbb1a9c98604ef5)
			{
				return "text-wrapping";
			}
			return "textWrapping";
		default:
			return "";
		}
	}

	internal static TextEffect xea66715906956b46(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "blinkBackground":
		case "blink-background":
			return TextEffect.BlinkingBackground;
		case "lights":
			return TextEffect.LasVegasLights;
		case "antsBlack":
		case "ants-black":
			return TextEffect.MarchingBlackAnts;
		case "antsRed":
		case "ants-red":
			return TextEffect.MarchingRedAnts;
		case "shimmer":
			return TextEffect.Shimmer;
		case "sparkle":
			return TextEffect.SparkleText;
		default:
			return TextEffect.None;
		}
	}

	internal static string x1fc6f26ef01fce34(TextEffect xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case TextEffect.BlinkingBackground:
			if (!x5fbb1a9c98604ef5)
			{
				return "blink-background";
			}
			return "blinkBackground";
		case TextEffect.LasVegasLights:
			return "lights";
		case TextEffect.MarchingBlackAnts:
			if (!x5fbb1a9c98604ef5)
			{
				return "ants-black";
			}
			return "antsBlack";
		case TextEffect.MarchingRedAnts:
			if (!x5fbb1a9c98604ef5)
			{
				return "ants-red";
			}
			return "antsRed";
		case TextEffect.Shimmer:
			return "shimmer";
		case TextEffect.SparkleText:
			return "sparkle";
		default:
			return "none";
		}
	}

	internal static Underline x0ae1d706c7d8a3e7(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "single":
			return Underline.Single;
		case "words":
			return Underline.Words;
		case "double":
			return Underline.Double;
		case "thick":
			return Underline.Thick;
		case "dotted":
			return Underline.Dotted;
		case "dotted-heavy":
		case "dottedHeavy":
			return Underline.DottedHeavy;
		case "dash":
			return Underline.Dash;
		case "dashed-heavy":
		case "dashedHeavy":
			return Underline.DashHeavy;
		case "dash-long":
		case "dashLong":
			return Underline.DashLong;
		case "dash-long-heavy":
		case "dashLongHeavy":
			return Underline.DashLongHeavy;
		case "dot-dash":
		case "dotDash":
			return Underline.DotDash;
		case "dash-dot-heavy":
		case "dashDotHeavy":
			return Underline.DotDashHeavy;
		case "dot-dot-dash":
		case "dotDotDash":
			return Underline.DotDotDash;
		case "dash-dot-dot-heavy":
		case "dashDotDotHeavy":
			return Underline.DotDotDashHeavy;
		case "wave":
			return Underline.Wavy;
		case "wavy-heavy":
		case "wavyHeavy":
			return Underline.WavyHeavy;
		case "wavy-double":
		case "wavyDouble":
			return Underline.WavyDouble;
		default:
			return Underline.None;
		}
	}

	internal static string xd2b7dad42aacccb2(Underline xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case Underline.Single:
			return "single";
		case Underline.Words:
			return "words";
		case Underline.Double:
			return "double";
		case Underline.Thick:
			return "thick";
		case Underline.Dotted:
			return "dotted";
		case Underline.DottedHeavy:
			if (!x5fbb1a9c98604ef5)
			{
				return "dotted-heavy";
			}
			return "dottedHeavy";
		case Underline.Dash:
			return "dash";
		case Underline.DashHeavy:
			if (!x5fbb1a9c98604ef5)
			{
				return "dashed-heavy";
			}
			return "dashedHeavy";
		case Underline.DashLong:
			if (!x5fbb1a9c98604ef5)
			{
				return "dash-long";
			}
			return "dashLong";
		case Underline.DashLongHeavy:
			if (!x5fbb1a9c98604ef5)
			{
				return "dash-long-heavy";
			}
			return "dashLongHeavy";
		case Underline.DotDash:
			if (!x5fbb1a9c98604ef5)
			{
				return "dot-dash";
			}
			return "dotDash";
		case Underline.DotDashHeavy:
			if (!x5fbb1a9c98604ef5)
			{
				return "dash-dot-heavy";
			}
			return "dashDotHeavy";
		case Underline.DotDotDash:
			if (!x5fbb1a9c98604ef5)
			{
				return "dot-dot-dash";
			}
			return "dotDotDash";
		case Underline.DotDotDashHeavy:
			if (!x5fbb1a9c98604ef5)
			{
				return "dash-dot-dot-heavy";
			}
			return "dashDotDotHeavy";
		case Underline.Wavy:
			return "wave";
		case Underline.WavyHeavy:
			if (!x5fbb1a9c98604ef5)
			{
				return "wavy-heavy";
			}
			return "wavyHeavy";
		case Underline.WavyDouble:
			if (!x5fbb1a9c98604ef5)
			{
				return "wavy-double";
			}
			return "wavyDouble";
		default:
			return "none";
		}
	}

	internal static x26d9ecb4bdf0456d xf605f8f5dedc8c5e(string xbcea506a33cf9111)
	{
		x88d38775104122b8 x268aef2fda7d49d;
		switch (xbcea506a33cf9111)
		{
		case "none":
			x268aef2fda7d49d = x88d38775104122b8.x2bca50d746ec73b2;
			break;
		case "white":
			x268aef2fda7d49d = x88d38775104122b8.x8f02f53f1587477d;
			break;
		case "yellow":
			x268aef2fda7d49d = x88d38775104122b8.x50a7f8950dee0ba8;
			break;
		case "green":
			x268aef2fda7d49d = x88d38775104122b8.x23d6043fb9c177ec;
			break;
		case "cyan":
			x268aef2fda7d49d = x88d38775104122b8.x87c77c027dc67f29;
			break;
		case "magenta":
			x268aef2fda7d49d = x88d38775104122b8.x72f158c0f92fae4e;
			break;
		case "blue":
			x268aef2fda7d49d = x88d38775104122b8.xe3a106a4c00973e3;
			break;
		case "red":
			x268aef2fda7d49d = x88d38775104122b8.x46d2ee2a363fa637;
			break;
		case "darkBlue":
		case "dark-blue":
			x268aef2fda7d49d = x88d38775104122b8.x31bdd1389ca026e0;
			break;
		case "darkCyan":
		case "dark-cyan":
			x268aef2fda7d49d = x88d38775104122b8.x3c0c4c381ec91e4c;
			break;
		case "darkGreen":
		case "dark-green":
			x268aef2fda7d49d = x88d38775104122b8.x3327303aa89cf700;
			break;
		case "darkMagenta":
		case "dark-magenta":
			x268aef2fda7d49d = x88d38775104122b8.xab24404ba058d2b7;
			break;
		case "darkRed":
		case "dark-red":
			x268aef2fda7d49d = x88d38775104122b8.x2ae2f959edf38ec3;
			break;
		case "darkYellow":
		case "dark-yellow":
			x268aef2fda7d49d = x88d38775104122b8.xa0ad12ae9ca7945f;
			break;
		case "darkGray":
		case "dark-gray":
			x268aef2fda7d49d = x88d38775104122b8.x887cecb99310e671;
			break;
		case "lightGray":
		case "light-gray":
			x268aef2fda7d49d = x88d38775104122b8.x9e9e42ecc27f71a8;
			break;
		case "black":
			x268aef2fda7d49d = x88d38775104122b8.x89fffa2751fdecbe;
			break;
		default:
			x268aef2fda7d49d = x88d38775104122b8.x2bca50d746ec73b2;
			break;
		}
		return x195cb055715b526e.x5ab07bb8554e00d9(x268aef2fda7d49d);
	}

	internal static string x97c33f42b6cf3f14(x26d9ecb4bdf0456d xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (x195cb055715b526e.xc3bcf5a9ad941428(xbcea506a33cf9111))
		{
		case x88d38775104122b8.x2bca50d746ec73b2:
			return "none";
		case x88d38775104122b8.x8f02f53f1587477d:
			return "white";
		case x88d38775104122b8.x50a7f8950dee0ba8:
			return "yellow";
		case x88d38775104122b8.x23d6043fb9c177ec:
			return "green";
		case x88d38775104122b8.x87c77c027dc67f29:
			return "cyan";
		case x88d38775104122b8.x72f158c0f92fae4e:
			return "magenta";
		case x88d38775104122b8.xe3a106a4c00973e3:
			return "blue";
		case x88d38775104122b8.x46d2ee2a363fa637:
			return "red";
		case x88d38775104122b8.x31bdd1389ca026e0:
			if (!x5fbb1a9c98604ef5)
			{
				return "dark-blue";
			}
			return "darkBlue";
		case x88d38775104122b8.x3c0c4c381ec91e4c:
			if (!x5fbb1a9c98604ef5)
			{
				return "dark-cyan";
			}
			return "darkCyan";
		case x88d38775104122b8.x3327303aa89cf700:
			if (!x5fbb1a9c98604ef5)
			{
				return "dark-green";
			}
			return "darkGreen";
		case x88d38775104122b8.xab24404ba058d2b7:
			if (!x5fbb1a9c98604ef5)
			{
				return "dark-magenta";
			}
			return "darkMagenta";
		case x88d38775104122b8.x2ae2f959edf38ec3:
			if (!x5fbb1a9c98604ef5)
			{
				return "dark-red";
			}
			return "darkRed";
		case x88d38775104122b8.xa0ad12ae9ca7945f:
			if (!x5fbb1a9c98604ef5)
			{
				return "dark-yellow";
			}
			return "darkYellow";
		case x88d38775104122b8.x887cecb99310e671:
			if (!x5fbb1a9c98604ef5)
			{
				return "dark-gray";
			}
			return "darkGray";
		case x88d38775104122b8.x9e9e42ecc27f71a8:
			if (!x5fbb1a9c98604ef5)
			{
				return "light-gray";
			}
			return "lightGray";
		case x88d38775104122b8.x89fffa2751fdecbe:
			return "black";
		default:
			return "none";
		}
	}

	internal static x7af53bbecc5ccdd5 x29d363e0f9b0c0ec(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"baseline" => x7af53bbecc5ccdd5.x139412b8dea2f02b, 
			"superscript" => x7af53bbecc5ccdd5.xab66d68facbadf18, 
			"subscript" => x7af53bbecc5ccdd5.x1b1f4712a1a0c38c, 
			_ => x7af53bbecc5ccdd5.x139412b8dea2f02b, 
		};
	}

	internal static string x992ad59422dd17f0(x7af53bbecc5ccdd5 xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			x7af53bbecc5ccdd5.x139412b8dea2f02b => "baseline", 
			x7af53bbecc5ccdd5.xab66d68facbadf18 => "superscript", 
			x7af53bbecc5ccdd5.x1b1f4712a1a0c38c => "subscript", 
			_ => "baseline", 
		};
	}

	internal static x7bc150a164904c56 x7c6acb2cba42ded5(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"none" => x7bc150a164904c56.x4d0b9d4447ba7566, 
			"normal" => x7bc150a164904c56.xe9e531d1a6725226, 
			"add-before" => x7bc150a164904c56.x53d42bfcc4944725, 
			"change-before" => x7bc150a164904c56.xf1e8fa7f68f82a9b, 
			"delete-before" => x7bc150a164904c56.x7bc5cf41a12c681c, 
			"change-after" => x7bc150a164904c56.xc1e3682ea3cd3029, 
			"delete-and-change" => x7bc150a164904c56.xba44d45afa907296, 
			_ => x7bc150a164904c56.x4d0b9d4447ba7566, 
		};
	}

	internal static string xa8ef82c72e599c43(x7bc150a164904c56 xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			x7bc150a164904c56.x4d0b9d4447ba7566 => "none", 
			x7bc150a164904c56.xe9e531d1a6725226 => "normal", 
			x7bc150a164904c56.x53d42bfcc4944725 => "add-before", 
			x7bc150a164904c56.xf1e8fa7f68f82a9b => "change-before", 
			x7bc150a164904c56.x7bc5cf41a12c681c => "delete-before", 
			x7bc150a164904c56.xc1e3682ea3cd3029 => "change-after", 
			x7bc150a164904c56.xba44d45afa907296 => "delete-and-change", 
			_ => "none", 
		};
	}

	static xf2a0216b53787578()
	{
		x3651c627ebb0cbd8 = new Hashtable();
		xab0381e77e622b1e = new Hashtable();
		x9016dc159e1b0fc8 = new Hashtable();
		x54a57ef9de8326e8 = new Hashtable();
		x682712679dbc585a.x70fa1602ceccddee(new object[466]
		{
			"af-ZA",
			x448900fcb384c333.x3c45334f3ca93592,
			"sq-AL",
			x448900fcb384c333.xc20cc12c0dc705a4,
			"am-ET",
			x448900fcb384c333.x836c7ca8c68b34d2,
			"ar-DZ",
			x448900fcb384c333.x6a7d18f85448e2b3,
			"ar-BH",
			x448900fcb384c333.x1a4c29172633fdc0,
			"ar-EG",
			x448900fcb384c333.xa624e449e1ea1d52,
			"ar-IQ",
			x448900fcb384c333.xc17dff06247a436b,
			"ar-JO",
			x448900fcb384c333.xfcb5164406a3aff1,
			"ar-KW",
			x448900fcb384c333.xe9abd38d1d616965,
			"ar-LB",
			x448900fcb384c333.x67011cea3be31d81,
			"ar-LY",
			x448900fcb384c333.xea3c2ab7169e71ef,
			"ar-MA",
			x448900fcb384c333.x711ae278599bbf69,
			"ar-OM",
			x448900fcb384c333.xaebc775b99c9441d,
			"ar-QA",
			x448900fcb384c333.xceab2e2df00b5248,
			"ar-SA",
			x448900fcb384c333.x463d26a13233b6e3,
			"ar-SY",
			x448900fcb384c333.xa4ccd21187a4da57,
			"ar-TN",
			x448900fcb384c333.xe69e52bac9fb72fe,
			"ar-AE",
			x448900fcb384c333.x75ca45826f7b8968,
			"ar-YE",
			x448900fcb384c333.x730600874a7091d9,
			"hy-AM",
			x448900fcb384c333.x3e4764da80a122ca,
			"as-IN",
			x448900fcb384c333.x95428deb27cf5698,
			"az-Cyrl-AZ",
			x448900fcb384c333.x0e9d40be1e19512c,
			"az-Latn-AZ",
			x448900fcb384c333.x160bd5213291c2a8,
			"eu-ES",
			x448900fcb384c333.x893431488e451b37,
			"be-BY",
			x448900fcb384c333.xb331303bbccb0d80,
			"bn-IN",
			x448900fcb384c333.x0cc750a6b6e17469,
			"bn-BD",
			x448900fcb384c333.x9ff03e9dd5fc6fa2,
			"bs-Cyrl-BA",
			x448900fcb384c333.xae3226ecb520c99f,
			"bs-Latn-BA",
			x448900fcb384c333.xa5fa319c7968b464,
			"bg-BG",
			x448900fcb384c333.x71b2a186300377a6,
			"my-MM",
			x448900fcb384c333.x648ce7aee03f871c,
			"ca-ES",
			x448900fcb384c333.x5614bec5a421ea3f,
			"chr-US",
			x448900fcb384c333.xc62f35562a648d0d,
			"zh-HK",
			x448900fcb384c333.x21c592529568b300,
			"zh-MO",
			x448900fcb384c333.xce4c02c7fd80bbe2,
			"zh-CN",
			x448900fcb384c333.x0e9ecdb4a279ee3b,
			"zh-SG",
			x448900fcb384c333.x17d0d2ce7db80a64,
			"zh-TW",
			x448900fcb384c333.x9d43eda807ddf817,
			"hr-BA",
			x448900fcb384c333.xd53410989ba3031f,
			"hr-HR",
			x448900fcb384c333.xda375eef5c11697d,
			"cs-CZ",
			x448900fcb384c333.x7d6fbe11ec3785a3,
			"da-DK",
			x448900fcb384c333.xc8932a5748e0fc7b,
			"dv-MV",
			x448900fcb384c333.xf5334f1686eb2edc,
			"nl-NL",
			x448900fcb384c333.xaf6b1a2483180de7,
			"nl-BE",
			x448900fcb384c333.xa640b3c87aa76bdb,
			"bin-NG",
			x448900fcb384c333.xe629c11673ade5dc,
			"en-AU",
			x448900fcb384c333.xcc8e53c0ab9855eb,
			"en-BZ",
			x448900fcb384c333.x4e8d688fb9edd1f8,
			"en-CA",
			x448900fcb384c333.x35ee91fedd1d3633,
			"en-029",
			x448900fcb384c333.xa17a6592ff1ae152,
			"en-HK",
			x448900fcb384c333.x50740a03563ec2db,
			"en-IN",
			x448900fcb384c333.x34cd9d68a13ef2f9,
			"en-ID",
			x448900fcb384c333.xe89444a5ffa760af,
			"en-IE",
			x448900fcb384c333.x18ebc905838e1cf9,
			"en-JM",
			x448900fcb384c333.x9c6361f59e06a24f,
			"en-MY",
			x448900fcb384c333.xca2f5a4ba135aa67,
			"en-NZ",
			x448900fcb384c333.x3151e26d3a0deaaf,
			"en-PH",
			x448900fcb384c333.x4b01d7a578d79c64,
			"en-SG",
			x448900fcb384c333.x3088f89a1fb7b754,
			"en-ZA",
			x448900fcb384c333.xc502f461f70ff6f4,
			"en-TT",
			x448900fcb384c333.xb7370d38e0898c3c,
			"en-GB",
			x448900fcb384c333.x65422ac3600da86a,
			"en-US",
			x448900fcb384c333.x2cee983cddd1e041,
			"en-ZW",
			x448900fcb384c333.x6e1dfba77e019ebe,
			"et-EE",
			x448900fcb384c333.xe55690bda6240d59,
			"fo-FO",
			x448900fcb384c333.x363af1a0659923cb,
			"fil-PH",
			x448900fcb384c333.x78adbdb8d7f075d9,
			"fi-FI",
			x448900fcb384c333.x2a455b723cd70448,
			"fr-BE",
			x448900fcb384c333.xb6f8230587018043,
			"fr-CM",
			x448900fcb384c333.xfcfd6a2d2038c227,
			"fr-CA",
			x448900fcb384c333.x767ff629671cade4,
			"fr-CD",
			x448900fcb384c333.xbdfd4e984e9ead0f,
			"fr-CI",
			x448900fcb384c333.x5ff4a108f462069c,
			"fr-FR",
			x448900fcb384c333.x7b5016c28544e89d,
			"fr-HT",
			x448900fcb384c333.x124b8825cd569833,
			"fr-LU",
			x448900fcb384c333.x9202122ca27c7d10,
			"fr-ML",
			x448900fcb384c333.x9e6c0f3af81357ac,
			"fr-MC",
			x448900fcb384c333.xf257665e8792c090,
			"fr-MA",
			x448900fcb384c333.x42996ab53c34345d,
			"fr-RE",
			x448900fcb384c333.xe423c16ff8dabe39,
			"fr-SN",
			x448900fcb384c333.x7e2e2bfe00af44ac,
			"fr-CH",
			x448900fcb384c333.x0403b53541138430,
			"fr-WINDIES",
			x448900fcb384c333.x66e2071cf6e5a671,
			"fy-NL",
			x448900fcb384c333.x82e6426d5c654197,
			"ff-NG",
			x448900fcb384c333.xbf961c7ab0b09d12,
			"gd-GB",
			x448900fcb384c333.xe99934fc071e80da,
			"gl-ES",
			x448900fcb384c333.x78326a573b93d10b,
			"ka-GE",
			x448900fcb384c333.x68692e185560733b,
			"de-AT",
			x448900fcb384c333.x471e3c0b501857eb,
			"de-DE",
			x448900fcb384c333.xe8970192bd2476d9,
			"de-LI",
			x448900fcb384c333.xe41dcd39e2a8580e,
			"de-LU",
			x448900fcb384c333.xbd531a7a3b662ac3,
			"de-CH",
			x448900fcb384c333.xb764bd2446c6e815,
			"el-GR",
			x448900fcb384c333.xfcfdd522ca68103c,
			"gn-PY",
			x448900fcb384c333.x9fafa170d8fffc62,
			"gu-IN",
			x448900fcb384c333.x4993fd0c5f9fa2ef,
			"ha-Latn-NG",
			x448900fcb384c333.x1dd54969c1e805b9,
			"haw-US",
			x448900fcb384c333.x9d343f53b9b2f3d4,
			"he-IL",
			x448900fcb384c333.x93242aad8aceb97c,
			"hi-IN",
			x448900fcb384c333.xc8cfb43aa523d7c8,
			"hu-HU",
			x448900fcb384c333.x9ff089b341c1af79,
			"ibb-NG",
			x448900fcb384c333.x89f1af565db5bd3c,
			"is-IS",
			x448900fcb384c333.x14eb8d2c3787a5d5,
			"ig-NG",
			x448900fcb384c333.xf1e21c7e002dd1b1,
			"id-ID",
			x448900fcb384c333.xc69a17c652d6be7f,
			"iu-Cans-CA",
			x448900fcb384c333.x52ebf2d4ada4c488,
			"iu-Latn-CA",
			x448900fcb384c333.x16a43d3b4662ac42,
			"ga-IE",
			x448900fcb384c333.xa10c55385874cb0c,
			"it-IT",
			x448900fcb384c333.x0716994c4e59c5e1,
			"it-CH",
			x448900fcb384c333.xfad7cc6e00e25b74,
			"ja-JP",
			x448900fcb384c333.x842d1848287ed735,
			"kn-IN",
			x448900fcb384c333.x343d7dde3b6be088,
			"kr-NG",
			x448900fcb384c333.xd41266d4ec243561,
			"ks-Deva",
			x448900fcb384c333.x8f26dcb6bb927a13,
			"ks-Arab",
			x448900fcb384c333.x14d4120a664d5df4,
			"kk-KZ",
			x448900fcb384c333.x5d4b30f306abed4f,
			"km-KH",
			x448900fcb384c333.xdd150622ce70df5e,
			"sw-KE",
			x448900fcb384c333.x8b2d18f9541a67fb,
			"kok-IN",
			x448900fcb384c333.x94d51d5744af4316,
			"ko-KR",
			x448900fcb384c333.x9cc16fa5cbd496eb,
			"ky-KG",
			x448900fcb384c333.x5472d9c0f52e351a,
			"lo-LA",
			x448900fcb384c333.x9554f406451432b4,
			"la-Latn",
			x448900fcb384c333.x94edc0d9bd2a8401,
			"lv-LV",
			x448900fcb384c333.x86efb06087b27bd4,
			"lt-LT",
			x448900fcb384c333.x11633218487950bf,
			"lb-LU",
			x448900fcb384c333.xb3c7537e98e6991a,
			"mk-MK",
			x448900fcb384c333.x26a7ae93d2641ea4,
			"ms-MY",
			x448900fcb384c333.xac93e00c4692e934,
			"ms-BN",
			x448900fcb384c333.xbdb782a773553216,
			"ml-IN",
			x448900fcb384c333.x48c33b4d3a861c82,
			"mt-MT",
			x448900fcb384c333.x1886864a8946e47e,
			"mni-IN",
			x448900fcb384c333.x0e6603750a22db78,
			"mi-NZ",
			x448900fcb384c333.xf89e02fe25831982,
			"arn-CL",
			x448900fcb384c333.x524a94f40c0a33a7,
			"mr-IN",
			x448900fcb384c333.xb1c2bee0951d91e1,
			"moh-CA",
			x448900fcb384c333.x4b327d3d066df03e,
			"mn-MN",
			x448900fcb384c333.xb106cce070268736,
			"mn-Mong-CN",
			x448900fcb384c333.xe7eb4d5f067b5084,
			"ne-NP",
			x448900fcb384c333.x9139fbe199933d21,
			"ne-IN",
			x448900fcb384c333.x96ef4b11c389cf50,
			"nb-NO",
			x448900fcb384c333.x1668fb7ac8c6e746,
			"nn-NO",
			x448900fcb384c333.x39e156cd8aaa5201,
			"or-IN",
			x448900fcb384c333.x5d1cc017e5052194,
			"om-Ethi-ET",
			x448900fcb384c333.xf0121605a1d3cdfa,
			"pap-AN",
			x448900fcb384c333.xbb965a8e03120691,
			"ps-AF",
			x448900fcb384c333.xe23df02766d4d2ed,
			"fa-IR",
			x448900fcb384c333.x790e93630c6f4ece,
			"pl-PL",
			x448900fcb384c333.x3e563631c667b520,
			"pt-BR",
			x448900fcb384c333.x46547bad15f03050,
			"pt-PT",
			x448900fcb384c333.x640569e793d4eeb7,
			"pa-IN",
			x448900fcb384c333.xb3d25d9aac22b410,
			"pa-PK",
			x448900fcb384c333.xf27d12f417b45bf3,
			"quz-BO",
			x448900fcb384c333.x715326a1de7e681f,
			"quz-EC",
			x448900fcb384c333.xab7b4968080e3d64,
			"quz-PE",
			x448900fcb384c333.x92714e31861dbc6f,
			"ro-MO",
			x448900fcb384c333.x452298bad8ccf2a7,
			"ro-RO",
			x448900fcb384c333.x6de69fbefbbe3820,
			"rm-CH",
			x448900fcb384c333.xe63d74d66008c4cc,
			"ru-MO",
			x448900fcb384c333.x13404acc9a2bd582,
			"ru-RU",
			x448900fcb384c333.x605efb69f1f204e7,
			"smn-FI",
			x448900fcb384c333.x3aecd69beacee573,
			"smj-NO",
			x448900fcb384c333.xcc08e9166bbd5d38,
			"smj-SE",
			x448900fcb384c333.x953273585f98119e,
			"se-FI",
			x448900fcb384c333.xde3e7231b9dc5033,
			"se-NO",
			x448900fcb384c333.x20770244a0f0c6dc,
			"se-SE",
			x448900fcb384c333.x317ce4c5837f62ca,
			"sms-FI",
			x448900fcb384c333.x6c7081c93b0bd326,
			"sma-NO",
			x448900fcb384c333.x9e6f0d20544bcc4b,
			"sma-SE",
			x448900fcb384c333.xe6275d88b84f9e29,
			"sa-IN",
			x448900fcb384c333.x700962f8cee35a46,
			"nso-ZA",
			x448900fcb384c333.xa3eff47a3e9e2730,
			"sr-Cyrl-BA",
			x448900fcb384c333.x0a0a29ae5fe2d5e9,
			"sr-Cyrl-CS",
			x448900fcb384c333.xd4dad5e888790000,
			"sr-Latn-BA",
			x448900fcb384c333.xfde058d57041de38,
			"sr-Latn-CS",
			x448900fcb384c333.x81a94c4a76fa8b73,
			"sd-Arab-PK",
			x448900fcb384c333.x1abd85cbffb0bfaa,
			"sd-Deva-IN",
			x448900fcb384c333.x73c9d3551715e1e3,
			"si-LK",
			x448900fcb384c333.x35b38702192c34f5,
			"sk-SK",
			x448900fcb384c333.xa601882490df7806,
			"sl-SI",
			x448900fcb384c333.x2aa09a5818360704,
			"so-SO",
			x448900fcb384c333.x83317786c4d3f5f4,
			"hsb-DE",
			x448900fcb384c333.x4e5fcbdcd316040c,
			"es-AR",
			x448900fcb384c333.x8850faefa1ed2570,
			"es-BO",
			x448900fcb384c333.x168dcc589f1add55,
			"es-CL",
			x448900fcb384c333.xda2d3e078fa9fc6d,
			"es-CO",
			x448900fcb384c333.x84ef75be587b0a5a,
			"es-CR",
			x448900fcb384c333.x4093167b5c2263c5,
			"es-DO",
			x448900fcb384c333.xe9145273ee90bb34,
			"es-EC",
			x448900fcb384c333.x501c40ffb3293ee0,
			"es-SV",
			x448900fcb384c333.xbd42ebcb933e74ce,
			"es-GT",
			x448900fcb384c333.xcad912f8c7cf4f1a,
			"es-HN",
			x448900fcb384c333.x1ee4eb31551048e4,
			"es-MX",
			x448900fcb384c333.x3045f4d64ffaecd7,
			"es-NI",
			x448900fcb384c333.xfe191ba5de472e9e,
			"es-PA",
			x448900fcb384c333.x4b7f8b2597eb0728,
			"es-PY",
			x448900fcb384c333.xaa10484439839c76,
			"es-PE",
			x448900fcb384c333.x8b5946f2b65edba4,
			"es-PR",
			x448900fcb384c333.xba2cda7cc5540600,
			"es-ES",
			x448900fcb384c333.x45436470ed34e3fb,
			"es-ES_tradnl",
			x448900fcb384c333.x218e824acc73aa86,
			"es-UY",
			x448900fcb384c333.x4dd9e1cb3ab94346,
			"es-VE",
			x448900fcb384c333.x668ad0e5a1a06dec,
			"st-ZA",
			x448900fcb384c333.x8ebb836285568ad8,
			"sv-FI",
			x448900fcb384c333.x15a2aef2a9a274b9,
			"sv-SE",
			x448900fcb384c333.xf89eff9607d893c7,
			"syr-SY",
			x448900fcb384c333.x37795f235a986ca0,
			"tg-Cyrl-TJ",
			x448900fcb384c333.x63c5b6a4aba73d9a,
			"tzm-Arab-MA",
			x448900fcb384c333.x091a92e94dd0cf1e,
			"tzm-Latn-DZ",
			x448900fcb384c333.x1287ddea59573bb9,
			"ta-IN",
			x448900fcb384c333.xe62d0d9d43601611,
			"tt-RU",
			x448900fcb384c333.xd578cd7fff817d49,
			"te-IN",
			x448900fcb384c333.xff42b7fb9f01a41f,
			"th-TH",
			x448900fcb384c333.x2bc7d5aeca5726e0,
			"bo-BT",
			x448900fcb384c333.x2239ec68349f277f,
			"bo-CN",
			x448900fcb384c333.x8ccd37ef0a63ba0a,
			"ti-ER",
			x448900fcb384c333.x5aa6f2c8246fcbc3,
			"ti-ET",
			x448900fcb384c333.x56767b897052dac5,
			"ts-ZA",
			x448900fcb384c333.xe85d9edda6191fb9,
			"tn-ZA",
			x448900fcb384c333.xf188da0abdc854b4,
			"tr-TR",
			x448900fcb384c333.x61e07c07ef5c9754,
			"tk-TM",
			x448900fcb384c333.xc5b8db5fe087efea,
			"uk-UA",
			x448900fcb384c333.xc7113192ef7491aa,
			"ur-PK",
			x448900fcb384c333.x69d0c314232cf917,
			"uz-Cyrl-UZ",
			x448900fcb384c333.xf6359c626f9d6fa7,
			"uz-Latn-UZ",
			x448900fcb384c333.x7ac0e174e8b294d7,
			"ve-ZA",
			x448900fcb384c333.x23325789c2558148,
			"vi-VN",
			x448900fcb384c333.xd4dee6432794fa61,
			"cy-GB",
			x448900fcb384c333.x452756e44bdc0147,
			"xh-ZA",
			x448900fcb384c333.x5174ac87e2fbb7db,
			"ii-CN",
			x448900fcb384c333.xe88688e270a0943d,
			"yi-Hebr",
			x448900fcb384c333.x9d5a7d101ab446c0,
			"yo-NG",
			x448900fcb384c333.x5d592b205e2f0880,
			"zu-ZA",
			x448900fcb384c333.xaa607949c983ab3e
		}, x3651c627ebb0cbd8, xab0381e77e622b1e);
		x682712679dbc585a.x70fa1602ceccddee(new object[466]
		{
			"AF",
			x448900fcb384c333.x3c45334f3ca93592,
			"SQ",
			x448900fcb384c333.xc20cc12c0dc705a4,
			"AMH",
			x448900fcb384c333.x836c7ca8c68b34d2,
			"AR-DZ",
			x448900fcb384c333.x6a7d18f85448e2b3,
			"AR-BH",
			x448900fcb384c333.x1a4c29172633fdc0,
			"AR-EG",
			x448900fcb384c333.xa624e449e1ea1d52,
			"AR-IQ",
			x448900fcb384c333.xc17dff06247a436b,
			"AR-JO",
			x448900fcb384c333.xfcb5164406a3aff1,
			"AR-KW",
			x448900fcb384c333.xe9abd38d1d616965,
			"AR-LB",
			x448900fcb384c333.x67011cea3be31d81,
			"AR-LY",
			x448900fcb384c333.xea3c2ab7169e71ef,
			"AR-MA",
			x448900fcb384c333.x711ae278599bbf69,
			"AR-OM",
			x448900fcb384c333.xaebc775b99c9441d,
			"AR-QA",
			x448900fcb384c333.xceab2e2df00b5248,
			"AR-SA",
			x448900fcb384c333.x463d26a13233b6e3,
			"AR-SY",
			x448900fcb384c333.xa4ccd21187a4da57,
			"AR-TN",
			x448900fcb384c333.xe69e52bac9fb72fe,
			"AR-AE",
			x448900fcb384c333.x75ca45826f7b8968,
			"AR-YE",
			x448900fcb384c333.x730600874a7091d9,
			"HY",
			x448900fcb384c333.x3e4764da80a122ca,
			"AS",
			x448900fcb384c333.x95428deb27cf5698,
			"AZ-CYR",
			x448900fcb384c333.x0e9d40be1e19512c,
			"AZ-LATIN",
			x448900fcb384c333.x160bd5213291c2a8,
			"EU",
			x448900fcb384c333.x893431488e451b37,
			"BE",
			x448900fcb384c333.xb331303bbccb0d80,
			"BN",
			x448900fcb384c333.x0cc750a6b6e17469,
			"0845",
			x448900fcb384c333.x9ff03e9dd5fc6fa2,
			"201A",
			x448900fcb384c333.xae3226ecb520c99f,
			"141A",
			x448900fcb384c333.xa5fa319c7968b464,
			"BG",
			x448900fcb384c333.x71b2a186300377a6,
			"MY",
			x448900fcb384c333.x648ce7aee03f871c,
			"CA",
			x448900fcb384c333.x5614bec5a421ea3f,
			"CHR",
			x448900fcb384c333.xc62f35562a648d0d,
			"ZH-HK",
			x448900fcb384c333.x21c592529568b300,
			"ZH-MO",
			x448900fcb384c333.xce4c02c7fd80bbe2,
			"ZH-CN",
			x448900fcb384c333.x0e9ecdb4a279ee3b,
			"ZH-SG",
			x448900fcb384c333.x17d0d2ce7db80a64,
			"ZH-TW",
			x448900fcb384c333.x9d43eda807ddf817,
			"SH",
			x448900fcb384c333.xd53410989ba3031f,
			"HR",
			x448900fcb384c333.xda375eef5c11697d,
			"CS",
			x448900fcb384c333.x7d6fbe11ec3785a3,
			"DA",
			x448900fcb384c333.xc8932a5748e0fc7b,
			"DIV",
			x448900fcb384c333.xf5334f1686eb2edc,
			"NL",
			x448900fcb384c333.xaf6b1a2483180de7,
			"NL-BE",
			x448900fcb384c333.xa640b3c87aa76bdb,
			"0466",
			x448900fcb384c333.xe629c11673ade5dc,
			"EN-AU",
			x448900fcb384c333.xcc8e53c0ab9855eb,
			"EN-BZ",
			x448900fcb384c333.x4e8d688fb9edd1f8,
			"EN-CA",
			x448900fcb384c333.x35ee91fedd1d3633,
			"EN-CARRIBEAN",
			x448900fcb384c333.xa17a6592ff1ae152,
			"EN-HK",
			x448900fcb384c333.x50740a03563ec2db,
			"EN-IN",
			x448900fcb384c333.x34cd9d68a13ef2f9,
			"EN-ID",
			x448900fcb384c333.xe89444a5ffa760af,
			"EN-IE",
			x448900fcb384c333.x18ebc905838e1cf9,
			"EN-JM",
			x448900fcb384c333.x9c6361f59e06a24f,
			"EN-MY",
			x448900fcb384c333.xca2f5a4ba135aa67,
			"EN-NZ",
			x448900fcb384c333.x3151e26d3a0deaaf,
			"EN-PH",
			x448900fcb384c333.x4b01d7a578d79c64,
			"EN-SG",
			x448900fcb384c333.x3088f89a1fb7b754,
			"EN-ZA",
			x448900fcb384c333.xc502f461f70ff6f4,
			"EN-TT",
			x448900fcb384c333.xb7370d38e0898c3c,
			"EN-GB",
			x448900fcb384c333.x65422ac3600da86a,
			"EN-US",
			x448900fcb384c333.x2cee983cddd1e041,
			"EN-ZW",
			x448900fcb384c333.x6e1dfba77e019ebe,
			"ET",
			x448900fcb384c333.xe55690bda6240d59,
			"FO",
			x448900fcb384c333.x363af1a0659923cb,
			"0464",
			x448900fcb384c333.x78adbdb8d7f075d9,
			"FI",
			x448900fcb384c333.x2a455b723cd70448,
			"FR-BE",
			x448900fcb384c333.xb6f8230587018043,
			"FR-CM",
			x448900fcb384c333.xfcfd6a2d2038c227,
			"FR-CA",
			x448900fcb384c333.x767ff629671cade4,
			"FR-CD",
			x448900fcb384c333.xbdfd4e984e9ead0f,
			"FR-CI",
			x448900fcb384c333.x5ff4a108f462069c,
			"FR",
			x448900fcb384c333.x7b5016c28544e89d,
			"FR-HT",
			x448900fcb384c333.x124b8825cd569833,
			"FR-LU",
			x448900fcb384c333.x9202122ca27c7d10,
			"FR-ML",
			x448900fcb384c333.x9e6c0f3af81357ac,
			"FR-MC",
			x448900fcb384c333.xf257665e8792c090,
			"FR-MA",
			x448900fcb384c333.x42996ab53c34345d,
			"FR-RE",
			x448900fcb384c333.xe423c16ff8dabe39,
			"FR-SN",
			x448900fcb384c333.x7e2e2bfe00af44ac,
			"FR-CH",
			x448900fcb384c333.x0403b53541138430,
			"FR-WINDIES",
			x448900fcb384c333.x66e2071cf6e5a671,
			"FY",
			x448900fcb384c333.x82e6426d5c654197,
			"0467",
			x448900fcb384c333.xbf961c7ab0b09d12,
			"GD",
			x448900fcb384c333.xe99934fc071e80da,
			"GL",
			x448900fcb384c333.x78326a573b93d10b,
			"GEO/KAT",
			x448900fcb384c333.x68692e185560733b,
			"DE-AT",
			x448900fcb384c333.x471e3c0b501857eb,
			"DE",
			x448900fcb384c333.xe8970192bd2476d9,
			"DE-LI",
			x448900fcb384c333.xe41dcd39e2a8580e,
			"DE-LU",
			x448900fcb384c333.xbd531a7a3b662ac3,
			"DE-CH",
			x448900fcb384c333.xb764bd2446c6e815,
			"EL",
			x448900fcb384c333.xfcfdd522ca68103c,
			"GN",
			x448900fcb384c333.x9fafa170d8fffc62,
			"GU",
			x448900fcb384c333.x4993fd0c5f9fa2ef,
			"HA",
			x448900fcb384c333.x1dd54969c1e805b9,
			"0475",
			x448900fcb384c333.x9d343f53b9b2f3d4,
			"HE",
			x448900fcb384c333.x93242aad8aceb97c,
			"HI",
			x448900fcb384c333.xc8cfb43aa523d7c8,
			"HU",
			x448900fcb384c333.x9ff089b341c1af79,
			"0469",
			x448900fcb384c333.x89f1af565db5bd3c,
			"IS",
			x448900fcb384c333.x14eb8d2c3787a5d5,
			"0470",
			x448900fcb384c333.xf1e21c7e002dd1b1,
			"IN",
			x448900fcb384c333.xc69a17c652d6be7f,
			"IKU",
			x448900fcb384c333.x52ebf2d4ada4c488,
			"085D",
			x448900fcb384c333.x16a43d3b4662ac42,
			"GA",
			x448900fcb384c333.xa10c55385874cb0c,
			"IT",
			x448900fcb384c333.x0716994c4e59c5e1,
			"IT-CH",
			x448900fcb384c333.xfad7cc6e00e25b74,
			"JA",
			x448900fcb384c333.x842d1848287ed735,
			"KN",
			x448900fcb384c333.x343d7dde3b6be088,
			"0471",
			x448900fcb384c333.xd41266d4ec243561,
			"KS-IN",
			x448900fcb384c333.x8f26dcb6bb927a13,
			"KS",
			x448900fcb384c333.x14d4120a664d5df4,
			"KZ",
			x448900fcb384c333.x5d4b30f306abed4f,
			"KHM",
			x448900fcb384c333.xdd150622ce70df5e,
			"SW",
			x448900fcb384c333.x8b2d18f9541a67fb,
			"KOK",
			x448900fcb384c333.x94d51d5744af4316,
			"KO",
			x448900fcb384c333.x9cc16fa5cbd496eb,
			"KY",
			x448900fcb384c333.x5472d9c0f52e351a,
			"LAO",
			x448900fcb384c333.x9554f406451432b4,
			"LA",
			x448900fcb384c333.x94edc0d9bd2a8401,
			"LV",
			x448900fcb384c333.x86efb06087b27bd4,
			"LT",
			x448900fcb384c333.x11633218487950bf,
			"046E",
			x448900fcb384c333.xb3c7537e98e6991a,
			"MK",
			x448900fcb384c333.x26a7ae93d2641ea4,
			"MS",
			x448900fcb384c333.xac93e00c4692e934,
			"MS-BN",
			x448900fcb384c333.xbdb782a773553216,
			"ML",
			x448900fcb384c333.x48c33b4d3a861c82,
			"MT",
			x448900fcb384c333.x1886864a8946e47e,
			"MNI",
			x448900fcb384c333.x0e6603750a22db78,
			"0481",
			x448900fcb384c333.xf89e02fe25831982,
			"047A",
			x448900fcb384c333.x524a94f40c0a33a7,
			"MR",
			x448900fcb384c333.xb1c2bee0951d91e1,
			"047C",
			x448900fcb384c333.x4b327d3d066df03e,
			"MN",
			x448900fcb384c333.xb106cce070268736,
			"MN-MN",
			x448900fcb384c333.xe7eb4d5f067b5084,
			"NE",
			x448900fcb384c333.x9139fbe199933d21,
			"NE-IN",
			x448900fcb384c333.x96ef4b11c389cf50,
			"NO-BOK",
			x448900fcb384c333.x1668fb7ac8c6e746,
			"NO-NYN",
			x448900fcb384c333.x39e156cd8aaa5201,
			"OR",
			x448900fcb384c333.x5d1cc017e5052194,
			"OM",
			x448900fcb384c333.xf0121605a1d3cdfa,
			"0479",
			x448900fcb384c333.xbb965a8e03120691,
			"0463",
			x448900fcb384c333.xe23df02766d4d2ed,
			"FA",
			x448900fcb384c333.x790e93630c6f4ece,
			"PL",
			x448900fcb384c333.x3e563631c667b520,
			"PT-BR",
			x448900fcb384c333.x46547bad15f03050,
			"PT",
			x448900fcb384c333.x640569e793d4eeb7,
			"PA",
			x448900fcb384c333.xb3d25d9aac22b410,
			"0846",
			x448900fcb384c333.xf27d12f417b45bf3,
			"046B",
			x448900fcb384c333.x715326a1de7e681f,
			"086B",
			x448900fcb384c333.xab7b4968080e3d64,
			"0C6B",
			x448900fcb384c333.x92714e31861dbc6f,
			"RO-MO",
			x448900fcb384c333.x452298bad8ccf2a7,
			"RO",
			x448900fcb384c333.x6de69fbefbbe3820,
			"RM",
			x448900fcb384c333.xe63d74d66008c4cc,
			"RU-MO",
			x448900fcb384c333.x13404acc9a2bd582,
			"RU",
			x448900fcb384c333.x605efb69f1f204e7,
			"243B",
			x448900fcb384c333.x3aecd69beacee573,
			"103B",
			x448900fcb384c333.xcc08e9166bbd5d38,
			"143B",
			x448900fcb384c333.x953273585f98119e,
			"0C3B",
			x448900fcb384c333.xde3e7231b9dc5033,
			"I-SAMI-NO",
			x448900fcb384c333.x20770244a0f0c6dc,
			"083B",
			x448900fcb384c333.x317ce4c5837f62ca,
			"203B",
			x448900fcb384c333.x6c7081c93b0bd326,
			"183B",
			x448900fcb384c333.x9e6f0d20544bcc4b,
			"1C3B",
			x448900fcb384c333.xe6275d88b84f9e29,
			"SA",
			x448900fcb384c333.x700962f8cee35a46,
			"046C",
			x448900fcb384c333.xa3eff47a3e9e2730,
			"1C1A",
			x448900fcb384c333.x0a0a29ae5fe2d5e9,
			"SR-CYR",
			x448900fcb384c333.xd4dad5e888790000,
			"181A",
			x448900fcb384c333.xfde058d57041de38,
			"SR",
			x448900fcb384c333.x81a94c4a76fa8b73,
			"0859",
			x448900fcb384c333.x1abd85cbffb0bfaa,
			"SD",
			x448900fcb384c333.x73c9d3551715e1e3,
			"045B",
			x448900fcb384c333.x35b38702192c34f5,
			"SK",
			x448900fcb384c333.xa601882490df7806,
			"SL",
			x448900fcb384c333.x2aa09a5818360704,
			"SO",
			x448900fcb384c333.x83317786c4d3f5f4,
			"SB",
			x448900fcb384c333.x4e5fcbdcd316040c,
			"ES-AR",
			x448900fcb384c333.x8850faefa1ed2570,
			"ES-BO",
			x448900fcb384c333.x168dcc589f1add55,
			"ES-CL",
			x448900fcb384c333.xda2d3e078fa9fc6d,
			"ES-CO",
			x448900fcb384c333.x84ef75be587b0a5a,
			"ES-CR",
			x448900fcb384c333.x4093167b5c2263c5,
			"ES-DO",
			x448900fcb384c333.xe9145273ee90bb34,
			"ES-EC",
			x448900fcb384c333.x501c40ffb3293ee0,
			"ES-SV",
			x448900fcb384c333.xbd42ebcb933e74ce,
			"ES-GT",
			x448900fcb384c333.xcad912f8c7cf4f1a,
			"ES-HN",
			x448900fcb384c333.x1ee4eb31551048e4,
			"ES-MX",
			x448900fcb384c333.x3045f4d64ffaecd7,
			"ES-NI",
			x448900fcb384c333.xfe191ba5de472e9e,
			"ES-PA",
			x448900fcb384c333.x4b7f8b2597eb0728,
			"ES-PY",
			x448900fcb384c333.xaa10484439839c76,
			"ES-PE",
			x448900fcb384c333.x8b5946f2b65edba4,
			"ES-PR",
			x448900fcb384c333.xba2cda7cc5540600,
			"ES",
			x448900fcb384c333.x45436470ed34e3fb,
			"ES-TRAD",
			x448900fcb384c333.x218e824acc73aa86,
			"ES-UY",
			x448900fcb384c333.x4dd9e1cb3ab94346,
			"ES-VE",
			x448900fcb384c333.x668ad0e5a1a06dec,
			"SX",
			x448900fcb384c333.x8ebb836285568ad8,
			"SV-FI",
			x448900fcb384c333.x15a2aef2a9a274b9,
			"SV",
			x448900fcb384c333.xf89eff9607d893c7,
			"SYR",
			x448900fcb384c333.x37795f235a986ca0,
			"TG",
			x448900fcb384c333.x63c5b6a4aba73d9a,
			"045F",
			x448900fcb384c333.x091a92e94dd0cf1e,
			"085F",
			x448900fcb384c333.x1287ddea59573bb9,
			"TA",
			x448900fcb384c333.xe62d0d9d43601611,
			"TT",
			x448900fcb384c333.xd578cd7fff817d49,
			"TE",
			x448900fcb384c333.xff42b7fb9f01a41f,
			"TH",
			x448900fcb384c333.x2bc7d5aeca5726e0,
			"0851",
			x448900fcb384c333.x2239ec68349f277f,
			"BO",
			x448900fcb384c333.x8ccd37ef0a63ba0a,
			"TI-ER",
			x448900fcb384c333.x5aa6f2c8246fcbc3,
			"TI-ET",
			x448900fcb384c333.x56767b897052dac5,
			"TS",
			x448900fcb384c333.xe85d9edda6191fb9,
			"TN",
			x448900fcb384c333.xf188da0abdc854b4,
			"TR",
			x448900fcb384c333.x61e07c07ef5c9754,
			"TK",
			x448900fcb384c333.xc5b8db5fe087efea,
			"UK",
			x448900fcb384c333.xc7113192ef7491aa,
			"ER",
			x448900fcb384c333.x69d0c314232cf917,
			"UZ-CYR",
			x448900fcb384c333.xf6359c626f9d6fa7,
			"UZ",
			x448900fcb384c333.x7ac0e174e8b294d7,
			"VEN",
			x448900fcb384c333.x23325789c2558148,
			"VI",
			x448900fcb384c333.xd4dee6432794fa61,
			"CY",
			x448900fcb384c333.x452756e44bdc0147,
			"XH",
			x448900fcb384c333.x5174ac87e2fbb7db,
			"0478",
			x448900fcb384c333.xe88688e270a0943d,
			"JI",
			x448900fcb384c333.x9d5a7d101ab446c0,
			"YO",
			x448900fcb384c333.x5d592b205e2f0880,
			"ZU",
			x448900fcb384c333.xaa607949c983ab3e
		}, x9016dc159e1b0fc8, x54a57ef9de8326e8);
	}
}
