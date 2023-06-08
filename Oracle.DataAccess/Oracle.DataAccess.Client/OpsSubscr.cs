using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Client;

[SuppressUnmanagedCodeSecurity]
internal class OpsSubscr
{
	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsSubscrAllocGlobalCtx")]
	public static extern int AllocGlobalCtx(out IntPtr opsEnvCtx, out IntPtr opsErrCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsSubscrFreeGlobalCtx")]
	public static extern int FreeGlobalCtx(out IntPtr opsEnvCtx, out IntPtr opsErrCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsSubscrAllocCtx")]
	public static extern int AllocCtx(IntPtr opsEnvCtx, out IntPtr opsErrCtx, out IntPtr opsSubscrCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsSubscrFreeCtx")]
	public static extern int FreeCtx(IntPtr opsEnvCtx, out IntPtr opsErrCtx, out IntPtr opsSubscrCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsSubscrSetChgNTFN")]
	public static extern int SetChgNTFN(IntPtr opsSubscrEnvCtx, IntPtr opsSubscrCtx, IntPtr opsErrCtx, string invalidationStr, int isPersistent, int isNotifiedOnce, int isRowidReq, uint timeout);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsSubscrUnRegister")]
	public static extern int UnRegister(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsSubscrCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsSubscrSetPort")]
	public static extern int SetPort(IntPtr opsEnvCtx, IntPtr opsErrCtx, uint port);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsSubscrGetPort")]
	public static extern int GetPort(IntPtr opsEnvCtx, IntPtr opsErrCtx, out uint port);
}
