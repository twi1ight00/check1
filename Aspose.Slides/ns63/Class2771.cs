using System;
using System.IO;
using System.Runtime.CompilerServices;
using Aspose.Slides;
using ns234;
using ns60;

namespace ns63;

internal class Class2771 : Class2623, Interface44
{
	public const int int_0 = 4113;

	private byte[] byte_0;

	private uint uint_0;

	[CompilerGenerated]
	private uint uint_1;

	public bool IsCompressed
	{
		get
		{
			return base.Header.Instance == 1;
		}
		set
		{
			base.Header.Instance = (short)(value ? 1 : 0);
		}
	}

	public byte[] CompressedData
	{
		get
		{
			if (byte_0 == null)
			{
				return null;
			}
			byte[] array = new byte[byte_0.Length];
			Array.Copy(byte_0, array, byte_0.Length);
			return array;
		}
		set
		{
			byte_0 = null;
			if (value != null)
			{
				byte_0 = new byte[value.Length];
				Array.Copy(value, byte_0, value.Length);
			}
			base.Header.Length = vmethod_2();
		}
	}

	public byte[] Data
	{
		get
		{
			return Class6171.smethod_0(byte_0, (int)uint_0, Enum794.const_1);
		}
		set
		{
			byte_0 = null;
			uint_0 = 0u;
			if (value != null)
			{
				byte_0 = Class6171.smethod_2(value, Enum794.const_1);
				uint_0 = (uint)value.Length;
			}
			base.Header.Length = vmethod_2();
		}
	}

	public uint PersistId
	{
		[CompilerGenerated]
		get
		{
			return uint_1;
		}
		[CompilerGenerated]
		set
		{
			uint_1 = value;
		}
	}

	public Class2771()
	{
		base.Header.Type = 4113;
		base.Header.Instance = 1;
	}

	public void method_1(byte[] compressedData, uint decompressedSize)
	{
		byte_0 = compressedData;
		uint_0 = decompressedSize;
		base.Header.Length = vmethod_2();
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		if (IsCompressed)
		{
			uint_0 = reader.ReadUInt32();
			byte_0 = reader.ReadBytes(base.Header.Length - 4);
		}
		else
		{
			Data = reader.ReadBytes(base.Header.Length);
		}
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		if (byte_0 == null)
		{
			throw new PptException("Serialization of external storage with empty data. View [ms-ppt] 2.10.34 ExOleObjStg, 2.10.37 ExControlStg, 2.10.40 VbaProjectStg.");
		}
		if (IsCompressed)
		{
			writer.Write(uint_0);
			writer.Write(byte_0);
		}
		else
		{
			writer.Write(Data);
		}
	}

	public override int vmethod_2()
	{
		if (IsCompressed)
		{
			uint num = ((byte_0 != null) ? ((uint)byte_0.Length) : 0u);
			return (int)(num + 4);
		}
		return Data.Length;
	}
}
