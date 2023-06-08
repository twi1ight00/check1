using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Client;

[SuppressUnmanagedCodeSecurity]
internal class OpsInit
{
	[DllImport("kernel32.dll")]
	public static extern int SetDllDirectory(string pathName);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public static extern int CheckVersionCompatibility(string version);

	[DllImport("kernel32")]
	public static extern IntPtr LoadLibrary(string fileName);

	[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
	public static extern int GetFileAttributes(string fileName);
}
