using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using Aspose;
using x5794c252ba25e723;

namespace xf9a9481c3f63a419;

[JavaManual("Manual porting by design.")]
internal class x3dacf8cbb5aec9f0 : IDisposable
{
	private Graphics xbc2692af206697aa;

	private readonly TextRenderingHint xf578cd532a5af49e;

	private readonly InterpolationMode xd3d7255c904109d3;

	private readonly Matrix xe1a804be9ed340fc;

	private readonly Region x02341ba5d6ef3199;

	public x3dacf8cbb5aec9f0(x3cd5d648729cd9b6 palBitmap)
		: this(palBitmap.x45634637f3d108db())
	{
	}

	public x3dacf8cbb5aec9f0(Image image)
	{
		xbc2692af206697aa = Graphics.FromImage(image);
		xf578cd532a5af49e = xbc2692af206697aa.TextRenderingHint;
		xd3d7255c904109d3 = xbc2692af206697aa.InterpolationMode;
		xe1a804be9ed340fc = xbc2692af206697aa.Transform;
		x02341ba5d6ef3199 = xbc2692af206697aa.Clip;
	}

	public void Dispose()
	{
		x8ffe90e7fbccfccd();
		GC.SuppressFinalize(this);
	}

	public void x8ffe90e7fbccfccd()
	{
		if (xbc2692af206697aa != null)
		{
			xbc2692af206697aa.Clip = x02341ba5d6ef3199;
			xbc2692af206697aa.Transform = xe1a804be9ed340fc;
			xbc2692af206697aa.InterpolationMode = xd3d7255c904109d3;
			xbc2692af206697aa.TextRenderingHint = xf578cd532a5af49e;
			xbc2692af206697aa.Dispose();
			xbc2692af206697aa = null;
		}
	}

	public void x363d43481471f613()
	{
		x24670816c6fb8451();
	}

	public void xc265ae6c5754834c()
	{
		xbc2692af206697aa.SmoothingMode = SmoothingMode.HighQuality;
	}

	public void x24670816c6fb8451()
	{
		xbc2692af206697aa.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
	}

	public void x4efda9e12bc505eb()
	{
		xbc2692af206697aa.InterpolationMode = InterpolationMode.HighQualityBicubic;
	}

	public void x5152a5707921c783(float x9bdeb785c5aca5b5)
	{
		xbc2692af206697aa.ScaleTransform(x9bdeb785c5aca5b5, x9bdeb785c5aca5b5);
	}

	public void x7cfc143904bcbd0a(x26d9ecb4bdf0456d x6c50a99faab7d741, float x08db3aeabb253cb1, float x1e218ceaee1bb583, float x9b0739496f8b5475, float x4d5aabc7a55b12ba)
	{
		using Brush brush = new SolidBrush(x6c50a99faab7d741.xc7656a130b2889c7());
		xbc2692af206697aa.FillRectangle(brush, 0f, 0f, x9b0739496f8b5475, x4d5aabc7a55b12ba);
	}

	public Graphics x0c16bcbc7d053d08()
	{
		return xbc2692af206697aa;
	}
}
