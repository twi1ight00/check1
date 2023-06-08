using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Types;

[SuppressUnmanagedCodeSecurity]
internal class OpsXmlStream
{
	private OpsXmlStream()
	{
	}

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsXmlStreamAllocCtx")]
	public static extern int AllocCtx(IntPtr opsConCtx, IntPtr opsXmlTypeCtx, ref IntPtr opsErrCtx, ref IntPtr opsXmlStreamCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsXmlStreamAllocReadParamList")]
	public unsafe static extern int AllocReadParamList(ref OpoXmlStreamReadParamList* popoXmlStreamReadParamList);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsXmlStreamFreeReadParamList")]
	public unsafe static extern int FreeReadParamList(ref OpoXmlStreamReadParamList* popoXmlStreamReadParamList);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsXmlStreamReadBytes")]
	public unsafe static extern int ReadBytes(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsXmlStreamCtx, IntPtr OpsXmlTypeCtx, IntPtr pBuffer, ref OpoXmlStreamReadParamList* popoXmlStreamReadParamList);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsXmlStreamReadChars")]
	public unsafe static extern int ReadChars(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsXmlStreamCtx, IntPtr opsXmlTypeCtx, IntPtr pBuffer, ref OpoXmlStreamReadParamList* popoXmlStreamReadParamList);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsXmlStreamFreeCtx")]
	public static extern int FreeCtx(ref IntPtr opsConCtx, ref IntPtr opsErrCtx, ref IntPtr opsXmlTypeCtx, ref IntPtr opsXmlStreamCtx, int bFreeOciXmlType, int bFreeOciHandles);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsXmlStreamGetValueBuffer")]
	public static extern int GetValueBuffer(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsXmlTypeCtx, ref IntPtr opsXmlStreamValueBuffer, ref int numCharsInBuffer);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsXmlStreamFreeValueBuffer")]
	public static extern int FreeValueBuffer(ref IntPtr opsXmlStreamValueBuffer);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsXmlStreamGetLength")]
	public static extern int GetLength(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsXmlTypeCtx, ref int lengthInChars);
}
