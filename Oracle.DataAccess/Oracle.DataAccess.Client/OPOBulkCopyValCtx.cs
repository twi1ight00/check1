using System;

namespace Oracle.DataAccess.Client;

internal struct OPOBulkCopyValCtx
{
	public int NoOfRows;

	public int RowsInColArr;

	public int MaxRowsInBuffer;

	public unsafe OPOBulkCopyColCtx* pOPOBulkCopyColCtx;

	public IntPtr pOPOBulkCopyRefCtx;

	public IntPtr pOPOBulkCopyCtx;

	public unsafe OPOBufferNode* pInputBuffer;

	public IntPtr OffToRowNum;

	public ushort NoOfCols;

	public byte NoLog;

	public IntPtr lfpContext;
}
