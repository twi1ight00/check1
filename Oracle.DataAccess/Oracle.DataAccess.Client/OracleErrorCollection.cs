using System;
using System.Collections;

namespace Oracle.DataAccess.Client;

[Serializable]
public sealed class OracleErrorCollection : ArrayList
{
	public new OracleError this[int index]
	{
		get
		{
			return base[index] as OracleError;
		}
		set
		{
			base[index] = value;
		}
	}

	static OracleErrorCollection()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	internal OracleErrorCollection()
	{
	}
}
