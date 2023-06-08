using x4adf554d20d941a6;
using xb1090543d168d647;

namespace x59d6a4fc5007b7a4;

internal class x34a37b5a89c466fd
{
	internal static bool x6657b4a72cfac626(char xb867a42da3ae686d)
	{
		return char.IsDigit(xb867a42da3ae686d);
	}

	internal static bool x2a3e4106546123a1(char xb867a42da3ae686d)
	{
		if (xb867a42da3ae686d >= '0')
		{
			return xb867a42da3ae686d <= '9';
		}
		return false;
	}

	internal static bool x4083ed3571df5d9e(char xb867a42da3ae686d)
	{
		x2e47a892b2c1a446 x2e47a892b2c1a = xd9a6b2b6ada137e6.xa11428f1845b710f(xb867a42da3ae686d);
		if (x2e47a892b2c1a != 0)
		{
			return x2e47a892b2c1a == x2e47a892b2c1a446.x45f04850a0027f83;
		}
		return true;
	}

	internal static bool xfb345a6afecb5385(char x3c4da2980d043c95)
	{
		return xd9a6b2b6ada137e6.x839a041aa1476aed(x3c4da2980d043c95) == xd2d2b731b30d7023.xed846b3bb18ccf39;
	}

	internal static bool x4502dd0e4ff79841(char xb867a42da3ae686d)
	{
		if (!x68e6a98ab5d29468(xb867a42da3ae686d))
		{
			return x4c57b971f1a8d64d(xb867a42da3ae686d);
		}
		return true;
	}

	internal static bool x68e6a98ab5d29468(char xb867a42da3ae686d)
	{
		if (xb867a42da3ae686d < '\u0590' || xb867a42da3ae686d > '\u05ff')
		{
			if (xb867a42da3ae686d >= 'יִ')
			{
				return xb867a42da3ae686d <= 'ﭏ';
			}
			return false;
		}
		return true;
	}

	internal static bool x4c57b971f1a8d64d(char xb867a42da3ae686d)
	{
		if ((xb867a42da3ae686d < '\u0600' || xb867a42da3ae686d > 'ۿ') && (xb867a42da3ae686d < 'ݐ' || xb867a42da3ae686d > 'ݿ') && (xb867a42da3ae686d < 'ﭐ' || xb867a42da3ae686d > '\ufdff'))
		{
			if (xb867a42da3ae686d >= 'ﹰ')
			{
				return xb867a42da3ae686d <= '\ufeff';
			}
			return false;
		}
		return true;
	}

	internal static bool x230a8c5c1df6b703(char xb867a42da3ae686d, bool x5cc257ebf0d1b73b)
	{
		if (xb867a42da3ae686d != '.' && xb867a42da3ae686d != ',' && xb867a42da3ae686d != ':')
		{
			if (x5cc257ebf0d1b73b)
			{
				if (xb867a42da3ae686d != '+' && xb867a42da3ae686d != '-' && xb867a42da3ae686d != '/')
				{
					return xb867a42da3ae686d == '%';
				}
				return true;
			}
			return false;
		}
		return true;
	}

	internal static bool xd5042647c7fe230d(char x3c4da2980d043c95)
	{
		if (!xd668e3b4a19d5ff1(x3c4da2980d043c95) && !x9dfbf26545e072e0(x3c4da2980d043c95) && !xe5cb5bde62a41375(x3c4da2980d043c95))
		{
			return x565ecba58afddd5e(x3c4da2980d043c95);
		}
		return true;
	}

	internal static bool x45fed000b8f9e25f(char x3c4da2980d043c95)
	{
		if (!xd668e3b4a19d5ff1(x3c4da2980d043c95) && !x9dfbf26545e072e0(x3c4da2980d043c95))
		{
			return xe5cb5bde62a41375(x3c4da2980d043c95);
		}
		return true;
	}

	internal static bool x9dfbf26545e072e0(char x3c4da2980d043c95)
	{
		if (x3c4da2980d043c95 >= '一')
		{
			return x3c4da2980d043c95 <= '\u9fff';
		}
		return false;
	}

	internal static bool xd668e3b4a19d5ff1(char x3c4da2980d043c95)
	{
		if (x3c4da2980d043c95 >= '\u3040')
		{
			return x3c4da2980d043c95 <= 'ヿ';
		}
		return false;
	}

	internal static bool x309b6591aec95a16(string xb41faee6912a2313)
	{
		for (int i = 0; i < xb41faee6912a2313.Length; i++)
		{
			if (xd668e3b4a19d5ff1(xb41faee6912a2313[i]))
			{
				return true;
			}
		}
		return false;
	}

	internal static bool xe5cb5bde62a41375(char x3c4da2980d043c95)
	{
		if (x3c4da2980d043c95 >= '！')
		{
			return x3c4da2980d043c95 <= '～';
		}
		return false;
	}

	internal static bool x565ecba58afddd5e(char x3c4da2980d043c95)
	{
		if (x3c4da2980d043c95 != '、')
		{
			return x3c4da2980d043c95 == '。';
		}
		return true;
	}

	internal static x4a1a6d8b0aafa0fe x517e646bc90695b3(char xb867a42da3ae686d)
	{
		if (xd5042647c7fe230d(xb867a42da3ae686d))
		{
			return x4a1a6d8b0aafa0fe.xb70c4e1b6bf793bc;
		}
		if (x4502dd0e4ff79841(xb867a42da3ae686d))
		{
			return x4a1a6d8b0aafa0fe.x0b228ef3d2b6a257;
		}
		return x4a1a6d8b0aafa0fe.x59cd759df238a7ae;
	}
}
