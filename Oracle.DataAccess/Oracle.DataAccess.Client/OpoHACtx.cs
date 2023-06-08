using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal class OpoHACtx
{
	public HAEventType eventType;

	public OracleHAEventSource source;

	public OracleHAEventStatus status;

	public string dbName;

	public string dbDomainName;

	public string hostName;

	public string instName;

	public string serviceName;

	public short year;

	public byte month;

	public byte day;

	public byte hour;

	public byte min;

	public byte sec;

	public uint fsec;

	public int cardinality;

	public OpoHACtx()
	{
		eventType = HAEventType.Invalid;
		dbName = null;
		dbDomainName = null;
		hostName = null;
		instName = null;
		serviceName = null;
	}

	public void Process()
	{
		ConnectionDispenser.HACallbackProcessing(this);
	}
}
