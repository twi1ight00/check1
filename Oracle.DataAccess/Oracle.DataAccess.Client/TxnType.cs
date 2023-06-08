namespace Oracle.DataAccess.Client;

internal enum TxnType
{
	None,
	SystemTxn,
	COMPlus,
	LocalTxnForSysTxn
}
