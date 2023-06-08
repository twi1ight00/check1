using System;
using System.Drawing;
using System.IO;
using System.Text;
using ns224;
using ns233;
using ns234;
using ns271;

namespace ns264;

internal class Class6488 : Class6485
{
	private int int_0;

	private Class6498 class6498_0;

	protected override void vmethod_0()
	{
		Stream stream = base.MetafileInfo.Stream;
		stream.Position = base.MetafileInfo.DataStartPos;
		class6498_0 = new Class6498(stream);
		while (stream.Position < stream.Length && stream.Position + 8L <= stream.Length)
		{
			int num = (int)stream.Position;
			Enum838 recordType = (Enum838)class6498_0.ReadInt32();
			int num2 = class6498_0.ReadInt32();
			if (method_32(recordType))
			{
				int num3 = num + num2;
				if (stream.Position != num3)
				{
					stream.Position = num3;
				}
				continue;
			}
			break;
		}
	}

	private bool method_32(Enum838 recordType)
	{
		switch (recordType)
		{
		case Enum838.const_0:
			return false;
		case Enum838.const_2:
			method_67(Enum846.flag_0);
			break;
		case Enum838.const_3:
			method_69(Enum846.flag_0);
			break;
		case Enum838.const_4:
			method_66(Enum846.flag_0);
			break;
		case Enum838.const_5:
			method_67(Enum846.flag_2);
			break;
		case Enum838.const_6:
			method_66(Enum846.flag_2);
			break;
		case Enum838.const_7:
			method_68(Enum846.flag_0);
			break;
		case Enum838.const_8:
			method_70(Enum846.flag_0);
			break;
		case Enum838.const_9:
			method_18(class6498_0.method_7());
			break;
		case Enum838.const_10:
			method_17(class6498_0.method_6());
			break;
		case Enum838.const_11:
			method_31(class6498_0.method_7());
			break;
		case Enum838.const_12:
			method_19(class6498_0.method_6());
			break;
		case Enum838.const_14:
			return false;
		case Enum838.const_15:
			method_64();
			break;
		case Enum838.const_17:
			method_16((Enum843)class6498_0.ReadInt32());
			break;
		case Enum838.const_18:
			method_24((Enum842)class6498_0.ReadInt32());
			break;
		case Enum838.const_19:
			method_54();
			break;
		case Enum838.const_20:
			method_55();
			break;
		case Enum838.const_21:
			method_36();
			break;
		case Enum838.const_22:
			method_26((Enum845)class6498_0.ReadInt32());
			break;
		case Enum838.const_24:
			method_25(class6498_0.method_9());
			break;
		case Enum838.const_25:
			method_15(class6498_0.method_9());
			break;
		case Enum838.const_26:
			method_14(class6498_0.method_7());
			break;
		case Enum838.const_27:
			method_27(class6498_0.method_6());
			break;
		case Enum838.const_28:
			method_53();
			break;
		case Enum838.const_29:
			method_13(class6498_0.method_8());
			break;
		case Enum838.const_30:
			method_12(class6498_0.method_8());
			break;
		case Enum838.const_31:
			method_20(method_56(base.ViewportRect.Size));
			break;
		case Enum838.const_32:
			method_18(method_56(base.DC.WindowRect.Size));
			break;
		case Enum838.const_33:
			method_3();
			int_0++;
			break;
		case Enum838.const_34:
			int_0--;
			method_4();
			break;
		case Enum838.const_35:
			method_38();
			break;
		case Enum838.const_36:
			method_37();
			break;
		case Enum838.const_37:
			method_22(class6498_0.ReadInt32());
			break;
		case Enum838.const_38:
			method_80();
			break;
		case Enum838.const_39:
			method_76();
			break;
		case Enum838.const_40:
			method_23(class6498_0.ReadInt32());
			break;
		case Enum838.const_42:
			method_73();
			break;
		case Enum838.const_43:
			method_29(class6498_0.method_8());
			break;
		case Enum838.const_44:
			method_63();
			break;
		case Enum838.const_45:
			method_72(Enum846.flag_0);
			break;
		case Enum838.const_46:
			method_74();
			break;
		case Enum838.const_47:
			method_75();
			break;
		case Enum838.const_49:
			method_82();
			break;
		case Enum838.const_54:
			method_28(class6498_0.method_6());
			break;
		case Enum838.const_55:
			method_72(Enum846.flag_2);
			break;
		case Enum838.const_56:
			method_71(Enum846.flag_0);
			break;
		case Enum838.const_59:
			method_39();
			break;
		case Enum838.const_60:
			method_40();
			break;
		case Enum838.const_61:
			method_41();
			break;
		case Enum838.const_62:
			method_42();
			break;
		case Enum838.const_63:
			method_44();
			break;
		case Enum838.const_64:
			method_43();
			break;
		case Enum838.const_67:
			method_52();
			break;
		case Enum838.const_71:
			method_46();
			break;
		case Enum838.const_72:
			method_47();
			break;
		case Enum838.const_73:
			method_48();
			break;
		case Enum838.const_74:
			method_49();
			break;
		case Enum838.const_75:
			method_51();
			break;
		case Enum838.const_76:
			method_35();
			break;
		case Enum838.const_77:
			method_34();
			break;
		case Enum838.const_81:
			method_33();
			break;
		case Enum838.const_82:
			method_79();
			break;
		case Enum838.const_83:
			method_57();
			break;
		case Enum838.const_84:
			method_60();
			break;
		case Enum838.const_85:
			method_67(Enum846.flag_1);
			break;
		case Enum838.const_86:
			method_69(Enum846.flag_1);
			break;
		case Enum838.const_87:
			method_66(Enum846.flag_1);
			break;
		case Enum838.const_88:
			method_67(Enum846.flag_1 | Enum846.flag_2);
			break;
		case Enum838.const_89:
			method_66(Enum846.flag_1 | Enum846.flag_2);
			break;
		case Enum838.const_90:
			method_68(Enum846.flag_1);
			break;
		case Enum838.const_91:
			method_70(Enum846.flag_1);
			break;
		case Enum838.const_92:
			method_71(Enum846.flag_1);
			break;
		case Enum838.const_93:
			method_78();
			break;
		case Enum838.const_94:
			method_77();
			break;
		case Enum838.const_95:
			method_81();
			break;
		case Enum838.const_96:
			method_62();
			break;
		case Enum838.const_97:
			method_61();
			break;
		case Enum838.const_98:
			method_45();
			break;
		}
		return true;
	}

	private void method_33()
	{
		class6498_0.method_8();
		int num = class6498_0.ReadInt32();
		int num2 = class6498_0.ReadInt32();
		int num3 = class6498_0.ReadInt32();
		int num4 = class6498_0.ReadInt32();
		int num5 = class6498_0.ReadInt32();
		int num6 = class6498_0.ReadInt32();
		class6498_0.ReadInt32();
		int headerLength = class6498_0.ReadInt32();
		class6498_0.ReadInt32();
		int num7 = class6498_0.ReadInt32();
		class6498_0.ReadInt32();
		class6498_0.ReadInt32();
		int num8 = class6498_0.ReadInt32();
		int num9 = class6498_0.ReadInt32();
		RectangleF rectangleF = new RectangleF(num, num2, num8, num9);
		if (num7 == 0)
		{
			class6479_0.vmethod_10(rectangleF);
			return;
		}
		byte[] imageBytes = Class6148.smethod_22(class6498_0, headerLength, num7);
		RectangleF srcRectangle = new RectangleF(num3, num4, num5, num6);
		class6479_0.vmethod_22(srcRectangle, rectangleF, imageBytes);
	}

	private void method_34()
	{
		class6498_0.method_8();
		int num = class6498_0.ReadInt32();
		int num2 = class6498_0.ReadInt32();
		int num3 = class6498_0.ReadInt32();
		int num4 = class6498_0.ReadInt32();
		Enum862 @enum = (Enum862)class6498_0.ReadInt32();
		int num5 = class6498_0.ReadInt32();
		int num6 = class6498_0.ReadInt32();
		Class6002 matrix = class6498_0.method_16();
		Class5998 color = class6498_0.method_9();
		class6498_0.ReadInt32();
		class6498_0.ReadInt32();
		int headerLength = class6498_0.ReadInt32();
		class6498_0.ReadInt32();
		int num7 = class6498_0.ReadInt32();
		RectangleF rectangleF = new RectangleF(num, num2, num3, num4);
		if (num7 == 0)
		{
			switch (@enum)
			{
			case Enum862.const_0:
			case Enum862.const_9:
				class6479_0.vmethod_10(rectangleF);
				break;
			case Enum862.const_11:
				bool_0 = true;
				break;
			}
		}
		else
		{
			int num8 = class6498_0.ReadInt32();
			int num9 = class6498_0.ReadInt32();
			byte[] bytes = Class6148.smethod_22(class6498_0, headerLength, num7);
			RectangleF srcRectangle = new RectangleF(num5, num6, num8, num9);
			class6479_0.vmethod_25(srcRectangle, rectangleF, matrix, color, @enum, bytes);
		}
	}

	private void method_35()
	{
		method_34();
	}

	private void method_36()
	{
		base.DC.StretchBltMode = (Enum848)class6498_0.ReadInt32();
	}

	private void method_37()
	{
		Class6002 matrix = class6498_0.method_16();
		Enum859 mode = (Enum859)class6498_0.ReadInt32();
		base.DC.method_15(matrix, mode);
		class6479_0.vmethod_26();
	}

	private void method_38()
	{
		Class6002 matrix = class6498_0.method_16();
		base.DC.method_14(matrix);
		class6479_0.vmethod_26();
	}

	private void method_39()
	{
		class6479_0.vmethod_27();
	}

	private void method_40()
	{
		class6479_0.vmethod_28();
	}

	private void method_41()
	{
		class6479_0.vmethod_29();
	}

	private void method_42()
	{
		class6479_0.vmethod_30();
	}

	private void method_43()
	{
		class6479_0.vmethod_31();
	}

	private void method_44()
	{
		class6479_0.vmethod_32();
	}

	private void method_45()
	{
		base.DC.IcmMode = (Enum847)class6498_0.ReadInt32();
	}

	private void method_46()
	{
		class6498_0.method_8();
		class6498_0.ReadInt32();
		int handle = class6498_0.ReadInt32();
		Class6499 region = method_50();
		class6479_0.vmethod_11(region, null, base.DC.method_10(handle));
	}

	private void method_47()
	{
		class6498_0.method_8();
		class6498_0.ReadInt32();
		int handle = class6498_0.ReadInt32();
		int num = class6498_0.ReadInt32();
		class6498_0.ReadInt32();
		Class6003 pen = new Class6003(base.DC.method_10(handle), num);
		Class6499 region = method_50();
		class6479_0.vmethod_11(region, pen, null);
	}

	private void method_48()
	{
		class6498_0.method_8();
		class6498_0.ReadInt32();
		Class6499 region = method_50();
		class6479_0.vmethod_11(region, new Class6003(Class5998.class5998_7), null);
	}

	private void method_49()
	{
		class6498_0.method_8();
		class6498_0.ReadInt32();
		Class6499 region = method_50();
		class6479_0.vmethod_11(region, null, base.DC.Brush);
	}

	private Class6499 method_50()
	{
		Class6499 @class = new Class6499();
		@class.method_1(class6498_0);
		return @class;
	}

	private void method_51()
	{
		class6479_0.vmethod_5();
		int num = class6498_0.ReadInt32();
		Enum864 @enum = (Enum864)class6498_0.ReadInt32();
		if (@enum != Enum864.const_4)
		{
			using (Region region = Class6164.smethod_0(class6498_0))
			{
				switch (@enum)
				{
				case Enum864.const_0:
					base.DC.ClipRegion.Intersect(region);
					break;
				case Enum864.const_1:
					base.DC.ClipRegion.Union(region);
					break;
				case Enum864.const_2:
					base.DC.ClipRegion.Xor(region);
					break;
				case Enum864.const_3:
					base.DC.ClipRegion.Complement(region);
					break;
				case Enum864.const_4:
					base.DC.ClipRegion = region;
					break;
				}
				return;
			}
		}
		if (num == 0)
		{
			base.DC.ClipRegion = null;
		}
		else
		{
			base.DC.ClipRegion = Class6164.smethod_0(class6498_0);
		}
	}

	private void method_52()
	{
		Enum864 mode = (Enum864)class6498_0.ReadInt32();
		class6479_0.vmethod_33(mode);
	}

	private void method_53()
	{
		base.DC.ClipRegion = null;
	}

	private void method_54()
	{
		base.DC.FillMode = (Enum844)class6498_0.ReadInt32();
		class6479_0.vmethod_34(base.DC.FillMode);
	}

	private void method_55()
	{
		base.DC.BinaryRasterOperation = (Enum861)class6498_0.ReadUInt32();
	}

	private SizeF method_56(SizeF oldSize)
	{
		int num = class6498_0.ReadInt32();
		int num2 = class6498_0.ReadInt32();
		int num3 = class6498_0.ReadInt32();
		int num4 = class6498_0.ReadInt32();
		if (num == 0 || num3 == 0)
		{
			throw new InvalidOperationException("Invalid scale values.");
		}
		return new SizeF(oldSize.Width * (float)num4 / (float)num3, oldSize.Height * (float)num2 / (float)num);
	}

	private void method_57()
	{
		method_60();
	}

	private void method_58()
	{
		PointF origin = class6498_0.method_6();
		int num = class6498_0.ReadInt32();
		if (num != 0)
		{
			class6498_0.ReadInt32();
			int num2 = class6498_0.ReadInt32();
			class6498_0.method_8();
			class6498_0.ReadInt32();
			string text;
			if (((uint)num2 & 0x10u) != 0)
			{
				int[] glyphIndexes = class6498_0.method_2(num);
				text = method_59(glyphIndexes);
			}
			else
			{
				text = class6498_0.method_5(num);
			}
			class6479_0.vmethod_9(origin, text);
		}
	}

	private string method_59(int[] glyphIndexes)
	{
		if (base.DC.Font != null && base.DC.Font.TrueTypeFont != null && base.DC.Font.TrueTypeFont.Glyphs != null)
		{
			Class6735 glyphs = base.DC.Font.TrueTypeFont.Glyphs;
			StringBuilder stringBuilder = new StringBuilder(glyphIndexes.Length);
			foreach (int glyphIndex in glyphIndexes)
			{
				stringBuilder.Append(glyphs.method_1(glyphIndex).CharCode);
			}
			return stringBuilder.ToString();
		}
		return string.Empty;
	}

	private void method_60()
	{
		class6498_0.method_8();
		class6498_0.ReadInt32();
		class6498_0.ReadSingle();
		class6498_0.ReadSingle();
		method_58();
	}

	private void method_61()
	{
		method_62();
	}

	private void method_62()
	{
		class6498_0.method_8();
		class6498_0.ReadInt32();
		class6498_0.ReadSingle();
		class6498_0.ReadSingle();
		int num = class6498_0.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			method_58();
		}
	}

	private void method_63()
	{
		RectangleF bounds = class6498_0.method_8();
		SizeF ellipse = class6498_0.method_7();
		class6479_0.vmethod_20(bounds, ellipse);
	}

	private void method_64()
	{
		PointF position = class6498_0.method_6();
		Class5998 color = class6498_0.method_9();
		class6479_0.vmethod_21(position, color);
	}

	private PointF[] method_65(PointF[] pointsArray)
	{
		PointF[] array = new PointF[pointsArray.Length + 1];
		ref PointF reference = ref array[0];
		reference = base.CurrentPosition;
		pointsArray.CopyTo(array, 1);
		return array;
	}

	private void method_66(Enum846 funcType)
	{
		class6498_0.method_8();
		PointF[] array = ((!smethod_2(funcType)) ? class6498_0.method_10() : class6498_0.method_12());
		if (array.Length >= 1)
		{
			if (smethod_3(funcType))
			{
				array = method_65(array);
				class6479_0.vmethod_16(array);
				base.CurrentPosition = array[array.Length - 1];
			}
			else
			{
				class6479_0.vmethod_16(array);
			}
		}
	}

	private void method_67(Enum846 funcType)
	{
		class6498_0.method_8();
		PointF[] array = ((!smethod_2(funcType)) ? class6498_0.method_10() : class6498_0.method_12());
		if (array.Length >= 1)
		{
			if (smethod_3(funcType))
			{
				array = method_65(array);
				class6479_0.vmethod_14(array);
				base.CurrentPosition = array[array.Length - 1];
			}
			else
			{
				class6479_0.vmethod_14(array);
			}
		}
	}

	private void method_68(Enum846 funcType)
	{
		class6498_0.method_8();
		PointF[][] pointsPoints = (smethod_2(funcType) ? class6498_0.method_15() : class6498_0.method_14());
		class6479_0.vmethod_18(pointsPoints);
	}

	private void method_69(Enum846 funcType)
	{
		class6498_0.method_8();
		PointF[] points = (smethod_2(funcType) ? class6498_0.method_12() : class6498_0.method_10());
		class6479_0.vmethod_15(points);
	}

	private void method_70(Enum846 funcType)
	{
		class6498_0.method_8();
		if (smethod_2(funcType))
		{
			class6479_0.vmethod_17(class6498_0.method_15());
		}
		else
		{
			class6479_0.vmethod_17(class6498_0.method_14());
		}
	}

	private void method_71(Enum846 funcType)
	{
		class6498_0.method_8();
		int num = class6498_0.ReadInt32();
		PointF[] array = ((!smethod_2(funcType)) ? class6498_0.method_11(num) : class6498_0.method_13(num));
		Enum857[] array2 = class6498_0.method_17(num);
		int num2 = 0;
		do
		{
			if ((array2[num2] & Enum857.flag_3) == Enum857.flag_3)
			{
				base.CurrentPosition = array[num2];
				num2++;
			}
			if ((array2[num2] & Enum857.flag_1) == Enum857.flag_1)
			{
				class6479_0.vmethod_12(array[num2]);
				base.CurrentPosition = array[num2];
				if ((array2[num2] & Enum857.flag_0) == Enum857.flag_0)
				{
					break;
				}
				num2++;
			}
			if ((array2[num2] & Enum857.flag_2) == Enum857.flag_2)
			{
				PointF[] points = new PointF[4]
				{
					base.CurrentPosition,
					array[++num2],
					array[++num2],
					array[++num2]
				};
				class6479_0.vmethod_14(points);
				base.CurrentPosition = array[num2];
				if ((array2[num2] & Enum857.flag_0) == Enum857.flag_0)
				{
					break;
				}
			}
		}
		while (num2 < num);
	}

	private void method_72(Enum846 funcType)
	{
		RectangleF bounds = class6498_0.method_8();
		PointF start = class6498_0.method_6();
		PointF pointF = class6498_0.method_6();
		class6479_0.vmethod_6(bounds, start, pointF);
		if ((funcType & Enum846.flag_2) == Enum846.flag_2)
		{
			base.CurrentPosition = pointF;
		}
	}

	private void method_73()
	{
		RectangleF rectangleF = class6498_0.method_8();
		rectangleF = new RectangleF(rectangleF.X, rectangleF.Y, Math.Abs(rectangleF.Width), Math.Abs(rectangleF.Height));
		class6479_0.vmethod_8(rectangleF);
	}

	private void method_74()
	{
		RectangleF bounds = class6498_0.method_8();
		PointF start = class6498_0.method_6();
		PointF end = class6498_0.method_6();
		class6479_0.vmethod_7(bounds, start, end);
	}

	private void method_75()
	{
		RectangleF bounds = class6498_0.method_8();
		PointF start = class6498_0.method_6();
		PointF end = class6498_0.method_6();
		class6479_0.vmethod_13(bounds, start, end);
	}

	private void method_76()
	{
		Class6491 @class = new Class6491();
		@class.method_3(class6498_0);
		method_21(@class);
	}

	private void method_77()
	{
		Class6491 @class = new Class6491();
		@class.method_4(class6498_0);
		method_21(@class);
	}

	private void method_78()
	{
		method_77();
	}

	private void method_79()
	{
		Class6493 @class = new Class6493();
		@class.method_1(class6498_0);
		method_21(@class);
	}

	private void method_80()
	{
		Class6495 @class = new Class6495();
		@class.method_1(class6498_0);
		method_21(@class);
	}

	private void method_81()
	{
		Class6495 @class = new Class6495();
		@class.method_2(class6498_0);
		method_21(@class);
	}

	private void method_82()
	{
		Class6494 @class = new Class6494();
		@class.method_0(class6498_0);
		method_21(@class);
	}

	private static bool smethod_2(Enum846 functionType)
	{
		return (functionType & Enum846.flag_1) == Enum846.flag_1;
	}

	private static bool smethod_3(Enum846 functionType)
	{
		return (functionType & Enum846.flag_2) == Enum846.flag_2;
	}
}
