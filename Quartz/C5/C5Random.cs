using System;
using System.Runtime.InteropServices;

namespace C5;

internal class C5Random : Random
{
	private uint[] Q = new uint[16];

	private uint c = 362436u;

	private uint i = 15u;

	private uint Cmwc()
	{
		ulong num = 487198574uL;
		uint num2 = 4294967294u;
		i = (i + 1) & 0xFu;
		ulong num3 = num * Q[i] + c;
		c = (uint)(num3 >> 32);
		uint num4 = (uint)(num3 + c);
		if (num4 < c)
		{
			num4++;
			c++;
		}
		return Q[i] = num2 - num4;
	}

	[ComVisible(true)]
	public override double NextDouble()
	{
		return (double)Cmwc() / 4294967296.0;
	}

	protected override double Sample()
	{
		return NextDouble();
	}

	[ComVisible(true)]
	public override int Next()
	{
		return (int)Cmwc();
	}

	[ComVisible(true)]
	public override int Next(int max)
	{
		if (max < 0)
		{
			throw new ArgumentException("max must be non-negative");
		}
		return (int)((double)Cmwc() / 4294967296.0 * (double)max);
	}

	[ComVisible(true)]
	public override int Next(int min, int max)
	{
		if (min > max)
		{
			throw new ArgumentException("min must be less than or equal to max");
		}
		return min + (int)((double)Cmwc() / 4294967296.0 * (double)(max - min));
	}

	[ComVisible(true)]
	public override void NextBytes(byte[] buffer)
	{
		int i = 0;
		for (int num = buffer.Length; i < num; i++)
		{
			buffer[i] = (byte)Cmwc();
		}
	}

	[ComVisible(true)]
	public C5Random()
		: this(DateTime.Now.Ticks)
	{
	}

	[ComVisible(true)]
	public C5Random(long seed)
	{
		if (seed == 0)
		{
			throw new ArgumentException("Seed must be non-zero");
		}
		uint num = (uint)(seed & 0xFFFFFFFFu);
		for (int i = 0; i < 16; i++)
		{
			num ^= num << 13;
			num ^= num >> 17;
			num ^= num << 5;
			Q[i] = num;
		}
		Q[15] = (uint)(seed ^ (seed >> 32));
	}

	[CLSCompliant(false)]
	[ComVisible(true)]
	public C5Random(uint[] Q)
	{
		if (Q.Length != 16)
		{
			throw new ArgumentException("Q must have length 16, was " + Q.Length);
		}
		Array.Copy(Q, this.Q, 16);
	}
}
