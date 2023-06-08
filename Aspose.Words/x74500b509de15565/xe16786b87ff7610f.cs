using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xa7850104c8d8c135;

namespace x74500b509de15565;

internal abstract class xe16786b87ff7610f
{
	protected x66ec63675332b85f x03025495f889f38a;

	protected PointF x0ac564605ece2b81;

	protected SizeF x6009175532baa42a;

	protected PointF xc0142498fd3a1ab7;

	protected SizeF x564804cd3b6ee228;

	protected x54366fa5f75a02f7 xb2c6d058f33b5ab3;

	public x54366fa5f75a02f7 xaccac17571a8d9fa
	{
		get
		{
			x54366fa5f75a02f7 x54366fa5f75a02f = x4511ad86c20aa065();
			x54366fa5f75a02f.x490e30087768649f(xb2c6d058f33b5ab3, MatrixOrder.Prepend);
			return x54366fa5f75a02f;
		}
	}

	protected xe16786b87ff7610f()
	{
		x0ac564605ece2b81 = default(PointF);
		xc0142498fd3a1ab7 = default(PointF);
		xb2c6d058f33b5ab3 = new x54366fa5f75a02f7();
	}

	public xe16786b87ff7610f x8b61531c8ea35b85()
	{
		xe16786b87ff7610f xe16786b87ff7610f2 = (xe16786b87ff7610f)MemberwiseClone();
		if (xb2c6d058f33b5ab3 != null)
		{
			xe16786b87ff7610f2.xb2c6d058f33b5ab3 = xb2c6d058f33b5ab3.x8b61531c8ea35b85();
		}
		return xe16786b87ff7610f2;
	}

	public virtual void SetMapMode(x66ec63675332b85f mapMode)
	{
		if (x03025495f889f38a != mapMode)
		{
			x03025495f889f38a = mapMode;
			switch (x03025495f889f38a)
			{
			case x66ec63675332b85f.xf9ad6fb78355fe13:
				SetTextExtents();
				break;
			case x66ec63675332b85f.xc24def7833757c3c:
				SetLoMetricExtents();
				break;
			case x66ec63675332b85f.xf87cded8855aa1e7:
				SetHiMetricExtents();
				break;
			case x66ec63675332b85f.x4e64dea1df7ca8b0:
				SetLoEnglishExtents();
				break;
			case x66ec63675332b85f.x47f1627d7e6a561a:
				SetHiEnglishExtents();
				break;
			case x66ec63675332b85f.x45e95ef12ed10838:
				SetTwipsExtents();
				break;
			case x66ec63675332b85f.x8a4bf7f1843beb34:
				SetLoMetricExtents();
				break;
			default:
				throw new InvalidOperationException("Unexpected map mode.");
			case x66ec63675332b85f.x9354757b4c8bb85e:
				break;
			}
		}
	}

	protected abstract void SetTwipsExtents();

	protected abstract void SetHiEnglishExtents();

	protected abstract void SetLoEnglishExtents();

	protected abstract void SetHiMetricExtents();

	protected abstract void SetLoMetricExtents();

	protected abstract void SetTextExtents();

	public abstract void SetWindowExt(SizeF ext);

	public abstract void SetViewportExt(SizeF ext);

	public abstract void SetWindowOrg(PointF org);

	public abstract void SetViewportOrg(PointF org);

	public virtual void OffsetWindowOrg(SizeF offset)
	{
		SetWindowOrg(x0d299f323d241756.x7c91cffb7e0460c1(x0ac564605ece2b81, offset));
	}

	public virtual void OffsetViewportOrg(SizeF offset)
	{
		SetViewportOrg(x0d299f323d241756.x7c91cffb7e0460c1(xc0142498fd3a1ab7, offset));
	}

	public virtual void ScaleWindowExt(x008aeca5918dcf49 scaleFactors)
	{
		SetWindowExt(scaleFactors.x858aeb69ed4ea256(x6009175532baa42a));
	}

	public virtual void ScaleViewportExt(x008aeca5918dcf49 scaleFactors)
	{
		SetViewportExt(scaleFactors.x858aeb69ed4ea256(x564804cd3b6ee228));
	}

	public void x3ef26574dd6a5679(x54366fa5f75a02f7 xa801ccff44b0c7eb, x0ccf5a71249ef4a6 xa4aa8b4150b11435)
	{
		switch (xa4aa8b4150b11435)
		{
		case x0ccf5a71249ef4a6.xd7dde027c81bb9a6:
			xb2c6d058f33b5ab3 = new x54366fa5f75a02f7();
			break;
		case x0ccf5a71249ef4a6.x9dcbb68afa7678b9:
			xb2c6d058f33b5ab3.x490e30087768649f(xa801ccff44b0c7eb, MatrixOrder.Prepend);
			break;
		case x0ccf5a71249ef4a6.x73ec591f716ac6c5:
			xb2c6d058f33b5ab3.x490e30087768649f(xa801ccff44b0c7eb, MatrixOrder.Append);
			break;
		case x0ccf5a71249ef4a6.x90fda48194fc6b9a:
			xb2c6d058f33b5ab3 = xa801ccff44b0c7eb;
			break;
		}
	}

	public RectangleF xc1af9161ab9d389b(RectangleF x26545669838eb36e)
	{
		return xaccac17571a8d9fa.xaccac17571a8d9fa(x26545669838eb36e);
	}

	public void xa4b699bd47eb7372(PointF[] x6fa2570084b2ad39)
	{
		xaccac17571a8d9fa.xa4b699bd47eb7372(x6fa2570084b2ad39);
	}

	public PointF x5c785f1d561da269(PointF x2f7096dac971d6ec)
	{
		return xaccac17571a8d9fa.x5c785f1d561da269(x2f7096dac971d6ec);
	}

	private x54366fa5f75a02f7 x4511ad86c20aa065()
	{
		x9b3f290a765150b6();
		float xb5c369f64ea369e = ((x6009175532baa42a.Width == 0f) ? 0f : (x564804cd3b6ee228.Width / x6009175532baa42a.Width));
		float x9b8af180a4e21ec = ((x6009175532baa42a.Height == 0f) ? 0f : (x564804cd3b6ee228.Height / x6009175532baa42a.Height));
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		x54366fa5f75a02f.xce92de628aa023cf(0f - x0ac564605ece2b81.X, 0f - x0ac564605ece2b81.Y, MatrixOrder.Append);
		x54366fa5f75a02f.x5152a5707921c783(xb5c369f64ea369e, x9b8af180a4e21ec, MatrixOrder.Append);
		x54366fa5f75a02f.xce92de628aa023cf(xc0142498fd3a1ab7.X, xc0142498fd3a1ab7.Y, MatrixOrder.Append);
		return x54366fa5f75a02f;
	}

	private void x9b3f290a765150b6()
	{
		if (x564804cd3b6ee228.Width == 0f)
		{
			throw new InvalidOperationException("Viewport width is invalid.");
		}
		if (x564804cd3b6ee228.Height == 0f)
		{
			throw new InvalidOperationException("Viewport height is invalid.");
		}
	}
}
