using System;
using System.Collections.Generic;

namespace LumiSoft.Data.lsDB;

public class LDB_DataColumnCollection
{
	private object m_pOwner = null;

	private List<LDB_DataColumn> m_pColumns = null;

	public LDB_DataColumn this[int index] => m_pColumns[index];

	public int Count => m_pColumns.Count;

	internal LDB_DataColumnCollection(object owner)
	{
		m_pOwner = owner;
		m_pColumns = new List<LDB_DataColumn>();
	}

	public void Add(LDB_DataColumn column)
	{
		if (Contains(column.ColumnName))
		{
			throw new Exception("Data column with specified name '" + column.ColumnName + "' already exists !");
		}
		if (m_pOwner.GetType() == typeof(DbFile))
		{
			((DbFile)m_pOwner).AddColumn(column);
		}
		else if (m_pOwner.GetType() == typeof(lsDB_FixedLengthTable))
		{
			((lsDB_FixedLengthTable)m_pOwner).AddColumn(column);
		}
		m_pColumns.Add(column);
	}

	public void Remove(string columName)
	{
		foreach (LDB_DataColumn pColumn in m_pColumns)
		{
			if (pColumn.ColumnName.ToLower() == columName.ToLower())
			{
				Remove(pColumn);
				break;
			}
		}
	}

	public void Remove(LDB_DataColumn column)
	{
		m_pColumns.Remove(column);
	}

	public int IndexOf(string columnName)
	{
		for (int i = 0; i < m_pColumns.Count; i++)
		{
			if (m_pColumns[i].ColumnName.ToLower() == columnName.ToLower())
			{
				return i;
			}
		}
		return -1;
	}

	public int IndexOf(LDB_DataColumn column)
	{
		return m_pColumns.IndexOf(column);
	}

	public bool Contains(string columnName)
	{
		foreach (LDB_DataColumn pColumn in m_pColumns)
		{
			if (pColumn.ColumnName.ToLower() == columnName.ToLower())
			{
				return true;
			}
		}
		return false;
	}

	public bool Contains(LDB_DataColumn column)
	{
		return m_pColumns.Contains(column);
	}

	internal void Parse(byte[] columnData)
	{
		LDB_DataColumn lDB_DataColumn = new LDB_DataColumn();
		lDB_DataColumn.Parse(columnData);
		m_pColumns.Add(lDB_DataColumn);
	}

	public IEnumerator<LDB_DataColumn> GetEnumerator()
	{
		return m_pColumns.GetEnumerator();
	}
}
