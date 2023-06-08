using System;
using Oracle.DataAccess.Types;

namespace Oracle.DataAccess.Client;

internal struct OpoPrmValCtx
{
	public ushort BindType;

	public int OraDbType;

	public int Size;

	public byte Direction;

	public ushort UCS2Char;

	public unsafe ushort* alenp;

	public unsafe short* pInd;

	public unsafe short* pSrcInd;

	public IntPtr pBind;

	public byte CharSetForm;

	public unsafe void* pTmpVal;

	public unsafe void* pBltVal;

	public byte PrmEnumType;

	public unsafe int* pIndSize;

	public IntPtr ppInd;

	public unsafe int* objalenp;

	public int maxarr_len;

	public int curelep;

	public IntPtr pOpsDscCtx;

	public unsafe short* pTmpInd;

	public IntPtr ppTempInd;

	public byte bIsFinalType;

	public unsafe void* pTDOSubType;

	public int NumOpoUdtValCtx;

	public unsafe OpoUdtValCtx* pOpoUdtValCtx;

	public IntPtr ppRefTDO;

	public int NumArrBindElems;

	public IntPtr pArrBindMemBlock;
}
