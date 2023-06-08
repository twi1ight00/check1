using System;
using System.Drawing;
using Aspose.Words;
using x4adf554d20d941a6;
using x6c95d9cf46ff5f25;

namespace x59d6a4fc5007b7a4;

internal class x512b9a381ad7cd9c : xb850ecb8335a2e09
{
	private float x871b04f44d95866a = float.MinValue;

	private readonly xc7f90d9c7c51cede x277a8e7797009ec7;

	internal float x7781272e2d3106cf
	{
		get
		{
			if (0f > x871b04f44d95866a)
			{
				x871b04f44d95866a = x4574ea26106f0edb.xc96d70553223ee04(x852fe8bb5ac31098.xd1c4856f813b427c((x852fe8bb5ac31098)x9fb0e9c0b1bdc4b3));
			}
			return x871b04f44d95866a;
		}
	}

	internal override RectangleF x0e1bf8242ad10272
	{
		get
		{
			float width = x4574ea26106f0edb.xc96d70553223ee04(x277a8e7797009ec7.xdc1bf80853046136);
			x852fe8bb5ac31098 x852fe8bb5ac = (x852fe8bb5ac31098)x9fb0e9c0b1bdc4b3;
			float num = xb0f146032f47c24e;
			if (x852fe8bb5ac.x7e2e5dd40daabc3b is x694f001896973fe3)
			{
				x694f001896973fe3 x694f001896973fe = (x694f001896973fe3)x852fe8bb5ac.x7e2e5dd40daabc3b;
				int x7fe0bd4f21a = x694f001896973fe.x7fe0bd4f21a85330;
				int num2 = 0;
				x86accec882b7012a x86accec882b7012a = x694f001896973fe.x96ac59f61797f5b9;
				while (x86accec882b7012a != null && !x86accec882b7012a.xfdc6650195492419)
				{
					int x0b5855089a074d = x86accec882b7012a.xc5464084edc8e226.xdfd0c9de0b4aa96a.xb70a9d14469748bf.xc9cd83e7ff351ae8(BorderType.Bottom, x86accec882b7012a).x0b5855089a074d93;
					num2 = Math.Max(num2, x0b5855089a074d);
					x86accec882b7012a = (x86accec882b7012a)x86accec882b7012a.xf432ece93e450408();
				}
				int num3 = Math.Max(0, num2 - x7fe0bd4f21a);
				if (num3 > 0)
				{
					num += x4574ea26106f0edb.xc96d70553223ee04(num3);
				}
			}
			return new RectangleF(0f - x72d92bd1aff02e37, 0f, width, num);
		}
	}

	internal x512b9a381ad7cd9c(x398b3bd0acd94b61 part, xc7f90d9c7c51cede page)
		: base(part)
	{
		x277a8e7797009ec7 = page;
	}

	internal override void x7012609bcdb39574(x3adba2572f6b9747 x672ff13faf031f3d)
	{
		x852fe8bb5ac31098 x852fe8bb5ac = (x852fe8bb5ac31098)x9fb0e9c0b1bdc4b3;
		x672ff13faf031f3d.x8ed9c1094d826c2f(this);
		x852fe8bb5ac31098[] array = x852fe8bb5ac.x1981d893a47031a5();
		x852fe8bb5ac31098[] array2 = array;
		foreach (x852fe8bb5ac31098 part in array2)
		{
			new xc6ae5bf3fc6721e2(part, x9fb0e9c0b1bdc4b3.x2206903f9421fd4b(), x7781272e2d3106cf).x7012609bcdb39574(x672ff13faf031f3d);
		}
		x672ff13faf031f3d.xd367b0854e02449e(this);
	}
}
