using System.IO;
using ns4;

namespace ns45;

internal class Class1103
{
	private readonly Stream stream_0;

	private byte[] byte_0 = new byte[8];

	private byte[] byte_1 = new byte[16];

	private long long_0;

	private long long_1;

	private long long_2 = 65534L;

	private long long_3;

	private long long_4;

	private long long_5;

	private long long_6;

	private long long_7;

	private int int_0;

	private long long_8;

	private long long_9;

	private long long_10;

	private static readonly byte[] byte_2 = new byte[8] { 208, 207, 17, 224, 161, 177, 26, 225 };

	public Class1103()
	{
	}

	public Class1103(Stream inStream)
	{
		stream_0 = inStream;
		method_0();
	}

	private void method_0()
	{
		BinaryReader binaryReader = new BinaryReader(stream_0);
		byte_0 = binaryReader.ReadBytes(8);
		if (byte_0[0] == 80 && byte_0[1] == 75 && byte_0[2] == 3 && byte_0[3] == 4)
		{
			throw new Exception1("The file is ZIP archive. It can be Microsoft PowerPoint 2007 PPTX presentation.");
		}
		if (byte_0[0] != byte_2[0] || byte_0[1] != byte_2[1] || byte_0[2] != byte_2[2] || byte_0[3] != byte_2[3] || byte_0[4] != byte_2[4] || byte_0[5] != byte_2[5] || byte_0[6] != byte_2[6] || byte_0[7] != byte_2[7])
		{
			throw new Exception1("Unknown file format.");
		}
		byte_1 = binaryReader.ReadBytes(16);
		long_0 = binaryReader.ReadUInt16();
		long_1 = binaryReader.ReadUInt16();
		long_2 = binaryReader.ReadUInt16();
		long_3 = binaryReader.ReadUInt16();
		long_4 = binaryReader.ReadUInt16();
		binaryReader.ReadBytes(10);
		long_5 = binaryReader.ReadUInt32();
		long_6 = binaryReader.ReadUInt32();
		binaryReader.ReadBytes(4);
		long_7 = binaryReader.ReadUInt32();
		int_0 = binaryReader.ReadInt32();
		long_8 = binaryReader.ReadUInt32();
		long_9 = binaryReader.ReadInt32();
		long_10 = binaryReader.ReadUInt32();
	}

	public byte[] method_1()
	{
		return byte_0;
	}

	public void method_2(byte[] identifier)
	{
		byte_0 = identifier;
	}

	public byte[] method_3()
	{
		return byte_1;
	}

	public void method_4(byte[] uid)
	{
		byte_1 = uid;
	}

	public long method_5()
	{
		return long_0;
	}

	public void method_6(short numberFormat)
	{
		long_0 = numberFormat;
	}

	public long method_7()
	{
		return long_1;
	}

	public void method_8(short version)
	{
		long_1 = version;
	}

	public long method_9()
	{
		return long_2;
	}

	public void method_10(short byteOrderID)
	{
		long_2 = byteOrderID;
	}

	public int method_11()
	{
		return 1 << (int)long_3;
	}

	private int method_12(short value)
	{
		if (value == 0)
		{
			long_3 = 0L;
			return 0;
		}
		int num = 0;
		while (value != 1)
		{
			value = (short)(value >> 1);
			num++;
		}
		return num;
	}

	public void method_13(short sizeOfSector)
	{
		long_3 = method_12(sizeOfSector);
	}

	public int method_14()
	{
		return 1 << (int)long_4;
	}

	public void method_15(short sizeOfShortSector)
	{
		long_4 = method_12(sizeOfShortSector);
	}

	public long method_16()
	{
		return long_5;
	}

	public void method_17(int numberOfSectorsSAT)
	{
		long_5 = numberOfSectorsSAT;
	}

	public long method_18()
	{
		return long_6;
	}

	public void method_19(int firstDirectorySID)
	{
		long_6 = firstDirectorySID;
	}

	public long method_20()
	{
		return long_7;
	}

	public void method_21(int minSizeOfStream)
	{
		long_7 = minSizeOfStream;
	}

	public int method_22()
	{
		return int_0;
	}

	public void method_23(int firstSIDOfShortSAT)
	{
		int_0 = firstSIDOfShortSAT;
	}

	public long method_24()
	{
		return long_8;
	}

	public void method_25(int numberOfSectorsOfShortSAT)
	{
		long_8 = numberOfSectorsOfShortSAT;
	}

	public long method_26()
	{
		return long_10;
	}

	public void method_27(int numberOfSectorsMasterSAT)
	{
		long_10 = numberOfSectorsMasterSAT;
	}

	public long method_28()
	{
		return long_9;
	}

	public void method_29(long firstSIDOfMasterSAT)
	{
		long_9 = firstSIDOfMasterSAT;
	}

	public void Write(Stream output)
	{
		BinaryWriter binaryWriter = new BinaryWriter(output);
		binaryWriter.Write(new byte[8] { 208, 207, 17, 224, 161, 177, 26, 225 });
		byte[] buffer = new byte[16];
		binaryWriter.Write(buffer);
		binaryWriter.Write((byte)62);
		binaryWriter.Write((byte)0);
		binaryWriter.Write((byte)3);
		binaryWriter.Write((byte)0);
		binaryWriter.Write((byte)((ulong)long_2 & 0xFFuL));
		binaryWriter.Write((byte)((ulong)(long_2 >> 8) & 0xFFuL));
		binaryWriter.Write((byte)9);
		binaryWriter.Write((byte)0);
		binaryWriter.Write((byte)6);
		binaryWriter.Write((byte)0);
		byte[] buffer2 = new byte[10];
		binaryWriter.Write(buffer2);
		binaryWriter.Write((int)long_5);
		binaryWriter.Write((int)long_6);
		byte[] buffer3 = new byte[4];
		binaryWriter.Write(buffer3);
		binaryWriter.Write((int)long_7);
		binaryWriter.Write(int_0);
		binaryWriter.Write((int)long_8);
		binaryWriter.Write((int)long_9);
		binaryWriter.Write((int)long_10);
		binaryWriter.Flush();
	}
}
