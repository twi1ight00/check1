using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1414
{
	private Enum202 enum202_0;

	private Class1430 class1430_0;

	private Class1423 class1423_0;

	private Class1417 class1417_0;

	private readonly ArrayList arrayList_0;

	private RectangleF rectangleF_0 = default(RectangleF);

	internal float HorizontalResolution
	{
		get
		{
			switch (enum202_0)
			{
			case Enum202.const_1:
			case Enum202.const_2:
				return method_14();
			default:
				return class1417_0.HorizontalResolution;
			}
		}
	}

	internal float VerticalResolution
	{
		get
		{
			switch (enum202_0)
			{
			case Enum202.const_1:
			case Enum202.const_2:
				return method_14();
			default:
				return class1417_0.VerticalResolution;
			}
		}
	}

	public SizeF Size => method_7().Size;

	internal Enum202 ImageType => enum202_0;

	public Class1414(byte[] byte_0)
	{
		arrayList_0 = new ArrayList();
		method_10(byte_0);
	}

	[SpecialName]
	internal bool method_0()
	{
		return enum202_0 == Enum202.const_2;
	}

	[SpecialName]
	internal bool method_1()
	{
		return enum202_0 == Enum202.const_3;
	}

	[SpecialName]
	internal bool method_2()
	{
		if (!method_1())
		{
			return method_5();
		}
		return true;
	}

	[SpecialName]
	internal bool method_3()
	{
		return enum202_0 == Enum202.const_5;
	}

	[SpecialName]
	internal bool method_4()
	{
		return enum202_0 == Enum202.const_4;
	}

	[SpecialName]
	internal bool method_5()
	{
		if (!method_3())
		{
			return method_4();
		}
		return true;
	}

	[SpecialName]
	public PointF method_6()
	{
		return method_7().Location;
	}

	[SpecialName]
	private RectangleF method_7()
	{
		switch (enum202_0)
		{
		default:
			throw new Exception("Unknown metafile image type");
		case Enum202.const_1:
			return method_15();
		case Enum202.const_2:
			if (class1423_0.method_1())
			{
				return new RectangleF(class1423_0.method_2().X, class1423_0.method_2().Y, class1423_0.method_2().Width, class1423_0.method_2().Height);
			}
			return Class1406.smethod_0();
		case Enum202.const_3:
		case Enum202.const_4:
		case Enum202.const_5:
			return class1417_0.method_1();
		}
	}

	[SpecialName]
	internal int method_8()
	{
		return arrayList_0.Count;
	}

	[SpecialName]
	internal int method_9()
	{
		if (method_2())
		{
			return 0;
		}
		return class1430_0.method_0();
	}

	private static Enum202 smethod_0(byte[] byte_0)
	{
		if (Class1404.smethod_12(byte_0))
		{
			return Enum202.const_1;
		}
		if (Class1404.smethod_13(byte_0))
		{
			return Enum202.const_2;
		}
		return Class1404.smethod_15(byte_0);
	}

	private void method_10(byte[] byte_0)
	{
		enum202_0 = smethod_0(byte_0);
		if (enum202_0 == Enum202.const_0)
		{
			throw new ArgumentException("The specified stream does not contain a valid metafile.", "stream");
		}
		using MemoryStream input = new MemoryStream(byte_0);
		BinaryReader binaryReader_ = new BinaryReader(input);
		method_11(binaryReader_);
		method_12(binaryReader_);
	}

	private void method_11(BinaryReader binaryReader_0)
	{
		if (method_2())
		{
			class1417_0 = new Class1417();
			class1417_0.Read(binaryReader_0);
			return;
		}
		if (method_0())
		{
			class1423_0 = new Class1423();
			class1423_0.Read(binaryReader_0);
		}
		class1430_0 = new Class1430();
		class1430_0.Read(binaryReader_0);
	}

	private void method_12(BinaryReader binaryReader_0)
	{
		int num = 0;
		while (binaryReader_0.BaseStream.Position < binaryReader_0.BaseStream.Length)
		{
			Class1424 @class = new Class1424();
			num++;
			switch (enum202_0)
			{
			case Enum202.const_1:
			case Enum202.const_2:
				@class.method_0(binaryReader_0);
				goto IL_0054;
			case Enum202.const_4:
				@class.method_1(binaryReader_0);
				goto IL_0054;
			case Enum202.const_3:
			case Enum202.const_5:
				@class.method_1(binaryReader_0);
				if (@class.method_3())
				{
					break;
				}
				goto IL_0054;
			default:
				{
					throw new Exception("Unknown Metafile type is detected");
				}
				IL_0054:
				if (@class.method_2() || @class.Type == Enum155.const_82)
				{
					return;
				}
				arrayList_0.Add(@class);
				break;
			}
		}
	}

	internal Class1424 method_13(int int_0)
	{
		return (Class1424)arrayList_0[int_0];
	}

	private float method_14()
	{
		if (method_0())
		{
			return class1423_0.method_3();
		}
		return 96f;
	}

	private RectangleF method_15()
	{
		if (rectangleF_0.IsEmpty)
		{
			Class1416 class1416_ = new Class1416(this);
			Class1427 @class = new Class1427(class1416_);
			Class1428 class2 = new Class1428(class1416_, @class);
			class2.method_0();
			rectangleF_0 = @class.method_9().Value;
		}
		return rectangleF_0;
	}
}
