using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ns234;
using ns33;
using ns4;

namespace ns62;

internal abstract class Class2634 : Class2629
{
	protected uint uint_1;

	internal int int_2;

	internal int int_3;

	internal int int_4;

	internal int int_5;

	internal int int_6;

	internal int int_7;

	internal Enum387 enum387_0;

	protected byte byte_1;

	internal Enum387 Compression => enum387_0;

	internal Class2634(ushort headerType, short headerInstance)
		: base(headerType, 0)
	{
		base.Header.Type = headerType;
		base.Header.Instance = headerInstance;
	}

	public static Class2634 smethod_1(Class2634 srcBlip)
	{
		Class2634 @class = srcBlip.Header.Type switch
		{
			61466 => new Class2636(), 
			61467 => new Class2635(), 
			_ => throw new NotImplementedException(), 
		};
		byte[] array = new byte[srcBlip.BLIPFileData.Length];
		Array.Copy(srcBlip.BLIPFileData, array, array.Length);
		@class.BLIPFileData = array;
		@class.RgbUid = new Guid(srcBlip.RgbUid.ToByteArray());
		@class.Header.Length = @class.RgbUid.ToByteArray().Length + 1 + array.Length;
		@class.int_5 = srcBlip.int_5;
		@class.enum387_0 = srcBlip.enum387_0;
		@class.byte_1 = srcBlip.byte_1;
		@class.int_7 = srcBlip.int_7;
		@class.int_2 = srcBlip.int_2;
		@class.int_4 = srcBlip.int_4;
		@class.int_3 = srcBlip.int_3;
		@class.int_6 = srcBlip.int_6;
		@class.uint_1 = srcBlip.uint_1;
		return @class;
	}

	public static Class2634 smethod_2(Metafile srcMetafile, Stream stream)
	{
		byte[] array = new byte[stream.Length];
		stream.Read(array, 0, array.Length);
		int num = 0;
		Class2634 @class;
		if (Class1159.smethod_1(array))
		{
			@class = new Class2636();
		}
		else
		{
			@class = new Class2635();
			int num2 = Class1162.smethod_1(array, 0);
			int num3 = Class1162.smethod_1(array, 2);
			if (num2 == 52695 && num3 == 39622)
			{
				num = 22;
			}
		}
		using (MemoryStream srcStream = new MemoryStream(array, num, array.Length - num, writable: false))
		{
			@class.BLIPFileData = Class6171.smethod_3(srcStream, Enum794.const_1);
		}
		@class.uint_1 = (uint)array.Length;
		Rectangle bounds = srcMetafile.GetMetafileHeader().Bounds;
		@class.int_2 = bounds.Left;
		@class.int_3 = bounds.Top;
		@class.int_4 = bounds.Right;
		@class.int_5 = bounds.Bottom;
		@class.int_6 = bounds.Width * 12700;
		@class.int_7 = bounds.Height * 12700;
		@class.enum387_0 = Enum387.const_0;
		@class.byte_1 = 254;
		@class.method_1(array);
		return @class;
	}

	internal byte[] method_2()
	{
		byte[] array = new byte[22];
		ushort num = 0;
		Class1162.smethod_19(array, 0, 2596720087L);
		num = 52695;
		num = 22289;
		Class1162.smethod_13(array, 4, 0);
		num = 22289;
		Class1162.smethod_13(array, 6, int_2);
		num = (ushort)(0x5711u ^ (ushort)int_2);
		Class1162.smethod_13(array, 8, int_3);
		num = (ushort)(num ^ (ushort)int_3);
		Class1162.smethod_13(array, 10, int_4);
		num = (ushort)(num ^ (ushort)int_4);
		Class1162.smethod_13(array, 12, int_5);
		num = (ushort)(num ^ (ushort)int_5);
		Class1162.smethod_13(array, 14, 96);
		num = (ushort)(num ^ 0x60u);
		Class1162.smethod_13(array, 16, 0);
		num = num;
		Class1162.smethod_13(array, 18, 0);
		num = num;
		Class1162.smethod_13(array, 20, num);
		return array;
	}

	public byte[] method_3()
	{
		MemoryStream memoryStream = new MemoryStream();
		if (base.BlipType != Enum389.const_2)
		{
			byte[] array = method_2();
			memoryStream.Write(array, 0, array.Length);
		}
		vmethod_5(memoryStream);
		return memoryStream.ToArray();
	}

	public Metafile method_4()
	{
		MemoryStream memoryStream = new MemoryStream();
		if (base.BlipType != Enum389.const_2)
		{
			byte[] array = method_2();
			memoryStream.Write(array, 0, array.Length);
		}
		vmethod_5(memoryStream);
		memoryStream.Position = 0L;
		Metafile result = null;
		try
		{
			result = (Metafile)Image.FromStream(memoryStream);
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
		}
		return result;
	}

	public override void vmethod_5(Stream stream)
	{
		switch (enum387_0)
		{
		default:
			throw new Exception("Unknown metafile compression method.");
		case Enum387.const_1:
			stream.Write(base.BLIPFileData, 0, base.BLIPFileData.Length);
			break;
		case Enum387.const_0:
		{
			byte[] array = Class6171.smethod_0(base.BLIPFileData, 0, Enum794.const_1);
			stream.Write(array, 0, array.Length);
			break;
		}
		}
	}

	public override byte[] vmethod_6()
	{
		return enum387_0 switch
		{
			Enum387.const_1 => base.BLIPFileData, 
			Enum387.const_0 => Class6171.smethod_0(base.BLIPFileData, 0, Enum794.const_1), 
			_ => null, 
		};
	}

	public override Image vmethod_7(SizeF size)
	{
		try
		{
			MemoryStream memoryStream = new MemoryStream();
			vmethod_5(memoryStream);
			memoryStream.Position = 0L;
			return new Metafile(memoryStream);
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
		}
		return null;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		int num = (int)reader.BaseStream.Position;
		if ((base.Header.Instance & 1) > 0)
		{
			reader.ReadBytes(16);
			base.Header.Instance &= -2;
		}
		base.RgbUid = Class2629.smethod_0(reader);
		uint_1 = reader.ReadUInt32();
		int_2 = reader.ReadInt32();
		int_3 = reader.ReadInt32();
		int_4 = reader.ReadInt32();
		int_5 = reader.ReadInt32();
		int_6 = reader.ReadInt32();
		int_7 = reader.ReadInt32();
		int count = reader.ReadInt32();
		enum387_0 = (Enum387)reader.ReadByte();
		byte_1 = reader.ReadByte();
		base.BLIPFileData = reader.ReadBytes(count);
		reader.BaseStream.Position = num + base.Header.Length;
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(base.RgbUid.ToByteArray());
		writer.Write(uint_1);
		writer.Write(int_2);
		writer.Write(int_3);
		writer.Write(int_4);
		writer.Write(int_5);
		writer.Write(int_6);
		writer.Write(int_7);
		writer.Write(base.BLIPFileData.Length);
		writer.Write((byte)enum387_0);
		writer.Write(byte_1);
		writer.Write(base.BLIPFileData);
	}

	public override int vmethod_2()
	{
		return base.RgbUid.ToByteArray().Length + 32 + 2 + base.BLIPFileData.Length;
	}
}
