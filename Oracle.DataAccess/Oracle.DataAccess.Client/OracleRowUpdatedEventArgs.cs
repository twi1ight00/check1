using System.Data;
using System.Data.Common;

namespace Oracle.DataAccess.Client;

public sealed class OracleRowUpdatedEventArgs : RowUpdatedEventArgs
{
	public new OracleCommand Command => (OracleCommand)base.Command;

	static OracleRowUpdatedEventArgs()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public OracleRowUpdatedEventArgs(DataRow row, IDbCommand command, StatementType statementType, DataTableMapping tableMapping)
		: base(row, command, statementType, tableMapping)
	{
	}
}
