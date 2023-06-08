using System;
using System.Collections;
using System.Text;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Settings;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xe5b37aee2c2a4d4e;

namespace x556d8f9846e43329;

internal class xa0d3611565b2a1f2
{
	private const double xe320320478815ddf = 2.5483870967741935;

	private const int xb3a6011872a8c2e7 = 63;

	private const int xffe3321fcbf6f6d2 = 5;

	private static readonly Hashtable x6eaf1ef0b18e67bf;

	private static readonly Hashtable x1fd54e86e256e2d3;

	private static readonly Hashtable xa463823fa2f10aad;

	private static readonly Hashtable x2a2693c0ce51df97;

	private static readonly Hashtable x8551ff9860b3b27c;

	private static readonly Hashtable x1666770923f021d3;

	private static readonly Hashtable x100687b29b66a97c;

	private static readonly Hashtable x46bfe8ebb3e8fb5a;

	private static readonly Hashtable xf7f3144718bf752f;

	private static readonly Hashtable x0ae36a259ef6ad7f;

	private static readonly Hashtable x8d426cf4c8659770;

	private static readonly Hashtable xf15f17de0097c9fc;

	private static readonly int[] xf558ca32aa48d36d;

	internal static int x030d4b7389328010(double xbcea506a33cf9111)
	{
		return (int)(xbcea506a33cf9111 * 10000.0);
	}

	internal static double xdec88a161e1f1f99(int xbcea506a33cf9111)
	{
		return (double)xbcea506a33cf9111 / 10000.0;
	}

	internal static double x401ef6809c021333(int xbcea506a33cf9111)
	{
		return x4574ea26106f0edb.x0e1fdb362561ddb2(xbcea506a33cf9111) * 4.0;
	}

	internal static int xcaea8b7a31c4f21f(double xbcea506a33cf9111)
	{
		return x4574ea26106f0edb.x88bf16f2386d633e(xbcea506a33cf9111 / 4.0);
	}

	internal static int x7c734cfcbb14646a(DateTime xb21f13a9707ad954)
	{
		int num = 0;
		num |= xb21f13a9707ad954.Minute;
		num |= xb21f13a9707ad954.Hour << 6;
		num |= xb21f13a9707ad954.Day << 11;
		num |= xb21f13a9707ad954.Month << 16;
		num |= xb21f13a9707ad954.Year - 1900 << 20;
		return num | (x9d32fb9248fc1a77(xb21f13a9707ad954.DayOfWeek) << 29);
	}

	internal static string x3c860eff373e6d44(x84d41ac121232475 xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x1fd54e86e256e2d3, xbcea506a33cf9111, "");
	}

	internal static x84d41ac121232475 xbe670088e64558c9(string xbcea506a33cf9111)
	{
		return (x84d41ac121232475)x682712679dbc585a.xce92de628aa023cf(x6eaf1ef0b18e67bf, xbcea506a33cf9111, x84d41ac121232475.x4d0b9d4447ba7566);
	}

	internal static string x84a6010bcc93313a(x55477ca1c0c8419f x4ec4022180cbf8f4, x932d11b236987c0e xac1376d78e61506e)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("\\p");
		stringBuilder.Append((xac1376d78e61506e == x932d11b236987c0e.x941a43d4a5637fd0) ? "ind" : "mar");
		switch (x4ec4022180cbf8f4)
		{
		case x55477ca1c0c8419f.x58d2ccae3c5cfd08:
			stringBuilder.Append("tabqc");
			break;
		case x55477ca1c0c8419f.x419ba17a5322627b:
			stringBuilder.Append("tabqr");
			break;
		default:
			stringBuilder.Append("tabql");
			break;
		}
		return stringBuilder.ToString();
	}

	internal static x55477ca1c0c8419f x1cbe436dac074235(string xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111.Length < 5)
		{
			return x55477ca1c0c8419f.x72d92bd1aff02e37;
		}
		return xbcea506a33cf9111.Substring(5, xbcea506a33cf9111.Length - 5) switch
		{
			"tabqr" => x55477ca1c0c8419f.x419ba17a5322627b, 
			"tabqc" => x55477ca1c0c8419f.x58d2ccae3c5cfd08, 
			"tabql" => x55477ca1c0c8419f.x72d92bd1aff02e37, 
			_ => x55477ca1c0c8419f.x72d92bd1aff02e37, 
		};
	}

	internal static x932d11b236987c0e x4444feaf6a1a4708(string xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111.Length < 5)
		{
			return x932d11b236987c0e.x941a43d4a5637fd0;
		}
		return xbcea506a33cf9111.Substring(0, 5) switch
		{
			"\\pmar" => x932d11b236987c0e.x6545d1f2c1b77773, 
			"\\pind" => x932d11b236987c0e.x941a43d4a5637fd0, 
			_ => x932d11b236987c0e.x941a43d4a5637fd0, 
		};
	}

	internal static DateTime x9a175459d1b055a7(int x5503fb2de329071a)
	{
		if (x5503fb2de329071a == 0)
		{
			return DateTime.MinValue;
		}
		int xd088075e67f6ea = x5503fb2de329071a & 0x3F;
		int xcc7a3b596222b08a = (x5503fb2de329071a >> 6) & 0x1F;
		int x36ccf2254f62ef4e = (x5503fb2de329071a >> 11) & 0x1F;
		int xea415cd5a0d = (x5503fb2de329071a >> 16) & 0xF;
		int x47418672747a = ((x5503fb2de329071a >> 20) & 0x1FF) + 1900;
		return x7546e38fbb25d738.xfde53ea35dfda4e6(x47418672747a, xea415cd5a0d, x36ccf2254f62ef4e, xcc7a3b596222b08a, xd088075e67f6ea, 0, 0);
	}

	internal static double x61f4dd4997f9c927(int xf6495da3f9ed2d9c)
	{
		return (double)xf6495da3f9ed2d9c / 2.5483870967741935;
	}

	internal static int xdf0828e8d289b651(double x2f7096dac971d6ec)
	{
		return (int)(x2f7096dac971d6ec * 2.5483870967741935);
	}

	internal static LineStyle x0ea0020e26ffd130(int xc0c4c459c6ccbd00)
	{
		return (LineStyle)(xc0c4c459c6ccbd00 + 63);
	}

	internal static int xf89753ddd8c66e66(LineStyle x26516bbd7ae94699)
	{
		return (int)(x26516bbd7ae94699 - 63);
	}

	internal static int[] x339a4889e0bd1111(x1a78664fa10a3755 x062aae8c9613eeaa, bool xbcea506a33cf9111)
	{
		int[] array = new int[xf558ca32aa48d36d.Length];
		for (int i = 0; i < xf558ca32aa48d36d.Length; i++)
		{
			int num = xf558ca32aa48d36d[i];
			if (!x062aae8c9613eeaa.xbc5dc59d0d9b620d(num))
			{
				array[i] = num;
				x062aae8c9613eeaa.xae20093bed1e48a8(num, xbcea506a33cf9111);
			}
		}
		return array;
	}

	internal static void x60367ca2e6e44bc3(x1a78664fa10a3755 x062aae8c9613eeaa, int[] xc107b75a85428bd6)
	{
		foreach (int xba08ce632055a1d in xc107b75a85428bd6)
		{
			x062aae8c9613eeaa.x52b190e626f65140(xba08ce632055a1d);
		}
	}

	internal static WrapType xed75ef2aa99e76d3(string xbcea506a33cf9111)
	{
		return (WrapType)x682712679dbc585a.xce92de628aa023cf(xa463823fa2f10aad, xbcea506a33cf9111);
	}

	internal static string xa1827014a0d63ae0(WrapType xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x2a2693c0ce51df97, xbcea506a33cf9111, WrapType.Inline);
	}

	internal static MailMergeMainDocumentType x8cf97090ad1be525(string xbcea506a33cf9111)
	{
		return (MailMergeMainDocumentType)x682712679dbc585a.xce92de628aa023cf(x100687b29b66a97c, xbcea506a33cf9111, MailMergeMainDocumentType.NotAMergeDocument);
	}

	internal static string x7f4b7a05bb406cd0(MailMergeMainDocumentType xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x46bfe8ebb3e8fb5a, xbcea506a33cf9111);
	}

	internal static MailMergeDataType xc8f95ea6619cc2d3(string xbcea506a33cf9111)
	{
		return (MailMergeDataType)x682712679dbc585a.xce92de628aa023cf(xf7f3144718bf752f, xbcea506a33cf9111, MailMergeDataType.None);
	}

	internal static string xe2ca4248b7e5af14(MailMergeDataType xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x0ae36a259ef6ad7f, xbcea506a33cf9111);
	}

	internal static MailMergeDestination x72be8363c5b507b9(string xbcea506a33cf9111)
	{
		return (MailMergeDestination)x682712679dbc585a.xce92de628aa023cf(x8d426cf4c8659770, xbcea506a33cf9111, MailMergeDestination.NewDocument);
	}

	internal static string xf80f9be050516dd4(MailMergeDestination xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xf15f17de0097c9fc, xbcea506a33cf9111);
	}

	internal static OdsoFieldMappingType x2e9471c187353611(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"\\mmfttypenull" => OdsoFieldMappingType.Null, 
			"\\mmfttypedbcolumn" => OdsoFieldMappingType.Column, 
			_ => OdsoFieldMappingType.Null, 
		};
	}

	internal static string x2db1376f2c5d1640(OdsoFieldMappingType xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			OdsoFieldMappingType.Column => "\\mmfttypedbcolumn", 
			_ => "\\mmfttypenull", 
		};
	}

	internal static x3e68720d12325f49 xa11a1d33b2fc22c2(string xbcea506a33cf9111)
	{
		return (x3e68720d12325f49)x682712679dbc585a.xce92de628aa023cf(x8551ff9860b3b27c, xbcea506a33cf9111, x3e68720d12325f49.x977976895b35c83c);
	}

	internal static string xc69659406175c811(xb474f98b96852a6e xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 == xb474f98b96852a6e.xe360b1885d8d4a41)
		{
			return "top";
		}
		return "bot";
	}

	internal static xb474f98b96852a6e xb44d60c6a50cc790(string xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 == "top")
		{
			return xb474f98b96852a6e.xe360b1885d8d4a41;
		}
		return xb474f98b96852a6e.x9bcb07e204e30218;
	}

	private static int x9d32fb9248fc1a77(DayOfWeek x8f0ad343d6248afc)
	{
		return x8f0ad343d6248afc switch
		{
			DayOfWeek.Sunday => 0, 
			DayOfWeek.Monday => 1, 
			DayOfWeek.Tuesday => 2, 
			DayOfWeek.Wednesday => 3, 
			DayOfWeek.Thursday => 4, 
			DayOfWeek.Friday => 5, 
			DayOfWeek.Saturday => 6, 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("clfgimmgcmdhcmkhambifmiijlpiiggjjknjdkekillkmfclikjlmjamdfhmhkomcjfnpimncjdocfko", 883647837))), 
		};
	}

	static xa0d3611565b2a1f2()
	{
		x6eaf1ef0b18e67bf = new Hashtable();
		x1fd54e86e256e2d3 = new Hashtable();
		xa463823fa2f10aad = new Hashtable();
		x2a2693c0ce51df97 = new Hashtable();
		x8551ff9860b3b27c = new Hashtable();
		x1666770923f021d3 = new Hashtable();
		x100687b29b66a97c = new Hashtable();
		x46bfe8ebb3e8fb5a = new Hashtable();
		xf7f3144718bf752f = new Hashtable();
		x0ae36a259ef6ad7f = new Hashtable();
		x8d426cf4c8659770 = new Hashtable();
		xf15f17de0097c9fc = new Hashtable();
		xf558ca32aa48d36d = new int[3] { 1240, 1250, 1270 };
		x682712679dbc585a.x70fa1602ceccddee(new object[10]
		{
			"\\ptabldot",
			x84d41ac121232475.x3cb6807e93737c2d,
			"\\ptablminus",
			x84d41ac121232475.x8e836880cbe4ad3d,
			"\\ptablmdot",
			x84d41ac121232475.xf15c6e29f02316fc,
			"\\ptablnone",
			x84d41ac121232475.x4d0b9d4447ba7566,
			"\\ptabluscore",
			x84d41ac121232475.x05249333ba886290
		}, x6eaf1ef0b18e67bf, x1fd54e86e256e2d3);
		x682712679dbc585a.x70fa1602ceccddee(new object[12]
		{
			"\\nowrap",
			WrapType.TopBottom,
			"\\overlay",
			WrapType.None,
			"\\wrapdefault",
			WrapType.Inline,
			"\\wraparound",
			WrapType.Square,
			"\\wraptight",
			WrapType.Tight,
			"\\wrapthrough",
			WrapType.Through
		}, xa463823fa2f10aad, x2a2693c0ce51df97);
		x682712679dbc585a.x70fa1602ceccddee(new object[16]
		{
			"\\mdeg",
			x3e68720d12325f49.x2b691ff28e877ea4,
			"\\mden",
			x3e68720d12325f49.x194cb0ccf5358fec,
			"\\me",
			x3e68720d12325f49.x1745ba6c6d5efbc4,
			"\\mlim",
			x3e68720d12325f49.x25d26846c330b189,
			"\\mfName",
			x3e68720d12325f49.x8c55fc884c93cb9f,
			"\\mnum",
			x3e68720d12325f49.x5ec114ef0df8072b,
			"\\msub",
			x3e68720d12325f49.x06b102f48629e32f,
			"\\msup",
			x3e68720d12325f49.x16984029356c96b7
		}, x8551ff9860b3b27c, x1666770923f021d3);
		x682712679dbc585a.x70fa1602ceccddee(new object[12]
		{
			"\\mmmaintypecatalog",
			MailMergeMainDocumentType.Catalog,
			"\\mmmaintypeenvelopes",
			MailMergeMainDocumentType.Envelopes,
			"\\mmmaintypelabels",
			MailMergeMainDocumentType.MailingLabels,
			"\\mmmaintypeletters",
			MailMergeMainDocumentType.FormLetters,
			"\\mmmaintypeemail",
			MailMergeMainDocumentType.Email,
			"\\mmmaintypefax",
			MailMergeMainDocumentType.Fax
		}, x100687b29b66a97c, x46bfe8ebb3e8fb5a);
		x682712679dbc585a.x70fa1602ceccddee(new object[12]
		{
			"\\mmdatatypeaccess",
			MailMergeDataType.Database,
			"\\mmdatatypeexcel",
			MailMergeDataType.Spreadsheet,
			"\\mmdatatypeqt",
			MailMergeDataType.Query,
			"\\mmdatatypeodbc",
			MailMergeDataType.Odbc,
			"\\mmdatatypeodso",
			MailMergeDataType.Native,
			"\\mmdatatypefile",
			MailMergeDataType.TextFile
		}, xf7f3144718bf752f, x0ae36a259ef6ad7f);
		x682712679dbc585a.x70fa1602ceccddee(new object[8]
		{
			"\\mmdestnewdoc",
			MailMergeDestination.NewDocument,
			"\\mmdestprinter",
			MailMergeDestination.Printer,
			"\\mmdestemail",
			MailMergeDestination.Email,
			"\\mmdestfax",
			MailMergeDestination.Fax
		}, x8d426cf4c8659770, xf15f17de0097c9fc);
	}
}
