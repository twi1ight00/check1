using System;
using System.Text;

namespace LumiSoft.Data.lsDB;

public class LDB_DataColumn
{
	private LDB_DataType m_DataType = LDB_DataType.String;

	private string m_ColumnName = "";

	private int m_ColumSize = -1;

	public LDB_DataType DataType => m_DataType;

	public string ColumnName => m_ColumnName;

	public int ColumnSize => m_ColumSize;

	public LDB_DataColumn(string columnName, LDB_DataType dataType)
		: this(columnName, dataType, -1)
	{
	}

	public LDB_DataColumn(string columnName, LDB_DataType dataType, int columnSize)
	{
		m_ColumnName = columnName;
		m_DataType = dataType;
		switch (dataType)
		{
		case LDB_DataType.Bool:
			m_ColumSize = 1;
			break;
		case LDB_DataType.DateTime:
			m_ColumSize = 13;
			break;
		case LDB_DataType.Int:
			m_ColumSize = 4;
			break;
		case LDB_DataType.Long:
			m_ColumSize = 8;
			break;
		default:
			m_ColumSize = columnSize;
			break;
		}
	}

	internal LDB_DataColumn()
	{
	}

	internal void Parse(byte[] columnData)
	{
		if (columnData.Length != 102)
		{
			throw new Exception("Invalid column data length '" + columnData.Length + "' !");
		}
		m_DataType = (LDB_DataType)columnData[0];
		m_ColumSize = (columnData[1] << 24) | (columnData[2] << 16) | (columnData[3] << 8) | columnData[4];
		byte[] array = new byte[50];
		Array.Copy(columnData, 50, array, 0, array.Length);
		m_ColumnName = GetChar0TerminatedString(Encoding.UTF8.GetString(array));
		if (m_DataType == LDB_DataType.Bool)
		{
			m_ColumSize = 1;
		}
		else if (m_DataType == LDB_DataType.DateTime)
		{
			m_ColumSize = 13;
		}
		else if (m_DataType == LDB_DataType.Int)
		{
			m_ColumSize = 4;
		}
		else if (m_DataType == LDB_DataType.Long)
		{
			m_ColumSize = 8;
		}
	}

	internal byte[] ToColumnInfo()
	{
		byte[] array = new byte[102];
		array[0] = (byte)m_DataType;
		array[1] = (byte)((m_ColumSize & 0x1000000) >> 24);
		array[2] = (byte)((m_ColumSize & 0x10000) >> 16);
		array[3] = (byte)((m_ColumSize & 0x100) >> 8);
		array[4] = (byte)((uint)m_ColumSize & 1u);
		byte[] bytes = Encoding.UTF8.GetBytes(m_ColumnName);
		Array.Copy(bytes, 0, array, 50, bytes.Length);
		array[100] = 13;
		array[101] = 10;
		return array;
	}

	internal static string GetChar0TerminatedString(string text)
	{
		if (text.IndexOf('\0') > -1)
		{
			return text.Substring(0, text.IndexOf('\0'));
		}
		return text;
	}
}
