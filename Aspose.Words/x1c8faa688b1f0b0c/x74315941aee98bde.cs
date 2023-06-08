using System;
using System.Drawing;
using x6c95d9cf46ff5f25;

namespace x1c8faa688b1f0b0c;

internal class x74315941aee98bde
{
	public x1fb5d45c2d0b868a xda09af88ab899a50(RectangleF xda73fcb97c77d998, PointF x10aaa7cdfa38f254, PointF xca09b6c2b5b18485)
	{
		return xda09af88ab899a50(xda73fcb97c77d998, x10aaa7cdfa38f254, xca09b6c2b5b18485, x32b88b60e9aa3a79.x22fb78f4fe61ffbc);
	}

	public x1fb5d45c2d0b868a xda09af88ab899a50(RectangleF xda73fcb97c77d998, PointF x10aaa7cdfa38f254, PointF xca09b6c2b5b18485, x32b88b60e9aa3a79 x7c31d7d019b1fe6c)
	{
		SizeF sizeF = new SizeF(xda73fcb97c77d998.Width / 2f, xda73fcb97c77d998.Height / 2f);
		PointF pointF = new PointF(xda73fcb97c77d998.X + sizeF.Width, xda73fcb97c77d998.Y + sizeF.Height);
		double num = Math.Atan2(x10aaa7cdfa38f254.Y - pointF.Y, x10aaa7cdfa38f254.X - pointF.X);
		double xb04d8b9fae = Math.Atan2(xca09b6c2b5b18485.Y - pointF.Y, xca09b6c2b5b18485.X - pointF.X);
		double sweepAngle = xab0e5ca7787491d6(num, xb04d8b9fae, x7c31d7d019b1fe6c);
		num = x15e971129fd80714.xc9211137ad7bfa2a(num);
		return new x1fb5d45c2d0b868a(xda73fcb97c77d998, num, sweepAngle);
	}

	private double xab0e5ca7787491d6(double x32bf744f8e9a8c29, double xb04d8b9fae810646, x32b88b60e9aa3a79 x7c31d7d019b1fe6c)
	{
		double num = x2678abf91bce80f9(x32bf744f8e9a8c29, xb04d8b9fae810646, x7c31d7d019b1fe6c);
		if (num == 0.0)
		{
			return 360.0;
		}
		if (x7c31d7d019b1fe6c == x32b88b60e9aa3a79.x22fb78f4fe61ffbc)
		{
			num = xdb7af76cbd60982f(num);
		}
		return x15e971129fd80714.xc9211137ad7bfa2a(num);
	}

	private double xdb7af76cbd60982f(double xf7845a6fecd5afc3)
	{
		if (xf7845a6fecd5afc3 > Math.PI)
		{
			xf7845a6fecd5afc3 -= Math.PI * 2.0;
		}
		else if (xf7845a6fecd5afc3 < -Math.PI)
		{
			xf7845a6fecd5afc3 += Math.PI * 2.0;
		}
		return xf7845a6fecd5afc3;
	}

	private double x2678abf91bce80f9(double x32bf744f8e9a8c29, double xb04d8b9fae810646, x32b88b60e9aa3a79 x7c31d7d019b1fe6c)
	{
		switch (x7c31d7d019b1fe6c)
		{
		case x32b88b60e9aa3a79.x7ba7d24657083a90:
			if (xb04d8b9fae810646 < x32bf744f8e9a8c29)
			{
				xb04d8b9fae810646 += Math.PI * 2.0;
			}
			break;
		case x32b88b60e9aa3a79.x736f2df237d05c37:
			if (xb04d8b9fae810646 > x32bf744f8e9a8c29)
			{
				x32bf744f8e9a8c29 += Math.PI * 2.0;
			}
			break;
		}
		return xb04d8b9fae810646 - x32bf744f8e9a8c29;
	}
}
