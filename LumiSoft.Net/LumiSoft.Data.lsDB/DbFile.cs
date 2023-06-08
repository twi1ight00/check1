using System;
using System.Collections;
using System.IO;
using System.Threading;
using LumiSoft.Net;

namespace LumiSoft.Data.lsDB;

public class DbFile : IDisposable
{
	private LDB_DataColumnCollection m_pColumns = null;

	private FileStream m_pDbFile = null;

	private string m_DbFileName = "";

	private long m_DatapagesStartOffset = -1L;

	private LDB_Record m_pCurrentRecord = null;

	private bool m_TableLocked = false;

	private int m_DataPageDataAreaSize = 1000;

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

	public LDB_Record CurrentRecord => m_pCurrentRecord;

	public bool TableLocked => m_TableLocked;

	public int DataPageDataAreaSize => m_DataPageDataAreaSize;

	public DbFile()
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
		StreamLineReader streamLineReader = new StreamLineReader(m_pDbFile);
		byte[] array = streamLineReader.ReadLine();
		byte[] array2 = new byte[10];
		m_pDbFile.Read(array2, 0, array2.Length);
		byte[] array3 = new byte[6];
		m_pDbFile.Read(array3, 0, array3.Length);
		m_DataPageDataAreaSize = ldb_Utils.ByteToInt(array3, 0);
		for (int i = 0; i < 100; i++)
		{
			byte[] array4 = streamLineReader.ReadLine();
			if (array4 == null)
			{
				throw new Exception("Invalid columns data area length !");
			}
			if (array4[0] != 0)
			{
				m_pColumns.Parse(array4);
			}
		}
		m_pDbFile.Position++;
		m_DatapagesStartOffset = m_pDbFile.Position;
		m_FileLength = m_pDbFile.Length;
		m_FilePosition = m_pDbFile.Position;
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
		}
	}

	public void Create(string fileName)
	{
		Create(fileName, 1000);
	}

	public void Create(string fileName, int dataPageDataAreaSize)
	{
		m_pDbFile = new FileStream(fileName, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None);
		byte[] array = new byte[52];
		array[0] = 49;
		array[1] = 46;
		array[2] = 48;
		array[50] = 13;
		array[51] = 10;
		m_pDbFile.Write(array, 0, array.Length);
		byte[] array2 = new byte[10] { 0, 0, 0, 0, 0, 0, 0, 0, 13, 10 };
		m_pDbFile.Write(array2, 0, array2.Length);
		byte[] array3 = new byte[6];
		Array.Copy(ldb_Utils.IntToByte(dataPageDataAreaSize), 0, array3, 0, 4);
		array3[4] = 13;
		array3[5] = 10;
		m_pDbFile.Write(array3, 0, array3.Length);
		for (int i = 0; i < 100; i++)
		{
			byte[] array4 = new byte[100];
			m_pDbFile.Write(array4, 0, array4.Length);
			m_pDbFile.Write(new byte[2] { 13, 10 }, 0, 2);
		}
		m_pDbFile.WriteByte(0);
		m_DatapagesStartOffset = m_pDbFile.Position - 1;
		m_DbFileName = fileName;
		m_DataPageDataAreaSize = dataPageDataAreaSize;
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

	public bool NextRecord()
	{
		if (!IsDatabaseOpen)
		{
			throw new Exception("Database isn't open, please open database first !");
		}
		long num = 0L;
		num = ((m_pCurrentRecord != null) ? (m_pCurrentRecord.DataPage.Pointer + m_DataPageDataAreaSize + 33) : m_DatapagesStartOffset);
		while (true)
		{
			bool flag = true;
			if (m_FileLength <= num)
			{
				break;
			}
			DataPage dataPage = new DataPage(m_DataPageDataAreaSize, this, num);
			if (dataPage.Used && dataPage.OwnerDataPagePointer < 1)
			{
				m_pCurrentRecord = new LDB_Record(this, dataPage);
				return false;
			}
			num += m_DataPageDataAreaSize + 33;
		}
		return true;
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
		byte[] array = LDB_Record.CreateRecord(this, values);
		DataPage[] dataPages = GetDataPages(0L, (int)Math.Ceiling((double)array.Length / (double)m_DataPageDataAreaSize));
		StoreDataToDataPages(m_DataPageDataAreaSize, array, dataPages);
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
		DataPage[] dataPages = m_pCurrentRecord.DataPages;
		foreach (DataPage dataPage in dataPages)
		{
			byte[] array = DataPage.CreateDataPage(m_DataPageDataAreaSize, used: false, 0L, 0L, 0L, new byte[m_DataPageDataAreaSize]);
			SetFilePosition(dataPage.Pointer);
			WriteToFile(array, 0, array.Length);
		}
		byte[] array2 = new byte[8];
		SetFilePosition(52L);
		ReadFromFile(array2, 0, array2.Length);
		array2 = ldb_Utils.LongToByte(ldb_Utils.ByteToLong(array2, 0) + dataPages.Length);
		SetFilePosition(52L);
		WriteToFile(array2, 0, array2.Length);
		if (flag)
		{
			UnlockTable();
		}
		NextRecord();
	}

	internal static void StoreDataToDataPages(int dataPageDataAreaSize, byte[] data, DataPage[] dataPages)
	{
		if ((int)Math.Ceiling((double)data.Length / (double)dataPageDataAreaSize) > dataPages.Length)
		{
			throw new Exception("There isn't enough data pages to store data ! Data needs '" + (int)Math.Ceiling((double)data.Length / (double)dataPageDataAreaSize) + "' , but available '" + dataPages.Length + "'.");
		}
		long num = 0L;
		for (int i = 0; i < dataPages.Length; i++)
		{
			if (data.Length - num > dataPageDataAreaSize)
			{
				byte[] array = new byte[dataPageDataAreaSize];
				Array.Copy(data, num, array, 0L, array.Length);
				dataPages[i].WriteData(array);
				num += dataPageDataAreaSize;
			}
			else
			{
				byte[] array = new byte[data.Length - num];
				Array.Copy(data, num, array, 0L, array.Length);
				dataPages[i].WriteData(array);
			}
		}
	}

	internal DataPage[] GetDataPages(long ownerDataPagePointer, int count)
	{
		if (!TableLocked)
		{
			throw new Exception("Table must be locked to acess GetDataPages() method !");
		}
		ArrayList arrayList = new ArrayList();
		byte[] array = new byte[8];
		SetFilePosition(52L);
		ReadFromFile(array, 0, array.Length);
		long num = ldb_Utils.ByteToLong(array, 0);
		if (num > 1000 && num > count)
		{
			long num2 = m_DatapagesStartOffset + 1;
			while (arrayList.Count < count)
			{
				DataPage dataPage = new DataPage(m_DataPageDataAreaSize, this, num2);
				if (!dataPage.Used)
				{
					dataPage.Used = true;
					arrayList.Add(dataPage);
				}
				num2 += m_DataPageDataAreaSize + 33;
			}
			SetFilePosition(52L);
			ReadFromFile(ldb_Utils.LongToByte(num - count), 0, 8);
		}
		else
		{
			for (int i = 0; i < count; i++)
			{
				byte[] array2 = DataPage.CreateDataPage(m_DataPageDataAreaSize, used: true, 0L, 0L, 0L, new byte[m_DataPageDataAreaSize]);
				GoToFileEnd();
				long filePosition = GetFilePosition();
				WriteToFile(array2, 0, array2.Length);
				arrayList.Add(new DataPage(m_DataPageDataAreaSize, this, filePosition));
			}
		}
		for (int i = 0; i < arrayList.Count; i++)
		{
			if (i == 0)
			{
				if (ownerDataPagePointer > 0)
				{
					((DataPage)arrayList[i]).OwnerDataPagePointer = ownerDataPagePointer;
				}
				if (arrayList.Count > 1)
				{
					((DataPage)arrayList[i]).NextDataPagePointer = ((DataPage)arrayList[i + 1]).Pointer;
				}
			}
			else if (i == arrayList.Count - 1)
			{
				((DataPage)arrayList[i]).OwnerDataPagePointer = ((DataPage)arrayList[i - 1]).Pointer;
			}
			else
			{
				((DataPage)arrayList[i]).OwnerDataPagePointer = ((DataPage)arrayList[i - 1]).Pointer;
				((DataPage)arrayList[i]).NextDataPagePointer = ((DataPage)arrayList[i + 1]).Pointer;
			}
		}
		DataPage[] array3 = new DataPage[arrayList.Count];
		arrayList.CopyTo(array3);
		return array3;
	}

	internal void AddColumn(LDB_DataColumn column)
	{
		m_pDbFile.Position = 68L;
		long num = -1L;
		StreamLineReader streamLineReader = new StreamLineReader(m_pDbFile);
		for (int i = 0; i < 100; i++)
		{
			byte[] array = streamLineReader.ReadLine();
			if (array == null)
			{
				throw new Exception("Invalid columns data area length !");
			}
			if (array[0] == 0)
			{
				num = m_pDbFile.Position;
				break;
			}
		}
		m_FilePosition = m_pDbFile.Position;
		if (num != -1)
		{
			SetFilePosition(GetFilePosition() - 102);
			byte[] array2 = column.ToColumnInfo();
			WriteToFile(array2, 0, array2.Length);
			return;
		}
		throw new Exception("Couldn't find free column space ! ");
	}

	internal void RemoveColumn(LDB_DataColumn column)
	{
		throw new Exception("TODO:");
	}

	internal int ReadFromFile(byte[] data, int offset, int count)
	{
		int num = m_pDbFile.Read(data, offset, count);
		m_FilePosition += num;
		return num;
	}

	internal void WriteToFile(byte[] data, int offset, int count)
	{
		m_pDbFile.Write(data, offset, count);
		m_FilePosition += count;
	}

	internal long GetFilePosition()
	{
		return m_FilePosition;
	}

	internal void SetFilePosition(long position)
	{
		if (m_FilePosition != position)
		{
			m_pDbFile.Position = position;
			m_FilePosition = position;
		}
	}

	private void GoToFileEnd()
	{
		m_pDbFile.Position = m_pDbFile.Length;
		m_FileLength = m_pDbFile.Length;
		m_FilePosition = m_FileLength;
	}
}
