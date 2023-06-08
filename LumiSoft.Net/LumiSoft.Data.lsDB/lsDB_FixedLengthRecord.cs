using System;
using System.Text;

namespace LumiSoft.Data.lsDB;

public class lsDB_FixedLengthRecord
{
	private lsDB_FixedLengthTable m_pOwnerDb = null;

	private long m_Pointer = -1L;

	private byte[] m_RowData = null;

	private int[] m_ColumnDataSizes = null;

	private LDB_DataType[] m_ColumnDataTypes = null;

	private int[] m_ColumnDataStartOffsets = null;

	private int m_ColumnCount = -1;

	public object this[int columnIndex]
	{
		get
		{
			if (columnIndex < 0)
			{
				throw new Exception("The columnIndex can't be negative value !");
			}
			if (columnIndex > m_ColumnCount)
			{
				throw new Exception("The columnIndex out of columns count !");
			}
			return ConvertFromInternalData(m_ColumnDataTypes[columnIndex], m_RowData, m_ColumnDataStartOffsets[columnIndex], m_ColumnDataSizes[columnIndex]);
		}
		set
		{
			if (columnIndex < 0)
			{
				throw new Exception("The columnIndex can't be negative value !");
			}
			if (columnIndex > m_ColumnCount)
			{
				throw new Exception("The columnIndex out of columns count !");
			}
			byte[] array = LDB_Record.ConvertToInternalData(m_pOwnerDb.Columns[columnIndex], value);
			if (array.Length > m_ColumnDataSizes[columnIndex])
			{
				throw new Exception("Value exceeds maximum allowed value for column '" + m_pOwnerDb.Columns[columnIndex].ColumnName + "' !");
			}
			if (m_ColumnDataTypes[columnIndex] == LDB_DataType.String)
			{
				throw new Exception("TODO: String not implemented !");
			}
			m_pOwnerDb.WriteToFile(m_Pointer + m_ColumnDataStartOffsets[columnIndex], array, 0, array.Length);
			Array.Copy(array, 0, m_RowData, m_ColumnDataStartOffsets[columnIndex], array.Length);
		}
	}

	internal long Pointer => m_Pointer;

	internal lsDB_FixedLengthRecord(lsDB_FixedLengthTable ownerDb, long pointer, byte[] rowData)
	{
		m_pOwnerDb = ownerDb;
		m_Pointer = pointer;
		m_RowData = rowData;
		m_ColumnCount = ownerDb.Columns.Count;
		m_ColumnDataTypes = new LDB_DataType[m_ColumnCount];
		m_ColumnDataSizes = new int[m_ColumnCount];
		for (int i = 0; i < m_ColumnDataSizes.Length; i++)
		{
			m_ColumnDataTypes[i] = m_pOwnerDb.Columns[i].DataType;
			m_ColumnDataSizes[i] = m_pOwnerDb.Columns[i].ColumnSize;
		}
		m_ColumnDataStartOffsets = new int[m_ColumnCount];
		int num = 1;
		for (int i = 0; i < m_ColumnDataStartOffsets.Length; i++)
		{
			m_ColumnDataStartOffsets[i] = num;
			num += m_pOwnerDb.Columns[i].ColumnSize;
		}
	}

	internal void ReuseRecord(lsDB_FixedLengthTable ownerDb, long pointer, byte[] rowData)
	{
		m_pOwnerDb = ownerDb;
		m_Pointer = pointer;
		m_RowData = rowData;
	}

	public static object ConvertFromInternalData(LDB_DataType dataType, byte[] val, int offset, int length)
	{
		switch (dataType)
		{
		case LDB_DataType.Bool:
			return Convert.ToBoolean(val[offset]);
		case LDB_DataType.DateTime:
		{
			int day = val[offset];
			int month = val[offset + 1];
			int year = ldb_Utils.ByteToInt(val, offset + 2);
			int hour = val[offset + 6];
			int minute = val[offset + 7];
			int second = val[offset + 8];
			return new DateTime(year, month, day, hour, minute, second);
		}
		case LDB_DataType.Long:
			return ldb_Utils.ByteToLong(val, offset);
		case LDB_DataType.Int:
			return ldb_Utils.ByteToInt(val, offset);
		case LDB_DataType.String:
			return Encoding.UTF8.GetString(val, offset, length);
		default:
			throw new Exception("Invalid column data type, never must reach here !");
		}
	}
}
