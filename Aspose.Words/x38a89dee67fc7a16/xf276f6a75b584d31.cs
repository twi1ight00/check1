using System;
using x5794c252ba25e723;

namespace x38a89dee67fc7a16;

internal class xf276f6a75b584d31
{
	private readonly x26d9ecb4bdf0456d xb33853ea5867d6a8;

	private readonly x26d9ecb4bdf0456d x5dd3bd8e842376d5;

	public x26d9ecb4bdf0456d xdf863a776b239667 => xb33853ea5867d6a8;

	public x26d9ecb4bdf0456d xb07c4db017102b70 => x5dd3bd8e842376d5;

	public xf276f6a75b584d31(x26d9ecb4bdf0456d center, int range)
	{
		if (center == null || center.x7149c962c02931b3)
		{
			throw new ArgumentNullException("center");
		}
		xb33853ea5867d6a8 = new x26d9ecb4bdf0456d(Math.Max(center.xc613adc4330033f3 - range, 0), Math.Max(center.x26463655896fd90a - range, 0), Math.Max(center.x8e8f6cc6a0756b05 - range, 0));
		x5dd3bd8e842376d5 = new x26d9ecb4bdf0456d(Math.Min(center.xc613adc4330033f3 + range, 255), Math.Min(center.x26463655896fd90a + range, 255), Math.Min(center.x8e8f6cc6a0756b05 + range, 255));
	}

	public xf276f6a75b584d31(x26d9ecb4bdf0456d lowColor, x26d9ecb4bdf0456d highColor)
	{
		if (lowColor == null || lowColor.x7149c962c02931b3)
		{
			throw new ArgumentNullException("lowColor");
		}
		if (highColor == null || highColor.x7149c962c02931b3)
		{
			throw new ArgumentNullException("highColor");
		}
		xb33853ea5867d6a8 = lowColor;
		x5dd3bd8e842376d5 = highColor;
	}

	public bool x01be14848dc45cb8(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		return x01be14848dc45cb8(x6c50a99faab7d741.xc613adc4330033f3, x6c50a99faab7d741.x26463655896fd90a, x6c50a99faab7d741.x8e8f6cc6a0756b05);
	}

	public bool x01be14848dc45cb8(int xb55b340ae3a3e4e0, int x4b101060f4767186, int xe7ebe10fa44d8d49)
	{
		if (xb55b340ae3a3e4e0 >= xdf863a776b239667.xc613adc4330033f3 && xb55b340ae3a3e4e0 <= xb07c4db017102b70.xc613adc4330033f3 && x4b101060f4767186 >= xdf863a776b239667.x26463655896fd90a && x4b101060f4767186 <= xb07c4db017102b70.x26463655896fd90a && xe7ebe10fa44d8d49 >= xdf863a776b239667.x8e8f6cc6a0756b05)
		{
			return xe7ebe10fa44d8d49 <= xb07c4db017102b70.x8e8f6cc6a0756b05;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (xb33853ea5867d6a8.GetHashCode() * 397) ^ x5dd3bd8e842376d5.GetHashCode();
	}
}
