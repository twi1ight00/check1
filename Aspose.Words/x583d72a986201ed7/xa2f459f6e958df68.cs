using Aspose.Words;
using xf989f31a236ff98c;

namespace x583d72a986201ed7;

internal class xa2f459f6e958df68
{
	private const char xfbd2b3b24222020a = '\u0085';

	private readonly x755940550ade8e52 x93ce70fb4ad3e4ab;

	private xa2f459f6e958df68(x755940550ade8e52 textReader)
	{
		x93ce70fb4ad3e4ab = textReader;
	}

	internal static FileFormatInfo xdef7f68a22ec051d(x755940550ade8e52 xe43224d95d6cd278)
	{
		return new xa2f459f6e958df68(xe43224d95d6cd278).xdef7f68a22ec051d();
	}

	private static bool xc0ea3ba8bf1b41c5(char x3c4da2980d043c95)
	{
		switch (x3c4da2980d043c95)
		{
		case '\t':
		case '\n':
		case '\r':
		case '\u0085':
			return true;
		default:
			return false;
		}
	}

	private static bool xd0f7d6bb829c47bd(char x3c4da2980d043c95)
	{
		if (x3c4da2980d043c95 > '\u001f' && x3c4da2980d043c95 != '\u007f')
		{
			if (x3c4da2980d043c95 >= '\u0080')
			{
				return x3c4da2980d043c95 <= '\u009f';
			}
			return false;
		}
		return true;
	}

	private static bool x219256a94e3c87fa(char x3c4da2980d043c95)
	{
		if (x3c4da2980d043c95 != '\n')
		{
			return x3c4da2980d043c95 == '\u0085';
		}
		return true;
	}

	private static bool x73c247b7a227d619(char xb867a42da3ae686d)
	{
		if (!char.IsWhiteSpace(xb867a42da3ae686d) && !x219256a94e3c87fa(xb867a42da3ae686d) && xb867a42da3ae686d != ',')
		{
			return xb867a42da3ae686d == ';';
		}
		return true;
	}

	private FileFormatInfo xdef7f68a22ec051d()
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		while (x93ce70fb4ad3e4ab.x5959bccb67bbf051)
		{
			char c = x93ce70fb4ad3e4ab.xb079f24d79abc35e();
			if (xd0f7d6bb829c47bd(c) && !xc0ea3ba8bf1b41c5(c))
			{
				return null;
			}
			num++;
			if (x73c247b7a227d619(c))
			{
				if (num6 != 0)
				{
					num3++;
					num4 += num6;
					num6 = 0;
				}
				if (x219256a94e3c87fa(c))
				{
					num2++;
				}
			}
			else
			{
				num6++;
				if (char.IsLetterOrDigit(c))
				{
					num5++;
				}
			}
		}
		if (num6 != 0)
		{
			num3++;
			num4 += num6;
		}
		int num7 = 0;
		if (num3 > 0 && num4 / num3 < 20)
		{
			num7++;
		}
		if (num5 > 0 && num / num5 < 2)
		{
			num7 += 2;
		}
		if (num2 > 0 && num / num2 < 120)
		{
			num7++;
		}
		if (num >= 200 && num3 > 0 && num4 / num3 > 20)
		{
			num7--;
		}
		if (num7 < 2)
		{
			return null;
		}
		FileFormatInfo fileFormatInfo = new FileFormatInfo();
		fileFormatInfo.x9d4c5edc77b82e9e(LoadFormat.Text);
		fileFormatInfo.x07279a63090af02d(x93ce70fb4ad3e4ab.x9ee491ab5579b9fc);
		return fileFormatInfo;
	}
}
