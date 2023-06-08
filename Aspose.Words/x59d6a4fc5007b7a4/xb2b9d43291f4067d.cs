using System.Drawing;
using Aspose.Words;
using x4adf554d20d941a6;
using x6c95d9cf46ff5f25;

namespace x59d6a4fc5007b7a4;

internal sealed class xb2b9d43291f4067d : xb850ecb8335a2e09
{
	private x526c0da08ed0e498 xb58048aaa04b750a;

	internal override RectangleF x0e1bf8242ad10272
	{
		get
		{
			RectangleF rectangleF = xa3a992e8cf81dabe.xe6cffb3d72baa311(x11db8fc7f469a2fc);
			return new RectangleF(rectangleF.X - 1f, rectangleF.Y - 1f, rectangleF.Width + 2f, rectangleF.Height + 2f);
		}
	}

	internal bool x01bc5527a261f633 => x11db8fc7f469a2fc.xc5464084edc8e226.x01bc5527a261f633;

	internal Shading x554aca059bdf6d48
	{
		get
		{
			x5709acc7200773ff x5709acc7200773ff = x11db8fc7f469a2fc.xc5464084edc8e226.xdfd0c9de0b4aa96a.x554aca059bdf6d48;
			Shading shading = new Shading();
			shading.xc290f60df004e384 = x5709acc7200773ff.x8fdbd80e8da6b0e6;
			shading.x0e18178ac4b2272f = x5709acc7200773ff.x83729c7ebf48ae24;
			shading.Texture = x5709acc7200773ff.x7b6a6d281546db99;
			return shading;
		}
	}

	internal RectangleF x8d3e220b8546945e
	{
		get
		{
			RectangleF rectangleF = xa3a992e8cf81dabe.xe6cffb3d72baa311(x11db8fc7f469a2fc);
			return new RectangleF(rectangleF.X + x72d92bd1aff02e37, rectangleF.Y + xe360b1885d8d4a41, rectangleF.Width, rectangleF.Height);
		}
	}

	internal x86accec882b7012a x11db8fc7f469a2fc => (x86accec882b7012a)x9fb0e9c0b1bdc4b3;

	internal x526c0da08ed0e498 xe6f52e090163d45e => xb58048aaa04b750a;

	internal bool x6b476d1cf3ec3a3d
	{
		get
		{
			if (xe6f52e090163d45e != x526c0da08ed0e498.xc236b23da7f61ea5)
			{
				return xe6f52e090163d45e == x526c0da08ed0e498.x3f5e31045e967a38;
			}
			return true;
		}
	}

	internal bool xb12567c8f0a05a2b
	{
		get
		{
			switch (xe6f52e090163d45e)
			{
			case x526c0da08ed0e498.xc236b23da7f61ea5:
			case x526c0da08ed0e498.x4e0b180a32cc9572:
			case x526c0da08ed0e498.xc922d5cb05b5c111:
				return true;
			default:
				return false;
			}
		}
	}

	internal xb2b9d43291f4067d(x86accec882b7012a part)
		: base(part)
	{
		xd5d4fc544204002e();
	}

	internal xb2b9d43291f4067d(x86accec882b7012a shared, x86accec882b7012a sink)
		: base(shared)
	{
		xb58048aaa04b750a = x526c0da08ed0e498.x3f5e31045e967a38;
		x72d92bd1aff02e37 -= x4574ea26106f0edb.xc96d70553223ee04(sink.x798272c9805cc00e.x8df91a2f90079e88 - x9fb0e9c0b1bdc4b3.xc255c495fd9232ca.x8df91a2f90079e88);
		xe360b1885d8d4a41 -= x4574ea26106f0edb.xc96d70553223ee04(sink.x798272c9805cc00e.xc821290d7ecc08bf - x9fb0e9c0b1bdc4b3.xc255c495fd9232ca.xc821290d7ecc08bf);
	}

	internal override void x7012609bcdb39574(x3adba2572f6b9747 x672ff13faf031f3d)
	{
		x672ff13faf031f3d.x0d919b3be4833815(this);
		if (x6b476d1cf3ec3a3d)
		{
			xb850ecb8335a2e09.xa246eb87eda7b55d(x672ff13faf031f3d, x11db8fc7f469a2fc.x8b8a0a04b3aeaf3a);
			xb850ecb8335a2e09.xa0d387f9dc55e84f(x672ff13faf031f3d, x11db8fc7f469a2fc.xf9d5944b191eb276(x5aa7d09b258e0f23: false));
		}
		x672ff13faf031f3d.x67c463ab8a7d7a8e(this);
	}

	internal static Border x9f6bbfd6a9013899(x86accec882b7012a xb4144741a65a3e9a, BorderType xe6e655492739f7d2, Border xcf4d59ab018ff9c4)
	{
		x56b4eac69b5fa65b xc5464084edc8e = xb4144741a65a3e9a.xc5464084edc8e226;
		if (xcf4d59ab018ff9c4 != null)
		{
			return xcf4d59ab018ff9c4;
		}
		xf2fec9a4212c9f90 xb70a9d14469748bf = xc5464084edc8e.xdfd0c9de0b4aa96a.xb70a9d14469748bf;
		if (xe6e655492739f7d2 == BorderType.Top || xe6e655492739f7d2 == BorderType.Bottom)
		{
			xc8e01097217ac9d2 x94aec03cf2ae750b = xb4144741a65a3e9a.xc5464084edc8e226.xdfd0c9de0b4aa96a.xb70a9d14469748bf.xc9cd83e7ff351ae8(xe6e655492739f7d2, xb4144741a65a3e9a);
			return x3557aa8566455ba9.x9f6bbfd6a9013899(x94aec03cf2ae750b);
		}
		return x3557aa8566455ba9.x9f6bbfd6a9013899(xb70a9d14469748bf.get_xe6d4b1b411ed94b5(xe6e655492739f7d2));
	}

	internal static RectangleF x04a13814ebb01700(x86accec882b7012a xb4144741a65a3e9a)
	{
		RectangleF rectangleF = xa3a992e8cf81dabe.x1049a67c4c918fe0(xb4144741a65a3e9a);
		xe4d6d8acaf4e81ea xe4d6d8acaf4e81ea2 = new xe4d6d8acaf4e81ea(xb4144741a65a3e9a.x798272c9805cc00e);
		float num = x4574ea26106f0edb.xc96d70553223ee04(xb4144741a65a3e9a.x8df91a2f90079e88) + xe4d6d8acaf4e81ea2.x72d92bd1aff02e37;
		float num2 = x4574ea26106f0edb.xc96d70553223ee04(xb4144741a65a3e9a.xc821290d7ecc08bf) + xe4d6d8acaf4e81ea2.xe360b1885d8d4a41;
		return new RectangleF(rectangleF.X + num, rectangleF.Y + num2, rectangleF.Width, rectangleF.Height);
	}

	private void xd5d4fc544204002e()
	{
		switch (x11db8fc7f469a2fc.xc5464084edc8e226.x6c68e8efd3a92e85)
		{
		case x6c68e8efd3a92e85.x4d0b9d4447ba7566:
			xb58048aaa04b750a = x526c0da08ed0e498.xc236b23da7f61ea5;
			break;
		case x6c68e8efd3a92e85.x38ced5a01a389303:
			xb58048aaa04b750a = (x11db8fc7f469a2fc.xc255c495fd9232ca.xd40b2068334ae37c ? x526c0da08ed0e498.xc236b23da7f61ea5 : x526c0da08ed0e498.x4e0b180a32cc9572);
			break;
		case x6c68e8efd3a92e85.x83e8265cdba541b5:
			xb58048aaa04b750a = (x11db8fc7f469a2fc.xc255c495fd9232ca.xd40b2068334ae37c ? x526c0da08ed0e498.xc922d5cb05b5c111 : x526c0da08ed0e498.x4e0b180a32cc9572);
			break;
		case x6c68e8efd3a92e85.xed3e432f7c9bf846:
			xb58048aaa04b750a = x526c0da08ed0e498.xc922d5cb05b5c111;
			break;
		}
	}
}
