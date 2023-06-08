using System.Data;
using System.Data.Common;

namespace Oracle.DataAccess.Client;

public sealed class OracleRowUpdatingEventArgs : RowUpdatingEventArgs
{
	public new OracleCommand Command
	{
		get
		{
			return (OracleCommand)base.Command;
		}
		set
		{
			base.Command = value;
		}
	}

	protected override IDbCommand BaseCommand
	{
		get
		{
			return base.BaseCommand;
		}
		set
		{
			base.BaseCommand = value as OracleCommand;
		}
	}

	static OracleRowUpdatingEventArgs()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public OracleRowUpdatingEventArgs(DataRow row, IDbCommand command, StatementType statementType, DataTableMapping tableMapping)
		: base(row, command, statementType, tableMapping)
	{
	}
}
