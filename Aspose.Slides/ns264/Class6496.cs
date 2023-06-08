using System;
using System.Drawing;
using System.IO;
using ns218;
using ns233;

namespace ns264;

internal class Class6496
{
	public const float float_0 = 96f;

	private readonly Stream stream_0;

	private readonly Enum868 enum868_0;

	private Class6502 class6502_0;

	private Class6500 class6500_0;

	private Class6497 class6497_0;

	private int int_0;

	private RectangleF rectangleF_0 = RectangleF.Empty;

	public static readonly RectangleF rectangleF_1 = new RectangleF(0f, 0f, 1280f, 1024f);

	public static SizeF sizeF_0 = new SizeF(1280f, 1024f);

	internal Stream Stream => stream_0;

	internal int DataStartPos => int_0;

	internal Enum868 MetafileType => enum868_0;

	internal bool IsWmfPlaceable => enum868_0 == Enum868.const_2;

	internal bool IsEmfOnly => enum868_0 == Enum868.const_3;

	internal bool IsEmfPlusDual => enum868_0 == Enum868.const_5;

	internal bool IsEmfPlusOnly => enum868_0 == Enum868.const_4;

	internal bool IsEmfPlus
	{
		get
		{
			if (!IsEmfPlusDual)
			{
				return IsEmfPlusOnly;
			}
			return true;
		}
	}

	internal bool IsEmfAny
	{
		get
		{
			if (!IsEmfOnly)
			{
				return IsEmfPlus;
			}
			return true;
		}
	}

	internal float HorizontalResolution
	{
		get
		{
			switch (enum868_0)
			{
			default:
				throw new InvalidOperationException("Unknown metafile type.");
			case Enum868.const_1:
			case Enum868.const_2:
				return method_1();
			case Enum868.const_3:
			case Enum868.const_4:
			case Enum868.const_5:
				return class6497_0.HorizontalResolution;
			}
		}
	}

	internal float VerticalResolution
	{
		get
		{
			switch (enum868_0)
			{
			default:
				throw new InvalidOperationException("Unknown metafile type.");
			case Enum868.const_1:
			case Enum868.const_2:
				return method_1();
			case Enum868.const_3:
			case Enum868.const_4:
			case Enum868.const_5:
				return class6497_0.VerticalResolution;
			}
		}
	}

	public RectangleF BoundsPixels
	{
		get
		{
			switch (enum868_0)
			{
			default:
				throw new InvalidOperationException("Unknown metafile type.");
			case Enum868.const_1:
				return method_2();
			case Enum868.const_2:
				if (class6500_0.AreDimensionsValid)
				{
					return class6500_0.Bounds;
				}
				return rectangleF_1;
			case Enum868.const_3:
			case Enum868.const_4:
			case Enum868.const_5:
				return class6497_0.FramePixels;
			}
		}
	}

	public SizeF SizePixels => BoundsPixels.Size;

	public SizeF SizePoints => new SizeF((float)Class5955.smethod_10(SizePixels.Width, HorizontalResolution), (float)Class5955.smethod_10(SizePixels.Height, VerticalResolution));

	internal int ObjectCount
	{
		get
		{
			if (IsEmfAny)
			{
				return 0;
			}
			return class6502_0.ObjectCount;
		}
	}

	public Class6496(byte[] imageBytes)
		: this(new MemoryStream(imageBytes))
	{
	}

	public Class6496(Stream stream)
	{
		stream_0 = stream;
		enum868_0 = Class6148.smethod_20(stream);
		method_0();
	}

	private void method_0()
	{
		stream_0.Position = 0L;
		BinaryReader reader = new BinaryReader(stream_0);
		if (IsEmfAny)
		{
			class6497_0 = new Class6497();
			class6497_0.Read(reader);
		}
		else
		{
			if (IsWmfPlaceable)
			{
				class6500_0 = new Class6500();
				class6500_0.Read(reader);
			}
			class6502_0 = new Class6502();
			class6502_0.Read(reader);
		}
		int_0 = (int)stream_0.Position;
	}

	private float method_1()
	{
		if (IsWmfPlaceable)
		{
			return class6500_0.Inch;
		}
		return 96f;
	}

	private RectangleF method_2()
	{
		if (rectangleF_0.IsEmpty)
		{
			Class6486 @class = new Class6486();
			Class6481 class2 = new Class6481(@class);
			@class.method_1(this, class2, new Class6483());
			rectangleF_0 = class2.Bounds;
		}
		return rectangleF_0;
	}

	public byte[] method_3()
	{
		if (IsEmfAny)
		{
			return null;
		}
		Class6487 @class = new Class6487();
		@class.method_1(this, null, new Class6483());
		return @class.ExtractedImageBytes;
	}
}
