using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
[SuppressUnmanagedCodeSecurity]
internal class MetaData
{
	internal unsafe OpoMetValCtx* m_pOpoMetValCtx;

	internal unsafe OpoMetValCtx* m_pOpoMetValCtxWRowid;

	internal ColMetaRef[] m_colMetaRef;

	internal ColMetaRef[] m_colMetaRefWRowid;

	internal bool m_parsed;

	internal bool m_addParam;

	internal long m_rowSize;

	internal uint[] m_colOffset;

	internal uint[] m_colIndOffset;

	internal uint[] m_colLenOffset;

	internal OraType[] m_oraType;

	internal OracleDbType[] m_oracleDbType;

	internal DotNetNumericAccessor[] m_dotNetNumericAccessor;

	internal static Pooler m_connDataPooler = new Pooler(10, 50);

	public unsafe MetaData(OpoMetValCtx* pOpoMetValCtx, bool addRowid)
	{
		m_addParam = true;
		if (!addRowid)
		{
			m_pOpoMetValCtx = pOpoMetValCtx;
		}
		else
		{
			m_pOpoMetValCtxWRowid = pOpoMetValCtx;
		}
	}

	public MetaData()
	{
		m_addParam = true;
	}

	unsafe ~MetaData()
	{
		if (m_pOpoMetValCtx != null)
		{
			try
			{
				OpsMet.FreeValCtx(m_pOpoMetValCtx);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
			}
			m_pOpoMetValCtx = null;
		}
		if (m_pOpoMetValCtxWRowid == null)
		{
			return;
		}
		try
		{
			OpsMet.FreeValCtx(m_pOpoMetValCtxWRowid);
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
		}
		m_pOpoMetValCtxWRowid = null;
	}
}
