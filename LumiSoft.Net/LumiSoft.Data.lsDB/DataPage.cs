using System;

namespace LumiSoft.Data.lsDB;

internal class DataPage
{
	private DbFile m_pOwnerDB = null;

	private long m_StartPointer = 0L;

	private bool m_Used = false;

	private long m_OwnerID = 0L;

	private long m_OwnerDataPagePointer = 0L;

	private long m_NextDataPagePointer = 0L;

	private int m_DataAreaSize = 1000;

	private int m_StoredDataLength = 0;

	private byte[] m_Data = null;

	public int DataPageSize => 33 + DataAreaSize;

	public long Pointer => m_StartPointer;

	public bool Used
	{
		get
		{
			return m_Used;
		}
		set
		{
			m_pOwnerDB.SetFilePosition(m_StartPointer + 2);
			m_pOwnerDB.WriteToFile(new byte[1] { Convert.ToByte(value) }, 0, 1);
		}
	}

	public long OwnerID => m_OwnerID;

	public long OwnerDataPagePointer
	{
		get
		{
			return m_OwnerDataPagePointer;
		}
		set
		{
			m_pOwnerDB.SetFilePosition(m_StartPointer + 11);
			m_pOwnerDB.WriteToFile(ldb_Utils.LongToByte(value), 0, 8);
			m_OwnerDataPagePointer = value;
		}
	}

	public long NextDataPagePointer
	{
		get
		{
			return m_NextDataPagePointer;
		}
		set
		{
			m_pOwnerDB.SetFilePosition(m_StartPointer + 19);
			m_pOwnerDB.WriteToFile(ldb_Utils.LongToByte(value), 0, 8);
			m_NextDataPagePointer = value;
		}
	}

	public int DataAreaSize => m_DataAreaSize;

	public int StoredDataLength => m_StoredDataLength;

	public long SpaceAvailable => DataAreaSize - m_StoredDataLength;

	public DataPage(int dataPageDataAreaSize, DbFile ownerDB, long startOffset)
	{
		m_DataAreaSize = dataPageDataAreaSize;
		m_pOwnerDB = ownerDB;
		m_StartPointer = startOffset;
		byte[] array = new byte[33];
		ownerDB.SetFilePosition(startOffset);
		ownerDB.ReadFromFile(array, 0, array.Length);
		m_Data = new byte[dataPageDataAreaSize];
		ownerDB.ReadFromFile(m_Data, 0, dataPageDataAreaSize);
		if (array[0] != 13)
		{
			throw new Exception("Not right data page startOffset, or invalid data page <CR> is expected but is '" + (int)array[0] + "' !");
		}
		if (array[1] != 10)
		{
			throw new Exception("Not right data page startOffset, or invalid data page <LF> is expected but is '" + (int)array[1] + "' !");
		}
		if (array[2] == 117)
		{
			m_Used = true;
		}
		else
		{
			m_Used = false;
		}
		m_OwnerID = ldb_Utils.ByteToLong(array, 3);
		m_OwnerDataPagePointer = ldb_Utils.ByteToLong(array, 11);
		m_NextDataPagePointer = ldb_Utils.ByteToLong(array, 19);
		m_StoredDataLength = ldb_Utils.ByteToInt(array, 27);
		if (array[31] != 13)
		{
			throw new Exception("Not right data page startOffset, or invalid data page <CR> is expected but is '" + (int)array[31] + "' !");
		}
		if (array[32] != 10)
		{
			throw new Exception("Not right data page startOffset, or invalid data page <LF> is expected but is '" + (int)array[32] + "' !");
		}
	}

	public static byte[] CreateDataPage(int dataPageDataAreaSize, bool used, long ownerID, long ownerDataPagePointer, long nextDataPagePointer, byte[] data)
	{
		if (data.Length > dataPageDataAreaSize)
		{
			throw new Exception("Data page can store only " + dataPageDataAreaSize + " bytes, data conatins '" + data.Length + "' bytes !");
		}
		byte[] array = new byte[dataPageDataAreaSize + 33];
		array[0] = 13;
		array[1] = 10;
		if (used)
		{
			array[2] = 117;
			Array.Copy(ldb_Utils.LongToByte(ownerID), 0, array, 3, 8);
			Array.Copy(ldb_Utils.LongToByte(ownerDataPagePointer), 0, array, 11, 8);
			Array.Copy(ldb_Utils.LongToByte(nextDataPagePointer), 0, array, 19, 8);
			Array.Copy(ldb_Utils.IntToByte(data.Length), 0, array, 27, 4);
			array[31] = 13;
			array[32] = 10;
			Array.Copy(data, 0, array, 33, data.Length);
		}
		else
		{
			array[2] = 102;
			array[31] = 13;
			array[32] = 10;
		}
		return array;
	}

	public void ReadData(byte[] buffer, int startIndexInBuffer, int length, int startOffset)
	{
		if (startOffset < 0)
		{
			throw new Exception("startOffset can't negative value !");
		}
		if (length + startOffset > DataAreaSize)
		{
			throw new Exception("startOffset and length are out of range data page data area !");
		}
		if (length + startOffset > m_StoredDataLength)
		{
			throw new Exception("There isn't so much data stored in data page as requested ! Stored data length = " + m_StoredDataLength + "; start offset = " + startOffset + "; length wanted = " + length);
		}
		Array.Copy(m_Data, startOffset, buffer, startIndexInBuffer, length);
	}

	public byte[] ReadData(int startOffset, int length)
	{
		if (startOffset < 0)
		{
			throw new Exception("startOffset can't negative value !");
		}
		if (length + startOffset > DataAreaSize)
		{
			throw new Exception("startOffset and length are out of range data page data area !");
		}
		if (length + startOffset > m_StoredDataLength)
		{
			throw new Exception("There isn't so much data stored in data page as requested ! Stored data length = " + m_StoredDataLength + "; start offset = " + startOffset + "; length wanted = " + length);
		}
		byte[] array = new byte[length];
		Array.Copy(m_Data, startOffset, array, 0, length);
		return array;
	}

	public void WriteData(byte[] data)
	{
		if (data.Length > DataAreaSize)
		{
			throw new Exception("Data page can't store more than " + DataAreaSize + " bytes, use mutliple data pages !");
		}
		m_pOwnerDB.SetFilePosition(m_StartPointer + 27);
		m_pOwnerDB.WriteToFile(ldb_Utils.IntToByte(data.Length), 0, 4);
		m_pOwnerDB.SetFilePosition(m_StartPointer + 33);
		m_pOwnerDB.WriteToFile(data, 0, data.Length);
		m_StoredDataLength = data.Length;
	}
}
