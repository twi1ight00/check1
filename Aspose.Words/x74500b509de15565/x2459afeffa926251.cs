using System;
using System.Drawing;
using xa7850104c8d8c135;

namespace x74500b509de15565;

internal class x2459afeffa926251 : xe16786b87ff7610f
{
	private SizeF x3a63ba73591fba53;

	private readonly float xc6564baeee70c94b;

	private readonly float x378e77e8a24bf149;

	public x2459afeffa926251(SizeF deviceSizePixels, PointF initialOrg, SizeF initialExt, float horizontalResolutionScaleFactor, float verticalResolutionScaleFactor)
	{
		x03025495f889f38a = x66ec63675332b85f.x9354757b4c8bb85e;
		x6009175532baa42a = initialExt;
		x564804cd3b6ee228 = initialExt;
		x0ac564605ece2b81 = initialOrg;
		xc0142498fd3a1ab7 = initialOrg;
		x3a63ba73591fba53 = deviceSizePixels;
		xc6564baeee70c94b = horizontalResolutionScaleFactor;
		x378e77e8a24bf149 = verticalResolutionScaleFactor;
	}

	protected override void SetTextExtents()
	{
		x564804cd3b6ee228 = new SizeF(1f, 1f);
		x6009175532baa42a = new SizeF(1f, 1f);
		xf1f1372ea85b1000();
	}

	protected override void SetLoMetricExtents()
	{
		x64c8b2cbf0cb1178(0.28346458f);
	}

	protected override void SetHiMetricExtents()
	{
		x64c8b2cbf0cb1178(0.028346457f);
	}

	protected override void SetLoEnglishExtents()
	{
		x64c8b2cbf0cb1178(0.71999997f);
	}

	protected override void SetHiEnglishExtents()
	{
		x64c8b2cbf0cb1178(0.072000004f);
	}

	protected override void SetTwipsExtents()
	{
		x64c8b2cbf0cb1178(0.05f);
	}

	private void x64c8b2cbf0cb1178(float x700d14398a449f25)
	{
		x564804cd3b6ee228 = new SizeF(x3a63ba73591fba53.Width, 0f - x3a63ba73591fba53.Height);
		x6009175532baa42a = new SizeF(x3a63ba73591fba53.Width / x700d14398a449f25, x3a63ba73591fba53.Height / x700d14398a449f25);
		xf1f1372ea85b1000();
	}

	private void xf1f1372ea85b1000()
	{
		x564804cd3b6ee228 = new SizeF(x564804cd3b6ee228.Width * xc6564baeee70c94b, x564804cd3b6ee228.Height * x378e77e8a24bf149);
	}

	public override void SetWindowExt(SizeF ext)
	{
		switch (x03025495f889f38a)
		{
		case x66ec63675332b85f.x8a4bf7f1843beb34:
			xfc910f8728709519(ext);
			break;
		case x66ec63675332b85f.x9354757b4c8bb85e:
			x6009175532baa42a = ext;
			break;
		case x66ec63675332b85f.xf9ad6fb78355fe13:
		case x66ec63675332b85f.xc24def7833757c3c:
		case x66ec63675332b85f.xf87cded8855aa1e7:
		case x66ec63675332b85f.x4e64dea1df7ca8b0:
		case x66ec63675332b85f.x47f1627d7e6a561a:
		case x66ec63675332b85f.x45e95ef12ed10838:
			break;
		}
	}

	private void xfc910f8728709519(SizeF xfdc547e6503d493e)
	{
		float num = Math.Abs(xfdc547e6503d493e.Width / xfdc547e6503d493e.Height);
		float num2 = Math.Abs(x564804cd3b6ee228.Width / x564804cd3b6ee228.Height);
		x6009175532baa42a = ((num2 < num) ? new SizeF(xfdc547e6503d493e.Width, (float)Math.Sign(xfdc547e6503d493e.Height) * Math.Abs(xfdc547e6503d493e.Width) / num2) : new SizeF((float)Math.Sign(xfdc547e6503d493e.Width) * Math.Abs(xfdc547e6503d493e.Height) * num2, xfdc547e6503d493e.Height));
	}

	public override void SetViewportExt(SizeF ext)
	{
	}

	public override void ScaleViewportExt(x008aeca5918dcf49 scaleFactors)
	{
		switch (x03025495f889f38a)
		{
		case x66ec63675332b85f.x8a4bf7f1843beb34:
			x04be8974e404af89(scaleFactors);
			break;
		case x66ec63675332b85f.x9354757b4c8bb85e:
			x564804cd3b6ee228 = scaleFactors.x858aeb69ed4ea256(x564804cd3b6ee228);
			break;
		case x66ec63675332b85f.xf9ad6fb78355fe13:
		case x66ec63675332b85f.xc24def7833757c3c:
		case x66ec63675332b85f.xf87cded8855aa1e7:
		case x66ec63675332b85f.x4e64dea1df7ca8b0:
		case x66ec63675332b85f.x47f1627d7e6a561a:
		case x66ec63675332b85f.x45e95ef12ed10838:
			break;
		}
	}

	private void x04be8974e404af89(x008aeca5918dcf49 x1f7247e457aef2fb)
	{
		x564804cd3b6ee228 = x1f7247e457aef2fb.x858aeb69ed4ea256(x564804cd3b6ee228);
		xfc910f8728709519(x6009175532baa42a);
	}

	public override void SetWindowOrg(PointF org)
	{
		x0ac564605ece2b81 = org;
	}

	public override void SetViewportOrg(PointF org)
	{
	}
}
