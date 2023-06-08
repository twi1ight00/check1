using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ns70;

internal abstract class Class3462
{
	public static void smethod_0(bool condition)
	{
		if (!condition)
		{
			int lastWin32Error = Marshal.GetLastWin32Error();
			throw new Win32Exception(lastWin32Error);
		}
	}
}
