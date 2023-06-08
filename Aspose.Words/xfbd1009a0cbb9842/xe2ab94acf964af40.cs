using System.Text.RegularExpressions;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xfbd1009a0cbb9842;

internal class xe2ab94acf964af40
{
	private const int xdb2f00ce573da4b5 = 1;

	private const int x8e89ec2f614c4d1a = 9;

	internal const int x9033c28e237217fd = -1;

	private const int xe4054ec424d6636a = 1;

	private const int x8ad5da4f5905b2b8 = 2;

	internal const string x85ec1bed3c2bcf7f = "Error! Not a valid heading level range.";

	private int x4e9cab8231980d71 = 1;

	private int xf62c92dc7d224a98 = 9;

	internal static readonly xe2ab94acf964af40 xffb68b1ddc32f0fd = new xe2ab94acf964af40(1, 9);

	private static readonly Regex x57982b49a14ea181 = new Regex("\\A\\D*(\\d)\\D+(\\d)\\D*\\z", RegexOptions.Compiled);

	internal int xf41d956c067e2b4d => x4e9cab8231980d71;

	internal int x9f4c543928c73298 => xf62c92dc7d224a98;

	internal xe2ab94acf964af40()
	{
	}

	private xe2ab94acf964af40(int min, int max)
	{
		x4e9cab8231980d71 = min;
		xf62c92dc7d224a98 = max;
	}

	internal bool x19890931227f0f56(string xb41faee6912a2313)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(xb41faee6912a2313))
		{
			return false;
		}
		Match match = x57982b49a14ea181.Match(xb41faee6912a2313);
		if (!match.Success)
		{
			return false;
		}
		int num = xca004f56614e2431.xa93402510be8434e(match.Groups[1].Value);
		int num2 = xca004f56614e2431.xa93402510be8434e(match.Groups[2].Value);
		if (num > num2)
		{
			return false;
		}
		if (!x451fe5122b35ec1f(num) || !x451fe5122b35ec1f(num2))
		{
			return false;
		}
		x4e9cab8231980d71 = num;
		xf62c92dc7d224a98 = num2;
		return true;
	}

	internal void x97188a808cff1d41()
	{
		x4e9cab8231980d71 = 9;
		xf62c92dc7d224a98 = 1;
	}

	internal bool x53ab91850c4897b0(int x66bbd7ed8c65740d)
	{
		if (x66bbd7ed8c65740d >= x4e9cab8231980d71)
		{
			return x66bbd7ed8c65740d <= xf62c92dc7d224a98;
		}
		return false;
	}

	internal static bool x451fe5122b35ec1f(int x66bbd7ed8c65740d)
	{
		if (x66bbd7ed8c65740d >= 1)
		{
			return x66bbd7ed8c65740d <= 9;
		}
		return false;
	}
}
