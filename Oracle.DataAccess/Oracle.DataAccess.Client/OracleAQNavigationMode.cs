namespace Oracle.DataAccess.Client;

public enum OracleAQNavigationMode
{
	FirstMessage = 1,
	NextMessage = 3,
	NextTransaction = 2,
	FirstMessageMultiGroup = 4,
	NextMessageMultiGroup = 5
}
