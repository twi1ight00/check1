using System;
using System.Runtime.InteropServices;

namespace ns70;

internal sealed class Class3468
{
	private const string string_0 = "User32.dll";

	private Class3468()
	{
	}

	[DllImport("User32.dll")]
	public static extern IntPtr GetDC(IntPtr hWnd);

	[DllImport("User32.dll")]
	public static extern int RelaseDC(IntPtr hWnd, IntPtr hDC);
}
