using System.Drawing;
using x1c8faa688b1f0b0c;
using x4adf554d20d941a6;
using x6c95d9cf46ff5f25;

namespace x59d6a4fc5007b7a4;

internal class xe4d6d8acaf4e81ea : xb850ecb8335a2e09
{
	private Point x23ca4adefa538f1c = new Point(int.MinValue, int.MinValue);

	private xb8e7e788f6d59708 xbd5cebcf81e382bf;

	internal override float x72d92bd1aff02e37 => x4574ea26106f0edb.xc96d70553223ee04(xa19781cfbe8b4961.x8df91a2f90079e88 - x8bbac01b81a827fb.X);

	internal override float xe360b1885d8d4a41 => x4574ea26106f0edb.xc96d70553223ee04(xa19781cfbe8b4961.xc821290d7ecc08bf - x8bbac01b81a827fb.Y + xa19781cfbe8b4961.x147605d3f215e4c9.xd72444cc04207b76);

	internal bool x3224fba74054513c
	{
		get
		{
			if (xa19781cfbe8b4961.x957cd3867cc3a9f3 && !xa19781cfbe8b4961.x838c6c67b5953bb0.x133f2db9e5b5690d.x752cfab9af626fd5 && !xa19781cfbe8b4961.x838c6c67b5953bb0.xc0e56f2fca892328)
			{
				return !xa19781cfbe8b4961.x838c6c67b5953bb0.x768f9befb545345a.x0f709e8a26f5dccd;
			}
			return false;
		}
	}

	internal xb8e7e788f6d59708 x4bbd18967c469fa1
	{
		get
		{
			if (xbd5cebcf81e382bf == null)
			{
				Point xf671230c49fb86ad = new Point(0, xa19781cfbe8b4961.xc255c495fd9232ca.x3dcafc2d758260e1 - xa19781cfbe8b4961.xc821290d7ecc08bf);
				PointF xb9c2cfae130d = x4574ea26106f0edb.xc96d70553223ee04(xf671230c49fb86ad);
				xbd5cebcf81e382bf = xa19781cfbe8b4961.x838c6c67b5953bb0.x133f2db9e5b5690d.x68864d8ae2380262(xb9c2cfae130d);
			}
			return xbd5cebcf81e382bf;
		}
	}

	private x694f001896973fe3 xa19781cfbe8b4961 => (x694f001896973fe3)x9fb0e9c0b1bdc4b3;

	private Point x8bbac01b81a827fb
	{
		get
		{
			if (x23ca4adefa538f1c.X == int.MinValue)
			{
				x694f001896973fe3 x694f001896973fe = xa19781cfbe8b4961.xefa751568d49862e();
				x23ca4adefa538f1c = new Point(x694f001896973fe.x8df91a2f90079e88, x694f001896973fe.xc821290d7ecc08bf);
			}
			return x23ca4adefa538f1c;
		}
	}

	internal xe4d6d8acaf4e81ea(x398b3bd0acd94b61 part)
		: base(part)
	{
	}

	internal override void x7012609bcdb39574(x3adba2572f6b9747 x672ff13faf031f3d)
	{
		if (!(xb0f146032f47c24e <= 0f))
		{
			x672ff13faf031f3d.x81181dae89c9ea13(this);
			x8ff4741a766a2d93 x8ff4741a766a2d = x8ff4741a766a2d93.x0df886665b5be89e(xa19781cfbe8b4961);
			while (x8ff4741a766a2d.x47f176deff0d42e2())
			{
				xb2b9d43291f4067d xb2b9d43291f4067d2 = new xb2b9d43291f4067d((x86accec882b7012a)x8ff4741a766a2d.x35cfcea4890f4e7d);
				xb2b9d43291f4067d2.x7012609bcdb39574(x672ff13faf031f3d);
			}
			x672ff13faf031f3d.xd0fe4ce66ef350ed(this);
		}
	}
}
