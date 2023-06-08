using System.Drawing;
using x4adf554d20d941a6;
using x6c95d9cf46ff5f25;

namespace x59d6a4fc5007b7a4;

internal class x24007e5c985fb52a : xb850ecb8335a2e09
{
	private readonly xc7f90d9c7c51cede x277a8e7797009ec7;

	internal override float x72d92bd1aff02e37
	{
		get
		{
			if (x9fb0e9c0b1bdc4b3 == null)
			{
				return 0f;
			}
			return x4574ea26106f0edb.xc96d70553223ee04(x9fb0e9c0b1bdc4b3.x8df91a2f90079e88);
		}
	}

	internal override float xdc1bf80853046136
	{
		get
		{
			if (x9fb0e9c0b1bdc4b3 == null)
			{
				return 0f;
			}
			return x4574ea26106f0edb.xc96d70553223ee04(x9fb0e9c0b1bdc4b3.xdc1bf80853046136);
		}
	}

	internal override float xe360b1885d8d4a41
	{
		get
		{
			if (x9fb0e9c0b1bdc4b3 == null)
			{
				return 0f;
			}
			return x4574ea26106f0edb.xc96d70553223ee04(x9fb0e9c0b1bdc4b3.xc821290d7ecc08bf);
		}
	}

	internal override float xb0f146032f47c24e
	{
		get
		{
			if (x9fb0e9c0b1bdc4b3 == null)
			{
				return 0f;
			}
			return x4574ea26106f0edb.xc96d70553223ee04(x9fb0e9c0b1bdc4b3.xb0f146032f47c24e);
		}
	}

	internal override RectangleF x0e1bf8242ad10272 => new RectangleF(0f - x72d92bd1aff02e37, 0f, x4574ea26106f0edb.xc96d70553223ee04(x277a8e7797009ec7.xdc1bf80853046136), xb0f146032f47c24e);

	internal x24007e5c985fb52a(x398b3bd0acd94b61 part, xc7f90d9c7c51cede page)
		: base(part)
	{
		x277a8e7797009ec7 = page;
	}

	internal override void x7012609bcdb39574(x3adba2572f6b9747 x672ff13faf031f3d)
	{
		if (x9fb0e9c0b1bdc4b3 != null)
		{
			x46bd7081dec08b8e x46bd7081dec08b8e = (x46bd7081dec08b8e)x9fb0e9c0b1bdc4b3;
			x672ff13faf031f3d.xa5ea669db02dc54a(this);
			xb850ecb8335a2e09.xa246eb87eda7b55d(x672ff13faf031f3d, x46bd7081dec08b8e.x8b8a0a04b3aeaf3a);
			x672ff13faf031f3d.xd5a9dc0e56d9d1fb(this);
		}
	}
}
