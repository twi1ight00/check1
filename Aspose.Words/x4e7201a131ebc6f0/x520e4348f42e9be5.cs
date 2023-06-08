using System.Text;
using Aspose.Words;
using xf989f31a236ff98c;

namespace x4e7201a131ebc6f0;

internal class x520e4348f42e9be5
{
	private x520e4348f42e9be5()
	{
	}

	internal static FileFormatInfo xdef7f68a22ec051d(x755940550ade8e52 xb654337884ac66fa)
	{
		xb654337884ac66fa.x399093d970c2cf4f();
		bool flag = xfb65a459cfafdb9e(xb654337884ac66fa) && xec8b374ead4f0540(xb654337884ac66fa);
		if (flag)
		{
			xb654337884ac66fa.x2bb95aedd2d8729f();
		}
		if (!(flag & (x2e3e96732a72fc3e(xb654337884ac66fa) || (xfb65a459cfafdb9e(xb654337884ac66fa) && xec8b374ead4f0540(xb654337884ac66fa)))))
		{
			return null;
		}
		FileFormatInfo fileFormatInfo = new FileFormatInfo();
		fileFormatInfo.x9d4c5edc77b82e9e(LoadFormat.Mhtml);
		fileFormatInfo.x07279a63090af02d(Encoding.ASCII);
		return fileFormatInfo;
	}

	private static bool xfb65a459cfafdb9e(x755940550ade8e52 xb654337884ac66fa)
	{
		int num = 0;
		bool flag = false;
		while (xb654337884ac66fa.x5959bccb67bbf051)
		{
			char c = xb654337884ac66fa.xb079f24d79abc35e();
			switch (c)
			{
			case '\t':
			case ' ':
				flag = true;
				continue;
			case ':':
				return num > 0;
			}
			if (!xccde3589b46a183d(c) || flag)
			{
				return false;
			}
			num++;
		}
		return false;
	}

	private static bool xec8b374ead4f0540(x755940550ade8e52 xb654337884ac66fa)
	{
		while (xb654337884ac66fa.x5959bccb67bbf051)
		{
			char c = xb654337884ac66fa.xb079f24d79abc35e();
			switch (c)
			{
			case '\0':
				return false;
			case '\n':
			case '\r':
			case '\\':
			{
				if (!xb654337884ac66fa.x5959bccb67bbf051)
				{
					break;
				}
				char c2 = xb654337884ac66fa.xb079f24d79abc35e();
				if (c == '\\')
				{
					break;
				}
				if (c2 == '\0')
				{
					return false;
				}
				xb654337884ac66fa.x299147f04b6b58b8();
				if (c != '\r' || c2 != '\n')
				{
					if (c2 != ' ' && c2 != '\t')
					{
						return true;
					}
					xb654337884ac66fa.x2bb95aedd2d8729f();
				}
				break;
			}
			}
		}
		return false;
	}

	private static bool x2e3e96732a72fc3e(x755940550ade8e52 xb654337884ac66fa)
	{
		if (!xb654337884ac66fa.x5959bccb67bbf051)
		{
			return false;
		}
		char c = xb654337884ac66fa.xb079f24d79abc35e();
		xb654337884ac66fa.x299147f04b6b58b8();
		if (c != '\r')
		{
			return c == '\n';
		}
		return true;
	}

	private static bool xccde3589b46a183d(char xb867a42da3ae686d)
	{
		if (xb867a42da3ae686d >= '!')
		{
			return xb867a42da3ae686d <= '~';
		}
		return false;
	}
}
