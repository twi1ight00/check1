using System;
using System.Collections;
using System.IO;
using System.Text;

namespace LumiSoft.Data.lsDB;

public class LDB_Record
{
	private DbFile m_pOwnerDb = null;

	private DataPage m_pDataPage = null;

	private int[] m_ColumnValueSize = null;

	public object[] Values
	{
		get
		{
			object[] array = new object[m_pOwnerDb.Columns.Count];
			for (int i = 0; i < m_pOwnerDb.Columns.Count; i++)
			{
				array[i] = this[i];
			}
			return array;
		}
		set
		{
			UpdateRecord(value);
		}
	}

	public object this[int columnIndex]
	{
		get
		{
			if (columnIndex < 0)
			{
				throw new Exception("The columnIndex can't be negative value !");
			}
			if (columnIndex > m_pOwnerDb.Columns.Count)
			{
				throw new Exception("The columnIndex out of columns count !");
			}
			return GetColumnData(columnIndex);
		}
		set
		{
			if (columnIndex < 0)
			{
				throw new Exception("The columnIndex can't be negative value !");
			}
			if (columnIndex > m_pOwnerDb.Columns.Count)
			{
				throw new Exception("The columnIndex out of columns count !");
			}
			object[] values = Values;
			values[columnIndex] = value;
			UpdateRecord(values);
		}
	}

	public object this[string columnName]
	{
		get
		{
			int num = m_pOwnerDb.Columns.IndexOf(columnName);
			if (num == -1)
			{
				throw new Exception("Table doesn't contain column '" + columnName + "' !");
			}
			return this[num];
		}
		set
		{
			int num = m_pOwnerDb.Columns.IndexOf(columnName);
			if (num == -1)
			{
				throw new Exception("Table doesn't contain column '" + columnName + "' !");
			}
			this[num] = value;
		}
	}

	public object this[LDB_DataColumn column]
	{
		get
		{
			int num = m_pOwnerDb.Columns.IndexOf(column);
			if (num == -1)
			{
				throw new Exception("Table doesn't contain column '" + column.ColumnName + "' !");
			}
			return this[num];
		}
		set
		{
			int num = m_pOwnerDb.Columns.IndexOf(column);
			if (num == -1)
			{
				throw new Exception("Table doesn't contain column '" + column.ColumnName + "' !");
			}
			this[num] = value;
		}
	}

	internal DataPage DataPage => m_pDataPage;

	internal DataPage[] DataPages
	{
		get
		{
			ArrayList arrayList = new ArrayList();
			DataPage dataPage = m_pDataPage;
			arrayList.Add(dataPage);
			while (dataPage.NextDataPagePointer > 0)
			{
				dataPage = new DataPage(m_pOwnerDb.DataPageDataAreaSize, m_pOwnerDb, dataPage.NextDataPagePointer);
				arrayList.Add(dataPage);
			}
			DataPage[] array = new DataPage[arrayList.Count];
			arrayList.CopyTo(array);
			return array;
		}
	}

	internal LDB_Record(DbFile ownerDb, DataPage rowStartDataPage)
	{
		m_pOwnerDb = ownerDb;
		m_pDataPage = rowStartDataPage;
		ParseRowInfo();
	}

	internal static byte[] CreateRecord(DbFile ownerDb, object[] rowValues)
	{
		if (ownerDb.Columns.Count != rowValues.Length)
		{
			throw new Exception("LDB_Record.CreateRecord m_pOwnerDb.Columns.Count != rowValues.Length !");
		}
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < rowValues.Length; i++)
		{
			arrayList.Add(ConvertToInternalData(ownerDb.Columns[i], rowValues[i]));
		}
		MemoryStream memoryStream = new MemoryStream();
		for (int i = 0; i < arrayList.Count; i++)
		{
			memoryStream.Write(ldb_Utils.IntToByte(((byte[])arrayList[i]).Length), 0, 4);
		}
		for (int i = 0; i < arrayList.Count; i++)
		{
			byte[] array = (byte[])arrayList[i];
			memoryStream.Write(array, 0, array.Length);
		}
		return memoryStream.ToArray();
	}

	private void ParseRowInfo()
	{
		m_ColumnValueSize = new int[m_pOwnerDb.Columns.Count];
		byte[] array = m_pDataPage.ReadData(0, 4 * m_pOwnerDb.Columns.Count);
		for (int i = 0; i < m_pOwnerDb.Columns.Count; i++)
		{
			m_ColumnValueSize[i] = ldb_Utils.ByteToInt(array, i * 4);
		}
	}

	private object GetColumnData(int columnIndex)
	{
		int num = 4 * m_pOwnerDb.Columns.Count;
		for (int i = 0; i < columnIndex; i++)
		{
			num += m_ColumnValueSize[i];
		}
		int num2 = m_ColumnValueSize[columnIndex];
		int num3 = (int)Math.Floor((double)num / (double)m_pOwnerDb.DataPageDataAreaSize);
		int num4 = num - num3 * m_pOwnerDb.DataPageDataAreaSize;
		int num5 = 0;
		int num6 = 0;
		byte[] array = new byte[num2];
		DataPage dataPage = DataPage;
		while (num5 < num2)
		{
			if (num6 < num3)
			{
				dataPage = new DataPage(m_pOwnerDb.DataPageDataAreaSize, m_pOwnerDb, dataPage.NextDataPagePointer);
				num6++;
			}
			else if (num2 - num5 + num4 > dataPage.StoredDataLength)
			{
				dataPage.ReadData(array, num5, m_pOwnerDb.DataPageDataAreaSize - num4, num4);
				num5 += m_pOwnerDb.DataPageDataAreaSize - num4;
				dataPage = new DataPage(m_pOwnerDb.DataPageDataAreaSize, m_pOwnerDb, dataPage.NextDataPagePointer);
				num6++;
				num4 = 0;
			}
			else
			{
				dataPage.ReadData(array, num5, num2 - num5, num4);
				num5 += num2 - num5;
				num4 = 0;
			}
		}
		return ConvertFromInternalData(m_pOwnerDb.Columns[columnIndex], array);
	}

	private void UpdateRecord(object[] rowValues)
	{
		bool flag = true;
		if (m_pOwnerDb.TableLocked)
		{
			flag = false;
		}
		else
		{
			m_pOwnerDb.LockTable(15);
		}
		byte[] array = CreateRecord(m_pOwnerDb, rowValues);
		DataPage[] array2 = DataPages;
		if ((int)Math.Ceiling((double)array.Length / (double)m_pOwnerDb.DataPageDataAreaSize) > array2.Length)
		{
			int count = (int)Math.Ceiling((double)array.Length / (double)m_pOwnerDb.DataPageDataAreaSize) - array2.Length;
			DataPage[] dataPages = m_pOwnerDb.GetDataPages(array2[array2.Length - 1].Pointer, count);
			array2[array2.Length - 1].NextDataPagePointer = dataPages[0].Pointer;
			DataPage[] array3 = new DataPage[array2.Length + dataPages.Length];
			Array.Copy(array2, 0, array3, 0, array2.Length);
			Array.Copy(dataPages, 0, array3, array2.Length, dataPages.Length);
			array2 = array3;
		}
		DbFile.StoreDataToDataPages(m_pOwnerDb.DataPageDataAreaSize, array, array2);
		ParseRowInfo();
		if (flag)
		{
			m_pOwnerDb.UnlockTable();
		}
	}

	internal static byte[] ConvertToInternalData(LDB_DataColumn coulmn, object val)
	{
		if (val == null)
		{
			throw new Exception("Null values aren't supported !");
		}
		if (coulmn.DataType == LDB_DataType.Bool)
		{
			if (val.GetType() != typeof(bool))
			{
				throw new Exception("Column '" + coulmn.ColumnName + "' requires datatype of bool, but value contains '" + val.GetType().ToString() + "' !");
			}
			return new byte[1] { Convert.ToByte((bool)val) };
		}
		if (coulmn.DataType == LDB_DataType.DateTime)
		{
			if (val.GetType() != typeof(DateTime))
			{
				throw new Exception("Column '" + coulmn.ColumnName + "' requires datatype of DateTime, but value contains '" + val.GetType().ToString() + "' !");
			}
			DateTime dateTime = (DateTime)val;
			byte[] array = new byte[13]
			{
				(byte)dateTime.Day,
				(byte)dateTime.Month,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
			Array.Copy(ldb_Utils.IntToByte(dateTime.Year), 0, array, 2, 4);
			array[6] = (byte)dateTime.Hour;
			array[7] = (byte)dateTime.Minute;
			array[8] = (byte)dateTime.Second;
			return array;
		}
		if (coulmn.DataType == LDB_DataType.Long)
		{
			if (val.GetType() != typeof(long))
			{
				throw new Exception("Column '" + coulmn.ColumnName + "' requires datatype of Long, but value contains '" + val.GetType().ToString() + "' !");
			}
			return ldb_Utils.LongToByte((long)val);
		}
		if (coulmn.DataType == LDB_DataType.Int)
		{
			if (val.GetType() != typeof(int))
			{
				throw new Exception("Column '" + coulmn.ColumnName + "' requires datatype of Int, but value contains '" + val.GetType().ToString() + "' !");
			}
			return ldb_Utils.IntToByte((int)val);
		}
		if (coulmn.DataType == LDB_DataType.String)
		{
			if (val.GetType() != typeof(string))
			{
				throw new Exception("Column '" + coulmn.ColumnName + "' requires datatype of String, but value contains '" + val.GetType().ToString() + "' !");
			}
			return Encoding.UTF8.GetBytes(val.ToString());
		}
		throw new Exception("Invalid column data type, never must reach here !");
	}

	internal static object ConvertFromInternalData(LDB_DataColumn coulmn, byte[] val)
	{
		if (coulmn.DataType == LDB_DataType.Bool)
		{
			return Convert.ToBoolean(val[0]);
		}
		if (coulmn.DataType == LDB_DataType.DateTime)
		{
			byte[] array = new byte[13];
			int day = val[0];
			int month = val[1];
			int year = ldb_Utils.ByteToInt(val, 2);
			int hour = val[6];
			int minute = val[7];
			int second = val[8];
			return new DateTime(year, month, day, hour, minute, second);
		}
		if (coulmn.DataType == LDB_DataType.Long)
		{
			return ldb_Utils.ByteToLong(val, 0);
		}
		if (coulmn.DataType == LDB_DataType.Int)
		{
			return ldb_Utils.ByteToInt(val, 0);
		}
		if (coulmn.DataType == LDB_DataType.String)
		{
			return Encoding.UTF8.GetString(val);
		}
		throw new Exception("Invalid column data type, never must reach here !");
	}
}
