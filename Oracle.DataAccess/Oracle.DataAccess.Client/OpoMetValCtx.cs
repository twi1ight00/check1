using System;

namespace Oracle.DataAccess.Client;

internal struct OpoMetValCtx
{
	public short NoOfMetaAlloc;

	public short NoOfCols;

	public short NoOfHiddenCols;

	public byte bHasLongCol;

	public byte bHasLongLobBFileCol;

	public byte bHasXmlType;

	public byte bHasUdtType;

	public byte bUdtInfoFetched;

	public byte bHasDescCol;

	public byte bPkFetched;

	public byte bPkPresent;

	public byte bPooled;

	public int InitialLongFS;

	public int InitialLobFS;

	public byte bStmtParsed;

	public unsafe ColMetaVal* pColMetaVal;

	public IntPtr pOpoMetRefCtx;

	public int CommandType;

	public byte bRowidPresent;

	public IntPtr pCommandText;

	public IntPtr pNewCommandText;

	public ushort NoOfBlobCols;

	public ushort NoOfClobCols;

	public ushort NoOfNClobCols;

	public int RefCount;

	public int NoOfDescCols;

	public byte bChgNtfnRowidPresent;
}
