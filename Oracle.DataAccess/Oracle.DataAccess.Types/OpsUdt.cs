using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Types;

[SuppressUnmanagedCodeSecurity]
internal class OpsUdt
{
	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsUdtSetSig")]
	public static extern int SetSig(IntPtr pOpsConCtx, out int pSessionBegin);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsUdtDispose")]
	public static extern int Dispose(IntPtr pOpsConCtx, int SessionBegin, ref IntPtr pUDT, ref IntPtr pOCIRef, ref IntPtr pAttrRefTDO, ref IntPtr pAttrTDO);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsUdtFromXML")]
	public static extern int UdtFromXML(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsDscCtx, ref IntPtr pUDT, ref IntPtr pObjInd, int OCITypeCode, string pXMLStr);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsUdtToXML")]
	public static extern int UdtToXML(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsDscCtx, string schemaNameTypeName, IntPtr pUDT, ref IntPtr LobLocator, ref int pDataLength, int OCITypeCode, int bCheckNotFinal);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsGetXML")]
	public static extern int GetXML(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsDscCtx, IntPtr LobLocator, int DataLength, string pXMLStr);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsUdtAllocValCtx")]
	public unsafe static extern int AllocValCtx(out OpoUdtValCtx* pOpoUdtValCtx, int numOpoUdtValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsUdtReAllocValCtx")]
	public unsafe static extern int ReAllocValCtx(ref OpoUdtValCtx* pOpoUdtValCtx, int numPrevOpoUdtValCtx, int numOpoUdtValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsUdtFreeValCtx")]
	public unsafe static extern int FreeValCtx(OpoUdtValCtx* pOpoUdtValCtx, bool bFreeOuter);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsUdtGetObj")]
	public unsafe static extern int GetObj(IntPtr pOpsConCtx, OpoUdtValCtx* pOpoUdtValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsUdtGetArr")]
	public unsafe static extern int GetArr(IntPtr pOpsConCtx, OpoUdtValCtx* pOpoUdtValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsUdtGetBFile")]
	public unsafe static extern int GetBFile(IntPtr pOpsConCtx, OpoUdtValCtx* pOpoUdtValCtx, int index);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsUdtGetLob")]
	public unsafe static extern int GetLob(IntPtr pOpsConCtx, OpoUdtValCtx* pOpoUdtValCtx, int index);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsUdtGetRef")]
	public unsafe static extern int GetRef(IntPtr pOpsConCtx, OpoUdtValCtx* pOpoUdtValCtx, int index);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsUdtGetXml")]
	public unsafe static extern int GetXml(IntPtr pOpsConCtx, OpoUdtValCtx* pOpoUdtValCtx, int index);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsUdtGetUdt")]
	public unsafe static extern int GetUdt(IntPtr pOpsConCtx, OpoUdtValCtx* pOpoUdtValCtx, int index);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsUdtSetData")]
	public unsafe static extern int SetData(IntPtr pOpsConCtx, OpoUdtValCtx* pOpoUdtValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsUdtSetArrayData")]
	public unsafe static extern int SetArrayData(IntPtr pOpsConCtx, OpoUdtValCtx* pOpoUdtValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsUdtCopy")]
	public unsafe static extern int Copy(IntPtr opsConCtx, OpoUdtValCtx* pOpoUdtValCtx, IntPtr pObjTarget, IntPtr pObjTargetInd);
}
