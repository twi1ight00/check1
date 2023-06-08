using System;
using System.Data;

namespace Oracle.DataAccess.Client;

public class OracleNotificationEventArgs : EventArgs
{
	internal OracleNotificationType m_type;

	internal OracleNotificationSource m_source;

	internal OracleNotificationInfo m_info;

	internal string[] m_resources;

	internal DataTable m_details;

	public OracleNotificationInfo Info => m_info;

	public OracleNotificationSource Source => m_source;

	public OracleNotificationType Type => m_type;

	public string[] ResourceNames => m_resources;

	public DataTable Details => m_details;

	static OracleNotificationEventArgs()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	internal OracleNotificationEventArgs()
	{
		m_type = OracleNotificationType.Change;
		m_source = OracleNotificationSource.Data;
		m_info = OracleNotificationInfo.Update;
		m_resources = new string[0];
		m_details = new DataTable();
		m_details.Columns.Add("ResourceName", typeof(string));
		m_details.Columns.Add("Info", typeof(OracleNotificationInfo));
		m_details.Columns.Add("Rowid", typeof(string));
		m_details.Columns.Add("QueryId", typeof(long));
	}

	internal void AddRowDetail(string name, OracleNotificationInfo info, string rowid, long queryid)
	{
		DataRow dataRow = m_details.NewRow();
		dataRow[0] = name;
		dataRow[1] = info;
		dataRow[2] = rowid;
		dataRow[3] = queryid;
		m_details.Rows.Add(dataRow);
	}
}
