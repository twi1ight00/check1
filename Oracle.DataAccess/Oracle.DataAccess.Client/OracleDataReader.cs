using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.Metadata.Edm;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml;
using Oracle.DataAccess.Types;

namespace Oracle.DataAccess.Client;

public sealed class OracleDataReader : DbDataReader
{
	private static int POOLED_CACHE_ARRAY_SIZE;

	private int m_freeOpsSqlCtx;

	private IntPtr m_opsConCtx;

	private IntPtr m_opsErrCtx;

	private IntPtr[] m_opsSqlCtx;

	internal IntPtr m_opsDacCtx;

	private ColMetaRef[] m_colMetaRef;

	private unsafe OpoSqlValCtx* m_pOpoSqlValCtx;

	internal uint[] m_colOffset;

	internal uint[] m_colIndOffset;

	internal uint[] m_colLenOffset;

	internal uint[] m_colDatOffset;

	internal uint[] m_colDatSize;

	internal long m_fetchArrayLocation;

	internal int m_currentClientRow;

	private long m_rowLocation;

	private int m_recordCount;

	private OraType[] m_oraType;

	private OracleDbType[] m_oracleDbType;

	private IntPtr m_pColumnsDataBuffer = IntPtr.Zero;

	private DotNetNumericAccessor[] m_dotNetNumericAccessor;

	private object m_disposeSyncObj = new object();

	private MetaData m_metaData;

	internal unsafe OpoMetValCtx* m_pOpoMetValCtx;

	internal bool m_bHasUdtType;

	internal unsafe OpoDacValCtx* m_pOpoDacValCtx;

	internal bool m_bCmdBehaviorSingleRow;

	private int m_recordsAffected;

	internal long m_fetchSize;

	private int m_currentResultIndex;

	private int m_resultCount;

	private bool m_closed;

	private bool m_disposed;

	private bool m_bBOF;

	private bool m_bLastFetch;

	private bool m_bSetLastFetch;

	private bool m_bEOF;

	private bool m_fillReader;

	private OracleConnection m_connection;

	private CommandBehavior m_commandBehavior;

	private DataTable m_dataTable;

	private ArrayList m_dataTableList;

	private bool m_noMoreResults;

	private int m_conSignature;

	private OracleRefCursor m_refCursor;

	private Hashtable m_safeMapping;

	private string m_commandText;

	private bool m_pkFetched;

	private bool m_doneMarshalAndStoreMetaData;

	private bool m_addRowid;

	private long m_rowSize;

	private IntPtr[] m_opsXmlTypeCtx;

	private bool m_hasRows;

	private bool m_doneReadOne;

	private bool m_bHasRowsCalledBeforeRead;

	private int m_fieldCount;

	private bool m_external;

	private bool m_isDBVer10gR2OrHigher;

	private bool m_bFetchSizePropertySet;

	private object[] m_currentRowUdtCache;

	private OracleUdtDescriptor[] m_udtDescriptorCache;

	internal bool m_returnPSTypes;

	private FetchArrayPooler m_fetchArrayPooler;

	internal string m_storedProcName;

	internal PrimitiveType[] m_expectedColumnTypes;

	internal bool m_isFromEF;

	public unsafe int InitialLONGFetchSize
	{
		get
		{
			if (m_closed)
			{
				throw new InvalidOperationException();
			}
			return m_pOpoDacValCtx->InitialLongFS;
		}
	}

	public unsafe int InitialLOBFetchSize
	{
		get
		{
			if (m_closed)
			{
				throw new InvalidOperationException();
			}
			return m_pOpoDacValCtx->InitialLobFS;
		}
	}

	public override int Depth
	{
		get
		{
			if (m_closed)
			{
				throw new InvalidOperationException();
			}
			return 0;
		}
	}

	public long FetchSize
	{
		get
		{
			if (m_closed)
			{
				throw new InvalidOperationException();
			}
			return m_fetchSize;
		}
		set
		{
			if (m_closed)
			{
				throw new InvalidOperationException();
			}
			if (value <= 0)
			{
				throw new ArgumentException();
			}
			m_fetchSize = value;
			m_bFetchSizePropertySet = true;
		}
	}

	internal long FetchSizeInRows
	{
		set
		{
			if (m_closed)
			{
				throw new InvalidOperationException();
			}
			if (value <= 0)
			{
				throw new ArgumentException();
			}
			m_fetchSize = value * m_rowSize;
		}
	}

	public unsafe override int FieldCount
	{
		get
		{
			if (m_closed)
			{
				throw new InvalidOperationException();
			}
			if (m_pOpoMetValCtx != null)
			{
				return m_fieldCount;
			}
			return 0;
		}
	}

	public override bool IsClosed => m_closed;

	public override int RecordsAffected => m_recordsAffected;

	public unsafe override bool HasRows
	{
		get
		{
			if (m_closed)
			{
				throw new InvalidOperationException();
			}
			if (!m_hasRows && !m_doneReadOne && Read() && m_currentClientRow == 1)
			{
				m_currentClientRow = 0;
				m_pOpoDacValCtx->CurrentClientRow = 0;
				m_bHasRowsCalledBeforeRead = true;
			}
			return m_hasRows;
		}
	}

	public long RowSize => m_rowSize;

	internal IntPtr SqlCtx
	{
		get
		{
			return m_opsSqlCtx[0];
		}
		set
		{
			m_opsSqlCtx[0] = value;
		}
	}

	internal int FreeSqlCtx
	{
		get
		{
			return m_freeOpsSqlCtx;
		}
		set
		{
			m_freeOpsSqlCtx = value;
		}
	}

	public unsafe override int VisibleFieldCount
	{
		get
		{
			if (m_closed)
			{
				throw new InvalidOperationException();
			}
			if (m_pOpoMetValCtx != null)
			{
				return m_fieldCount;
			}
			return 0;
		}
	}

	public unsafe int HiddenFieldCount
	{
		get
		{
			if (m_closed)
			{
				throw new InvalidOperationException();
			}
			if (m_pOpoMetValCtx != null)
			{
				return m_pOpoMetValCtx->NoOfHiddenCols;
			}
			return 0;
		}
	}

	internal int CurrentRow
	{
		get
		{
			if (m_closed)
			{
				throw new InvalidOperationException();
			}
			return m_currentClientRow;
		}
	}

	internal bool IsEOF
	{
		get
		{
			if (m_closed)
			{
				throw new InvalidOperationException();
			}
			return m_bEOF;
		}
	}

	internal bool IsFillReader
	{
		get
		{
			if (m_closed)
			{
				throw new InvalidOperationException();
			}
			return m_fillReader;
		}
		set
		{
			if (m_closed)
			{
				throw new InvalidOperationException();
			}
			m_fillReader = value;
			if (m_fillReader)
			{
				m_dataTableList = new ArrayList();
				DataTable minSchemaTable = GetMinSchemaTable();
				if (minSchemaTable != null)
				{
					m_dataTableList.Add(minSchemaTable);
				}
			}
		}
	}

	internal OracleRefCursor RefCursor
	{
		get
		{
			if (m_closed)
			{
				throw new InvalidOperationException();
			}
			return m_refCursor;
		}
		set
		{
			if (m_closed)
			{
				throw new InvalidOperationException();
			}
			m_refCursor = value;
		}
	}

	internal Hashtable SafeMapping
	{
		get
		{
			return m_safeMapping;
		}
		set
		{
			m_safeMapping = value;
		}
	}

	internal ArrayList SchemaTables
	{
		get
		{
			if (m_closed)
			{
				throw new InvalidOperationException();
			}
			return m_dataTableList;
		}
	}

	public override object this[int i] => GetValue(i);

	public override object this[string columnName] => this[GetOrdinal(columnName)];

	static OracleDataReader()
	{
		POOLED_CACHE_ARRAY_SIZE = 131072;
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public override void Close()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::Close()\n");
		}
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
		m_closed = true;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::Close()\n");
		}
	}

	public new void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public override bool GetBoolean(int i)
	{
		if (m_isFromEF)
		{
			object value = GetValue(i);
			Type type = value.GetType();
			if (type == typeof(bool))
			{
				return (bool)value;
			}
			if (type == typeof(DBNull))
			{
				return false;
			}
			if (!((decimal)value > 0m))
			{
				return false;
			}
			return true;
		}
		throw new NotSupportedException();
	}

	public unsafe override byte GetByte(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetByte()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (oraType != OraType.ORA_NUMBER)
		{
			throw new InvalidCastException();
		}
		int scale = m_pOpoMetValCtx->pColMetaVal[i].Scale;
		int precision = m_pOpoMetValCtx->pColMetaVal[i].Precision;
		if (!m_isFromEF && (scale > 0 || precision - scale >= 3))
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		m_pOpoDacValCtx->Type = 103;
		long num2 = m_fetchArrayLocation + m_rowLocation + m_colIndOffset[i];
		short num3 = *(short*)num2;
		if (num3 == -1)
		{
			throw new InvalidCastException(OpoErrResManager.GetErrorMesg(ErrRes.DR_NULL_COL_DATA));
		}
		long num4 = m_fetchArrayLocation + m_rowLocation;
		IntPtr pBuffer = (IntPtr)(num4 + m_colOffset[i]);
		m_pOpoDacValCtx->pBuffer = pBuffer;
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		try
		{
			num = OpsDac.GetType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, 1);
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
				if (m_pOpoDacValCtx->Type == -1)
				{
					if (num == 22053 || num == 22054)
					{
						throw new OverflowException(OracleTypeException.GetTypeMsg(num));
					}
					throw new OracleTypeException(num);
				}
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetByte()\n");
		}
		return *(byte*)m_pOpoDacValCtx->pValCtx;
	}

	public override long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferOffset, int length)
	{
		return GetBytesInternal(i, fieldOffset, buffer, bufferOffset, length, bThrowException: true);
	}

	internal unsafe long GetBytesInternal(int i, long fieldOffset, byte[] buffer, int bufferOffset, int length, bool bThrowException)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetBytes()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		if (buffer != null)
		{
			CheckParameters(buffer.Length, bufferOffset, length);
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (m_external && oraType != OraType.ORA_LONGRAW && oraType != OraType.ORA_RAW && oraType != OraType.ORA_OCIBLobLocator && oraType != OraType.ORA_OCIBFileLocator)
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->RetDataLen = 0;
		if (buffer != null)
		{
			GCHandle gCHandle = default(GCHandle);
			if (length == 0 || fieldOffset < 0)
			{
				return 0L;
			}
			m_pOpoDacValCtx->BufLen = length;
			m_pOpoDacValCtx->FieldOffset = fieldOffset;
			bool flag;
			if ((oraType == OraType.ORA_LONGRAW && m_pOpoDacValCtx->InitialLongFS != -1 && m_pOpoDacValCtx->BufLen + m_pOpoDacValCtx->FieldOffset > m_pOpoDacValCtx->InitialLongFS) || (oraType == OraType.ORA_OCIBLobLocator && m_pOpoDacValCtx->InitialLobFS == 0) || (oraType == OraType.ORA_OCIBLobLocator && m_pOpoDacValCtx->InitialLobFS != -1 && m_pOpoDacValCtx->BufLen + m_pOpoDacValCtx->FieldOffset > m_pOpoDacValCtx->InitialLobFS) || oraType == OraType.ORA_OCIBFileLocator)
			{
				flag = false;
				gCHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
				int num2 = (int)gCHandle.AddrOfPinnedObject();
				num2 += bufferOffset;
				m_pOpoDacValCtx->pBuffer = (IntPtr)num2;
			}
			else
			{
				flag = true;
				m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
			}
			try
			{
				num = OpsDac.GetType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, 0);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				num = ErrRes.INT_ERR;
				throw;
			}
			finally
			{
				if (num != ErrRes.INT_ERR && (oraType == OraType.ORA_LONGRAW || (oraType == OraType.ORA_OCIBLobLocator && m_pOpoDacValCtx->InitialLobFS > 0 && !m_isDBVer10gR2OrHigher)) && !m_pkFetched)
				{
					UpdateMetaDataPool();
				}
				if (!flag && gCHandle.IsAllocated)
				{
					gCHandle.Free();
				}
			}
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
			if (m_pOpoDacValCtx->Indicator == -1)
			{
				if (!bThrowException)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(1u, " (EXIT) OracleDataReader::GetBytes()\n");
					}
					return -1L;
				}
				throw new InvalidCastException(OpoErrResManager.GetErrorMesg(ErrRes.DR_NULL_COL_DATA));
			}
			if (flag)
			{
				if (length < m_pOpoDacValCtx->RetDataLen)
				{
					m_pOpoDacValCtx->RetDataLen = length;
				}
				if (m_pOpoDacValCtx->RetDataLen > 0)
				{
					Marshal.Copy(m_pOpoDacValCtx->pBuffer, buffer, bufferOffset, m_pOpoDacValCtx->RetDataLen);
				}
			}
		}
		else
		{
			m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
			m_pOpoDacValCtx->BufLen = 0;
			m_pOpoDacValCtx->FieldOffset = 0L;
			try
			{
				num = OpsDac.GetLen(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx);
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
				throw;
			}
			if ((oraType == OraType.ORA_LONGRAW || (oraType == OraType.ORA_OCIBLobLocator && m_pOpoDacValCtx->InitialLobFS > 0 && !m_isDBVer10gR2OrHigher)) && !m_pkFetched)
			{
				UpdateMetaDataPool();
			}
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		if (m_pOpoDacValCtx->Indicator == -1)
		{
			if (!bThrowException)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT) OracleDataReader::GetBytes()\n");
				}
				return -1L;
			}
			throw new InvalidCastException(OpoErrResManager.GetErrorMesg(ErrRes.DR_NULL_COL_DATA));
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetBytes()\n");
		}
		return m_pOpoDacValCtx->RetDataLen;
	}

	public override char GetChar(int i)
	{
		throw new NotSupportedException();
	}

	public unsafe override long GetChars(int i, long fieldOffset, char[] buffer, int bufferOffset, int length)
	{
		bool flag = false;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetChars()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		if (buffer != null)
		{
			CheckParameters(buffer.Length, bufferOffset, length);
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (m_external && oraType != OraType.ORA_CHAR && oraType != OraType.ORA_CHARN && oraType != OraType.ORA_LONG && oraType != OraType.ORA_OCIRowid && oraType != OraType.ORA_OCICLobLocator)
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->RetDataLen = 0;
		if (buffer != null)
		{
			if (length == 0 || fieldOffset < 0)
			{
				return 0L;
			}
			m_pOpoDacValCtx->BufLen = length * 2;
			m_pOpoDacValCtx->FieldOffset = fieldOffset * 2;
			GCHandle gCHandle = default(GCHandle);
			bool flag2;
			if ((oraType == OraType.ORA_LONG && m_pOpoDacValCtx->InitialLongFS != -1 && (m_pOpoDacValCtx->BufLen + m_pOpoDacValCtx->FieldOffset) / 2 > m_pOpoDacValCtx->InitialLongFS) || (oraType == OraType.ORA_OCICLobLocator && m_pOpoDacValCtx->InitialLobFS == 0) || (oraType == OraType.ORA_OCICLobLocator && m_pOpoDacValCtx->InitialLobFS != -1 && (m_pOpoDacValCtx->BufLen + m_pOpoDacValCtx->FieldOffset) / 2 > m_pOpoDacValCtx->InitialLobFS))
			{
				flag2 = false;
				gCHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
				int num2 = (int)gCHandle.AddrOfPinnedObject();
				num2 += bufferOffset * 2;
				m_pOpoDacValCtx->pBuffer = (IntPtr)num2;
			}
			else
			{
				flag2 = true;
				m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
				if (oraType != OraType.ORA_LONG && oraType != OraType.ORA_OCICLobLocator)
				{
					long num3 = m_fetchArrayLocation + m_rowLocation + m_colIndOffset[i];
					short num4 = *(short*)num3;
					if (num4 == -1)
					{
						throw new InvalidCastException(OpoErrResManager.GetErrorMesg(ErrRes.DR_NULL_COL_DATA));
					}
					long num5 = m_fetchArrayLocation + m_rowLocation;
					num3 = num5 + m_colLenOffset[i];
					IntPtr pBuffer = (IntPtr)(num5 + m_colOffset[i] + m_pOpoDacValCtx->FieldOffset);
					m_pOpoDacValCtx->pBuffer = pBuffer;
					m_pOpoDacValCtx->RetDataLen = *(short*)num3;
					if (m_pOpoDacValCtx->FieldOffset > 0)
					{
						m_pOpoDacValCtx->RetDataLen -= (int)m_pOpoDacValCtx->FieldOffset;
					}
					flag = true;
				}
			}
			try
			{
				if (!flag)
				{
					num = OpsDac.GetType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, 0);
				}
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				num = ErrRes.INT_ERR;
				throw;
			}
			finally
			{
				if (num != ErrRes.INT_ERR && (oraType == OraType.ORA_LONG || (oraType == OraType.ORA_OCICLobLocator && m_pOpoDacValCtx->InitialLobFS > 0 && !m_isDBVer10gR2OrHigher)) && !m_pkFetched)
				{
					UpdateMetaDataPool();
				}
				if (!flag2 && gCHandle.IsAllocated)
				{
					gCHandle.Free();
				}
			}
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
			if (m_pOpoDacValCtx->Indicator == -1)
			{
				throw new InvalidCastException(OpoErrResManager.GetErrorMesg(ErrRes.DR_NULL_COL_DATA));
			}
			m_pOpoDacValCtx->RetDataLen /= 2;
			if (flag2)
			{
				bool flag3 = true;
				if (m_pOpoMetValCtx->pColMetaVal[i].UCS2Character == 0)
				{
					flag3 = false;
				}
				if (length < m_pOpoDacValCtx->RetDataLen)
				{
					m_pOpoDacValCtx->RetDataLen = length;
				}
				if (m_pOpoDacValCtx->RetDataLen > 0)
				{
					if (flag3)
					{
						Marshal.Copy(m_pOpoDacValCtx->pBuffer, buffer, bufferOffset, m_pOpoDacValCtx->RetDataLen);
					}
					else
					{
						string value = OracleString.GetValue(m_pOpoDacValCtx->pBuffer, m_pOpoDacValCtx->RetDataLen, flag3);
						value.CopyTo(0, buffer, bufferOffset, m_pOpoDacValCtx->RetDataLen);
					}
				}
			}
		}
		else
		{
			m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
			m_pOpoDacValCtx->BufLen = 0;
			m_pOpoDacValCtx->FieldOffset = fieldOffset;
			try
			{
				num = OpsDac.GetLen(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx);
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
				throw;
			}
			if ((oraType == OraType.ORA_LONG || (oraType == OraType.ORA_OCICLobLocator && m_pOpoDacValCtx->InitialLobFS > 0 && !m_isDBVer10gR2OrHigher)) && !m_pkFetched)
			{
				UpdateMetaDataPool();
			}
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
			if (m_pOpoDacValCtx->Indicator == -1)
			{
				throw new InvalidCastException(OpoErrResManager.GetErrorMesg(ErrRes.DR_NULL_COL_DATA));
			}
			m_pOpoDacValCtx->RetDataLen /= 2;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetChars()\n");
		}
		return m_pOpoDacValCtx->RetDataLen;
	}

	public new DbDataReader GetData(int i)
	{
		throw new NotSupportedException();
	}

	public override string GetDataTypeName(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetDataTypeName()\n");
		}
		if (m_closed)
		{
			throw new InvalidOperationException();
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetDataTypeName()\n");
		}
		return m_oracleDbType[i].ToString();
	}

	public unsafe override DateTime GetDateTime(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetDateTime()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (m_external && oraType != OraType.ORA_TIMESTAMP && oraType != OraType.ORA_TIMESTAMP_LTZ && oraType != OraType.ORA_TIMESTAMP_TZ && oraType != OraType.ORA_DATE)
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		long num2 = m_fetchArrayLocation + m_rowLocation + m_colIndOffset[i];
		short num3 = *(short*)num2;
		if (num3 == -1)
		{
			throw new InvalidCastException(OpoErrResManager.GetErrorMesg(ErrRes.DR_NULL_COL_DATA));
		}
		long num4 = m_fetchArrayLocation + m_rowLocation;
		IntPtr pBuffer = (IntPtr)(num4 + m_colOffset[i]);
		m_pOpoDacValCtx->pBuffer = pBuffer;
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		try
		{
			num = OpsDac.GetType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, 1);
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
		DateTime result;
		switch (oraType)
		{
		case OraType.ORA_DATE:
		{
			byte* ptr = (byte*)(void*)m_pOpoDacValCtx->pBuffer;
			int year = (*ptr - 100) * 100 + (ptr[1] - 100);
			result = new DateTime(year, ptr[2], ptr[3], ptr[4] - 1, ptr[5] - 1, ptr[6] - 1);
			m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
			break;
		}
		case OraType.ORA_TIMESTAMP:
			result = DateTimeConv.GetDateTime((OpoTSValCtx*)m_pOpoDacValCtx->pValCtx, OracleDbType.TimeStamp, bCheck: false);
			break;
		case OraType.ORA_TIMESTAMP_LTZ:
			result = DateTimeConv.GetDateTime((OpoTSValCtx*)m_pOpoDacValCtx->pValCtx, OracleDbType.TimeStampLTZ, bCheck: false);
			break;
		case OraType.ORA_TIMESTAMP_TZ:
			result = DateTimeConv.GetDateTime((OpoTSValCtx*)m_pOpoDacValCtx->pValCtx, OracleDbType.TimeStampTZ, bCheck: false);
			break;
		default:
			result = default(DateTime);
			break;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetDateTime()\n");
		}
		return result;
	}

	public unsafe override decimal GetDecimal(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetDecimal()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		OraType oraType = m_oraType[i];
		if (m_isFromEF)
		{
			if (oraType != OraType.ORA_NUMBER && oraType != OraType.ORA_INTERVAL_YM && oraType != OraType.ORA_INTERVAL_DS)
			{
				throw new InvalidCastException();
			}
			switch (oraType)
			{
			case OraType.ORA_INTERVAL_DS:
				return (decimal)GetTimeSpan(i).TotalSeconds;
			case OraType.ORA_INTERVAL_YM:
			{
				object value = GetValue(i);
				return (decimal)value;
			}
			}
		}
		else if (oraType != OraType.ORA_NUMBER)
		{
			throw new InvalidCastException();
		}
		long num = m_fetchArrayLocation + m_rowLocation + m_colIndOffset[i];
		short num2 = *(short*)num;
		if (num2 == -1)
		{
			throw new InvalidCastException(OpoErrResManager.GetErrorMesg(ErrRes.DR_NULL_COL_DATA));
		}
		long num3 = m_fetchArrayLocation + m_rowLocation;
		IntPtr numCtx = (IntPtr)(num3 + m_colOffset[i]);
		return DecimalConv.GetDecimal(numCtx);
	}

	public unsafe override double GetDouble(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetDouble()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (oraType != OraType.ORA_NUMBER && oraType != OraType.ORA_IBDOUBLE)
		{
			throw new InvalidCastException();
		}
		int precision = m_pOpoMetValCtx->pColMetaVal[i].Precision;
		if (!m_isFromEF && precision >= 16 && oraType != OraType.ORA_IBDOUBLE)
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		m_pOpoDacValCtx->Type = 108;
		long num2 = m_fetchArrayLocation + m_rowLocation + m_colIndOffset[i];
		short num3 = *(short*)num2;
		if (num3 == -1)
		{
			throw new InvalidCastException(OpoErrResManager.GetErrorMesg(ErrRes.DR_NULL_COL_DATA));
		}
		long num4 = m_fetchArrayLocation + m_rowLocation;
		IntPtr pBuffer = (IntPtr)(num4 + m_colOffset[i]);
		m_pOpoDacValCtx->pBuffer = pBuffer;
		try
		{
			num = OpsDac.GetType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, 1);
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
				if (m_pOpoDacValCtx->Type == -1)
				{
					if (num == 22053 || num == 22054)
					{
						throw new OverflowException(OracleTypeException.GetTypeMsg(num));
					}
					throw new OracleTypeException(num);
				}
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetDouble()\n");
		}
		return *(double*)m_pOpoDacValCtx->pValCtx;
	}

	public unsafe override Type GetFieldType(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetFieldType()\n");
		}
		if (m_closed)
		{
			throw new InvalidOperationException();
		}
		if (i >= m_fieldCount || i < 0)
		{
			throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
		}
		OraType oraType = m_oraType[i];
		if (oraType == OraType.ORA_NDT && m_pOpoMetValCtx->pColMetaVal[i].bIsXmlType == 0)
		{
			OracleUdtDescriptor cachedOracleUdtDescriptor = GetCachedOracleUdtDescriptor(i);
			if (cachedOracleUdtDescriptor.m_bSetOracleDbType)
			{
				_ = cachedOracleUdtDescriptor.m_oraDbType;
			}
			else
			{
				_ = cachedOracleUdtDescriptor.OracleDbType;
			}
			if (cachedOracleUdtDescriptor.OracleDbType != OracleDbType.XmlType)
			{
				if (OracleConnection.s_bIsOdtConnection)
				{
					return typeof(object);
				}
				object factory = OracleUdt.GetFactory(cachedOracleUdtDescriptor);
				if (factory is IOracleCustomTypeFactory)
				{
					return ((IOracleCustomTypeFactory)factory).CreateObject().GetType();
				}
				if (factory is IOracleArrayTypeFactory)
				{
					return ((IOracleArrayTypeFactory)factory).CreateArray(0).GetType();
				}
				return factory.GetType();
			}
		}
		Type type = (Type)OracleTypeMapper.m_OraToNET[oraType];
		if (m_safeMapping != null && m_safeMapping.Count > 0 && IsCorruptible(oraType))
		{
			Type type2 = (Type)m_safeMapping[m_colMetaRef[i].pColAlias];
			if (type2 == null)
			{
				type2 = (Type)m_safeMapping["*"];
			}
			if (type2 != null)
			{
				type = type2;
			}
		}
		if (type == typeof(decimal))
		{
			int scale = m_pOpoMetValCtx->pColMetaVal[i].Scale;
			int precision = m_pOpoMetValCtx->pColMetaVal[i].Precision;
			if (scale <= 0 && precision - scale < 5)
			{
				type = typeof(short);
			}
			else if (scale <= 0 && precision - scale < 10)
			{
				type = typeof(int);
			}
			else if (scale <= 0 && precision - scale < 19)
			{
				type = typeof(long);
			}
			else if (precision < 8 && ((scale <= 0 && precision - scale <= 38) || (scale > 0 && scale <= 44)))
			{
				type = typeof(float);
			}
			else if (precision < 16)
			{
				type = typeof(double);
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetFieldType()\n");
		}
		return type;
	}

	public override Guid GetGuid(int i)
	{
		if (m_isFromEF)
		{
			object value = GetValue(i);
			return (Guid)value;
		}
		throw new NotSupportedException();
	}

	public unsafe override short GetInt16(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetInt16()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (oraType != OraType.ORA_NUMBER)
		{
			throw new InvalidCastException();
		}
		int scale = m_pOpoMetValCtx->pColMetaVal[i].Scale;
		int precision = m_pOpoMetValCtx->pColMetaVal[i].Precision;
		if (!m_isFromEF && (scale > 0 || precision - scale >= 5))
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		m_pOpoDacValCtx->Type = 111;
		long num2 = m_fetchArrayLocation + m_rowLocation + m_colIndOffset[i];
		short num3 = *(short*)num2;
		if (num3 == -1)
		{
			throw new InvalidCastException(OpoErrResManager.GetErrorMesg(ErrRes.DR_NULL_COL_DATA));
		}
		long num4 = m_fetchArrayLocation + m_rowLocation;
		IntPtr pBuffer = (IntPtr)(num4 + m_colOffset[i]);
		m_pOpoDacValCtx->pBuffer = pBuffer;
		try
		{
			num = OpsDac.GetType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, 1);
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
				if (m_pOpoDacValCtx->Type == -1)
				{
					if (num == 22053 || num == 22054)
					{
						throw new OverflowException(OracleTypeException.GetTypeMsg(num));
					}
					throw new OracleTypeException(num);
				}
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetInt16()\n");
		}
		return *(short*)m_pOpoDacValCtx->pValCtx;
	}

	public unsafe override int GetInt32(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetInt32()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (oraType != OraType.ORA_NUMBER)
		{
			throw new InvalidCastException();
		}
		int scale = m_pOpoMetValCtx->pColMetaVal[i].Scale;
		int precision = m_pOpoMetValCtx->pColMetaVal[i].Precision;
		if (!m_isFromEF && (scale > 0 || precision - scale >= 10))
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		m_pOpoDacValCtx->Type = 112;
		long num2 = m_fetchArrayLocation + m_rowLocation + (int)m_colIndOffset[i];
		short num3 = *(short*)num2;
		if (num3 == -1)
		{
			throw new InvalidCastException(OpoErrResManager.GetErrorMesg(ErrRes.DR_NULL_COL_DATA));
		}
		long num4 = m_fetchArrayLocation + m_rowLocation;
		IntPtr pBuffer = (IntPtr)(num4 + m_colOffset[i]);
		m_pOpoDacValCtx->pBuffer = pBuffer;
		try
		{
			num = OpsDac.GetType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, 1);
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
				if (m_pOpoDacValCtx->Type == -1)
				{
					if (num == 22053 || num == 22054)
					{
						throw new OverflowException(OracleTypeException.GetTypeMsg(num));
					}
					throw new OracleTypeException(num);
				}
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetInt32()\n");
		}
		return *(int*)m_pOpoDacValCtx->pValCtx;
	}

	public unsafe override long GetInt64(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetInt64()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (oraType != OraType.ORA_NUMBER && oraType != OraType.ORA_INTERVAL_YM)
		{
			throw new InvalidCastException();
		}
		if (oraType == OraType.ORA_NUMBER)
		{
			int scale = m_pOpoMetValCtx->pColMetaVal[i].Scale;
			int precision = m_pOpoMetValCtx->pColMetaVal[i].Precision;
			if (!m_isFromEF && (scale > 0 || precision - scale >= 19))
			{
				throw new InvalidCastException();
			}
		}
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		m_pOpoDacValCtx->Type = 113;
		long num2 = m_fetchArrayLocation + m_rowLocation + m_colIndOffset[i];
		short num3 = *(short*)num2;
		if (num3 == -1)
		{
			throw new InvalidCastException(OpoErrResManager.GetErrorMesg(ErrRes.DR_NULL_COL_DATA));
		}
		long num4 = m_fetchArrayLocation + m_rowLocation;
		IntPtr pBuffer = (IntPtr)(num4 + m_colOffset[i]);
		m_pOpoDacValCtx->pBuffer = pBuffer;
		try
		{
			num = OpsDac.GetType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, 1);
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
				if (m_pOpoDacValCtx->Type == -1)
				{
					if (num == 22053 || num == 22054)
					{
						throw new OverflowException(OracleTypeException.GetTypeMsg(num));
					}
					throw new OracleTypeException(num);
				}
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		if (oraType == OraType.ORA_INTERVAL_YM)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetInt64()\n");
			}
			return LongConv.GetLong((OpoITLValCtx*)m_pOpoDacValCtx->pValCtx, OracleDbType.IntervalYM);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetInt64()\n");
		}
		return *(long*)m_pOpoDacValCtx->pValCtx;
	}

	public unsafe override float GetFloat(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetFloat()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (oraType != OraType.ORA_NUMBER && oraType != OraType.ORA_IBFLOAT)
		{
			throw new InvalidCastException();
		}
		int scale = m_pOpoMetValCtx->pColMetaVal[i].Scale;
		int precision = m_pOpoMetValCtx->pColMetaVal[i].Precision;
		if (!m_isFromEF && (precision >= 8 || ((scale > 0 || precision - scale > 38) && (scale <= 0 || scale > 44))) && oraType != OraType.ORA_IBFLOAT)
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		m_pOpoDacValCtx->Type = 108;
		long num2 = m_fetchArrayLocation + m_rowLocation + m_colIndOffset[i];
		short num3 = *(short*)num2;
		if (num3 == -1)
		{
			throw new InvalidCastException(OpoErrResManager.GetErrorMesg(ErrRes.DR_NULL_COL_DATA));
		}
		long num4 = m_fetchArrayLocation + m_rowLocation;
		IntPtr pBuffer = (IntPtr)(num4 + m_colOffset[i]);
		m_pOpoDacValCtx->pBuffer = pBuffer;
		try
		{
			num = OpsDac.GetType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, 1);
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
				if (m_pOpoDacValCtx->Type == -1)
				{
					if (num == 22053 || num == 22054)
					{
						throw new OverflowException(OracleTypeException.GetTypeMsg(num));
					}
					throw new OracleTypeException(num);
				}
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetFloat()\n");
		}
		if (oraType != OraType.ORA_IBFLOAT)
		{
			return (float)(*(double*)m_pOpoDacValCtx->pValCtx);
		}
		return *(float*)m_pOpoDacValCtx->pValCtx;
	}

	public unsafe override string GetName(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetName()\n");
		}
		if (m_closed)
		{
			throw new InvalidOperationException();
		}
		if (i >= m_fieldCount || i < 0)
		{
			throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
		}
		if (m_pOpoMetValCtx != null && m_colMetaRef == null)
		{
			GetColMetaRef(bFetchMoreMetaIfRequired: false, bLocalParsed: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetName()\n");
		}
		return m_colMetaRef[i].pColAlias;
	}

	public OracleBinary GetOracleBinary(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetOracleBinary()\n");
		}
		byte[] buffer = null;
		long num = 0L;
		if ((num = GetBytesInternal(i, 0L, buffer, 0, 0, bThrowException: false)) < 0)
		{
			return OracleBinary.Null;
		}
		buffer = new byte[num];
		int num2 = 0;
		while (num > int.MaxValue)
		{
			if (GetBytesInternal(i, num2, buffer, num2, int.MaxValue, bThrowException: false) < 0)
			{
				return OracleBinary.Null;
			}
			num2 += int.MaxValue;
			num -= int.MaxValue;
		}
		if (GetBytesInternal(i, num2, buffer, num2, (int)num, bThrowException: false) < 0)
		{
			return OracleBinary.Null;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleBinary()\n");
		}
		return new OracleBinary(buffer);
	}

	public unsafe OracleBlob GetOracleBlob(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetOracleBlob()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (oraType != OraType.ORA_OCIBLobLocator || m_pOpoDacValCtx->InitialLobFS == -1 || (m_pOpoDacValCtx->InitialLobFS > 0 && !m_isDBVer10gR2OrHigher))
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		try
		{
			num = OpsDac.GetOraType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx);
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
		if (m_pOpoDacValCtx->Indicator == -1)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleBlob()\n");
			}
			return OracleBlob.Null;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleBlob()\n");
		}
		return new OracleBlob(m_connection, m_pOpoDacValCtx->pBuffer, bCaching: false, bTempLob: false);
	}

	public unsafe OracleBlob GetOracleBlobForUpdate(int i, int wait)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetOracleBlobForUpdate()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (oraType != OraType.ORA_OCIBLobLocator || m_pOpoDacValCtx->InitialLobFS == -1 || (m_pOpoDacValCtx->InitialLobFS > 0 && !m_isDBVer10gR2OrHigher))
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		m_pOpoDacValCtx->ForUpdate = 1;
		m_pOpoDacValCtx->Wait = wait;
		try
		{
			num = OpsDac.GetOraType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		if (!m_pkFetched)
		{
			UpdateMetaDataPool();
		}
		if (num != 0)
		{
			if (num == ErrRes.DAC_PK_REQUIRED)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.DAC_PK_REQUIRED));
			}
			OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
		}
		if (m_pOpoDacValCtx->Indicator == -1)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleBlobForUpdate()\n");
			}
			return OracleBlob.Null;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleBlobForUpdate()\n");
		}
		return new OracleBlob(m_connection, m_pOpoDacValCtx->pBuffer, bCaching: false, bTempLob: false);
	}

	public OracleBlob GetOracleBlobForUpdate(int i)
	{
		return GetOracleBlobForUpdate(i, -1);
	}

	public unsafe OracleBFile GetOracleBFile(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetOracleBFile()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (oraType != OraType.ORA_OCIBFileLocator)
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		try
		{
			num = OpsDac.GetOraType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx);
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
		if (m_pOpoDacValCtx->Indicator == -1)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleBFile()\n");
			}
			return OracleBFile.Null;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleBFile()\n");
		}
		return new OracleBFile(m_connection, m_pOpoDacValCtx->pBuffer);
	}

	public unsafe OracleClob GetOracleClob(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetOracleClob()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (oraType != OraType.ORA_OCICLobLocator || m_pOpoDacValCtx->InitialLobFS == -1 || (m_pOpoDacValCtx->InitialLobFS > 0 && !m_isDBVer10gR2OrHigher))
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		try
		{
			num = OpsDac.GetOraType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx);
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
		if (m_pOpoDacValCtx->Indicator == -1)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleClob()\n");
			}
			return OracleClob.Null;
		}
		bool bNClob = true;
		if (m_pOpoMetValCtx->pColMetaVal[i].UCS2Character == 0)
		{
			bNClob = false;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleClob()\n");
		}
		return new OracleClob(m_connection, m_pOpoDacValCtx->pBuffer, bCaching: false, bNClob, bTempLob: false);
	}

	public unsafe OracleClob GetOracleClobForUpdate(int i, int wait)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetOracleClobForUpdate()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (oraType != OraType.ORA_OCICLobLocator || m_pOpoDacValCtx->InitialLobFS == -1 || (m_pOpoDacValCtx->InitialLobFS > 0 && !m_isDBVer10gR2OrHigher))
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		m_pOpoDacValCtx->ForUpdate = 1;
		m_pOpoDacValCtx->Wait = wait;
		try
		{
			num = OpsDac.GetOraType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		if (!m_pkFetched)
		{
			UpdateMetaDataPool();
		}
		if (num != 0)
		{
			if (num == ErrRes.DAC_PK_REQUIRED)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.DAC_PK_REQUIRED));
			}
			OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
		}
		if (m_pOpoDacValCtx->Indicator == -1)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleClobForUpdate()\n");
			}
			return OracleClob.Null;
		}
		bool bNClob = true;
		if (m_pOpoMetValCtx->pColMetaVal[i].UCS2Character == 0)
		{
			bNClob = false;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleClobForUpdate()\n");
		}
		return new OracleClob(m_connection, m_pOpoDacValCtx->pBuffer, bCaching: false, bNClob, bTempLob: false);
	}

	public OracleClob GetOracleClobForUpdate(int i)
	{
		return GetOracleClobForUpdate(i, -1);
	}

	public unsafe OracleDate GetOracleDate(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetOracleDate()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (oraType != OraType.ORA_DATE)
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		try
		{
			num = OpsDac.GetOraType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx);
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
		if (m_pOpoDacValCtx->Indicator == -1)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleDate()\n");
			}
			return OracleDate.Null;
		}
		OracleDate result = new OracleDate((OpoDatValCtx*)m_pOpoDacValCtx->pValCtx);
		m_pOpoDacValCtx->pValCtx = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleDate()\n");
		}
		return result;
	}

	public unsafe OracleDecimal GetOracleDecimal(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetOracleDecimal()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (oraType != OraType.ORA_NUMBER && oraType != OraType.ORA_IBFLOAT && oraType != OraType.ORA_IBDOUBLE)
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		try
		{
			num = OpsDac.GetOraType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx);
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
		if (m_pOpoDacValCtx->Indicator == -1)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleDecimal()\n");
			}
			return OracleDecimal.Null;
		}
		OracleDecimal result = ((OraType.ORA_NUMBER == oraType) ? new OracleDecimal((IntPtr)m_pOpoDacValCtx->pValCtx, getInfo: false) : ((OraType.ORA_IBFLOAT != oraType) ? new OracleDecimal(*(double*)m_pOpoDacValCtx->pValCtx) : new OracleDecimal(*(float*)m_pOpoDacValCtx->pValCtx)));
		m_pOpoDacValCtx->pValCtx = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleDecimal()\n");
		}
		return result;
	}

	public unsafe OracleIntervalDS GetOracleIntervalDS(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetOracleIntervalDS()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (oraType != OraType.ORA_INTERVAL_DS)
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		try
		{
			num = OpsDac.GetOraType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx);
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
		if (m_pOpoDacValCtx->Indicator == -1)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleIntervalDS()\n");
			}
			return OracleIntervalDS.Null;
		}
		OracleIntervalDS result = new OracleIntervalDS((OpoITLValCtx*)m_pOpoDacValCtx->pValCtx, m_pOpoMetValCtx->pColMetaVal[i].Precision, m_pOpoMetValCtx->pColMetaVal[i].Scale);
		m_pOpoDacValCtx->pValCtx = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleIntervalDS()\n");
		}
		return result;
	}

	public unsafe OracleIntervalYM GetOracleIntervalYM(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetOracleIntervalYM()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (oraType != OraType.ORA_INTERVAL_YM)
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		try
		{
			num = OpsDac.GetOraType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx);
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
		if (m_pOpoDacValCtx->Indicator == -1)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleIntervalYM()\n");
			}
			return OracleIntervalYM.Null;
		}
		OracleIntervalYM result = new OracleIntervalYM((OpoITLValCtx*)m_pOpoDacValCtx->pValCtx, m_pOpoMetValCtx->pColMetaVal[i].Precision);
		m_pOpoDacValCtx->pValCtx = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleIntervalYM()\n");
		}
		return result;
	}

	public unsafe OracleRef GetOracleRef(int i)
	{
		OracleRef oracleRef = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetOracleRef()\n");
		}
		if (m_closed || m_bBOF || m_bEOF)
		{
			throw new InvalidOperationException();
		}
		if (i >= m_fieldCount || i < 0)
		{
			throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (oraType != OraType.ORA_OCIRef)
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		OracleUdtDescriptor cachedOracleUdtDescriptor = GetCachedOracleUdtDescriptor(i);
		try
		{
			num = OpsDac.GetOraType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx);
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
		if (m_pOpoDacValCtx->Indicator == -1)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleRef()\n");
			}
			return OracleRef.Null;
		}
		if (!m_fillReader && m_pOpoDacValCtx->Indicator == 0 && m_pOpoDacValCtx->pBuffer == IntPtr.Zero)
		{
			OracleRef oracleRef2 = (OracleRef)m_currentRowUdtCache[i];
			oracleRef2 = (OracleRef)oracleRef2.Clone();
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleRef()\n");
			}
			return oracleRef2;
		}
		OpoUdtCtx opoUdtCtx = new OpoUdtCtx(m_opsConCtx, IntPtr.Zero, m_pOpoDacValCtx->pBuffer, m_pOpoDacValCtx->pUdtNullStruct);
		oracleRef = ((m_pOpoMetValCtx->pColMetaVal[i].bIsFinalType != 0) ? new OracleRef(cachedOracleUdtDescriptor, opoUdtCtx) : new OracleRef(m_connection, opoUdtCtx));
		if (!m_fillReader)
		{
			m_currentRowUdtCache[i] = oracleRef;
		}
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleRef()\n");
		}
		return oracleRef;
	}

	public unsafe OracleString GetOracleString(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetOracleString()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (m_external && oraType != OraType.ORA_CHAR && oraType != OraType.ORA_CHARN && oraType != OraType.ORA_LONG && oraType != OraType.ORA_OCIRowid && oraType != OraType.ORA_OCICLobLocator && oraType != OraType.ORA_NDT && oraType != OraType.ORA_OCIRef)
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		if (oraType == OraType.ORA_NDT || oraType == OraType.ORA_OCIRef)
		{
			if (m_pOpoMetValCtx->pColMetaVal[i].bIsXmlType != 1)
			{
				if (IsDBNull(i))
				{
					return OracleString.Null;
				}
				return new OracleString(GetString(i));
			}
			if (m_opsXmlTypeCtx == null)
			{
				m_opsXmlTypeCtx = new IntPtr[m_fieldCount];
			}
			else if (m_opsXmlTypeCtx[i] != IntPtr.Zero)
			{
				IntPtr opsXmlStreamValueBuffer = IntPtr.Zero;
				int numCharsInBuffer = 0;
				OracleString result = null;
				try
				{
					num = OpsXmlStream.GetValueBuffer(m_opsConCtx, m_opsErrCtx, m_opsXmlTypeCtx[i], ref opsXmlStreamValueBuffer, ref numCharsInBuffer);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					throw;
				}
				if (num == 0)
				{
					result = new OracleString(opsXmlStreamValueBuffer, numCharsInBuffer, isUnicode: true);
					try
					{
						num = OpsXmlStream.FreeValueBuffer(ref opsXmlStreamValueBuffer);
					}
					catch (Exception ex2)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex2);
						}
					}
				}
				if (num != 0)
				{
					OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
				}
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleString()\n");
				return result;
			}
		}
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		string text = null;
		GCHandle gCHandle = default(GCHandle);
		bool flag;
		if ((oraType == OraType.ORA_LONG && InitialLONGFetchSize != -1) || (oraType == OraType.ORA_OCICLobLocator && InitialLOBFetchSize != -1))
		{
			try
			{
				num = OpsDac.GetLen(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx);
			}
			catch (Exception ex3)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex3);
				}
				throw;
			}
			if ((oraType == OraType.ORA_LONG || (oraType == OraType.ORA_OCICLobLocator && m_pOpoDacValCtx->InitialLobFS > 0 && !m_isDBVer10gR2OrHigher)) && !m_pkFetched)
			{
				UpdateMetaDataPool();
			}
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
			if (m_pOpoDacValCtx->Indicator == -1)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOralceString()\n");
				}
				return OracleString.Null;
			}
			if (((oraType != OraType.ORA_LONG || m_pOpoDacValCtx->RetDataLen / 2 > m_pOpoDacValCtx->InitialLongFS) && (oraType != OraType.ORA_OCICLobLocator || m_pOpoDacValCtx->InitialLobFS <= 0 || m_pOpoDacValCtx->RetDataLen / 2 > m_pOpoDacValCtx->InitialLobFS)) || (oraType == OraType.ORA_OCICLobLocator && m_pOpoDacValCtx->InitialLobFS > 0 && m_pOpoDacValCtx->RetDataLen / 2 > m_pOpoDacValCtx->InitialLobFS && m_isDBVer10gR2OrHigher))
			{
				flag = false;
				text = new string('\0', m_pOpoDacValCtx->RetDataLen / 2);
				gCHandle = GCHandle.Alloc(text, GCHandleType.Pinned);
				m_pOpoDacValCtx->pBuffer = gCHandle.AddrOfPinnedObject();
				m_pOpoDacValCtx->BufLen = m_pOpoDacValCtx->RetDataLen;
			}
			else
			{
				flag = true;
				m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
				m_pOpoDacValCtx->BufLen = m_pOpoDacValCtx->RetDataLen;
			}
		}
		else
		{
			flag = true;
			m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
			m_pOpoDacValCtx->BufLen = 0;
		}
		m_pOpoDacValCtx->FieldOffset = 0L;
		try
		{
			num = OpsDac.GetType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, 0);
		}
		catch (Exception ex4)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex4);
			}
			num = ErrRes.INT_ERR;
			throw;
		}
		finally
		{
			if (num != ErrRes.INT_ERR && (oraType == OraType.ORA_LONG || (oraType == OraType.ORA_OCICLobLocator && m_pOpoDacValCtx->InitialLobFS > 0 && !m_isDBVer10gR2OrHigher)) && !m_pkFetched)
			{
				UpdateMetaDataPool();
			}
			if (!flag && gCHandle.IsAllocated)
			{
				gCHandle.Free();
			}
		}
		if (num != 0)
		{
			OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
		}
		if (m_pOpoDacValCtx->Indicator == -1)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOralceString()\n");
			}
			return OracleString.Null;
		}
		if (oraType == OraType.ORA_NDT)
		{
			if (m_pOpoMetValCtx->pColMetaVal[i].bIsXmlType == 1)
			{
				IntPtr intPtr = (IntPtr)m_pOpoDacValCtx->pValCtx;
				IntPtr opsXmlStreamValueBuffer2 = IntPtr.Zero;
				int numCharsInBuffer2 = 0;
				OracleString result2 = null;
				m_opsXmlTypeCtx[i] = intPtr;
				m_pOpoDacValCtx->pValCtx = null;
				try
				{
					num = OpsXmlStream.GetValueBuffer(m_opsConCtx, m_opsErrCtx, intPtr, ref opsXmlStreamValueBuffer2, ref numCharsInBuffer2);
				}
				catch (Exception ex5)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex5);
					}
					throw;
				}
				if (num == 0)
				{
					result2 = new OracleString(opsXmlStreamValueBuffer2, numCharsInBuffer2, isUnicode: true);
					try
					{
						num = OpsXmlStream.FreeValueBuffer(ref opsXmlStreamValueBuffer2);
					}
					catch (Exception ex6)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex6);
						}
					}
				}
				if (num != 0)
				{
					OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
				}
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleString()\n");
				return result2;
			}
			return new OracleString(GetString(i));
		}
		m_pOpoDacValCtx->RetDataLen /= 2;
		if (flag)
		{
			bool isUnicode = true;
			if (m_pOpoMetValCtx->pColMetaVal[i].UCS2Character == 0)
			{
				isUnicode = false;
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetString()\n");
			}
			return new OracleString(m_pOpoDacValCtx->pBuffer, m_pOpoDacValCtx->RetDataLen, isUnicode);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOralceString()\n");
		}
		return new OracleString(text);
	}

	public unsafe OracleTimeStamp GetOracleTimeStamp(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetOracleTimeStamp()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (oraType != OraType.ORA_TIMESTAMP)
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		try
		{
			num = OpsDac.GetOraType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx);
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
		if (m_pOpoDacValCtx->Indicator == -1)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleTimeStamp()\n");
			}
			return OracleTimeStamp.Null;
		}
		OracleTimeStamp result = new OracleTimeStamp((OpoTSValCtx*)m_pOpoDacValCtx->pValCtx, m_pOpoMetValCtx->pColMetaVal[i].Scale);
		m_pOpoDacValCtx->pValCtx = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleTimeStamp()\n");
		}
		return result;
	}

	public unsafe OracleTimeStampLTZ GetOracleTimeStampLTZ(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetOracleTimeStampLTZ()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (oraType != OraType.ORA_TIMESTAMP_LTZ)
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		try
		{
			num = OpsDac.GetOraType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx);
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
		if (m_pOpoDacValCtx->Indicator == -1)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleTimeStampLTZ()\n");
			}
			return OracleTimeStampLTZ.Null;
		}
		OracleTimeStampLTZ result = new OracleTimeStampLTZ((OpoTSValCtx*)m_pOpoDacValCtx->pValCtx, m_pOpoMetValCtx->pColMetaVal[i].Scale);
		m_pOpoDacValCtx->pValCtx = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleTimeStampLTZ()\n");
		}
		return result;
	}

	public unsafe OracleTimeStampTZ GetOracleTimeStampTZ(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetOracleTimeStampTZ()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (oraType != OraType.ORA_TIMESTAMP_TZ)
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		try
		{
			num = OpsDac.GetOraType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx);
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
		if (m_pOpoDacValCtx->Indicator == -1)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleTimeStampTZ()\n");
			}
			return OracleTimeStampTZ.Null;
		}
		OracleTimeStampTZ result = new OracleTimeStampTZ((OpoTSValCtx*)m_pOpoDacValCtx->pValCtx, m_pOpoMetValCtx->pColMetaVal[i].Scale);
		m_pOpoDacValCtx->pValCtx = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleTimeStampTZ()\n");
		}
		return result;
	}

	public unsafe OracleXmlType GetOracleXmlType(int i)
	{
		OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetOracleXmlType()\n");
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (oraType != OraType.ORA_NDT)
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		if (m_opsXmlTypeCtx == null)
		{
			m_opsXmlTypeCtx = new IntPtr[m_fieldCount];
		}
		else if (m_opsXmlTypeCtx[i] != IntPtr.Zero)
		{
			return new OracleXmlType(m_connection, m_opsXmlTypeCtx[i], flag: true);
		}
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		try
		{
			num = OpsDac.GetOraType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx);
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
		if (m_pOpoDacValCtx->Indicator == -1)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleXmlType()\n");
			return OracleXmlType.Null;
		}
		OracleXmlType result = new OracleXmlType(m_connection, (IntPtr)m_pOpoDacValCtx->pValCtx, flag: true);
		ref IntPtr reference = ref m_opsXmlTypeCtx[i];
		reference = (IntPtr)m_pOpoDacValCtx->pValCtx;
		m_pOpoDacValCtx->pValCtx = null;
		OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleXmlType()\n");
		return result;
	}

	public unsafe object GetOracleValue(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetOracleValue()\n");
		}
		object result = null;
		OraType oraType = (OraType)m_pOpoMetValCtx->pColMetaVal[i].OraType;
		try
		{
			m_external = false;
			switch (oraType)
			{
			case OraType.ORA_RAW:
			case OraType.ORA_LONGRAW:
				result = GetOracleBinary(i);
				break;
			case OraType.ORA_OCIBFileLocator:
				result = GetOracleBFile(i);
				break;
			case OraType.ORA_OCIBLobLocator:
				result = ((InitialLOBFetchSize != 0 && (InitialLOBFetchSize == -1 || !m_isDBVer10gR2OrHigher)) ? ((object)GetOracleBinary(i)) : GetOracleBlob(i));
				break;
			case OraType.ORA_OCICLobLocator:
				result = ((InitialLOBFetchSize != 0 && (InitialLOBFetchSize == -1 || !m_isDBVer10gR2OrHigher)) ? ((object)GetOracleString(i)) : GetOracleClob(i));
				break;
			case OraType.ORA_DATE:
				result = GetOracleDate(i);
				break;
			case OraType.ORA_NUMBER:
				result = GetOracleDecimal(i);
				break;
			case OraType.ORA_CHARN:
			case OraType.ORA_LONG:
			case OraType.ORA_CHAR:
			case OraType.ORA_OCIRowid:
				result = GetOracleString(i);
				break;
			case OraType.ORA_INTERVAL_DS:
				result = GetOracleIntervalDS(i);
				break;
			case OraType.ORA_INTERVAL_YM:
				result = GetOracleIntervalYM(i);
				break;
			case OraType.ORA_TIMESTAMP:
				result = GetOracleTimeStamp(i);
				break;
			case OraType.ORA_TIMESTAMP_LTZ:
				result = GetOracleTimeStampLTZ(i);
				break;
			case OraType.ORA_TIMESTAMP_TZ:
				result = GetOracleTimeStampTZ(i);
				break;
			case OraType.ORA_NDT:
				result = ((m_pOpoMetValCtx->pColMetaVal[i].bIsXmlType == 1) ? GetOracleXmlType(i) : GetCustomObject(i));
				break;
			case OraType.ORA_OCIRef:
				result = GetOracleRef(i);
				break;
			case OraType.ORA_IBFLOAT:
			case OraType.ORA_IBDOUBLE:
				result = GetOracleDecimal(i);
				break;
			}
		}
		finally
		{
			m_external = true;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleValue()\n");
		}
		return result;
	}

	public int GetOracleValues(object[] values)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetOracleValues()\n");
		}
		if (m_closed || m_bBOF || m_bEOF)
		{
			throw new InvalidOperationException();
		}
		int num = values.Length;
		int num2 = 0;
		num2 = ((num >= m_fieldCount) ? m_fieldCount : num);
		try
		{
			m_external = false;
			for (int i = 0; i < num2; i++)
			{
				values[i] = GetOracleValue(i);
			}
		}
		finally
		{
			m_external = true;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOracleValues()\n");
		}
		return num2;
	}

	public unsafe override int GetOrdinal(string name)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetOrdinal()\n");
		}
		if (m_closed)
		{
			throw new InvalidOperationException();
		}
		if (m_pOpoMetValCtx != null && m_colMetaRef == null)
		{
			GetColMetaRef(bFetchMoreMetaIfRequired: false, bLocalParsed: false);
		}
		for (int i = 0; i < m_fieldCount; i++)
		{
			if (name.Equals(m_colMetaRef[i].pColAlias))
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOrdinal()\n");
				}
				return i;
			}
		}
		for (int j = 0; j < m_fieldCount; j++)
		{
			if (name.ToUpper().Equals(m_colMetaRef[j].pColAlias.ToUpper()))
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOrdinal()\n");
				}
				return j;
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetOrdinal()\n");
		}
		throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_NAME));
	}

	public unsafe override DataTable GetSchemaTable()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetSchemaTable()\n");
		}
		if (m_closed)
		{
			throw new InvalidOperationException();
		}
		if (m_noMoreResults)
		{
			return null;
		}
		if (m_pOpoMetValCtx == null)
		{
			return null;
		}
		DataTable dataTable = null;
		if (m_dataTable == null)
		{
			int num = 0;
			bool bLocalParsed = false;
			try
			{
				if (m_pOpoSqlValCtx->CommandType == 1)
				{
					if (m_pOpoMetValCtx->bStmtParsed != 1)
					{
						num = OpsMet.GetSchemaMetaData(m_opsConCtx, m_opsErrCtx, m_pOpoMetValCtx, m_pOpoSqlValCtx->AddRowid, m_pOpoSqlValCtx->AddToStmtCache);
						bLocalParsed = true;
					}
					if ((m_commandBehavior & CommandBehavior.KeyInfo) == CommandBehavior.KeyInfo && m_pOpoMetValCtx->bPkFetched != 1)
					{
						num = OpsMet.GetPrimaryKey(m_opsConCtx, m_opsErrCtx, m_pOpoMetValCtx, 1, m_pOpoDacValCtx->AddRowid, m_pOpoDacValCtx->AddToStmtCache);
						UpdateMetaDataPool();
					}
				}
				else
				{
					if (m_refCursor != null)
					{
						RefCursorInfo refCursorInfo = m_refCursor.m_refCursorInfo;
						if (refCursorInfo != null)
						{
							dataTable = refCursorInfo.columnInfo;
						}
					}
					else
					{
						StoredProcedureInfo storedProcInfo = RegAndConfigRdr.GetStoredProcInfo(m_storedProcName);
						if (storedProcInfo != null && storedProcInfo.refCursors.Count > 0)
						{
							dataTable = ((RefCursorInfo)storedProcInfo.refCursors[m_currentResultIndex]).columnInfo;
						}
					}
					if (dataTable != null)
					{
						DataTable dataTable2 = dataTable.Copy();
						dataTable2.Columns.Remove("NativeDataType");
						dataTable2.Columns.Remove("ProviderDBType");
						dataTable2.Columns.Remove("ObjectName");
						dataTable2.AcceptChanges();
						return dataTable2;
					}
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
			GetColMetaRef(bFetchMoreMetaIfRequired: true, bLocalParsed);
			m_dataTable = new DataTable("SchemaTable");
			m_dataTable.MinimumCapacity = m_fieldCount;
			m_dataTable.Columns.Add("ColumnName", typeof(string));
			m_dataTable.Columns.Add("ColumnOrdinal", typeof(int));
			m_dataTable.Columns.Add("ColumnSize", typeof(int));
			m_dataTable.Columns.Add("NumericPrecision", typeof(short));
			m_dataTable.Columns.Add("NumericScale", typeof(short));
			m_dataTable.Columns.Add("IsUnique", typeof(bool));
			m_dataTable.Columns.Add("IsKey", typeof(bool));
			m_dataTable.Columns.Add("IsRowID", typeof(bool));
			m_dataTable.Columns.Add("BaseColumnName", typeof(string));
			m_dataTable.Columns.Add("BaseSchemaName", typeof(string));
			m_dataTable.Columns.Add("BaseTableName", typeof(string));
			m_dataTable.Columns.Add("DataType", typeof(Type));
			m_dataTable.Columns.Add("ProviderType", typeof(OracleDbType));
			m_dataTable.Columns.Add("AllowDBNull", typeof(bool));
			m_dataTable.Columns.Add("IsAliased", typeof(bool));
			m_dataTable.Columns.Add("IsByteSemantic", typeof(bool));
			m_dataTable.Columns.Add("IsExpression", typeof(bool));
			m_dataTable.Columns.Add("IsHidden", typeof(bool));
			m_dataTable.Columns.Add("IsReadOnly", typeof(bool));
			m_dataTable.Columns.Add("IsLong", typeof(bool));
			m_dataTable.Columns.Add("UdtTypeName", typeof(string));
			for (int i = 0; i < m_fieldCount; i++)
			{
				DataRow dataRow = m_dataTable.NewRow();
				dataRow[0] = m_colMetaRef[i].pColAlias;
				dataRow[1] = i;
				dataRow[7] = false;
				dataRow[19] = false;
				if (m_pOpoMetValCtx->pColMetaVal[i].NullOK == 1)
				{
					dataRow[13] = true;
				}
				else
				{
					dataRow[13] = false;
				}
				OraType oraType = (OraType)m_pOpoMetValCtx->pColMetaVal[i].OraType;
				switch (oraType)
				{
				case OraType.ORA_INTERVAL_YM:
					dataRow[2] = 5;
					break;
				case OraType.ORA_DATE:
					dataRow[2] = 7;
					break;
				case OraType.ORA_OCIRowid:
					dataRow[2] = 18;
					dataRow[7] = true;
					if (!m_connection.IsDBVer10gR2OrHigher && m_colMetaRef[i].pColName.ToString().Equals("ROWID"))
					{
						dataRow[13] = false;
					}
					break;
				case OraType.ORA_TIMESTAMP:
				case OraType.ORA_INTERVAL_DS:
				case OraType.ORA_TIMESTAMP_LTZ:
					dataRow[2] = 11;
					break;
				case OraType.ORA_TIMESTAMP_TZ:
					dataRow[2] = 13;
					break;
				case OraType.ORA_LONG:
				case OraType.ORA_LONGRAW:
				case OraType.ORA_OCICLobLocator:
				case OraType.ORA_OCIBLobLocator:
				case OraType.ORA_OCIBFileLocator:
					dataRow[2] = int.MaxValue;
					dataRow[19] = true;
					break;
				case OraType.ORA_NDT:
					dataRow[2] = int.MaxValue;
					break;
				case OraType.ORA_CHARN:
				case OraType.ORA_VARCHAR:
				case OraType.ORA_CHAR:
					if (oraType == OraType.ORA_CHARN)
					{
						dataRow[2] = m_pOpoMetValCtx->pColMetaVal[i].Size;
					}
					else
					{
						dataRow[2] = m_pOpoMetValCtx->pColMetaVal[i].Size;
					}
					if (m_pOpoMetValCtx->pColMetaVal[i].bIsByteSemantic == 1)
					{
						dataRow[15] = true;
					}
					else if (m_pOpoMetValCtx->pColMetaVal[i].CharSetForm != 2)
					{
						dataRow[15] = false;
					}
					break;
				case OraType.ORA_OCIRef:
					dataRow[2] = 256;
					break;
				default:
					dataRow[2] = m_pOpoMetValCtx->pColMetaVal[i].Size;
					break;
				}
				if (oraType == OraType.ORA_NUMBER || oraType == OraType.ORA_INTERVAL_DS || oraType == OraType.ORA_INTERVAL_YM)
				{
					dataRow[3] = m_pOpoMetValCtx->pColMetaVal[i].Precision;
				}
				if (oraType == OraType.ORA_NUMBER || oraType == OraType.ORA_INTERVAL_DS || oraType == OraType.ORA_TIMESTAMP || oraType == OraType.ORA_TIMESTAMP_LTZ || oraType == OraType.ORA_TIMESTAMP_TZ)
				{
					dataRow[4] = m_pOpoMetValCtx->pColMetaVal[i].Scale;
				}
				if ((m_commandBehavior & CommandBehavior.KeyInfo) == CommandBehavior.KeyInfo)
				{
					if (m_pOpoMetValCtx->pColMetaVal[i].bIsUnique == 1)
					{
						dataRow[5] = true;
					}
					else
					{
						dataRow[5] = false;
					}
					if (m_pOpoMetValCtx->pColMetaVal[i].bIsKeyColumn == 1)
					{
						dataRow[6] = true;
					}
					else
					{
						dataRow[6] = false;
					}
				}
				dataRow[8] = m_colMetaRef[i].pColName;
				dataRow[9] = m_colMetaRef[i].pSchemaName;
				dataRow[10] = m_colMetaRef[i].pTabName;
				if (m_returnPSTypes)
				{
					dataRow[11] = GetProviderSpecificFieldType(i);
				}
				else
				{
					dataRow[11] = GetFieldType(i);
				}
				if (IsCorruptible(oraType) && (Type)dataRow[11] == typeof(string))
				{
					dataRow[2] = -1;
				}
				dataRow[12] = m_oracleDbType[i];
				if (m_pOpoSqlValCtx->CommandType != 8 && m_pOpoSqlValCtx->CommandType != 9)
				{
					string text = null;
					string text2 = null;
					if (m_colMetaRef[i].pColName != null)
					{
						text = m_colMetaRef[i].pColName;
					}
					if (m_colMetaRef[i].pColAlias != null)
					{
						text2 = m_colMetaRef[i].pColAlias;
					}
					if (text != text2)
					{
						dataRow[14] = true;
					}
					else
					{
						dataRow[14] = false;
					}
					if (m_pOpoMetValCtx->pColMetaVal[i].bIsExpression == 1)
					{
						dataRow[16] = true;
					}
					else
					{
						dataRow[16] = false;
					}
				}
				if (m_pOpoMetValCtx->pColMetaVal[i].bIsHiddenCol == 1)
				{
					dataRow[17] = true;
				}
				else
				{
					dataRow[17] = false;
				}
				if (m_pOpoMetValCtx->pColMetaVal[i].Updatable == 1 || m_pOpoSqlValCtx->CommandType == 8 || (m_pOpoSqlValCtx->CommandType == 9 && !(bool)dataRow[7]))
				{
					dataRow[18] = false;
				}
				else
				{
					dataRow[18] = true;
				}
				if ((oraType == OraType.ORA_NDT && m_pOpoMetValCtx->pColMetaVal[i].bIsXmlType == 0) || oraType == OraType.ORA_OCIRef)
				{
					dataRow[20] = GetCachedOracleUdtDescriptor(i).UdtTypeName;
				}
				m_dataTable.Rows.Add(dataRow);
			}
			m_dataTable.AcceptChanges();
		}
		DataTable result = m_dataTable.Copy();
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetSchemaTable()\n");
		}
		return result;
	}

	public unsafe override string GetString(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetString()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (m_external && oraType != OraType.ORA_CHAR && oraType != OraType.ORA_CHARN && oraType != OraType.ORA_LONG && oraType != OraType.ORA_OCIRowid && oraType != OraType.ORA_OCICLobLocator && (oraType != OraType.ORA_NDT || m_pOpoMetValCtx->pColMetaVal[i].bIsXmlType == 0) && oraType != OraType.ORA_OCIRef)
		{
			throw new InvalidCastException();
		}
		bool flag = true;
		if (m_pOpoMetValCtx->pColMetaVal[i].UCS2Character == 0)
		{
			flag = false;
		}
		long num2 = m_fetchArrayLocation + m_rowLocation + m_colIndOffset[i];
		short num3 = *(short*)num2;
		if (num3 == -1)
		{
			throw new InvalidCastException(OpoErrResManager.GetErrorMesg(ErrRes.DR_NULL_COL_DATA));
		}
		if (oraType == OraType.ORA_CHAR || oraType == OraType.ORA_CHARN || oraType == OraType.ORA_OCIRowid)
		{
			long num4 = m_fetchArrayLocation + m_rowLocation;
			num2 = num4 + m_colLenOffset[i];
			ushort num5 = *(ushort*)num2;
			IntPtr intPtr = (IntPtr)(num4 + m_colOffset[i]);
			if (flag)
			{
				if (m_connection.ConnectionType == OracleConnectionType.TimesTen && m_pOpoMetValCtx->pColMetaVal[i].Define.Type == 94)
				{
					int num6 = *(int*)num2;
					intPtr = (IntPtr)(num4 + m_colOffset[i] + 4);
					return Marshal.PtrToStringUni(intPtr, num6 / 2);
				}
				if (m_connection.ConnectionType == OracleConnectionType.TimesTen && m_pOpoMetValCtx->pColMetaVal[i].Define.Type == 5)
				{
					return Marshal.PtrToStringUni(intPtr);
				}
				return Marshal.PtrToStringUni(intPtr, (int)num5 / 2);
			}
			return OracleString.GetValue(intPtr, num5, isUnicode: false);
		}
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		if (oraType == OraType.ORA_NDT && m_pOpoMetValCtx->pColMetaVal[i].bIsXmlType == 1)
		{
			if (m_opsXmlTypeCtx == null)
			{
				m_opsXmlTypeCtx = new IntPtr[m_fieldCount];
			}
			else if (m_opsXmlTypeCtx[i] != IntPtr.Zero)
			{
				IntPtr opsXmlStreamValueBuffer = IntPtr.Zero;
				int numCharsInBuffer = 0;
				string result = null;
				try
				{
					num = OpsXmlStream.GetValueBuffer(m_opsConCtx, m_opsErrCtx, m_opsXmlTypeCtx[i], ref opsXmlStreamValueBuffer, ref numCharsInBuffer);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					throw;
				}
				if (num == 0)
				{
					result = Marshal.PtrToStringUni(opsXmlStreamValueBuffer, numCharsInBuffer);
					try
					{
						num = OpsXmlStream.FreeValueBuffer(ref opsXmlStreamValueBuffer);
					}
					catch (Exception ex2)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex2);
						}
					}
				}
				if (num != 0)
				{
					OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
				}
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetString()\n");
				return result;
			}
		}
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		string text = null;
		GCHandle gCHandle = default(GCHandle);
		bool flag2;
		if ((oraType == OraType.ORA_LONG && InitialLONGFetchSize != -1) || (oraType == OraType.ORA_OCICLobLocator && InitialLOBFetchSize != -1))
		{
			try
			{
				num = OpsDac.GetLen(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx);
			}
			catch (Exception ex3)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex3);
				}
				throw;
			}
			if ((oraType == OraType.ORA_LONG || (oraType == OraType.ORA_OCICLobLocator && m_pOpoDacValCtx->InitialLobFS > 0 && !m_isDBVer10gR2OrHigher)) && !m_pkFetched)
			{
				UpdateMetaDataPool();
			}
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
			if (m_pOpoDacValCtx->Indicator == -1)
			{
				throw new InvalidCastException(OpoErrResManager.GetErrorMesg(ErrRes.DR_NULL_COL_DATA));
			}
			if (((oraType != OraType.ORA_LONG || m_pOpoDacValCtx->RetDataLen / 2 > m_pOpoDacValCtx->InitialLongFS) && (oraType != OraType.ORA_OCICLobLocator || m_pOpoDacValCtx->InitialLobFS <= 0 || m_pOpoDacValCtx->RetDataLen / 2 > m_pOpoDacValCtx->InitialLobFS)) || (oraType == OraType.ORA_OCICLobLocator && m_pOpoDacValCtx->InitialLobFS > 0 && m_pOpoDacValCtx->RetDataLen / 2 > m_pOpoDacValCtx->InitialLobFS && m_isDBVer10gR2OrHigher))
			{
				flag2 = false;
				text = new string('\0', m_pOpoDacValCtx->RetDataLen / 2);
				gCHandle = GCHandle.Alloc(text, GCHandleType.Pinned);
				m_pOpoDacValCtx->pBuffer = gCHandle.AddrOfPinnedObject();
				m_pOpoDacValCtx->BufLen = m_pOpoDacValCtx->RetDataLen;
			}
			else
			{
				flag2 = true;
				m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
				m_pOpoDacValCtx->BufLen = m_pOpoDacValCtx->RetDataLen;
			}
		}
		else
		{
			flag2 = true;
			m_pOpoDacValCtx->BufLen = 0;
		}
		OpoUdtCtx opoUdtCtx = null;
		if (oraType == OraType.ORA_NDT && m_pOpoMetValCtx->pColMetaVal[i].bIsXmlType == 0)
		{
			return GetCustomObject(i).ToString();
		}
		if (opoUdtCtx == null)
		{
			try
			{
				num = OpsDac.GetType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, 0);
			}
			catch (Exception ex4)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex4);
				}
				num = ErrRes.INT_ERR;
				throw;
			}
			finally
			{
				if (num != ErrRes.INT_ERR && (oraType == OraType.ORA_LONG || (oraType == OraType.ORA_OCICLobLocator && m_pOpoDacValCtx->InitialLobFS > 0 && !m_isDBVer10gR2OrHigher)) && !m_pkFetched)
				{
					UpdateMetaDataPool();
				}
				if (!flag2 && gCHandle.IsAllocated)
				{
					gCHandle.Free();
				}
			}
		}
		if (num != 0)
		{
			OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
		}
		if (m_pOpoDacValCtx->Indicator == -1)
		{
			throw new InvalidCastException(OpoErrResManager.GetErrorMesg(ErrRes.DR_NULL_COL_DATA));
		}
		if (oraType == OraType.ORA_NDT || oraType == OraType.ORA_OCIRef)
		{
			if (m_pOpoMetValCtx->pColMetaVal[i].bIsXmlType == 1)
			{
				IntPtr intPtr2 = (IntPtr)m_pOpoDacValCtx->pValCtx;
				IntPtr opsXmlStreamValueBuffer2 = IntPtr.Zero;
				int numCharsInBuffer2 = 0;
				string result2 = null;
				m_opsXmlTypeCtx[i] = intPtr2;
				m_pOpoDacValCtx->pValCtx = null;
				try
				{
					num = OpsXmlStream.GetValueBuffer(m_opsConCtx, m_opsErrCtx, intPtr2, ref opsXmlStreamValueBuffer2, ref numCharsInBuffer2);
				}
				catch (Exception ex5)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex5);
					}
					throw;
				}
				if (num == 0)
				{
					result2 = Marshal.PtrToStringUni(opsXmlStreamValueBuffer2, numCharsInBuffer2);
					try
					{
						num = OpsXmlStream.FreeValueBuffer(ref opsXmlStreamValueBuffer2);
					}
					catch (Exception ex6)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex6);
						}
					}
				}
				if (num != 0)
				{
					OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
				}
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetString()\n");
				return result2;
			}
			OracleUdtDescriptor cachedOracleUdtDescriptor = GetCachedOracleUdtDescriptor(i);
			if (oraType == OraType.ORA_OCIRef)
			{
				OracleRef oracleRef = null;
				if (!m_fillReader && m_pOpoDacValCtx->Indicator == 0 && m_pOpoDacValCtx->pBuffer == IntPtr.Zero)
				{
					oracleRef = (OracleRef)m_currentRowUdtCache[i];
				}
				else
				{
					if (opoUdtCtx == null)
					{
						opoUdtCtx = new OpoUdtCtx(m_opsConCtx, IntPtr.Zero, m_pOpoDacValCtx->pBuffer, m_pOpoDacValCtx->pUdtNullStruct);
					}
					oracleRef = ((m_pOpoMetValCtx->pColMetaVal[i].bIsFinalType != 0) ? new OracleRef(cachedOracleUdtDescriptor, opoUdtCtx) : new OracleRef(m_connection, opoUdtCtx));
					if (!m_fillReader)
					{
						m_currentRowUdtCache[i] = oracleRef;
						oracleRef.m_bNotRefByApp = true;
					}
				}
				string value = oracleRef.Value;
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetString()\n");
				}
				return value;
			}
		}
		m_pOpoDacValCtx->RetDataLen /= 2;
		if (flag2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetString()\n");
			}
			if (flag)
			{
				if (m_pOpoDacValCtx->pBuffer != IntPtr.Zero)
				{
					return Marshal.PtrToStringUni(m_pOpoDacValCtx->pBuffer, m_pOpoDacValCtx->RetDataLen);
				}
				return null;
			}
			return OracleString.GetValue(m_pOpoDacValCtx->pBuffer, m_pOpoDacValCtx->RetDataLen, isUnicode: false);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetString()\n");
		}
		return text;
	}

	public unsafe TimeSpan GetTimeSpan(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetTimeSpan()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		if (oraType != OraType.ORA_INTERVAL_DS)
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		long num2 = m_fetchArrayLocation + m_rowLocation + m_colIndOffset[i];
		short num3 = *(short*)num2;
		if (num3 == -1)
		{
			throw new InvalidCastException(OpoErrResManager.GetErrorMesg(ErrRes.DR_NULL_COL_DATA));
		}
		long num4 = m_fetchArrayLocation + m_rowLocation;
		IntPtr pBuffer = (IntPtr)(num4 + m_colOffset[i]);
		m_pOpoDacValCtx->pBuffer = pBuffer;
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		try
		{
			num = OpsDac.GetType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, 1);
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
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetTimeSpan()\n");
		}
		return TimeSpanConv.GetTimeSpan((OpoITLValCtx*)m_pOpoDacValCtx->pValCtx, OracleDbType.IntervalDS);
	}

	public unsafe override object GetValue(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetValue()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		OraType oraType = m_oraType[i];
		object obj = null;
		try
		{
			m_external = false;
			if (oraType == OraType.ORA_OCIRef || oraType == OraType.ORA_NDT || oraType == OraType.ORA_NDT)
			{
				if (IsDBNull(i))
				{
					return DBNull.Value;
				}
			}
			else
			{
				long num = m_fetchArrayLocation + m_rowLocation + m_colIndOffset[i];
				short num2 = *(short*)num;
				if (num2 == -1)
				{
					return DBNull.Value;
				}
			}
			switch (oraType)
			{
			case OraType.ORA_CHARN:
			case OraType.ORA_LONG:
			case OraType.ORA_CHAR:
			case OraType.ORA_OCIRowid:
			case OraType.ORA_OCICLobLocator:
				obj = GetString(i);
				break;
			case OraType.ORA_NDT:
				obj = (((oraType != OraType.ORA_NDT || m_pOpoMetValCtx->pColMetaVal[i].bIsXmlType == 1) && oraType != OraType.ORA_OCIRef) ? GetString(i) : GetCustomObject(i));
				break;
			case OraType.ORA_OCIRef:
				obj = GetString(i);
				break;
			case OraType.ORA_NUMBER:
				if (m_safeMapping != null && m_safeMapping.Count > 0)
				{
					Type type3 = (Type)m_safeMapping[m_colMetaRef[i].pColAlias];
					if (type3 == null)
					{
						type3 = (Type)m_safeMapping["*"];
					}
					if (type3 == typeof(string))
					{
						obj = GetOracleDecimal(i).ToString();
					}
					else if (type3 == typeof(byte[]))
					{
						obj = GetOracleDecimal(i).BinData;
					}
				}
				if (obj == null)
				{
					switch (m_dotNetNumericAccessor[i])
					{
					case DotNetNumericAccessor.GetDecimal:
						obj = GetDecimal(i);
						break;
					case DotNetNumericAccessor.GetDouble:
						obj = GetDouble(i);
						break;
					case DotNetNumericAccessor.GetFloat:
						obj = GetFloat(i);
						break;
					case DotNetNumericAccessor.GetInt16:
						obj = GetInt16(i);
						break;
					case DotNetNumericAccessor.GetInt32:
						obj = GetInt32(i);
						break;
					case DotNetNumericAccessor.GetInt64:
						obj = GetInt64(i);
						break;
					}
				}
				break;
			case OraType.ORA_IBDOUBLE:
				obj = GetDouble(i);
				break;
			case OraType.ORA_IBFLOAT:
				obj = GetFloat(i);
				break;
			case OraType.ORA_RAW:
			case OraType.ORA_LONGRAW:
			case OraType.ORA_OCIBLobLocator:
			case OraType.ORA_OCIBFileLocator:
			{
				long bytes = GetBytes(i, 0L, null, 0, 0);
				byte[] array = new byte[bytes];
				GetBytes(i, 0L, array, 0, (int)bytes);
				obj = array;
				break;
			}
			case OraType.ORA_DATE:
			case OraType.ORA_TIMESTAMP:
			case OraType.ORA_TIMESTAMP_TZ:
			case OraType.ORA_TIMESTAMP_LTZ:
			{
				if (!m_isFromEF || !(m_expectedColumnTypes[i].ClrEquivalentType == typeof(DateTimeOffset)))
				{
					if (m_safeMapping != null && m_safeMapping.Count > 0)
					{
						Type type2 = (Type)m_safeMapping[m_colMetaRef[i].pColAlias];
						if (type2 == null)
						{
							type2 = (Type)m_safeMapping["*"];
						}
						if (type2 == typeof(string))
						{
							switch (oraType)
							{
							case OraType.ORA_DATE:
								obj = GetOracleDate(i).ToString();
								break;
							case OraType.ORA_TIMESTAMP:
								obj = GetOracleTimeStamp(i).ToString();
								break;
							case OraType.ORA_TIMESTAMP_LTZ:
								obj = GetOracleTimeStampLTZ(i).ToString();
								break;
							case OraType.ORA_TIMESTAMP_TZ:
								obj = GetOracleTimeStampTZ(i).ToString();
								break;
							}
						}
						else if (type2 == typeof(byte[]))
						{
							switch (oraType)
							{
							case OraType.ORA_DATE:
								obj = GetOracleDate(i).BinData;
								break;
							case OraType.ORA_TIMESTAMP:
								obj = GetOracleTimeStamp(i).BinData;
								break;
							case OraType.ORA_TIMESTAMP_LTZ:
								obj = GetOracleTimeStampLTZ(i).BinData;
								break;
							case OraType.ORA_TIMESTAMP_TZ:
								obj = GetOracleTimeStampTZ(i).BinData;
								break;
							}
						}
					}
					if (obj == null)
					{
						obj = GetDateTime(i);
					}
					break;
				}
				OracleTimeStampTZ oracleTimeStampTZ = oraType switch
				{
					OraType.ORA_TIMESTAMP_TZ => GetOracleTimeStampTZ(i), 
					OraType.ORA_TIMESTAMP_LTZ => GetOracleTimeStampLTZ(i).ToOracleTimeStampTZ(), 
					OraType.ORA_TIMESTAMP => GetOracleTimeStamp(i).ToOracleTimeStampTZ(), 
					_ => GetOracleDate(i).ToOracleTimeStamp().ToOracleTimeStampTZ(), 
				};
				return new DateTimeOffset(oracleTimeStampTZ.Value, oracleTimeStampTZ.GetTimeZoneOffset());
			}
			case OraType.ORA_INTERVAL_DS:
				if (m_safeMapping != null && m_safeMapping.Count > 0)
				{
					Type type = (Type)m_safeMapping[m_colMetaRef[i].pColAlias];
					if (type == null)
					{
						type = (Type)m_safeMapping["*"];
					}
					if (type == typeof(string))
					{
						obj = GetOracleIntervalDS(i).ToString();
					}
					else if (type == typeof(byte[]))
					{
						obj = GetOracleIntervalDS(i).BinData;
					}
				}
				if (obj == null)
				{
					obj = GetTimeSpan(i);
				}
				break;
			case OraType.ORA_INTERVAL_YM:
				obj = GetInt64(i);
				break;
			}
		}
		finally
		{
			m_external = true;
		}
		if (m_isFromEF && m_expectedColumnTypes != null && obj.GetType() != m_expectedColumnTypes[i].ClrEquivalentType)
		{
			obj = ChangeType(obj, m_expectedColumnTypes[i].ClrEquivalentType);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetValue()\n");
		}
		return obj;
	}

	public unsafe override int GetValues(object[] values)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetValues()\n");
		}
		if (m_closed || m_bBOF || m_bEOF)
		{
			throw new InvalidOperationException();
		}
		int num = values.Length;
		int num2 = 0;
		long num3 = 0L;
		short num4 = 0;
		long num5 = 0L;
		IntPtr zero = IntPtr.Zero;
		num2 = ((num >= m_fieldCount) ? m_fieldCount : num);
		if (!IsFillReader || m_pColumnsDataBuffer == IntPtr.Zero)
		{
			try
			{
				m_external = false;
				for (int i = 0; i < num2; i++)
				{
					values[i] = GetValue(i);
				}
			}
			finally
			{
				m_external = true;
			}
		}
		else
		{
			try
			{
				m_external = false;
				for (int j = 0; j < num2; j++)
				{
					OraType oraType = m_oraType[j];
					object obj = null;
					if (oraType == OraType.ORA_OCIRef || oraType == OraType.ORA_NDT || oraType == OraType.ORA_NDT)
					{
						if (IsDBNull(j))
						{
							values[j] = DBNull.Value;
							continue;
						}
					}
					else
					{
						num5 = m_fetchArrayLocation + m_rowLocation;
						num3 = num5 + m_colIndOffset[j];
						num4 = *(short*)num3;
						if (num4 == -1)
						{
							values[j] = DBNull.Value;
							continue;
						}
					}
					switch (oraType)
					{
					case OraType.ORA_CHARN:
					case OraType.ORA_CHAR:
					case OraType.ORA_OCIRowid:
					{
						num5 = m_fetchArrayLocation + m_rowLocation;
						num3 = num5 + m_colIndOffset[j];
						num4 = *(short*)num3;
						if (num4 == -1)
						{
							values[j] = DBNull.Value;
							break;
						}
						num3 = num5 + m_colLenOffset[j];
						short num7 = *(short*)num3;
						IntPtr ptr5 = (IntPtr)(num5 + m_colOffset[j]);
						values[j] = Marshal.PtrToStringUni(ptr5, num7 / 2);
						break;
					}
					case OraType.ORA_LONG:
					case OraType.ORA_OCICLobLocator:
						num5 = m_fetchArrayLocation + m_rowLocation;
						num3 = num5 + m_colIndOffset[j];
						num4 = *(short*)num3;
						if (num4 == -1)
						{
							values[j] = DBNull.Value;
						}
						else
						{
							values[j] = GetString(j);
						}
						break;
					case OraType.ORA_NDT:
						if ((oraType == OraType.ORA_NDT && m_pOpoMetValCtx->pColMetaVal[j].bIsXmlType != 1) || oraType == OraType.ORA_OCIRef)
						{
							values[j] = GetCustomObject(j);
						}
						else
						{
							values[j] = GetString(j);
						}
						break;
					case OraType.ORA_OCIRef:
						values[j] = GetString(j);
						break;
					case OraType.ORA_NUMBER:
						if (m_safeMapping != null && m_safeMapping.Count > 0)
						{
							Type type3 = (Type)m_safeMapping[m_colMetaRef[j].pColAlias];
							if (type3 == null)
							{
								type3 = (Type)m_safeMapping["*"];
							}
							if (type3 == typeof(string))
							{
								obj = GetOracleDecimal(j).ToString();
							}
							else if (type3 == typeof(byte[]))
							{
								obj = GetOracleDecimal(j).BinData;
							}
						}
						if (obj != null)
						{
							values[j] = obj;
							break;
						}
						switch (m_dotNetNumericAccessor[j])
						{
						case DotNetNumericAccessor.GetDecimal:
							num5 = m_fetchArrayLocation + m_rowLocation;
							num3 = num5 + m_colIndOffset[j];
							num4 = *(short*)num3;
							if (num4 == -1)
							{
								values[j] = DBNull.Value;
								break;
							}
							zero = (IntPtr)(num5 + m_colOffset[j]);
							values[j] = DecimalConv.GetDecimal(zero);
							break;
						case DotNetNumericAccessor.GetDouble:
							num3 = m_fetchArrayLocation + m_rowLocation + m_colIndOffset[j];
							if (*(short*)num3 == -1)
							{
								values[j] = DBNull.Value;
							}
							else
							{
								values[j] = *(double*)((byte*)(void*)m_pColumnsDataBuffer + (int)m_colDatOffset[j] + (m_currentClientRow - 1) % m_pOpoDacValCtx->FetchSize * m_colDatSize[j]);
							}
							break;
						case DotNetNumericAccessor.GetFloat:
							num3 = m_fetchArrayLocation + m_rowLocation + m_colIndOffset[j];
							if (*(short*)num3 == -1)
							{
								values[j] = DBNull.Value;
							}
							else
							{
								values[j] = (float)(*(double*)((byte*)(void*)m_pColumnsDataBuffer + (int)m_colDatOffset[j] + (m_currentClientRow - 1) % m_pOpoDacValCtx->FetchSize * m_colDatSize[j]));
							}
							break;
						case DotNetNumericAccessor.GetInt16:
							num3 = m_fetchArrayLocation + m_rowLocation + m_colIndOffset[j];
							if (*(short*)num3 == -1)
							{
								values[j] = DBNull.Value;
							}
							else
							{
								values[j] = *(short*)((byte*)(void*)m_pColumnsDataBuffer + (int)m_colDatOffset[j] + (m_currentClientRow - 1) % m_pOpoDacValCtx->FetchSize * m_colDatSize[j]);
							}
							break;
						case DotNetNumericAccessor.GetInt32:
							num3 = m_fetchArrayLocation + m_rowLocation + m_colIndOffset[j];
							if (*(short*)num3 == -1)
							{
								values[j] = DBNull.Value;
							}
							else
							{
								values[j] = *(int*)((byte*)(void*)m_pColumnsDataBuffer + (int)m_colDatOffset[j] + (m_currentClientRow - 1) % m_pOpoDacValCtx->FetchSize * m_colDatSize[j]);
							}
							break;
						case DotNetNumericAccessor.GetInt64:
							num3 = m_fetchArrayLocation + m_rowLocation + m_colIndOffset[j];
							if (*(short*)num3 == -1)
							{
								values[j] = DBNull.Value;
							}
							else
							{
								values[j] = *(long*)((byte*)(void*)m_pColumnsDataBuffer + (int)m_colDatOffset[j] + (m_currentClientRow - 1) % m_pOpoDacValCtx->FetchSize * m_colDatSize[j]);
							}
							break;
						}
						break;
					case OraType.ORA_IBDOUBLE:
						num5 = m_fetchArrayLocation + m_rowLocation;
						num3 = num5 + m_colIndOffset[j];
						num4 = *(short*)num3;
						if (num4 == -1)
						{
							values[j] = DBNull.Value;
							break;
						}
						zero = (IntPtr)(num5 + m_colOffset[j]);
						values[j] = *(double*)(void*)zero;
						break;
					case OraType.ORA_IBFLOAT:
						num5 = m_fetchArrayLocation + m_rowLocation;
						num3 = num5 + m_colIndOffset[j];
						num4 = *(short*)num3;
						if (num4 == -1)
						{
							values[j] = DBNull.Value;
							break;
						}
						zero = (IntPtr)(num5 + m_colOffset[j]);
						values[j] = *(float*)(void*)zero;
						break;
					case OraType.ORA_RAW:
					case OraType.ORA_LONGRAW:
					case OraType.ORA_OCIBLobLocator:
					case OraType.ORA_OCIBFileLocator:
					{
						num5 = m_fetchArrayLocation + m_rowLocation;
						num3 = num5 + m_colIndOffset[j];
						num4 = *(short*)num3;
						if (num4 == -1)
						{
							values[j] = DBNull.Value;
							break;
						}
						long bytes = GetBytes(j, 0L, null, 0, 0);
						byte[] array = new byte[bytes];
						GetBytes(j, 0L, array, 0, (int)bytes);
						values[j] = array;
						break;
					}
					case OraType.ORA_DATE:
					case OraType.ORA_TIMESTAMP:
					case OraType.ORA_TIMESTAMP_TZ:
					case OraType.ORA_TIMESTAMP_LTZ:
						if (m_safeMapping != null && m_safeMapping.Count > 0)
						{
							Type type = (Type)m_safeMapping[m_colMetaRef[j].pColAlias];
							if (type == null)
							{
								type = (Type)m_safeMapping["*"];
							}
							if (type == typeof(string))
							{
								switch (oraType)
								{
								case OraType.ORA_DATE:
									obj = GetOracleDate(j).ToString();
									break;
								case OraType.ORA_TIMESTAMP:
									obj = GetOracleTimeStamp(j).ToString();
									break;
								case OraType.ORA_TIMESTAMP_LTZ:
									obj = GetOracleTimeStampLTZ(j).ToString();
									break;
								case OraType.ORA_TIMESTAMP_TZ:
									obj = GetOracleTimeStampTZ(j).ToString();
									break;
								}
							}
							else if (type == typeof(byte[]))
							{
								switch (oraType)
								{
								case OraType.ORA_DATE:
									obj = GetOracleDate(j).BinData;
									break;
								case OraType.ORA_TIMESTAMP:
									obj = GetOracleTimeStamp(j).BinData;
									break;
								case OraType.ORA_TIMESTAMP_LTZ:
									obj = GetOracleTimeStampLTZ(j).BinData;
									break;
								case OraType.ORA_TIMESTAMP_TZ:
									obj = GetOracleTimeStampTZ(j).BinData;
									break;
								}
							}
						}
						if (obj != null)
						{
							values[j] = obj;
							break;
						}
						num5 = m_fetchArrayLocation + m_rowLocation;
						num3 = num5 + m_colIndOffset[j];
						num4 = *(short*)num3;
						if (num4 == -1)
						{
							values[j] = DBNull.Value;
							break;
						}
						switch (oraType)
						{
						case OraType.ORA_DATE:
						{
							zero = (IntPtr)(num5 + m_colOffset[j]);
							byte* ptr3 = (byte*)(void*)zero;
							int year = (*ptr3 - 100) * 100 + (ptr3[1] - 100);
							values[j] = new DateTime(year, ptr3[2], ptr3[3], ptr3[4] - 1, ptr3[5] - 1, ptr3[6] - 1);
							break;
						}
						case OraType.ORA_TIMESTAMP:
						case OraType.ORA_TIMESTAMP_TZ:
						case OraType.ORA_TIMESTAMP_LTZ:
						{
							OpoDatValCtx* ptr2 = (OpoDatValCtx*)((byte*)(void*)m_pColumnsDataBuffer + (int)m_colDatOffset[j] + (m_currentClientRow - 1) % m_pOpoDacValCtx->FetchSize * m_colDatSize[j]);
							DateTime dateTime = new DateTime(ptr2->m_year, ptr2->m_month, ptr2->m_day, ptr2->m_hour, ptr2->m_minute, ptr2->m_second);
							if (ptr2->m_fSecond > 0)
							{
								values[j] = dateTime.AddTicks(ptr2->m_fSecond / 100);
							}
							else
							{
								values[j] = dateTime;
							}
							break;
						}
						}
						break;
					case OraType.ORA_INTERVAL_DS:
					{
						if (m_safeMapping != null && m_safeMapping.Count > 0)
						{
							Type type2 = (Type)m_safeMapping[m_colMetaRef[j].pColAlias];
							if (type2 == null)
							{
								type2 = (Type)m_safeMapping["*"];
							}
							if (type2 == typeof(string))
							{
								obj = GetOracleIntervalDS(j).ToString();
							}
							else if (type2 == typeof(byte[]))
							{
								obj = GetOracleIntervalDS(j).BinData;
							}
						}
						if (obj != null)
						{
							values[j] = obj;
							break;
						}
						num5 = m_fetchArrayLocation + m_rowLocation;
						num3 = num5 + m_colIndOffset[j];
						num4 = *(short*)num3;
						if (num4 == -1)
						{
							values[j] = DBNull.Value;
							break;
						}
						zero = (IntPtr)(num5 + m_colOffset[j]);
						IDSCtx* ptr4 = (IDSCtx*)((byte*)(void*)m_pColumnsDataBuffer + (int)m_colDatOffset[j] + (m_currentClientRow - 1) % m_pOpoDacValCtx->FetchSize * m_colDatSize[j]);
						if (Math.Abs(ptr4->m_fSeconds) % 100 > 0)
						{
							throw new OracleTypeException(ErrRes.TYP_GETDOTNETTYPE_FAIL);
						}
						decimal num6 = (decimal)ptr4->m_days * 864000000000m + (decimal)(ptr4->m_hours * 36000000000L) + (decimal)((long)ptr4->m_minutes * 600000000L) + (decimal)((long)ptr4->m_seconds * 10000000L) + (decimal)ptr4->m_fSeconds * 0.01m;
						if (num6 < -9223372036854775808m || num6 > 9223372036854775807m)
						{
							throw new OracleTypeException(ErrRes.TYP_GETDOTNETTYPE_FAIL);
						}
						values[j] = new TimeSpan((long)num6);
						break;
					}
					case OraType.ORA_INTERVAL_YM:
					{
						num5 = m_fetchArrayLocation + m_rowLocation;
						num3 = num5 + m_colIndOffset[j];
						num4 = *(short*)num3;
						if (num4 == -1)
						{
							values[j] = DBNull.Value;
							break;
						}
						long* ptr = (long*)((byte*)(void*)m_pColumnsDataBuffer + (int)m_colDatOffset[j] + (m_currentClientRow - 1) % m_pOpoDacValCtx->FetchSize * m_colDatSize[j]);
						values[j] = *ptr;
						break;
					}
					}
				}
			}
			finally
			{
				m_external = true;
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetValues()\n");
		}
		return num2;
	}

	public unsafe XmlReader GetXmlReader(int i)
	{
		OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetXmlReader()\n");
		if (m_closed || m_bBOF || m_bEOF)
		{
			throw new InvalidOperationException();
		}
		string s = null;
		if (i >= m_fieldCount || i < 0)
		{
			throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
		}
		int num = 0;
		OraType oraType = m_oraType[i];
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		if (oraType != OraType.ORA_NDT || m_pOpoMetValCtx->pColMetaVal[i].bIsXmlType != 1)
		{
			throw new InvalidCastException();
		}
		if (m_opsXmlTypeCtx == null)
		{
			m_opsXmlTypeCtx = new IntPtr[m_fieldCount];
		}
		if (m_opsXmlTypeCtx[i] != IntPtr.Zero)
		{
			IntPtr opsXmlStreamValueBuffer = IntPtr.Zero;
			int numCharsInBuffer = 0;
			try
			{
				num = OpsXmlStream.GetValueBuffer(m_opsConCtx, m_opsErrCtx, m_opsXmlTypeCtx[i], ref opsXmlStreamValueBuffer, ref numCharsInBuffer);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			if (num == 0)
			{
				s = Marshal.PtrToStringUni(opsXmlStreamValueBuffer, numCharsInBuffer);
				try
				{
					num = OpsXmlStream.FreeValueBuffer(ref opsXmlStreamValueBuffer);
				}
				catch (Exception ex2)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex2);
					}
				}
			}
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		else
		{
			m_pOpoDacValCtx->Ordinal = i;
			m_pOpoDacValCtx->FieldOffset = 0L;
			m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
			m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
			m_pOpoDacValCtx->BufLen = 0;
			m_pOpoDacValCtx->FieldOffset = 0L;
			try
			{
				num = OpsDac.GetType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, 0);
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
			if (m_pOpoDacValCtx->Indicator == -1)
			{
				throw new InvalidCastException(OpoErrResManager.GetErrorMesg(ErrRes.DR_NULL_COL_DATA));
			}
			IntPtr intPtr = (IntPtr)m_pOpoDacValCtx->pValCtx;
			m_pOpoDacValCtx->pValCtx = null;
			IntPtr opsXmlStreamValueBuffer2 = IntPtr.Zero;
			int numCharsInBuffer2 = 0;
			m_opsXmlTypeCtx[i] = intPtr;
			try
			{
				num = OpsXmlStream.GetValueBuffer(m_opsConCtx, m_opsErrCtx, intPtr, ref opsXmlStreamValueBuffer2, ref numCharsInBuffer2);
			}
			catch (Exception ex4)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex4);
				}
				throw;
			}
			if (num == 0)
			{
				s = Marshal.PtrToStringUni(opsXmlStreamValueBuffer2, numCharsInBuffer2);
				try
				{
					num = OpsXmlStream.FreeValueBuffer(ref opsXmlStreamValueBuffer2);
				}
				catch (Exception ex5)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex5);
					}
				}
			}
			if (num != 0)
			{
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		TextReader input = new StringReader(s);
		XmlReader result = new XmlTextReader(input);
		OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetXmlReader()\n");
		return result;
	}

	public unsafe override bool IsDBNull(int i)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::IsDBNull()\n");
		}
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		OraType oraType = m_oraType[i];
		if (oraType == OraType.ORA_OCIRef || oraType == OraType.ORA_NDT || oraType == OraType.ORA_NDT)
		{
			int num = 0;
			m_pOpoDacValCtx->Ordinal = i;
			m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
			try
			{
				num = OpsDac.GetInd(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx);
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
			if (m_pOpoDacValCtx->Indicator == -1)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleDataReader::IsDBNull()\n");
				}
				return true;
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::IsDBNull()\n");
			}
			return false;
		}
		long num2 = m_fetchArrayLocation + m_rowLocation + m_colIndOffset[i];
		short num3 = *(short*)num2;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::IsDBNull()\n");
		}
		return num3 == -1;
	}

	public unsafe override bool NextResult()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::NextResult()\n");
		}
		if (m_closed)
		{
			throw new InvalidOperationException();
		}
		int num = 0;
		if (m_refCursor != null && !m_fillReader)
		{
			m_refCursor.m_state = OraRefCursorState.Closed;
		}
		if (m_currentResultIndex == m_resultCount - 1 || m_opsSqlCtx == null || (m_commandBehavior & CommandBehavior.SingleResult) == CommandBehavior.SingleResult)
		{
			if (!m_noMoreResults && !m_fillReader)
			{
				if (m_pOpoSqlValCtx != null && m_pOpoSqlValCtx->bPooledFetchArray == 1)
				{
					m_fetchArrayPooler.PutFetchArray((IntPtr)m_fetchArrayLocation);
					m_fetchArrayLocation = 0L;
					m_pOpoSqlValCtx->FetchArrayLocation = IntPtr.Zero;
				}
				if (m_opsSqlCtx == null)
				{
					try
					{
						OpsDac.Dispose(m_opsConCtx, m_opsErrCtx, IntPtr.Zero, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, m_pOpoSqlValCtx, 1);
						m_opsErrCtx = IntPtr.Zero;
					}
					catch (Exception ex)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex);
						}
					}
				}
				else
				{
					try
					{
						if (m_freeOpsSqlCtx == 1)
						{
							OpsDac.Dispose(m_opsConCtx, m_opsErrCtx, m_opsSqlCtx[m_currentResultIndex], m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, m_pOpoSqlValCtx, 1);
						}
						else
						{
							OpsDac.Dispose(m_opsConCtx, m_opsErrCtx, IntPtr.Zero, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, m_pOpoSqlValCtx, 1);
						}
						m_opsErrCtx = IntPtr.Zero;
						ref IntPtr reference = ref m_opsSqlCtx[m_currentResultIndex];
						reference = IntPtr.Zero;
					}
					catch (Exception ex2)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex2);
						}
					}
					if (m_opsSqlCtx[m_currentResultIndex] != IntPtr.Zero)
					{
						try
						{
							if (m_freeOpsSqlCtx == 1)
							{
								if (m_pOpoSqlValCtx->CommandType == 1)
								{
									if (m_pOpoSqlValCtx->AddToStmtCache == 0)
									{
										OpsSql.FreeCtx(ref m_opsSqlCtx[m_currentResultIndex], m_opsErrCtx, 0);
									}
									else
									{
										OpsSql.FreeCtx(ref m_opsSqlCtx[m_currentResultIndex], m_opsErrCtx, 1);
									}
								}
								else
								{
									OpsSql.FreeCtx(ref m_opsSqlCtx[m_currentResultIndex], m_opsErrCtx, 0);
								}
							}
						}
						catch (Exception ex3)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex3);
							}
						}
						ref IntPtr reference2 = ref m_opsSqlCtx[m_currentResultIndex];
						reference2 = IntPtr.Zero;
					}
					if ((m_commandBehavior & CommandBehavior.SingleResult) == CommandBehavior.SingleResult)
					{
						int num2 = 0;
						m_currentResultIndex++;
						for (num2 = m_currentResultIndex; num2 < m_resultCount; num2++)
						{
							if (!(m_opsSqlCtx[num2] != IntPtr.Zero))
							{
								continue;
							}
							try
							{
								if (m_pOpoSqlValCtx->CommandType == 1)
								{
									if (m_pOpoSqlValCtx->AddToStmtCache == 0)
									{
										OpsSql.FreeCtx(ref m_opsSqlCtx[num2], m_opsErrCtx, 0);
									}
									else
									{
										OpsSql.FreeCtx(ref m_opsSqlCtx[num2], m_opsErrCtx, 1);
									}
								}
								else
								{
									OpsSql.FreeCtx(ref m_opsSqlCtx[num2], m_opsErrCtx, 0);
								}
							}
							catch (Exception ex4)
							{
								if (OraTrace.m_TraceLevel != 0)
								{
									OraTrace.TraceExceptionInfo(ex4);
								}
							}
							ref IntPtr reference3 = ref m_opsSqlCtx[num2];
							reference3 = IntPtr.Zero;
						}
					}
				}
				if (m_opsErrCtx != IntPtr.Zero)
				{
					try
					{
						OpsErr.FreeCtx(ref m_opsErrCtx);
					}
					catch (Exception ex5)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex5);
						}
					}
					m_opsErrCtx = IntPtr.Zero;
				}
				m_pOpoSqlValCtx = null;
				m_pOpoDacValCtx = null;
				m_pOpoMetValCtx = null;
				m_pkFetched = false;
				m_doneMarshalAndStoreMetaData = false;
				m_bBOF = true;
				m_bEOF = true;
				m_bLastFetch = true;
				m_bSetLastFetch = true;
				m_opsErrCtx = IntPtr.Zero;
				m_opsDacCtx = IntPtr.Zero;
				m_colMetaRef = null;
				m_noMoreResults = true;
				m_metaData = null;
				m_expectedColumnTypes = null;
				m_isFromEF = false;
				m_colDatOffset = null;
				m_colDatSize = null;
				if (m_currentRowUdtCache != null)
				{
					for (int i = 0; i < m_currentRowUdtCache.Length; i++)
					{
						if (m_currentRowUdtCache[i] != null)
						{
							if (m_currentRowUdtCache[i] is OracleRef oracleRef && oracleRef.m_bNotRefByApp)
							{
								oracleRef.Dispose();
								OracleRef oracleRef2 = null;
							}
							m_currentRowUdtCache[i] = null;
						}
					}
					m_currentRowUdtCache = null;
				}
				m_udtDescriptorCache = null;
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::NextResult()\n");
			}
			return false;
		}
		if (m_pOpoSqlValCtx != null && m_pOpoSqlValCtx->bPooledFetchArray == 1)
		{
			m_fetchArrayPooler.PutFetchArray((IntPtr)m_fetchArrayLocation);
			m_fetchArrayLocation = 0L;
			m_pOpoSqlValCtx->FetchArrayLocation = IntPtr.Zero;
		}
		try
		{
			num = OpsDac.NextResult(m_connection.m_opoConCtx.opsConCtx, m_opsErrCtx, m_opsSqlCtx, m_opsDacCtx, m_pOpoSqlValCtx, ref m_pOpoMetValCtx, m_pOpoDacValCtx);
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
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
		m_recordCount = m_pOpoDacValCtx->RecordCount;
		ref IntPtr reference4 = ref m_opsSqlCtx[m_currentResultIndex];
		reference4 = IntPtr.Zero;
		m_metaData = new MetaData(m_pOpoMetValCtx, m_addRowid);
		try
		{
			OpsMet.AddRef(m_pOpoMetValCtx);
		}
		catch (Exception ex7)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex7);
			}
			throw;
		}
		if (m_pOpoMetValCtx != null)
		{
			m_rowSize = (int)m_pOpoMetValCtx->pColMetaVal[m_pOpoMetValCtx->NoOfCols - 1].Offset;
			m_fieldCount = m_pOpoMetValCtx->NoOfCols - m_pOpoMetValCtx->NoOfHiddenCols;
		}
		m_currentResultIndex++;
		m_pOpoDacValCtx->ResultsetIndex = m_currentResultIndex;
		m_pOpoDacValCtx->InitialLongFS = m_pOpoSqlValCtx->InitialLongFS;
		m_pOpoDacValCtx->InitialLobFS = m_pOpoSqlValCtx->InitialLobFS;
		m_opsDacCtx = IntPtr.Zero;
		m_bBOF = true;
		m_bEOF = false;
		m_bLastFetch = false;
		m_bSetLastFetch = false;
		m_colMetaRef = null;
		m_doneReadOne = false;
		m_hasRows = false;
		m_bHasRowsCalledBeforeRead = false;
		m_expectedColumnTypes = null;
		m_isFromEF = false;
		m_colDatOffset = null;
		m_colDatSize = null;
		m_bHasUdtType = false;
		if (m_pOpoMetValCtx != null)
		{
			m_bHasUdtType = m_pOpoMetValCtx->bHasUdtType == 1;
			m_colOffset = new uint[m_fieldCount];
			m_colIndOffset = new uint[m_fieldCount];
			m_colLenOffset = new uint[m_fieldCount];
			m_oraType = new OraType[m_fieldCount];
			m_oracleDbType = new OracleDbType[m_fieldCount];
			m_dotNetNumericAccessor = new DotNetNumericAccessor[m_fieldCount];
			for (int j = 0; j < m_fieldCount; j++)
			{
				m_colOffset[j] = 0u;
				if (j > 0)
				{
					m_colOffset[j] = m_pOpoMetValCtx->pColMetaVal[j - 1].Offset;
				}
				m_colIndOffset[j] = m_colOffset[j] + m_pOpoMetValCtx->pColMetaVal[j].Define.Length;
				m_colLenOffset[j] = m_colIndOffset[j] + 2;
				m_oraType[j] = (OraType)m_pOpoMetValCtx->pColMetaVal[j].OraType;
				m_oracleDbType[j] = GetOraDbTypeEx(j);
				int num3 = 0;
				int num4 = 0;
				num3 = m_pOpoMetValCtx->pColMetaVal[j].Scale;
				num4 = m_pOpoMetValCtx->pColMetaVal[j].Precision;
				if (num3 <= 0 && num4 - num3 < 5)
				{
					m_dotNetNumericAccessor[j] = DotNetNumericAccessor.GetInt16;
				}
				else if (num3 <= 0 && num4 - num3 < 10)
				{
					m_dotNetNumericAccessor[j] = DotNetNumericAccessor.GetInt32;
				}
				else if (num3 <= 0 && num4 - num3 < 19)
				{
					m_dotNetNumericAccessor[j] = DotNetNumericAccessor.GetInt64;
				}
				else if (num4 < 8 && ((num3 <= 0 && num4 - num3 <= 38) || (num3 > 0 && num3 <= 44)))
				{
					m_dotNetNumericAccessor[j] = DotNetNumericAccessor.GetFloat;
				}
				else if (num4 < 16)
				{
					m_dotNetNumericAccessor[j] = DotNetNumericAccessor.GetDouble;
				}
				else
				{
					m_dotNetNumericAccessor[j] = DotNetNumericAccessor.GetDecimal;
				}
			}
			m_pColumnsDataBuffer = IntPtr.Zero;
			m_currentClientRow = 0;
		}
		if (m_opsSqlCtx == null || m_pOpoMetValCtx == null || (m_commandBehavior & CommandBehavior.SchemaOnly) == CommandBehavior.SchemaOnly)
		{
			m_bSetLastFetch = true;
		}
		m_bCmdBehaviorSingleRow = (m_commandBehavior & CommandBehavior.SingleRow) == CommandBehavior.SingleRow;
		if (m_currentRowUdtCache != null)
		{
			for (int k = 0; k < m_currentRowUdtCache.Length; k++)
			{
				if (m_currentRowUdtCache[k] != null)
				{
					if (m_currentRowUdtCache[k] is OracleRef oracleRef3 && oracleRef3.m_bNotRefByApp)
					{
						oracleRef3.Dispose();
						OracleRef oracleRef4 = null;
					}
					m_currentRowUdtCache[k] = null;
				}
			}
			m_currentRowUdtCache = null;
		}
		m_udtDescriptorCache = null;
		if (m_dataTable != null)
		{
			m_dataTable.Dispose();
			m_dataTable = null;
		}
		if (m_fillReader)
		{
			DataTable minSchemaTable = GetMinSchemaTable();
			if (minSchemaTable != null)
			{
				m_dataTableList.Add(minSchemaTable);
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::NextResult()\n");
		}
		return true;
	}

	internal void GetDataOffsetsAndSizes(uint[] colDatOffset, uint[] colDatSize, int rows)
	{
		for (int i = 0; i < m_fieldCount; i++)
		{
			int num = 0;
			switch (m_oracleDbType[i])
			{
			case OracleDbType.Double:
			case OracleDbType.Single:
			case OracleDbType.BinaryDouble:
				num = 8;
				break;
			case OracleDbType.BinaryFloat:
				num = 4;
				break;
			case OracleDbType.Int16:
				num = 2;
				break;
			case OracleDbType.Int32:
				num = 4;
				break;
			case OracleDbType.Int64:
				num = 8;
				break;
			case OracleDbType.TimeStamp:
			case OracleDbType.TimeStampLTZ:
			case OracleDbType.TimeStampTZ:
				num = 20;
				break;
			case OracleDbType.IntervalDS:
				num = 20;
				break;
			case OracleDbType.IntervalYM:
				num = 8;
				break;
			}
			colDatOffset[i + 1] = (uint)(m_colDatOffset[i] + num * rows);
			colDatSize[i] = (uint)num;
		}
	}

	public unsafe override bool Read()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::Read()\n");
		}
		if (m_closed)
		{
			throw new InvalidOperationException();
		}
		if (m_bHasRowsCalledBeforeRead && m_currentClientRow == 0)
		{
			m_currentClientRow = 1;
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::Read()\n");
			}
			return true;
		}
		int num = 0;
		if (m_pOpoMetValCtx != null && m_bHasUdtType)
		{
			if (m_currentRowUdtCache == null)
			{
				if (!m_fillReader)
				{
					m_currentRowUdtCache = new object[m_pOpoMetValCtx->NoOfCols];
				}
				if (m_pOpoMetValCtx->bUdtInfoFetched == 0)
				{
					for (int i = 0; i < m_pOpoMetValCtx->NoOfCols; i++)
					{
						OraType oraType = (OraType)m_pOpoMetValCtx->pColMetaVal[i].OraType;
						if ((oraType == OraType.ORA_NDT && m_pOpoMetValCtx->pColMetaVal[i].bIsXmlType == 0) || oraType == OraType.ORA_OCIRef)
						{
							OracleUdtDescriptor cachedOracleUdtDescriptor = GetCachedOracleUdtDescriptor(i);
							m_pOpoMetValCtx->pColMetaVal[i].pOpsDscCtx = cachedOracleUdtDescriptor.m_opsDscCtx;
							m_pOpoMetValCtx->pColMetaVal[i].ociTypeCode = (int)cachedOracleUdtDescriptor.GetUdtTypeCode();
							OracleDbType oracleDbType = ((!cachedOracleUdtDescriptor.m_bSetOracleDbType) ? cachedOracleUdtDescriptor.OracleDbType : cachedOracleUdtDescriptor.m_oraDbType);
							if (oracleDbType != OracleDbType.Array && oraType == OraType.ORA_OCIRef)
							{
								m_pOpoMetValCtx->pColMetaVal[i].ociTypeCode = 110;
							}
							m_pOpoMetValCtx->pColMetaVal[i].bIsFinalType = cachedOracleUdtDescriptor.m_pOpoDscValCtx->bIsFinalType;
						}
					}
					m_pOpoMetValCtx->bUdtInfoFetched = 1;
				}
				if (m_pOpoDacValCtx->pOpoUdtValCtx == null)
				{
					try
					{
						OpsUdt.AllocValCtx(out m_pOpoDacValCtx->pOpoUdtValCtx, m_pOpoMetValCtx->NoOfCols);
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
				}
			}
			if (!m_fillReader)
			{
				for (int j = 0; j < m_pOpoMetValCtx->NoOfCols; j++)
				{
					if (m_currentRowUdtCache[j] is OracleRef oracleRef && oracleRef.m_bNotRefByApp)
					{
						oracleRef.Dispose();
						OracleRef oracleRef2 = null;
					}
					m_currentRowUdtCache[j] = null;
				}
			}
		}
		if (m_bSetLastFetch || (m_bCmdBehaviorSingleRow && m_currentClientRow > 0))
		{
			m_bLastFetch = true;
			m_bEOF = true;
			if (m_refCursor != null)
			{
				m_refCursor.m_state = OraRefCursorState.Closed;
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDataReader::Read()\n");
			}
			return false;
		}
		if (m_opsXmlTypeCtx != null)
		{
			try
			{
				int num2 = m_opsXmlTypeCtx.Length;
				for (int k = 0; k < num2; k++)
				{
					if (m_opsXmlTypeCtx[k] != IntPtr.Zero)
					{
						OpsXmlType.RelRef(m_opsConCtx, m_opsErrCtx, ref m_opsXmlTypeCtx[k], 1);
					}
				}
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
			}
			m_opsXmlTypeCtx = null;
		}
		if (m_currentClientRow == m_recordCount)
		{
			if (m_bLastFetch)
			{
				m_bEOF = true;
				if (m_refCursor != null)
				{
					m_refCursor.m_state = OraRefCursorState.Closed;
				}
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleDataReader::Read()\n");
				}
				return false;
			}
			if (m_currentClientRow == 0)
			{
				m_pOpoDacValCtx->FetchSize = m_fetchSize;
				if (m_fetchSize < m_rowSize || m_rowSize == 0)
				{
					m_pOpoDacValCtx->FetchSize = 1L;
					m_pOpoSqlValCtx->FetchSize = 1L;
				}
				else
				{
					m_pOpoSqlValCtx->FetchSize = (m_pOpoDacValCtx->FetchSize = m_fetchSize / m_rowSize);
				}
				if (m_pOpoDacValCtx->FetchSize >= 25 && m_fetchSize != 131072 && m_bFetchSizePropertySet)
				{
					m_pOpoDacValCtx->FetchSize++;
					m_pOpoSqlValCtx->FetchSize++;
				}
			}
			m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
			try
			{
				num = OpsDac.Read(m_opsConCtx, m_opsErrCtx, m_opsSqlCtx[m_currentResultIndex], ref m_opsDacCtx, m_pOpoSqlValCtx, m_pOpoMetValCtx, m_pOpoDacValCtx);
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
				m_doneReadOne = true;
				if (num != 0)
				{
					OracleException.HandleError(num, m_connection, m_opsErrCtx, this, bCheck: true);
				}
			}
			m_recordCount = m_pOpoDacValCtx->RecordCount;
			if (m_currentClientRow == 0)
			{
				m_fetchArrayLocation = (long)m_pOpoSqlValCtx->FetchArrayLocation;
			}
			if (m_recordCount < m_currentClientRow + m_pOpoDacValCtx->FetchSize)
			{
				m_bLastFetch = true;
				if (m_recordCount == m_currentClientRow)
				{
					m_bEOF = true;
					if (m_refCursor != null)
					{
						m_refCursor.m_state = OraRefCursorState.Closed;
					}
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(1u, " (EXIT)  OracleDataReader::Read()\n");
					}
					return false;
				}
			}
			m_bBOF = false;
			m_rowLocation = 0L;
			if (m_fillReader)
			{
				try
				{
					if (m_fillReader && m_colDatOffset == null)
					{
						m_colDatOffset = new uint[m_fieldCount + 1];
						m_colDatSize = new uint[m_fieldCount];
						int num3 = (int)(m_pOpoDacValCtx->RecordCount % m_pOpoDacValCtx->FetchSize);
						if (num3 == 0)
						{
							num3 = (int)m_pOpoDacValCtx->FetchSize;
						}
						GetDataOffsetsAndSizes(m_colDatOffset, m_colDatSize, num3);
					}
					num = OpsDac.GetColumnValues(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, m_oracleDbType, ref m_pColumnsDataBuffer, m_fetchArrayLocation, m_rowSize, m_colOffset, m_colIndOffset, m_colLenOffset, m_colDatOffset, m_colDatSize);
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
					switch (num)
					{
					case 22053:
					case 22054:
						throw new OverflowException(OracleTypeException.GetTypeMsg(num));
					default:
						OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
						break;
					case 0:
						break;
					}
				}
			}
		}
		else if (m_currentClientRow == 0)
		{
			m_bBOF = false;
			m_rowLocation = 0L;
			if (m_fillReader)
			{
				try
				{
					if (m_fillReader && m_colDatOffset == null)
					{
						m_colDatOffset = new uint[m_fieldCount + 1];
						m_colDatSize = new uint[m_fieldCount];
						int num4 = (int)(m_pOpoDacValCtx->RecordCount % m_pOpoDacValCtx->FetchSize);
						if (num4 == 0)
						{
							num4 = (int)m_pOpoDacValCtx->FetchSize;
						}
						GetDataOffsetsAndSizes(m_colDatOffset, m_colDatSize, num4);
					}
					num = OpsDac.GetColumnValues(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, m_oracleDbType, ref m_pColumnsDataBuffer, m_fetchArrayLocation, m_rowSize, m_colOffset, m_colIndOffset, m_colLenOffset, m_colDatOffset, m_colDatSize);
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
					switch (num)
					{
					case 22053:
					case 22054:
						throw new OverflowException(OracleTypeException.GetTypeMsg(num));
					default:
						OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
						break;
					case 0:
						break;
					}
				}
			}
		}
		else
		{
			m_rowLocation += m_rowSize;
		}
		m_pOpoDacValCtx->CurrentClientRow++;
		m_currentClientRow++;
		m_hasRows = true;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::Read()\n");
		}
		return true;
	}

	private void CheckParameters(int bufferLength, int bufferOffset, int length)
	{
		if (bufferOffset < 0 || bufferOffset > bufferLength)
		{
			throw new ArgumentOutOfRangeException("bufferOffset");
		}
		if (bufferOffset + length > bufferLength)
		{
			throw new ArgumentOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_DATA_REQ));
		}
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
	}

	protected unsafe override void Dispose(bool disposing)
	{
		int num = 1;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::Dispose()\n");
		}
		if (!m_disposed)
		{
			if (m_pOpoSqlValCtx != null && m_pOpoSqlValCtx->bPooledFetchArray == 1)
			{
				m_fetchArrayPooler.PutFetchArray((IntPtr)m_fetchArrayLocation);
			}
			lock (m_disposeSyncObj)
			{
				if (!m_disposed)
				{
					try
					{
						if (m_connection != null)
						{
							lock (m_connection.m_DataReaderList.SyncRoot)
							{
								m_connection.m_DataReaderList.Remove(this);
							}
						}
					}
					catch
					{
					}
					try
					{
						if (OracleConnection.IsAvailable && m_connection != null && m_connection.m_extProcEnv != null)
						{
							Monitor.Enter(m_connection.m_extProcEnv);
							if (!m_connection.m_extProcEnv.m_status)
							{
								num = 0;
							}
						}
						if (m_opsXmlTypeCtx != null)
						{
							try
							{
								int num2 = m_opsXmlTypeCtx.Length;
								for (int i = 0; i < num2; i++)
								{
									if (m_opsXmlTypeCtx[i] != IntPtr.Zero)
									{
										OpsXmlType.RelRef(m_opsConCtx, m_opsErrCtx, ref m_opsXmlTypeCtx[i], num);
										ref IntPtr reference = ref m_opsXmlTypeCtx[i];
										reference = IntPtr.Zero;
									}
								}
							}
							catch (Exception ex)
							{
								if (OraTrace.m_TraceLevel != 0)
								{
									OraTrace.TraceExceptionInfo(ex);
								}
							}
							m_opsXmlTypeCtx = null;
						}
						if (m_connection.m_opoConCtx.m_bSelfTuning && !m_connection.m_disposed && null != m_pOpoSqlValCtx && 1 == m_pOpoSqlValCtx->AddToStmtCache && m_commandText != null && !OracleTuningAgent.bHighMemoryAlertFlag)
						{
							m_connection.AcceptStatementData(m_commandText);
						}
						if (!m_noMoreResults)
						{
							if (m_opsSqlCtx == null)
							{
								try
								{
									OpsDac.Dispose(m_opsConCtx, m_opsErrCtx, IntPtr.Zero, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, m_pOpoSqlValCtx, num);
									m_opsErrCtx = IntPtr.Zero;
								}
								catch (Exception ex2)
								{
									if (OraTrace.m_TraceLevel != 0)
									{
										OraTrace.TraceExceptionInfo(ex2);
									}
								}
							}
							else
							{
								try
								{
									if (m_freeOpsSqlCtx == 1)
									{
										OpsDac.Dispose(m_opsConCtx, m_opsErrCtx, m_opsSqlCtx[m_currentResultIndex], m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, m_pOpoSqlValCtx, num);
									}
									else
									{
										OpsDac.Dispose(m_opsConCtx, m_opsErrCtx, IntPtr.Zero, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, m_pOpoSqlValCtx, num);
									}
									m_opsErrCtx = IntPtr.Zero;
									ref IntPtr reference2 = ref m_opsSqlCtx[m_currentResultIndex];
									reference2 = IntPtr.Zero;
								}
								catch (Exception ex3)
								{
									if (OraTrace.m_TraceLevel != 0)
									{
										OraTrace.TraceExceptionInfo(ex3);
									}
								}
								try
								{
									if (m_opsSqlCtx[m_currentResultIndex] != IntPtr.Zero)
									{
										try
										{
											if (m_freeOpsSqlCtx == 1 && num == 1)
											{
												if (m_pOpoSqlValCtx->CommandType == 1)
												{
													if (m_pOpoSqlValCtx->AddToStmtCache == 0)
													{
														OpsSql.FreeCtx(ref m_opsSqlCtx[m_currentResultIndex], m_opsErrCtx, 0);
													}
													else
													{
														OpsSql.FreeCtx(ref m_opsSqlCtx[m_currentResultIndex], m_opsErrCtx, 1);
													}
												}
												else
												{
													OpsSql.FreeCtx(ref m_opsSqlCtx[m_currentResultIndex], m_opsErrCtx, 0);
												}
											}
										}
										catch (Exception ex4)
										{
											if (OraTrace.m_TraceLevel != 0)
											{
												OraTrace.TraceExceptionInfo(ex4);
											}
										}
										ref IntPtr reference3 = ref m_opsSqlCtx[m_currentResultIndex];
										reference3 = IntPtr.Zero;
									}
									int num3 = 0;
									m_currentResultIndex++;
									for (num3 = m_currentResultIndex; num3 < m_resultCount; num3++)
									{
										if (!(m_opsSqlCtx[num3] != IntPtr.Zero))
										{
											continue;
										}
										try
										{
											if (num == 1)
											{
												if (m_pOpoSqlValCtx->CommandType == 1)
												{
													if (m_pOpoSqlValCtx->AddToStmtCache == 0)
													{
														OpsSql.FreeCtx(ref m_opsSqlCtx[num3], m_opsErrCtx, 0);
													}
													else
													{
														OpsSql.FreeCtx(ref m_opsSqlCtx[num3], m_opsErrCtx, 1);
													}
												}
												else
												{
													OpsSql.FreeCtx(ref m_opsSqlCtx[num3], m_opsErrCtx, 0);
												}
											}
										}
										catch (Exception ex5)
										{
											if (OraTrace.m_TraceLevel != 0)
											{
												OraTrace.TraceExceptionInfo(ex5);
											}
										}
										ref IntPtr reference4 = ref m_opsSqlCtx[num3];
										reference4 = IntPtr.Zero;
									}
								}
								catch
								{
								}
							}
							if (m_opsErrCtx != IntPtr.Zero)
							{
								try
								{
									if (num == 1)
									{
										OpsErr.FreeCtx(ref m_opsErrCtx);
									}
								}
								catch (Exception ex6)
								{
									if (OraTrace.m_TraceLevel != 0)
									{
										OraTrace.TraceExceptionInfo(ex6);
									}
								}
								m_opsErrCtx = IntPtr.Zero;
							}
							m_pOpoSqlValCtx = null;
							m_pOpoDacValCtx = null;
							m_pOpoMetValCtx = null;
							m_opsErrCtx = IntPtr.Zero;
							m_opsDacCtx = IntPtr.Zero;
							m_noMoreResults = true;
						}
					}
					finally
					{
						if (OracleConnection.IsAvailable && m_connection != null && m_connection.m_extProcEnv != null)
						{
							Monitor.Exit(m_connection.m_extProcEnv);
						}
					}
					try
					{
						OpsCon.RelRef(ref m_opsConCtx);
					}
					catch (Exception ex7)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex7);
						}
					}
					if (m_refCursor != null)
					{
						try
						{
							m_refCursor.m_state = OraRefCursorState.Closed;
						}
						catch
						{
						}
					}
					if ((m_commandBehavior & CommandBehavior.CloseConnection) == CommandBehavior.CloseConnection)
					{
						try
						{
							m_connection.Close();
						}
						catch
						{
						}
					}
					if (disposing)
					{
						m_closed = true;
						m_connection = null;
						m_opsSqlCtx = null;
						m_colMetaRef = null;
						m_safeMapping = null;
						m_pkFetched = false;
						m_doneMarshalAndStoreMetaData = false;
						m_expectedColumnTypes = null;
						if (m_currentRowUdtCache != null)
						{
							for (int j = 0; j < m_currentRowUdtCache.Length; j++)
							{
								if (m_currentRowUdtCache[j] != null)
								{
									if (m_currentRowUdtCache[j] is OracleRef oracleRef && oracleRef.m_bNotRefByApp)
									{
										oracleRef.Dispose();
										OracleRef oracleRef2 = null;
									}
									m_currentRowUdtCache[j] = null;
								}
							}
							m_currentRowUdtCache = null;
						}
						m_udtDescriptorCache = null;
						if (m_dataTable != null)
						{
							try
							{
								m_dataTable.Dispose();
							}
							catch
							{
							}
							m_dataTable = null;
						}
						m_dataTableList = null;
						m_commandText = null;
						m_metaData = null;
					}
					m_disposed = true;
				}
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::Dispose()\n");
		}
	}

	private unsafe void GetColMetaRef(bool bFetchMoreMetaIfRequired, bool bLocalParsed)
	{
		int num = 0;
		int num2 = 0;
		bool flag = bLocalParsed;
		if (m_pOpoMetValCtx == null || m_pOpoMetValCtx->pOpoMetRefCtx == IntPtr.Zero)
		{
			return;
		}
		num2 = m_pOpoMetValCtx->NoOfCols;
		if (num2 == 0)
		{
			return;
		}
		try
		{
			if (bFetchMoreMetaIfRequired && m_pOpoMetValCtx->bStmtParsed != 1 && m_pOpoSqlValCtx->CommandType == 1)
			{
				num = OpsMet.GetSchemaMetaData(m_opsConCtx, m_opsErrCtx, m_pOpoMetValCtx, m_pOpoSqlValCtx->AddRowid, m_pOpoSqlValCtx->AddToStmtCache);
				flag = true;
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
		if (m_metaData != null && m_colMetaRef == null)
		{
			if (!m_addRowid)
			{
				m_colMetaRef = m_metaData.m_colMetaRef;
			}
			else
			{
				m_colMetaRef = m_metaData.m_colMetaRefWRowid;
			}
		}
		if (m_colMetaRef != null && !flag)
		{
			return;
		}
		m_colMetaRef = new ColMetaRef[num2];
		OpoMetRefCtx opoMetRefCtx = new OpoMetRefCtx();
		Marshal.PtrToStructure(m_pOpoMetValCtx->pOpoMetRefCtx, (object)opoMetRefCtx);
		IntPtr intPtr = opoMetRefCtx.pColMetaRef;
		int num3 = Marshal.SizeOf(typeof(ColMetaRef));
		for (int i = 0; i < num2; i++)
		{
			m_colMetaRef[i] = new ColMetaRef();
			Marshal.PtrToStructure(intPtr, (object)m_colMetaRef[i]);
			intPtr = (IntPtr)((int)intPtr + num3);
		}
		if (m_metaData != null)
		{
			if (!m_addRowid)
			{
				m_metaData.m_colMetaRef = m_colMetaRef;
			}
			else
			{
				m_metaData.m_colMetaRefWRowid = m_colMetaRef;
			}
		}
		if (bLocalParsed)
		{
			m_doneMarshalAndStoreMetaData = true;
		}
	}

	private OracleDbType GetOraDbType(int i)
	{
		return m_oracleDbType[i];
	}

	private unsafe OracleDbType GetOraDbTypeEx(int i)
	{
		if (i >= m_fieldCount || i < 0)
		{
			throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
		}
		bool flag = true;
		if (m_pOpoMetValCtx->pColMetaVal[i].CharSetForm != 2)
		{
			flag = false;
		}
		OraType oraType = m_oraType[i];
		if (oraType == OraType.ORA_NDT && m_pOpoMetValCtx->pColMetaVal[i].bIsXmlType == 0)
		{
			OracleUdtDescriptor cachedOracleUdtDescriptor = GetCachedOracleUdtDescriptor(i);
			if (cachedOracleUdtDescriptor.m_bSetOracleDbType)
			{
				return cachedOracleUdtDescriptor.m_oraDbType;
			}
			return cachedOracleUdtDescriptor.OracleDbType;
		}
		OracleDbType oracleDbType = (OracleDbType)OracleTypeMapper.m_OraToOraDb[oraType];
		switch (oracleDbType)
		{
		case OracleDbType.Char:
			if (flag)
			{
				oracleDbType = OracleDbType.NChar;
			}
			break;
		case OracleDbType.Varchar2:
			if (flag)
			{
				oracleDbType = OracleDbType.NVarchar2;
			}
			break;
		case OracleDbType.Clob:
			if (flag)
			{
				oracleDbType = OracleDbType.NClob;
			}
			break;
		case OracleDbType.Decimal:
		{
			int scale = m_pOpoMetValCtx->pColMetaVal[i].Scale;
			int precision = m_pOpoMetValCtx->pColMetaVal[i].Precision;
			if (scale <= 0 && precision - scale < 5)
			{
				oracleDbType = OracleDbType.Int16;
			}
			else if (scale <= 0 && precision - scale < 10)
			{
				oracleDbType = OracleDbType.Int32;
			}
			else if (scale <= 0 && precision - scale < 19)
			{
				oracleDbType = OracleDbType.Int64;
			}
			else if (precision < 8 && ((scale <= 0 && precision - scale <= 38) || (scale > 0 && scale <= 44)))
			{
				oracleDbType = OracleDbType.Single;
			}
			else if (precision < 16)
			{
				oracleDbType = OracleDbType.Double;
			}
			break;
		}
		}
		return oracleDbType;
	}

	public override IEnumerator GetEnumerator()
	{
		bool closeReader = false;
		if ((m_commandBehavior & CommandBehavior.CloseConnection) == CommandBehavior.CloseConnection)
		{
			closeReader = true;
		}
		return new DbEnumerator((IDataReader)this, closeReader);
	}

	public override Type GetProviderSpecificFieldType(int ordinal)
	{
		Type result = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetProviderSpecificFieldType()\n");
		}
		switch (m_oracleDbType[ordinal])
		{
		case OracleDbType.BFile:
			result = ODPType.OraBFile;
			break;
		case OracleDbType.Blob:
			result = ODPType.OraBlob;
			break;
		case OracleDbType.Char:
		case OracleDbType.Long:
		case OracleDbType.NChar:
		case OracleDbType.NVarchar2:
		case OracleDbType.Varchar2:
			result = ODPType.OraString;
			break;
		case OracleDbType.Clob:
		case OracleDbType.NClob:
			result = ODPType.OraClob;
			break;
		case OracleDbType.Date:
			result = ODPType.OraDate;
			break;
		case OracleDbType.Byte:
		case OracleDbType.Decimal:
		case OracleDbType.Double:
		case OracleDbType.Int16:
		case OracleDbType.Int32:
		case OracleDbType.Int64:
		case OracleDbType.Single:
		case OracleDbType.BinaryDouble:
		case OracleDbType.BinaryFloat:
			result = ODPType.OraDecimal;
			break;
		case OracleDbType.LongRaw:
		case OracleDbType.Raw:
			result = ODPType.OraBinary;
			break;
		case OracleDbType.IntervalDS:
			result = ODPType.OraIntervalDS;
			break;
		case OracleDbType.IntervalYM:
			result = ODPType.OraIntervalYM;
			break;
		case OracleDbType.RefCursor:
			result = ODPType.OraRefCursor;
			break;
		case OracleDbType.TimeStamp:
			result = ODPType.OraTimeStamp;
			break;
		case OracleDbType.TimeStampTZ:
			result = ODPType.OraTimeStampTZ;
			break;
		case OracleDbType.TimeStampLTZ:
			result = ODPType.OraTimeStampLTZ;
			break;
		case OracleDbType.XmlType:
			result = ODPType.OraXmlType;
			break;
		case OracleDbType.Array:
		case OracleDbType.Object:
			result = GetFieldType(ordinal);
			break;
		case OracleDbType.Ref:
			result = ODPType.OraRef;
			break;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetProviderSpecificFieldType()\n");
		}
		return result;
	}

	public override object GetProviderSpecificValue(int ordinal)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetProviderSpecificValue()\n");
		}
		object oracleValue = GetOracleValue(ordinal);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetProviderSpecificValue()\n");
		}
		return oracleValue;
	}

	public override int GetProviderSpecificValues(object[] values)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDataReader::GetProviderSpecificValues()\n");
		}
		int oracleValues = GetOracleValues(values);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDataReader::GetProviderSpecificValues()\n");
		}
		return oracleValues;
	}

	private bool IsCorruptible(OraType oraType)
	{
		switch (oraType)
		{
		case OraType.ORA_NUMBER:
		case OraType.ORA_DATE:
		case OraType.ORA_TIMESTAMP:
		case OraType.ORA_TIMESTAMP_TZ:
		case OraType.ORA_INTERVAL_DS:
		case OraType.ORA_TIMESTAMP_LTZ:
			return true;
		default:
			return false;
		}
	}

	private unsafe OracleUdtDescriptor GetCachedOracleUdtDescriptor(int index)
	{
		if (m_udtDescriptorCache == null)
		{
			m_udtDescriptorCache = new OracleUdtDescriptor[m_pOpoMetValCtx->NoOfCols];
		}
		if (m_udtDescriptorCache[index] == null)
		{
			if (m_pOpoMetValCtx != null && m_colMetaRef == null)
			{
				GetColMetaRef(bFetchMoreMetaIfRequired: false, bLocalParsed: false);
			}
			if (m_colMetaRef[index].pUdtTypeName != null)
			{
				m_udtDescriptorCache[index] = OracleUdtDescriptor.GetOracleUdtDescriptor(m_connection, m_colMetaRef[index].pUdtSchemaName, m_colMetaRef[index].pUdtTypeName);
				if (m_udtDescriptorCache[index] != null)
				{
					m_udtDescriptorCache[index].GetMetaDataTable();
				}
			}
		}
		return m_udtDescriptorCache[index];
	}

	internal unsafe object GetCustomObject(int i)
	{
		if (m_external)
		{
			if (m_closed || m_bBOF || m_bEOF)
			{
				throw new InvalidOperationException();
			}
			if (i >= m_fieldCount || i < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
		}
		int num = 0;
		OraType oraType = (OraType)m_pOpoMetValCtx->pColMetaVal[i].OraType;
		if (oraType != OraType.ORA_NDT)
		{
			throw new InvalidCastException();
		}
		m_pOpoDacValCtx->CurrentClientRow = m_currentClientRow;
		m_pOpoDacValCtx->Ordinal = i;
		m_pOpoDacValCtx->FieldOffset = 0L;
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		OracleUdtDescriptor oracleUdtDescriptor;
		if (m_pOpoMetValCtx->pColMetaVal[i].bIsFinalType == 0)
		{
			try
			{
				num = OpsDac.GetType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, 0);
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
			if (m_pOpoDacValCtx->Indicator == 0)
			{
				oracleUdtDescriptor = OracleUdtDescriptor.GetOracleUdtDescriptor(m_connection, m_pOpoDacValCtx->pTDO, bRefresh: false, out var bExists);
				if (bExists)
				{
					try
					{
						OpsDsc.UnpinTDO(m_opsConCtx, m_pOpoDacValCtx->pTDO);
					}
					catch (Exception ex2)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex2);
						}
					}
				}
				m_pOpoDacValCtx->pTDO = IntPtr.Zero;
			}
			else
			{
				oracleUdtDescriptor = GetCachedOracleUdtDescriptor(i);
			}
		}
		else
		{
			oracleUdtDescriptor = GetCachedOracleUdtDescriptor(i);
		}
		if (OracleConnection.s_bIsOdtConnection)
		{
			m_pOpoDacValCtx->pOpoUdtValCtx[i].bIsOdtConnection = 1;
			if (m_pOpoMetValCtx->pColMetaVal[i].bIsFinalType == 0)
			{
				oracleUdtDescriptor.GetMetaDataTable();
			}
		}
		else
		{
			m_pOpoDacValCtx->pOpoUdtValCtx[i].bIsOdtConnection = 0;
			if (oracleUdtDescriptor.m_customTypeFactory == null)
			{
				object factory = OracleUdt.GetFactory(oracleUdtDescriptor);
				if (factory != null)
				{
					oracleUdtDescriptor.DescribeCustomType(factory);
				}
			}
		}
		m_pOpoDacValCtx->pOpoUdtValCtx[i].pTDO = oracleUdtDescriptor.m_opsDscCtx;
		m_pOpoDacValCtx->pOpoUdtValCtx[i].pOpsErrCtx = m_opsErrCtx;
		m_pOpoDacValCtx->pOpoUdtValCtx[i].pOpoDscValCtx = oracleUdtDescriptor.m_pOpoDscValCtx;
		m_pOpoDacValCtx->pOpoUdtValCtx[i].ppRefTDO = m_pOpoDacValCtx->ppRefTDO;
		try
		{
			if (m_pOpoMetValCtx->pColMetaVal[i].bIsFinalType == 1)
			{
				num = OpsDac.GetType(m_opsConCtx, m_opsErrCtx, m_opsDacCtx, m_pOpoMetValCtx, m_pOpoDacValCtx, 0);
			}
			else if (m_pOpoDacValCtx->Indicator == 0)
			{
				m_pOpoDacValCtx->pOpoUdtValCtx[i].pUDT = m_pOpoDacValCtx->pBuffer;
				m_pOpoDacValCtx->pOpoUdtValCtx[i].pNullStruct = m_pOpoDacValCtx->pUdtNullStruct;
				num = OpsUdt.GetObj(m_opsConCtx, m_pOpoDacValCtx->pOpoUdtValCtx + i);
			}
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
		object obj = null;
		if (m_pOpoDacValCtx->Indicator == -1)
		{
			object customTypeFactory = oracleUdtDescriptor.m_customTypeFactory;
			if (oracleUdtDescriptor.m_pOpoDscValCtx->bIsArrayType == 0 && customTypeFactory is IOracleCustomTypeFactory)
			{
				obj = ((IOracleCustomTypeFactory)oracleUdtDescriptor.m_customTypeFactory).CreateObject();
				Type type = obj.GetType();
				PropertyInfo property = type.GetProperty("Null");
				if (property != null)
				{
					return property.GetValue(null, null);
				}
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(-2902, "'" + type.FullName + "'", "'Null'"));
			}
			return null;
		}
		m_pOpoDacValCtx->pBuffer = IntPtr.Zero;
		if (OracleConnection.s_bIsOdtConnection)
		{
			if (oracleUdtDescriptor.OracleDbType == OracleDbType.Object)
			{
				OracleUdtWrapper oracleUdtWrapper = new OracleUdtWrapper();
				oracleUdtWrapper.m_udtData = new object[oracleUdtDescriptor.AttributeCount];
				oracleUdtWrapper.m_udtStatusArray = new OracleUdtStatus[oracleUdtDescriptor.AttributeCount];
				for (int j = 0; j < oracleUdtDescriptor.AttributeCount; j++)
				{
					OciTypeCode typeCode = (OciTypeCode)oracleUdtDescriptor.m_pOpoDscValCtx->pAttrMetaVals[j].TypeCode;
					if (typeCode == OciTypeCode.OBJECT || typeCode == OciTypeCode.NAMEDCOLLECTION)
					{
						OracleUdtWrapper oracleUdtWrapper2 = new OracleUdtWrapper();
						oracleUdtWrapper2.m_udtDescriptor = oracleUdtDescriptor.GetObjAttrUdtDescriptor(j);
						((object[])oracleUdtWrapper.m_udtData)[j] = oracleUdtWrapper2;
						if (m_pOpoDacValCtx->pOpoUdtValCtx[i].pOpoUdtValCtx[j].bIsNull == 1)
						{
							oracleUdtWrapper.m_udtStatusArray[j] = OracleUdtStatus.Null;
						}
						else
						{
							oracleUdtWrapper.m_udtStatusArray[j] = OracleUdtStatus.NotNull;
						}
					}
					else
					{
						object value = OracleUdt.GetValue(m_connection, (IntPtr)(m_pOpoDacValCtx->pOpoUdtValCtx + i), j);
						((object[])oracleUdtWrapper.m_udtData)[j] = value;
						if (value == null || value == DBNull.Value || (value is INullable && ((INullable)value).IsNull))
						{
							oracleUdtWrapper.m_udtStatusArray[j] = OracleUdtStatus.Null;
						}
						else
						{
							oracleUdtWrapper.m_udtStatusArray[j] = OracleUdtStatus.NotNull;
						}
					}
				}
				oracleUdtWrapper.m_udtDescriptor = oracleUdtDescriptor;
				obj = oracleUdtWrapper;
			}
			else
			{
				OracleUdtWrapper oracleUdtWrapper3 = new OracleUdtWrapper();
				int numOfArrElems = m_pOpoDacValCtx->pOpoUdtValCtx[i].NumOfArrElems;
				oracleUdtWrapper3.m_udtData = new object[numOfArrElems];
				oracleUdtWrapper3.m_udtStatusArray = new OracleUdtStatus[numOfArrElems];
				OciTypeCode typeCode2 = (OciTypeCode)oracleUdtDescriptor.m_pOpoDscValCtx->pAttrMetaVals->TypeCode;
				for (int k = 0; k < numOfArrElems; k++)
				{
					if (typeCode2 == OciTypeCode.OBJECT || typeCode2 == OciTypeCode.NAMEDCOLLECTION)
					{
						OracleUdtWrapper oracleUdtWrapper4 = new OracleUdtWrapper();
						oracleUdtWrapper4.m_udtDescriptor = oracleUdtDescriptor.GetArrElemUdtDescriptor();
						((object[])oracleUdtWrapper3.m_udtData)[k] = oracleUdtWrapper4;
						if (m_pOpoDacValCtx->pOpoUdtValCtx[i].pOpoUdtValCtx[k].bIsNull == 1)
						{
							oracleUdtWrapper3.m_udtStatusArray[k] = OracleUdtStatus.Null;
						}
						else
						{
							oracleUdtWrapper3.m_udtStatusArray[k] = OracleUdtStatus.NotNull;
						}
					}
					else
					{
						OracleUdtStatus status;
						object statusArray;
						object data = OracleUdt.GetData(m_connection, (IntPtr)(m_pOpoDacValCtx->pOpoUdtValCtx + i), k, out status, out statusArray);
						((object[])oracleUdtWrapper3.m_udtData)[k] = data;
						if (data == null || data == DBNull.Value || (data is INullable && ((INullable)data).IsNull))
						{
							oracleUdtWrapper3.m_udtStatusArray[k] = OracleUdtStatus.Null;
						}
						else
						{
							oracleUdtWrapper3.m_udtStatusArray[k] = OracleUdtStatus.NotNull;
						}
					}
				}
				oracleUdtWrapper3.m_udtDescriptor = oracleUdtDescriptor;
				obj = oracleUdtWrapper3;
			}
		}
		else
		{
			_ = oracleUdtDescriptor.m_customTypeFactory;
			if (oracleUdtDescriptor.m_pOpoDscValCtx->bIsArrayType == 0)
			{
				obj = ((IOracleCustomTypeFactory)oracleUdtDescriptor.m_customTypeFactory).CreateObject();
				((IOracleCustomType)obj).ToCustomObject(m_connection, (IntPtr)(m_pOpoDacValCtx->pOpoUdtValCtx + i));
			}
			else
			{
				m_pOpoDacValCtx->pOpoUdtValCtx[i].bIgnoreElemStatus = 1;
				obj = OracleUdt.GetArrData(m_connection, (IntPtr)(m_pOpoDacValCtx->pOpoUdtValCtx + i), out var _, out var _);
			}
		}
		GC.KeepAlive(oracleUdtDescriptor);
		return obj;
	}

	internal unsafe DataTable GetMinSchemaTable()
	{
		if (m_pOpoMetValCtx == null)
		{
			return null;
		}
		DataTable dataTable = null;
		DataTable dataTable2 = null;
		if (m_pOpoSqlValCtx->CommandType != 1)
		{
			if (m_refCursor != null)
			{
				RefCursorInfo refCursorInfo = m_refCursor.m_refCursorInfo;
				if (refCursorInfo != null)
				{
					dataTable2 = refCursorInfo.columnInfo;
				}
			}
			else
			{
				StoredProcedureInfo storedProcInfo = RegAndConfigRdr.GetStoredProcInfo(m_storedProcName);
				if (storedProcInfo != null && storedProcInfo.refCursors.Count > 0)
				{
					RefCursorInfo refCursorInfo2 = (RefCursorInfo)storedProcInfo.refCursors[m_currentResultIndex];
					if (refCursorInfo2 != null)
					{
						dataTable2 = refCursorInfo2.columnInfo;
					}
				}
			}
		}
		dataTable = new DataTable("MinSchemaTable");
		GetColMetaRef(bFetchMoreMetaIfRequired: true, bLocalParsed: false);
		dataTable.MinimumCapacity = m_fieldCount;
		if (m_pOpoSqlValCtx->CommandType != 1)
		{
			dataTable.ExtendedProperties["REFCursorName"] = ((m_currentResultIndex == 0) ? "REFCursor" : ("REFCursor" + m_currentResultIndex));
		}
		dataTable.Columns.Add("ColumnName", typeof(string));
		dataTable.Columns.Add("BaseColumnName", typeof(string));
		dataTable.Columns.Add("BaseTableName", typeof(string));
		dataTable.Columns.Add("OraDbType", typeof(OracleDbType));
		dataTable.Columns.Add("BaseSchemaName", typeof(string));
		dataTable.Columns.Add("UdtTypeName", typeof(string));
		for (int i = 0; i < m_fieldCount; i++)
		{
			DataRow dataRow = dataTable.NewRow();
			if (m_pOpoSqlValCtx->CommandType != 1 && dataTable2 != null)
			{
				dataRow[0] = dataTable2.Rows[i]["ColumnName"];
				dataRow[1] = dataTable2.Rows[i]["BaseColumnName"];
				dataRow[2] = dataTable2.Rows[i]["BaseTableName"];
				dataRow[3] = dataTable2.Rows[i]["ProviderType"];
				dataRow[4] = dataTable2.Rows[i]["BaseSchemaName"];
				dataRow[5] = dataTable2.Rows[i]["UdtTypeName"];
			}
			else
			{
				dataRow[0] = m_colMetaRef[i].pColAlias;
				dataRow[1] = m_colMetaRef[i].pColName;
				dataRow[2] = m_colMetaRef[i].pTabName;
				dataRow[3] = m_oracleDbType[i];
				dataRow[4] = m_colMetaRef[i].pSchemaName;
				OraType oraType = (OraType)m_pOpoMetValCtx->pColMetaVal[i].OraType;
				if ((oraType == OraType.ORA_NDT && m_pOpoMetValCtx->pColMetaVal[i].bIsXmlType == 0) || oraType == OraType.ORA_OCIRef)
				{
					dataRow[5] = GetCachedOracleUdtDescriptor(i).UdtTypeName;
				}
			}
			dataTable.Rows.Add(dataRow);
		}
		dataTable.AcceptChanges();
		return dataTable;
	}

	internal unsafe OracleDataReader(OracleConnection connection, IntPtr[] opsSqlCtx, IntPtr opsDacCtx, IntPtr opsErrCtx, OpoSqlValCtx* pOpoSqlValCtx, OpoDacValCtx* pOpoDacValCtx, MetaData metaData, int resultCount, CommandBehavior commandBehavior, Hashtable safeMapping, string commandText, int freeOpsSqlCtx, bool bFetchSizePropertySet)
	{
		int num = 0;
		m_bBOF = true;
		m_external = true;
		m_safeMapping = safeMapping;
		m_bFetchSizePropertySet = bFetchSizePropertySet;
		m_resultCount = resultCount;
		m_commandBehavior = commandBehavior;
		m_connection = connection;
		m_fetchArrayPooler = connection.m_opoConCtx.m_fetchArrayPooler;
		m_conSignature = m_connection.m_conSignature;
		m_opsSqlCtx = opsSqlCtx;
		m_opsDacCtx = opsDacCtx;
		m_opsErrCtx = opsErrCtx;
		m_pOpoSqlValCtx = pOpoSqlValCtx;
		m_fetchSize = m_pOpoSqlValCtx->FetchSize;
		m_commandText = commandText;
		m_freeOpsSqlCtx = freeOpsSqlCtx;
		if (m_pOpoSqlValCtx->AddRowid == 1)
		{
			m_addRowid = true;
		}
		if (m_pOpoSqlValCtx->CommandType == 4 || m_pOpoSqlValCtx->CommandType == 2 || m_pOpoSqlValCtx->CommandType == 3)
		{
			m_recordsAffected = m_pOpoSqlValCtx->RowsAffected;
		}
		else
		{
			m_recordsAffected = -1;
		}
		m_opsConCtx = m_connection.m_opoConCtx.opsConCtx;
		if (m_opsConCtx == IntPtr.Zero)
		{
			GC.SuppressFinalize(this);
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			GC.SuppressFinalize(this);
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		int num2 = 0;
		try
		{
			num2 = OpsCon.AddRef(m_opsConCtx);
			if (num2 <= 1)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			GC.SuppressFinalize(this);
			throw;
		}
		if (m_opsErrCtx == IntPtr.Zero)
		{
			try
			{
				num = OpsErr.AllocCtx(ref m_opsErrCtx, m_opsConCtx);
			}
			catch (Exception ex2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex2);
				}
				num = ErrRes.INT_ERR;
				GC.SuppressFinalize(this);
				throw;
			}
			finally
			{
				if (num != 0)
				{
					try
					{
						OpsCon.RelRef(ref m_opsConCtx);
					}
					catch (Exception ex3)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex3);
						}
					}
					if (num != ErrRes.INT_ERR)
					{
						GC.SuppressFinalize(this);
						OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
					}
				}
			}
		}
		m_metaData = metaData;
		if (m_metaData != null)
		{
			if (!m_addRowid)
			{
				m_pOpoMetValCtx = m_metaData.m_pOpoMetValCtx;
			}
			else
			{
				m_pOpoMetValCtx = m_metaData.m_pOpoMetValCtxWRowid;
			}
			try
			{
				OpsMet.AddRef(m_pOpoMetValCtx);
			}
			catch (Exception ex4)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex4);
				}
				num = ErrRes.INT_ERR;
				GC.SuppressFinalize(this);
				throw;
			}
			finally
			{
				if (num != 0)
				{
					try
					{
						OpsCon.RelRef(ref m_opsConCtx);
					}
					catch (Exception ex5)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex5);
						}
					}
					if (num != ErrRes.INT_ERR)
					{
						GC.SuppressFinalize(this);
						OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
					}
				}
			}
		}
		if (m_opsSqlCtx != null && m_pOpoMetValCtx == null && (m_pOpoSqlValCtx->CommandType == 8 || m_pOpoSqlValCtx->CommandType == 9) && m_opsSqlCtx[m_currentResultIndex] != IntPtr.Zero)
		{
			try
			{
				num = OpsMet.GetValCtx(m_opsConCtx, m_opsErrCtx, m_opsSqlCtx[m_currentResultIndex], m_pOpoSqlValCtx, ref m_pOpoMetValCtx);
			}
			catch (Exception ex6)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex6);
				}
				num = ErrRes.INT_ERR;
				throw;
			}
			finally
			{
				if (num != 0)
				{
					try
					{
						OpsCon.RelRef(ref m_opsConCtx);
					}
					catch (Exception ex7)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex7);
						}
					}
					try
					{
						OpsMet.RelRef(m_pOpoMetValCtx);
					}
					catch (Exception ex8)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex8);
						}
					}
					if (num != ErrRes.INT_ERR)
					{
						OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
					}
				}
			}
		}
		if (m_pOpoMetValCtx != null)
		{
			m_rowSize = (int)m_pOpoMetValCtx->pColMetaVal[m_pOpoMetValCtx->NoOfCols - 1].Offset;
			m_fieldCount = m_pOpoMetValCtx->NoOfCols - m_pOpoMetValCtx->NoOfHiddenCols;
			m_bHasUdtType = m_pOpoMetValCtx->bHasUdtType == 1;
		}
		try
		{
			if (m_opsDacCtx != IntPtr.Zero && pOpoDacValCtx != null)
			{
				m_pOpoDacValCtx = pOpoDacValCtx;
			}
			else
			{
				num = OpsDac.AllocValCtx(ref m_pOpoDacValCtx);
			}
		}
		catch (Exception ex9)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex9);
			}
			num = ErrRes.INT_ERR;
			throw;
		}
		finally
		{
			if (num != 0)
			{
				try
				{
					OpsCon.RelRef(ref m_opsConCtx);
				}
				catch (Exception ex10)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex10);
					}
				}
				try
				{
					OpsMet.RelRef(m_pOpoMetValCtx);
				}
				catch (Exception ex11)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex11);
					}
				}
				if (num != ErrRes.INT_ERR)
				{
					OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
				}
			}
		}
		m_pOpoDacValCtx->InitialLongFS = m_pOpoSqlValCtx->InitialLongFS;
		m_pOpoDacValCtx->InitialLobFS = m_pOpoSqlValCtx->InitialLobFS;
		m_pOpoDacValCtx->ResultsetIndex = m_currentResultIndex;
		m_pOpoDacValCtx->pSnapShot = pOpoSqlValCtx->pSnapShot;
		pOpoSqlValCtx->pSnapShot = IntPtr.Zero;
		m_pOpoDacValCtx->AddRowid = m_pOpoSqlValCtx->AddRowid;
		m_pOpoDacValCtx->AddToStmtCache = m_pOpoSqlValCtx->AddToStmtCache;
		m_isDBVer10gR2OrHigher = m_connection.IsDBVer10gR2OrHigher;
		if (m_metaData != null && m_metaData.m_dotNetNumericAccessor != null && m_metaData.m_rowSize == m_rowSize)
		{
			m_colOffset = m_metaData.m_colOffset;
			m_colIndOffset = m_metaData.m_colIndOffset;
			m_colLenOffset = m_metaData.m_colLenOffset;
			m_oraType = m_metaData.m_oraType;
			m_oracleDbType = m_metaData.m_oracleDbType;
			m_dotNetNumericAccessor = m_metaData.m_dotNetNumericAccessor;
		}
		else
		{
			m_colOffset = new uint[m_fieldCount];
			m_colIndOffset = new uint[m_fieldCount];
			m_colLenOffset = new uint[m_fieldCount];
			m_oraType = new OraType[m_fieldCount];
			m_oracleDbType = new OracleDbType[m_fieldCount];
			m_dotNetNumericAccessor = new DotNetNumericAccessor[m_fieldCount];
			for (int i = 0; i < m_fieldCount; i++)
			{
				m_colOffset[i] = 0u;
				if (i > 0)
				{
					m_colOffset[i] = m_pOpoMetValCtx->pColMetaVal[i - 1].Offset;
				}
				m_colIndOffset[i] = m_colOffset[i] + m_pOpoMetValCtx->pColMetaVal[i].Define.Length;
				m_colLenOffset[i] = m_colIndOffset[i] + 2;
				m_oraType[i] = (OraType)m_pOpoMetValCtx->pColMetaVal[i].OraType;
				m_oracleDbType[i] = GetOraDbTypeEx(i);
				int num3 = 0;
				int num4 = 0;
				num3 = m_pOpoMetValCtx->pColMetaVal[i].Scale;
				num4 = m_pOpoMetValCtx->pColMetaVal[i].Precision;
				if (num3 <= 0 && num4 - num3 < 5)
				{
					m_dotNetNumericAccessor[i] = DotNetNumericAccessor.GetInt16;
				}
				else if (num3 <= 0 && num4 - num3 < 10)
				{
					m_dotNetNumericAccessor[i] = DotNetNumericAccessor.GetInt32;
				}
				else if (num3 <= 0 && num4 - num3 < 19)
				{
					m_dotNetNumericAccessor[i] = DotNetNumericAccessor.GetInt64;
				}
				else if (num4 < 8 && ((num3 <= 0 && num4 - num3 <= 38) || (num3 > 0 && num3 <= 44)))
				{
					m_dotNetNumericAccessor[i] = DotNetNumericAccessor.GetFloat;
				}
				else if (num4 < 16)
				{
					m_dotNetNumericAccessor[i] = DotNetNumericAccessor.GetDouble;
				}
				else
				{
					m_dotNetNumericAccessor[i] = DotNetNumericAccessor.GetDecimal;
				}
			}
			if (m_metaData != null && m_metaData.m_dotNetNumericAccessor == null)
			{
				lock (m_metaData)
				{
					if (m_metaData.m_dotNetNumericAccessor == null)
					{
						m_metaData.m_rowSize = m_rowSize;
						m_metaData.m_colOffset = m_colOffset;
						m_metaData.m_colIndOffset = m_colIndOffset;
						m_metaData.m_colLenOffset = m_colLenOffset;
						m_metaData.m_oraType = m_oraType;
						m_metaData.m_oracleDbType = m_oracleDbType;
						m_metaData.m_dotNetNumericAccessor = m_dotNetNumericAccessor;
					}
				}
			}
		}
		m_currentClientRow = 0;
		m_recordCount = m_pOpoDacValCtx->RecordCount;
		m_fetchArrayLocation = (long)m_pOpoSqlValCtx->FetchArrayLocation;
		if (m_opsSqlCtx == null || m_pOpoMetValCtx == null || (m_commandBehavior & CommandBehavior.SchemaOnly) == CommandBehavior.SchemaOnly)
		{
			m_bSetLastFetch = true;
		}
		m_bCmdBehaviorSingleRow = (m_commandBehavior & CommandBehavior.SingleRow) == CommandBehavior.SingleRow;
		lock (m_connection.m_DataReaderList.SyncRoot)
		{
			m_connection.m_DataReaderList.Add(this);
		}
	}

	internal unsafe void UpdateMetaDataPool()
	{
		MetaData metaData = null;
		if (m_pOpoMetValCtx == null || m_pOpoMetValCtx->bPkFetched == 0 || m_pOpoSqlValCtx->CommandType != 1 || m_commandText == null)
		{
			return;
		}
		if (m_pOpoMetValCtx->bStmtParsed == 1 && !m_doneMarshalAndStoreMetaData)
		{
			GetColMetaRef(bFetchMoreMetaIfRequired: false, bLocalParsed: true);
		}
		if (m_connection.m_opoConCtx.metaPool == 0 || ((m_pOpoDacValCtx->InitialLongFS != 0 || m_pOpoDacValCtx->InitialLobFS != 0) && (!m_isFromEF || m_pOpoDacValCtx->InitialLongFS > 0 || m_pOpoDacValCtx->InitialLobFS > 0)))
		{
			return;
		}
		metaData = m_connection.m_opoConCtx.m_conPooler.Get(m_commandText) as MetaData;
		bool flag = false;
		if (metaData == null)
		{
			metaData = m_metaData;
			flag = true;
		}
		OpoMetValCtx* ptr = (m_addRowid ? metaData.m_pOpoMetValCtxWRowid : metaData.m_pOpoMetValCtx);
		if (flag)
		{
			ptr->bPooled = 1;
			m_connection.m_opoConCtx.m_conPooler.Put(m_commandText, metaData);
		}
		else if (ptr->bPkFetched != 1)
		{
			if (m_pOpoMetValCtx->bPkPresent == 1 || m_pOpoMetValCtx->bRowidPresent == 1)
			{
				int noOfCols = m_pOpoMetValCtx->NoOfCols;
				for (int i = 0; i < noOfCols; i++)
				{
					ptr->pColMetaVal[i].bIsKeyColumn = m_pOpoMetValCtx->pColMetaVal[i].bIsKeyColumn;
					ptr->pColMetaVal[i].bIsUnique = m_pOpoMetValCtx->pColMetaVal[i].bIsUnique;
				}
				ptr->bRowidPresent = m_pOpoMetValCtx->bRowidPresent;
				ptr->bPkPresent = m_pOpoMetValCtx->bPkPresent;
			}
			ptr->bPkFetched = 1;
		}
		ptr = null;
		m_pkFetched = true;
	}

	internal object ChangeType(object sourceValue, Type targetType)
	{
		if (sourceValue is byte[] && targetType == typeof(Guid))
		{
			return new Guid((byte[])sourceValue);
		}
		if (sourceValue is TimeSpan && targetType == typeof(decimal))
		{
			return (decimal)((TimeSpan)sourceValue).TotalSeconds;
		}
		return Convert.ChangeType(sourceValue, targetType, CultureInfo.InvariantCulture);
	}

	~OracleDataReader()
	{
		Dispose(disposing: false);
	}
}
