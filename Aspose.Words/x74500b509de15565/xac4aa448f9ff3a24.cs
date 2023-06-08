using System;
using System.Drawing;
using xa7850104c8d8c135;

namespace x74500b509de15565;

internal class xac4aa448f9ff3a24 : xe16786b87ff7610f
{
	private readonly SizeF x3a63ba73591fba53;

	private readonly float x2d1c271174d2f5d5;

	private readonly float xc01fd179bbea222c;

	public xac4aa448f9ff3a24(SizeF deviceSizePixels, float horizontalResolution, float verticalResolution)
	{
		x3a63ba73591fba53 = deviceSizePixels;
		x2d1c271174d2f5d5 = horizontalResolution;
		xc01fd179bbea222c = verticalResolution;
		x03025495f889f38a = x66ec63675332b85f.xf9ad6fb78355fe13;
		SetTextExtents();
	}

	protected override void SetTextExtents()
	{
		x564804cd3b6ee228 = new SizeF(1f, 1f);
		x6009175532baa42a = new SizeF(1f, 1f);
	}

	protected override void SetLoMetricExtents()
	{
		x64c8b2cbf0cb1178(0.003937008f);
	}

	protected override void SetHiMetricExtents()
	{
		x64c8b2cbf0cb1178(0.0003937008f);
	}

	protected override void SetLoEnglishExtents()
	{
		x64c8b2cbf0cb1178(0.01f);
	}

	protected override void SetHiEnglishExtents()
	{
		x64c8b2cbf0cb1178(0.001f);
	}

	protected override void SetTwipsExtents()
	{
		x64c8b2cbf0cb1178(0.00069444446f);
	}

	private void x64c8b2cbf0cb1178(float x43fad977bb367ffb)
	{
		x564804cd3b6ee228 = new SizeF(x3a63ba73591fba53.Width, 0f - x3a63ba73591fba53.Height);
		x6009175532baa42a = new SizeF(x3a63ba73591fba53.Width / x2d1c271174d2f5d5 / x43fad977bb367ffb, x3a63ba73591fba53.Height / xc01fd179bbea222c / x43fad977bb367ffb);
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

	public override void SetViewportExt(SizeF ext)
	{
		switch (x03025495f889f38a)
		{
		case x66ec63675332b85f.x8a4bf7f1843beb34:
			x48b9f4ffa68cfe81(ext);
			break;
		case x66ec63675332b85f.x9354757b4c8bb85e:
			x564804cd3b6ee228 = ext;
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
		x6009175532baa42a = xfdc547e6503d493e;
		x48b9f4ffa68cfe81(x564804cd3b6ee228);
	}

	private void x48b9f4ffa68cfe81(SizeF xfdc547e6503d493e)
	{
		float num = Math.Abs(x6009175532baa42a.Width / x6009175532baa42a.Height);
		float num2 = Math.Abs(xfdc547e6503d493e.Width / xfdc547e6503d493e.Height);
		x564804cd3b6ee228 = ((num2 < num) ? new SizeF(xfdc547e6503d493e.Width, (float)Math.Sign(xfdc547e6503d493e.Height) * Math.Abs(xfdc547e6503d493e.Width) / num) : new SizeF((float)Math.Sign(xfdc547e6503d493e.Width) * Math.Abs(xfdc547e6503d493e.Height) * num, xfdc547e6503d493e.Height));
	}

	public override void SetWindowOrg(PointF org)
	{
		x0ac564605ece2b81 = org;
	}

	public override void SetViewportOrg(PointF org)
	{
		xc0142498fd3a1ab7 = org;
	}
}
