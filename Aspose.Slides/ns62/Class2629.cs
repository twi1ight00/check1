using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ns223;

namespace ns62;

internal abstract class Class2629 : Class2628
{
	protected const int int_0 = 61464;

	protected const int int_1 = 16;

	private Guid guid_0;

	private byte[] byte_0;

	public uint uint_0;

	public Guid RgbUid
	{
		get
		{
			return guid_0;
		}
		set
		{
			guid_0 = value;
		}
	}

	public byte[] BLIPFileData
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

	public Enum389 BlipType => (Enum389)(base.Header.Type - 61464);

	public ImageFormat ImageFormat => BlipType switch
	{
		Enum389.const_2 => ImageFormat.Emf, 
		Enum389.const_3 => ImageFormat.Wmf, 
		Enum389.const_4 => ImageFormat.Emf, 
		Enum389.const_5 => ImageFormat.Jpeg, 
		Enum389.const_6 => ImageFormat.Png, 
		Enum389.const_7 => ImageFormat.Bmp, 
		_ => throw new Exception("Unsupported image format."), 
	};

	public Class2629(ushort type, byte version)
		: base(type, version)
	{
	}

	protected static Guid smethod_0(BinaryReader reader)
	{
		return new Guid(reader.ReadBytes(16));
	}

	protected void method_1(byte[] imageBytes)
	{
		guid_0 = Class5981.smethod_0(imageBytes);
	}

	public abstract void vmethod_5(Stream stream);

	public abstract byte[] vmethod_6();

	public abstract Image vmethod_7(SizeF size);

	public abstract override int vmethod_2();
}
