using System;
using System.IO;
using ns63;

namespace ns62;

internal class Class2638 : Class2628
{
	internal const int int_0 = 61447;

	private byte byte_0;

	private byte byte_1;

	private byte[] byte_2;

	private ushort ushort_0;

	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private byte byte_3;

	private byte byte_4;

	private byte byte_5;

	private byte byte_6;

	private Class2629 class2629_0;

	public byte BtWin32
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public byte BtMacOs
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	public byte[] RgbUid
	{
		get
		{
			return byte_2;
		}
		set
		{
			byte_2 = value;
		}
	}

	public ushort Tag
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
		}
	}

	public uint Size
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public uint CRef
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public uint FoDelay
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	public byte CbName => byte_4;

	public Class2629 EmbeddedBlip
	{
		get
		{
			return class2629_0;
		}
		set
		{
			class2629_0 = value;
		}
	}

	public Class2638()
		: base(61447, 2)
	{
	}

	internal void method_1(BinaryReader docStreamReader)
	{
		long position = docStreamReader.BaseStream.Position;
		docStreamReader.BaseStream.Seek(FoDelay, SeekOrigin.Begin);
		class2629_0 = Class2950.smethod_0(docStreamReader) as Class2629;
		docStreamReader.BaseStream.Seek(position, SeekOrigin.Begin);
	}

	internal void method_2(BinaryWriter docStreamWriter)
	{
		FoDelay = (uint)docStreamWriter.BaseStream.Position;
		Size = (uint)class2629_0.Write(docStreamWriter);
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		byte_0 = reader.ReadByte();
		byte_1 = reader.ReadByte();
		byte_2 = reader.ReadBytes(16);
		ushort_0 = reader.ReadUInt16();
		uint_0 = reader.ReadUInt32();
		uint_1 = reader.ReadUInt32();
		uint_2 = reader.ReadUInt32();
		byte_3 = reader.ReadByte();
		byte_4 = reader.ReadByte();
		byte_5 = reader.ReadByte();
		byte_6 = reader.ReadByte();
		if (byte_4 > 0)
		{
			throw new Exception("Found a BLIP with a name and this is not yet supported.");
		}
		if (base.Header.Length > 36)
		{
			class2629_0 = Class2950.smethod_0(reader) as Class2629;
		}
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		if (class2629_0 != null)
		{
			uint_0 = (uint)(class2629_0.vmethod_2() + 8);
		}
		writer.Write(byte_0);
		writer.Write(byte_1);
		writer.Write(byte_2);
		writer.Write(ushort_0);
		writer.Write(uint_0);
		writer.Write(uint_1);
		writer.Write(uint_2);
		writer.Write(byte_3);
		writer.Write(byte_4);
		writer.Write(byte_5);
		writer.Write(byte_6);
		if (class2629_0 != null)
		{
			class2629_0.Write(writer);
		}
	}

	public override int vmethod_2()
	{
		int num = 2 + byte_2.Length + 18;
		if (class2629_0 != null)
		{
			num += class2629_0.vmethod_2() + 8;
		}
		return num;
	}
}
