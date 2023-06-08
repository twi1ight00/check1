using System;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal abstract class xcf9d359063aa93f2
{
	internal readonly x17dcbf5fe3c0d2d2 x17dcbf5fe3c0d2d2;

	private int x07b787728a2e6e8d;

	private bool xfeaabefbdd0c65f6;

	internal virtual bool xe76bdd563aa52beb
	{
		get
		{
			if (x17dcbf5fe3c0d2d2 == null)
			{
				return true;
			}
			return xfeaabefbdd0c65f6;
		}
	}

	internal xcf9d359063aa93f2(x17dcbf5fe3c0d2d2 context)
	{
		x17dcbf5fe3c0d2d2 = context;
	}

	protected bool x39f156868f37b760(object xa59bff7708de3a18)
	{
		if (xa59bff7708de3a18 != null && GetType() == xa59bff7708de3a18.GetType())
		{
			return GetHashCode() == xa59bff7708de3a18.GetHashCode();
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (!xfeaabefbdd0c65f6)
		{
			xfeaabefbdd0c65f6 = true;
			x07b787728a2e6e8d = 0;
			AddKeysToHashCode();
			x07b787728a2e6e8d += x07b787728a2e6e8d << 3;
			x07b787728a2e6e8d ^= x07b787728a2e6e8d >> 11;
			x07b787728a2e6e8d += x07b787728a2e6e8d << 15;
		}
		return x07b787728a2e6e8d;
	}

	protected abstract void AddKeysToHashCode();

	protected void xd94964d84c426258(object xba08ce632055a1d9)
	{
		if (xba08ce632055a1d9 != null)
		{
			x07b787728a2e6e8d += xba08ce632055a1d9.GetHashCode();
		}
		x026c31519b7bbb4e();
	}

	protected void x1e94bce19c84490b(ValueType xba08ce632055a1d9)
	{
		x07b787728a2e6e8d += xba08ce632055a1d9.GetHashCode();
		x026c31519b7bbb4e();
	}

	private void x026c31519b7bbb4e()
	{
		x07b787728a2e6e8d += x07b787728a2e6e8d << 10;
		x07b787728a2e6e8d ^= x07b787728a2e6e8d >> 6;
	}

	protected bool x5003c1d655073976(Array x19218ffab70283ef, Array xe7ebe10fa44d8d49)
	{
		if (x19218ffab70283ef == xe7ebe10fa44d8d49)
		{
			return true;
		}
		if (x19218ffab70283ef == null || xe7ebe10fa44d8d49 == null)
		{
			return false;
		}
		if (x19218ffab70283ef.Length != xe7ebe10fa44d8d49.Length)
		{
			return false;
		}
		for (int i = 0; i < x19218ffab70283ef.Length; i++)
		{
			object value = x19218ffab70283ef.GetValue(i);
			object value2 = xe7ebe10fa44d8d49.GetValue(i);
			if (!object.Equals(value, value2))
			{
				return false;
			}
		}
		return true;
	}

	protected bool x5003c1d655073976(int[] x19218ffab70283ef, int[] xe7ebe10fa44d8d49)
	{
		return xcd4bd3abd72ff2da.xf920f15ca6067ada(x19218ffab70283ef, xe7ebe10fa44d8d49);
	}

	protected void xb8a096c5a06a549d(Array xba08ce632055a1d9)
	{
		foreach (object item in xba08ce632055a1d9)
		{
			xd94964d84c426258(item);
		}
	}

	protected void xb8a096c5a06a549d(int[] xba08ce632055a1d9)
	{
		foreach (int num in xba08ce632055a1d9)
		{
			x1e94bce19c84490b(num);
		}
	}

	protected void x71c6d753219cc1b7()
	{
		if (xfeaabefbdd0c65f6)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jmpkknglinnlpnemjilmpmcnbnjndnaobnholloofmfphlmpgldaogkaelbbllibfgpbfkgcakncpjedbkldljcehjjeafafoihfijoflifgeemgeidhphkhjibigiiieipigigjpcnjogekoglkgcclahjlpgambghmdgomnffnnfmngfdocfkojbbp", 1802088309)));
		}
	}
}
