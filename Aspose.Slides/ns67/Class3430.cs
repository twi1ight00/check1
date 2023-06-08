using System.Diagnostics;
using DrawingMLRenderer;

namespace ns67;

internal sealed class Class3430
{
	public static bool smethod_0(double value)
	{
		if (value < 0.0)
		{
			return false;
		}
		if (value >= 21600000.0)
		{
			return false;
		}
		return true;
	}

	public static bool smethod_1(double value)
	{
		if (value < 0.0)
		{
			return false;
		}
		if (value > 100.0)
		{
			return false;
		}
		return true;
	}

	[Conditional("DEBUG")]
	public static void smethod_2(bool condition)
	{
		if (!condition)
		{
			throw new Exception("Debug assertion failed.");
		}
	}

	[Conditional("DEBUG")]
	public static void smethod_3(bool condition, string message)
	{
		if (!condition)
		{
			throw new Exception("Debug assertion failed: " + message);
		}
	}

	private Class3430()
	{
	}
}
