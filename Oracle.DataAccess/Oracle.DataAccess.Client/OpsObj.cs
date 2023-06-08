using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Client;

[SuppressUnmanagedCodeSecurity]
internal class OpsObj
{
	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsObjAllocValCtx")]
	public unsafe static extern int AllocObjValCtx(ref OpoObjValCtx* pOpoObjValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsObjFreeValCtx")]
	public unsafe static extern int FreeValCtx(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr pComplexObjCtx, OpoObjValCtx* pOpoObjValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsObjNew")]
	public unsafe static extern int New(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsUdtCtx, ref OpoObjValCtx* pOpoObjValCtx, OpoObjRefCtx pOpoObjRefCtx, ref IntPtr pUDT, ref IntPtr pOCIRef, ref IntPtr pObjInd);
}
