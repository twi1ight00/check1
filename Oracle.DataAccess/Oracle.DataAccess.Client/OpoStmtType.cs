namespace Oracle.DataAccess.Client;

internal enum OpoStmtType : short
{
	SELECT = 1,
	UPDATE,
	DELETE,
	INSERT,
	CREATE,
	DROP,
	ALTER,
	BEGIN,
	DECLARE
}
