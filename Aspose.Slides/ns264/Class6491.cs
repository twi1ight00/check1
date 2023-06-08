using System.Drawing.Drawing2D;
using ns224;
using ns233;

namespace ns264;

internal class Class6491 : Interface318
{
	private int int_0;

	private Enum840 enum840_0;

	private Class5998 class5998_0;

	private Class5998 class5998_1;

	private Enum841 enum841_0;

	private Class5990 class5990_0;

	private byte[] byte_0;

	private WrapMode wrapMode_0;

	Enum866 Interface318.Type => Enum866.const_1;

	public int Handle
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	internal Enum840 Style
	{
		get
		{
			return enum840_0;
		}
		set
		{
			enum840_0 = value;
		}
	}

	internal Class5998 ForeColor
	{
		get
		{
			return class5998_0;
		}
		set
		{
			class5998_0 = value;
		}
	}

	internal Class5998 BackColor
	{
		get
		{
			return class5998_1;
		}
		set
		{
			class5998_1 = value;
		}
	}

	internal Enum841 BrushHatchStyle
	{
		get
		{
			return enum841_0;
		}
		set
		{
			enum841_0 = value;
		}
	}

	internal Class6491()
	{
		enum840_0 = Enum840.const_0;
		class5998_0 = Class5998.class5998_136;
		class5998_1 = Class5998.class5998_141;
		enum841_0 = Enum841.const_0;
	}

	internal void method_0(Class6501 reader)
	{
		enum840_0 = (Enum840)reader.ReadInt16();
		class5998_0 = reader.method_9();
		enum841_0 = (Enum841)reader.ReadInt16();
	}

	internal void method_1(Class6501 reader)
	{
		enum840_0 = Enum840.const_11;
		wrapMode_0 = WrapMode.Tile;
		byte_0 = reader.ReadBytes((int)reader.BaseStream.Length);
	}

	internal void method_2(Class6501 reader)
	{
		enum840_0 = Enum840.const_11;
		wrapMode_0 = WrapMode.Tile;
		int dibLength = (int)(reader.BaseStream.Length - reader.BaseStream.Position);
		byte_0 = Class6148.smethod_21(reader, dibLength);
	}

	internal void method_3(Class6498 reader)
	{
		int_0 = reader.ReadInt32();
		enum840_0 = (Enum840)reader.ReadUInt32();
		class5998_0 = reader.method_9();
		enum841_0 = (Enum841)reader.ReadInt32();
	}

	internal void method_4(Class6498 reader)
	{
		int num = (int)reader.BaseStream.Position - 8;
		int_0 = reader.ReadInt32();
		enum840_0 = Enum840.const_11;
		wrapMode_0 = WrapMode.Tile;
		reader.ReadInt32();
		int num2 = reader.ReadInt32();
		int headerLength = reader.ReadInt32();
		reader.ReadInt32();
		int bmpLength = reader.ReadInt32();
		reader.BaseStream.Position = num + num2;
		byte_0 = Class6148.smethod_22(reader, headerLength, bmpLength);
	}

	internal Class5990 method_5(Class6002 brushMatrix)
	{
		switch (enum840_0)
		{
		case Enum840.const_11:
		{
			Class5995 @class = new Class5995(byte_0, wrapMode_0);
			@class.Transform = brushMatrix;
			class5990_0 = @class;
			break;
		}
		case Enum840.const_0:
			class5990_0 = new Class5997(class5998_0);
			break;
		case Enum840.const_1:
			return null;
		case Enum840.const_3:
			class5990_0 = new Class5996((HatchStyle)enum841_0, class5998_0, class5998_1);
			break;
		}
		return class5990_0;
	}
}
