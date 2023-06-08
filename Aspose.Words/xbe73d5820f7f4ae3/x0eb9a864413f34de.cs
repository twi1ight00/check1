using System.Collections;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fonts;
using Aspose.Words.Lists;
using Aspose.Words.Properties;
using Aspose.Words.Tables;
using x011d489fb9df7027;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xda075892eccab2ad;
using xf9a9481c3f63a419;
using xfce5b6a304778b89;

namespace xbe73d5820f7f4ae3;

internal class x0eb9a864413f34de
{
	private const string x4248dd426a402996 = " (user)";

	private static readonly Hashtable x462a070e16afbac5;

	private static readonly Hashtable x9505b0ae46363b0c;

	private static readonly Hashtable x73b371e817d6608f;

	private static readonly Hashtable xdd1c5b917fe6db60;

	private static readonly Hashtable x6ed3560115064f44;

	private static readonly Hashtable x3f0c300c9b8f8c84;

	private static readonly Hashtable x276c2db3eb504e56;

	private static readonly Hashtable x1f2e520ce6648ad0;

	private static readonly Hashtable x9f74c36ed6f29ae6;

	private static readonly Hashtable x47b289e6d343959d;

	private static readonly Hashtable xe9262ddc4a1310be;

	private static readonly Hashtable x72699d9802e89fa9;

	private static readonly Hashtable xe49c14b143611f35;

	private static readonly Hashtable xff3ebdfb873687f6;

	private static readonly Hashtable xae1872c5eb9882c8;

	private static readonly Hashtable xb12f6b492f47f35e;

	private static readonly Hashtable xcc4e65f7fc2abde3;

	private static readonly Hashtable x4518183e0cfa3a1e;

	private static readonly Hashtable x4480d5dbde174156;

	private static readonly Hashtable x5ab2d2c9eba4d278;

	private static readonly Hashtable x7660b2bbd0607e4f;

	private static readonly Hashtable x238eae4ac21bd0fb;

	private static readonly Hashtable x0d20435df4854d97;

	private static readonly Hashtable x93b88c04601ba258;

	private static readonly Hashtable x841efd55c5138168;

	private static readonly Hashtable x885779ab5535d24e;

	internal static x3b504d8c866583dc x4692ce795d87911d(string xbcea506a33cf9111)
	{
		return (x3b504d8c866583dc)x682712679dbc585a.xce92de628aa023cf(x841efd55c5138168, xbcea506a33cf9111, VerticalAlignment.None);
	}

	internal static string x88b5247903a7524e(x3b504d8c866583dc x71a41cb92e0388f1)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x885779ab5535d24e, x71a41cb92e0388f1, "none");
	}

	internal static x4dd8a59ec8974a5f x2bd866c4b07a7144(char x3c4da2980d043c95)
	{
		return x3c4da2980d043c95 switch
		{
			'M' => x4dd8a59ec8974a5f.x01b2723108ff3dfe, 
			'L' => x4dd8a59ec8974a5f.xd0baff30d99dc152, 
			'C' => x4dd8a59ec8974a5f.x102c43569e36d6d1, 
			'Z' => x4dd8a59ec8974a5f.x8ffe90e7fbccfccd, 
			'N' => x4dd8a59ec8974a5f.x9fd888e65466818c, 
			'F' => x4dd8a59ec8974a5f.xaba04beace9e3ba6, 
			'S' => x4dd8a59ec8974a5f.x59157f0bc21022ee, 
			'T' => x4dd8a59ec8974a5f.x350c7c4c4aeebe37, 
			'U' => x4dd8a59ec8974a5f.x8dc4eedb9f218057, 
			'A' => x4dd8a59ec8974a5f.x5fd023604497c8ef, 
			'B' => x4dd8a59ec8974a5f.x26a9b6a08a70bcb9, 
			'W' => x4dd8a59ec8974a5f.x27166c2759dd15ed, 
			'V' => x4dd8a59ec8974a5f.xc6c517e2ed4a7e97, 
			'X' => x4dd8a59ec8974a5f.xb9fb25f53beaeb97, 
			'Y' => x4dd8a59ec8974a5f.xbfb6f7deb7122782, 
			'Q' => x4dd8a59ec8974a5f.xcacbfbb8ebda9581, 
			_ => x4dd8a59ec8974a5f.xf6c17f648b65c793, 
		};
	}

	internal static x4dd8a59ec8974a5f xa3861736e9040b76(char x3c4da2980d043c95)
	{
		switch (char.ToUpper(x3c4da2980d043c95))
		{
		case 'M':
			return x4dd8a59ec8974a5f.x01b2723108ff3dfe;
		case 'H':
		case 'L':
		case 'V':
			return x4dd8a59ec8974a5f.xd0baff30d99dc152;
		case 'C':
		case 'S':
			return x4dd8a59ec8974a5f.x102c43569e36d6d1;
		case 'Q':
		case 'T':
			return x4dd8a59ec8974a5f.xcacbfbb8ebda9581;
		case 'A':
			return x4dd8a59ec8974a5f.x5fd023604497c8ef;
		case 'Z':
			return x4dd8a59ec8974a5f.x8ffe90e7fbccfccd;
		default:
			return x4dd8a59ec8974a5f.xf6c17f648b65c793;
		}
	}

	internal static string x15fdc88864a318d9(x4dd8a59ec8974a5f x80b6be92a9531145)
	{
		switch (x80b6be92a9531145)
		{
		case x4dd8a59ec8974a5f.xf6c17f648b65c793:
		case x4dd8a59ec8974a5f.xd0baff30d99dc152:
			return "L";
		case x4dd8a59ec8974a5f.x102c43569e36d6d1:
			return "C";
		case x4dd8a59ec8974a5f.x01b2723108ff3dfe:
			return "M";
		case x4dd8a59ec8974a5f.x8ffe90e7fbccfccd:
			return "Z";
		case x4dd8a59ec8974a5f.x9fd888e65466818c:
			return "N";
		case x4dd8a59ec8974a5f.x350c7c4c4aeebe37:
			return "T";
		case x4dd8a59ec8974a5f.x8dc4eedb9f218057:
			return "U";
		case x4dd8a59ec8974a5f.x5fd023604497c8ef:
			return "A";
		case x4dd8a59ec8974a5f.x26a9b6a08a70bcb9:
			return "B";
		case x4dd8a59ec8974a5f.x27166c2759dd15ed:
			return "W";
		case x4dd8a59ec8974a5f.xc6c517e2ed4a7e97:
			return "V";
		case x4dd8a59ec8974a5f.xb9fb25f53beaeb97:
			return "X";
		case x4dd8a59ec8974a5f.xbfb6f7deb7122782:
			return "Y";
		case x4dd8a59ec8974a5f.xcacbfbb8ebda9581:
			return "Q";
		case x4dd8a59ec8974a5f.xaba04beace9e3ba6:
			return "F";
		case x4dd8a59ec8974a5f.x59157f0bc21022ee:
			return "S";
		default:
			return "";
		}
	}

	internal static string x50ac76da81079195(x5b865d49b2c8440d xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			x5b865d49b2c8440d.x14db7adc12540124 => "line", 
			x5b865d49b2c8440d.xa98c75da8bd3d4fd => "curve", 
			_ => null, 
		};
	}

	internal static x5b865d49b2c8440d x445ccf57cde58615(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "lines":
		case "line":
			return x5b865d49b2c8440d.x14db7adc12540124;
		case "standard":
			return x5b865d49b2c8440d.x39d30306c4a8866f;
		case "curve":
			return x5b865d49b2c8440d.xa98c75da8bd3d4fd;
		default:
			return x5b865d49b2c8440d.x4d0b9d4447ba7566;
		}
	}

	internal static string x3d92bf97cfbf258c(CellVerticalAlignment xdc46a7254c7770ad, TextOrientation xd1c56470d96cb24c, ParagraphAlignment x6f2204b94f985bf0, bool xfefe3f874ca61d1e)
	{
		switch (xdc46a7254c7770ad)
		{
		case CellVerticalAlignment.Center:
			if (xd1c56470d96cb24c == TextOrientation.Upward)
			{
				switch (x6f2204b94f985bf0)
				{
				case ParagraphAlignment.Left:
					return "bottom";
				case ParagraphAlignment.Right:
					return "top";
				}
			}
			return "middle";
		case CellVerticalAlignment.Bottom:
			if (xd1c56470d96cb24c == TextOrientation.Upward)
			{
				return x6f2204b94f985bf0 switch
				{
					ParagraphAlignment.Right => "top", 
					ParagraphAlignment.Center => "middle", 
					_ => "bottom", 
				};
			}
			if (!xfefe3f874ca61d1e)
			{
				return null;
			}
			return "bottom";
		case CellVerticalAlignment.Top:
			if (xd1c56470d96cb24c == TextOrientation.Upward)
			{
				switch (x6f2204b94f985bf0)
				{
				case ParagraphAlignment.Left:
					return "bottom";
				case ParagraphAlignment.Center:
					return "middle";
				}
			}
			return "top";
		default:
			return null;
		}
	}

	internal static string x2e0e7b4c48ef8f54(bool x916d6a98a11ca50c, ParagraphAlignment xbcea506a33cf9111, TextOrientation xd1c56470d96cb24c, CellVerticalAlignment xdc46a7254c7770ad)
	{
		switch (xbcea506a33cf9111)
		{
		case ParagraphAlignment.Left:
			if (xd1c56470d96cb24c == TextOrientation.Upward)
			{
				switch (xdc46a7254c7770ad)
				{
				case CellVerticalAlignment.Bottom:
					return "right";
				case CellVerticalAlignment.Center:
					return "center";
				}
			}
			if (!x916d6a98a11ca50c)
			{
				return null;
			}
			return "left";
		case ParagraphAlignment.Center:
			if (xd1c56470d96cb24c == TextOrientation.Upward)
			{
				return xdc46a7254c7770ad switch
				{
					CellVerticalAlignment.Bottom => "right", 
					CellVerticalAlignment.Center => "center", 
					_ => null, 
				};
			}
			return "center";
		case ParagraphAlignment.Right:
			if (xd1c56470d96cb24c == TextOrientation.Upward)
			{
				switch (xdc46a7254c7770ad)
				{
				case CellVerticalAlignment.Top:
					return null;
				case CellVerticalAlignment.Center:
					return "center";
				}
			}
			return "right";
		case ParagraphAlignment.Justify:
		case ParagraphAlignment.Distributed:
			return "justify";
		default:
			return null;
		}
	}

	internal static string x8544250546ff6f3b(TextOrientation xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case TextOrientation.Horizontal:
		case TextOrientation.Upward:
			return null;
		case TextOrientation.Downward:
			return "tb-rl";
		case TextOrientation.HorizontalRotatedFarEast:
			return "lr-tb-v";
		case TextOrientation.VerticalFarEast:
			return "tb-rl-v";
		default:
			return "page";
		}
	}

	internal static xf2c5ad4b4d2975c8 x50ae2fd3acc88b8b(ShapeBase x5770cdefd8931aa9, int x710e06940d1179d8)
	{
		xf2c5ad4b4d2975c8 result = new xf2c5ad4b4d2975c8();
		if (!x5770cdefd8931aa9.xf7125312c7ee115c.x263d579af1d0d43f(462))
		{
			return result;
		}
		return (DashStyle)x5770cdefd8931aa9.xf7125312c7ee115c.xf7866f89640a29a3(462) switch
		{
			DashStyle.ShortDash => x0b23f533d73a8a4c("Line_20_Style_20_9", x710e06940d1179d8, "Line Style 9", "1", "197%", null, null, "120%"), 
			DashStyle.ShortDot => x0b23f533d73a8a4c("_32__20_Dots_20_1_20_Dash", x710e06940d1179d8, "2 Dots 1 Dash", "2", null, "1", "0.203cm", "0.203cm"), 
			DashStyle.ShortDashDot => x0b23f533d73a8a4c("Fine_20_Dashed", x710e06940d1179d8, "Fine Dashed", "1", "0.508cm", "1", "0.508cm", "0.508cm"), 
			DashStyle.ShortDashDotDot => x0b23f533d73a8a4c("Ultrafine_20_2_20_Dots_20_3_20_Dashes", x710e06940d1179d8, "Ultrafine 2 Dots 3 Dashes", "2", "0.051cm", "3", "0.254cm", "0.127cm"), 
			DashStyle.Dot => x0b23f533d73a8a4c("Fine_20_Dotted", x710e06940d1179d8, "Fine Dotted", "1", null, null, null, "0.457cm"), 
			DashStyle.Dash => x0b23f533d73a8a4c("Fine_20_Dashed_20__28_var_29_", x710e06940d1179d8, "Fine Dashed (var)", "1", "197%", null, null, "197%"), 
			DashStyle.LongDash => x0b23f533d73a8a4c("Fine_20_Dashed", x710e06940d1179d8, "Fine Dashed", "1", "0.508cm", "1", "0.508cm", "0.508cm"), 
			DashStyle.DashDot => x0b23f533d73a8a4c("Ultrafine_20_2_20_Dots_20_3_20_Dashes", x710e06940d1179d8, "Ultrafine 2 Dots 3 Dashes", "2", "0.051cm", "3", "0.254cm", "0.127cm"), 
			DashStyle.LongDashDot => x0b23f533d73a8a4c("Line_20_with_20_Fine_20_Dots", x710e06940d1179d8, "Line with Fine Dots", "1", "2.007cm", "10", null, "0.057cm"), 
			DashStyle.LongDashDotDot => x0b23f533d73a8a4c("Ultrafine_20_2_20_Dots_20_3_20_Dashes", x710e06940d1179d8, "Ultrafine 2 Dots 3 Dashes", "2", "0.051cm", "3", "0.254cm", "0.127cm"), 
			_ => x0b23f533d73a8a4c("Fine_20_Dotted", x710e06940d1179d8, "Fine Dotted", "1", null, null, null, "0.457cm"), 
		};
	}

	private static xf2c5ad4b4d2975c8 x0b23f533d73a8a4c(string xc15bd84e01929885, int x710e06940d1179d8, string xf0d47d7698b4e263, string xfe0e513c0c3ccab1, string xb155fac1d8e99a84, string x10cf91c2b80c32f2, string x35e102ee7ade09b0, string xf7b90603456caad3)
	{
		xf2c5ad4b4d2975c8 xf2c5ad4b4d2975c9 = new xf2c5ad4b4d2975c8();
		xf2c5ad4b4d2975c9.x759aa16c2016a289 = $"{xc15bd84e01929885}{x710e06940d1179d8}";
		xf2c5ad4b4d2975c9.xba89ca2127612c56 = xf0d47d7698b4e263;
		xf2c5ad4b4d2975c9.xa307ed3e7b388bae = xfe0e513c0c3ccab1;
		xf2c5ad4b4d2975c9.x9303663085079165 = xb155fac1d8e99a84;
		xf2c5ad4b4d2975c9.xa022bd8ca9b57d09 = x10cf91c2b80c32f2;
		xf2c5ad4b4d2975c9.xe92560c39205e82d = x35e102ee7ade09b0;
		xf2c5ad4b4d2975c9.x58316dde3396e982 = xf7b90603456caad3;
		return xf2c5ad4b4d2975c9;
	}

	private static string x6bb3bf1abc7be67f(string xd7e5673853e47af4)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xd7e5673853e47af4))
		{
			return $"{xd7e5673853e47af4} ";
		}
		return "";
	}

	internal static DashStyle x89d821e7a5db0c45(string xb1ed72b81a89125c, xf2c5ad4b4d2975c8 x93050302802dc24a)
	{
		if (xb1ed72b81a89125c == "solid")
		{
			return DashStyle.Solid;
		}
		if (!(xb1ed72b81a89125c == "dash") || x93050302802dc24a == null)
		{
			return DashStyle.Solid;
		}
		switch ($"{x6bb3bf1abc7be67f(x93050302802dc24a.xa307ed3e7b388bae)}{x6bb3bf1abc7be67f(x93050302802dc24a.x9303663085079165)}{x6bb3bf1abc7be67f(x93050302802dc24a.xa022bd8ca9b57d09)}{x6bb3bf1abc7be67f(x93050302802dc24a.xe92560c39205e82d)}{x6bb3bf1abc7be67f(x93050302802dc24a.x58316dde3396e982).Trim()}")
		{
		case "3 5 0.028cm 0.057cm":
			return DashStyle.ShortDashDotDot;
		case "1 0.508cm 1 0.508cm 0.508cm":
			return DashStyle.LongDash;
		case "2 0.051cm 3 0.254cm 0.127cm":
			return DashStyle.ShortDashDotDot;
		case "1 0.457cm":
			return DashStyle.Dot;
		case "1 2.007cm 10 0.057cm":
			return DashStyle.LongDashDot;
		case "1 0.0197cm 0.0197cm":
		case "1 197% 197%":
			return DashStyle.Dash;
		case "3 0.0197cm 3 0.01cm":
		case "3 197% 3 100%":
			return DashStyle.ShortDashDotDot;
		case "1 0.005cm":
		case "1 50%":
			return DashStyle.ShortDot;
		case "1 0.0197cm 0.012cm%":
		case "1 197% 120%":
			return DashStyle.ShortDash;
		case "2 1 0.203cm 0.203cm":
			return DashStyle.ShortDot;
		case "1 0.0197cm 0.0127cm":
		case "1 197% 127%":
			return DashStyle.Dash;
		default:
			return DashStyle.Solid;
		}
	}

	internal static void x48a90babb0267a41(xf871da68decec406 xe134235b3526fa75, string xc1d29e54720eaf38, xf7125312c7ee115c xa5e8b8b5991a4e1d, bool xa59013d234619c58)
	{
		xcb29cf976b7ec398 xcb29cf976b7ec399 = (xcb29cf976b7ec398)xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(xbb857c9fc36f5054.x94045081801bb82d(xc1d29e54720eaf38), (string)null, x0bfe184ad871a4c2: false, xafd04c36a00d5bcf: false);
		if (xcb29cf976b7ec399 != null)
		{
			ArrowType arrowType = ArrowType.Arrow;
			switch ($"{xcb29cf976b7ec399.x8251b2a60565655e}{xcb29cf976b7ec399.x5d593cee9d844848}")
			{
			case "0 0 20 30m10 0-10 30h20z":
			case "0 0 1321 3493m1321 3493h-1321l702-3493z":
			case "0 0 1131 1918m737 1131h394l-564-1131-567 1131h398l-398 787h1131z":
			case "0 0 1013 1130m1009 1050-449-1008-22-30-29-12-34 12-21 26-449 1012-5 13v8l5 21 12 21 17 13 21 4h903l21-4 21-13 9-21 4-21v-8z":
			case "0 0 1131 902m564 0-564 902h1131z":
			case "0 0 1131 2256m1127 2120-449-2006-9-42-25-39-38-25-38-8-43 8-38 25-25 39-9 42-449 2006v13l-4 9 9 42 25 38 38 25 42 9h903l42-9 38-25 26-38 8-42v-9z":
				arrowType = ArrowType.Arrow;
				break;
			case "0 0 10 10m0 0h10v10h-10z":
			case "0 0 1131 1131m0 564 564 567 567-567-567-564z":
				arrowType = ArrowType.Diamond;
				break;
			case "0 0 836 110m0 0h278 278 280v36 36 38h-278-278-280v-36-36z":
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(xa59013d234619c58 ? 467 : 469, ArrowLength.Short);
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(xa59013d234619c58 ? 466 : 468, ArrowWidth.Wide);
				arrowType = ArrowType.Oval;
				break;
			case "0 0 1131 1131m462 1118-102-29-102-51-93-72-72-93-51-102-29-102-13-105 13-102 29-106 51-102 72-89 93-72 102-50 102-34 106-9 101 9 106 34 98 50 93 72 72 89 51 102 29 106 13 102-13 105-29 102-51 102-72 93-93 72-98 51-106 29-101 13z":
				arrowType = ArrowType.Oval;
				break;
			case "0 0 1122 2243m0 2108v17 17l12 42 30 34 38 21 43 4 29-8 30-21 25-26 13-34 343-1532 339 1520 13 42 29 34 39 21 42 4 42-12 34-30 21-42v-39-12l-4 4-440-1998-9-42-25-39-38-25-43-8-42 8-38 25-26 39-8 42z":
				arrowType = ArrowType.Open;
				break;
			case "0 0 1131 1580m1013 1491 118 89-567-1580-564 1580 114-85 136-68 148-46 161-17 161 13 153 46z":
				arrowType = ArrowType.Stealth;
				break;
			}
			xa5e8b8b5991a4e1d.xae20093bed1e48a8(xa59013d234619c58 ? 464 : 465, arrowType);
		}
	}

	internal static string x5730cdebb9d7bbb5(PropertyType x7474ea63400af254)
	{
		switch (x7474ea63400af254)
		{
		case PropertyType.Boolean:
			return "boolean";
		case PropertyType.DateTime:
			return "date";
		case PropertyType.Double:
		case PropertyType.Number:
			return "float";
		default:
			return null;
		}
	}

	internal static xeba92971120d3e5a x420ef5b455ea067b(string xd925f447ef7e00a4, x425eec8888f9cefa xc41398e743370c21)
	{
		switch (xd925f447ef7e00a4)
		{
		case "bitmap":
			return xeba92971120d3e5a.x7f4d496937f8c24c;
		case "gradient":
			return x2a716159180c06f5(xc41398e743370c21);
		case "solid":
		case "hatch":
			return xeba92971120d3e5a.xb8751dec55f64252;
		default:
			return xeba92971120d3e5a.xb8751dec55f64252;
		}
	}

	private static xeba92971120d3e5a x2a716159180c06f5(x425eec8888f9cefa xc41398e743370c21)
	{
		if (xc41398e743370c21 == null)
		{
			return xeba92971120d3e5a.xd4d9335470be4176;
		}
		switch (xc41398e743370c21.xfe2178c1f916f36c)
		{
		case "axial":
		case "linear":
			return xeba92971120d3e5a.x8ee64abc2e3e8f45;
		case "rectangular":
			return xeba92971120d3e5a.xaf29dc5ca8be8da4;
		case "ellipsoid":
		case "radial":
		case "square":
			return xeba92971120d3e5a.xca1af54f5cfd812d;
		default:
			return xeba92971120d3e5a.xd4d9335470be4176;
		}
	}

	internal static string x27aadef0d0b5b322(xeba92971120d3e5a x6f97e5cf19b52dbd)
	{
		switch (x6f97e5cf19b52dbd)
		{
		case xeba92971120d3e5a.x7f4d496937f8c24c:
			return "bitmap";
		case xeba92971120d3e5a.xd4d9335470be4176:
		case xeba92971120d3e5a.xca1af54f5cfd812d:
		case xeba92971120d3e5a.xaf29dc5ca8be8da4:
		case xeba92971120d3e5a.x8ee64abc2e3e8f45:
		case xeba92971120d3e5a.x408710144185f184:
			return "gradient";
		case xeba92971120d3e5a.xb8751dec55f64252:
			return "solid";
		default:
			return null;
		}
	}

	internal static string x1f3ef07dedd13d25(xeba92971120d3e5a x6f97e5cf19b52dbd)
	{
		switch (x6f97e5cf19b52dbd)
		{
		case xeba92971120d3e5a.xd4d9335470be4176:
		case xeba92971120d3e5a.xaf29dc5ca8be8da4:
			return "rectangular";
		case xeba92971120d3e5a.x8ee64abc2e3e8f45:
		case xeba92971120d3e5a.x408710144185f184:
			return "linear";
		case xeba92971120d3e5a.xca1af54f5cfd812d:
			return "square";
		default:
			return null;
		}
	}

	internal static string x718695a87d5257db(FootnoteNumberingRule xf9ef7d1dc6eddfaa)
	{
		if (xf9ef7d1dc6eddfaa == FootnoteNumberingRule.RestartPage)
		{
			return "page";
		}
		return null;
	}

	internal static FootnoteNumberingRule x718695a87d5257db(string xbcea506a33cf9111)
	{
		string text;
		if ((text = xbcea506a33cf9111) != null && text == "page")
		{
			return FootnoteNumberingRule.RestartPage;
		}
		return FootnoteNumberingRule.Continuous;
	}

	internal static string x9b80d04beca7775c(FontFamily x41166b24dc03e8e1)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x72699d9802e89fa9, x41166b24dc03e8e1, "");
	}

	internal static FontFamily x8207f0bf3d84695a(string xbcea506a33cf9111)
	{
		return (FontFamily)x682712679dbc585a.xce92de628aa023cf(xe9262ddc4a1310be, xbcea506a33cf9111, FontFamily.Auto);
	}

	internal static string x385e8e614138cf3e(FontPitch x281d5d7b8df6ec74)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xff3ebdfb873687f6, x281d5d7b8df6ec74, "");
	}

	internal static FontPitch x5c6ebf2ef685c760(string xbcea506a33cf9111)
	{
		return (FontPitch)x682712679dbc585a.xce92de628aa023cf(xe49c14b143611f35, xbcea506a33cf9111, FontPitch.Default);
	}

	internal static FootnoteLocation xe9cb341987ba8dd8(string x5b137ec0f8c48630)
	{
		return (FootnoteLocation)x682712679dbc585a.xce92de628aa023cf(x9f74c36ed6f29ae6, x5b137ec0f8c48630, FootnoteLocation.BottomOfPage);
	}

	internal static string x7ad4832bddeecba4(FootnoteLocation x09ef5d487e2b9f40)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x47b289e6d343959d, x09ef5d487e2b9f40, "");
	}

	internal static string xbdfff93b6ef512cf(WrapType x1b33630b689cfddb, WrapSide xb789d00686698e2a)
	{
		if (x1b33630b689cfddb == WrapType.TopBottom)
		{
			return "none";
		}
		if ((x1b33630b689cfddb == WrapType.None && (xb789d00686698e2a == WrapSide.Both || xb789d00686698e2a == WrapSide.Both)) || x1b33630b689cfddb == WrapType.Through)
		{
			return "run-through";
		}
		switch (xb789d00686698e2a)
		{
		case WrapSide.Left:
			return "left";
		case WrapSide.Right:
			return "right";
		case WrapSide.Largest:
			return "biggest";
		default:
			if (x1b33630b689cfddb == WrapType.Square || x1b33630b689cfddb == WrapType.Tight)
			{
				return "parallel";
			}
			return null;
		}
	}

	internal static WrapType x11d727ed1ffc07fe(string x878956783d1decb2)
	{
		switch (x878956783d1decb2)
		{
		case "parallel":
		case "dynamic":
			return WrapType.Square;
		case "none":
			return WrapType.TopBottom;
		default:
			return WrapType.None;
		}
	}

	internal static WrapSide xc857a84afe54635b(string x878956783d1decb2)
	{
		return x878956783d1decb2 switch
		{
			"left" => WrapSide.Left, 
			"right" => WrapSide.Right, 
			"biggest" => WrapSide.Largest, 
			_ => WrapSide.Both, 
		};
	}

	internal static string x6e755b88613727d8(LineStyle x26516bbd7ae94699)
	{
		switch (x26516bbd7ae94699)
		{
		case LineStyle.Double:
		case LineStyle.ThinThickSmallGap:
		case LineStyle.ThickThinSmallGap:
		case LineStyle.ThinThickThinSmallGap:
		case LineStyle.ThinThickMediumGap:
		case LineStyle.ThickThinMediumGap:
		case LineStyle.ThinThickThinMediumGap:
		case LineStyle.ThinThickLargeGap:
		case LineStyle.ThickThinLargeGap:
		case LineStyle.ThinThickThinLargeGap:
		case LineStyle.DoubleWave:
			return "double";
		case LineStyle.DashLargeGap:
		case LineStyle.DotDash:
		case LineStyle.DotDotDash:
		case LineStyle.DashSmallGap:
			return "dashed";
		case LineStyle.Dot:
			return "dotted";
		case LineStyle.Emboss3D:
			return "groove";
		case LineStyle.Engrave3D:
			return "ridge";
		case LineStyle.Outset:
			return "outset";
		case LineStyle.Inset:
			return "inset";
		case LineStyle.None:
			return "none";
		default:
			return "solid";
		}
	}

	internal static LineStyle xd3fb949f1a59cf0a(string x26516bbd7ae94699)
	{
		return x26516bbd7ae94699 switch
		{
			"dotted" => LineStyle.Dot, 
			"dashed" => LineStyle.DashLargeGap, 
			"double" => LineStyle.Double, 
			"groove" => LineStyle.Emboss3D, 
			"ridge" => LineStyle.Engrave3D, 
			"outset" => LineStyle.Outset, 
			"inset" => LineStyle.Inset, 
			"none" => LineStyle.None, 
			_ => LineStyle.Single, 
		};
	}

	internal static double x196175fd1cffa22a(TextureIndex x29d5ed4aec3de9b7)
	{
		switch (x29d5ed4aec3de9b7)
		{
		case TextureIndex.Texture95Percent:
			return 0.95;
		case TextureIndex.Texture97Pt5Percent:
			return 0.975;
		case TextureIndex.Texture92Pt5Percent:
			return 0.925;
		case TextureIndex.Texture90Percent:
			return 0.9;
		case TextureIndex.Texture87Pt5Percent:
			return 0.875;
		case TextureIndex.Texture85Percent:
			return 0.85;
		case TextureIndex.Texture82Pt5Percent:
			return 0.825;
		case TextureIndex.Texture80Percent:
			return 0.8;
		case TextureIndex.Texture77Pt5Percent:
			return 0.775;
		case TextureIndex.Texture75Percent:
			return 0.75;
		case TextureIndex.Texture72Pt5Percent:
			return 0.725;
		case TextureIndex.Texture70Percent:
			return 0.7;
		case TextureIndex.Texture67Pt5Percent:
			return 0.675;
		case TextureIndex.TextureDarkHorizontal:
		case TextureIndex.TextureDarkVertical:
		case TextureIndex.TextureDarkDiagonalDown:
		case TextureIndex.TextureDarkDiagonalUp:
		case TextureIndex.TextureDarkCross:
		case TextureIndex.TextureDarkDiagonalCross:
		case TextureIndex.TextureHorizontal:
		case TextureIndex.TextureVertical:
		case TextureIndex.TextureDiagonalDown:
		case TextureIndex.TextureDiagonalUp:
		case TextureIndex.TextureCross:
		case TextureIndex.TextureDiagonalCross:
			return 0.33;
		case TextureIndex.Texture65Percent:
			return 0.65;
		case TextureIndex.Texture62Pt5Percent:
			return 0.625;
		case TextureIndex.Texture60Percent:
			return 0.6;
		case TextureIndex.Texture57Pt5Percent:
			return 0.575;
		case TextureIndex.Texture55Percent:
			return 0.55;
		case TextureIndex.Texture52Pt5Percent:
			return 0.525;
		case TextureIndex.Texture50Percent:
			return 0.5;
		case TextureIndex.Texture47Pt5Percent:
			return 0.475;
		case TextureIndex.Texture45Percent:
			return 0.45;
		case TextureIndex.Texture42Pt5Percent:
			return 0.425;
		case TextureIndex.Texture40Percent:
			return 0.4;
		case TextureIndex.Texture37Pt5Percent:
			return 0.375;
		case TextureIndex.Texture35Percent:
			return 0.35;
		case TextureIndex.Texture32Pt5Percent:
			return 0.325;
		case TextureIndex.Texture30Percent:
			return 0.3;
		case TextureIndex.Texture27Pt5Percent:
			return 0.275;
		case TextureIndex.Texture25Percent:
			return 0.25;
		case TextureIndex.Texture22Pt5Percent:
			return 0.225;
		case TextureIndex.Texture20Percent:
			return 0.2;
		case TextureIndex.Texture17Pt5Percent:
			return 0.175;
		case TextureIndex.Texture15Percent:
			return 0.15;
		case TextureIndex.Texture12Pt5Percent:
			return 0.125;
		case TextureIndex.Texture10Percent:
			return 0.1;
		case TextureIndex.Texture7Pt5Percent:
			return 0.075;
		case TextureIndex.Texture5Percent:
			return 0.05;
		case TextureIndex.Texture2Pt5Percent:
			return 0.025;
		case TextureIndex.TextureNone:
		case TextureIndex.TextureNil:
			return 0.0;
		default:
			return 1.0;
		}
	}

	internal static TextOrientation x81274fb3a0882f18(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"tb-rl" => TextOrientation.Downward, 
			"lr-tb-v" => TextOrientation.HorizontalRotatedFarEast, 
			"tb-rl-v" => TextOrientation.VerticalFarEast, 
			_ => TextOrientation.Horizontal, 
		};
	}

	internal static string x56430de7f4e96631(RelativeVerticalPosition xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			RelativeVerticalPosition.Line => "line", 
			RelativeVerticalPosition.Margin => "page-content", 
			RelativeVerticalPosition.Page => "page", 
			_ => "paragraph", 
		};
	}

	internal static RelativeVerticalPosition x4fd9cfbe5f5253d0(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"line" => RelativeVerticalPosition.Line, 
			"page-content" => RelativeVerticalPosition.Margin, 
			"page" => RelativeVerticalPosition.Page, 
			_ => RelativeVerticalPosition.Paragraph, 
		};
	}

	internal static string x95bf6cec5de8cec7(VerticalAlignment xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xb12f6b492f47f35e, xbcea506a33cf9111, "from-top");
	}

	internal static VerticalAlignment xdf0002ad29b56fd1(string xbcea506a33cf9111)
	{
		return (VerticalAlignment)x682712679dbc585a.xce92de628aa023cf(xae1872c5eb9882c8, xbcea506a33cf9111, VerticalAlignment.None);
	}

	internal static string x28c092e469dbab2a(x8fdc64e3f5579ea8 xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x4518183e0cfa3a1e, xbcea506a33cf9111, "");
	}

	internal static x8fdc64e3f5579ea8 x6b9ad249ade432f6(string xbcea506a33cf9111)
	{
		return (x8fdc64e3f5579ea8)x682712679dbc585a.xce92de628aa023cf(xcc4e65f7fc2abde3, xbcea506a33cf9111, x8fdc64e3f5579ea8.x139412b8dea2f02b);
	}

	internal static string xa79e2cf81bd81a75(RelativeHorizontalPosition xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x238eae4ac21bd0fb, xbcea506a33cf9111, "paragraph");
	}

	internal static RelativeHorizontalPosition xc20d2a534e22db7e(string xbcea506a33cf9111)
	{
		return (RelativeHorizontalPosition)x682712679dbc585a.xce92de628aa023cf(x7660b2bbd0607e4f, xbcea506a33cf9111, RelativeHorizontalPosition.Column);
	}

	internal static string x4da6a8cc075fb1bd(HorizontalAlignment xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			HorizontalAlignment.Center => "center", 
			HorizontalAlignment.Inside => "inside", 
			HorizontalAlignment.Left => "left", 
			HorizontalAlignment.Outside => "outside", 
			HorizontalAlignment.Right => "right", 
			_ => null, 
		};
	}

	internal static HorizontalAlignment x17c06b0a2e7f6479(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"center" => HorizontalAlignment.Center, 
			"inside" => HorizontalAlignment.Inside, 
			"left" => HorizontalAlignment.Left, 
			"outside" => HorizontalAlignment.Outside, 
			"right" => HorizontalAlignment.Right, 
			_ => HorizontalAlignment.None, 
		};
	}

	internal static CellVerticalAlignment x28cd796d97d12ba6(string x940641391c2c99d2)
	{
		return x940641391c2c99d2 switch
		{
			"middle" => CellVerticalAlignment.Center, 
			"bottom" => CellVerticalAlignment.Bottom, 
			_ => CellVerticalAlignment.Top, 
		};
	}

	internal static TableAlignment x8047f9bb4019189b(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"right" => TableAlignment.Right, 
			"center" => TableAlignment.Center, 
			_ => TableAlignment.Left, 
		};
	}

	internal static string x06fbbca8012f5070(TableAlignment x2064588236522105)
	{
		return x2064588236522105 switch
		{
			TableAlignment.Center => "center", 
			TableAlignment.Right => "right", 
			_ => "left", 
		};
	}

	internal static string xb17e0945d9acb370(ArrowType x56e30755bce7e00e)
	{
		return x56e30755bce7e00e switch
		{
			ArrowType.Arrow => "Arrow", 
			ArrowType.None => "None", 
			ArrowType.Diamond => "Diamond", 
			ArrowType.Open => "Open", 
			ArrowType.Oval => "Oval", 
			ArrowType.Stealth => "Stealth", 
			_ => null, 
		};
	}

	internal static string x3b70322bc9053ed5(ListLevelAlignment x4ec4022180cbf8f4)
	{
		return x4ec4022180cbf8f4 switch
		{
			ListLevelAlignment.Left => "start", 
			ListLevelAlignment.Right => "end", 
			ListLevelAlignment.Center => "center", 
			_ => null, 
		};
	}

	internal static ListLevelAlignment x7c024e58d824fd53(string xe4f97a5cc9204c1f)
	{
		switch (xe4f97a5cc9204c1f)
		{
		case "center":
			return ListLevelAlignment.Center;
		case "end":
		case "right":
			return ListLevelAlignment.Right;
		default:
			return ListLevelAlignment.Left;
		}
	}

	internal static string xbc2e1c29972a40ee(NumberStyle x3f5f7cef69e188c0)
	{
		switch (x3f5f7cef69e188c0)
		{
		case NumberStyle.Arabic:
		case NumberStyle.Number:
			return "1";
		case NumberStyle.UppercaseRoman:
			return "I";
		case NumberStyle.LowercaseRoman:
			return "i";
		case NumberStyle.UppercaseLetter:
			return "A";
		case NumberStyle.LowercaseLetter:
			return "a";
		default:
			return null;
		}
	}

	internal static NumberStyle xf82235a3d3bbad96(string x462e8a703d817fb4)
	{
		return x462e8a703d817fb4 switch
		{
			"I" => NumberStyle.UppercaseRoman, 
			"i" => NumberStyle.LowercaseRoman, 
			"A" => NumberStyle.UppercaseLetter, 
			"a" => NumberStyle.LowercaseLetter, 
			"1" => NumberStyle.Arabic, 
			_ => NumberStyle.None, 
		};
	}

	internal static string x0977d00ea3519faa(TabAlignment xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			TabAlignment.Center => "center", 
			TabAlignment.Right => "right", 
			TabAlignment.Left => "left", 
			TabAlignment.Decimal => "char", 
			_ => null, 
		};
	}

	internal static TabAlignment x5d40204c804ea9f9(string x43163d22e8cd5a71, string x01d1693fa395ce60)
	{
		return x43163d22e8cd5a71 switch
		{
			"center" => TabAlignment.Center, 
			"right" => TabAlignment.Right, 
			"char" => TabAlignment.Decimal, 
			_ => TabAlignment.Left, 
		};
	}

	internal static TabLeader xe171049fef4b8423(string x7c7e4805a3a4ed55, string xb40a54c2fe6d2690)
	{
		if (xb40a54c2fe6d2690.Length > 0)
		{
			switch (xb40a54c2fe6d2690)
			{
			case "-":
				return TabLeader.Dashes;
			case ".":
				return TabLeader.Dots;
			case "_":
				return TabLeader.Line;
			}
		}
		switch (x7c7e4805a3a4ed55)
		{
		case "solid":
		case "wave":
			return TabLeader.Line;
		case "dotted":
			return TabLeader.Dots;
		case "dash":
		case "long-dash":
		case "dot-dash":
		case "dot-dot-dash":
			return TabLeader.Dashes;
		default:
			return TabLeader.None;
		}
	}

	internal static string xea82020d7562fd79(TabLeader xb6842aa1e60562e1)
	{
		switch (xb6842aa1e60562e1)
		{
		case TabLeader.Dashes:
			return "-";
		case TabLeader.Dots:
		case TabLeader.MiddleDot:
			return ".";
		case TabLeader.Line:
		case TabLeader.Heavy:
			return "_";
		default:
			return null;
		}
	}

	internal static string xa75e7f72ded19fa7(TabLeader xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case TabLeader.Dashes:
			return "dash";
		case TabLeader.Dots:
		case TabLeader.MiddleDot:
			return "dotted";
		case TabLeader.Line:
		case TabLeader.Heavy:
			return "solid";
		case TabLeader.None:
			return "none";
		default:
			return null;
		}
	}

	internal static ParagraphAlignment x7105f40ee7ec74ce(string xe4f97a5cc9204c1f, bool x4d21032b3ed37672)
	{
		switch (xe4f97a5cc9204c1f)
		{
		case "end":
		case "right":
			return ParagraphAlignment.Right;
		case "center":
			return ParagraphAlignment.Center;
		case "justify":
			return ParagraphAlignment.Justify;
		default:
			return ParagraphAlignment.Left;
		}
	}

	internal static string x1e349416132705da(Underline xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case Underline.Thick:
			return "thick";
		case Underline.DottedHeavy:
		case Underline.DashHeavy:
		case Underline.DotDashHeavy:
		case Underline.DotDotDashHeavy:
		case Underline.WavyHeavy:
		case Underline.DashLongHeavy:
			return "bold";
		default:
			return null;
		}
	}

	internal static string x79c50c33f461abd6(Underline xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case Underline.Dash:
		case Underline.DashHeavy:
			return "dash";
		case Underline.DashLong:
		case Underline.DashLongHeavy:
			return "long-dash";
		case Underline.DotDash:
		case Underline.DotDashHeavy:
			return "dot-dash";
		case Underline.DotDotDash:
		case Underline.DotDotDashHeavy:
			return "dot-dot-dash";
		case Underline.Dotted:
		case Underline.DottedHeavy:
			return "dotted";
		case Underline.Wavy:
		case Underline.WavyHeavy:
		case Underline.WavyDouble:
			return "wave";
		case Underline.Single:
		case Underline.Words:
		case Underline.Double:
		case Underline.Thick:
			return "solid";
		case Underline.None:
			return "none";
		default:
			return null;
		}
	}

	internal static Underline x57328579aa0dc5af(string x54c0df94402ddf13, string xeeec64767063576c, string xc1721fbce11d029e, string x5be89112f1b625bc)
	{
		bool flag = xeeec64767063576c == "bold";
		switch (x54c0df94402ddf13)
		{
		case "dash":
			if (!flag)
			{
				return Underline.Dash;
			}
			return Underline.DashHeavy;
		case "long-dash":
			if (!flag)
			{
				return Underline.DashLong;
			}
			return Underline.DashLongHeavy;
		case "dot-dash":
			if (!flag)
			{
				return Underline.DotDash;
			}
			return Underline.DotDashHeavy;
		case "dot-dot-dash":
			if (!flag)
			{
				return Underline.DotDotDash;
			}
			return Underline.DotDotDashHeavy;
		case "dotted":
			if (!flag)
			{
				return Underline.Dotted;
			}
			return Underline.DottedHeavy;
		case "wave":
			if (flag)
			{
				return Underline.WavyHeavy;
			}
			if (!(x5be89112f1b625bc == "double"))
			{
				return Underline.Wavy;
			}
			return Underline.WavyDouble;
		default:
			if (xc1721fbce11d029e == "skip-white-space")
			{
				return Underline.Words;
			}
			if (xeeec64767063576c == "thick")
			{
				return Underline.Thick;
			}
			if (x5be89112f1b625bc == "double")
			{
				return Underline.Double;
			}
			if (x54c0df94402ddf13 == "solid" || x5be89112f1b625bc == "single")
			{
				return Underline.Single;
			}
			return Underline.None;
		}
	}

	internal static string xa6f21184281b3f5a(TextOrientation xf65758d54b79fc7a)
	{
		return xf65758d54b79fc7a switch
		{
			TextOrientation.HorizontalRotatedFarEast => "0", 
			TextOrientation.Upward => "90", 
			TextOrientation.VerticalFarEast => "270", 
			_ => null, 
		};
	}

	internal static TextOrientation x9d37a8a506e662b7(string xbcea506a33cf9111)
	{
		int num = xca004f56614e2431.xa93402510be8434e(xbcea506a33cf9111) % 360;
		if ((num >= 315 && num < 360) || (num >= 0 && num < 45))
		{
			return TextOrientation.HorizontalRotatedFarEast;
		}
		if (num >= 45 && num < 135)
		{
			return TextOrientation.Upward;
		}
		if (num >= 135 && num < 315)
		{
			return TextOrientation.VerticalFarEast;
		}
		return TextOrientation.Horizontal;
	}

	internal static string x7df5568a93d9f858(string x2eebe5b22e29f252, int xb53acfe332ad6e91)
	{
		int num = 0;
		for (int i = 0; i <= xb53acfe332ad6e91; i++)
		{
			num = x2eebe5b22e29f252.IndexOf((char)i);
			if (num != -1)
			{
				break;
			}
		}
		if (num != -1)
		{
			return x2eebe5b22e29f252.Substring(0, num);
		}
		return null;
	}

	internal static string x69cc6ab89d735dcd(string x2eebe5b22e29f252, int xb53acfe332ad6e91)
	{
		int num = x2eebe5b22e29f252.IndexOf((char)xb53acfe332ad6e91);
		if (num != -1 && num < x2eebe5b22e29f252.Length - 1)
		{
			return x2eebe5b22e29f252.Substring(num + 1);
		}
		return null;
	}

	internal static string xb7771d27b3454277(string x2eebe5b22e29f252, int xb53acfe332ad6e91)
	{
		int num = xb53acfe332ad6e91 + 1;
		for (int i = 0; i < xb53acfe332ad6e91; i++)
		{
			if (x2eebe5b22e29f252.IndexOf((char)i) == -1)
			{
				num--;
			}
		}
		if (num != 1)
		{
			return num.ToString();
		}
		return null;
	}

	internal static string x8971368560588cfd(x7af53bbecc5ccdd5 xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x1f2e520ce6648ad0, xbcea506a33cf9111, "");
	}

	internal static x7af53bbecc5ccdd5 xc4b75e84c6310a3b(string xbcea506a33cf9111)
	{
		return (x7af53bbecc5ccdd5)x682712679dbc585a.xce92de628aa023cf(x276c2db3eb504e56, xbcea506a33cf9111, "");
	}

	internal static string xd70034c69864bb0b(StyleType xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xdd1c5b917fe6db60, xbcea506a33cf9111, "paragraph");
	}

	internal static string xb19294b14e3c8598(Style x44ecfea61c937b8e)
	{
		if (x44ecfea61c937b8e == null)
		{
			return "No_20_List";
		}
		string text = x72a0c846678ecaf9.x27d6a5b617edc9db(x44ecfea61c937b8e.StyleIdentifier, "");
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			string xe4115acdf4fbfccc = (string)x682712679dbc585a.xce92de628aa023cf(x3f0c300c9b8f8c84, text, text);
			xe4115acdf4fbfccc = xb7dbd7bb3ed97d5b.x0994f10b8582d748(xe4115acdf4fbfccc);
			return xb2042383d3c7e76b(xe4115acdf4fbfccc, x44ecfea61c937b8e.StyleIdentifier);
		}
		if (x44ecfea61c937b8e.StyleIdentifier == StyleIdentifier.User && !x0d299f323d241756.x5959bccb67bbf051(x44ecfea61c937b8e.Name))
		{
			x44ecfea61c937b8e.x2b8399f052630a13($"UnnamedUserStyle{x44ecfea61c937b8e.x8301ab10c226b0c2}");
		}
		return xb2042383d3c7e76b(x44ecfea61c937b8e.Name, x44ecfea61c937b8e.StyleIdentifier);
	}

	private static string xb2042383d3c7e76b(string xbcea506a33cf9111, StyleIdentifier xa3be2ccad541ab25)
	{
		string xbcea506a33cf9112 = (string)x682712679dbc585a.xce92de628aa023cf(x6ed3560115064f44, xbcea506a33cf9111, xbcea506a33cf9111);
		StyleIdentifier styleIdentifier = x72a0c846678ecaf9.x3b3cea4656a2e16d(xbcea506a33cf9112);
		if (xa3be2ccad541ab25 == StyleIdentifier.User && styleIdentifier != StyleIdentifier.User)
		{
			xbcea506a33cf9111 = string.Format("{0}{1}", xbcea506a33cf9111, " (user)");
		}
		return xbb857c9fc36f5054.x127fca996f5c76e4(xbcea506a33cf9111);
	}

	internal static string x5915b82b40b273fd(string xb1f85df14abb5acc)
	{
		xb1f85df14abb5acc = xbb857c9fc36f5054.x94045081801bb82d(xb1f85df14abb5acc);
		return (string)x682712679dbc585a.xce92de628aa023cf(x6ed3560115064f44, xb1f85df14abb5acc, xb1f85df14abb5acc);
	}

	internal static string xef1c76b0fb2ec874(int x2f387d3a0ec23109)
	{
		string text = (string)x682712679dbc585a.xce92de628aa023cf(x9505b0ae46363b0c, (x448900fcb384c333)x2f387d3a0ec23109, "");
		if (text == "")
		{
			return xf2a0216b53787578.xd16e1d14e9bd81a9(x2f387d3a0ec23109, x5fbb1a9c98604ef5: true);
		}
		return text;
	}

	internal static int x1fd658c8428b3dd6(string x00018b81fe0ed5a2)
	{
		int num = (int)x682712679dbc585a.xce92de628aa023cf(x462a070e16afbac5, x00018b81fe0ed5a2, -1);
		if (num == -1)
		{
			return xf2a0216b53787578.xae88295ea6bfc819(x00018b81fe0ed5a2, x5fbb1a9c98604ef5: true);
		}
		return num;
	}

	internal static string x1bbc7ba55bd9fa0f(string x5856e76074a9d333)
	{
		return xfd72587da58f658b(x5856e76074a9d333, 0);
	}

	internal static string xc400beacdb7f0a74(string x5856e76074a9d333)
	{
		return xfd72587da58f658b(x5856e76074a9d333, 1);
	}

	private static string xfd72587da58f658b(string x5856e76074a9d333, int x4bd8b74a22f4705c)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(x5856e76074a9d333))
		{
			return null;
		}
		string[] array = x5856e76074a9d333.Split('-');
		if (array.Length != 2)
		{
			return null;
		}
		return array[x4bd8b74a22f4705c];
	}

	internal static string xf7e611d1d8ca4bb2(Orientation xf65758d54b79fc7a)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x5ab2d2c9eba4d278, xf65758d54b79fc7a, "portrait");
	}

	internal static Orientation xb1914e9373851c18(string xbcea506a33cf9111)
	{
		return (Orientation)x682712679dbc585a.xce92de628aa023cf(x4480d5dbde174156, xbcea506a33cf9111, Orientation.Portrait);
	}

	static x0eb9a864413f34de()
	{
		x462a070e16afbac5 = new Hashtable();
		x9505b0ae46363b0c = new Hashtable();
		x73b371e817d6608f = new Hashtable();
		xdd1c5b917fe6db60 = new Hashtable();
		x6ed3560115064f44 = new Hashtable();
		x3f0c300c9b8f8c84 = new Hashtable();
		x276c2db3eb504e56 = new Hashtable();
		x1f2e520ce6648ad0 = new Hashtable();
		x9f74c36ed6f29ae6 = new Hashtable();
		x47b289e6d343959d = new Hashtable();
		xe9262ddc4a1310be = new Hashtable();
		x72699d9802e89fa9 = new Hashtable();
		xe49c14b143611f35 = new Hashtable();
		xff3ebdfb873687f6 = new Hashtable();
		xae1872c5eb9882c8 = new Hashtable();
		xb12f6b492f47f35e = new Hashtable();
		xcc4e65f7fc2abde3 = new Hashtable();
		x4518183e0cfa3a1e = new Hashtable();
		x4480d5dbde174156 = new Hashtable();
		x5ab2d2c9eba4d278 = new Hashtable();
		x7660b2bbd0607e4f = new Hashtable();
		x238eae4ac21bd0fb = new Hashtable();
		x0d20435df4854d97 = new Hashtable();
		x93b88c04601ba258 = new Hashtable();
		x841efd55c5138168 = new Hashtable();
		x885779ab5535d24e = new Hashtable();
		x682712679dbc585a.x70fa1602ceccddee(new object[4]
		{
			"char",
			RelativeHorizontalPosition.Character,
			"page",
			RelativeHorizontalPosition.Page
		}, x7660b2bbd0607e4f, x238eae4ac21bd0fb);
		x682712679dbc585a.x70fa1602ceccddee(new object[4]
		{
			"portrait",
			Orientation.Portrait,
			"landscape",
			Orientation.Landscape
		}, x4480d5dbde174156, x5ab2d2c9eba4d278);
		x682712679dbc585a.x70fa1602ceccddee(new object[8]
		{
			"bottom",
			x8fdc64e3f5579ea8.x9bcb07e204e30218,
			"middle",
			x8fdc64e3f5579ea8.x58d2ccae3c5cfd08,
			"top",
			x8fdc64e3f5579ea8.xe360b1885d8d4a41,
			"auto",
			x8fdc64e3f5579ea8.x2bca50d746ec73b2
		}, xcc4e65f7fc2abde3, x4518183e0cfa3a1e);
		x682712679dbc585a.x70fa1602ceccddee(new object[8]
		{
			"bottom",
			VerticalAlignment.Bottom,
			"middle",
			VerticalAlignment.Center,
			"top",
			VerticalAlignment.Top,
			"from-top",
			VerticalAlignment.Inline
		}, xae1872c5eb9882c8, xb12f6b492f47f35e);
		x682712679dbc585a.x70fa1602ceccddee(new object[4]
		{
			"fixed",
			FontPitch.Fixed,
			"variable",
			FontPitch.Variable
		}, xe49c14b143611f35, xff3ebdfb873687f6);
		x682712679dbc585a.x70fa1602ceccddee(new object[12]
		{
			"",
			FontFamily.Auto,
			"roman",
			FontFamily.Roman,
			"swiss",
			FontFamily.Swiss,
			"modern",
			FontFamily.Modern,
			"script",
			FontFamily.Script,
			"decorative",
			FontFamily.Decorative
		}, xe9262ddc4a1310be, x72699d9802e89fa9);
		x682712679dbc585a.x70fa1602ceccddee(new object[8]
		{
			"text",
			FootnoteLocation.BeneathText,
			"page",
			FootnoteLocation.BottomOfPage,
			"section",
			FootnoteLocation.EndOfSection,
			"document",
			FootnoteLocation.EndOfDocument
		}, x9f74c36ed6f29ae6, x47b289e6d343959d);
		x682712679dbc585a.x70fa1602ceccddee(new object[6]
		{
			"",
			x7af53bbecc5ccdd5.x139412b8dea2f02b,
			"super 58%",
			x7af53bbecc5ccdd5.xab66d68facbadf18,
			"sub 58%",
			x7af53bbecc5ccdd5.x1b1f4712a1a0c38c
		}, x276c2db3eb504e56, x1f2e520ce6648ad0);
		x682712679dbc585a.x70fa1602ceccddee(new object[12]
		{
			"az-cyrillic",
			x448900fcb384c333.x0e9d40be1e19512c,
			"az-AZ",
			x448900fcb384c333.x160bd5213291c2a8,
			"iu-CA",
			x448900fcb384c333.x16a43d3b4662ac42,
			"om-ET",
			x448900fcb384c333.xf0121605a1d3cdfa,
			"tg-TJ",
			x448900fcb384c333.x63c5b6a4aba73d9a,
			"none",
			x448900fcb384c333.xe6e1e754fb8e4ea0
		}, x462a070e16afbac5, x9505b0ae46363b0c);
		x682712679dbc585a.x70fa1602ceccddee(new object[4]
		{
			"paragraph",
			StyleType.Paragraph,
			"text",
			StyleType.Character
		}, x73b371e817d6608f, xdd1c5b917fe6db60);
		x682712679dbc585a.x70fa1602ceccddee(new object[36]
		{
			"Heading 1", "heading 1", "Heading 2", "heading 2", "Heading 3", "heading 3", "Heading 4", "heading 4", "Heading 5", "heading 5",
			"Heading 6", "heading 6", "Heading 7", "heading 7", "Heading 8", "heading 8", "Heading 9", "heading 9", "Caption", "caption",
			"Footer", "footer", "Header", "header", "Standard", "Normal", "Internet link", "Hyperlink", "Endnote text", "endnote text",
			"Footnote text", "footnote text", "Endnote reference", "endnote reference", "Footnote reference", "footnote reference"
		}, x6ed3560115064f44, x3f0c300c9b8f8c84);
		x682712679dbc585a.x70fa1602ceccddee(new object[18]
		{
			"1",
			OutlineLevel.Level1,
			"2",
			OutlineLevel.Level2,
			"3",
			OutlineLevel.Level3,
			"4",
			OutlineLevel.Level4,
			"5",
			OutlineLevel.Level5,
			"6",
			OutlineLevel.Level6,
			"7",
			OutlineLevel.Level7,
			"8",
			OutlineLevel.Level8,
			"9",
			OutlineLevel.Level9
		}, x0d20435df4854d97, x93b88c04601ba258);
		x682712679dbc585a.x70fa1602ceccddee(new object[8]
		{
			"",
			x3b504d8c866583dc.x1a23317d325de634,
			"none",
			x3b504d8c866583dc.x4d0b9d4447ba7566,
			"segments",
			x3b504d8c866583dc.xdb6e255971c32d6d,
			"rectangle",
			x3b504d8c866583dc.xa07a9457a2ebbbfc
		}, x841efd55c5138168, x885779ab5535d24e);
	}
}
