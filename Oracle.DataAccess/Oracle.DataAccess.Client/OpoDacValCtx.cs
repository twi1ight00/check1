using System;
using Oracle.DataAccess.Types;

namespace Oracle.DataAccess.Client;

internal struct OpoDacValCtx
{
	public int MemFileCache;

	public int ResultsetIndex;

	public long OrigFetchSize;

	public long FetchSize;

	public int CurrentClientRow;

	public int CurrentRowPointedTo;

	public int Ordinal;

	public int Type;

	public long FieldOffset;

	public int InitialLongFS;

	public int InitialLobFS;

	public int BufLen;

	public int ForUpdate;

	public int Wait;

	public int AddRowid;

	public int AddToStmtCache;

	public int RetDataLen;

	public int RecordCount;

	public int Indicator;

	public int IsUnicode;

	public IntPtr pBuffer;

	public unsafe void* pValCtx;

	public IntPtr pUnmanagedBuf;

	public IntPtr pUnmanagedValCtx;

	public IntPtr pSnapShot;

	public IntPtr pLOBCtx;

	public IntPtr pUdtNullStruct;

	public IntPtr pTDO;

	public unsafe OpoUdtValCtx* pOpoUdtValCtx;

	public IntPtr ppRefTDO;
}
