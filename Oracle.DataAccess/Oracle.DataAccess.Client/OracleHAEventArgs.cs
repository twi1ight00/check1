using System;

namespace Oracle.DataAccess.Client;

public sealed class OracleHAEventArgs : EventArgs
{
	private OracleHAEventSource m_source;

	private OracleHAEventStatus m_status;

	private string m_service;

	private string m_database;

	private string m_databaseDomain;

	private string m_host;

	private string m_instance;

	private DateTime m_time;

	public OracleHAEventSource Source => m_source;

	public OracleHAEventStatus Status => m_status;

	public string ServiceName => m_service;

	public string DatabaseName => m_database;

	public string DatabaseDomainName => m_databaseDomain;

	public string HostName => m_host;

	public string InstanceName => m_instance;

	public DateTime Time => m_time;

	static OracleHAEventArgs()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	internal OracleHAEventArgs(OpoHACtx opoHACtx)
	{
		m_source = opoHACtx.source;
		m_status = opoHACtx.status;
		m_service = opoHACtx.serviceName;
		m_database = opoHACtx.dbName;
		m_databaseDomain = opoHACtx.dbDomainName;
		m_instance = opoHACtx.instName;
		m_host = opoHACtx.hostName;
		m_time = new DateTime(opoHACtx.year, opoHACtx.month, opoHACtx.day, opoHACtx.hour, opoHACtx.min, opoHACtx.sec, (int)(opoHACtx.fsec / 1000000u));
	}
}
