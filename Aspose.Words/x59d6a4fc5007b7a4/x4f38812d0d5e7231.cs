using System;
using System.Collections;
using Aspose.Words;
using Aspose.Words.Saving;
using Aspose.Words.Settings;
using x28925c9b27b37a46;
using x4adf554d20d941a6;
using x66dd9eaee57cfba4;
using xf989f31a236ff98c;

namespace x59d6a4fc5007b7a4;

internal class x4f38812d0d5e7231 : xaa47e6d0b035aea6
{
	private enum x742e26ca8d747b28
	{
		x4d0b9d4447ba7566,
		xf9ad6fb78355fe13,
		x3e1feffd8ca6feb2,
		xe59d6d35c76d70aa
	}

	private class xbfac429e165a6a0d
	{
		private int x212ae880d15d2ed1;

		private int xb664a8c25c0c85cc;

		private readonly string xed4a7b1500064e12;

		private bool x87f656b7899cfaf6;

		private readonly x1d1dd20018fcde10 x83cd810ab70afec3;

		private readonly xacc55eb1e4595209 x8ac5a83e483bcc07;

		private readonly x000f21cbda739311 x8d8226994d810517;

		internal int x12cb12b5d2cad53d => x212ae880d15d2ed1;

		internal int x9fd888e65466818c => xb664a8c25c0c85cc;

		internal bool xc943a5c0f676cd2b => !x87f656b7899cfaf6;

		public object x35cfcea4890f4e7d => xc943a5c0f676cd2b;

		internal xbfac429e165a6a0d(string text, x1d1dd20018fcde10 font, x000f21cbda739311 category, xacc55eb1e4595209 mapper)
		{
			xed4a7b1500064e12 = text;
			x83cd810ab70afec3 = font;
			x8ac5a83e483bcc07 = mapper;
			x8d8226994d810517 = category;
			x74f5a1ef3906e23c();
		}

		public bool x47f176deff0d42e2()
		{
			x212ae880d15d2ed1 = xb664a8c25c0c85cc;
			if (x212ae880d15d2ed1 >= xed4a7b1500064e12.Length)
			{
				return false;
			}
			while (true)
			{
				if (xb664a8c25c0c85cc < xed4a7b1500064e12.Length && xee5277c7de5be8e4(xed4a7b1500064e12[xb664a8c25c0c85cc]) == x87f656b7899cfaf6)
				{
					xb664a8c25c0c85cc++;
					continue;
				}
				x87f656b7899cfaf6 = !x87f656b7899cfaf6;
				if (xb664a8c25c0c85cc != x212ae880d15d2ed1)
				{
					break;
				}
				xb664a8c25c0c85cc++;
			}
			return true;
		}

		public void x74f5a1ef3906e23c()
		{
			x212ae880d15d2ed1 = 0;
			xb664a8c25c0c85cc = 0;
		}

		private bool xee5277c7de5be8e4(char x3c4da2980d043c95)
		{
			x6b1a899052c71a60 x6b1a899052c71a = x83cd810ab70afec3.xc06de25aa714683f(x8d8226994d810517);
			if (x6b1a899052c71a == null)
			{
				x6b1a899052c71a = x8ac5a83e483bcc07.xfeeb3de36742543a(x83cd810ab70afec3, x8d8226994d810517, x34a37b5a89c466fd.x4c57b971f1a8d64d(x3c4da2980d043c95));
				x83cd810ab70afec3.x3c8f1980ecfa6e87(x8d8226994d810517, x6b1a899052c71a);
			}
			if (x6b1a899052c71a != null)
			{
				return x6b1a899052c71a.x1e6da4134d115607.get_xe6d4b1b411ed94b5((int)x3c4da2980d043c95) == null;
			}
			return false;
		}
	}

	private class xf838f0b35babc912
	{
		internal readonly int x5566e2d2acbd1fbe;

		internal readonly string xf9ad6fb78355fe13;

		internal readonly x000f21cbda739311 x9ee8adcec1e2f351;

		internal readonly bool x8c7546b3f6a0da68;

		internal readonly string x759aa16c2016a289;

		internal readonly bool x3a7473f820dd300b;

		internal readonly int xa59ac2c936c6b7bd;

		internal xf838f0b35babc912(int spanType, string text, x000f21cbda739311 category, string fontName, bool isSmallCapsLower, bool isRtl, int localeIdBi)
		{
			x5566e2d2acbd1fbe = spanType;
			xf9ad6fb78355fe13 = text;
			x9ee8adcec1e2f351 = category;
			x759aa16c2016a289 = fontName;
			x8c7546b3f6a0da68 = isSmallCapsLower;
			x3a7473f820dd300b = isRtl;
			xa59ac2c936c6b7bd = localeIdBi;
		}
	}

	private const string x638aa6f19896a76a = "Arial Unicode MS";

	internal const int xd557c3f0da51cfe4 = 16382;

	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	private int xa9de8b15d6d142ba;

	private x08802e9e984cd3ee x5a7a1d229173bf5d;

	private readonly x1d1dd20018fcde10 x83cd810ab70afec3;

	private readonly xacc55eb1e4595209 x8ac5a83e483bcc07;

	private bool xed59c429c6e58585;

	private readonly bool x41096f405e836cb4;

	private readonly int x77264eb9c03a5153;

	private readonly int x889791f18fe4a450;

	private readonly int xf787de6753ffce43;

	private readonly ArrayList x9676691686e8e935 = new ArrayList();

	private x742e26ca8d747b28 x30a3394c0375b0b0;

	private readonly NumeralFormat x1f7ceef97f47be57;

	private bool xae5f8919cf07c8bb;

	private bool xe2e5f54339175005;

	public object x35cfcea4890f4e7d => x82b70567a5f68f41[xa9de8b15d6d142ba];

	internal x000f21cbda739311 x9ee8adcec1e2f351 => xb444c09fa044bbca.x9ee8adcec1e2f351;

	internal string x759aa16c2016a289 => xb444c09fa044bbca.x759aa16c2016a289;

	internal bool x8c7546b3f6a0da68 => xb444c09fa044bbca.x8c7546b3f6a0da68;

	internal int x5566e2d2acbd1fbe => xb444c09fa044bbca.x5566e2d2acbd1fbe;

	public string xf9ad6fb78355fe13 => xb444c09fa044bbca.xf9ad6fb78355fe13;

	public bool x3a7473f820dd300b => xb444c09fa044bbca.x3a7473f820dd300b;

	public int xa59ac2c936c6b7bd => xb444c09fa044bbca.xa59ac2c936c6b7bd;

	private xf838f0b35babc912 xb444c09fa044bbca => (xf838f0b35babc912)x35cfcea4890f4e7d;

	public bool x47f176deff0d42e2()
	{
		return ++xa9de8b15d6d142ba < x82b70567a5f68f41.Count;
	}

	public void x74f5a1ef3906e23c()
	{
		xa9de8b15d6d142ba = -1;
		x5a7a1d229173bf5d = null;
	}

	internal x4f38812d0d5e7231(Inline node, string text, x1d1dd20018fcde10 font, xacc55eb1e4595209 converter, CompatibilityOptions compatibility, NumeralFormat numeralFormat)
	{
		if (node.ParentParagraph != null)
		{
			xe2e5f54339175005 = node.ParentParagraph.x1a78664fa10a3755.xcedf9c82728ad579;
		}
		x83cd810ab70afec3 = font;
		x8ac5a83e483bcc07 = converter;
		x1f7ceef97f47be57 = numeralFormat;
		xeedad81aaed42a76 xeedad81aaed42a = node.x856218fd0771d379(xecac24b19ed3a2b7.xb7ae55095fddecd9);
		xed59c429c6e58585 = xeedad81aaed42a.xcedf9c82728ad579.x4e98cd0cf854343f();
		x41096f405e836cb4 = xed59c429c6e58585 || xeedad81aaed42a.xd4e922ceeed89b74.x4e98cd0cf854343f();
		x77264eb9c03a5153 = xeedad81aaed42a.x2928b54f20b91723;
		xf787de6753ffce43 = xeedad81aaed42a.xa59ac2c936c6b7bd;
		x889791f18fe4a450 = xeedad81aaed42a.xbdfe108412062dd5;
		x5a7a1d229173bf5d = new x08802e9e984cd3ee(this, compatibility);
		x4041477ce3d81452(text, font.x0080ae622855f90c);
		foreach (string item in x9676691686e8e935)
		{
			switch (item[0])
			{
			case '\u0002':
			case '\u0005':
			case ' ':
			case '\u2002':
			case '\u200e':
			case '\u200f':
				x4fb8d507f4b3c96e(font.xc2d4efc42998d87b, item, x000f21cbda739311.x175297738c8b8d1e);
				break;
			default:
				xd22cb714335f8d2c(item);
				break;
			}
		}
		x74f5a1ef3906e23c();
	}

	internal int x0be68579badf5b2b(x4a1a6d8b0aafa0fe x89c7f101679f0a46)
	{
		if (x89c7f101679f0a46 != x4a1a6d8b0aafa0fe.xb70c4e1b6bf793bc)
		{
			if (!x3a7473f820dd300b)
			{
				return x77264eb9c03a5153;
			}
			return xf787de6753ffce43;
		}
		return x889791f18fe4a450;
	}

	public void x4fb8d507f4b3c96e(Font x0078185e1040c523, string xb41faee6912a2313, x000f21cbda739311 xcb075c7088c3b520)
	{
		if (0 >= xb41faee6912a2313.Length)
		{
			return;
		}
		x1d1dd20018fcde10 x1d1dd20018fcde11 = x83cd810ab70afec3;
		switch (xb41faee6912a2313[0])
		{
		case '\u2003':
			xd6b6ed77479ef68c(10768, xb41faee6912a2313, xcb075c7088c3b520, x1d1dd20018fcde11);
			return;
		case '\n':
			xd6b6ed77479ef68c(10768, '\u2003'.ToString(), xcb075c7088c3b520, x1d1dd20018fcde11);
			return;
		case '\u2002':
			xd6b6ed77479ef68c(10769, xb41faee6912a2313, xcb075c7088c3b520, x1d1dd20018fcde11);
			return;
		case '\u2005':
			xd6b6ed77479ef68c(10770, xb41faee6912a2313, xcb075c7088c3b520, x1d1dd20018fcde11);
			return;
		case '\u3000':
			xd6b6ed77479ef68c(10782, xb41faee6912a2313, xcb075c7088c3b520, x1d1dd20018fcde11);
			return;
		case '\u00a0':
			xd6b6ed77479ef68c(9747, xb41faee6912a2313, xcb075c7088c3b520, x1d1dd20018fcde11);
			return;
		case '—':
			xd6b6ed77479ef68c(11284, xb41faee6912a2313, xcb075c7088c3b520, x1d1dd20018fcde11);
			return;
		case '–':
			xd6b6ed77479ef68c(11285, xb41faee6912a2313, xcb075c7088c3b520, x1d1dd20018fcde11);
			return;
		case '\u200d':
			xd6b6ed77479ef68c(9753, xb41faee6912a2313, xcb075c7088c3b520, x1d1dd20018fcde11);
			return;
		case '\u200c':
			xd6b6ed77479ef68c(9752, xb41faee6912a2313, xcb075c7088c3b520, x1d1dd20018fcde11);
			return;
		case '\r':
			xd6b6ed77479ef68c(21537, xb41faee6912a2313, xcb075c7088c3b520, x1d1dd20018fcde11);
			return;
		case ' ':
			xd6b6ed77479ef68c(10754, xb41faee6912a2313, xcb075c7088c3b520, x1d1dd20018fcde11, x1d1dd20018fcde11.x0080ae622855f90c, null);
			return;
		case '\u200f':
			xd6b6ed77479ef68c(9755, xb41faee6912a2313, xcb075c7088c3b520, x1d1dd20018fcde11);
			return;
		case '\u200e':
			xd6b6ed77479ef68c(9754, xb41faee6912a2313, xcb075c7088c3b520, x1d1dd20018fcde11);
			return;
		case '\u0002':
		case '\u0005':
			xd6b6ed77479ef68c(9217, xb41faee6912a2313, xcb075c7088c3b520, x1d1dd20018fcde11);
			return;
		case '\u0003':
			xd6b6ed77479ef68c(9244, xb41faee6912a2313, xcb075c7088c3b520, x1d1dd20018fcde11);
			return;
		case '\u0004':
			xd6b6ed77479ef68c(9245, xb41faee6912a2313, xcb075c7088c3b520, x1d1dd20018fcde11);
			return;
		}
		xbfac429e165a6a0d xbfac429e165a6a0d = new xbfac429e165a6a0d(xb41faee6912a2313, x1d1dd20018fcde11, xcb075c7088c3b520, x8ac5a83e483bcc07);
		while (xbfac429e165a6a0d.x47f176deff0d42e2())
		{
			string text = xb41faee6912a2313.Substring(xbfac429e165a6a0d.x12cb12b5d2cad53d, xbfac429e165a6a0d.x9fd888e65466818c - xbfac429e165a6a0d.x12cb12b5d2cad53d);
			string x9e9070c6c983bbc = ((xbfac429e165a6a0d.xc943a5c0f676cd2b && (xcb075c7088c3b520 == x000f21cbda739311.x7c8c2d13fa5b79fa || xcb075c7088c3b520 == x000f21cbda739311.xd4e922ceeed89b74)) ? "Arial Unicode MS" : null);
			bool xcf94672007892a8b = char.IsLower(text[0]) && x1d1dd20018fcde11.x0080ae622855f90c;
			xd6b6ed77479ef68c(9217, text, xcb075c7088c3b520, x1d1dd20018fcde11, xcf94672007892a8b, x9e9070c6c983bbc);
		}
	}

	public void xa2b89eef4b059bae(Font x26094932cf7a9139)
	{
		throw new InvalidOperationException();
	}

	public void x284f8021a6d47363(Font x26094932cf7a9139)
	{
		xd6b6ed77479ef68c(21514, ControlChar.LineBreak, x000f21cbda739311.x175297738c8b8d1e, x83cd810ab70afec3, xcf94672007892a8b: false, null);
	}

	public void x6597dd39dd2fe401(Font x26094932cf7a9139)
	{
		xd6b6ed77479ef68c(21788, ControlChar.PageBreak, x000f21cbda739311.x175297738c8b8d1e, x83cd810ab70afec3, xcf94672007892a8b: false, null);
	}

	public void x52597787a113eeb0(Font x26094932cf7a9139)
	{
		xd6b6ed77479ef68c(21779, ControlChar.ColumnBreak, x000f21cbda739311.x175297738c8b8d1e, x83cd810ab70afec3, xcf94672007892a8b: false, null);
	}

	public void x3d5e17ecf5a24632(Font x26094932cf7a9139)
	{
		xd6b6ed77479ef68c(12803, ControlChar.Tab, x000f21cbda739311.x175297738c8b8d1e, x83cd810ab70afec3, xcf94672007892a8b: false, null);
	}

	public void x036788cf7c188d59(Font x26094932cf7a9139)
	{
		xd6b6ed77479ef68c(9747, ControlChar.NonBreakingSpace, x000f21cbda739311.x175297738c8b8d1e, x83cd810ab70afec3, xcf94672007892a8b: false, null);
	}

	public void x85c770ad4ef06982(Font x26094932cf7a9139)
	{
		xd6b6ed77479ef68c(9238, ControlChar.x6d39aeda91fde741, x000f21cbda739311.x175297738c8b8d1e, x83cd810ab70afec3, xcf94672007892a8b: false, null);
	}

	public void xf376b77c1a1556bf(Font x26094932cf7a9139)
	{
		xd6b6ed77479ef68c(11799, ControlChar.xa105f6e68b723c97, x000f21cbda739311.x175297738c8b8d1e, x83cd810ab70afec3, xcf94672007892a8b: false, null);
	}

	private void xc363aa1cb5299338(Font x26094932cf7a9139, bool xe68b7760102eb0fd)
	{
	}

	void xaa47e6d0b035aea6.x920950f507ecd136(Font x26094932cf7a9139, bool xe68b7760102eb0fd)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xc363aa1cb5299338
		this.xc363aa1cb5299338(x26094932cf7a9139, xe68b7760102eb0fd);
	}

	private void x4041477ce3d81452(string xb41faee6912a2313, bool xdfe96ac2591fbe50)
	{
		x9676691686e8e935.Clear();
		if (xb41faee6912a2313.Length <= 1)
		{
			x9676691686e8e935.Add(xb41faee6912a2313);
			return;
		}
		x30a3394c0375b0b0 = x742e26ca8d747b28.x4d0b9d4447ba7566;
		int num = 0;
		for (int i = 0; i < xb41faee6912a2313.Length; i++)
		{
			if (x34a37b5a89c466fd.x4502dd0e4ff79841(xb41faee6912a2313[i]) && !xed59c429c6e58585)
			{
				xae5f8919cf07c8bb = true;
			}
			if (++num < 16382)
			{
				switch (xb41faee6912a2313[i])
				{
				case '\u0002':
				case '\u0005':
				case '\n':
				case '\u001e':
				case '\u001f':
				case '\u00a0':
				case '\u2002':
				case '\u2003':
				case '\u2005':
				case '\u200c':
				case '\u200d':
				case '\u200e':
				case '\u200f':
				case '–':
				case '—':
				case '\u3000':
					xd80082bad4bc01c4(x742e26ca8d747b28.xe59d6d35c76d70aa);
					if (i == 0)
					{
						continue;
					}
					break;
				case ' ':
					if (xd80082bad4bc01c4(x742e26ca8d747b28.x3e1feffd8ca6feb2))
					{
						continue;
					}
					break;
				default:
					if (xd80082bad4bc01c4(x742e26ca8d747b28.xf9ad6fb78355fe13) && (!xdfe96ac2591fbe50 || 0 >= i || char.IsLower(xb41faee6912a2313[i - 1]) == char.IsLower(xb41faee6912a2313[i])) && (0 >= i || x34a37b5a89c466fd.xd5042647c7fe230d(xb41faee6912a2313[i - 1]) == x34a37b5a89c466fd.xd5042647c7fe230d(xb41faee6912a2313[i])) && (0 >= i || x34a37b5a89c466fd.x4502dd0e4ff79841(xb41faee6912a2313[i - 1]) == x34a37b5a89c466fd.x4502dd0e4ff79841(xb41faee6912a2313[i])) && (0 >= i || x34a37b5a89c466fd.x6657b4a72cfac626(xb41faee6912a2313[i - 1]) == x34a37b5a89c466fd.x6657b4a72cfac626(xb41faee6912a2313[i])))
					{
						continue;
					}
					break;
				}
			}
			num = 0;
			x9676691686e8e935.Add(i);
		}
		x9676691686e8e935.Add(xb41faee6912a2313.Length);
		int num2 = 0;
		for (int j = 0; j < x9676691686e8e935.Count; j++)
		{
			int num3 = (int)x9676691686e8e935[j];
			x9676691686e8e935[j] = xb41faee6912a2313.Substring(num2, num3 - num2);
			num2 = num3;
		}
	}

	private void xd22cb714335f8d2c(string xb41faee6912a2313)
	{
		bool isMirroringRequired = xed59c429c6e58585 || (xe2e5f54339175005 && xae5f8919cf07c8bb);
		x4e23280611779ac3 x4e23280611779ac4 = new x4e23280611779ac3(xb41faee6912a2313, xed59c429c6e58585, xf787de6753ffce43, isMirroringRequired);
		xa4665f59f0cb55bd.xaa12240713c4e5bd(x4e23280611779ac4, x1f7ceef97f47be57);
		xed59c429c6e58585 = x4e23280611779ac4.x3a7473f820dd300b;
		x5a7a1d229173bf5d.xd22cb714335f8d2c(x4e23280611779ac4.xf9ad6fb78355fe13, x83cd810ab70afec3.xc2d4efc42998d87b);
	}

	private bool xd80082bad4bc01c4(x742e26ca8d747b28 xbcea506a33cf9111)
	{
		bool result = x30a3394c0375b0b0 == x742e26ca8d747b28.x4d0b9d4447ba7566 || xbcea506a33cf9111 == x30a3394c0375b0b0;
		x30a3394c0375b0b0 = xbcea506a33cf9111;
		return result;
	}

	private void xd6b6ed77479ef68c(int x5620391b595d8955, string xb41faee6912a2313, x000f21cbda739311 x6f02b6a80bf6b36f, x1d1dd20018fcde10 x26094932cf7a9139, bool xcf94672007892a8b, string x9e9070c6c983bbc0)
	{
		x000f21cbda739311 x6f02b6a80bf6b36f2 = (x52b49f2d2a30e3fa(xb41faee6912a2313) ? x000f21cbda739311.xd4e922ceeed89b74 : x6f02b6a80bf6b36f);
		if (x9e9070c6c983bbc0 == null)
		{
			x9e9070c6c983bbc0 = x26094932cf7a9139.xaf95fb496eb25433(x6f02b6a80bf6b36f2);
		}
		x82b70567a5f68f41.Add(new xf838f0b35babc912(x5620391b595d8955, xb41faee6912a2313, x6f02b6a80bf6b36f, x9e9070c6c983bbc0, xcf94672007892a8b, xed59c429c6e58585, xf787de6753ffce43));
	}

	private bool x52b49f2d2a30e3fa(string xb41faee6912a2313)
	{
		bool flag = x34a37b5a89c466fd.x6657b4a72cfac626(xb41faee6912a2313[0]);
		bool flag2 = x769ea5e930af2cbc.x68e6a98ab5d29468(xf787de6753ffce43);
		bool result = x1f7ceef97f47be57 == NumeralFormat.ArabicIndic || x1f7ceef97f47be57 == NumeralFormat.EasternArabicIndic;
		if (!x41096f405e836cb4 || (flag && !flag2))
		{
			if (flag && flag2)
			{
				return result;
			}
			return false;
		}
		return true;
	}

	private void xd6b6ed77479ef68c(int x5620391b595d8955, string xb41faee6912a2313, x000f21cbda739311 x6f02b6a80bf6b36f, x1d1dd20018fcde10 x26094932cf7a9139)
	{
		xd6b6ed77479ef68c(x5620391b595d8955, xb41faee6912a2313, x6f02b6a80bf6b36f, x26094932cf7a9139, xcf94672007892a8b: false, null);
	}
}
