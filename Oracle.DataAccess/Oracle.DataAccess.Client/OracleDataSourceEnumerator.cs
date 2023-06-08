using System;
using System.Data;
using System.Data.Common;

namespace Oracle.DataAccess.Client;

public sealed class OracleDataSourceEnumerator : DbDataSourceEnumerator
{
	static OracleDataSourceEnumerator()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public override DataTable GetDataSources()
	{
		string tnsAliases = null;
		string port = null;
		string server = null;
		string service = null;
		string protocol = null;
		int num = 0;
		DataTable dataTable = new DataTable("DataSource");
		dataTable.Columns.Add(new DataColumn("InstanceName", typeof(string)));
		dataTable.Columns.Add(new DataColumn("ServerName", typeof(string)));
		dataTable.Columns.Add(new DataColumn("ServiceName", typeof(string)));
		dataTable.Columns.Add(new DataColumn("Protocol", typeof(string)));
		dataTable.Columns.Add(new DataColumn("Port", typeof(string)));
		try
		{
			num = OpsCom.ParseTnsnamesFile(out tnsAliases, out port, out server, out service, out protocol);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		if (num != 0 || tnsAliases == null)
		{
			return dataTable;
		}
		char[] separator = new char[1] { ' ' };
		string[] array = tnsAliases.Split(separator);
		if (array == null)
		{
			return dataTable;
		}
		string[] array2 = port.Split(separator);
		string[] array3 = server.Split(separator);
		string[] array4 = service.Split(separator);
		string[] array5 = protocol.Split(separator);
		DataRow dataRow = null;
		int num2 = array.Length;
		for (int i = 0; i < num2; i++)
		{
			dataRow = dataTable.NewRow();
			dataRow["InstanceName"] = array[i];
			dataRow["ServerName"] = ((array3[i] != "*") ? array3[i] : string.Empty);
			dataRow["ServiceName"] = ((array4[i] != "*") ? array4[i] : string.Empty);
			dataRow["Protocol"] = ((array5[i] != "*") ? array5[i] : string.Empty);
			dataRow["Port"] = ((array2[i] != "*") ? array2[i] : string.Empty);
			dataTable.Rows.Add(dataRow);
		}
		return dataTable;
	}
}
