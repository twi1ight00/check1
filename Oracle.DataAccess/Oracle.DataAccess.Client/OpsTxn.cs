using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Client;

[SuppressUnmanagedCodeSecurity]
internal class OpsTxn
{
	private OpsTxn()
	{
	}

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTxnAllocValCtx")]
	public unsafe static extern int AllocValCtx(ref OpoTxnValCtx* pOpoTxnValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTxnFreeValCtx")]
	public unsafe static extern int FreeValCtx(OpoTxnValCtx* pOpoTxnValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTxnBegin")]
	public unsafe static extern int Begin(IntPtr opsConCtx, out IntPtr opsErrCtx, OpoTxnValCtx* opoTxnValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTxnCommit")]
	public unsafe static extern int Commit(IntPtr opsConCtx, IntPtr opsErrCtx, OpoTxnValCtx* pOpoTxnValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTxnRollback")]
	public unsafe static extern int Rollback(IntPtr opsConCtx, IntPtr opsErrCtx, OpoTxnValCtx* pOpoTxnValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsTxnDispose")]
	public unsafe static extern int Dispose(IntPtr opsErrCtx, OpoTxnValCtx* pOpoTxnValCtx);
}
