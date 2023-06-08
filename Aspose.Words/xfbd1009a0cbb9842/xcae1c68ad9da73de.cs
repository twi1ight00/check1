using System.Collections;
using System.Text;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xfbd1009a0cbb9842;

internal class xcae1c68ad9da73de : x6ed66b5cf8da2955
{
	private string x466efe2449ba68a6 = string.Empty;

	private string xecea29caa71c189c = string.Empty;

	private string xaaaa57c6c15f5273 = string.Empty;

	private bool x6a131679d19aface;

	private int xc56c6554ad5cbc1b;

	private x2e7d767f7d782a7a x97aace01684d4eab;

	private static Hashtable x7a54136c855e1b56;

	private static Hashtable x14ad1dc0cb3f9952;

	internal string xe5d13ccbc3df998a
	{
		get
		{
			return x466efe2449ba68a6;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x466efe2449ba68a6 = value;
		}
	}

	internal string x9f8e4dc805c6986e
	{
		get
		{
			return xecea29caa71c189c;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			xecea29caa71c189c = value;
		}
	}

	internal string x336c298ccd00f056
	{
		get
		{
			return xaaaa57c6c15f5273;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			xaaaa57c6c15f5273 = value;
		}
	}

	internal bool xe8ae08e6819999f9
	{
		get
		{
			return x6a131679d19aface;
		}
		set
		{
			x6a131679d19aface = value;
		}
	}

	internal int x577033bbed151076
	{
		get
		{
			return xc56c6554ad5cbc1b;
		}
		set
		{
			xc56c6554ad5cbc1b = value;
		}
	}

	internal x2e7d767f7d782a7a x2e7d767f7d782a7a
	{
		get
		{
			return x97aace01684d4eab;
		}
		set
		{
			x97aace01684d4eab = value;
		}
	}

	internal static string xda09af88ab899a50(OleFormat x7b7c85f74f22d093)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat(" LINK {0} {1} {2} ", x7b7c85f74f22d093.ProgId, xb7dbd7bb3ed97d5b.x0b0647af7a5ab290(x7b7c85f74f22d093.SourceFullName), xb7dbd7bb3ed97d5b.x0b0647af7a5ab290(x7b7c85f74f22d093.SourceItem));
		if (x7b7c85f74f22d093.AutoUpdate)
		{
			stringBuilder.Append("\\a ");
		}
		if (x7b7c85f74f22d093.x577033bbed151076 != 0)
		{
			stringBuilder.AppendFormat("\\f {0} ", x7b7c85f74f22d093.x577033bbed151076);
		}
		stringBuilder.Append(x3d7f9ad0d95fd25e(x7b7c85f74f22d093.x2e7d767f7d782a7a));
		return stringBuilder.ToString();
	}

	internal static xcae1c68ad9da73de x1f490eac106aee12(string x0e59413709b18038)
	{
		xcae1c68ad9da73de xcae1c68ad9da73de2 = new xcae1c68ad9da73de();
		x985dd08fd338eeea x985dd08fd338eeea2 = new x985dd08fd338eeea(x0e59413709b18038, xcae1c68ad9da73de2);
		xcae1c68ad9da73de2.xe5d13ccbc3df998a = x985dd08fd338eeea2.x642e37025c67edab(0, x9fc40ce4428c62cc: true, xbd96676852fc71de: true);
		xcae1c68ad9da73de2.x9f8e4dc805c6986e = x985dd08fd338eeea2.x642e37025c67edab(1, x9fc40ce4428c62cc: true, xbd96676852fc71de: true);
		xcae1c68ad9da73de2.x336c298ccd00f056 = x985dd08fd338eeea2.x642e37025c67edab(2, x9fc40ce4428c62cc: true, xbd96676852fc71de: true);
		xcae1c68ad9da73de2.xe8ae08e6819999f9 = x985dd08fd338eeea2.xcc2d426b867d703d("\\a");
		int num = xca004f56614e2431.x912616ee70b2d94d(x985dd08fd338eeea2.x6eba61762c5e83d7("\\f", xbd96676852fc71de: true));
		if (num != int.MinValue)
		{
			xcae1c68ad9da73de2.x577033bbed151076 = num;
		}
		foreach (xcfa6f73a76d96956 item in x985dd08fd338eeea2.x7261c103565fa212)
		{
			switch (item.x759aa16c2016a289.ToLower())
			{
			case "\\b":
			case "\\h":
			case "\\p":
			case "\\r":
			case "\\t":
			case "\\u":
				xcae1c68ad9da73de2.x2e7d767f7d782a7a = x49016797797649bc(item.x759aa16c2016a289.ToLower());
				break;
			}
		}
		return xcae1c68ad9da73de2;
	}

	private x9f6b815e19fa8f62 x6b9dc5b8ca4335e3(string x724fbd227bfb6eda)
	{
		switch (x724fbd227bfb6eda)
		{
		case "\\a":
		case "\\d":
		case "\\b":
		case "\\h":
		case "\\p":
		case "\\r":
		case "\\t":
		case "\\u":
			return x9f6b815e19fa8f62.x8416ed4b8ffb3e34;
		case "\\f":
			return x9f6b815e19fa8f62.x47e3e032f7bd5d28;
		default:
			return x9f6b815e19fa8f62.xf6c17f648b65c793;
		}
	}

	x9f6b815e19fa8f62 x6ed66b5cf8da2955.x3ecf81e56889c4af(string x724fbd227bfb6eda)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x6b9dc5b8ca4335e3
		return this.x6b9dc5b8ca4335e3(x724fbd227bfb6eda);
	}

	internal static x2e7d767f7d782a7a x49016797797649bc(string xbcea506a33cf9111)
	{
		return (x2e7d767f7d782a7a)x682712679dbc585a.xce92de628aa023cf(x7a54136c855e1b56, xbcea506a33cf9111, x2e7d767f7d782a7a.x7f4d496937f8c24c);
	}

	internal static string x3d7f9ad0d95fd25e(x2e7d767f7d782a7a xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x14ad1dc0cb3f9952, xbcea506a33cf9111, "\\p");
	}

	static xcae1c68ad9da73de()
	{
		x7a54136c855e1b56 = new Hashtable();
		x14ad1dc0cb3f9952 = new Hashtable();
		x682712679dbc585a.x70fa1602ceccddee(new object[12]
		{
			"\\p",
			x2e7d767f7d782a7a.x7f4d496937f8c24c,
			"\\b",
			x2e7d767f7d782a7a.x1351df7d00b0ea53,
			"\\h",
			x2e7d767f7d782a7a.x4bc88de02db3a00d,
			"\\r",
			x2e7d767f7d782a7a.x5896ed36f2cf9162,
			"\\t",
			x2e7d767f7d782a7a.xf9ad6fb78355fe13,
			"\\u",
			x2e7d767f7d782a7a.xc6077c9598837311
		}, x7a54136c855e1b56, x14ad1dc0cb3f9952);
	}
}
