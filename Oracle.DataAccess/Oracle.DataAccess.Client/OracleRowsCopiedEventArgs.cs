using System;

namespace Oracle.DataAccess.Client;

public class OracleRowsCopiedEventArgs : EventArgs
{
	private bool m_abort;

	private long m_rowsCopied;

	public bool Abort
	{
		get
		{
			return m_abort;
		}
		set
		{
			m_abort = value;
		}
	}

	public long RowsCopied => m_rowsCopied;

	static OracleRowsCopiedEventArgs()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public OracleRowsCopiedEventArgs(long rowsCopied)
	{
		m_rowsCopied = rowsCopied;
	}
}
