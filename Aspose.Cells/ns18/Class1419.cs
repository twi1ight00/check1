using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns18;

internal class Class1419 : Class1418
{
	internal Class1419(Class1416 class1416_1, Class1426 class1426_1)
		: base(class1416_1, class1426_1)
	{
	}

	protected override void vmethod_0(Class1424 class1424_0)
	{
		switch (class1424_0.Type)
		{
		case Enum155.const_70:
			method_61(Enum165.flag_0);
			break;
		case Enum155.const_71:
			method_63(Enum165.flag_0);
			break;
		case Enum155.const_72:
			method_60(Enum165.flag_0);
			break;
		case Enum155.const_73:
			method_61(Enum165.flag_2);
			break;
		case Enum155.const_74:
			method_60(Enum165.flag_2);
			break;
		case Enum155.const_75:
			method_62(Enum165.flag_0);
			break;
		case Enum155.const_76:
			method_64(Enum165.flag_0);
			break;
		case Enum155.const_77:
			method_37();
			break;
		case Enum155.const_78:
			method_36();
			break;
		case Enum155.const_79:
			method_42();
			break;
		case Enum155.const_80:
			method_41();
			break;
		case Enum155.const_81:
			method_40();
			break;
		case Enum155.const_83:
			method_58();
			break;
		case Enum155.const_85:
			method_33();
			break;
		case Enum155.const_86:
			method_46();
			break;
		case Enum155.const_87:
			method_35();
			break;
		case Enum155.const_88:
			method_48();
			break;
		case Enum155.const_89:
			method_18();
			break;
		case Enum155.const_90:
			method_44();
			break;
		case Enum155.const_92:
			method_45();
			break;
		case Enum155.const_93:
			method_47();
			break;
		case Enum155.const_95:
			method_56();
			break;
		case Enum155.const_29:
			method_29();
			break;
		case Enum155.const_99:
			method_43();
			break;
		case Enum155.const_100:
			method_39();
			break;
		case Enum155.const_101:
			method_31();
			break;
		case Enum155.const_102:
			method_32();
			break;
		case Enum155.const_103:
			method_20();
			break;
		case Enum155.const_104:
			method_19();
			break;
		case Enum155.const_105:
			method_77();
			break;
		case Enum155.const_106:
			method_74();
			break;
		case Enum155.const_107:
			method_70();
			break;
		case Enum155.const_108:
			method_78();
			break;
		case Enum155.const_110:
			method_67();
			break;
		case Enum155.const_111:
			method_54();
			break;
		case Enum155.const_112:
			method_55();
			break;
		case Enum155.const_113:
			method_66(Enum165.flag_0);
			break;
		case Enum155.const_114:
			method_68();
			break;
		case Enum155.const_115:
			method_69();
			break;
		case Enum155.const_117:
			method_76();
			break;
		case Enum155.const_122:
			method_57();
			break;
		case Enum155.const_53:
			method_66(Enum165.flag_2);
			break;
		case Enum155.const_124:
			method_65(Enum165.flag_0);
			break;
		case Enum155.const_125:
			method_34();
			break;
		case Enum155.const_126:
			method_14();
			break;
		case Enum155.const_127:
			method_21();
			break;
		case Enum155.const_128:
			method_22();
			break;
		case Enum155.const_129:
			method_23();
			break;
		case Enum155.const_130:
			method_24();
			break;
		case Enum155.const_131:
			method_26();
			break;
		case Enum155.const_132:
			method_25();
			break;
		case Enum155.const_135:
			method_30();
			break;
		case Enum155.const_138:
			method_80();
			break;
		case Enum155.const_143:
			method_28();
			break;
		case Enum155.const_144:
			method_17();
			break;
		case Enum155.const_145:
			method_16();
			break;
		case Enum155.const_149:
			method_15();
			break;
		case Enum155.const_150:
			method_73();
			break;
		case Enum155.const_151:
			method_49();
			break;
		case Enum155.const_152:
			method_51();
			break;
		case Enum155.const_153:
			method_61(Enum165.flag_1);
			break;
		case Enum155.const_154:
			method_63(Enum165.flag_1);
			break;
		case Enum155.const_155:
			method_60(Enum165.flag_1);
			break;
		case Enum155.const_156:
			method_61(Enum165.flag_1 | Enum165.flag_2);
			break;
		case Enum155.const_157:
			method_60(Enum165.flag_1 | Enum165.flag_2);
			break;
		case Enum155.const_158:
			method_62(Enum165.flag_1);
			break;
		case Enum155.const_159:
			method_64(Enum165.flag_1);
			break;
		case Enum155.const_160:
			method_65(Enum165.flag_1);
			break;
		case Enum155.const_161:
			method_72();
			break;
		case Enum155.const_162:
			method_71();
			break;
		case Enum155.const_163:
			method_75();
			break;
		case Enum155.const_164:
			method_53();
			break;
		case Enum155.const_165:
			method_52();
			break;
		case Enum155.const_166:
			method_27();
			break;
		case Enum155.const_186:
			method_79();
			break;
		case Enum155.const_82:
		case Enum155.const_84:
		case Enum155.const_91:
		case Enum155.const_94:
		case Enum155.const_96:
		case Enum155.const_97:
		case Enum155.const_109:
		case Enum155.const_116:
		case Enum155.const_118:
		case Enum155.const_119:
		case Enum155.const_120:
		case Enum155.const_51:
		case Enum155.const_133:
		case Enum155.const_134:
		case Enum155.const_136:
		case Enum155.const_137:
		case Enum155.const_139:
		case Enum155.const_140:
		case Enum155.const_141:
		case Enum155.const_142:
		case Enum155.const_146:
		case Enum155.const_147:
		case Enum155.const_148:
		case Enum155.const_167:
		case Enum155.const_168:
		case Enum155.const_169:
		case Enum155.const_170:
		case Enum155.const_171:
		case Enum155.const_172:
		case Enum155.const_173:
		case Enum155.const_174:
		case Enum155.const_175:
		case Enum155.const_176:
		case Enum155.const_177:
		case Enum155.const_178:
		case Enum155.const_179:
		case Enum155.const_180:
		case Enum155.const_181:
		case Enum155.const_182:
		case Enum155.const_183:
		case Enum155.const_184:
		case Enum155.const_185:
			break;
		}
	}

	private void method_14()
	{
		method_6().ReadSingle();
	}

	private void method_15()
	{
		method_6().method_5();
		int num = method_6().ReadInt32();
		int num2 = method_6().ReadInt32();
		int num3 = method_6().ReadInt32();
		int num4 = method_6().ReadInt32();
		int num5 = method_6().ReadInt32();
		int num6 = method_6().ReadInt32();
		method_6().ReadInt32();
		int int_ = method_6().ReadInt32();
		method_6().ReadInt32();
		int num7 = method_6().ReadInt32();
		method_6().ReadInt32();
		method_6().ReadInt32();
		int num8 = method_6().ReadInt32();
		int num9 = method_6().ReadInt32();
		RectangleF rectangleF = new RectangleF(num, num2, num8, num9);
		if (num7 == 0)
		{
			method_7().vmethod_5(rectangleF);
			return;
		}
		byte[] byte_ = Class1404.smethod_18(method_6(), int_, num7);
		RectangleF rectangleF_ = new RectangleF(num3, num4, num5, num6);
		method_7().vmethod_16(rectangleF_, rectangleF, byte_);
	}

	private void method_16()
	{
		method_6().method_5();
		int num = method_6().ReadInt32();
		int num2 = method_6().ReadInt32();
		int num3 = method_6().ReadInt32();
		int num4 = method_6().ReadInt32();
		Enum158 @enum = (Enum158)method_6().ReadUInt32();
		int num5 = method_6().ReadInt32();
		int num6 = method_6().ReadInt32();
		Matrix matrix_ = method_6().method_13();
		Color color_ = method_6().method_6();
		method_6().ReadUInt32();
		method_6().ReadUInt32();
		int int_ = method_6().ReadInt32();
		method_6().ReadUInt32();
		int num7 = method_6().ReadInt32();
		RectangleF rectangleF = new RectangleF(num, num2, num3, num4);
		if (num7 == 0)
		{
			if (@enum == Enum158.const_0 || @enum == Enum158.const_9)
			{
				method_7().vmethod_5(rectangleF);
			}
		}
		else
		{
			int num8 = method_6().ReadInt32();
			int num9 = method_6().ReadInt32();
			byte[] byte_ = Class1404.smethod_18(method_6(), int_, num7);
			RectangleF rectangleF_ = new RectangleF(num5, num6, num8, num9);
			method_7().method_7(rectangleF_, rectangleF, matrix_, color_, @enum, byte_);
		}
	}

	private void method_17()
	{
		method_16();
	}

	private void method_18()
	{
		method_1().method_21((Enum160)method_6().ReadInt32());
	}

	private void method_19()
	{
		Matrix matrix_ = method_6().method_13();
		Enum163 enum163_ = (Enum163)method_6().ReadInt32();
		method_1().method_31(matrix_, enum163_);
	}

	private void method_20()
	{
		Matrix matrix_ = method_6().method_13();
		method_1().method_30(matrix_);
	}

	private void method_21()
	{
		method_7().method_15();
	}

	private void method_22()
	{
		method_7().method_16();
	}

	private void method_23()
	{
		method_7().method_14();
	}

	private void method_24()
	{
		method_7().method_18();
	}

	private void method_25()
	{
		method_7().method_19();
	}

	private void method_26()
	{
		method_7().method_20();
	}

	private void method_27()
	{
		method_1().method_20((Enum152)method_6().ReadInt32());
	}

	private void method_28()
	{
		method_6().ReadInt32();
		int num = method_6().ReadInt32();
		Enum167 @enum = (Enum167)num;
		if (@enum == Enum167.const_4)
		{
			method_7().method_24(Enum159.const_4);
		}
	}

	private void method_29()
	{
		RectangleF rectangleF = method_6().method_5();
		PointF[] array = new PointF[2] { rectangleF.Location, rectangleF.Location };
		array[1].X += rectangleF.Width;
		array[1].Y += rectangleF.Height;
		method_1().method_29().TransformPoints(array);
		RectangleF rectangleF_ = new RectangleF(array[0], new SizeF(array[1].X - array[0].X, array[1].Y - array[0].Y));
		method_7().vmethod_17(rectangleF_);
	}

	private void method_30()
	{
		int enum159_ = method_6().ReadInt32();
		method_7().method_24((Enum159)enum159_);
	}

	private void method_31()
	{
		method_7().method_21();
		method_8();
	}

	private void method_32()
	{
		method_9();
		method_7().method_22();
	}

	private void method_33()
	{
		method_1().method_17((Enum154)method_6().ReadInt32());
		method_1().method_27();
	}

	private void method_34()
	{
		method_6().ReadInt32();
	}

	private void method_35()
	{
		method_1().method_19((Enum150)method_6().ReadUInt32());
	}

	private void method_36()
	{
		method_1().method_1(method_6().method_3());
		method_1().method_27();
	}

	private void method_37()
	{
		SizeF sizeF_ = method_6().method_4();
		method_1().method_2(sizeF_);
		method_1().method_27();
	}

	private SizeF method_38(SizeF sizeF_0)
	{
		int num = method_6().ReadInt32();
		int num2 = method_6().ReadInt32();
		int num3 = method_6().ReadInt32();
		int num4 = method_6().ReadInt32();
		if (num == 0 || num3 == 0)
		{
			throw new Exception("Invalid scale values.");
		}
		return new SizeF(sizeF_0.Width * (float)num4 / (float)num3, sizeF_0.Height * (float)num2 / (float)num);
	}

	private void method_39()
	{
		SizeF sizeF = method_38(method_1().method_12().Size);
		method_1().method_26().Scale(sizeF.Width / method_1().method_12().Size.Width, sizeF.Height / method_1().method_12().Size.Height);
	}

	private void method_40()
	{
		method_6().method_3();
	}

	private void method_41()
	{
		method_13(method_6().method_3());
		method_1().method_27();
	}

	private void method_42()
	{
		SizeF sizeF = method_6().method_4();
		method_12(sizeF);
		method_1().method_3(sizeF);
		method_1().method_27();
	}

	private void method_43()
	{
		method_12(method_38(method_3().Size));
		method_1().method_27();
	}

	private void method_44()
	{
		method_1().method_16((Enum161)method_6().ReadUInt32());
	}

	private void method_45()
	{
		method_1().method_14(method_6().method_6());
	}

	private void method_46()
	{
		method_1().BackgroundMode = (Enum145)method_6().ReadInt32();
	}

	private void method_47()
	{
		method_1().BackgroundColor = method_6().method_6();
	}

	private void method_48()
	{
		method_1().method_25((Enum149)method_6().ReadInt32());
	}

	private void method_49()
	{
		method_51();
	}

	private void method_50()
	{
		PointF pointF_ = method_6().method_3();
		int num = method_6().ReadInt32();
		method_6().ReadInt32();
		int num2 = method_6().ReadInt32();
		RectangleF rectangleF_ = method_6().method_5();
		if (num2 == 2)
		{
			using SolidBrush brush_ = new SolidBrush(Color.FromArgb(255, method_1().BackgroundColor.R, method_1().BackgroundColor.G, method_1().BackgroundColor.B));
			method_7().method_6(rectangleF_, brush_);
		}
		method_6().ReadInt32();
		string string_ = method_6().method_2(num);
		if (num != 0)
		{
			method_7().vmethod_1(pointF_, string_);
		}
	}

	private void method_51()
	{
		method_6().method_5();
		method_6().ReadInt32();
		method_6().ReadSingle();
		method_6().ReadSingle();
		method_50();
	}

	private void method_52()
	{
		method_53();
	}

	private void method_53()
	{
		method_6().method_5();
		method_6().ReadInt32();
		method_6().ReadSingle();
		method_6().ReadSingle();
		int num = method_6().ReadInt32();
		for (int i = 0; i < num; i++)
		{
			method_50();
		}
	}

	private void method_54()
	{
		RectangleF rectangleF_ = method_6().method_5();
		method_7().vmethod_4(rectangleF_);
	}

	private void method_55()
	{
		RectangleF rectangleF_ = method_6().method_5();
		SizeF sizeF_ = method_6().method_4();
		method_7().vmethod_15(rectangleF_, sizeF_);
	}

	private void method_56()
	{
		method_5(method_6().method_3());
	}

	private void method_57()
	{
		PointF pointF_ = method_6().method_3();
		method_7().vmethod_3(pointF_);
		method_5(pointF_);
	}

	private void method_58()
	{
		PointF pointF_ = method_6().method_3();
		Color color_ = method_6().method_6();
		method_7().vmethod_2(pointF_, color_);
	}

	private PointF[] method_59(PointF[] pointF_0)
	{
		PointF[] array = new PointF[pointF_0.Length + 1];
		ref PointF reference = ref array[0];
		reference = method_4();
		pointF_0.CopyTo(array, 1);
		return array;
	}

	private void method_60(Enum165 enum165_0)
	{
		method_6().method_5();
		PointF[] array = ((!smethod_0(enum165_0)) ? method_6().method_7() : method_6().method_9());
		if (array.Length >= 1)
		{
			if (smethod_1(enum165_0))
			{
				array = method_59(array);
				method_7().vmethod_6(array);
				method_5(array[array.Length - 1]);
			}
			else
			{
				method_7().vmethod_6(array);
			}
		}
	}

	private void method_61(Enum165 enum165_0)
	{
		method_7().rectangleF_0 = method_6().method_5();
		PointF[] array = ((!smethod_0(enum165_0)) ? method_6().method_7() : method_6().method_9());
		if (array.Length >= 1)
		{
			if (smethod_1(enum165_0))
			{
				array = method_59(array);
				method_7().vmethod_7(array);
				method_5(array[array.Length - 1]);
			}
			else
			{
				method_7().vmethod_7(array);
			}
		}
	}

	private void method_62(Enum165 enum165_0)
	{
		method_6().method_5();
		if (smethod_0(enum165_0))
		{
			method_7().vmethod_8(method_6().method_12());
		}
		else
		{
			method_7().vmethod_8(method_6().method_11());
		}
	}

	private void method_63(Enum165 enum165_0)
	{
		method_6().method_5();
		if (smethod_0(enum165_0))
		{
			method_7().vmethod_9(method_6().method_9());
		}
		else
		{
			method_7().vmethod_9(method_6().method_7());
		}
	}

	private void method_64(Enum165 enum165_0)
	{
		method_6().method_5();
		if (smethod_0(enum165_0))
		{
			method_7().vmethod_10(method_6().method_12());
		}
		else
		{
			method_7().vmethod_10(method_6().method_11());
		}
	}

	private void method_65(Enum165 enum165_0)
	{
		method_6().method_5();
		int num = method_6().ReadInt32();
		PointF[] array = ((!smethod_0(enum165_0)) ? method_6().method_8(num) : method_6().method_10(num));
		Enum164[] array2 = method_6().method_14(num);
		int num2 = 0;
		do
		{
			if ((array2[num2] & Enum164.flag_3) == Enum164.flag_3)
			{
				method_5(array[num2]);
				num2++;
			}
			if ((array2[num2] & Enum164.flag_1) == Enum164.flag_1)
			{
				method_7().vmethod_3(array[num2]);
				method_5(array[num2]);
				if ((array2[num2] & Enum164.flag_0) == Enum164.flag_0)
				{
					break;
				}
				num2++;
			}
			if ((array2[num2] & Enum164.flag_2) == Enum164.flag_2)
			{
				PointF[] pointF_ = new PointF[4]
				{
					method_4(),
					array[++num2],
					array[++num2],
					array[++num2]
				};
				method_7().vmethod_7(pointF_);
				method_5(array[num2]);
				if ((array2[num2] & Enum164.flag_0) == Enum164.flag_0)
				{
					break;
				}
			}
		}
		while (num2 < num);
	}

	private void method_66(Enum165 enum165_0)
	{
		RectangleF rectangleF_ = method_6().method_5();
		PointF pointF_ = method_6().method_3();
		PointF pointF = method_6().method_3();
		method_7().vmethod_11(rectangleF_, pointF_, pointF);
		if ((enum165_0 & Enum165.flag_2) == Enum165.flag_2)
		{
			method_5(pointF);
		}
	}

	private void method_67()
	{
		RectangleF rectangleF = method_6().method_5();
		rectangleF = new RectangleF(rectangleF.X, rectangleF.Y, Math.Abs(rectangleF.Width), Math.Abs(rectangleF.Height));
		method_7().vmethod_12(rectangleF);
	}

	private void method_68()
	{
		RectangleF rectangleF_ = method_6().method_5();
		PointF pointF_ = method_6().method_3();
		PointF pointF_2 = method_6().method_3();
		method_7().vmethod_14(rectangleF_, pointF_, pointF_2);
	}

	private void method_69()
	{
		RectangleF rectangleF_ = method_6().method_5();
		PointF pointF_ = method_6().method_3();
		PointF pointF_2 = method_6().method_3();
		method_7().vmethod_13(rectangleF_, pointF_, pointF_2);
	}

	private void method_70()
	{
		Class1409 @class = new Class1409();
		@class.method_3(method_6());
		method_10(@class);
	}

	private void method_71()
	{
		Class1409 @class = new Class1409();
		@class.method_4(method_6());
		method_10(@class);
	}

	private void method_72()
	{
		method_71();
	}

	private void method_73()
	{
		Class1411 @class = new Class1411();
		@class.method_1(method_6());
		method_10(@class);
	}

	private void method_74()
	{
		Class1413 @class = new Class1413();
		@class.method_1(method_6());
		method_10(@class);
	}

	private void method_75()
	{
		Class1413 @class = new Class1413();
		@class.method_2(method_6());
		method_10(@class);
	}

	private void method_76()
	{
		Class1412 @class = new Class1412();
		@class.method_0(method_6());
		method_10(@class);
	}

	private void method_77()
	{
		method_1().method_0(method_6().ReadUInt32());
	}

	private void method_78()
	{
		method_11(method_6().ReadUInt32());
	}

	private void method_79()
	{
		method_6().method_5();
		Class1046[] array = new Class1046[method_6().ReadInt32()];
		Class1043[] array2 = new Class1043[method_6().ReadInt32()];
		int num = method_6().ReadInt32();
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new Class1046(method_6());
		}
		for (int j = 0; j < array2.Length; j++)
		{
			if (num == 2)
			{
				array2[j] = new Class1045(method_6(), method_7());
			}
			else
			{
				array2[j] = new Class1044(method_6(), method_7());
			}
		}
		Class1043[] array3 = array2;
		foreach (Class1043 @class in array3)
		{
			@class.vmethod_0(array);
		}
	}

	private static bool smethod_0(Enum165 enum165_0)
	{
		return (enum165_0 & Enum165.flag_1) == Enum165.flag_1;
	}

	private static bool smethod_1(Enum165 enum165_0)
	{
		return (enum165_0 & Enum165.flag_2) == Enum165.flag_2;
	}

	private void method_80()
	{
		int int_ = method_6().ReadInt32();
		switch ((Enum143)method_6().ReadUInt32())
		{
		case Enum143.const_1:
			method_81(int_);
			break;
		}
	}

	private void method_81(int int_0)
	{
		switch ((Enum144)method_6().ReadUInt16())
		{
		case Enum144.const_1:
			method_6().ReadBytes(12);
			break;
		case Enum144.const_4:
		case Enum144.const_5:
		case Enum144.const_6:
		case Enum144.const_7:
		case Enum144.const_43:
			method_83();
			break;
		case Enum144.const_0:
		case Enum144.const_3:
		case Enum144.const_9:
		case Enum144.const_10:
		case Enum144.const_11:
		case Enum144.const_12:
		case Enum144.const_13:
		case Enum144.const_14:
		case Enum144.const_15:
		case Enum144.const_16:
		case Enum144.const_18:
		case Enum144.const_19:
		case Enum144.const_20:
		case Enum144.const_21:
		case Enum144.const_25:
		case Enum144.const_26:
		case Enum144.const_27:
		case Enum144.const_40:
		case Enum144.const_53:
			method_82();
			break;
		case Enum144.const_2:
		case Enum144.const_8:
		case Enum144.const_17:
		case Enum144.const_22:
		case Enum144.const_23:
		case Enum144.const_24:
		case Enum144.const_28:
		case Enum144.const_29:
		case Enum144.const_30:
		case Enum144.const_31:
		case Enum144.const_32:
		case Enum144.const_33:
		case Enum144.const_34:
		case Enum144.const_35:
		case Enum144.const_36:
		case Enum144.const_37:
		case Enum144.const_38:
		case Enum144.const_39:
		case Enum144.const_41:
		case Enum144.const_42:
		case Enum144.const_44:
		case Enum144.const_45:
		case Enum144.const_46:
		case Enum144.const_47:
		case Enum144.const_48:
		case Enum144.const_49:
		case Enum144.const_50:
		case Enum144.const_51:
		case Enum144.const_52:
		case Enum144.const_54:
		case Enum144.const_55:
		case Enum144.const_56:
		case Enum144.const_57:
			break;
		}
	}

	private void method_82()
	{
		method_6().ReadUInt16();
		method_6().ReadUInt32();
		method_6().ReadUInt32();
		method_6().ReadUInt32();
		method_6().ReadUInt32();
		method_6().ReadInt32();
		method_6().ReadInt32();
	}

	private void method_83()
	{
		method_6().ReadUInt16();
		method_6().ReadUInt32();
		uint count = method_6().ReadUInt32();
		method_6().ReadBytes((int)count);
	}
}
