namespace Oracle.DataAccess.Client;

internal struct OpoTxnValCtx
{
	public int Serializable;

	public int TxnHndAllocated;

	public int ForceDispose;

	public int ErrHndAllocated;
}
