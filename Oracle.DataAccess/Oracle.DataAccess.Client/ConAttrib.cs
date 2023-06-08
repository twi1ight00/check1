namespace Oracle.DataAccess.Client;

internal class ConAttrib
{
	public const string DataSrc = "DATA SOURCE";

	public const string DBAPriv = "DBA PRIVILEGE";

	public const string Enlist = "ENLIST";

	public const string Lifetime = "CONNECTION LIFETIME";

	public const string PoolInc = "INCR POOL SIZE";

	public const string PoolDec = "DECR POOL SIZE";

	public const string MaxPool = "MAX POOL SIZE";

	public const string MinPool = "MIN POOL SIZE";

	public const string Passwd = "PASSWORD";

	public const string Persist = "PERSIST SECURITY INFO";

	public const string Pooling = "POOLING";

	public const string Timeout = "CONNECTION TIMEOUT";

	public const string Timeout2 = "CONNECT TIMEOUT";

	public const string UserID = "USER ID";

	public const string ProxyUsr = "PROXY USER ID";

	public const string ProxyPwd = "PROXY PASSWORD";

	public const string ValidCon = "VALIDATE CONNECTION";

	public const string StmtCache = "STATEMENT CACHE SIZE";

	public const string StmtCachePurge = "STATEMENT CACHE PURGE";

	public const string GridCR = "HA EVENTS";

	public const string GridRLB = "LOAD BALANCING";

	public const string MetaPool = "METADATA POOLING";

	public const string CtxConn = "CONTEXT CONNECTION";

	public const string PSPE = "PROMOTABLE TRANSACTION";

	public const string SelfTuning = "SELF TUNING";

	public const string PoolReg = "POOL REGULATOR";

	private ConAttrib()
	{
	}
}
