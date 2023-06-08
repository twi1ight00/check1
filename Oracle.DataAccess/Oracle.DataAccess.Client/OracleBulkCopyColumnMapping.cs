using System;

namespace Oracle.DataAccess.Client;

public sealed class OracleBulkCopyColumnMapping : IComparable
{
	internal string m_destinationColumnName;

	internal string m_sourceColumnName;

	internal int m_destinationColumnOrdinal;

	internal int m_sourceColumnOrdinal;

	public string DestinationColumn
	{
		get
		{
			if (m_destinationColumnName == null)
			{
				return string.Empty;
			}
			return m_destinationColumnName;
		}
		set
		{
			m_destinationColumnOrdinal = -1;
			m_destinationColumnName = value;
		}
	}

	public int DestinationOrdinal
	{
		get
		{
			return m_destinationColumnOrdinal;
		}
		set
		{
			if (value < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
			m_destinationColumnName = null;
			m_destinationColumnOrdinal = value;
		}
	}

	public string SourceColumn
	{
		get
		{
			if (m_sourceColumnName == null)
			{
				return string.Empty;
			}
			return m_sourceColumnName;
		}
		set
		{
			m_sourceColumnOrdinal = -1;
			m_sourceColumnName = value;
		}
	}

	public int SourceOrdinal
	{
		get
		{
			return m_sourceColumnOrdinal;
		}
		set
		{
			if (value < 0)
			{
				throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
			}
			m_sourceColumnName = null;
			m_sourceColumnOrdinal = value;
		}
	}

	static OracleBulkCopyColumnMapping()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public OracleBulkCopyColumnMapping()
	{
		m_sourceColumnOrdinal = -1;
		m_destinationColumnOrdinal = -1;
	}

	public OracleBulkCopyColumnMapping(int sourceColumnOrdinal, int destinationOrdinal)
	{
		if (sourceColumnOrdinal < 0 || destinationOrdinal < 0)
		{
			throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
		}
		m_sourceColumnOrdinal = sourceColumnOrdinal;
		m_destinationColumnOrdinal = destinationOrdinal;
	}

	public OracleBulkCopyColumnMapping(int sourceColumnOrdinal, string destinationColumn)
	{
		if (sourceColumnOrdinal < 0)
		{
			throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
		}
		m_sourceColumnOrdinal = sourceColumnOrdinal;
		m_destinationColumnName = destinationColumn;
		m_destinationColumnOrdinal = -1;
	}

	public OracleBulkCopyColumnMapping(string sourceColumn, int destinationOrdinal)
	{
		if (destinationOrdinal < 0)
		{
			throw new IndexOutOfRangeException(OpoErrResManager.GetErrorMesg(ErrRes.DR_INV_COL_INDEX));
		}
		m_sourceColumnName = sourceColumn;
		m_destinationColumnOrdinal = destinationOrdinal;
		m_sourceColumnOrdinal = -1;
	}

	public OracleBulkCopyColumnMapping(string sourceColumn, string destinationColumn)
	{
		m_sourceColumnName = sourceColumn;
		m_destinationColumnName = destinationColumn;
		m_sourceColumnOrdinal = -1;
		m_destinationColumnOrdinal = -1;
	}

	internal OracleBulkCopyColumnMapping Clone()
	{
		OracleBulkCopyColumnMapping oracleBulkCopyColumnMapping = new OracleBulkCopyColumnMapping();
		oracleBulkCopyColumnMapping.m_sourceColumnName = m_sourceColumnName;
		oracleBulkCopyColumnMapping.m_destinationColumnName = m_destinationColumnName;
		oracleBulkCopyColumnMapping.m_sourceColumnOrdinal = m_sourceColumnOrdinal;
		oracleBulkCopyColumnMapping.m_destinationColumnOrdinal = m_destinationColumnOrdinal;
		return oracleBulkCopyColumnMapping;
	}

	public int CompareTo(object obj)
	{
		if (obj is OracleBulkCopyColumnMapping)
		{
			OracleBulkCopyColumnMapping oracleBulkCopyColumnMapping = (OracleBulkCopyColumnMapping)obj;
			return m_sourceColumnOrdinal.CompareTo(oracleBulkCopyColumnMapping.m_sourceColumnOrdinal);
		}
		throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "object"));
	}
}
