using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using ns218;
using ns224;
using ns233;

namespace ns264;

internal class Class6486 : Class6485
{
	private const int int_0 = 6;

	private Class6501 class6501_0;

	protected Class6501 Reader => class6501_0;

	protected override void vmethod_0()
	{
		Stream stream = base.MetafileInfo.Stream;
		stream.Position = base.MetafileInfo.DataStartPos;
		class6501_0 = new Class6501(stream);
		while (stream.Position < stream.Length)
		{
			int num = class6501_0.ReadInt32();
			Enum837 recordType = (Enum837)class6501_0.ReadUInt16();
			int num2 = (int)stream.Position;
			int num3 = num * 2 - 6;
			if (vmethod_1(recordType, num3))
			{
				int num4 = num2 + num3;
				if (stream.Position != num4)
				{
					stream.Position = num4;
				}
				continue;
			}
			break;
		}
	}

	protected virtual bool vmethod_1(Enum837 recordType, int dataSize)
	{
		switch (recordType)
		{
		case Enum837.const_30:
			method_3();
			break;
		case Enum837.const_0:
			return false;
		case Enum837.const_64:
			method_39();
			break;
		case Enum837.const_39:
			method_4();
			break;
		case Enum837.const_42:
			method_34();
			break;
		case Enum837.const_43:
			method_35();
			break;
		case Enum837.const_44:
			method_68();
			break;
		case Enum837.const_45:
			method_22(class6501_0.ReadUInt16());
			break;
		case Enum837.const_46:
			method_26((Enum845)class6501_0.ReadUInt16());
			break;
		case Enum837.const_2:
			method_24((Enum842)class6501_0.ReadInt16());
			break;
		case Enum837.const_3:
			method_16((Enum843)class6501_0.ReadInt16());
			break;
		case Enum837.const_4:
			method_47();
			break;
		case Enum837.const_6:
			method_46();
			break;
		case Enum837.const_8:
			method_48();
			break;
		case Enum837.const_59:
			method_45();
			break;
		case Enum837.const_65:
			method_44();
			break;
		case Enum837.const_63:
			method_23(class6501_0.ReadUInt16());
			break;
		case Enum837.const_32:
			method_14(class6501_0.method_5());
			break;
		case Enum837.const_1:
			method_15(class6501_0.method_9());
			break;
		case Enum837.const_9:
			method_25(class6501_0.method_9());
			break;
		case Enum837.const_11:
			method_17(class6501_0.method_3());
			break;
		case Enum837.const_12:
			method_18(class6501_0.method_5());
			break;
		case Enum837.const_13:
			method_19(class6501_0.method_3());
			break;
		case Enum837.const_14:
			method_31(class6501_0.method_5());
			break;
		case Enum837.const_15:
			method_36();
			break;
		case Enum837.const_17:
			method_37();
			break;
		case Enum837.const_19:
			method_28(class6501_0.method_3());
			break;
		case Enum837.const_20:
			method_27(class6501_0.method_3());
			break;
		case Enum837.const_40:
			method_32();
			break;
		case Enum837.const_36:
			method_54();
			break;
		case Enum837.const_37:
			method_53();
			break;
		case Enum837.const_66:
			method_41();
			break;
		case Enum837.const_67:
			method_43();
			break;
		case Enum837.const_68:
			method_42();
			break;
		case Enum837.const_31:
			method_52();
			break;
		case Enum837.const_16:
			method_18(method_38(base.DC.WindowRect.Size));
			break;
		case Enum837.const_18:
			method_20(method_38(base.ViewportRect.Size));
			break;
		case Enum837.const_21:
			method_13(class6501_0.method_7());
			break;
		case Enum837.const_22:
			method_12(class6501_0.method_7());
			break;
		case Enum837.const_24:
			method_57();
			break;
		case Enum837.const_27:
			method_29(class6501_0.method_7());
			break;
		case Enum837.const_41:
			method_33();
			break;
		case Enum837.const_55:
			method_55();
			break;
		case Enum837.const_33:
			method_49();
			break;
		case Enum837.const_38:
			method_66();
			break;
		case Enum837.const_28:
			method_60();
			break;
		case Enum837.const_29:
			method_67();
			break;
		case Enum837.const_23:
			method_56();
			break;
		case Enum837.const_69:
			method_40();
			break;
		case Enum837.const_47:
			method_59();
			break;
		case Enum837.const_26:
			method_58();
			break;
		case Enum837.const_49:
			method_50();
			break;
		case Enum837.const_57:
			method_65(dataSize);
			break;
		case Enum837.const_60:
			method_61(dataSize);
			break;
		case Enum837.const_58:
			method_62(dataSize);
			break;
		}
		return true;
	}

	private void method_32()
	{
		int handle = class6501_0.ReadUInt16();
		int handle2 = class6501_0.ReadUInt16();
		Class6499 region = (Class6499)base.GdiObjects[handle];
		class6479_0.vmethod_11(region, null, base.DC.method_10(handle2));
	}

	private void method_33()
	{
		int handle = class6501_0.ReadUInt16();
		int handle2 = class6501_0.ReadUInt16();
		class6501_0.ReadInt16();
		int num = class6501_0.ReadInt16();
		Class6003 pen = new Class6003(base.DC.method_10(handle2), num);
		Class6499 region = (Class6499)base.GdiObjects[handle];
		class6479_0.vmethod_11(region, pen, null);
	}

	private void method_34()
	{
		int handle = class6501_0.ReadUInt16();
		Class6499 region = (Class6499)base.GdiObjects[handle];
		class6479_0.vmethod_11(region, new Class6003(Class5998.class5998_7), null);
	}

	private void method_35()
	{
		int handle = class6501_0.ReadUInt16();
		Class6499 region = (Class6499)base.GdiObjects[handle];
		class6479_0.vmethod_11(region, null, base.DC.Brush);
	}

	private void method_36()
	{
		PointF location = base.DC.WindowRect.Location;
		PointF pointF = class6501_0.method_3();
		base.DC.method_2(new PointF(location.X + pointF.X, location.Y + pointF.Y));
		base.DC.method_12();
	}

	private void method_37()
	{
		PointF location = base.ViewportRect.Location;
		PointF pointF = class6501_0.method_3();
		method_5(new PointF(location.X + pointF.X, location.Y + pointF.Y));
		base.DC.method_12();
	}

	private SizeF method_38(SizeF oldSize)
	{
		int num = class6501_0.ReadInt16();
		int num2 = class6501_0.ReadInt16();
		int num3 = class6501_0.ReadInt16();
		int num4 = class6501_0.ReadInt16();
		if (num == 0 || num3 == 0)
		{
			throw new InvalidOperationException("Invalid scale values.");
		}
		return new SizeF(oldSize.Width * (float)num4 / (float)num3, oldSize.Height * (float)num2 / (float)num);
	}

	private void method_39()
	{
		Class6495 gdiObject = new Class6495();
		method_21(gdiObject);
	}

	private void method_40()
	{
		Class6499 @class = new Class6499();
		@class.method_0(class6501_0);
		method_21(@class);
	}

	private void method_41()
	{
		Class6495 @class = new Class6495();
		@class.method_0(class6501_0);
		method_21(@class);
	}

	private void method_42()
	{
		Class6491 @class = new Class6491();
		@class.method_0(class6501_0);
		method_21(@class);
	}

	private void method_43()
	{
		Class6493 @class = new Class6493();
		@class.method_0(class6501_0);
		method_21(@class);
	}

	private void method_44()
	{
		Class6491 @class = new Class6491();
		@class.method_1(class6501_0);
		method_21(@class);
	}

	private void method_45()
	{
		class6501_0.ReadInt32();
		Class6491 @class = new Class6491();
		@class.method_2(class6501_0);
		method_21(@class);
	}

	private void method_46()
	{
		base.DC.FillMode = (Enum844)class6501_0.ReadUInt16();
	}

	private void method_47()
	{
		base.DC.BinaryRasterOperation = (Enum861)class6501_0.ReadUInt16();
	}

	private void method_48()
	{
		int characterExtra = class6501_0.ReadInt16();
		base.DC.CharacterExtra = characterExtra;
	}

	private void method_49()
	{
		int length = class6501_0.ReadUInt16();
		string text = method_51(length);
		if (Class5964.smethod_4(class6501_0.BaseStream.Position))
		{
			class6501_0.BaseStream.Position++;
		}
		PointF origin = class6501_0.method_3();
		class6479_0.vmethod_23(origin, text);
	}

	private void method_50()
	{
		PointF origin = class6501_0.method_3();
		int num = class6501_0.ReadUInt16();
		int num2 = class6501_0.ReadInt16();
		RectangleF bounds = RectangleF.Empty;
		if (num2 != 0)
		{
			bounds = class6501_0.method_6();
		}
		if (num != 0)
		{
			string text = method_51(num);
			class6479_0.vmethod_23(origin, text);
		}
		else if (((uint)num2 & 2u) != 0)
		{
			class6479_0.vmethod_24(bounds);
		}
	}

	private string method_51(int length)
	{
		byte[] array = class6501_0.ReadBytes(length);
		if (base.DC.LogFont.CharSet != 2 && !Class5958.smethod_0(base.DC.LogFont.FaceName))
		{
			Encoding encoding = base.DC.LogFont.Encoding;
			return encoding.GetString(array);
		}
		StringBuilder stringBuilder = new StringBuilder();
		byte[] array2 = array;
		foreach (byte b in array2)
		{
			char c = (char)(b & 0xFFu);
			stringBuilder.Append(Class5958.smethod_5(c));
		}
		return stringBuilder.ToString();
	}

	private void method_52()
	{
		Class5998 color = class6501_0.method_9();
		PointF position = class6501_0.method_3();
		class6479_0.vmethod_21(position, color);
	}

	private void method_53()
	{
		class6479_0.vmethod_16(class6501_0.method_10());
	}

	private void method_54()
	{
		class6479_0.vmethod_15(class6501_0.method_10());
	}

	private void method_55()
	{
		class6479_0.vmethod_17(class6501_0.method_12());
	}

	private void method_56()
	{
		PointF start = class6501_0.method_3();
		PointF end = class6501_0.method_3();
		RectangleF bounds = class6501_0.method_7();
		class6479_0.vmethod_6(bounds, start, end);
	}

	private void method_57()
	{
		class6479_0.vmethod_8(class6501_0.method_7());
	}

	private void method_58()
	{
		PointF end = class6501_0.method_3();
		PointF start = class6501_0.method_3();
		RectangleF bounds = class6501_0.method_7();
		class6479_0.vmethod_13(bounds, start, end);
	}

	private void method_59()
	{
		PointF end = class6501_0.method_3();
		PointF start = class6501_0.method_3();
		RectangleF bounds = class6501_0.method_7();
		class6479_0.vmethod_7(bounds, start, end);
	}

	private void method_60()
	{
		SizeF ellipse = class6501_0.method_5();
		RectangleF bounds = class6501_0.method_7();
		class6479_0.vmethod_20(bounds, ellipse);
	}

	private void method_61(int dataSize)
	{
		class6501_0.ReadUInt16();
		class6501_0.ReadUInt16();
		class6501_0.ReadUInt16();
		method_63(dataSize - 22);
	}

	private void method_62(int dataSize)
	{
		class6501_0.ReadUInt16();
		class6501_0.ReadUInt16();
		method_63(dataSize - 20);
	}

	private void method_63(int dibLength)
	{
		RectangleF srcBounds = class6501_0.method_8();
		RectangleF dstBounds = class6501_0.method_8();
		method_64(dibLength, srcBounds, dstBounds);
	}

	private void method_64(int dibLength, RectangleF srcBounds, RectangleF dstBounds)
	{
		if (dibLength > 0)
		{
			byte[] imageBytes = Class6148.smethod_21(class6501_0, dibLength);
			class6479_0.vmethod_22(srcBounds, dstBounds, imageBytes);
		}
	}

	private void method_65(int dataSize)
	{
		if (smethod_2(dataSize, Enum837.const_57))
		{
			class6501_0.ReadInt32();
			float y = (int)class6501_0.ReadUInt16();
			float x = (int)class6501_0.ReadUInt16();
			RectangleF dstBounds = class6501_0.method_8();
			RectangleF srcBounds = new RectangleF(x, y, dstBounds.Width, dstBounds.Height);
			method_64(dataSize - 16, srcBounds, dstBounds);
			return;
		}
		Enum862 @enum = (Enum862)class6501_0.ReadInt32();
		class6501_0.ReadUInt16();
		class6501_0.ReadUInt16();
		class6501_0.ReadUInt16();
		RectangleF bounds = class6501_0.method_8();
		Enum862 enum2 = @enum;
		if (enum2 != Enum862.const_17 && enum2 == Enum862.const_9)
		{
			class6479_0.vmethod_10(bounds);
		}
	}

	private void method_66()
	{
		class6501_0.ReadInt16();
		class6501_0.ReadUInt16();
	}

	private void method_67()
	{
		class6501_0.ReadInt32();
		RectangleF bounds = class6501_0.method_8();
		class6479_0.vmethod_10(bounds);
	}

	private void method_68()
	{
		int handle = class6501_0.ReadUInt16();
		object obj = base.GdiObjects[handle];
		if (!(obj is Class6499 @class))
		{
			base.DC.ClipRegion = new Region(base.ViewportRect);
			return;
		}
		List<RectangleF> scans = @class.Scans;
		if (scans.Count > 0)
		{
			base.DC.ClipRegion = new Region(scans[0]);
			for (int i = 1; i < scans.Count; i++)
			{
				base.DC.ClipRegion.Union(scans[i]);
			}
		}
	}

	private static bool smethod_2(int dataSize, Enum837 recordFunction)
	{
		return (dataSize + 6) / 2 != ((int)recordFunction >> 8) + 3;
	}
}
