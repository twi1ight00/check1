using System;
using System.Collections;

namespace Oracle.DataAccess.Client;

public sealed class OracleBulkCopyColumnMappingCollection : CollectionBase
{
	private enum MappingType
	{
		Undefined,
		NameName,
		NameIndex,
		IndexName,
		IndexIndex
	}

	private bool m_bulkCopyInProgress;

	public OracleBulkCopyColumnMapping this[int index]
	{
		get
		{
			return (OracleBulkCopyColumnMapping)base.List[index];
		}
		set
		{
			base.List[index] = value;
		}
	}

	internal bool BulkCopyInProgress
	{
		get
		{
			return m_bulkCopyInProgress;
		}
		set
		{
			m_bulkCopyInProgress = value;
		}
	}

	static OracleBulkCopyColumnMappingCollection()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public OracleBulkCopyColumnMapping Add(OracleBulkCopyColumnMapping bulkCopyColumnMapping)
	{
		if (BulkCopyInProgress)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.BC_OPER_IN_PROGRESS));
		}
		if (bulkCopyColumnMapping.SourceOrdinal == -1 && IsEmpty(bulkCopyColumnMapping.SourceColumn))
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "Column mapping"));
		}
		if (bulkCopyColumnMapping.DestinationOrdinal == -1 && IsEmpty(bulkCopyColumnMapping.DestinationColumn))
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "Column mapping"));
		}
		base.InnerList.Add(bulkCopyColumnMapping);
		return bulkCopyColumnMapping;
	}

	public OracleBulkCopyColumnMapping Add(int sourceColumnIndex, int destinationColumnIndex)
	{
		if (BulkCopyInProgress)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.BC_OPER_IN_PROGRESS));
		}
		OracleBulkCopyColumnMapping bulkCopyColumnMapping = new OracleBulkCopyColumnMapping(sourceColumnIndex, destinationColumnIndex);
		return Add(bulkCopyColumnMapping);
	}

	public OracleBulkCopyColumnMapping Add(int sourceColumnIndex, string destinationColumn)
	{
		if (BulkCopyInProgress)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.BC_OPER_IN_PROGRESS));
		}
		OracleBulkCopyColumnMapping bulkCopyColumnMapping = new OracleBulkCopyColumnMapping(sourceColumnIndex, destinationColumn);
		return Add(bulkCopyColumnMapping);
	}

	public OracleBulkCopyColumnMapping Add(string sourceColumn, int destinationColumnIndex)
	{
		if (BulkCopyInProgress)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.BC_OPER_IN_PROGRESS));
		}
		OracleBulkCopyColumnMapping bulkCopyColumnMapping = new OracleBulkCopyColumnMapping(sourceColumn, destinationColumnIndex);
		return Add(bulkCopyColumnMapping);
	}

	public OracleBulkCopyColumnMapping Add(string sourceColumn, string destinationColumn)
	{
		if (BulkCopyInProgress)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.BC_OPER_IN_PROGRESS));
		}
		OracleBulkCopyColumnMapping bulkCopyColumnMapping = new OracleBulkCopyColumnMapping(sourceColumn, destinationColumn);
		return Add(bulkCopyColumnMapping);
	}

	public new void Clear()
	{
		if (BulkCopyInProgress)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.BC_OPER_IN_PROGRESS));
		}
		base.Clear();
	}

	public bool Contains(OracleBulkCopyColumnMapping value)
	{
		return -1 != base.InnerList.IndexOf(value);
	}

	public void CopyTo(OracleBulkCopyColumnMapping[] array, int index)
	{
		base.InnerList.CopyTo(array, index);
	}

	public int IndexOf(OracleBulkCopyColumnMapping value)
	{
		return base.InnerList.IndexOf(value);
	}

	public void Insert(int index, OracleBulkCopyColumnMapping value)
	{
		if (BulkCopyInProgress)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.BC_OPER_IN_PROGRESS));
		}
		base.InnerList.Insert(index, value);
	}

	public void Remove(OracleBulkCopyColumnMapping value)
	{
		if (BulkCopyInProgress)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.BC_OPER_IN_PROGRESS));
		}
		base.InnerList.Remove(value);
	}

	public new void RemoveAt(int index)
	{
		if (BulkCopyInProgress)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.BC_OPER_IN_PROGRESS));
		}
		base.RemoveAt(index);
	}

	internal OracleBulkCopyColumnMappingCollection()
	{
	}

	internal void CreateDefaultColumnMapping(int columnCount)
	{
		for (int i = 0; i < columnCount; i++)
		{
			base.InnerList.Add(new OracleBulkCopyColumnMapping(i, i));
		}
	}

	internal void Sort()
	{
		base.InnerList.Sort();
	}

	internal void ValidateCollection()
	{
		MappingType mappingType = MappingType.Undefined;
		foreach (OracleBulkCopyColumnMapping inner in base.InnerList)
		{
			MappingType mappingType2 = ((inner.SourceOrdinal != -1) ? ((inner.DestinationOrdinal == -1) ? MappingType.IndexName : MappingType.IndexIndex) : ((inner.DestinationOrdinal == -1) ? MappingType.NameName : MappingType.NameIndex));
			if (mappingType == MappingType.Undefined)
			{
				mappingType = mappingType2;
			}
			else if (mappingType != mappingType2)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.BC_INV_COL_MAPPINGS));
			}
		}
	}

	internal static bool IsEmpty(string str)
	{
		if (str != null)
		{
			return 0 == str.Length;
		}
		return true;
	}
}
