using System;
using System.Collections;
using System.IO;
using ns108;
using ns114;
using ns118;
using ns121;
using ns99;

namespace ns116;

internal class Class4461 : Class4460, Interface117
{
	private MemoryStream memoryStream_0;

	private ArrayList arrayList_0;

	private bool bool_0;

	private bool bool_1;

	private Class4452 class4452_0;

	private Class4438 class4438_0;

	public MemoryStream AlterProgramStream => memoryStream_0;

	public ArrayList OperandIndexes => arrayList_0;

	public bool IsHandled
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Class4452 OffsetShifts
	{
		get
		{
			return class4452_0;
		}
		set
		{
			class4452_0 = value;
		}
	}

	public Class4461(Interface116 interpreterContext, Class4438 fontDictionary, bool alteringMode)
		: base(interpreterContext)
	{
		class4438_0 = fontDictionary;
		memoryStream_0 = new MemoryStream();
		arrayList_0 = new ArrayList();
		bool_1 = alteringMode;
		method_0();
	}

	private void method_0()
	{
	}

	public override void vmethod_0(string commandName)
	{
		switch (commandName)
		{
		case "version":
			method_1();
			break;
		case "Notice":
			method_2();
			break;
		case "FullName":
			method_3();
			break;
		case "FamilyName":
			method_4();
			break;
		case "Weight":
			method_5();
			break;
		case "FontBBox":
			method_6();
			break;
		case "UniqueID":
			method_7();
			break;
		case "XUID":
			method_8();
			break;
		case "charset":
			method_9();
			break;
		case "Encoding":
			method_10();
			break;
		case "CharStrings":
			method_11();
			break;
		case "Private":
			method_12();
			break;
		case "Copyright":
			method_13();
			break;
		case "isFixedPitch":
			method_14();
			break;
		case "ItalicAngle":
			method_15();
			break;
		case "UnderlinePosition":
			method_16();
			break;
		case "UnderlineThickness":
			method_17();
			break;
		case "PaintType":
			method_18();
			break;
		case "CharstringType":
			method_19();
			break;
		case "FontMatrix":
			method_20();
			break;
		case "StrokeWidth":
			method_21();
			break;
		case "SyntheticBase":
			method_22();
			break;
		case "PostScript":
			method_23();
			break;
		case "BaseFontName":
			method_24();
			break;
		case "BaseFontBlend":
			method_25();
			break;
		case "ROS":
			method_26();
			break;
		case "CIDFontVersion":
			method_27();
			break;
		case "CIDFontRevision":
			method_28();
			break;
		case "CIDFontType":
			method_29();
			break;
		case "CIDCount":
			method_30();
			break;
		case "UIDBase":
			method_31();
			break;
		case "FDArray":
			method_32();
			break;
		case "FDSelect":
			method_33();
			break;
		case "FontName":
			method_34();
			break;
		}
	}

	public void method_1()
	{
		double num = base.OperandStack.method_3();
		class4438_0.uint_0 = (uint)num;
	}

	public void method_2()
	{
		double num = base.OperandStack.method_3();
		class4438_0.uint_1 = (uint)num;
	}

	public void method_3()
	{
		double num = base.OperandStack.method_3();
		class4438_0.uint_3 = (uint)num;
	}

	public void method_4()
	{
		double num = base.OperandStack.method_3();
		class4438_0.uint_4 = (uint)num;
	}

	public void method_5()
	{
		double num = base.OperandStack.method_3();
		class4438_0.uint_5 = (uint)num;
	}

	public void method_6()
	{
		double yMax = base.OperandStack.method_3();
		double xMax = base.OperandStack.method_3();
		double yMin = base.OperandStack.method_3();
		double xMin = base.OperandStack.method_3();
		class4438_0.class4518_0 = new Class4518(xMin, yMin, xMax, yMax);
	}

	public void method_7()
	{
		double num = base.OperandStack.method_3();
		class4438_0.long_3 = (long)num;
	}

	public void method_8()
	{
		class4438_0.double_0 = new double[base.OperandStack.Count];
		for (int num = class4438_0.double_0.Length - 1; num >= 0; num--)
		{
			class4438_0.double_0[num] = base.OperandStack.method_3();
		}
	}

	public void method_9()
	{
		double num = base.OperandStack.method_3();
		class4438_0.long_5 = (long)num;
		if (bool_1)
		{
			byte[] array = Class4457.smethod_0((int)num + OffsetShifts.int_3);
			AlterProgramStream.Write(array, 0, array.Length);
			AlterProgramStream.WriteByte(15);
			IsHandled = true;
		}
	}

	public void method_10()
	{
		double num = base.OperandStack.method_3();
		class4438_0.long_6 = (long)num;
		if (bool_1)
		{
			byte[] array = Class4457.smethod_0((int)num + OffsetShifts.int_2);
			AlterProgramStream.Write(array, 0, array.Length);
			AlterProgramStream.WriteByte(16);
			IsHandled = true;
		}
	}

	public void method_11()
	{
		double num = base.OperandStack.method_3();
		class4438_0.long_7 = (long)num;
		if (bool_1)
		{
			byte[] array = Class4457.smethod_0((int)num + OffsetShifts.int_5);
			AlterProgramStream.Write(array, 0, array.Length);
			AlterProgramStream.WriteByte(18);
			IsHandled = true;
		}
	}

	public void method_12()
	{
		double num = base.OperandStack.method_3();
		double num2 = base.OperandStack.method_3();
		class4438_0.long_8 = (long)num2;
		class4438_0.long_9 = (uint)num;
		if (bool_1)
		{
			byte[] array = Class4457.smethod_0((int)num + OffsetShifts.int_7);
			AlterProgramStream.Write(array, 0, array.Length);
			AlterProgramStream.WriteByte(18);
			IsHandled = true;
		}
	}

	public void method_13()
	{
		double num = base.OperandStack.method_3();
		class4438_0.uint_2 = (uint)num;
	}

	public void method_14()
	{
		double value = base.OperandStack.method_3();
		class4438_0.bool_1 = Convert.ToBoolean(value);
	}

	public void method_15()
	{
		double num = base.OperandStack.method_3();
		class4438_0.long_0 = (long)num;
	}

	public void method_16()
	{
		double num = base.OperandStack.method_3();
		class4438_0.long_1 = (long)num;
	}

	public void method_17()
	{
		double num = base.OperandStack.method_3();
		class4438_0.long_2 = (long)num;
	}

	public void method_18()
	{
		double num = base.OperandStack.method_3();
		class4438_0.int_0 = (int)num;
	}

	public void method_19()
	{
		double num = base.OperandStack.method_3();
		class4438_0.int_1 = (int)num;
	}

	public void method_20()
	{
		double num = base.OperandStack.method_3();
		double num2 = base.OperandStack.method_3();
		double num3 = base.OperandStack.method_3();
		double num4 = base.OperandStack.method_3();
		double num5 = base.OperandStack.method_3();
		double num6 = base.OperandStack.method_3();
		class4438_0.class4509_0 = new Class4509(new double[6] { num6, num5, num4, num3, num2, num });
	}

	public void method_21()
	{
		double num = base.OperandStack.method_3();
		class4438_0.long_4 = (long)num;
	}

	public void method_22()
	{
		double num = base.OperandStack.method_3();
		class4438_0.uint_2 = (uint)num;
	}

	public void method_23()
	{
		double num = base.OperandStack.method_3();
		class4438_0.uint_8 = (uint)num;
	}

	public void method_24()
	{
		double num = base.OperandStack.method_3();
		class4438_0.uint_6 = (uint)num;
	}

	public void method_25()
	{
	}

	public void method_26()
	{
		double num = base.OperandStack.method_3();
		double num2 = base.OperandStack.method_3();
		double num3 = base.OperandStack.method_3();
		class4438_0.uint_9 = (uint)num3;
		class4438_0.uint_10 = (uint)num2;
		class4438_0.long_11 = (uint)num;
		class4438_0.bool_0 = true;
	}

	public void method_27()
	{
		double num = base.OperandStack.method_3();
		class4438_0.long_12 = (long)num;
	}

	public void method_28()
	{
		double num = base.OperandStack.method_3();
		class4438_0.long_13 = (long)num;
	}

	public void method_29()
	{
		double num = base.OperandStack.method_3();
		class4438_0.long_14 = (long)num;
	}

	public void method_30()
	{
		double num = base.OperandStack.method_3();
		class4438_0.long_15 = (long)num;
	}

	public void method_31()
	{
		double num = base.OperandStack.method_3();
		class4438_0.long_16 = (long)num;
	}

	public void method_32()
	{
		double num = base.OperandStack.method_3();
		class4438_0.long_17 = (long)num;
		if (bool_1)
		{
			byte[] array = Class4457.smethod_0((int)num + OffsetShifts.int_6);
			AlterProgramStream.Write(array, 0, array.Length);
			AlterProgramStream.WriteByte(12);
			AlterProgramStream.WriteByte(36);
			IsHandled = true;
		}
	}

	public void method_33()
	{
		double num = base.OperandStack.method_3();
		class4438_0.long_18 = (long)num;
		if (bool_1)
		{
			byte[] array = Class4457.smethod_0((int)num + OffsetShifts.int_4);
			AlterProgramStream.Write(array, 0, array.Length);
			AlterProgramStream.WriteByte(12);
			AlterProgramStream.WriteByte(37);
			IsHandled = true;
		}
	}

	public void method_34()
	{
		double num = base.OperandStack.method_3();
		class4438_0.uint_11 = (uint)num;
	}
}
