using System;

namespace Oracle.DataAccess.Types;

internal struct OpoUdtValCtx
{
	public IntPtr pUDT;

	public IntPtr pNullStruct;

	public IntPtr pOpsErrCtx;

	public unsafe OpoDscValCtx* pOpoDscValCtx;

	public IntPtr pTDO;

	public IntPtr ppRefTDO;

	public int bIgnoreElemStatus;

	public int bIsOdtConnection;

	public int NumOfArrElems;

	public unsafe int* pDataLen;

	public long ArrDataTmpBufferSize;

	public IntPtr pArrDataTmpBuffer;

	public long ArrStatusTmpBufferSize;

	public IntPtr pArrStatusTmpBuffer;

	public long ArrExistsTmpBufferSize;

	public IntPtr pArrExistsTmpBuffer;

	public int NumOpoUdtValCtx;

	public unsafe OpoUdtValCtx* pOpoUdtValCtx;

	public OpoUdtAttrValCtx opoUdtAttrValCtx;

	public int DataLen;

	public long DataBufferSize;

	public IntPtr pDataMarshalBuffer;

	public IntPtr pDataPinnedBuffer;

	public IntPtr pDataTmpBuffer;

	public int bIsNull;

	public long StatusBufferSize;

	public IntPtr pStatusMarshalBuffer;

	public IntPtr pStatusPinnedBuffer;
}
