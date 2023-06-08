using System.Drawing.Drawing2D;
using System.Text;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xaf73fad8cede26de;

internal class x941a3106af7ce3e9
{
	internal static bool x9e85ecf25cca82ee(x49c255776a98e55d xd07ce4b74c5774a7, x22a2c6bbecd8ed7a x0f7b23d1c393aed9, xab391c46ff9a0a38 xe125219852864557)
	{
		x4ff8ecf10eb0714f x4ff8ecf10eb0714f = new x4ff8ecf10eb0714f();
		string xbcea506a33cf = x4ff8ecf10eb0714f.x38b39e52c8321dc8(xe125219852864557);
		if (!x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf))
		{
			return false;
		}
		xd07ce4b74c5774a7.x2307058321cdb62f("Path");
		if (xe125219852864557.x9e5d5f9128c69a8f != null)
		{
			xd07ce4b74c5774a7.xff520a0047c27122("StrokeThickness", xe125219852864557.x9e5d5f9128c69a8f.xdc1bf80853046136);
			xd07ce4b74c5774a7.xff520a0047c27122("StrokeLineJoin", x7a02f1cfc55b8a6a.xc0a593247dbbc377(xe125219852864557.x9e5d5f9128c69a8f.x03a8df074279275f));
			if (xe125219852864557.x9e5d5f9128c69a8f.x03a8df074279275f == LineJoin.Miter || xe125219852864557.x9e5d5f9128c69a8f.x03a8df074279275f == LineJoin.MiterClipped)
			{
				xd07ce4b74c5774a7.xff520a0047c27122("StrokeMiterLimit", xe125219852864557.x9e5d5f9128c69a8f.x3372c2e5fab45e9a);
			}
			xd07ce4b74c5774a7.xff520a0047c27122("StrokeStartLineCap", x7a02f1cfc55b8a6a.xc54c279f16da6376(xe125219852864557.x9e5d5f9128c69a8f.x1e0dcb2cdd562cb2));
			xd07ce4b74c5774a7.xff520a0047c27122("StrokeEndLineCap", x7a02f1cfc55b8a6a.xc54c279f16da6376(xe125219852864557.x9e5d5f9128c69a8f.xec7c14446b693774));
			if (xe125219852864557.x9e5d5f9128c69a8f.xca08e8eb525b8a1a != 0)
			{
				xd07ce4b74c5774a7.xff520a0047c27122("StrokeDashOffset", xe125219852864557.x9e5d5f9128c69a8f.xc19b368b60309472);
				xd07ce4b74c5774a7.xff520a0047c27122("StrokeDashCap", x7a02f1cfc55b8a6a.xffa6b5e790e9ca3d(xe125219852864557.x9e5d5f9128c69a8f.x9526ba50e2183e01));
				xd07ce4b74c5774a7.xff520a0047c27122("StrokeDashArray", xb4a3e948ccf0c625(xe125219852864557.x9e5d5f9128c69a8f.x358988d12e56bf69));
			}
		}
		if (xe125219852864557.x52dde376accdec7d != null)
		{
			xd07ce4b74c5774a7.xff520a0047c27122("RenderTransform", xe125219852864557.x52dde376accdec7d);
		}
		xd07ce4b74c5774a7.xff520a0047c27122("Data", xbcea506a33cf);
		if (xe125219852864557.x0e1bf8242ad10272 != null)
		{
			xd07ce4b74c5774a7.xff520a0047c27122("Clip", x4ff8ecf10eb0714f.x38b39e52c8321dc8(xe125219852864557.x0e1bf8242ad10272));
		}
		if (xe125219852864557.x60465f602599d327 != null)
		{
			x1e8ae78ce4b0fda4(xd07ce4b74c5774a7, x0f7b23d1c393aed9, xe125219852864557.x60465f602599d327);
		}
		if (xe125219852864557.x9e5d5f9128c69a8f != null)
		{
			xae32a20a7d06086d(xd07ce4b74c5774a7, x0f7b23d1c393aed9, xe125219852864557.x9e5d5f9128c69a8f);
		}
		return true;
	}

	internal static void x8e20e5f3afd31049(x3c74b3c4f21844f9 xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static string xb4a3e948ccf0c625(float[] xa679552e30d81989)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < xa679552e30d81989.Length; i++)
		{
			stringBuilder.Append(xca004f56614e2431.x37804260a70f74eb(xa679552e30d81989[i]));
			if (i < xa679552e30d81989.Length - 1)
			{
				stringBuilder.Append(" ");
			}
		}
		if (xa679552e30d81989.Length % 2 == 1)
		{
			stringBuilder.Append(" 0");
		}
		return stringBuilder.ToString();
	}

	internal static void xae32a20a7d06086d(x49c255776a98e55d xd07ce4b74c5774a7, x22a2c6bbecd8ed7a x0f7b23d1c393aed9, x31c19fcb724dfaf5 x90279591611601bc)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("Path.Stroke");
		xeb4cb9e320b75151.x3a53bab86bc1dfad(xd07ce4b74c5774a7, x0f7b23d1c393aed9, x90279591611601bc.x60465f602599d327);
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	internal static void x1e8ae78ce4b0fda4(x49c255776a98e55d xd07ce4b74c5774a7, x22a2c6bbecd8ed7a x0f7b23d1c393aed9, x845d6a068e0b03c5 xd8f1949f8950238a)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("Path.Fill");
		xeb4cb9e320b75151.x3a53bab86bc1dfad(xd07ce4b74c5774a7, x0f7b23d1c393aed9, xd8f1949f8950238a);
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}
}
