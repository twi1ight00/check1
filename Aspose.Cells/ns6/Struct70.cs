using System;
using System.Runtime.InteropServices;

namespace ns6;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct70
{
	internal static double smethod_0(double double_0)
	{
		return Math.PI / 180.0 * double_0;
	}

	internal static double smethod_1(double double_0)
	{
		return 180.0 * double_0 / Math.PI;
	}
}
