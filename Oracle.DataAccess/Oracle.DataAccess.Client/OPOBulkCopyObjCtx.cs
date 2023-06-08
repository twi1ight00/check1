using System;

namespace Oracle.DataAccess.Client;

internal struct OPOBulkCopyObjCtx
{
	public int RowsInColArr;

	public uint ObjType;

	public IntPtr pDPFuncCtx;

	public IntPtr pDPFuncCtxColArr;

	public unsafe OPOBulkCopyColCtx* pOPOBulkCopyColCtx;

	public ushort NoOfCols;

	public byte bIsFinalType;
}
