using System;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

internal class OpoUdtCtx
{
	public IntPtr m_opsConCtx;

	public IntPtr m_pUDT;

	public IntPtr m_pOCIRef;

	public IntPtr m_pObjInd;

	public IntPtr m_pAttrRefTdo;

	public IntPtr m_pAttrTdo;

	public bool m_disposed;

	internal int m_refCount;

	internal int m_IsPinned;

	internal int m_pinLatest;

	internal int m_SessionBegin;

	internal OpoUdtCtx(IntPtr opsConCtx, IntPtr pUDT, IntPtr pOCIRef, IntPtr pObjInd)
	{
		int num = 0;
		try
		{
			num = OpsCon.AddRef(opsConCtx);
			if (num <= 1)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		m_opsConCtx = opsConCtx;
		OpsUdt.SetSig(opsConCtx, out m_SessionBegin);
		m_pUDT = pUDT;
		m_pOCIRef = pOCIRef;
		m_pObjInd = pObjInd;
	}

	internal void AddRefCount()
	{
		if (m_disposed)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		lock (this)
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			m_refCount++;
		}
	}

	internal void RelRefCount()
	{
		if (m_disposed)
		{
			return;
		}
		lock (this)
		{
			if (!m_disposed)
			{
				m_refCount--;
				if (m_refCount <= 0)
				{
					Dispose();
					GC.SuppressFinalize(this);
				}
			}
		}
	}

	private void Dispose()
	{
		if (m_disposed)
		{
			return;
		}
		try
		{
			if (m_pUDT != IntPtr.Zero || m_pOCIRef != IntPtr.Zero || m_pAttrRefTdo != IntPtr.Zero || m_pAttrTdo != IntPtr.Zero)
			{
				OpsUdt.Dispose(m_opsConCtx, m_SessionBegin, ref m_pUDT, ref m_pOCIRef, ref m_pAttrRefTdo, ref m_pAttrTdo);
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
		}
		try
		{
			OpsCon.RelRef(ref m_opsConCtx);
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
		}
		m_disposed = true;
	}

	~OpoUdtCtx()
	{
		Dispose();
	}
}
