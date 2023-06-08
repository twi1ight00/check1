namespace Oracle.DataAccess.Client;

public enum OracleDBShutdownMode
{
	Default,
	Transactional,
	TransactionalLocal,
	Immediate,
	Abort,
	Final
}
