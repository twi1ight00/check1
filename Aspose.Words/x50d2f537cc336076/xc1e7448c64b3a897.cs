using System;
using System.Collections;
using System.Drawing;
using System.Text;
using x1c8faa688b1f0b0c;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xeb665d1aeef09d64;

namespace x50d2f537cc336076;

internal class xc1e7448c64b3a897 : x57df270da83ea6de
{
	private const string xad4e1b2d8ca4e91c = "Cambria Math";

	private string xed4a7b1500064e12;

	private xeedad81aaed42a76 xd0c44e5ae0011daa;

	private bool xfe48d421ab96598f;

	private bool x6146324e24a5d839;

	private float xd74c65b8d28b1740;

	private float x8918dc7c534575e5;

	private float x35ce3e947a843983;

	private static Hashtable x4fd9df925bdefeea;

	private static char[] xdd3ed78096d5688f;

	private static char[] x8037d270b93c78c4;

	internal xc1e7448c64b3a897(string text, xeedad81aaed42a76 runPr, bool isArgument)
		: base(null)
	{
		xed4a7b1500064e12 = text;
		xd0c44e5ae0011daa = runPr;
		xfe48d421ab96598f = isArgument;
	}

	internal override void x1fa9148f6731ff24(x57df270da83ea6de x4bbc2c453c470189)
	{
		throw new NotSupportedException("Text element cannot have children.");
	}

	internal override void xb7ae55095fddecd9()
	{
		xe39d06eee35dd23d xe39d06eee35dd23d = x9d888f53892d94df.x9834ddb0e0bd5996.x491f5a7224612753(xd0c44e5ae0011daa.x759aa16c2016a289, xd0c44e5ae0011daa.x437e3b626c0fdd43, x659bc4263aa7ef66());
		x7251308304851b5d(xe39d06eee35dd23d);
		x35ce3e947a843983 = xe39d06eee35dd23d.x30e45ef93fedb4ba(32);
		x26d9ecb4bdf0456d x6c50a99faab7d = ((xd0c44e5ae0011daa.x9b41425268471380 == x26d9ecb4bdf0456d.x45260ad4b94166f2) ? x26d9ecb4bdf0456d.x89fffa2751fdecbe : xd0c44e5ae0011daa.x9b41425268471380);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < xed4a7b1500064e12.Length; i++)
		{
			char c = xed4a7b1500064e12[i];
			if (xa3ec13fa5b9aace5(c))
			{
				if (stringBuilder.Length > 0)
				{
					x56baafd669e0d3e9(xe39d06eee35dd23d, x6c50a99faab7d, stringBuilder.ToString());
					stringBuilder = new StringBuilder();
				}
				xad068acc3b1e8bc5(xe39d06eee35dd23d, x6c50a99faab7d, c.ToString());
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		x56baafd669e0d3e9(xe39d06eee35dd23d, x6c50a99faab7d, stringBuilder.ToString());
		x6ae4612a8469678e = new RectangleF(x6ae4612a8469678e.X, x6ae4612a8469678e.Y, xd74c65b8d28b1740, x8918dc7c534575e5);
	}

	private void xad068acc3b1e8bc5(xe39d06eee35dd23d x26094932cf7a9139, x26d9ecb4bdf0456d x6c50a99faab7d741, string x9c9eac3a36336680)
	{
		if (!x6146324e24a5d839)
		{
			xd74c65b8d28b1740 += x35ce3e947a843983;
		}
		xe58d60f216ff3371(x26094932cf7a9139, x6c50a99faab7d741, x9c9eac3a36336680);
		x6146324e24a5d839 = true;
	}

	private void x56baafd669e0d3e9(xe39d06eee35dd23d x26094932cf7a9139, x26d9ecb4bdf0456d x6c50a99faab7d741, string xb41faee6912a2313)
	{
		if (x6146324e24a5d839)
		{
			xd74c65b8d28b1740 += x35ce3e947a843983;
		}
		xe58d60f216ff3371(x26094932cf7a9139, x6c50a99faab7d741, xb41faee6912a2313);
		x6146324e24a5d839 = false;
	}

	private void xe58d60f216ff3371(xe39d06eee35dd23d x26094932cf7a9139, x26d9ecb4bdf0456d x6c50a99faab7d741, string xb41faee6912a2313)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xb41faee6912a2313))
		{
			SizeF size = x26094932cf7a9139.x6e21842ebf5f70df(xb41faee6912a2313);
			PointF origin = new PointF(xd74c65b8d28b1740, x26094932cf7a9139.xd9ac1486133b5a4e);
			xd74c65b8d28b1740 += size.Width;
			x8918dc7c534575e5 = Math.Max(size.Height, x8918dc7c534575e5);
			xcc8c7739d82c63ba xda5bf54deb817e = new xcc8c7739d82c63ba(x26094932cf7a9139, x6c50a99faab7d741, x26d9ecb4bdf0456d.x45260ad4b94166f2, origin, xb41faee6912a2313, size, xd0c44e5ae0011daa.x9ba60a33bc3988dc);
			base.xefb7a8f84373ac04.xd6b6ed77479ef68c(xda5bf54deb817e);
		}
	}

	private FontStyle x659bc4263aa7ef66()
	{
		if (xd0c44e5ae0011daa.x759aa16c2016a289 == "Cambria Math")
		{
			return FontStyle.Regular;
		}
		FontStyle fontStyle = FontStyle.Regular;
		if (xd0c44e5ae0011daa.x4e1d3347e7864b81.x4e98cd0cf854343f())
		{
			fontStyle |= FontStyle.Bold;
		}
		if (xd0c44e5ae0011daa.x00d0ae795109fe11.x4e98cd0cf854343f())
		{
			fontStyle |= FontStyle.Italic;
		}
		if (xd0c44e5ae0011daa.x2588d8c20c42e232 != 0)
		{
			fontStyle |= FontStyle.Underline;
		}
		return fontStyle;
	}

	private void x7251308304851b5d(xe39d06eee35dd23d x26094932cf7a9139)
	{
		if (!(x26094932cf7a9139.x6054c4379c01a50d != "Cambria Math") && xfe48d421ab96598f)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < xed4a7b1500064e12.Length; i++)
			{
				char x3c4da2980d043c = xed4a7b1500064e12[i];
				stringBuilder.Append(xbd597aaf540a2be3(x3c4da2980d043c));
			}
			xed4a7b1500064e12 = stringBuilder.ToString();
		}
	}

	private static string xbd597aaf540a2be3(char x3c4da2980d043c95)
	{
		if (!x4fd9df925bdefeea.ContainsKey(x3c4da2980d043c95))
		{
			return new string(x3c4da2980d043c95, 1);
		}
		return xdf3a1f89dca325a3.x251dbcb3221739c5((int)x4fd9df925bdefeea[x3c4da2980d043c95]);
	}

	private static bool xa3ec13fa5b9aace5(char x3c4da2980d043c95)
	{
		if (xcc23a9631b49a7e5(xdd3ed78096d5688f, x3c4da2980d043c95))
		{
			return true;
		}
		if (x3c4da2980d043c95 >= x8037d270b93c78c4[0] && x3c4da2980d043c95 <= x8037d270b93c78c4[x8037d270b93c78c4.Length - 1])
		{
			return xcc23a9631b49a7e5(x8037d270b93c78c4, x3c4da2980d043c95);
		}
		return false;
	}

	private static bool xcc23a9631b49a7e5(char[] x9d5750eb2d6373bc, char x3c4da2980d043c95)
	{
		for (int i = 0; i < x9d5750eb2d6373bc.Length; i++)
		{
			if (x9d5750eb2d6373bc[i] == x3c4da2980d043c95)
			{
				return true;
			}
		}
		return false;
	}

	static xc1e7448c64b3a897()
	{
		x4fd9df925bdefeea = new Hashtable();
		xdd3ed78096d5688f = new char[13]
		{
			'*', '+', '-', '<', '=', '>', '±', '×', '÷', '‒',
			'†', '‡', '△'
		};
		x8037d270b93c78c4 = new char[130]
		{
			'∈', '∉', '∋', '∓', '∔', '∕', '∖', '∗', '∘', '∙',
			'∝', '∥', '∧', '∨', '∩', '∪', '∴', '∵', '∶', '∸',
			'∼', '∽', '≀', '≃', '≄', '≇', '≈', '≉', '≊', '≍',
			'≎', '≏', '≐', '≑', '≒', '≓', '≖', '≗', '≜', '≝',
			'≠', '≡', '≢', '≤', '≥', '≦', '≧', '≪', '≫', '≬',
			'≮', '≯', '≰', '≱', '≲', '≳', '≶', '≷', '≺', '≻',
			'≼', '≼', '≽', '≽', '≾', '≿', '⊂', '⊃', '⊆', '⊆',
			'⊇', '⊇', '⊎', '⊏', '⊐', '⊑', '⊒', '⊓', '⊔', '⊕',
			'⊖', '⊗', '⊘', '⊙', '⊚', '⊛', '⊝', '⊞', '⊟', '⊠',
			'⊡', '⊢', '⊣', '⊥', '⊨', '⊩', '⊪', '⊲', '⊳', '⊴',
			'⊵', '⊺', '⋄', '⋅', '⋆', '⋇', '⋈', '⋈', '⋉', '⋊',
			'⋋', '⋌', '⋍', '⋎', '⋏', '⋐', '⋑', '⋒', '⋓', '⋔',
			'⋖', '⋗', '⋘', '⋙', '⋚', '⋛', '⋜', '⋝', '⋞', '⋟'
		};
		for (char c = 'a'; c <= 'z'; c = (char)(c + 1))
		{
			x4fd9df925bdefeea[c] = c + 119789;
		}
		for (char c2 = 'A'; c2 <= 'Z'; c2 = (char)(c2 + 1))
		{
			x4fd9df925bdefeea[c2] = c2 + 119795;
		}
		x4fd9df925bdefeea['h'] = 8462;
		x4fd9df925bdefeea['-'] = 8210;
		x4fd9df925bdefeea['*'] = 8727;
	}
}
