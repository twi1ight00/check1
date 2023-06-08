using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Types;

[SuppressUnmanagedCodeSecurity]
internal class OpsStr
{
	private OpsStr()
	{
	}

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsStrBytesToUnicode")]
	public static extern int BytesToUnicode(IntPtr byteSrc, int srcLen, int index, int count, out string dst);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsStrUnicodeToBytes")]
	public static extern int UnicodeToBytes(IntPtr str, int srcLen, out IntPtr dst, out uint dstLen);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsStrStrCompare")]
	public static extern int StrCompare(IntPtr src1, int src1Len, IntPtr src2, int src2Len, int isCaseInsensitive, out int res);
}
