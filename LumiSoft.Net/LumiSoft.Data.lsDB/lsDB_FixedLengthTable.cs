using System;
using System.IO;
using System.Threading;

namespace LumiSoft.Data.lsDB;

public class lsDB_FixedLengthTable : IDisposable
{
	private LDB_DataColumnCollection m_pColumns = null;

	private FileStream m_pDbFile = null;

	private string m_DbFileName = "";

	private bool m_TableLocked = false;

	private long m_RowsStartOffset = -1L;

	private long m_ColumnsStartOffset = -1L;

	private int m_RowLength = -1;

	private byte[] m_RowDataBuffer = null;

	private lsDB_FixedLengthRecord m_pCurrentRecord = null;

	private long m_FileLength = 0L;

	private long m_FilePosition = 0L;

	public bool IsDatabaseOpen => m_pDbFile != null;

	public string FileName
	{
		get
		{
			if (!IsDatabaseOpen)
			{
				throw new Exception("Database isn't open, please open database first !");
			}
			return m_DbFileName;
		}
	}

	public LDB_DataColumnCollection Columns
	{
		get
		{
			if (!IsDatabaseOpen)
			{
				throw new Exception("Database isn't open, please open database first !");
			}
			return m_pColumns;
		}
	}

	public lsDB_FixedLengthRecord CurrentRecord => m_pCurrentRecord;

	public bool TableLocked => m_TableLocked;

	public lsDB_FixedLengthTable()
	{
		m_pColumns = new LDB_DataColumnCollection(this);
	}

	public void Dispose()
	{
		Close();
	}

	public void Open(string fileName)
	{
		Open(fileName, 0);
	}

	public void Open(string fileName, int waitTime)
	{
		DateTime dateTime = DateTime.Now.AddSeconds(waitTime);
		while (true)
		{
			bool flag = true;
			try
			{
				m_pDbFile = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
			}
			catch (IOException ex)
			{
				if (!File.Exists(fileName))
				{
					throw new Exception("Specified database file '" + fileName + "' does not exists !");
				}
				string message = ex.Message;
				Thread.Sleep(15);
				if (DateTime.Now > dateTime)
				{
					throw new Exception("Database file is locked and lock wait time expired !");
				}
				continue;
			}
			break;
		}
		m_DbFileName = fileName;
		byte[] array = new byte[52];
		ReadFromFile(0L, array, 0, array.Length);
		byte[] array2 = new byte[6];
		ReadFromFile(0L, array2, 0, array2.Length);
		long num = 58L;
		for (int i = 0; i < 100; i++)
		{
			byte[] array3 = new byte[102];
			if (ReadFromFile(num, array3, 0, array3.Length) != array3.Length)
			{
				throw new Exception("Invalid columns data area length !");
			}
			if (array3[0] != 0)
			{
				m_pColumns.Parse(array3);
			}
			num += 102;
		}
		m_pDbFile.Position++;
		m_RowsStartOffset = m_pDbFile.Position;
		m_FileLength = m_pDbFile.Length;
		m_FilePosition = m_pDbFile.Position;
		m_RowLength = 3;
		for (int i = 0; i < m_pColumns.Count; i++)
		{
			m_RowLength += m_pColumns[i].ColumnSize;
		}
		m_RowDataBuffer = new byte[m_RowLength];
	}

	public void Close()
	{
		if (m_pDbFile != null)
		{
			m_pDbFile.Close();
			m_pDbFile = null;
			m_DbFileName = "";
			m_FileLength = 0L;
			m_FilePosition = 0L;
			m_RowLength = 0;
			m_ColumnsStartOffset = 0L;
			m_RowsStartOffset = 0L;
			m_TableLocked = false;
			m_RowDataBuffer = null;
			m_pCurrentRecord = null;
		}
	}

	public void Create(string fileName)
	{
		m_pDbFile = new FileStream(fileName, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None);
		byte[] array = new byte[52];
		array[0] = 49;
		array[1] = 46;
		array[2] = 48;
		array[50] = 13;
		array[51] = 10;
		m_pDbFile.Write(array, 0, array.Length);
		byte[] array2 = new byte[6] { 0, 0, 0, 0, 13, 10 };
		m_pDbFile.Write(array2, 0, array2.Length);
		m_ColumnsStartOffset = m_pDbFile.Position;
		for (int i = 0; i < 100; i++)
		{
			byte[] array3 = new byte[100];
			m_pDbFile.Write(array3, 0, array3.Length);
			m_pDbFile.Write(new byte[2] { 13, 10 }, 0, 2);
		}
		m_pDbFile.WriteByte(0);
		m_RowsStartOffset = m_pDbFile.Position - 1;
		m_DbFileName = fileName;
		m_FileLength = m_pDbFile.Length;
		m_FilePosition = m_pDbFile.Position;
	}

	public void LockTable(int waitTime)
	{
		if (!IsDatabaseOpen)
		{
			throw new Exception("Database isn't open, please open database first !");
		}
		if (m_TableLocked)
		{
			return;
		}
		DateTime dateTime = DateTime.Now.AddSeconds(waitTime);
		while (true)
		{
			bool flag = true;
			try
			{
				m_pDbFile.Lock(0L, 1L);
				m_TableLocked = true;
				break;
			}
			catch (IOException ex)
			{
				string message = ex.Message;
				Thread.Sleep(15);
				if (DateTime.Now > dateTime)
				{
					throw new Exception("Table is locked and lock wait time expired !");
				}
			}
		}
	}

	public void UnlockTable()
	{
		if (!IsDatabaseOpen)
		{
			throw new Exception("Database isn't open, please open database first !");
		}
		if (m_TableLocked)
		{
			m_pDbFile.Unlock(0L, 1L);
		}
	}

	public void MoveFirstRecord()
	{
		m_pCurrentRecord = null;
	}

	public bool NextRecord()
	{
		if (!IsDatabaseOpen)
		{
			throw new Exception("Database isn't open, please open database first !");
		}
		long num = 0L;
		num = ((m_pCurrentRecord != null) ? (m_pCurrentRecord.Pointer + m_RowLength) : m_RowsStartOffset);
		while (true)
		{
			bool flag = true;
			if (m_FileLength > num)
			{
				ReadFromFile(num, m_RowDataBuffer, 0, m_RowLength);
				if (m_RowDataBuffer[0] == 117)
				{
					if (m_pCurrentRecord == null)
					{
						m_pCurrentRecord = new lsDB_FixedLengthRecord(this, num, m_RowDataBuffer);
					}
					else
					{
						m_pCurrentRecord.ReuseRecord(this, num, m_RowDataBuffer);
					}
					break;
				}
				num += m_RowLength;
				continue;
			}
			return true;
		}
		return false;
	}

	public void AppendRecord(object[] values)
	{
		if (!IsDatabaseOpen)
		{
			throw new Exception("Database isn't open, please open database first !");
		}
		if (m_pColumns.Count != values.Length)
		{
			throw new Exception("Each column must have corresponding value !");
		}
		bool flag = true;
		if (TableLocked)
		{
			flag = false;
		}
		else
		{
			LockTable(15);
		}
		int num = 3;
		for (int i = 0; i < m_pColumns.Count; i++)
		{
			num += m_pColumns[i].ColumnSize;
		}
		int num2 = 1;
		byte[] array = new byte[num];
		array[0] = 117;
		array[num - 2] = 13;
		array[num - 1] = 10;
		for (int i = 0; i < values.Length; i++)
		{
			byte[] array2 = LDB_Record.ConvertToInternalData(m_pColumns[i], values[i]);
			if (array2.Length > m_pColumns[i].ColumnSize)
			{
				throw new Exception(string.Concat("Column '", m_pColumns[i], "' exceeds maximum value length !"));
			}
			Array.Copy(array2, 0, array, num2, array2.Length);
			num2 += array2.Length;
		}
		byte[] array3 = new byte[4];
		ReadFromFile(52L, array3, 0, array3.Length);
		int num3 = ldb_Utils.ByteToInt(array3, 0);
		if (num3 > 100)
		{
			long num4 = m_RowsStartOffset;
			long num5 = 0L;
			byte[] array4 = new byte[m_RowLength];
			while (true)
			{
				bool flag2 = true;
				ReadFromFile(num4, array4, 0, m_RowLength);
				if (array4[0] == 102)
				{
					break;
				}
				num4 += m_RowLength;
			}
			num5 = num4;
			WriteToFile(num5, array, 0, array.Length);
			WriteToFile(52L, ldb_Utils.IntToByte(num3 - 1), 0, 4);
		}
		else
		{
			AppendToFile(array, 0, array.Length);
		}
		if (flag)
		{
			UnlockTable();
		}
	}

	public void DeleteCurrentRecord()
	{
		if (!IsDatabaseOpen)
		{
			throw new Exception("Database isn't open, please open database first !");
		}
		if (m_pCurrentRecord == null)
		{
			throw new Exception("There is no current record !");
		}
		bool flag = true;
		if (TableLocked)
		{
			flag = false;
		}
		else
		{
			LockTable(15);
		}
		byte[] array = new byte[m_RowLength];
		array[0] = 102;
		array[m_RowLength - 2] = 13;
		array[m_RowLength - 1] = 10;
		WriteToFile(m_pCurrentRecord.Pointer, array, 0, array.Length);
		byte[] array2 = new byte[4];
		ReadFromFile(52L, array2, 0, array2.Length);
		int num = ldb_Utils.ByteToInt(array2, 0);
		WriteToFile(52L, ldb_Utils.IntToByte(num + 1), 0, 4);
		if (flag)
		{
			UnlockTable();
		}
		NextRecord();
	}

	internal void AddColumn(LDB_DataColumn column)
	{
		if (column.ColumnSize < 1)
		{
			throw new Exception("Invalid column size '" + column.ColumnSize + "' for column '" + column.ColumnName + "' !");
		}
		long num = m_ColumnsStartOffset;
		long num2 = -1L;
		for (int i = 0; i < 100; i++)
		{
			byte[] array = new byte[102];
			if (ReadFromFile(num, array, 0, array.Length) != array.Length)
			{
				throw new Exception("Invalid columns data area length !");
			}
			if (array[0] == 0)
			{
				num2 = num - 102;
				break;
			}
			num += 102;
		}
		if (num2 != -1)
		{
			byte[] array2 = column.ToColumnInfo();
			WriteToFile(num, array2, 0, array2.Length);
			return;
		}
		throw new Exception("Couldn't find free column space ! ");
	}

	internal void RemoveColumn(LDB_DataColumn column)
	{
		throw new Exception("TODO:");
	}

	internal int ReadFromFile(long readOffset, byte[] data, int offset, int count)
	{
		SetFilePosition(readOffset);
		int num = m_pDbFile.Read(data, offset, count);
		m_FilePosition += num;
		return num;
	}

	internal void WriteToFile(long writeOffset, byte[] data, int offset, int count)
	{
		SetFilePosition(writeOffset);
		m_pDbFile.Write(data, offset, count);
		m_FilePosition += count;
	}

	internal void AppendToFile(byte[] data, int offset, int count)
	{
		m_pDbFile.Position = m_pDbFile.Length;
		m_pDbFile.Write(data, offset, count);
		m_FileLength = m_pDbFile.Length;
		m_FilePosition = m_pDbFile.Position;
	}

	internal long GetFilePosition()
	{
		return m_FilePosition;
	}

	private void SetFilePosition(long position)
	{
		if (m_FilePosition != position)
		{
			m_pDbFile.Position = position;
			m_FilePosition = position;
		}
	}
}
