using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Client;

[SuppressUnmanagedCodeSecurity]
internal class OpsBC
{
	private OpsBC()
	{
	}

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsBulkCopyAllocBufferNode")]
	public unsafe static extern int AllocBufferNode(ref OPOBufferNode* pBufferNode, int rows, int rowsize);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsBulkCopyFreeInputBuffer")]
	public unsafe static extern int FreeInputBuffer(OPOBulkCopyValCtx* pOPOBulkCopyValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsBulkCopyAllocValCtx")]
	public unsafe static extern int AllocValCtx(ref OPOBulkCopyValCtx* pOPOBulkCopyValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsBulkCopyFreeValCtx")]
	public unsafe static extern int FreeValCtx(OPOBulkCopyValCtx* pOPOBulkCopyValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsBulkCopyAllocColCtx")]
	public unsafe static extern int AllocColCtx(ref OPOBulkCopyColCtx* pOPOBulkCopyColCtx, int colCount);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsBulkCopyFreeColCtx")]
	public unsafe static extern int FreeColCtx(OPOBulkCopyColCtx* pOPOBulkCopyColCtx, int colCount);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsBulkCopyCopyColCtx")]
	public unsafe static extern int CopyColCtx(OPOBulkCopyColCtx* pSrcColCtx, OPOBulkCopyColCtx* pDstColCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsBulkCopyGetMeta")]
	public unsafe static extern int GetMeta(IntPtr opsConCtx, ref IntPtr opsErrCtx, ref IntPtr opsSqlCtx, string pCommandText, OPOBulkCopyValCtx* pOPOBulkCopyValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsBulkCopyInit")]
	public unsafe static extern int Init(IntPtr opsConCtx, OPOBulkCopyValCtx* pOPOBulkCopyValCtx, IntPtr pOpsErrCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsBulkCopyLoad")]
	public unsafe static extern int Load(IntPtr opsConCtx, OPOBulkCopyValCtx* pOPOBulkCopyValCtx, IntPtr pOpsErrCtx, ref int pBadRowNum, ref int pBadColNum, int IsOraDataReader, IntPtr pOpsDacCtx, OpoMetValCtx* pOpoMetValCtx, OpoDacValCtx* pOpoDacValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsBulkCopyFinish")]
	public static extern int Finish(IntPtr opsConCtx, IntPtr pOpsBulkCopyCtx, IntPtr pOpsErrCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsBulkCopyAbort")]
	public static extern int Abort(IntPtr pOpsBulkCopyCtx, IntPtr pOpsErrCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsBulkCopyReset")]
	public unsafe static extern int Reset(IntPtr opsConCtx, OPOBulkCopyValCtx* pOPOBulkCopyValCtx, IntPtr pOpsErrCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsBulkCopyCleanup")]
	public unsafe static extern int Cleanup(OPOBulkCopyValCtx* pOPOBulkCopyValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "OpsBulkCopyConvertToBinaryDouble")]
	public unsafe static extern int ConvertToBinaryDouble(IntPtr lfpContext, string inputVal, byte* pBinaryDouble);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "OpsBulkCopyConvertToBinaryFloat")]
	public unsafe static extern int ConvertToBinaryFloat(IntPtr lfpContext, string inputVal, byte* pBinaryFloat);
}
