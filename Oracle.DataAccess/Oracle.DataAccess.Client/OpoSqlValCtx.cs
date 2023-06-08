using System;

namespace Oracle.DataAccess.Client;

internal struct OpoSqlValCtx
{
	public int ArraySize;

	public int BindByName;

	public int RowsAffected;

	public short CommandType;

	public int AddRowid;

	public long FetchSize;

	public int InitialLongFS;

	public int InitialLobFS;

	public uint mode;

	public IntPtr pSnapShot;

	public int RetIdxForSP;

	public int ErrCnt;

	public int AddToStmtCache;

	public int LocalParse;

	public unsafe OpoPrmCtx* pOpoPrmCtx;

	public int StmtPrepared;

	public IntPtr FetchArrayLocation;

	public int bPooledFetchArray;

	public int bIsFromEF;
}
