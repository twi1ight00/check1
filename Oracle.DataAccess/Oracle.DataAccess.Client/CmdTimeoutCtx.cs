using System;
using System.Threading;

namespace Oracle.DataAccess.Client;

internal class CmdTimeoutCtx
{
	public IntPtr m_pOpsConCtx;

	public IntPtr m_pErrHnd;

	public ManualResetEvent m_hWaitForOciBreakEvent;

	public bool m_bDoneExecution;

	public bool m_bDoneOCIBreak;

	public CmdTimeoutCtx(IntPtr pOpsConCtx, int timeoutSec)
	{
		m_pOpsConCtx = pOpsConCtx;
		m_hWaitForOciBreakEvent = new ManualResetEvent(initialState: true);
	}

	~CmdTimeoutCtx()
	{
		Dispose();
		GC.SuppressFinalize(this);
	}

	public void Dispose()
	{
		m_pOpsConCtx = IntPtr.Zero;
		if (m_hWaitForOciBreakEvent != null)
		{
			m_hWaitForOciBreakEvent.Close();
			m_hWaitForOciBreakEvent = null;
		}
		if (!(m_pErrHnd != IntPtr.Zero))
		{
			return;
		}
		try
		{
			OpsErr.FreeCtx(ref m_pErrHnd);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
		}
		m_pErrHnd = IntPtr.Zero;
	}

	public void TimeoutNew(object state)
	{
		CmdTimeoutCtx cmdTimeoutCtx = (CmdTimeoutCtx)state;
		try
		{
			cmdTimeoutCtx.m_hWaitForOciBreakEvent.Reset();
			if (!cmdTimeoutCtx.m_bDoneExecution)
			{
				OpsSql.BreakExecution(cmdTimeoutCtx.m_pOpsConCtx, ref cmdTimeoutCtx.m_pErrHnd);
			}
			cmdTimeoutCtx.m_bDoneOCIBreak = true;
		}
		catch
		{
		}
		finally
		{
			try
			{
				cmdTimeoutCtx.m_hWaitForOciBreakEvent.Set();
			}
			catch
			{
			}
		}
	}
}
