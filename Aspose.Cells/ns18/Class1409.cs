using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1409 : Interface46
{
	private uint uint_0;

	private Enum146 enum146_0;

	private Color color_0;

	private Color color_1;

	private Enum151 enum151_0;

	private Brush brush_0;

	private Image image_0;

	private WrapMode wrapMode_0;

	internal Enum146 Style
	{
		get
		{
			return enum146_0;
		}
		set
		{
			enum146_0 = value;
		}
	}

	internal Color ForeColor
	{
		set
		{
			color_0 = value;
		}
	}

	internal Color BackColor
	{
		set
		{
			color_1 = value;
		}
	}

	internal Class1409()
	{
		enum146_0 = Enum146.const_0;
		color_0 = Color.White;
		color_1 = Color.Empty;
		enum151_0 = Enum151.const_0;
	}

	internal void method_0(Class1429 class1429_0)
	{
		enum146_0 = (Enum146)class1429_0.ReadInt16();
		color_0 = class1429_0.method_6();
		enum151_0 = (Enum151)class1429_0.ReadInt16();
	}

	internal void method_1(Class1429 class1429_0)
	{
		enum146_0 = Enum146.const_11;
		wrapMode_0 = WrapMode.Tile;
		image_0 = Image.FromStream(class1429_0.BaseStream) as Bitmap;
	}

	internal void method_2(Class1429 class1429_0)
	{
		enum146_0 = Enum146.const_11;
		wrapMode_0 = WrapMode.Tile;
		int int_ = (int)(class1429_0.BaseStream.Length - class1429_0.BaseStream.Position);
		image_0 = Class1404.smethod_19(class1429_0, int_);
	}

	internal void method_3(Class1420 class1420_0)
	{
		uint_0 = class1420_0.ReadUInt32();
		enum146_0 = (Enum146)class1420_0.ReadUInt32();
		color_0 = class1420_0.method_6();
		enum151_0 = (Enum151)class1420_0.ReadInt32();
	}

	internal void method_4(Class1420 class1420_0)
	{
		uint_0 = class1420_0.ReadUInt32();
		enum146_0 = Enum146.const_11;
		wrapMode_0 = WrapMode.Tile;
		class1420_0.ReadInt32();
		int num = class1420_0.ReadInt32();
		int int_ = class1420_0.ReadInt32();
		class1420_0.ReadInt32();
		int int_2 = class1420_0.ReadInt32();
		try
		{
			class1420_0.BaseStream.Position = class1420_0.BaseStream.Position - 16 - 16 + num;
			image_0 = Class1404.smethod_20(class1420_0, int_, int_2);
		}
		catch
		{
		}
	}

	internal Brush method_5(Matrix matrix_0)
	{
		switch (enum146_0)
		{
		case Enum146.const_11:
			if (image_0 == null)
			{
				return null;
			}
			brush_0 = new TextureBrush(image_0);
			((TextureBrush)brush_0).Transform = matrix_0;
			((TextureBrush)brush_0).WrapMode = wrapMode_0;
			break;
		case Enum146.const_0:
			brush_0 = new SolidBrush(color_0);
			break;
		case Enum146.const_1:
			return null;
		case Enum146.const_3:
			brush_0 = new HatchBrush((HatchStyle)enum151_0, color_0, color_1);
			break;
		}
		return brush_0;
	}

	[SpecialName]
	Enum203 Interface46.get_Type()
	{
		return Enum203.const_1;
	}

	[SpecialName]
	public uint imethod_0()
	{
		return uint_0;
	}

	[SpecialName]
	public void imethod_1(uint uint_1)
	{
		uint_0 = uint_1;
	}
}
