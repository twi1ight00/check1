using System;

namespace Oracle.DataAccess.Client;

internal struct OpoPrmCtx
{
	public byte CtxType;

	public int NumValCtxElems;

	public unsafe OpoPrmValCtx* pOpoPrmValCtx;

	public IntPtr m_pAttrRefTdo;

	public IntPtr pOpsConCtx;

	private int SessionBegin;

	public IntPtr pMemBlock;

	public int bInStmtCache;
}
