using System;

namespace Oracle.DataAccess.Client;

internal struct OpoConValCtx
{
	public int InMtsTxn;

	public int Enlist;

	public int Pooling;

	public int OSAuthent;

	public int ServerAttach;

	public int SessionBegin;

	public int DBAPrivilege;

	public int SetIntAndExtName;

	public int TxnHndAllocated;

	public int StmtCacheSize;

	public int StmtCachePurge;

	public int registerHA;

	public IntPtr HASubscrHnd;

	public int reRegHAFailed;

	public int registerRLB;

	public IntPtr RLBSubscrHnd;

	public int reRegRLBFailed;

	public int bTAFEnabled;

	public int PSPE;

	public int MajorVersion;

	public int MinorVersion;

	public int PatchSetVersion;

	public int DbNtfPort;

	public int HABasedConClose;

	public int DBStartup;

	public int OracleDBStartupMode;

	public int OracleDBShutdownMode;

	public int ConSignature;

	public int bIsTimesTen;

	public IntPtr pITransactionPromote;

	public IntPtr token;

	public int token_size;
}
