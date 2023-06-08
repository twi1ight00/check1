using System.Drawing;
using System.Text;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x4f4df92b75ba3b67;

internal class x0c228b6673bb03aa : xba2f911354958a68
{
	private readonly xb187dfc67cf2709f xeec901fb6e4b560e;

	private readonly x4d8917c8186e8cb2 x4f943c75887b44d8;

	private readonly xcd986872cf3bcf68 xe65db51216614d6f;

	internal xcd986872cf3bcf68 x968fd3630f239305 => xe65db51216614d6f;

	public x0c228b6673bb03aa(x4882ae789be6e2ef context, FontStyle requestedStyle, xd99feecae3b0ba7a fontData)
		: base(context, requestedStyle, new x09c52d25bb20c3cd(fontData.x968fd3630f239305), fontData)
	{
		xe65db51216614d6f = fontData.x968fd3630f239305;
		xeec901fb6e4b560e = new xb187dfc67cf2709f(context, this);
		x4f943c75887b44d8 = new x4d8917c8186e8cb2(context);
	}

	internal string xf498d69a5239cf1b(int x4cba4ba1e17f1c21)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[");
		x09ce2c02826e31a6 x09ce2c02826e31a = x4f2a988137f0d4d9();
		for (int i = 0; i < x09ce2c02826e31a.xd44988f225497f3a; i++)
		{
			int x37cf7043760b312e = x09ce2c02826e31a.xf15263674eb297bb(i);
			int x8dcb0a33c47803dd = (int)x09ce2c02826e31a.x6d3720b962bd3112(i);
			x7c1d47b289dfd9fa x7c1d47b289dfd9fa = base.x25998da3963930e9.x29f65b3e7616f6b3.x1e6da4134d115607.x12f49b36ab885c48(x8dcb0a33c47803dd);
			int num = xf716fdaf41b2c8ab(x7c1d47b289dfd9fa.xf58adb71a3d2dade);
			if (num != x4cba4ba1e17f1c21)
			{
				stringBuilder.Append(xca004f56614e2431.xc8ba948e0d631490(x37cf7043760b312e));
				stringBuilder.Append("[");
				stringBuilder.Append(xca004f56614e2431.xc8ba948e0d631490(num));
				stringBuilder.Append("]");
			}
		}
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		x51cf2b3953f93541(writer);
		xeec901fb6e4b560e.WriteToPdf(writer);
		x08977b0c96e7c21f(writer);
	}

	private void x51cf2b3953f93541(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.x7a67b9beb30292d6(this);
		xbdfb620b7167944b.xafb7e6f79ed43681();
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Type", "/Font");
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Subtype", "/Type0");
		x9ee491ab5579b9fc.WriteEncodingToFontDictionary(xbdfb620b7167944b);
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/BaseFont", $"/{base.xd47a98a7600d6b65}");
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/DescendantFonts", $"[{xeec901fb6e4b560e.x899a2110a8a35fda}]");
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/ToUnicode", x4f943c75887b44d8.x899a2110a8a35fda);
		xbdfb620b7167944b.x693a8d6d020474f2();
		xbdfb620b7167944b.x5155d7b9dab28280();
	}

	private void x08977b0c96e7c21f(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		x4f943c75887b44d8.x25d0efbd7848eeb3("/CIDInit /ProcSet findresource begin");
		x4f943c75887b44d8.x25d0efbd7848eeb3("11 dict begin");
		x4f943c75887b44d8.x25d0efbd7848eeb3("begincmap");
		x4f943c75887b44d8.x25d0efbd7848eeb3("/CIDSystemInfo");
		x4f943c75887b44d8.x25d0efbd7848eeb3("<< /Registry (Adobe)");
		x4f943c75887b44d8.x25d0efbd7848eeb3("/Ordering (UCS)");
		x4f943c75887b44d8.x25d0efbd7848eeb3("/Supplement 0");
		x4f943c75887b44d8.x25d0efbd7848eeb3(">> def");
		x4f943c75887b44d8.x25d0efbd7848eeb3("/CMapName /Adobe-Identity-UCS def");
		x4f943c75887b44d8.x25d0efbd7848eeb3("/CMapType 2 def");
		x4f943c75887b44d8.x25d0efbd7848eeb3("1 begincodespacerange");
		x4f943c75887b44d8.x25d0efbd7848eeb3("<0000><FFFF>");
		x4f943c75887b44d8.x25d0efbd7848eeb3("endcodespacerange");
		xf6bb2120e903b619();
		x4f943c75887b44d8.x25d0efbd7848eeb3("endcmap");
		x4f943c75887b44d8.x25d0efbd7848eeb3("CMapName currentdict /CMap defineresource pop");
		x4f943c75887b44d8.x25d0efbd7848eeb3("end");
		x4f943c75887b44d8.x25d0efbd7848eeb3("end");
		x4f943c75887b44d8.WriteToPdf(xbdfb620b7167944b);
	}

	private void xf6bb2120e903b619()
	{
		x09ce2c02826e31a6 x09ce2c02826e31a = x4f2a988137f0d4d9();
		x4f943c75887b44d8.x25d0efbd7848eeb3("{0} beginbfchar", xca004f56614e2431.xc8ba948e0d631490(x09ce2c02826e31a.xd44988f225497f3a));
		for (int i = 0; i < x09ce2c02826e31a.xd44988f225497f3a; i++)
		{
			int x37cf7043760b312e = x09ce2c02826e31a.xf15263674eb297bb(i);
			int x8dcb0a33c47803dd = (int)x09ce2c02826e31a.x6d3720b962bd3112(i);
			x4f943c75887b44d8.x25d0efbd7848eeb3("<{0}><{1}>", xca004f56614e2431.x7c1a0f9da8274fe8(x37cf7043760b312e), xe85f0774cfbd0cf8(x8dcb0a33c47803dd));
		}
		x4f943c75887b44d8.x25d0efbd7848eeb3("endbfchar");
	}

	private string xe85f0774cfbd0cf8(int x8dcb0a33c47803dd)
	{
		string text = xdf3a1f89dca325a3.x251dbcb3221739c5(x8dcb0a33c47803dd);
		return $"{xca004f56614e2431.x7c1a0f9da8274fe8(text[0])}{((text.Length > 1) ? xca004f56614e2431.x7c1a0f9da8274fe8(text[1]) : string.Empty)}";
	}

	private x09ce2c02826e31a6 x4f2a988137f0d4d9()
	{
		x09ce2c02826e31a6 x09ce2c02826e31a = new x09ce2c02826e31a6();
		for (int i = 0; i < xe65db51216614d6f.x8f0b229fb69d4269.xd44988f225497f3a; i++)
		{
			int num = xe65db51216614d6f.x8f0b229fb69d4269.xf15263674eb297bb(i);
			int xba08ce632055a1d = (int)xe65db51216614d6f.x8f0b229fb69d4269.x6d3720b962bd3112(i);
			if (!x09ce2c02826e31a.xbc5dc59d0d9b620d(xba08ce632055a1d))
			{
				x09ce2c02826e31a.xd6b6ed77479ef68c(xba08ce632055a1d, num);
			}
		}
		return x09ce2c02826e31a;
	}
}
