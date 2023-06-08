using System;
using System.Drawing;
using Aspose.Words.Fields;
using x13f1efc79617a47b;
using x4adf554d20d941a6;
using x6c95d9cf46ff5f25;
using xfbd1009a0cbb9842;

namespace x59d6a4fc5007b7a4;

internal class x988c1cad471a514c : x038d2057eb729fcf
{
	internal SizeF x437e3b626c0fdd43
	{
		get
		{
			switch (xd438a3a8968e57e1.xdda013621290d582)
			{
			case xdda013621290d582.xfd2f38e457ba1955:
			{
				int num = ((x56410a8dd70087c5)x9fb0e9c0b1bdc4b3).x705ed5f9769744e5.x437e3b626c0fdd43;
				return x4574ea26106f0edb.xc96d70553223ee04(new Size(num, num));
			}
			case xdda013621290d582.x09e38cfc94ebc64d:
			case xdda013621290d582.xca07ebdb4698a889:
			{
				xf6937c72cebe4ad1 xf6937c72cebe4ad = (xf6937c72cebe4ad1)x9fb0e9c0b1bdc4b3.xc255c495fd9232ca;
				x5c28fdcd27dee7d9 xa6315bf377f6364c = ((xeb20d9a559fa99ca)x9fb0e9c0b1bdc4b3).x8ebdfaa20182b73c();
				return x4574ea26106f0edb.xc96d70553223ee04(new Size(xe283b020dc20b632(xa6315bf377f6364c, xf6937c72cebe4ad), xf6937c72cebe4ad.xb0f146032f47c24e));
			}
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hjidnkpdhkgehknefkefkklfojcgnejgajahgjhhgjohoifiodmibidjbikjkhbkohikdhpkmcglnhnlphemdhlmfgcnlcjn", 1540634690)));
			}
		}
	}

	internal override PointF xc22eade24b085d91
	{
		get
		{
			if (x831916008bfc3ed7 == null)
			{
				Point point = x9fb0e9c0b1bdc4b3.x588d7683a6d1fbd5();
				x831916008bfc3ed7 = new PointF(x4574ea26106f0edb.xc96d70553223ee04(point.X), x4574ea26106f0edb.xc96d70553223ee04(point.Y + x9fb0e9c0b1bdc4b3.xb0f146032f47c24e));
			}
			return (PointF)x831916008bfc3ed7;
		}
	}

	internal FormField xd438a3a8968e57e1 => ((xeb20d9a559fa99ca)x9fb0e9c0b1bdc4b3).xd438a3a8968e57e1;

	internal x988c1cad471a514c(x398b3bd0acd94b61 part)
		: base(part)
	{
	}

	internal override void x7012609bcdb39574(x3adba2572f6b9747 x672ff13faf031f3d)
	{
		x672ff13faf031f3d.xeb3f33fe08e9a2e6(this);
	}

	private static int xe283b020dc20b632(x5c28fdcd27dee7d9 xa6315bf377f6364c, xf6937c72cebe4ad1 xd3311d815ca25f02)
	{
		x56410a8dd70087c5 x61712f0b4f5455af = xa6315bf377f6364c.x275cb4c2185b2177.x61712f0b4f5455af;
		x5c28fdcd27dee7d9 x70ff891026cb = xa6315bf377f6364c.x70ff891026cb8704;
		x56410a8dd70087c5 x56410a8dd70087c = x61712f0b4f5455af;
		while (true)
		{
			x56410a8dd70087c5 xbd2e6df53b2331ee = x56410a8dd70087c.xbd2e6df53b2331ee;
			if (xbd2e6df53b2331ee == null || xbd2e6df53b2331ee == x70ff891026cb)
			{
				break;
			}
			x56410a8dd70087c = xbd2e6df53b2331ee;
		}
		return x56410a8dd70087c.x419ba17a5322627b - x61712f0b4f5455af.x8df91a2f90079e88;
	}
}
