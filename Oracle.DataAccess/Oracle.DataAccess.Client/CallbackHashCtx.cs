using System;

namespace Oracle.DataAccess.Client;

internal class CallbackHashCtx
{
	internal OpoConCtx m_opoConCtxReg;

	internal bool m_shared;

	public CallbackHashCtx(OpoConCtx opoConCtxReg)
	{
		m_opoConCtxReg = opoConCtxReg;
	}

	unsafe ~CallbackHashCtx()
	{
		try
		{
			OpsCon.UnRegisterCallbacks(ref m_opoConCtxReg.opsConCtx, ref m_opoConCtxReg.opsErrCtx, m_opoConCtxReg.pOpoConValCtx, ref m_opoConCtxReg.opoConRefCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
		}
		m_opoConCtxReg = null;
	}
}
