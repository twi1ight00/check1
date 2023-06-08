using System;
using System.Runtime.CompilerServices;
using ns21;
using ns52;

namespace Aspose.Cells.Drawing;

public class TextureFill
{
	private object object_0;

	private Workbook workbook_0;

	private TextureType textureType_0;

	internal Class1696 class1696_0;

	private object object_1;

	internal string string_0 = "";

	internal Enum174 enum174_0;

	private int int_0 = 100000;

	public TextureType Type
	{
		get
		{
			return textureType_0;
		}
		set
		{
			textureType_0 = value;
			class1696_0 = null;
		}
	}

	public byte[] ImageData
	{
		get
		{
			return method_0()?.ImageData;
		}
		set
		{
			class1696_0 = new Class1696(value, workbook_0.Worksheets.method_75());
			byte[] array = class1696_0.method_6();
			if (array != null)
			{
				textureType_0 = MsoFillFormatHelper.smethod_48(array);
			}
			else
			{
				textureType_0 = TextureType.Unknown;
			}
		}
	}

	public PicFormatOption PicFormatOption
	{
		get
		{
			if (method_3())
			{
				return null;
			}
			return (PicFormatOption)object_1;
		}
		set
		{
			object_1 = value;
		}
	}

	public TilePicOption TilePicOption
	{
		get
		{
			if (method_3())
			{
				return (TilePicOption)object_1;
			}
			return null;
		}
		set
		{
			object_1 = value;
		}
	}

	public FillPictureType PictureFormatType
	{
		get
		{
			if (PicFormatOption == null)
			{
				return FillPictureType.Stretch;
			}
			return PicFormatOption.Type;
		}
		set
		{
			if (PicFormatOption == null)
			{
				object_1 = new PicFormatOption();
			}
			PicFormatOption.Type = value;
		}
	}

	public double Scale
	{
		get
		{
			if (PicFormatOption == null)
			{
				return 100.0;
			}
			return PicFormatOption.Scale;
		}
		set
		{
			if (PicFormatOption == null)
			{
				object_1 = new PicFormatOption();
			}
			PicFormatOption.Scale = value;
		}
	}

	public double Transparency
	{
		get
		{
			return Math.Round((double)(100 - method_8()) / 100.0, 2);
		}
		set
		{
			if (value < 0.0 || value > 1.0)
			{
				throw new CellsException(ExceptionType.InvalidData, "Transparency must between 0.0 (opaque) and 1.0 (clear)");
			}
			int int_ = 100 - (int)(value * 100.0);
			method_9(int_);
		}
	}

	internal TextureFill(object object_2, Workbook workbook_1)
	{
		workbook_0 = workbook_1;
		object_0 = object_2;
		object_1 = new PicFormatOption();
	}

	[SpecialName]
	internal Class1696 method_0()
	{
		if (class1696_0 == null && textureType_0 != TextureType.Unknown)
		{
			class1696_0 = new Class1696();
			class1696_0.method_3(Class1707.smethod_2(textureType_0), workbook_0.Worksheets.method_75());
		}
		return class1696_0;
	}

	[SpecialName]
	internal void method_1(Class1696 class1696_1)
	{
		class1696_0 = class1696_1;
		textureType_0 = TextureType.Unknown;
		if (class1696_1 != null && class1696_1.method_4() != null)
		{
			textureType_0 = smethod_0(class1696_1);
		}
	}

	internal static TextureType smethod_0(Class1696 class1696_1)
	{
		TextureType textureType = TextureType.Unknown;
		if (class1696_1.method_4() != null)
		{
			textureType = smethod_1(class1696_1.method_4().byte_4);
		}
		if (textureType != TextureType.Unknown)
		{
			return textureType;
		}
		byte[] array = class1696_1.method_6();
		if (array != null)
		{
			return MsoFillFormatHelper.smethod_48(array);
		}
		return textureType;
	}

	internal static TextureType smethod_1(byte byte_0)
	{
		return byte_0 switch
		{
			0 => TextureType.Papyrus, 
			1 => TextureType.Canvas, 
			2 => TextureType.Denim, 
			3 => TextureType.WovenMat, 
			4 => TextureType.WaterDroplets, 
			5 => TextureType.PaperBag, 
			6 => TextureType.FishFossil, 
			7 => TextureType.Sand, 
			8 => TextureType.GreenMarble, 
			9 => TextureType.WhiteMarble, 
			10 => TextureType.BrownMarble, 
			11 => TextureType.Granite, 
			12 => TextureType.Newsprint, 
			13 => TextureType.RecycledPaper, 
			14 => TextureType.Parchment, 
			15 => TextureType.Stationery, 
			16 => TextureType.BlueTissuePaper, 
			17 => TextureType.PinkTissuePaper, 
			18 => TextureType.PurpleMesh, 
			19 => TextureType.Bouquet, 
			20 => TextureType.Cork, 
			21 => TextureType.Walnut, 
			22 => TextureType.Oak, 
			23 => TextureType.MediumWood, 
			_ => TextureType.Unknown, 
		};
	}

	[SpecialName]
	internal byte[] method_2()
	{
		if (class1696_0 == null)
		{
			if (textureType_0 != TextureType.Unknown)
			{
				return Class1707.smethod_2(textureType_0);
			}
			return null;
		}
		return class1696_0.method_2();
	}

	[SpecialName]
	internal bool method_3()
	{
		return object_1 is TilePicOption;
	}

	[SpecialName]
	internal void method_4(bool bool_0)
	{
		if (bool_0)
		{
			if (object_1 is PicFormatOption)
			{
				object_1 = new TilePicOption();
			}
		}
		else if (object_1 is TilePicOption)
		{
			object_1 = new PicFormatOption();
		}
	}

	internal PicFormatOption method_5()
	{
		if (method_3())
		{
			return null;
		}
		return (PicFormatOption)object_1;
	}

	[SpecialName]
	internal int method_6()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_7(int int_1)
	{
		int_0 = int_1;
	}

	[SpecialName]
	internal int method_8()
	{
		return int_0 / 1000;
	}

	[SpecialName]
	internal void method_9(int int_1)
	{
		int_0 = int_1 * 1000;
	}

	internal void Copy(TextureFill textureFill_0)
	{
		class1696_0 = textureFill_0.class1696_0;
		textureType_0 = textureFill_0.textureType_0;
		int_0 = textureFill_0.int_0;
		if (textureFill_0.object_1 is TilePicOption)
		{
			object_1 = new TilePicOption();
			((TilePicOption)object_1).Copy(textureFill_0.TilePicOption);
		}
		else
		{
			object_1 = new PicFormatOption();
			((PicFormatOption)object_1).Copy(textureFill_0.PicFormatOption);
		}
	}
}
