using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Drawing;
using Oracle.DataAccess.Types;

namespace Oracle.DataAccess.Client;

[DefaultEvent("RowUpdated")]
[Designer("Oracle.VsDevTools.OracleVSGDataAdapterWizard, Oracle.VsDevTools, Version=4.112.3.0, Culture=neutral, PublicKeyToken=89b483f429c47342, processorArchitecture=X86", typeof(IDesigner))]
[ToolboxBitmap(typeof(resfinder), "Oracle.DataAccess.src.Client.Icons.OracleDataAdapterToolBox_hc.bmp")]
public sealed class OracleDataAdapter : DbDataAdapter, IDbDataAdapter, IDataAdapter
{
	private OracleCommand m_selectCommand;

	private OracleCommand m_insertCommand;

	private OracleCommand m_updateCommand;

	private OracleCommand m_deleteCommand;

	private bool m_requery;

	private Hashtable m_safeMapping;

	private static readonly object EventRowUpdated;

	private static readonly object EventRowUpdating;

	private int m_updateBatchSize = 1;

	private BatchUpdateHelper m_batchUpdateHelper;

	private bool m_bGBRAInvoked;

	private Array m_errorCodesArray;

	private Array m_errMsgsArray;

	private Array m_rowsModArray;

	IDbCommand IDbDataAdapter.SelectCommand
	{
		get
		{
			return m_selectCommand;
		}
		set
		{
			m_selectCommand = (OracleCommand)value;
		}
	}

	IDbCommand IDbDataAdapter.InsertCommand
	{
		get
		{
			return m_insertCommand;
		}
		set
		{
			m_insertCommand = (OracleCommand)value;
		}
	}

	IDbCommand IDbDataAdapter.UpdateCommand
	{
		get
		{
			return m_updateCommand;
		}
		set
		{
			m_updateCommand = (OracleCommand)value;
		}
	}

	IDbCommand IDbDataAdapter.DeleteCommand
	{
		get
		{
			return m_deleteCommand;
		}
		set
		{
			m_deleteCommand = (OracleCommand)value;
		}
	}

	[Category("Fill")]
	[DefaultValue(null)]
	[Description("")]
	public new OracleCommand SelectCommand
	{
		get
		{
			return m_selectCommand;
		}
		set
		{
			m_selectCommand = value;
		}
	}

	[Description("")]
	[Category("Update")]
	[DefaultValue(null)]
	public new OracleCommand InsertCommand
	{
		get
		{
			return m_insertCommand;
		}
		set
		{
			m_insertCommand = value;
		}
	}

	[Description("")]
	[Category("Update")]
	[DefaultValue(null)]
	public new OracleCommand UpdateCommand
	{
		get
		{
			return m_updateCommand;
		}
		set
		{
			m_updateCommand = value;
		}
	}

	[Description("")]
	[Category("Update")]
	[DefaultValue(null)]
	public new OracleCommand DeleteCommand
	{
		get
		{
			return m_deleteCommand;
		}
		set
		{
			m_deleteCommand = value;
		}
	}

	[Description("")]
	[DefaultValue(true)]
	[Category("Fill")]
	public bool Requery
	{
		get
		{
			return m_requery;
		}
		set
		{
			m_requery = value;
		}
	}

	[Category("Mapping")]
	[Description("")]
	public Hashtable SafeMapping
	{
		get
		{
			if (m_safeMapping == null)
			{
				m_safeMapping = new Hashtable();
			}
			return Hashtable.Synchronized(m_safeMapping);
		}
	}

	[DefaultValue(1)]
	public override int UpdateBatchSize
	{
		get
		{
			return m_updateBatchSize;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			m_updateBatchSize = value;
		}
	}

	public event OracleRowUpdatingEventHandler RowUpdating
	{
		add
		{
			base.Events.AddHandler(EventRowUpdating, value);
		}
		remove
		{
			base.Events.RemoveHandler(EventRowUpdating, value);
		}
	}

	public event OracleRowUpdatedEventHandler RowUpdated
	{
		add
		{
			base.Events.AddHandler(EventRowUpdated, value);
		}
		remove
		{
			base.Events.RemoveHandler(EventRowUpdated, value);
		}
	}

	static OracleDataAdapter()
	{
		EventRowUpdated = new object();
		EventRowUpdating = new object();
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public OracleDataAdapter()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataAdapter::OracleDataAdapter(1)\n");
		}
		m_requery = true;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataAdapter::OracleDataAdapter(1)\n");
		}
	}

	public OracleDataAdapter(OracleCommand selectCommand)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataAdapter::OracleDataAdapter(2)\n");
		}
		m_requery = true;
		m_selectCommand = selectCommand;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataAdapter::OracleDataAdapter(2)\n");
		}
	}

	public OracleDataAdapter(string selectCommandText, OracleConnection selectConnection)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataAdapter::OracleDataAdapter(3)\n");
		}
		m_requery = true;
		m_selectCommand = new OracleCommand(selectCommandText, selectConnection);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataAdapter::OracleDataAdapter(3)\n");
		}
	}

	public OracleDataAdapter(string selectCommandText, string selectConnectionString)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataAdapter::OracleDataAdapter(4)\n");
		}
		m_requery = true;
		m_selectCommand = new OracleCommand(selectCommandText, new OracleConnection(selectConnectionString));
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataAdapter::OracleDataAdapter(4)\n");
		}
	}

	public int Fill(DataTable dataTable, OracleRefCursor refCursor)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataAdapter::Fill(1)\n");
		}
		if (dataTable == null)
		{
			throw new ArgumentNullException("dataTable");
		}
		if (refCursor == null)
		{
			throw new ArgumentNullException("refCursor");
		}
		OracleDataReader dataReader = refCursor.GetDataReader(fillRequest: true);
		if (dataReader.CurrentRow > 0)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.DA_FORWARD_ONLY));
		}
		int result = 0;
		try
		{
			result = Fill(dataTable, dataReader);
		}
		finally
		{
			dataReader.Close();
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataAdapter::Fill(1)\n");
		}
		return result;
	}

	public int Fill(DataSet dataSet, OracleRefCursor refCursor)
	{
		string srcTable = "Table";
		int startRecord = 0;
		int maxRecords = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataAdapter::Fill(2)\n");
		}
		if (dataSet == null)
		{
			throw new ArgumentNullException("dataSet");
		}
		if (refCursor == null)
		{
			throw new ArgumentNullException("refCursor");
		}
		OracleDataReader dataReader = refCursor.GetDataReader(fillRequest: true);
		if (dataReader.CurrentRow > 0)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.DA_FORWARD_ONLY));
		}
		int result = 0;
		try
		{
			result = Fill(dataSet, srcTable, dataReader, startRecord, maxRecords);
		}
		finally
		{
			dataReader.Close();
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataAdapter::Fill(2)\n");
		}
		return result;
	}

	public int Fill(DataSet dataSet, string srcTable, OracleRefCursor refCursor)
	{
		int startRecord = 0;
		int maxRecords = 0;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataAdapter::Fill(3)\n");
		}
		if (dataSet == null)
		{
			throw new ArgumentNullException("dataSet");
		}
		if (refCursor == null)
		{
			throw new ArgumentNullException("refCursor");
		}
		OracleDataReader dataReader = refCursor.GetDataReader(fillRequest: true);
		if (dataReader.CurrentRow > 0)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.DA_FORWARD_ONLY));
		}
		int result = 0;
		try
		{
			result = Fill(dataSet, srcTable, dataReader, startRecord, maxRecords);
		}
		finally
		{
			dataReader.Close();
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataAdapter::Fill(3)\n");
		}
		return result;
	}

	public int Fill(DataSet dataSet, int startRecord, int maxRecords, string srcTable, OracleRefCursor refCursor)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataAdapter::Fill(4)\n");
		}
		if (dataSet == null)
		{
			throw new ArgumentNullException("dataSet");
		}
		if (refCursor == null)
		{
			throw new ArgumentNullException("refCursor");
		}
		OracleDataReader dataReader = refCursor.GetDataReader(fillRequest: true);
		int currentRow = dataReader.CurrentRow;
		startRecord -= currentRow;
		if (startRecord < 0)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.DA_FORWARD_ONLY));
		}
		int result = 0;
		try
		{
			result = Fill(dataSet, srcTable, dataReader, startRecord, maxRecords);
		}
		finally
		{
			if (dataReader.IsEOF)
			{
				dataReader.Close();
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataAdapter::Fill(4)\n");
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataAdapter::Dispose()\n");
		}
		try
		{
			if (m_safeMapping != null)
			{
				m_safeMapping = null;
			}
		}
		finally
		{
			try
			{
				base.Dispose(disposing);
			}
			catch
			{
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataAdapter::Dispose()\n");
		}
	}

	protected override RowUpdatedEventArgs CreateRowUpdatedEvent(DataRow dataRow, IDbCommand command, StatementType statementType, DataTableMapping tableMapping)
	{
		return new OracleRowUpdatedEventArgs(dataRow, command, statementType, tableMapping);
	}

	protected override RowUpdatingEventArgs CreateRowUpdatingEvent(DataRow dataRow, IDbCommand command, StatementType statementType, DataTableMapping tableMapping)
	{
		return new OracleRowUpdatingEventArgs(dataRow, command, statementType, tableMapping);
	}

	protected override void OnRowUpdating(RowUpdatingEventArgs value)
	{
		OracleRowUpdatingEventHandler oracleRowUpdatingEventHandler = (OracleRowUpdatingEventHandler)base.Events[EventRowUpdating];
		if (oracleRowUpdatingEventHandler != null && value is OracleRowUpdatingEventArgs e)
		{
			oracleRowUpdatingEventHandler(this, e);
		}
	}

	protected override void OnRowUpdated(RowUpdatedEventArgs value)
	{
		bool flag = false;
		if (OraTrace.m_RevertBUErrHandling == 0 && !m_bGBRAInvoked && m_updateBatchSize > 1 && value.Errors == null && m_batchUpdateHelper != null)
		{
			int num = 0;
			int length = m_rowsModArray.Length;
			for (int i = 0; i < length; i++)
			{
				int num2 = (int)m_rowsModArray.GetValue(i);
				if (num2 > 0)
				{
					num++;
				}
			}
			if (num < length)
			{
				value.Errors = new DBConcurrencyException();
				flag = true;
			}
		}
		OracleRowUpdatedEventHandler oracleRowUpdatedEventHandler = (OracleRowUpdatedEventHandler)base.Events[EventRowUpdated];
		if (oracleRowUpdatedEventHandler != null && value is OracleRowUpdatedEventArgs e)
		{
			oracleRowUpdatedEventHandler(this, e);
		}
		if (flag)
		{
			throw value.Errors;
		}
	}

	protected override int Fill(DataTable[] dataTables, int startRecord, int maxRecords, IDbCommand command, CommandBehavior behavior)
	{
		if (dataTables == null)
		{
			throw new ArgumentNullException("dataTables");
		}
		if (command == null)
		{
			throw new ArgumentNullException("command");
		}
		OracleCommand oracleCommand = (OracleCommand)command;
		behavior |= CommandBehavior.SequentialAccess;
		if (base.MissingSchemaAction == MissingSchemaAction.AddWithKey)
		{
			behavior |= CommandBehavior.KeyInfo;
		}
		bool flag = false;
		if (oracleCommand.Connection != null && oracleCommand.Connection.m_state == ConnectionState.Closed)
		{
			flag = true;
		}
		OracleDataReader oracleDataReader = null;
		bool localParse = oracleCommand.m_localParse;
		try
		{
			oracleCommand.m_localParse = true;
			oracleDataReader = oracleCommand.ExecuteReader(m_requery, fillRequest: true, behavior);
			oracleCommand.m_localParse = localParse;
		}
		catch
		{
			oracleCommand.m_localParse = localParse;
			if (flag && oracleCommand.Connection.m_state == ConnectionState.Open)
			{
				try
				{
					oracleCommand.Connection.Close();
				}
				catch
				{
				}
			}
			throw;
		}
		if (m_safeMapping != null)
		{
			lock (m_safeMapping.SyncRoot)
			{
				foreach (DictionaryEntry item in m_safeMapping)
				{
					if ((Type)item.Value != typeof(string) && (Type)item.Value != typeof(byte[]))
					{
						throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.DA_INV_SAFE_TYPE));
					}
				}
				oracleDataReader.SafeMapping = Hashtable.Synchronized(m_safeMapping);
			}
		}
		oracleDataReader.IsFillReader = true;
		if (!m_requery)
		{
			int currentRow = oracleDataReader.CurrentRow;
			startRecord -= currentRow;
			if (startRecord < 0)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.DA_FORWARD_ONLY));
			}
		}
		int result = 0;
		try
		{
			result = base.Fill(dataTables, oracleDataReader, startRecord, maxRecords);
			ArrayList schemaTables = oracleDataReader.SchemaTables;
			for (int i = 0; i < schemaTables.Count; i++)
			{
				DataTable dataTable = dataTables[i];
				DataTable dataTable2 = (DataTable)schemaTables[i];
				int j = 0;
				Hashtable hashtable = new Hashtable();
				Hashtable hashtable2 = new Hashtable();
				DataTableMapping dataTableMapping = null;
				if (base.TableMappings.IndexOfDataSetTable(dataTable.TableName) != -1)
				{
					dataTableMapping = base.TableMappings.GetByDataSetTable(dataTable.TableName);
				}
				for (; dataTable.ExtendedProperties.ContainsKey("BaseTable." + j); j++)
				{
				}
				if (dataTable2.ExtendedProperties.ContainsKey("REFCursorName"))
				{
					dataTable.ExtendedProperties["REFCursorName"] = dataTable2.ExtendedProperties["REFCursorName"];
				}
				bool flag2 = false;
				foreach (DataRow row in dataTable2.Rows)
				{
					if (!row.IsNull("ColumnName"))
					{
						hashtable[(string)row["ColumnName"]] = true;
					}
					if (!flag2 && !row.IsNull("BaseSchemaName"))
					{
						dataTable.ExtendedProperties["BaseSchema"] = (string)row["BaseSchemaName"];
						flag2 = true;
					}
				}
				foreach (DataRow row2 in dataTable2.Rows)
				{
					if (!row2.IsNull("BaseTableName") && !dataTable.ExtendedProperties.ContainsValue(row2["BaseTableName"]))
					{
						dataTable.ExtendedProperties["BaseTable." + j] = (string)row2["BaseTableName"];
						j++;
					}
					if (row2.IsNull("ColumnName"))
					{
						continue;
					}
					string text = (string)row2["ColumnName"];
					string text2 = text;
					if (hashtable2[text2] == null)
					{
						hashtable2[text2] = true;
					}
					else
					{
						int num = 0;
						while (hashtable[text2] != null)
						{
							num++;
							text2 = text + num;
						}
						hashtable[text2] = true;
					}
					if (dataTableMapping != null)
					{
						DataColumnMapping columnMappingBySchemaAction = dataTableMapping.GetColumnMappingBySchemaAction(text2, base.MissingMappingAction);
						if (columnMappingBySchemaAction != null)
						{
							text2 = columnMappingBySchemaAction.DataSetColumn;
						}
					}
					DataColumn dataColumn = null;
					if (dataTable.Columns.IndexOf(text2) != -1)
					{
						dataColumn = dataTable.Columns[text2];
					}
					if (dataColumn != null)
					{
						if (!row2.IsNull("BaseColumnName"))
						{
							dataColumn.ExtendedProperties["BaseColumn"] = (string)row2["BaseColumnName"];
						}
						if (!row2.IsNull("OraDbType"))
						{
							dataColumn.ExtendedProperties["OraDbType"] = (int)row2["OraDbType"];
						}
						if (!row2.IsNull("UdtTypeName"))
						{
							dataColumn.ExtendedProperties["UdtTypeName"] = (string)row2["UdtTypeName"];
						}
					}
				}
			}
		}
		finally
		{
			if (oracleDataReader.IsEOF || m_requery)
			{
				oracleDataReader.Close();
			}
		}
		oracleDataReader = null;
		return result;
	}

	protected override int Fill(DataTable dataTable, IDbCommand command, CommandBehavior behavior)
	{
		if (dataTable == null)
		{
			throw new ArgumentNullException("dataTable");
		}
		if (command == null)
		{
			throw new ArgumentNullException("command");
		}
		OracleCommand oracleCommand = (OracleCommand)command;
		behavior = behavior | CommandBehavior.SingleResult | CommandBehavior.SequentialAccess;
		if (base.MissingSchemaAction == MissingSchemaAction.AddWithKey)
		{
			behavior |= CommandBehavior.KeyInfo;
		}
		bool flag = false;
		if (oracleCommand.Connection != null && oracleCommand.Connection.m_state == ConnectionState.Closed)
		{
			flag = true;
		}
		bool localParse = oracleCommand.m_localParse;
		OracleDataReader oracleDataReader;
		try
		{
			oracleCommand.m_localParse = true;
			oracleDataReader = oracleCommand.ExecuteReader(m_requery, fillRequest: true, behavior);
			oracleCommand.m_localParse = localParse;
		}
		catch
		{
			oracleCommand.m_localParse = localParse;
			if (flag && oracleCommand.Connection.m_state == ConnectionState.Open)
			{
				try
				{
					oracleCommand.Connection.Close();
				}
				catch
				{
				}
			}
			throw;
		}
		if (!m_requery && oracleDataReader.CurrentRow > 0)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.DA_FORWARD_ONLY));
		}
		int result = 0;
		try
		{
			result = Fill(dataTable, oracleDataReader);
		}
		finally
		{
			oracleDataReader.Close();
		}
		oracleCommand = null;
		oracleDataReader = null;
		return result;
	}

	protected override int Fill(DataSet dataSet, int startRecord, int maxRecords, string srcTable, IDbCommand command, CommandBehavior behavior)
	{
		if (dataSet == null)
		{
			throw new ArgumentNullException("dataSet");
		}
		if (command == null)
		{
			throw new ArgumentNullException("command");
		}
		OracleCommand oracleCommand = (OracleCommand)command;
		behavior |= CommandBehavior.SequentialAccess;
		if (base.MissingSchemaAction == MissingSchemaAction.AddWithKey)
		{
			behavior |= CommandBehavior.KeyInfo;
		}
		bool flag = false;
		if (oracleCommand.Connection != null && oracleCommand.Connection.m_state == ConnectionState.Closed)
		{
			flag = true;
		}
		bool localParse = oracleCommand.m_localParse;
		OracleDataReader oracleDataReader;
		try
		{
			oracleCommand.m_localParse = true;
			oracleDataReader = oracleCommand.ExecuteReader(m_requery, fillRequest: true, behavior);
			oracleCommand.m_localParse = localParse;
		}
		catch
		{
			oracleCommand.m_localParse = localParse;
			if (flag && oracleCommand.Connection.m_state == ConnectionState.Open)
			{
				try
				{
					oracleCommand.Connection.Close();
				}
				catch
				{
				}
			}
			throw;
		}
		if (!m_requery)
		{
			int currentRow = oracleDataReader.CurrentRow;
			startRecord -= currentRow;
			if (startRecord < 0)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.DA_FORWARD_ONLY));
			}
		}
		int num = 0;
		try
		{
			return Fill(dataSet, srcTable, oracleDataReader, startRecord, maxRecords);
		}
		finally
		{
			if (oracleDataReader.IsEOF || m_requery)
			{
				oracleDataReader.Close();
			}
		}
	}

	protected override int Fill(DataTable dataTable, IDataReader dataReader)
	{
		if (dataTable == null)
		{
			throw new ArgumentNullException("dataTable");
		}
		if (dataReader == null)
		{
			throw new ArgumentNullException("dataReader");
		}
		OracleDataReader oracleDataReader = (OracleDataReader)dataReader;
		if (m_safeMapping != null)
		{
			lock (m_safeMapping.SyncRoot)
			{
				foreach (DictionaryEntry item in m_safeMapping)
				{
					if ((Type)item.Value != typeof(string) && (Type)item.Value != typeof(byte[]))
					{
						throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.DA_INV_SAFE_TYPE));
					}
				}
				if (m_safeMapping != null)
				{
					oracleDataReader.SafeMapping = Hashtable.Synchronized(m_safeMapping);
				}
				else
				{
					oracleDataReader.SafeMapping = Hashtable.Synchronized(m_safeMapping = new Hashtable());
				}
			}
		}
		oracleDataReader.IsFillReader = true;
		int result = base.Fill(dataTable, dataReader);
		ArrayList schemaTables = oracleDataReader.SchemaTables;
		for (int i = 0; i < schemaTables.Count; i++)
		{
			DataTable dataTable2 = (DataTable)schemaTables[i];
			int j = 0;
			Hashtable hashtable = new Hashtable();
			Hashtable hashtable2 = new Hashtable();
			DataTableMapping dataTableMapping = null;
			if (base.TableMappings.IndexOfDataSetTable(dataTable.TableName) != -1)
			{
				dataTableMapping = base.TableMappings.GetByDataSetTable(dataTable.TableName);
			}
			for (; dataTable.ExtendedProperties.ContainsKey("BaseTable." + j); j++)
			{
			}
			if (dataTable2.ExtendedProperties.ContainsKey("REFCursorName"))
			{
				dataTable.ExtendedProperties["REFCursorName"] = dataTable2.ExtendedProperties["REFCursorName"];
			}
			bool flag = false;
			foreach (DataRow row in dataTable2.Rows)
			{
				if (!row.IsNull("ColumnName"))
				{
					hashtable[(string)row["ColumnName"]] = true;
				}
				if (!flag && !row.IsNull("BaseSchemaName"))
				{
					dataTable.ExtendedProperties["BaseSchema"] = (string)row["BaseSchemaName"];
					flag = true;
				}
			}
			foreach (DataRow row2 in dataTable2.Rows)
			{
				if (!row2.IsNull("BaseTableName") && !dataTable.ExtendedProperties.ContainsValue(row2["BaseTableName"]))
				{
					dataTable.ExtendedProperties["BaseTable." + j] = (string)row2["BaseTableName"];
					j++;
				}
				if (row2.IsNull("ColumnName"))
				{
					continue;
				}
				string text = (string)row2["ColumnName"];
				string text2 = text;
				if (hashtable2[text2] == null)
				{
					hashtable2[text2] = true;
				}
				else
				{
					int num = 0;
					while (hashtable[text2] != null)
					{
						num++;
						text2 = text + num;
					}
					hashtable[text2] = true;
				}
				if (dataTableMapping != null)
				{
					DataColumnMapping columnMappingBySchemaAction = dataTableMapping.GetColumnMappingBySchemaAction(text2, base.MissingMappingAction);
					if (columnMappingBySchemaAction != null)
					{
						text2 = columnMappingBySchemaAction.DataSetColumn;
					}
				}
				DataColumn dataColumn = null;
				if (dataTable.Columns.IndexOf(text2) != -1)
				{
					dataColumn = dataTable.Columns[text2];
				}
				if (dataColumn != null)
				{
					if (!row2.IsNull("BaseColumnName"))
					{
						dataColumn.ExtendedProperties["BaseColumn"] = (string)row2["BaseColumnName"];
					}
					if (!row2.IsNull("OraDbType"))
					{
						dataColumn.ExtendedProperties["OraDbType"] = (int)row2["OraDbType"];
					}
					if (!row2.IsNull("UdtTypeName"))
					{
						dataColumn.ExtendedProperties["UdtTypeName"] = (string)row2["UdtTypeName"];
					}
				}
			}
		}
		oracleDataReader = null;
		return result;
	}

	protected override int Fill(DataSet dataSet, string srcTable, IDataReader dataReader, int startRecord, int maxRecords)
	{
		if (dataSet == null)
		{
			throw new ArgumentNullException("dataSet");
		}
		if (dataReader == null)
		{
			throw new ArgumentNullException("dataReader");
		}
		OracleDataReader oracleDataReader = (OracleDataReader)dataReader;
		if (m_safeMapping != null)
		{
			lock (m_safeMapping.SyncRoot)
			{
				foreach (DictionaryEntry item in m_safeMapping)
				{
					if ((Type)item.Value != typeof(string) && (Type)item.Value != typeof(byte[]))
					{
						throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.DA_INV_SAFE_TYPE));
					}
				}
				if (m_safeMapping != null)
				{
					oracleDataReader.SafeMapping = Hashtable.Synchronized(m_safeMapping);
				}
				else
				{
					oracleDataReader.SafeMapping = Hashtable.Synchronized(m_safeMapping = new Hashtable());
				}
			}
		}
		oracleDataReader.IsFillReader = true;
		int result = base.Fill(dataSet, srcTable, dataReader, startRecord, maxRecords);
		ArrayList schemaTables = oracleDataReader.SchemaTables;
		for (int i = 0; i < schemaTables.Count; i++)
		{
			string text = srcTable;
			if (i > 0)
			{
				text = srcTable + i;
			}
			DataTableMapping dataTableMapping = null;
			if (base.TableMappings.IndexOf(text) != -1)
			{
				dataTableMapping = base.TableMappings[text];
			}
			if (dataTableMapping != null)
			{
				text = dataTableMapping.DataSetTable;
			}
			DataTable dataTable = null;
			if (dataSet.Tables.IndexOf(text) != -1)
			{
				dataTable = dataSet.Tables[text];
			}
			if (dataTable != null)
			{
				DataTable dataTable2 = (DataTable)schemaTables[i];
				int j = 0;
				Hashtable hashtable = new Hashtable();
				Hashtable hashtable2 = new Hashtable();
				for (; dataTable.ExtendedProperties.ContainsKey("BaseTable." + j); j++)
				{
				}
				if (dataTable2.ExtendedProperties.ContainsKey("REFCursorName"))
				{
					dataTable.ExtendedProperties["REFCursorName"] = dataTable2.ExtendedProperties["REFCursorName"];
				}
				bool flag = false;
				foreach (DataRow row in dataTable2.Rows)
				{
					if (!row.IsNull("ColumnName"))
					{
						hashtable[(string)row["ColumnName"]] = true;
					}
					if (!flag && !row.IsNull("BaseSchemaName"))
					{
						dataTable.ExtendedProperties["BaseSchema"] = (string)row["BaseSchemaName"];
						flag = true;
					}
				}
				foreach (DataRow row2 in dataTable2.Rows)
				{
					if (!row2.IsNull("BaseTableName") && !dataTable.ExtendedProperties.ContainsValue(row2["BaseTableName"]))
					{
						dataTable.ExtendedProperties["BaseTable." + j] = (string)row2["BaseTableName"];
						j++;
					}
					if (row2.IsNull("ColumnName"))
					{
						continue;
					}
					string text2 = (string)row2["ColumnName"];
					string text3 = text2;
					if (hashtable2[text3] == null)
					{
						hashtable2[text3] = true;
					}
					else
					{
						int num = 0;
						while (hashtable[text3] != null)
						{
							num++;
							text3 = text2 + num;
						}
						hashtable[text3] = true;
					}
					if (dataTableMapping != null)
					{
						DataColumnMapping columnMappingBySchemaAction = dataTableMapping.GetColumnMappingBySchemaAction(text3, base.MissingMappingAction);
						if (columnMappingBySchemaAction != null)
						{
							text3 = columnMappingBySchemaAction.DataSetColumn;
						}
					}
					DataColumn dataColumn = null;
					if (dataTable.Columns.IndexOf(text3) != -1)
					{
						dataColumn = dataTable.Columns[text3];
					}
					if (dataColumn != null)
					{
						if (!row2.IsNull("BaseColumnName"))
						{
							dataColumn.ExtendedProperties["BaseColumn"] = (string)row2["BaseColumnName"];
						}
						if (!row2.IsNull("OraDbType"))
						{
							dataColumn.ExtendedProperties["OraDbType"] = (int)row2["OraDbType"];
						}
						if (!row2.IsNull("UdtTypeName"))
						{
							dataColumn.ExtendedProperties["UdtTypeName"] = (string)row2["UdtTypeName"];
						}
					}
				}
			}
			dataTable = null;
			dataTableMapping = null;
		}
		oracleDataReader = null;
		return result;
	}

	protected override DataTable FillSchema(DataTable dataTable, SchemaType schemaType, IDbCommand command, CommandBehavior behavior)
	{
		if (dataTable == null)
		{
			throw new ArgumentNullException("dataTable");
		}
		if (command == null)
		{
			throw new ArgumentNullException("command");
		}
		OracleCommand oracleCommand = (OracleCommand)command;
		if (m_safeMapping != null)
		{
			lock (m_safeMapping.SyncRoot)
			{
				foreach (DictionaryEntry item in m_safeMapping)
				{
					if ((Type)item.Value != typeof(string) && (Type)item.Value != typeof(byte[]))
					{
						throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.DA_INV_SAFE_TYPE));
					}
				}
				if (m_safeMapping != null)
				{
					oracleCommand.m_safeMapping = Hashtable.Synchronized(m_safeMapping);
				}
				else
				{
					oracleCommand.m_safeMapping = Hashtable.Synchronized(m_safeMapping = new Hashtable());
				}
			}
		}
		oracleCommand.m_returnPSTypes = ReturnProviderSpecificTypes;
		bool localParse = oracleCommand.m_localParse;
		oracleCommand.m_localParse = true;
		DataTable result = null;
		try
		{
			result = base.FillSchema(dataTable, schemaType, command, behavior);
		}
		finally
		{
			oracleCommand.m_localParse = localParse;
			oracleCommand.m_returnPSTypes = false;
		}
		oracleCommand = null;
		return result;
	}

	protected override DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType, IDbCommand command, string srcTable, CommandBehavior behavior)
	{
		if (dataSet == null)
		{
			throw new ArgumentNullException("dataSet");
		}
		if (command == null)
		{
			throw new ArgumentNullException("command");
		}
		OracleCommand oracleCommand = (OracleCommand)command;
		if (m_safeMapping != null)
		{
			lock (m_safeMapping.SyncRoot)
			{
				foreach (DictionaryEntry item in m_safeMapping)
				{
					if ((Type)item.Value != typeof(string) && (Type)item.Value != typeof(byte[]))
					{
						throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.DA_INV_SAFE_TYPE));
					}
				}
				if (m_safeMapping != null)
				{
					oracleCommand.m_safeMapping = Hashtable.Synchronized(m_safeMapping);
				}
				else
				{
					oracleCommand.m_safeMapping = Hashtable.Synchronized(m_safeMapping = new Hashtable());
				}
			}
		}
		oracleCommand.m_returnPSTypes = ReturnProviderSpecificTypes;
		bool localParse = oracleCommand.m_localParse;
		oracleCommand.m_localParse = true;
		DataTable[] result = null;
		try
		{
			result = base.FillSchema(dataSet, schemaType, command, srcTable, behavior);
		}
		finally
		{
			oracleCommand.m_localParse = localParse;
			oracleCommand.m_returnPSTypes = false;
		}
		oracleCommand = null;
		return result;
	}

	protected override int Update(DataRow[] dataRows, DataTableMapping tableMapping)
	{
		if (m_selectCommand == null || m_selectCommand.Connection == null)
		{
			return base.Update(dataRows, tableMapping);
		}
		if (m_selectCommand.Connection.State == ConnectionState.Closed)
		{
			try
			{
				try
				{
					m_selectCommand.Connection.Open();
				}
				catch
				{
				}
				return base.Update(dataRows, tableMapping);
			}
			finally
			{
				if (m_selectCommand.Connection.State == ConnectionState.Open)
				{
					m_selectCommand.Connection.Close();
				}
			}
		}
		return base.Update(dataRows, tableMapping);
	}

	protected override void InitializeBatching()
	{
		OracleCommand insertCommand = InsertCommand;
		OracleCommand deleteCommand = DeleteCommand;
		OracleCommand updateCommand = UpdateCommand;
		bool flag = false;
		if (insertCommand == null)
		{
			if (updateCommand != null && deleteCommand != null && deleteCommand.BindByName != updateCommand.BindByName)
			{
				flag = true;
			}
		}
		else if (updateCommand == null)
		{
			if (deleteCommand != null && deleteCommand.BindByName != insertCommand.BindByName)
			{
				flag = true;
			}
		}
		else if (updateCommand.BindByName != insertCommand.BindByName)
		{
			flag = true;
		}
		else if (deleteCommand != null && updateCommand.BindByName != deleteCommand.BindByName)
		{
			flag = true;
		}
		if (flag)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.DA_BU_BIND_VIOLATION));
		}
		if (m_batchUpdateHelper == null)
		{
			m_batchUpdateHelper = new BatchUpdateHelper();
		}
		m_batchUpdateHelper.InitializeBUC();
		OracleCommand oracleCommand = UpdateCommand;
		if (oracleCommand == null)
		{
			oracleCommand = DeleteCommand;
			if (oracleCommand == null)
			{
				oracleCommand = InsertCommand;
				if (oracleCommand == null)
				{
					oracleCommand = SelectCommand;
				}
			}
		}
		if (oracleCommand != null)
		{
			m_batchUpdateHelper.BatchUpdateCommand.Connection = oracleCommand.Connection;
			m_batchUpdateHelper.BatchUpdateCommand.CommandTimeout = oracleCommand.CommandTimeout;
			m_batchUpdateHelper.BatchUpdateCommand.BindByName = oracleCommand.BindByName;
		}
	}

	protected override int AddToBatch(IDbCommand command)
	{
		if (m_batchUpdateHelper != null)
		{
			return m_batchUpdateHelper.AddCommand(command as OracleCommand);
		}
		return -1;
	}

	protected override void ClearBatch()
	{
		if (m_batchUpdateHelper != null)
		{
			m_batchUpdateHelper.InitializeBUC();
		}
		m_errorCodesArray = null;
		m_errMsgsArray = null;
		m_rowsModArray = null;
	}

	protected override IDataParameter GetBatchedParameter(int commandIdentifier, int parameterIndex)
	{
		if (m_batchUpdateHelper != null)
		{
			return m_batchUpdateHelper.GetBatchedParameter(commandIdentifier, parameterIndex);
		}
		return null;
	}

	protected override int ExecuteBatch()
	{
		int result = 0;
		if (m_batchUpdateHelper != null)
		{
			m_batchUpdateHelper.FinalizeBUC();
			m_batchUpdateHelper.BatchUpdateCommand.ExecuteNonQuery();
			OracleParameterCollection parameters = m_batchUpdateHelper.BatchUpdateCommand.Parameters;
			m_errorCodesArray = parameters["aecd"].Value as Array;
			m_errMsgsArray = parameters["aem"].Value as Array;
			m_rowsModArray = parameters["armd"].Value as Array;
			OracleErrorCollection oracleErrorCollection = new OracleErrorCollection();
			int length = m_rowsModArray.Length;
			for (int i = 0; i < length; i++)
			{
				if ((int)m_rowsModArray.GetValue(i) == 0)
				{
					int num = (int)m_errorCodesArray.GetValue(i);
					if (num != 0)
					{
						string errMsg = (string)m_errMsgsArray.GetValue(i);
						OracleError value = new OracleError(num, string.Empty, string.Empty, errMsg);
						oracleErrorCollection.Add(value);
					}
				}
			}
			if (oracleErrorCollection.Count > 0)
			{
				throw new OracleException(oracleErrorCollection);
			}
			result = (int)parameters["rmd"].Value;
		}
		return result;
	}

	protected override void TerminateBatching()
	{
	}

	protected override bool GetBatchedRecordsAffected(int commandIdentifier, out int recordsAffected, out Exception error)
	{
		m_bGBRAInvoked = true;
		recordsAffected = 0;
		error = null;
		if (m_rowsModArray.Length <= commandIdentifier)
		{
			return false;
		}
		recordsAffected = (int)m_rowsModArray.GetValue(commandIdentifier);
		if (recordsAffected == 0)
		{
			int num = (int)m_errorCodesArray.GetValue(commandIdentifier);
			if (num != 0)
			{
				string errMsg = (string)m_errMsgsArray.GetValue(commandIdentifier);
				error = new OracleException(num, string.Empty, string.Empty, errMsg);
			}
		}
		return true;
	}
}
