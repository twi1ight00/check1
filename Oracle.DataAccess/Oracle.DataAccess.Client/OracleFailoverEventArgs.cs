using System;

namespace Oracle.DataAccess.Client;

public sealed class OracleFailoverEventArgs : EventArgs
{
	private IntPtr pSvcCtx;

	private IntPtr pEnvHnd;

	private IntPtr m_FailoverCtx;

	private FailoverType m_FailoverType;

	private FailoverEvent m_FailoverEvent;

	public FailoverType FailoverType => m_FailoverType;

	public FailoverEvent FailoverEvent => m_FailoverEvent;

	static OracleFailoverEventArgs()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	internal OracleFailoverEventArgs(IntPtr svchp, IntPtr envhp, IntPtr fo_ctx, int fo_type, int fo_event)
	{
		pSvcCtx = svchp;
		pEnvHnd = envhp;
		m_FailoverCtx = fo_ctx;
		m_FailoverType = (FailoverType)fo_type;
		m_FailoverEvent = (FailoverEvent)fo_event;
	}
}
