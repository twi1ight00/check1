using System;

namespace Oracle.DataAccess.Client;

[Flags]
public enum OracleBulkCopyOptions
{
	Default = 0,
	UseInternalTransaction = 1
}
