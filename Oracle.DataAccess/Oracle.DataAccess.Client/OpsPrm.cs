using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Client;

[SuppressUnmanagedCodeSecurity]
internal class OpsPrm
{
	private OpsPrm()
	{
	}

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsPrmResetValCtx")]
	public unsafe static extern int ResetValCtx(OpoPrmValCtx* pOpoPrmValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsPrmReAllocValCtx")]
	public unsafe static extern int ReAllocValCtx(OpoPrmValCtx* pOpoPrmValCtx, int arraySize);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsPrmFreeOpoPrmCtx")]
	public unsafe static extern int FreeOpoPrmCtx(OpoPrmCtx* pOpoPrmCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsPrmFreeUdtObjects")]
	public unsafe static extern int FreeUdtObjects(IntPtr pOpsConCtx, OpoPrmValCtx* pOpoPrmValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsPrmFreeUdtInObjects")]
	public unsafe static extern int FreeUdtInObjects(IntPtr pOpsConCtx, OpoPrmValCtx* pOpoPrmValCtx);
}
