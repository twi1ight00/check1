using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Timers;
using Oracle.DataAccess.Types;

namespace Oracle.DataAccess.Client;

public sealed class OracleBulkCopy : IDisposable
{
	private enum SourceType
	{
		Unspecified,
		IDataReader,
		OracleDataReader,
		DataTable,
		RowArray
	}

	private const int INTERNAL_BATCH_SIZE = 10000;

	private const int LONG_MAX_SIZE = int.MaxValue;

	private const int DEFAULT_TIMEOUT = 30;

	private const int ONE_SECOND = 1000;

	private unsafe OPOBulkCopyValCtx* m_pOpoBulkCopyValCtx;

	private unsafe OPOBulkCopyColCtx* m_pBlkColCtx;

	private IntPtr m_opsSqlCtx;

	private IntPtr m_opsConCtx;

	private IntPtr m_opsErrCtx;

	private int m_batchSize;

	private OracleBulkCopyOptions m_bulkCopyOptions;

	private int m_timeout;

	private OracleBulkCopyColumnMappingCollection m_columnMappings;

	private OracleBulkCopyColumnMappingCollection m_internalColumnMappings;

	private OracleConnection m_connection;

	private string m_destinationTableName;

	private string m_destinationPartitionName;

	private int m_notifyAfter;

	private int m_badRowNumber;

	private int m_badColNumber;

	private bool m_ownConnection;

	private bool m_insideRowsCopiedEvent;

	private bool m_fetchMeta;

	private bool m_OptimizedPathForOraDataReader;

	private OracleRowsCopiedEventHandler m_rowsCopiedEventHandler;

	private OracleTransaction m_internalTransaction;

	private DataRowState m_rowState;

	private int m_rowsCopied;

	private int m_conSignature;

	private int m_rowSize;

	private bool m_disposed;

	private static bool m_timeElapsed;

	private object m_dataSource;

	private IEnumerator m_rowEnumerator;

	private DataRow m_currentRow;

	private int m_srcColumnCount;

	private int m_dstColumnCount;

	private SourceType m_sourceType;

	private static int COL_NULLIND_SIZE;

	private static int COL_LEN_SIZE;

	private int COL_HEADER_SIZE = COL_NULLIND_SIZE + COL_LEN_SIZE;

	private int SIZE_OF_CHAR = 2;

	private unsafe int SIZE_OF_PTR = sizeof(IntPtr);

	[DefaultValue(0)]
	public int BatchSize
	{
		get
		{
			return m_batchSize;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("BatchSize");
			}
			m_batchSize = value;
		}
	}

	[DefaultValue(OracleBulkCopyOptions.Default)]
	public OracleBulkCopyOptions BulkCopyOptions
	{
		get
		{
			return m_bulkCopyOptions;
		}
		set
		{
			m_bulkCopyOptions = value;
		}
	}

	[DefaultValue(30)]
	public int BulkCopyTimeout
	{
		get
		{
			return m_timeout;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("BulkCopyTimeout");
			}
			m_timeout = value;
		}
	}

	public OracleBulkCopyColumnMappingCollection ColumnMappings
	{
		get
		{
			if (m_columnMappings == null)
			{
				m_columnMappings = new OracleBulkCopyColumnMappingCollection();
			}
			return m_columnMappings;
		}
	}

	public OracleConnection Connection => m_connection;

	public string DestinationTableName
	{
		get
		{
			if (m_destinationTableName == null)
			{
				return string.Empty;
			}
			return m_destinationTableName;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("DestinationTableName");
			}
			if (value.Length == 0)
			{
				throw new ArgumentException("DestinationTableName");
			}
			if (m_destinationTableName != value)
			{
				m_fetchMeta = true;
				m_destinationTableName = value;
			}
		}
	}

	public string DestinationPartitionName
	{
		get
		{
			if (m_destinationPartitionName == null)
			{
				return string.Empty;
			}
			return m_destinationPartitionName;
		}
		set
		{
			m_destinationPartitionName = value;
		}
	}

	[DefaultValue(0)]
	public int NotifyAfter
	{
		get
		{
			return m_notifyAfter;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("NotifyAfter");
			}
			m_notifyAfter = value;
		}
	}

	public event OracleRowsCopiedEventHandler OracleRowsCopied
	{
		add
		{
			m_rowsCopiedEventHandler = (OracleRowsCopiedEventHandler)Delegate.Combine(m_rowsCopiedEventHandler, value);
		}
		remove
		{
			m_rowsCopiedEventHandler = (OracleRowsCopiedEventHandler)Delegate.Remove(m_rowsCopiedEventHandler, value);
		}
	}

	~OracleBulkCopy()
	{
		Dispose(disposing: false);
	}

	static OracleBulkCopy()
	{
		COL_NULLIND_SIZE = 2;
		COL_LEN_SIZE = 4;
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public unsafe OracleBulkCopy(OracleConnection connection)
	{
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		if (connection.State != ConnectionState.Open)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		m_connection = connection;
		m_conSignature = connection.m_conSignature;
		m_timeout = 30;
		m_bulkCopyOptions = OracleBulkCopyOptions.Default;
	}

	public unsafe OracleBulkCopy(string connectionString)
	{
		if (connectionString == null)
		{
			throw new ArgumentNullException("connectionString");
		}
		if (connectionString == string.Empty)
		{
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "connectionString"));
		}
		m_connection = new OracleConnection(connectionString);
		m_ownConnection = true;
		m_timeout = 30;
		m_bulkCopyOptions = OracleBulkCopyOptions.Default;
	}

	public OracleBulkCopy(OracleConnection connection, OracleBulkCopyOptions copyOptions)
		: this(connection)
	{
		m_bulkCopyOptions = copyOptions;
	}

	public OracleBulkCopy(string connectionString, OracleBulkCopyOptions copyOptions)
		: this(connectionString)
	{
		m_bulkCopyOptions = copyOptions;
	}

	public void Close()
	{
		if (m_insideRowsCopiedEvent)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.BC_INV_OPER_INSIDE_EVENT));
		}
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public void WriteToServer(DataRow[] rows)
	{
		if (m_disposed)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (rows == null)
		{
			throw new ArgumentNullException("rows");
		}
		if (m_destinationTableName == null)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "Destination table"));
		}
		if (rows.Length != 0)
		{
			DataTable dataTable = (DataTable)(m_dataSource = rows[0].Table);
			m_sourceType = SourceType.RowArray;
			m_rowEnumerator = dataTable.Rows.GetEnumerator();
			m_srcColumnCount = dataTable.Columns.Count;
			WriteDataSourceToServer();
		}
	}

	public void WriteToServer(DataTable table)
	{
		WriteToServer(table, (DataRowState)0);
	}

	public void WriteToServer(IDataReader reader)
	{
		if (m_disposed)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		if (m_destinationTableName == null)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "Destination table"));
		}
		m_dataSource = reader;
		m_sourceType = SourceType.IDataReader;
		m_srcColumnCount = reader.FieldCount;
		WriteDataSourceToServer();
	}

	public void WriteToServer(DataTable table, DataRowState rowState)
	{
		if (m_disposed)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		if (table == null)
		{
			throw new ArgumentNullException("table");
		}
		if (m_destinationTableName == null)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "Destination table"));
		}
		m_rowState = rowState & ~DataRowState.Deleted;
		m_dataSource = table;
		m_sourceType = SourceType.DataTable;
		m_rowEnumerator = table.Rows.GetEnumerator();
		m_srcColumnCount = table.Columns.Count;
		WriteDataSourceToServer();
	}

	public void WriteToServer(OracleRefCursor refCursor)
	{
		WriteToServer(refCursor.GetDataReader());
	}

	private unsafe void Dispose(bool disposing)
	{
		if (m_disposed)
		{
			return;
		}
		if (disposing)
		{
			m_columnMappings = null;
			if (m_internalTransaction != null)
			{
				m_internalTransaction.Dispose();
				m_internalTransaction = null;
			}
			if (m_connection != null)
			{
				if (m_ownConnection)
				{
					m_connection.Dispose();
				}
				m_connection = null;
			}
		}
		if (m_pBlkColCtx != null)
		{
			try
			{
				OpsBC.FreeColCtx(m_pBlkColCtx, m_dstColumnCount);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
		}
		if (m_pOpoBulkCopyValCtx != null)
		{
			try
			{
				OpsBC.FreeValCtx(m_pOpoBulkCopyValCtx);
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
				throw;
			}
		}
		if (m_opsErrCtx != IntPtr.Zero)
		{
			try
			{
				OpsErr.FreeCtx(ref m_opsErrCtx);
			}
			catch (Exception ex3)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex3);
				}
			}
			m_opsErrCtx = IntPtr.Zero;
		}
		if (m_opsConCtx != IntPtr.Zero)
		{
			try
			{
				OpsCon.RelRef(ref m_opsConCtx);
			}
			catch (Exception ex4)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex4);
				}
			}
			m_opsConCtx = IntPtr.Zero;
		}
		m_disposed = true;
	}

	private unsafe void Abort()
	{
		int num = 0;
		m_internalTransaction = null;
		try
		{
			num = OpsBC.Abort(m_pOpoBulkCopyValCtx->pOPOBulkCopyCtx, m_opsErrCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		finally
		{
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		try
		{
			num = OpsBC.FreeInputBuffer(m_pOpoBulkCopyValCtx);
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
			throw;
		}
		finally
		{
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		try
		{
			num = OpsBC.Cleanup(m_pOpoBulkCopyValCtx);
		}
		catch (Exception ex3)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex3);
			}
			throw;
		}
		finally
		{
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
	}

	private unsafe void WriteDataSourceToServer()
	{
		bool flag = false;
		int num = 0;
		OPOBulkCopyColCtx* pOPOBulkCopyColCtx = null;
		OPOBulkCopyColRefCtx oPOBulkCopyColRefCtx = new OPOBulkCopyColRefCtx();
		ValidateConnection();
		if (m_fetchMeta)
		{
			try
			{
				if (m_pBlkColCtx != null)
				{
					num = OpsBC.FreeColCtx(m_pBlkColCtx, m_dstColumnCount);
				}
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			finally
			{
				if (num != 0)
				{
					OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
				}
			}
			try
			{
				if (m_pOpoBulkCopyValCtx != null)
				{
					num = OpsBC.FreeValCtx(m_pOpoBulkCopyValCtx);
					m_pOpoBulkCopyValCtx = null;
				}
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
				throw;
			}
			finally
			{
				if (num != 0)
				{
					OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
				}
			}
			try
			{
				num = OpsBC.AllocValCtx(ref m_pOpoBulkCopyValCtx);
			}
			catch (Exception ex3)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex3);
				}
				throw;
			}
			finally
			{
				if (num != 0)
				{
					OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
				}
			}
			GetMetaData();
			m_fetchMeta = false;
		}
		else
		{
			m_pOpoBulkCopyValCtx->MaxRowsInBuffer = 0;
			m_pOpoBulkCopyValCtx->NoOfRows = 0;
			m_pOpoBulkCopyValCtx->RowsInColArr = 0;
		}
		bool flag2 = false;
		if (m_internalColumnMappings == null)
		{
			m_internalColumnMappings = new OracleBulkCopyColumnMappingCollection();
		}
		else
		{
			m_internalColumnMappings.Clear();
		}
		if (m_columnMappings != null)
		{
			foreach (OracleBulkCopyColumnMapping columnMapping in m_columnMappings)
			{
				m_internalColumnMappings.Add(columnMapping.Clone());
			}
		}
		if (m_internalColumnMappings.Count > 0)
		{
			new ArrayList();
			m_internalColumnMappings.ValidateCollection();
			foreach (OracleBulkCopyColumnMapping internalColumnMapping in m_internalColumnMappings)
			{
				if (internalColumnMapping.SourceOrdinal == -1)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				int num2 = -1;
				flag = false;
				foreach (OracleBulkCopyColumnMapping internalColumnMapping2 in m_internalColumnMappings)
				{
					if (internalColumnMapping2.SourceOrdinal == -1)
					{
						num2 = ((m_sourceType != SourceType.DataTable && m_sourceType != SourceType.RowArray) ? ((IDataReader)m_dataSource).GetOrdinal(internalColumnMapping2.SourceColumn) : ((DataTable)m_dataSource).Columns.IndexOf(internalColumnMapping2.SourceColumn));
						if (num2 == -1)
						{
							throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "Column mapping"));
						}
						internalColumnMapping2.SourceOrdinal = num2;
					}
				}
			}
		}
		else
		{
			if (m_srcColumnCount > m_pOpoBulkCopyValCtx->NoOfCols)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "Column mapping"));
			}
			m_internalColumnMappings.CreateDefaultColumnMapping(m_srcColumnCount);
			flag2 = true;
		}
		foreach (OracleBulkCopyColumnMapping internalColumnMapping3 in m_internalColumnMappings)
		{
			int i;
			OPOBulkCopyColCtx* ptr;
			if (internalColumnMapping3.DestinationColumn.Equals(string.Empty))
			{
				ptr = m_pBlkColCtx;
				if (internalColumnMapping3.DestinationOrdinal < m_dstColumnCount)
				{
					for (i = 0; i < internalColumnMapping3.DestinationOrdinal; i++)
					{
						ptr++;
					}
					Marshal.PtrToStructure(ptr->pOPOBulkCopyColRefCtx, (object)oPOBulkCopyColRefCtx);
					internalColumnMapping3.DestinationColumn = oPOBulkCopyColRefCtx.pColName;
					continue;
				}
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "Column mapping"));
			}
			bool flag3 = false;
			i = 0;
			ptr = m_pBlkColCtx;
			while (i < m_dstColumnCount)
			{
				Marshal.PtrToStructure(ptr->pOPOBulkCopyColRefCtx, (object)oPOBulkCopyColRefCtx);
				if (internalColumnMapping3.DestinationColumn.ToUpper().Equals(oPOBulkCopyColRefCtx.pColName.ToUpper()))
				{
					flag3 = true;
					break;
				}
				i++;
				ptr++;
			}
			if (flag3)
			{
				continue;
			}
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "Column mapping"));
		}
		if (!flag2)
		{
			m_internalColumnMappings.Sort();
		}
		try
		{
			num = OpsBC.AllocColCtx(ref pOPOBulkCopyColCtx, m_internalColumnMappings.Count);
		}
		catch (Exception ex4)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex4);
			}
			throw;
		}
		finally
		{
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		m_pOpoBulkCopyValCtx->pOPOBulkCopyColCtx = pOPOBulkCopyColCtx;
		foreach (OracleBulkCopyColumnMapping internalColumnMapping4 in m_internalColumnMappings)
		{
			int i = 0;
			OPOBulkCopyColCtx* ptr = m_pBlkColCtx;
			while (i < m_dstColumnCount)
			{
				Marshal.PtrToStructure(ptr->pOPOBulkCopyColRefCtx, (object)oPOBulkCopyColRefCtx);
				if (internalColumnMapping4.DestinationColumn.ToUpper().Equals(oPOBulkCopyColRefCtx.pColName.ToUpper()))
				{
					try
					{
						num = OpsBC.CopyColCtx(ptr, pOPOBulkCopyColCtx);
					}
					catch (Exception ex5)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex5);
						}
						throw;
					}
					finally
					{
						if (num != 0)
						{
							OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
						}
					}
					break;
				}
				i++;
				ptr++;
			}
			pOPOBulkCopyColCtx++;
		}
		m_pOpoBulkCopyValCtx->NoOfCols = (ushort)m_internalColumnMappings.Count;
		ColumnMappings.BulkCopyInProgress = true;
		ProcessSrcColumns();
		if (m_dataSource is OracleDataReader && m_batchSize > 0 && m_OptimizedPathForOraDataReader)
		{
			m_sourceType = SourceType.OracleDataReader;
			PerformBulkCopyForOraDataReader();
		}
		else
		{
			PerformBulkCopy();
		}
		ColumnMappings.BulkCopyInProgress = false;
	}

	private bool IsBulkCopyOption(OracleBulkCopyOptions copyOption)
	{
		return (m_bulkCopyOptions & copyOption) == copyOption;
	}

	private bool ReadFromSource()
	{
		switch (m_sourceType)
		{
		case SourceType.IDataReader:
			return ((IDataReader)m_dataSource).Read();
		case SourceType.DataTable:
			do
			{
				if (!m_rowEnumerator.MoveNext())
				{
					return false;
				}
				m_currentRow = (DataRow)m_rowEnumerator.Current;
			}
			while ((m_currentRow.RowState & DataRowState.Deleted) != 0 && (m_rowState == (DataRowState)0 || (m_currentRow.RowState & m_rowState) != 0));
			return true;
		case SourceType.RowArray:
			if (m_rowEnumerator.MoveNext())
			{
				m_currentRow = (DataRow)m_rowEnumerator.Current;
				return true;
			}
			return false;
		default:
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "Source Type " + m_sourceType));
		}
	}

	internal unsafe void GetMetaData()
	{
		int num = 0;
		string pCommandText = "select * from " + m_destinationTableName;
		OPOBulkCopyRefCtx oPOBulkCopyRefCtx = new OPOBulkCopyRefCtx();
		Marshal.PtrToStructure(m_pOpoBulkCopyValCtx->pOPOBulkCopyRefCtx, (object)oPOBulkCopyRefCtx);
		oPOBulkCopyRefCtx.pTableName = m_destinationTableName;
		if (m_destinationPartitionName != null && !m_destinationPartitionName.Equals(string.Empty))
		{
			oPOBulkCopyRefCtx.pPartitionName = m_destinationPartitionName;
		}
		Marshal.StructureToPtr((object)oPOBulkCopyRefCtx, m_pOpoBulkCopyValCtx->pOPOBulkCopyRefCtx, fDeleteOld: true);
		try
		{
			num = OpsBC.GetMeta(m_opsConCtx, ref m_opsErrCtx, ref m_opsSqlCtx, pCommandText, m_pOpoBulkCopyValCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		finally
		{
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		m_pBlkColCtx = m_pOpoBulkCopyValCtx->pOPOBulkCopyColCtx;
		m_dstColumnCount = m_pOpoBulkCopyValCtx->NoOfCols;
		m_pOpoBulkCopyValCtx->NoLog = 1;
		m_pOpoBulkCopyValCtx->pOPOBulkCopyColCtx = null;
	}

	private unsafe void PrintMetaData(OPOBulkCopyColCtx* pColumn, int numCols)
	{
		int num = 0;
		while (num < numCols)
		{
			OPOBulkCopyColRefCtx oPOBulkCopyColRefCtx = new OPOBulkCopyColRefCtx();
			Marshal.PtrToStructure(pColumn->pOPOBulkCopyColRefCtx, (object)oPOBulkCopyColRefCtx);
			Console.WriteLine("Ordinal : " + pColumn->Ordinal);
			Console.WriteLine("Name: " + oPOBulkCopyColRefCtx.pColName);
			Console.WriteLine("OraType : " + pColumn->OraType);
			Console.WriteLine("Precision : " + pColumn->Precision);
			Console.WriteLine("Scale :" + pColumn->Scale);
			Console.WriteLine("MaxSize :" + pColumn->MaxSize);
			Console.WriteLine("MaxCharSize :" + pColumn->MaxCharSize);
			Console.WriteLine("CharsetID :" + pColumn->CharsetID);
			Console.WriteLine("CharsetForm :" + pColumn->CharsetForm);
			Console.WriteLine();
			num++;
			pColumn++;
		}
	}

	private unsafe void SetColumnInfo(Type srcColType, OPOBulkCopyColCtx* pColumn)
	{
		OraType oraType = (OraType)pColumn->OraType;
		if (!m_OptimizedPathForOraDataReader || oraType == OraType.ORA_INTERVAL_DS || oraType == OraType.ORA_INTERVAL_YM || oraType == OraType.ORA_OCIBFileLocator || oraType == OraType.ORA_OCIBLobLocator || oraType == OraType.ORA_OCICLobLocator || oraType == OraType.ORA_TIMESTAMP || oraType == OraType.ORA_TIMESTAMP_TZ || oraType == OraType.ORA_TIMESTAMP_LTZ)
		{
			m_OptimizedPathForOraDataReader = false;
		}
		if (oraType == OraType.ORA_DATE || oraType == OraType.ORA_TIMESTAMP || oraType == OraType.ORA_TIMESTAMP_TZ || oraType == OraType.ORA_TIMESTAMP_LTZ || oraType == OraType.ORA_IBDOUBLE || oraType == OraType.ORA_IBFLOAT)
		{
			return;
		}
		switch (srcColType.ToString())
		{
		case "System.Boolean":
		case "System.SByte":
		case "System.Byte":
			pColumn->OraType = 3;
			pColumn->MaxSize = 1u;
			break;
		case "System.Decimal":
		case "System.UInt64":
		case "Oracle.DataAccess.Types.OracleDecimal":
		case "System.Single":
		case "System.Double":
		case "System.UInt16":
		case "System.Int16":
		case "System.UInt32":
		case "System.Int32":
			pColumn->OraType = 6;
			pColumn->MaxSize = 22u;
			break;
		case "System.String":
		case "System.Char":
		case "System.Char[]":
		case "Oracle.DataAccess.Types.OracleString":
		case "Oracle.DataAccess.Types.OracleClob":
			pColumn->OraType = 1;
			pColumn->IsPtrData = 1u;
			break;
		case "System.Byte[]":
		case "Oracle.DataAccess.Types.OracleBinary":
		case "Oracle.DataAccess.Types.OracleBlob":
			pColumn->OraType = 23;
			pColumn->IsPtrData = 1u;
			break;
		case "System.TimeSpan":
		case "Oracle.DataAccess.Types.OracleIntervalDS":
			oraType = (OraType)pColumn->OraType;
			pColumn->MaxSize = (uint)sizeof(OpoTSValCtx);
			if (oraType != OraType.ORA_INTERVAL_DS)
			{
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), srcColType.ToString());
			}
			break;
		case "System.Int64":
		case "Oracle.DataAccess.Types.OracleIntervalYM":
			oraType = (OraType)pColumn->OraType;
			pColumn->MaxSize = (uint)sizeof(OpoITLValCtx);
			switch (oraType)
			{
			default:
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), srcColType.ToString());
			case OraType.ORA_NUMBER:
				pColumn->OraType = 6;
				pColumn->MaxSize = 22u;
				break;
			case OraType.ORA_INTERVAL_YM:
				break;
			}
			break;
		default:
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.PRM_INVALID_BIND), srcColType.ToString());
		}
	}

	private unsafe void ProcessSrcColumns()
	{
		m_OptimizedPathForOraDataReader = true;
		int num = 0;
		OPOBulkCopyColCtx* ptr = m_pOpoBulkCopyValCtx->pOPOBulkCopyColCtx;
		while (num < m_pOpoBulkCopyValCtx->NoOfCols)
		{
			Type srcColType = ((m_sourceType != SourceType.DataTable && m_sourceType != SourceType.RowArray) ? ((IDataReader)m_dataSource).GetFieldType(num) : ((DataTable)m_dataSource).Columns[num].DataType);
			SetColumnInfo(srcColType, ptr);
			if (ptr->IsPtrData == 1)
			{
				m_rowSize += SIZE_OF_PTR;
			}
			else
			{
				if (ptr->OraType == 187 || ptr->OraType == 188 || ptr->OraType == 232)
				{
					ptr->MaxSize = (uint)sizeof(OpoTSValCtx);
				}
				else if (ptr->OraType == 190 || ptr->OraType == 189)
				{
					ptr->MaxSize = (uint)sizeof(OpoITLValCtx);
				}
				m_rowSize += (int)ptr->MaxSize;
			}
			num++;
			ptr++;
		}
	}

	private unsafe void PerformBulkCopy()
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		int num = 0;
		int num2 = 0;
		int num3 = m_batchSize;
		int notifyAfter = m_notifyAfter;
		int count = m_internalColumnMappings.Count;
		m_timeElapsed = false;
		Timer timer = new Timer();
		timer.Elapsed += OnTimeElapsed;
		timer.Interval = m_timeout * 1000;
		timer.AutoReset = false;
		timer.Enabled = true;
		try
		{
			m_rowsCopied = 0;
			int num4 = notifyAfter;
			if (num3 > 0)
			{
				num2 = num3;
			}
			else
			{
				num2 = 10000;
				num3 = 10000;
			}
			int num5 = num3;
			if (!ReadFromSource())
			{
				return;
			}
			OPOBufferNode* pBufferNode = (OPOBufferNode*)(void*)IntPtr.Zero;
			try
			{
				num = OpsBC.AllocBufferNode(ref pBufferNode, num2, m_rowSize + count * COL_HEADER_SIZE);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			finally
			{
				if (num != 0)
				{
					OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
				}
			}
			m_pOpoBulkCopyValCtx->pInputBuffer = pBufferNode;
			m_pOpoBulkCopyValCtx->MaxRowsInBuffer = num2;
			if (IsBulkCopyOption(OracleBulkCopyOptions.UseInternalTransaction))
			{
				m_internalTransaction = m_connection.BeginTransaction();
			}
			void* ptr = (void*)pBufferNode->pBuffer;
			try
			{
				num = OpsBC.Init(m_opsConCtx, m_pOpoBulkCopyValCtx, m_opsErrCtx);
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
				throw;
			}
			finally
			{
				if (num != 0)
				{
					OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
				}
			}
			do
			{
				int num6 = 0;
				OPOBulkCopyColCtx* ptr2 = m_pOpoBulkCopyValCtx->pOPOBulkCopyColCtx;
				while (num6 < count)
				{
					object obj = ((m_sourceType != SourceType.DataTable && m_sourceType != SourceType.RowArray) ? ((IDataReader)m_dataSource).GetValue(m_internalColumnMappings[num6].m_sourceColumnOrdinal) : m_currentRow[m_internalColumnMappings[num6].m_sourceColumnOrdinal]);
					if (obj is DBNull)
					{
						*(short*)ptr = -1;
						ptr = (byte*)ptr + COL_NULLIND_SIZE;
					}
					else
					{
						*(short*)ptr = 0;
						ptr = (byte*)ptr + COL_NULLIND_SIZE;
						if (ptr2->IsPtrData == 1)
						{
							if (obj is byte[])
							{
								*(int*)ptr = ((byte[])obj).Length;
							}
							else if (obj is OracleBinary)
							{
								*(int*)ptr = ((OracleBinary)obj).Length;
							}
							else if (obj is OracleBlob)
							{
								*(int*)ptr = (int)((OracleBlob)obj).Length;
							}
							else if (obj is OracleClob)
							{
								*(int*)ptr = ((OracleClob)obj).Value.Length * SIZE_OF_CHAR;
							}
							else
							{
								*(int*)ptr = obj.ToString().Length * SIZE_OF_CHAR;
							}
						}
						else
						{
							*(uint*)ptr = ptr2->MaxSize;
						}
						ptr = (byte*)ptr + COL_LEN_SIZE;
						switch ((OraType)ptr2->OraType)
						{
						case OraType.ORA_SB1:
							if (obj is byte || obj is sbyte || obj is bool)
							{
								*(byte*)ptr = Convert.ToByte(obj);
							}
							else if (obj is short || obj is ushort)
							{
								*(short*)ptr = Convert.ToInt16(obj);
							}
							else if (obj is int || obj is uint)
							{
								*(int*)ptr = Convert.ToInt32(obj);
							}
							break;
						case OraType.ORA_BFLOAT:
							*(float*)ptr = Convert.ToSingle(obj);
							break;
						case OraType.ORA_BDOUBLE:
							*(double*)ptr = Convert.ToDouble(obj);
							break;
						case OraType.ORA_IBFLOAT:
							OpsBC.ConvertToBinaryFloat(m_pOpoBulkCopyValCtx->lfpContext, obj.ToString(), (byte*)ptr);
							break;
						case OraType.ORA_IBDOUBLE:
							OpsBC.ConvertToBinaryDouble(m_pOpoBulkCopyValCtx->lfpContext, obj.ToString(), (byte*)ptr);
							break;
						case OraType.ORA_VARNUM:
						{
							if (obj is decimal)
							{
								DecimalConv.GetBytes(Convert.ToDecimal(obj), (IntPtr)ptr);
								break;
							}
							if (obj is float)
							{
								OracleDecimal oracleDecimal = new OracleDecimal((double)(float)obj);
								try
								{
									OpsDec.GetValCtxForSetPrecNoRound(oracleDecimal.m_opoDecCtx.m_pValCtx, 7, (IntPtr)ptr);
								}
								catch (Exception ex3)
								{
									if (OraTrace.m_TraceLevel != 0)
									{
										OraTrace.TraceExceptionInfo(ex3);
									}
									throw;
								}
								break;
							}
							if (obj is OracleDecimal oracleDecimal2)
							{
								byte[] binData = oracleDecimal2.BinData;
								byte* ptr6 = (byte*)ptr;
								for (int j = 0; j <= binData[0]; j++)
								{
									ptr6[j] = binData[j];
								}
								break;
							}
							if (obj is double)
							{
								OracleDecimal oracleDecimal3 = new OracleDecimal((double)obj);
								try
								{
									OpsDec.GetValCtxForSetPrecNoRound(oracleDecimal3.m_opoDecCtx.m_pValCtx, 16, (IntPtr)ptr);
								}
								catch (Exception ex4)
								{
									if (OraTrace.m_TraceLevel != 0)
									{
										OraTrace.TraceExceptionInfo(ex4);
									}
									throw;
								}
								break;
							}
							long num7 = Convert.ToInt64(obj);
							try
							{
								OpsDec.GetValCtxFromInteger(&num7, 8, (IntPtr)ptr);
							}
							catch (Exception ex5)
							{
								if (OraTrace.m_TraceLevel != 0)
								{
									OraTrace.TraceExceptionInfo(ex5);
								}
								throw;
							}
							break;
						}
						case OraType.ORA_FLOAT:
							*(double*)ptr = Convert.ToDouble(obj);
							break;
						case OraType.ORA_CHARN:
							if (obj is OracleClob)
							{
								*(void**)ptr = Marshal.StringToCoTaskMemUni(((OracleClob)obj).Value).ToPointer();
							}
							else
							{
								*(void**)ptr = Marshal.StringToCoTaskMemUni(obj.ToString()).ToPointer();
							}
							break;
						case OraType.ORA_RAW:
							if (obj is byte[])
							{
								int num8 = ((byte[])obj).Length;
								IntPtr destination = Marshal.AllocCoTaskMem(num8);
								Marshal.Copy((byte[])obj, 0, destination, num8);
								*(void**)ptr = destination.ToPointer();
							}
							else if (obj is OracleBinary oracleBinary)
							{
								int length = oracleBinary.Length;
								IntPtr destination2 = Marshal.AllocCoTaskMem(length);
								Marshal.Copy(((OracleBinary)obj).Value, 0, destination2, length);
								*(void**)ptr = destination2.ToPointer();
							}
							else if (obj is OracleBlob)
							{
								int num9 = (int)((OracleBlob)obj).Length;
								IntPtr destination3 = Marshal.AllocCoTaskMem(num9);
								Marshal.Copy(((OracleBlob)obj).Value, 0, destination3, num9);
								*(void**)ptr = destination3.ToPointer();
							}
							break;
						case OraType.ORA_DATE:
							if (obj is DateTime)
							{
								DateTimeConv.ToBytes((DateTime)obj, (byte*)ptr);
							}
							else if (obj is OracleDate oracleDate2)
							{
								OracleDate.ToBytes(oracleDate2.GetValCtx(), (byte*)ptr);
							}
							else if (obj is OracleTimeStamp oracleTimeStamp3)
							{
								OracleDate.ToBytes(oracleTimeStamp3.GetValCtx(), (byte*)ptr);
							}
							else if (obj is OracleTimeStampTZ oracleTimeStampTZ3)
							{
								OracleDate.ToBytes(oracleTimeStampTZ3.GetValCtx(), (byte*)ptr);
							}
							else if (obj is OracleTimeStampLTZ oracleTimeStampLTZ3)
							{
								OracleDate.ToBytes(oracleTimeStampLTZ3.GetValCtx(), (byte*)ptr);
							}
							else if (obj is string)
							{
								DateTimeConv.ToBytes(new OracleDate(obj.ToString()).Value, (byte*)ptr);
							}
							break;
						case OraType.ORA_TIMESTAMP:
						{
							OpoTSValCtx* ptr10 = null;
							if (obj is DateTime)
							{
								ptr10 = new OracleTimeStamp((DateTime)obj).GetValCtx();
							}
							else if (obj is OracleDate oracleDate)
							{
								ptr10 = oracleDate.ToOracleTimeStamp().GetValCtx();
							}
							else if (obj is OracleTimeStamp oracleTimeStamp2)
							{
								ptr10 = oracleTimeStamp2.GetValCtx();
							}
							else if (obj is OracleTimeStampTZ oracleTimeStampTZ2)
							{
								ptr10 = oracleTimeStampTZ2.ToOracleTimeStamp().GetValCtx();
							}
							else if (obj is OracleTimeStampLTZ oracleTimeStampLTZ2)
							{
								ptr10 = oracleTimeStampLTZ2.ToOracleTimeStamp().GetValCtx();
							}
							else if (obj is string)
							{
								ptr10 = new OracleTimeStamp(obj.ToString()).GetValCtx();
							}
							if (null != ptr10)
							{
								byte* ptr11 = (byte*)ptr;
								byte* ptr12 = (byte*)ptr10;
								for (int l = 0; l < ptr2->MaxSize; l++)
								{
									ptr11[l] = ptr12[l];
								}
							}
							break;
						}
						case OraType.ORA_TIMESTAMP_TZ:
						{
							OpoTSValCtx* ptr7 = null;
							OracleTimeStampTZ oracleTimeStampTZ;
							if (obj is DateTime)
							{
								oracleTimeStampTZ = new OracleTimeStampTZ((DateTime)obj);
								ptr7 = oracleTimeStampTZ.GetValCtx();
							}
							else if (obj is OracleDate)
							{
								oracleTimeStampTZ = new OracleTimeStampTZ(((OracleDate)obj).Value);
								ptr7 = oracleTimeStampTZ.GetValCtx();
							}
							else if (obj is OracleTimeStamp oracleTimeStamp)
							{
								oracleTimeStampTZ = oracleTimeStamp.ToOracleTimeStampTZ();
								ptr7 = oracleTimeStampTZ.GetValCtx();
							}
							else if (obj is OracleTimeStampTZ)
							{
								oracleTimeStampTZ = (OracleTimeStampTZ)obj;
								ptr7 = oracleTimeStampTZ.GetValCtx();
							}
							else if (obj is OracleTimeStampLTZ oracleTimeStampLTZ)
							{
								oracleTimeStampTZ = oracleTimeStampLTZ.ToOracleTimeStampTZ();
								ptr7 = oracleTimeStampTZ.GetValCtx();
							}
							else if (obj is string)
							{
								oracleTimeStampTZ = new OracleTimeStampTZ(obj.ToString());
								ptr7 = oracleTimeStampTZ.GetValCtx();
							}
							if (null != ptr7)
							{
								byte* ptr8 = (byte*)ptr;
								byte* ptr9 = (byte*)ptr7;
								for (int k = 0; k < ptr2->MaxSize; k++)
								{
									ptr8[k] = ptr9[k];
								}
							}
							break;
						}
						case OraType.ORA_TIMESTAMP_LTZ:
						{
							OpoTSValCtx* ptr16 = null;
							OracleTimeStampLTZ oracleTimeStampLTZ4;
							if (obj is DateTime)
							{
								oracleTimeStampLTZ4 = new OracleTimeStampLTZ((DateTime)obj);
								ptr16 = oracleTimeStampLTZ4.GetValCtx();
							}
							else if (obj is OracleDate)
							{
								oracleTimeStampLTZ4 = new OracleTimeStampLTZ(((OracleDate)obj).Value);
								ptr16 = oracleTimeStampLTZ4.GetValCtx();
							}
							else if (obj is OracleTimeStamp oracleTimeStamp4)
							{
								oracleTimeStampLTZ4 = oracleTimeStamp4.ToOracleTimeStampLTZ();
								ptr16 = oracleTimeStampLTZ4.GetValCtx();
							}
							else if (obj is OracleTimeStampTZ oracleTimeStampTZ4)
							{
								oracleTimeStampLTZ4 = oracleTimeStampTZ4.ToOracleTimeStampLTZ();
								ptr16 = oracleTimeStampLTZ4.GetValCtx();
							}
							else if (obj is OracleTimeStampLTZ)
							{
								oracleTimeStampLTZ4 = (OracleTimeStampLTZ)obj;
								ptr16 = oracleTimeStampLTZ4.GetValCtx();
							}
							else if (obj is string)
							{
								oracleTimeStampLTZ4 = new OracleTimeStampLTZ(obj.ToString());
								ptr16 = oracleTimeStampLTZ4.GetValCtx();
							}
							if (null != ptr16)
							{
								byte* ptr17 = (byte*)ptr;
								byte* ptr18 = (byte*)ptr16;
								for (int n = 0; n < ptr2->MaxSize; n++)
								{
									ptr17[n] = ptr18[n];
								}
							}
							break;
						}
						case OraType.ORA_INTERVAL_DS:
						{
							OpoITLValCtx* ptr13 = null;
							if (obj is TimeSpan)
							{
								ptr13 = new OracleIntervalDS((TimeSpan)obj).GetValCtx();
							}
							else if (obj is OracleIntervalDS oracleIntervalDS)
							{
								ptr13 = oracleIntervalDS.GetValCtx();
							}
							if (null != ptr13)
							{
								byte* ptr14 = (byte*)ptr;
								byte* ptr15 = (byte*)ptr13;
								for (int m = 0; m < ptr2->MaxSize; m++)
								{
									ptr14[m] = ptr15[m];
								}
							}
							break;
						}
						case OraType.ORA_INTERVAL_YM:
						{
							OpoITLValCtx* ptr3 = null;
							if (obj is OracleIntervalYM oracleIntervalYM)
							{
								ptr3 = oracleIntervalYM.GetValCtx();
							}
							else if (obj is long)
							{
								ptr3 = new OracleIntervalYM(Convert.ToInt64(obj)).GetValCtx();
							}
							if (null != ptr3)
							{
								byte* ptr4 = (byte*)ptr;
								byte* ptr5 = (byte*)ptr3;
								for (int i = 0; i < ptr2->MaxSize; i++)
								{
									ptr4[i] = ptr5[i];
								}
							}
							break;
						}
						default:
							throw new OracleException(ErrRes.CMD_TYPE_NOT_SUPPORTED, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CMD_TYPE_NOT_SUPPORTED));
						}
						ptr = ((ptr2->IsPtrData != 1) ? ((byte*)ptr + (int)ptr2->MaxSize) : ((byte*)ptr + SIZE_OF_PTR));
					}
					num6++;
					ptr2++;
				}
				m_rowsCopied++;
				m_pOpoBulkCopyValCtx->NoOfRows++;
				if (m_timeElapsed)
				{
					Abort();
					throw new OracleException(ErrRes.BC_OPER_TIMEOUT, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.BC_OPER_TIMEOUT));
				}
				if (num4 > 0)
				{
					num4--;
				}
				if (notifyAfter > 0 && num4 == 0)
				{
					if (FireRowsCopiedEvent(m_rowsCopied))
					{
						Abort();
						throw new OracleException(ErrRes.BC_OPER_ABORT, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.BC_OPER_ABORT));
					}
					num4 = notifyAfter;
				}
				if (num5 > 0)
				{
					num5--;
				}
				if (num3 > 0 && num5 == 0)
				{
					try
					{
						m_badRowNumber = -1;
						m_badColNumber = -1;
						num = OpsBC.Load(m_opsConCtx, m_pOpoBulkCopyValCtx, m_opsErrCtx, ref m_badRowNumber, ref m_badColNumber, 0, IntPtr.Zero, (OpoMetValCtx*)(void*)IntPtr.Zero, (OpoDacValCtx*)(void*)IntPtr.Zero);
					}
					catch (Exception ex6)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex6);
						}
						throw;
					}
					finally
					{
						if (num != 0)
						{
							OracleException ex7 = new OracleException(m_opsErrCtx, null, m_opsConCtx, m_connection.DataSource, string.Empty);
							OracleError value = new OracleError(ErrRes.BC_ERROR, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.BC_ERROR, m_badRowNumber.ToString(), m_badColNumber.ToString()));
							ex7.Errors.Insert(0, value);
							throw ex7;
						}
					}
					try
					{
						num = OpsBC.Finish(m_opsConCtx, m_pOpoBulkCopyValCtx->pOPOBulkCopyCtx, m_opsErrCtx);
						if (num == 0)
						{
							num = OpsBC.Cleanup(m_pOpoBulkCopyValCtx);
						}
					}
					catch (Exception ex8)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex8);
						}
						throw;
					}
					finally
					{
						if (num != 0)
						{
							OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
						}
					}
					if (m_internalTransaction != null)
					{
						m_internalTransaction.Commit();
						m_internalTransaction.Dispose();
						m_internalTransaction = null;
					}
					num5 = num3;
					flag3 = true;
				}
				flag2 = ReadFromSource();
				if (flag2)
				{
					if (num3 == 0 && m_pOpoBulkCopyValCtx->NoOfRows % num2 == 0)
					{
						OPOBufferNode* pBufferNode2 = (OPOBufferNode*)(void*)IntPtr.Zero;
						try
						{
							num = OpsBC.AllocBufferNode(ref pBufferNode2, num2, m_rowSize + count * COL_HEADER_SIZE);
						}
						catch (Exception ex9)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex9);
							}
							throw;
						}
						finally
						{
							if (num != 0)
							{
								OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
							}
						}
						pBufferNode->pNext = (IntPtr)pBufferNode2;
						pBufferNode = (OPOBufferNode*)(void*)pBufferNode->pNext;
						ptr = (void*)pBufferNode->pBuffer;
					}
					if (!flag3)
					{
						continue;
					}
					flag3 = false;
					m_pOpoBulkCopyValCtx->NoOfRows = 0;
					if (IsBulkCopyOption(OracleBulkCopyOptions.UseInternalTransaction))
					{
						m_internalTransaction = m_connection.BeginTransaction();
					}
					ptr = (void*)m_pOpoBulkCopyValCtx->pInputBuffer->pBuffer;
					try
					{
						num = OpsBC.Init(m_opsConCtx, m_pOpoBulkCopyValCtx, m_opsErrCtx);
					}
					catch (Exception ex10)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex10);
						}
						throw;
					}
					finally
					{
						if (num != 0)
						{
							OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
						}
					}
				}
				else
				{
					if (flag3)
					{
						continue;
					}
					try
					{
						m_badRowNumber = -1;
						m_badColNumber = -1;
						num = OpsBC.Load(m_opsConCtx, m_pOpoBulkCopyValCtx, m_opsErrCtx, ref m_badRowNumber, ref m_badColNumber, 0, IntPtr.Zero, (OpoMetValCtx*)(void*)IntPtr.Zero, (OpoDacValCtx*)(void*)IntPtr.Zero);
					}
					catch (Exception ex11)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex11);
						}
						throw;
					}
					finally
					{
						if (num != 0)
						{
							OracleException ex12 = new OracleException(m_opsErrCtx, null, m_opsConCtx, m_connection.DataSource, string.Empty);
							OracleError value2 = new OracleError(ErrRes.BC_ERROR, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.BC_ERROR, m_badRowNumber.ToString(), m_badColNumber.ToString()));
							ex12.Errors.Insert(0, value2);
							throw ex12;
						}
					}
					try
					{
						num = OpsBC.Finish(m_opsConCtx, m_pOpoBulkCopyValCtx->pOPOBulkCopyCtx, m_opsErrCtx);
						if (num == 0)
						{
							num = OpsBC.Cleanup(m_pOpoBulkCopyValCtx);
						}
						if (m_internalTransaction != null)
						{
							m_internalTransaction.Commit();
							m_internalTransaction.Dispose();
							m_internalTransaction = null;
						}
					}
					catch (Exception ex13)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex13);
						}
						throw;
					}
					finally
					{
						if (num != 0)
						{
							OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
						}
					}
				}
			}
			while (flag2);
			try
			{
				num = OpsBC.FreeInputBuffer(m_pOpoBulkCopyValCtx);
			}
			catch (Exception ex14)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex14);
				}
				throw;
			}
			finally
			{
				if (num != 0)
				{
					OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
				}
			}
		}
		finally
		{
			timer.Enabled = false;
			m_timeElapsed = false;
			timer.Dispose();
			if (m_internalTransaction != null)
			{
				m_internalTransaction.Rollback();
				m_internalTransaction.Dispose();
				m_internalTransaction = null;
			}
		}
	}

	private unsafe void PerformBulkCopyForOraDataReader()
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		int num = 0;
		int batchSize = m_batchSize;
		int notifyAfter = m_notifyAfter;
		OracleDataReader oracleDataReader = m_dataSource as OracleDataReader;
		m_timeElapsed = false;
		Timer timer = new Timer();
		timer.Elapsed += OnTimeElapsed;
		timer.Interval = m_timeout * 1000;
		timer.AutoReset = false;
		timer.Enabled = true;
		try
		{
			m_rowsCopied = 0;
			int num2 = notifyAfter;
			int num3 = batchSize;
			oracleDataReader.FetchSizeInRows = batchSize - 1;
			oracleDataReader.m_currentClientRow = oracleDataReader.m_pOpoDacValCtx->CurrentClientRow;
			flag2 = oracleDataReader.Read();
			if (!flag2)
			{
				return;
			}
			do
			{
				m_rowsCopied++;
				m_pOpoBulkCopyValCtx->NoOfRows++;
				if (m_timeElapsed)
				{
					Abort();
					throw new OracleException(ErrRes.BC_OPER_TIMEOUT, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.BC_OPER_TIMEOUT));
				}
				if (oracleDataReader.m_pOpoDacValCtx->RecordCount % batchSize != 0)
				{
					flag3 = true;
				}
				if (num2 > 0)
				{
					num2--;
				}
				if (notifyAfter > 0 && num2 == 0)
				{
					if (FireRowsCopiedEvent(m_rowsCopied))
					{
						Abort();
						throw new OracleException(ErrRes.BC_OPER_ABORT, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.BC_OPER_ABORT));
					}
					num2 = notifyAfter;
				}
				if (num3 > 0)
				{
					num3--;
				}
				if ((batchSize <= 0 || num3 != 0) && !flag3)
				{
					continue;
				}
				if (IsBulkCopyOption(OracleBulkCopyOptions.UseInternalTransaction))
				{
					m_internalTransaction = m_connection.BeginTransaction();
				}
				try
				{
					num = OpsBC.Init(m_opsConCtx, m_pOpoBulkCopyValCtx, m_opsErrCtx);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					throw;
				}
				finally
				{
					if (num != 0)
					{
						OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
					}
				}
				try
				{
					m_badRowNumber = -1;
					m_badColNumber = -1;
					num = OpsBC.Load(m_opsConCtx, m_pOpoBulkCopyValCtx, m_opsErrCtx, ref m_badRowNumber, ref m_badColNumber, 1, oracleDataReader.m_opsDacCtx, oracleDataReader.m_pOpoMetValCtx, oracleDataReader.m_pOpoDacValCtx);
				}
				catch (Exception ex2)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex2);
					}
					throw;
				}
				finally
				{
					if (num != 0)
					{
						OracleException ex3 = new OracleException(m_opsErrCtx, null, m_opsConCtx, m_connection.DataSource, string.Empty);
						OracleError value = new OracleError(ErrRes.BC_ERROR, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.BC_ERROR, m_badRowNumber.ToString(), m_badColNumber.ToString()));
						ex3.Errors.Insert(0, value);
						throw ex3;
					}
				}
				try
				{
					num = OpsBC.Finish(m_opsConCtx, m_pOpoBulkCopyValCtx->pOPOBulkCopyCtx, m_opsErrCtx);
					if (num == 0)
					{
						num = OpsBC.Cleanup(m_pOpoBulkCopyValCtx);
					}
				}
				catch (Exception ex4)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex4);
					}
					throw;
				}
				finally
				{
					if (num != 0)
					{
						OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
					}
				}
				if (m_internalTransaction != null)
				{
					m_internalTransaction.Commit();
					m_internalTransaction.Dispose();
					m_internalTransaction = null;
				}
				num3 = batchSize;
				oracleDataReader.m_currentClientRow = oracleDataReader.m_pOpoDacValCtx->CurrentClientRow;
				flag2 = oracleDataReader.Read();
				m_pOpoBulkCopyValCtx->NoOfRows = 0;
			}
			while (flag2);
		}
		finally
		{
			timer.Enabled = false;
			m_timeElapsed = false;
			timer.Dispose();
			if (m_internalTransaction != null)
			{
				m_internalTransaction.Rollback();
				m_internalTransaction.Dispose();
				m_internalTransaction = null;
			}
		}
	}

	private void ValidateConnection()
	{
		int num = 0;
		if (m_ownConnection && m_connection.State != ConnectionState.Open)
		{
			m_connection.Open();
			m_conSignature = m_connection.m_conSignature;
			m_opsConCtx = m_connection.m_opoConCtx.opsConCtx;
			try
			{
				int num2 = OpsCon.AddRef(m_opsConCtx);
				if (num2 <= 1)
				{
					num = ErrRes.CON_CLOSED;
					throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
				}
				return;
			}
			catch (Exception ex)
			{
				if (num != 0 && num != ErrRes.CON_CLOSED && OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
		}
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_opsConCtx != m_connection.m_opoConCtx.opsConCtx)
		{
			if (m_opsConCtx != IntPtr.Zero)
			{
				try
				{
					OpsCon.RelRef(ref m_opsConCtx);
				}
				catch (Exception ex2)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex2);
					}
				}
			}
			m_opsConCtx = m_connection.m_opoConCtx.opsConCtx;
			try
			{
				int num3 = OpsCon.AddRef(m_opsConCtx);
				if (num3 <= 1)
				{
					num = ErrRes.CON_CLOSED;
					throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
				}
			}
			catch (Exception ex3)
			{
				if (num != 0 && num != ErrRes.CON_CLOSED && OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex3);
				}
				throw;
			}
		}
		if (m_conSignature == m_connection.m_conSignature)
		{
			return;
		}
		if (m_opsErrCtx != IntPtr.Zero)
		{
			try
			{
				OpsErr.FreeCtx(ref m_opsErrCtx);
			}
			catch (Exception ex4)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex4);
				}
			}
			m_opsErrCtx = IntPtr.Zero;
		}
		m_fetchMeta = true;
		m_conSignature = m_connection.m_conSignature;
	}

	private bool FireRowsCopiedEvent(long rowsCopied)
	{
		OracleRowsCopiedEventArgs oracleRowsCopiedEventArgs;
		try
		{
			oracleRowsCopiedEventArgs = new OracleRowsCopiedEventArgs(rowsCopied);
			m_insideRowsCopiedEvent = true;
			OnRowsCopied(oracleRowsCopiedEventArgs);
		}
		finally
		{
			m_insideRowsCopiedEvent = false;
		}
		return oracleRowsCopiedEventArgs.Abort;
	}

	internal void OnRowsCopied(OracleRowsCopiedEventArgs eventArgs)
	{
		if (m_rowsCopiedEventHandler != null)
		{
			m_rowsCopiedEventHandler(this, eventArgs);
		}
	}

	private static void OnTimeElapsed(object source, ElapsedEventArgs e)
	{
		m_timeElapsed = true;
	}
}
