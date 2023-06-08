using System;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1428
{
	private readonly Class1416 class1416_0;

	private MemoryStream memoryStream_0;

	private Class1429 class1429_0;

	private readonly Class1425 class1425_0;

	internal Class1428(Class1416 class1416_1, Class1425 class1425_1)
	{
		class1416_0 = class1416_1;
		class1425_0 = class1425_1;
	}

	internal void method_0()
	{
		method_1(PointF.Empty, SizeF.Empty);
	}

	internal void method_1(PointF pointF_0, SizeF sizeF_0)
	{
		if (class1425_0.method_4())
		{
			class1416_0.method_3(class1416_0.method_4().Size);
			method_49().method_2(class1416_0.method_4().Size);
		}
		memoryStream_0 = new MemoryStream();
		class1429_0 = new Class1429(memoryStream_0);
		class1425_0.Initialize(pointF_0, sizeF_0);
		for (int i = 0; i < method_50().method_8(); i++)
		{
			method_2(method_50().method_13(i));
		}
		memoryStream_0.Close();
	}

	private void method_2(Class1424 class1424_0)
	{
		if (class1424_0.method_4() > 0)
		{
			memoryStream_0.Write(class1424_0.Data, 0, class1424_0.method_4());
			memoryStream_0.Position -= class1424_0.method_4();
		}
		switch (class1424_0.Type)
		{
		case Enum155.const_29:
			method_3();
			break;
		case Enum155.const_1:
			method_25();
			break;
		case Enum155.const_2:
			method_5();
			break;
		case Enum155.const_5:
			method_26();
			break;
		case Enum155.const_7:
			method_29();
			break;
		case Enum155.const_63:
			method_15();
			break;
		case Enum155.const_44:
			method_22();
			break;
		case Enum155.const_45:
			method_28();
			break;
		case Enum155.const_38:
			method_4();
			break;
		case Enum155.const_58:
			method_21();
			break;
		case Enum155.const_64:
			method_20();
			break;
		case Enum155.const_62:
			method_23();
			break;
		case Enum155.const_8:
			method_27();
			break;
		case Enum155.const_10:
			method_6();
			break;
		case Enum155.const_11:
			method_7();
			break;
		case Enum155.const_12:
			method_10();
			break;
		case Enum155.const_13:
			method_11();
			break;
		case Enum155.const_14:
			method_8();
			break;
		case Enum155.const_16:
			method_12();
			break;
		case Enum155.const_18:
			method_33();
			break;
		case Enum155.const_19:
			MoveTo();
			break;
		case Enum155.const_0:
			method_24();
			break;
		case Enum155.const_35:
			method_36();
			break;
		case Enum155.const_36:
			method_35();
			break;
		case Enum155.const_65:
			method_17();
			break;
		case Enum155.const_66:
			method_19();
			break;
		case Enum155.const_67:
			method_18();
			break;
		case Enum155.const_23:
			method_39();
			break;
		case Enum155.const_15:
			method_9();
			break;
		case Enum155.const_17:
			method_14();
			break;
		case Enum155.const_30:
			method_32();
			break;
		case Enum155.const_26:
			method_34();
			break;
		case Enum155.const_32:
			method_30();
			break;
		case Enum155.const_27:
			method_42();
			break;
		case Enum155.const_54:
			method_37();
			break;
		case Enum155.const_68:
			method_16();
			break;
		case Enum155.const_25:
			method_40();
			break;
		case Enum155.const_22:
			method_38();
			break;
		case Enum155.const_56:
			method_46();
			break;
		case Enum155.const_46:
			method_41();
			break;
		case Enum155.const_59:
			method_43();
			break;
		case Enum155.const_57:
			method_44();
			break;
		case Enum155.const_48:
			method_31();
			break;
		}
	}

	private void method_3()
	{
		class1416_0.method_0();
	}

	private void method_4()
	{
		class1416_0.method_1();
	}

	private void method_5()
	{
		method_49().method_17((Enum154)class1429_0.ReadInt16());
		method_49().method_27();
	}

	private void method_6()
	{
		method_49().method_1(class1429_0.method_2());
		method_49().method_27();
	}

	private void method_7()
	{
		method_49().method_2(class1429_0.method_3());
		method_49().method_27();
	}

	private void method_8()
	{
		PointF location = method_49().method_12().Location;
		PointF pointF = class1429_0.method_2();
		method_49().method_1(new PointF(location.X + pointF.X, location.Y + pointF.Y));
		method_49().method_27();
	}

	private void method_9()
	{
		method_49().method_2(method_13(method_49().method_12().Size));
		method_49().method_27();
	}

	private void method_10()
	{
		class1416_0.method_2(class1429_0.method_2());
		method_49().method_27();
	}

	private void method_11()
	{
		class1416_0.method_3(class1429_0.method_3());
		method_49().method_27();
	}

	private void method_12()
	{
		PointF location = method_51().Location;
		PointF pointF = class1429_0.method_2();
		class1416_0.method_2(new PointF(location.X + pointF.X, location.Y + pointF.Y));
		method_49().method_27();
	}

	private SizeF method_13(SizeF sizeF_0)
	{
		int num = class1429_0.ReadInt16();
		int num2 = class1429_0.ReadInt16();
		int num3 = class1429_0.ReadInt16();
		int num4 = class1429_0.ReadInt16();
		if (num == 0 || num3 == 0)
		{
			throw new Exception("Invalid scale values.");
		}
		return new SizeF(sizeF_0.Width * (float)num4 / (float)num3, sizeF_0.Height * (float)num2 / (float)num);
	}

	private void method_14()
	{
		class1416_0.method_3(method_13(method_51().Size));
		method_49().method_27();
	}

	private void method_15()
	{
		Class1413 interface46_ = new Class1413();
		method_47(interface46_);
	}

	private void method_16()
	{
		Class1413 interface46_ = new Class1413();
		method_47(interface46_);
	}

	private void method_17()
	{
		Class1413 @class = new Class1413();
		@class.method_0(class1429_0);
		method_47(@class);
	}

	private void method_18()
	{
		Class1409 @class = new Class1409();
		@class.method_0(class1429_0);
		method_47(@class);
	}

	private void method_19()
	{
		Class1411 @class = new Class1411();
		@class.method_0(class1429_0);
		method_47(@class);
	}

	private void method_20()
	{
		Class1409 @class = new Class1409();
		@class.method_1(class1429_0);
		method_47(@class);
	}

	private void method_21()
	{
		class1429_0.ReadUInt32();
		Class1409 @class = new Class1409();
		@class.method_2(class1429_0);
		method_47(@class);
	}

	private void method_22()
	{
		uint uint_ = class1429_0.ReadUInt16();
		method_49().method_0(uint_);
	}

	private void method_23()
	{
		uint uint_ = class1429_0.ReadUInt16();
		method_48(uint_);
	}

	private void method_24()
	{
		method_49().BackgroundColor = class1429_0.method_6();
	}

	private void method_25()
	{
		method_49().BackgroundMode = (Enum145)class1429_0.ReadUInt16();
	}

	private void method_26()
	{
		method_49().method_19((Enum150)class1429_0.ReadUInt16());
	}

	private void method_27()
	{
		method_49().method_14(class1429_0.method_6());
	}

	private void method_28()
	{
		method_49().method_16((Enum161)class1429_0.ReadUInt16());
	}

	private void method_29()
	{
		int int_ = class1429_0.ReadInt16();
		method_49().method_23(int_);
	}

	private void method_30()
	{
		int num = class1429_0.ReadUInt16();
		if (num != 0)
		{
			string string_ = class1429_0.method_1(num);
			class1429_0.BaseStream.Seek(-4L, SeekOrigin.End);
			PointF pointF_ = class1429_0.method_2();
			class1425_0.vmethod_0(pointF_, string_);
		}
	}

	private void method_31()
	{
		PointF pointF_ = class1429_0.method_2();
		int num = class1429_0.ReadUInt16();
		if (num != 0)
		{
			if (class1429_0.ReadInt16() != 0)
			{
				class1429_0.method_4();
			}
			string string_ = class1429_0.method_1(num);
			class1425_0.vmethod_0(pointF_, string_);
		}
	}

	private void method_32()
	{
		Color color_ = class1429_0.method_6();
		PointF pointF_ = class1429_0.method_2();
		class1425_0.vmethod_2(pointF_, color_);
	}

	private void MoveTo()
	{
		class1416_0.method_9(class1429_0.method_2());
	}

	private void method_33()
	{
		PointF pointF = class1429_0.method_2();
		class1425_0.vmethod_3(pointF);
		class1416_0.method_9(pointF);
	}

	private void method_34()
	{
		class1425_0.vmethod_4(class1429_0.method_4());
	}

	private void method_35()
	{
		class1425_0.vmethod_6(class1429_0.method_7());
	}

	private void method_36()
	{
		class1425_0.vmethod_9(class1429_0.method_7());
	}

	private void method_37()
	{
		class1425_0.vmethod_10(class1429_0.method_9());
	}

	private void method_38()
	{
		PointF pointF_ = class1429_0.method_2();
		PointF pointF_2 = class1429_0.method_2();
		RectangleF rectangleF_ = class1429_0.method_4();
		class1425_0.vmethod_11(rectangleF_, pointF_, pointF_2);
	}

	private void method_39()
	{
		class1425_0.vmethod_12(class1429_0.method_4());
	}

	private void method_40()
	{
		PointF pointF_ = class1429_0.method_2();
		PointF pointF_2 = class1429_0.method_2();
		RectangleF rectangleF_ = class1429_0.method_4();
		class1425_0.vmethod_13(rectangleF_, pointF_, pointF_2);
	}

	private void method_41()
	{
		PointF pointF_ = class1429_0.method_2();
		PointF pointF_2 = class1429_0.method_2();
		RectangleF rectangleF_ = class1429_0.method_4();
		class1425_0.vmethod_14(rectangleF_, pointF_, pointF_2);
	}

	private void method_42()
	{
		SizeF sizeF_ = class1429_0.method_3();
		RectangleF rectangleF_ = class1429_0.method_4();
		class1425_0.vmethod_15(rectangleF_, sizeF_);
	}

	private void method_43()
	{
		class1429_0.ReadUInt16();
		class1429_0.ReadUInt16();
		class1429_0.ReadUInt16();
		method_45();
	}

	private void method_44()
	{
		class1429_0.ReadUInt16();
		class1429_0.ReadUInt16();
		method_45();
	}

	private void method_45()
	{
		RectangleF rectangleF_ = class1429_0.method_5();
		RectangleF rectangleF_2 = class1429_0.method_5();
		int num = (int)(class1429_0.BaseStream.Length - class1429_0.BaseStream.Position);
		if (num >= 1)
		{
			byte[] byte_ = class1429_0.ReadBytes(num);
			byte[] byte_2 = Class1404.smethod_16(byte_);
			class1425_0.vmethod_16(rectangleF_, rectangleF_2, byte_2);
		}
	}

	private void method_46()
	{
		class1429_0.ReadUInt16();
		class1429_0.ReadUInt16();
		class1429_0.ReadUInt16();
		class1429_0.ReadUInt16();
		class1429_0.ReadUInt16();
		RectangleF rectangleF_ = class1429_0.method_5();
		class1425_0.vmethod_5(rectangleF_);
	}

	private void method_47(Interface46 interface46_0)
	{
		class1416_0.method_10().Add(interface46_0);
	}

	private void method_48(uint uint_0)
	{
		class1416_0.method_10().method_0(uint_0);
	}

	[SpecialName]
	private Class1407 method_49()
	{
		return class1416_0.method_5();
	}

	[SpecialName]
	private Class1414 method_50()
	{
		return class1416_0.method_4();
	}

	[SpecialName]
	private RectangleF method_51()
	{
		return class1416_0.method_6();
	}
}
