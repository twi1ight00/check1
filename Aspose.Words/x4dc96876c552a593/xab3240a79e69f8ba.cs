using x6b8130194ad714f7;
using x7cd71466ce904867;

namespace x4dc96876c552a593;

internal class xab3240a79e69f8ba : x7e58bc4f68c02a4e
{
	private x55c6a66cc28d5b86 x4574aea041dd835f = x55c6a66cc28d5b86.x220dcfbc81260c16(1.0);

	public x55c6a66cc28d5b86 xd2f68ee6f47e9dfb
	{
		get
		{
			return x4574aea041dd835f;
		}
		set
		{
			x4574aea041dd835f = value;
		}
	}

	public double x77463c049b3fadfb(xf5c6aa532fe023d4 x31e6518f5e08db6c)
	{
		double num = 0.0;
		foreach (x62d3f1339ed0fbcf item in x31e6518f5e08db6c.x0c560ee4a7223d6d)
		{
			if (num < item.x8fb6a748ef46ad8f.x70c328f6f2e77d76.xb6525833a9058091)
			{
				num = item.x8fb6a748ef46ad8f.x70c328f6f2e77d76.xb6525833a9058091;
			}
		}
		return num * xd2f68ee6f47e9dfb.x71c5078172d72420;
	}

	public x5725b63233877cf4 x25ebf13b3a18c04f(x5725b63233877cf4 x23e600cf55dca486)
	{
		x7cd9263b5da819f7 x7cd9263b5da819f = new x7cd9263b5da819f7();
		x7cd9263b5da819f.x3f80ed349f729542 = x23e600cf55dca486.x3f80ed349f729542 * xd2f68ee6f47e9dfb.x71c5078172d72420;
		x7cd9263b5da819f.xc9f7bec53c29c691 = x23e600cf55dca486.xc9f7bec53c29c691 * xd2f68ee6f47e9dfb.x71c5078172d72420;
		x7cd9263b5da819f.x84bbacdc1fc0efd2 = x23e600cf55dca486.x84bbacdc1fc0efd2 * xd2f68ee6f47e9dfb.x71c5078172d72420;
		return x7cd9263b5da819f;
	}
}
