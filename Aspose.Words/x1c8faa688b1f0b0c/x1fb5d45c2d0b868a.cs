using System;
using System.Drawing;
using x6c95d9cf46ff5f25;

namespace x1c8faa688b1f0b0c;

internal class x1fb5d45c2d0b868a
{
	private const double xcf5de9696d7ee7a3 = 45.0;

	private PointF xc539d78cbe7328ff = default(PointF);

	private SizeF x3b77a41bd57164d6 = default(SizeF);

	private double x0c596d5805c971d8;

	private double xed31a5b43d760843;

	public PointF xab07b26048f600ba
	{
		get
		{
			return xc539d78cbe7328ff;
		}
		set
		{
			xc539d78cbe7328ff = value;
		}
	}

	public SizeF x437e3b626c0fdd43
	{
		get
		{
			return x3b77a41bd57164d6;
		}
		set
		{
			x3b77a41bd57164d6 = value;
		}
	}

	public double xba40a5b113d122a1
	{
		get
		{
			return x0c596d5805c971d8;
		}
		set
		{
			x0c596d5805c971d8 = value;
		}
	}

	public double xae49680937687932
	{
		get
		{
			return xed31a5b43d760843;
		}
		set
		{
			xed31a5b43d760843 = value;
		}
	}

	public SizeF xcda28b63e4d131de => new SizeF(x437e3b626c0fdd43.Width / 2f, x437e3b626c0fdd43.Height / 2f);

	public PointF x58d2ccae3c5cfd08 => new PointF(xab07b26048f600ba.X + xcda28b63e4d131de.Width, xab07b26048f600ba.Y + xcda28b63e4d131de.Height);

	public x1fb5d45c2d0b868a()
	{
	}

	public x1fb5d45c2d0b868a(RectangleF bounds, double startAngle, double sweepAngle)
	{
		xc539d78cbe7328ff = bounds.Location;
		x3b77a41bd57164d6 = bounds.Size;
		x0c596d5805c971d8 = startAngle;
		xed31a5b43d760843 = sweepAngle;
	}

	public x1fb5d45c2d0b868a(RectangleF bounds)
		: this(bounds, 0.0, 360.0)
	{
	}

	public PointF x7739898ad73de905()
	{
		return x8ce0efa97a0226ef(x15e971129fd80714.xcdc7b29a812dd7df(xba40a5b113d122a1));
	}

	public PointF x0f74da0eed3dd981()
	{
		return x8ce0efa97a0226ef(x15e971129fd80714.xcdc7b29a812dd7df(xba40a5b113d122a1 + xae49680937687932));
	}

	public x9fe47a4de491f4aa[] x1a10ab118b131ef0()
	{
		int num = (int)(Math.Abs(xae49680937687932) / 45.0);
		if (xae49680937687932 % 45.0 != 0.0)
		{
			num++;
		}
		num = Math.Min(num, 8);
		x9fe47a4de491f4aa[] array = new x9fe47a4de491f4aa[num];
		double num2 = xba40a5b113d122a1;
		double num3 = Math.Sign(xae49680937687932);
		for (int i = 0; i < num; i++)
		{
			double num4 = Math.Min(45.0, Math.Abs(xba40a5b113d122a1 + xae49680937687932 - num2));
			num4 *= num3;
			ref x9fe47a4de491f4aa reference = ref array[i];
			reference = x491d51970a2559e1(num2, num4);
			num2 += num4;
		}
		return array;
	}

	private x9fe47a4de491f4aa x491d51970a2559e1(double x32bf744f8e9a8c29, double x4b7a727a9fc82698)
	{
		x32bf744f8e9a8c29 = x15e971129fd80714.xcdc7b29a812dd7df(x32bf744f8e9a8c29);
		x4b7a727a9fc82698 = x15e971129fd80714.xcdc7b29a812dd7df(x4b7a727a9fc82698);
		double num = xddd07e9cd06c5a23(x32bf744f8e9a8c29);
		double num2 = xddd07e9cd06c5a23(x32bf744f8e9a8c29 + x4b7a727a9fc82698);
		double num3 = num2 - num;
		double a = num3 / 2.0;
		double num4 = Math.Sin(num3) * (Math.Sqrt(4.0 + 3.0 * Math.Pow(Math.Tan(a), 2.0)) - 1.0) / 3.0;
		x9fe47a4de491f4aa result = default(x9fe47a4de491f4aa);
		result.xaf4e0fbe61814cf5 = x8ce0efa97a0226ef(x32bf744f8e9a8c29);
		result.x2271dea312f4a835 = x8ce0efa97a0226ef(x32bf744f8e9a8c29 + x4b7a727a9fc82698);
		result.xc7cf0e43653f9c41 = new PointF((float)((double)result.xaf4e0fbe61814cf5.X - num4 * (double)xcda28b63e4d131de.Width * Math.Sin(num)), (float)((double)result.xaf4e0fbe61814cf5.Y + num4 * (double)xcda28b63e4d131de.Height * Math.Cos(num)));
		result.xf52fe1c3cad11afd = new PointF((float)((double)result.x2271dea312f4a835.X + num4 * (double)xcda28b63e4d131de.Width * Math.Sin(num2)), (float)((double)result.x2271dea312f4a835.Y - num4 * (double)xcda28b63e4d131de.Height * Math.Cos(num2)));
		return result;
	}

	private PointF x8ce0efa97a0226ef(double xcb83cdf6822fc99d)
	{
		double num = xddd07e9cd06c5a23(xcb83cdf6822fc99d);
		return new PointF((float)((double)x58d2ccae3c5cfd08.X + (double)xcda28b63e4d131de.Width * Math.Cos(num)), (float)((double)x58d2ccae3c5cfd08.Y + (double)xcda28b63e4d131de.Height * Math.Sin(num)));
	}

	private double xddd07e9cd06c5a23(double xcb83cdf6822fc99d)
	{
		return Math.Atan2(1.0 / (double)xcda28b63e4d131de.Height * Math.Sin(xcb83cdf6822fc99d), 1.0 / (double)xcda28b63e4d131de.Width * Math.Cos(xcb83cdf6822fc99d));
	}
}
