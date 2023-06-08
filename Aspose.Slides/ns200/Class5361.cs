using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using ns173;
using ns175;
using ns181;
using ns183;
using ns184;
using ns205;

namespace ns200;

internal abstract class Class5361 : Class5360
{
	private static int int_2 = 0;

	private static int int_3 = 1;

	private static int int_4 = 2;

	private static int int_5 = 3;

	protected static Class5619 class5619_0 = new Class5619("http://xmlgraphics.apache.org/fop/extensions", "fox:transform");

	public Class5361(Class5738 userAgent)
		: base(userAgent)
	{
	}

	protected override void vmethod_9(Class4962 block)
	{
		float num = (float)block.method_21() / 1000f;
		float num2 = (float)block.method_22() / 1000f;
		float num3 = (float)block.method_19() / 1000f;
		float num4 = (float)block.method_20() / 1000f;
		float num5 = (float)int_0 / 1000f;
		float starty = (float)class5358_0.Value / 1000f;
		float num6 = (float)block.method_12() / 1000f;
		float num7 = (float)block.vmethod_1() / 1000f;
		int num8 = block.method_18();
		if (num8 != -1 && ((uint)num8 & (true ? 1u : 0u)) != 0)
		{
			num5 += (float)block.method_48() / 1000f;
			num5 -= num2;
		}
		else
		{
			num5 += (float)block.method_47() / 1000f;
			num5 -= num;
		}
		if (block is Class4963 @class && @class.method_37().Count > 0)
		{
			Class4962 class2 = @class.method_37()[0] as Class4962;
			if (class2.IsFloatSide)
			{
				num5 = (float)class2.method_40() / 1000f;
				num6 = (float)class2.FloatWidth / 1000f;
				num = 0f;
				num2 = 0f;
			}
		}
		num6 += num;
		num6 += num2;
		num7 += num3;
		num7 += num4;
		method_17(block, num5, starty, num6, num7);
		method_18(block, num5, starty, num6, num7);
	}

	protected override void vmethod_3(Class4971 region)
	{
		RectangleF rectangleF = region.method_40();
		Class4964 @class = region.method_38();
		float startx = rectangleF.X / 1000f;
		float starty = rectangleF.Y / 1000f;
		float width = rectangleF.Width / 1000f;
		float height = rectangleF.Height / 1000f;
		class5358_0.Value = @class.method_19();
		int num = region.method_18();
		if (num != -1 && ((uint)num & (true ? 1u : 0u)) != 0)
		{
			int_0 = @class.method_22();
		}
		else
		{
			int_0 = @class.method_21();
		}
		method_19(region, @class, startx, starty, width, height);
	}

	protected void method_17(Class4942 area, float startx, float starty, float width, float height)
	{
		method_19(area, area, startx, starty, width, height);
	}

	protected void method_18(Class4942 area, float startx, float starty, float width, float height)
	{
		Class5475 @class = (Class5475)area.method_33(Class5757.int_37);
		if (@class != null)
		{
			float num = (float)@class.int_1 / 1000f;
			RectangleF rectangleF = new RectangleF(startx - num, starty - num, width + 2f * num, height + 2f * num);
			vmethod_34();
			vmethod_40(rectangleF.Left, rectangleF.Top);
			vmethod_41(rectangleF.Right, rectangleF.Top);
			vmethod_41(rectangleF.Right, rectangleF.Bottom);
			vmethod_41(rectangleF.Left, rectangleF.Bottom);
			vmethod_42();
			vmethod_38();
			vmethod_46(rectangleF.Left, rectangleF.Top, rectangleF.Right, rectangleF.Top + num, horz: true, startOrBefore: true, @class.int_0, @class.color_0, 0);
			vmethod_46(rectangleF.Right - num, rectangleF.Top, rectangleF.Right, rectangleF.Bottom, horz: false, startOrBefore: false, @class.int_0, @class.color_0, 1);
			vmethod_46(rectangleF.Left, rectangleF.Bottom - num, rectangleF.Right, rectangleF.Bottom, horz: true, startOrBefore: true, @class.int_0, @class.color_0, 2);
			vmethod_46(rectangleF.Left, rectangleF.Top, rectangleF.Left + num, rectangleF.Bottom, horz: false, startOrBefore: false, @class.int_0, @class.color_0, 3);
			vmethod_35();
		}
	}

	protected void method_19(Class4942 backgroundArea, Class4942 borderArea, float startx, float starty, float width, float height)
	{
		Class5705 bpsBefore = (Class5705)borderArea.method_33(Class5757.int_12);
		Class5705 bpsAfter = (Class5705)borderArea.method_33(Class5757.int_13);
		Class5705 bpsStart = (Class5705)borderArea.method_33(Class5757.int_10);
		Class5705 bpsEnd = (Class5705)borderArea.method_33(Class5757.int_11);
		method_20(startx, starty, width, height, (Class5757.Class5761)backgroundArea.method_33(Class5757.int_6), bpsBefore, bpsAfter, bpsStart, bpsEnd, backgroundArea.method_18());
		method_22(startx, starty, width, height, bpsBefore, bpsAfter, bpsStart, bpsEnd, borderArea.method_18());
	}

	protected void method_20(float startx, float starty, float width, float height, Class5757.Class5761 back, Class5705 bpsBefore, Class5705 bpsAfter, Class5705 bpsStart, Class5705 bpsEnd, int level)
	{
		Class5705 bpsLeft;
		Class5705 bpsRight;
		if (level != -1 && ((uint)level & (true ? 1u : 0u)) != 0)
		{
			bpsLeft = bpsEnd;
			bpsRight = bpsStart;
		}
		else
		{
			bpsLeft = bpsStart;
			bpsRight = bpsEnd;
		}
		method_21(startx, starty, width, height, back, bpsBefore, bpsAfter, bpsLeft, bpsRight);
	}

	protected void method_21(float startx, float starty, float width, float height, Class5757.Class5761 back, Class5705 bpsTop, Class5705 bpsBottom, Class5705 bpsLeft, Class5705 bpsRight)
	{
		if (back == null)
		{
			return;
		}
		vmethod_37();
		float num = startx;
		float num2 = starty;
		float num3 = width;
		float num4 = height;
		if (bpsLeft != null)
		{
			num += (float)bpsLeft.int_4 / 1000f;
			num3 -= (float)bpsLeft.int_4 / 1000f;
		}
		if (bpsTop != null)
		{
			num2 += (float)bpsTop.int_4 / 1000f;
			num4 -= (float)bpsTop.int_4 / 1000f;
		}
		if (bpsRight != null)
		{
			num3 -= (float)bpsRight.int_4 / 1000f;
		}
		if (bpsBottom != null)
		{
			num4 -= (float)bpsBottom.int_4 / 1000f;
		}
		if (!back.method_0().IsEmpty)
		{
			vmethod_44(back.method_0(), fill: true);
			vmethod_43(num, num2, num3, num4);
		}
		if (back.method_4() == null)
		{
			return;
		}
		Class5393 @class = back.method_4().method_2();
		vmethod_34();
		if (!back.bool_0)
		{
			vmethod_39(num, num2, num3, num4);
		}
		else
		{
			num = 0f;
			num2 = 0f;
		}
		int num5 = (int)(num3 * 1000f / (float)@class.method_8() + 1f);
		int num6 = (int)(((!back.bool_0 || class4971_0 == null) ? (num4 * 1000f) : ((float)class4971_0.vmethod_1())) / (float)@class.method_9() + 1f);
		if (back.method_2() == 96)
		{
			num5 = 1;
			num6 = 1;
		}
		else if (back.method_2() == 113)
		{
			num6 = 1;
		}
		else if (back.method_2() == 114)
		{
			num5 = 1;
		}
		num *= 1000f;
		num2 *= 1000f;
		if (num5 == 1)
		{
			num += (float)back.method_1();
		}
		if (num6 == 1)
		{
			num2 += (float)back.method_5();
		}
		for (int i = 0; i < num5; i++)
		{
			for (int j = 0; j < num6; j++)
			{
				method_26(pos: new RectangleF(num - (float)int_0 + (float)(i * @class.method_8()), num2 - (float)class5358_0.Value + (float)(j * @class.method_9()), @class.method_8(), @class.method_9()), url: back.method_3(), isBackground: true);
			}
		}
		vmethod_35();
	}

	protected void method_22(float startx, float starty, float width, float height, Class5705 bpsBefore, Class5705 bpsAfter, Class5705 bpsStart, Class5705 bpsEnd, int level)
	{
		RectangleF borderRect = new RectangleF(startx, starty, width, height);
		Class5705 bpsLeft;
		Class5705 bpsRight;
		if (level != -1 && ((uint)level & (true ? 1u : 0u)) != 0)
		{
			bpsLeft = bpsEnd;
			bpsRight = bpsStart;
		}
		else
		{
			bpsLeft = bpsStart;
			bpsRight = bpsEnd;
		}
		method_23(borderRect, bpsBefore, bpsAfter, bpsLeft, bpsRight);
	}

	protected virtual void vmethod_29(Class5705 bpsTop, Class5705 bpsBottom, Class5705 bpsLeft, Class5705 bpsRight)
	{
	}

	protected virtual void vmethod_30(RectangleF rect)
	{
	}

	protected void method_23(RectangleF borderRect, Class5705 bpsTop, Class5705 bpsBottom, Class5705 bpsLeft, Class5705 bpsRight)
	{
		RectangleF rect = RectangleF.Empty;
		try
		{
			bool[] array = new bool[4]
			{
				bpsTop != null,
				bpsRight != null,
				bpsBottom != null,
				bpsLeft != null
			};
			float x = borderRect.X;
			float y = borderRect.Y;
			float width = borderRect.Width;
			float height = borderRect.Height;
			vmethod_29(bpsTop, bpsBottom, bpsLeft, bpsRight);
			rect = new RectangleF(x, y, width, height);
			float[] array2 = new float[4]
			{
				array[int_2] ? ((float)bpsTop.int_4 / 1000f) : 0f,
				array[int_3] ? ((float)bpsRight.int_4 / 1000f) : 0f,
				array[int_4] ? ((float)bpsBottom.int_4 / 1000f) : 0f,
				array[int_5] ? ((float)bpsLeft.int_4 / 1000f) : 0f
			};
			float[] array3 = new float[4]
			{
				(float)Class5705.smethod_0(bpsTop) / 1000f,
				(float)Class5705.smethod_0(bpsRight) / 1000f,
				(float)Class5705.smethod_0(bpsBottom) / 1000f,
				(float)Class5705.smethod_0(bpsLeft) / 1000f
			};
			y += array3[int_2];
			height -= array3[int_2];
			height -= array3[int_4];
			x += array3[int_5];
			width -= array3[int_5];
			width -= array3[int_3];
			bool[] array4 = new bool[4]
			{
				array[int_5] && array[int_2],
				array[int_2] && array[int_3],
				array[int_3] && array[int_4],
				array[int_4] && array[int_5]
			};
			if (bpsTop != null)
			{
				vmethod_37();
				float num = x;
				float x2 = (array4[int_2] ? (num + array2[int_5] - array3[int_5]) : num);
				float num2 = x + width;
				float x3 = (array4[int_3] ? (num2 - array2[int_3] + array3[int_3]) : num2);
				float num3 = y - array3[int_2];
				float y2 = num3 + array3[int_2];
				float num4 = num3 + array2[int_2];
				vmethod_34();
				vmethod_40(num, y2);
				float num5 = num;
				float num6 = num2;
				if (bpsTop.int_5 == Class5705.int_2)
				{
					if (bpsLeft != null && bpsLeft.int_5 == Class5705.int_2)
					{
						num5 -= array3[int_5];
					}
					if (bpsRight != null && bpsRight.int_5 == Class5705.int_2)
					{
						num6 += array3[int_3];
					}
					vmethod_41(num5, num3);
					vmethod_41(num6, num3);
				}
				vmethod_41(num2, y2);
				vmethod_41(x3, num4);
				vmethod_41(x2, num4);
				vmethod_42();
				vmethod_38();
				vmethod_46(num5, num3, num6, num4, horz: true, startOrBefore: true, bpsTop.int_3, bpsTop.color_0, 0);
				vmethod_35();
			}
			if (bpsRight != null)
			{
				vmethod_37();
				float num7 = y;
				float y3 = (array4[int_3] ? (num7 + array2[int_2] - array3[int_2]) : num7);
				float num8 = y + height;
				float y4 = (array4[int_4] ? (num8 - array2[int_4] + array3[int_4]) : num8);
				float num9 = x + width + array3[int_3];
				float x4 = num9 - array3[int_3];
				float num10 = num9 - array2[int_3];
				vmethod_34();
				vmethod_40(x4, num7);
				float num11 = num7;
				float num12 = num8;
				if (bpsRight.int_5 == Class5705.int_2)
				{
					if (bpsTop != null && bpsTop.int_5 == Class5705.int_2)
					{
						num11 -= array3[int_2];
					}
					if (bpsBottom != null && bpsBottom.int_5 == Class5705.int_2)
					{
						num12 += array3[int_4];
					}
					vmethod_41(num9, num11);
					vmethod_41(num9, num12);
				}
				vmethod_41(x4, num8);
				vmethod_41(num10, y4);
				vmethod_41(num10, y3);
				vmethod_42();
				vmethod_38();
				vmethod_46(num10, num11, num9, num12, horz: false, startOrBefore: false, bpsRight.int_3, bpsRight.color_0, 1);
				vmethod_35();
			}
			if (bpsBottom != null)
			{
				vmethod_37();
				float num13 = x;
				float x5 = (array4[int_5] ? (num13 + array2[int_5] - array3[int_5]) : num13);
				float num14 = x + width;
				float x6 = (array4[int_4] ? (num14 - array2[int_3] + array3[int_3]) : num14);
				float num15 = y + height + array3[int_4];
				float y5 = num15 - array3[int_4];
				float num16 = num15 - array2[int_4];
				vmethod_34();
				vmethod_40(num14, y5);
				float num17 = num13;
				float num18 = num14;
				if (bpsBottom.int_5 == Class5705.int_2)
				{
					if (bpsLeft != null && bpsLeft.int_5 == Class5705.int_2)
					{
						num17 -= array3[int_5];
					}
					if (bpsRight != null && bpsRight.int_5 == Class5705.int_2)
					{
						num18 += array3[int_3];
					}
					vmethod_41(num18, num15);
					vmethod_41(num17, num15);
				}
				vmethod_41(num13, y5);
				vmethod_41(x5, num16);
				vmethod_41(x6, num16);
				vmethod_42();
				vmethod_38();
				vmethod_46(num17, num16, num18, num15, horz: true, startOrBefore: false, bpsBottom.int_3, bpsBottom.color_0, 2);
				vmethod_35();
			}
			if (bpsLeft == null)
			{
				return;
			}
			vmethod_37();
			float num19 = y;
			float y6 = (array4[int_2] ? (num19 + array2[int_2] - array3[int_2]) : num19);
			float num20 = num19 + height;
			float y7 = (array4[int_5] ? (num20 - array2[int_4] + array3[int_4]) : num20);
			float num21 = x - array3[int_5];
			float x7 = num21 + array3[int_5];
			float num22 = num21 + array2[int_5];
			vmethod_34();
			vmethod_40(x7, num20);
			float num23 = num19;
			float num24 = num20;
			if (bpsLeft.int_5 == Class5705.int_2)
			{
				if (bpsTop != null && bpsTop.int_5 == Class5705.int_2)
				{
					num23 -= array3[int_2];
				}
				if (bpsBottom != null && bpsBottom.int_5 == Class5705.int_2)
				{
					num24 += array3[int_4];
				}
				vmethod_41(num21, num24);
				vmethod_41(num21, num23);
			}
			vmethod_41(x7, num19);
			vmethod_41(num22, y6);
			vmethod_41(num22, y7);
			vmethod_42();
			vmethod_38();
			vmethod_46(num21, num23, num22, num24, horz: false, startOrBefore: true, bpsLeft.int_3, bpsLeft.color_0, 3);
			vmethod_35();
		}
		finally
		{
			vmethod_30(rect);
		}
	}

	protected override void vmethod_16(Class4943 area)
	{
		float num = (float)area.method_21() / 1000f;
		float num2 = (float)area.method_22() / 1000f;
		float num3 = (float)area.method_19() / 1000f;
		float num4 = (float)area.method_20() / 1000f;
		float num5 = num + num2;
		float num6 = num3 + num4;
		float num7 = (float)area.vmethod_1() / 1000f;
		if (num7 != 0f || (num6 != 0f && num5 != 0f))
		{
			float startx = (float)int_0 / 1000f;
			float num8 = (float)(class5358_0.Value + area.method_42()) / 1000f;
			float num9 = (float)area.method_12() / 1000f;
			method_17(area, startx, num8 - num3, num9 + num5, num7 + num6);
		}
	}

	protected int method_24(Class4963 bv)
	{
		int num = 0;
		int num2 = 0;
		bool flag = true;
		int[] array = class5358_0.method_1();
		Class4942 @class = bv.method_28();
		while (@class != null)
		{
			if (@class is Class4963 class2)
			{
				int num3 = class2.method_45();
				if (num3 == 2 || num3 == 4 || num3 == 5 || num3 == 3)
				{
					break;
				}
				if (flag)
				{
					flag = false;
				}
			}
			else if (@class is Class4961)
			{
				break;
			}
			@class = @class.method_28();
			num++;
			if (!flag)
			{
				num2 += array[num];
			}
		}
		return num2;
	}

	protected override void vmethod_10(Class4963 bv, ArrayList children)
	{
		int num = int_0;
		class5358_0.Save();
		Class5492 @class = bv.method_50();
		int num2 = bv.method_19();
		int num3 = bv.method_45();
		if (num3 != 2 && num3 != 4 && num3 != 5 && num3 != 3)
		{
			class5358_0.Value += bv.method_23();
			if (bv.method_27() != 57)
			{
				vmethod_9(bv);
			}
			int_0 += bv.method_47();
			Class5492 class2 = new Class5492(int_1, class5358_0.Value);
			@class = class2.method_0(@class);
			class5358_0.Value += num2;
			Rectangle rectangle = Rectangle.Empty;
			if (bv.imethod_0())
			{
				rectangle = new Rectangle(int_0, 0, bv.method_12(), bv.vmethod_1());
			}
			vmethod_1(@class, rectangle);
			int_0 = 0;
			class5358_0.Value = 0;
			vmethod_12(bv, children);
			vmethod_2();
			int_0 = num;
			class5358_0.method_0();
			class5358_0.Value += bv.method_15();
			return;
		}
		ArrayList arrayList = null;
		if (num3 == 3)
		{
			arrayList = vmethod_33();
		}
		int num4;
		int num6;
		if (num3 == 2)
		{
			if (bv.IsTopAuto && bv.IsBottomAuto)
			{
				num4 = class5358_0.Value;
			}
			else
			{
				int num5 = -method_24(bv);
				num4 = num5 + bv.method_41();
			}
			num6 = ((!bv.IsLeftAuto || !bv.IsRightAuto) ? bv.method_40() : int_0);
		}
		else
		{
			num6 = bv.method_40();
			num4 = bv.method_41();
		}
		num6 += bv.method_47();
		Matrix matrix = new Matrix();
		matrix.Translate(num6, num4);
		int num7 = bv.method_18();
		int num8 = bv.method_21();
		int num9 = bv.method_22();
		if (num7 != -1 && ((uint)num7 & (true ? 1u : 0u)) != 0)
		{
			matrix.Translate(-num9, -num2);
		}
		else
		{
			matrix.Translate(-num8, -num2);
		}
		string text = bv.method_2(class5619_0);
		if (text != null)
		{
			throw new NotImplementedException();
		}
		if (!matrix.IsIdentity)
		{
			method_27(matrix);
		}
		float num10 = (float)bv.method_12() / 1000f;
		float num11 = (float)bv.vmethod_1() / 1000f;
		float num12 = (float)(num8 + num9) / 1000f;
		float num13 = (float)(num2 + bv.method_20()) / 1000f;
		method_17(bv, 0f, 0f, num10 + num12, num11 + num13);
		Matrix matrix2 = new Matrix();
		if (num7 != -1 && ((uint)num7 & (true ? 1u : 0u)) != 0)
		{
			matrix2.Translate(num9, num2);
		}
		else
		{
			matrix2.Translate(num8, num2);
		}
		if (!matrix2.IsIdentity)
		{
			method_27(matrix2);
		}
		if (bv.imethod_0())
		{
			RectangleF rectangleF = bv.imethod_1();
			vmethod_39(rectangleF.X / 1000f, rectangleF.Y / 1000f, rectangleF.Width / 1000f, rectangleF.Height / 1000f);
		}
		Matrix matrix3 = @class.method_6();
		if (!matrix3.IsIdentity)
		{
			method_27(matrix3);
		}
		int_0 = 0;
		class5358_0.Value = 0;
		vmethod_12(bv, children);
		if (!matrix3.IsIdentity)
		{
			vmethod_35();
		}
		if (!matrix2.IsIdentity)
		{
			vmethod_35();
		}
		if (!matrix.IsIdentity)
		{
			vmethod_35();
		}
		if (num3 == 3 && arrayList != null)
		{
			vmethod_32(arrayList);
		}
		int_0 = num;
		class5358_0.method_0();
	}

	protected override void vmethod_11(Class4962 block)
	{
		int num = int_0;
		class5358_0.Save();
		Matrix matrix = new Matrix();
		matrix.Translate(int_0, class5358_0.Value);
		matrix.Translate(block.method_40(), block.method_41());
		matrix.Translate(0f, block.method_23());
		if (!matrix.IsIdentity)
		{
			method_27(matrix);
		}
		int_0 = 0;
		class5358_0.Value = 0;
		vmethod_9(block);
		ArrayList arrayList = block.method_37();
		if (arrayList != null)
		{
			vmethod_12(block, arrayList);
		}
		if (!matrix.IsIdentity)
		{
			vmethod_35();
		}
		int_0 = num;
		class5358_0.method_0();
	}

	protected override void vmethod_8(Class4961 flow)
	{
		int num = int_0;
		class5358_0.Save();
		Matrix matrix = new Matrix();
		matrix.Translate(int_0, class5358_0.Value);
		if (!matrix.IsIdentity)
		{
			method_27(matrix);
		}
		int_0 = 0;
		class5358_0.Value = 0;
		base.vmethod_8(flow);
		if (!matrix.IsIdentity)
		{
			vmethod_35();
		}
		int_0 = num;
		class5358_0.method_0();
	}

	protected abstract void vmethod_31(Matrix at);

	protected override void vmethod_24(Class4951 viewport)
	{
		int num = viewport.method_18();
		float num2 = (float)int_0 / 1000f;
		float num3 = (float)(class5358_0.Value + viewport.method_42()) / 1000f;
		float num4 = (float)viewport.method_12() / 1000f;
		float num5 = (float)viewport.vmethod_1() / 1000f;
		float num6 = (float)viewport.method_21() / 1000f;
		float num7 = (float)viewport.method_22() / 1000f;
		float num8 = (float)viewport.method_19() / 1000f;
		float num9 = (float)viewport.method_20() / 1000f;
		float num10 = num6 + num7;
		float num11 = num8 + num9;
		method_17(viewport, num2, num3, num4 + num10, num5 + num11);
		if (viewport.imethod_0())
		{
			vmethod_34();
			if (num != -1 && ((uint)num & (true ? 1u : 0u)) != 0)
			{
				vmethod_39(num2 + num7, num3 + num8, num4, num5);
			}
			else
			{
				vmethod_39(num2 + num6, num3 + num8, num4, num5);
			}
		}
		base.vmethod_24(viewport);
		if (viewport.imethod_0())
		{
			vmethod_35();
		}
	}

	protected abstract void vmethod_32(ArrayList breakOutList);

	protected abstract ArrayList vmethod_33();

	protected abstract void vmethod_34();

	protected abstract void vmethod_35();

	protected abstract void vmethod_36();

	protected abstract void vmethod_37();

	protected void method_25(Interface161 fm, int fontsize, Class4943 inline, int baseline, int startx)
	{
		if (inline.method_43() || inline.method_44() || inline.method_45())
		{
			vmethod_37();
			float num = (float)fm.imethod_8(fontsize) / 1000f;
			float num2 = (float)fm.imethod_7(fontsize) / 1000f;
			if (num2.CompareTo(0f) == 0)
			{
				num2 = (float)fm.imethod_6(fontsize) / 1500f;
			}
			float num3 = num / -8f / 2f;
			float x = (float)(startx + inline.method_12()) / 1000f;
			if (inline.method_43())
			{
				Color col = (Color)inline.method_33(Class5757.int_27);
				float num4 = (float)baseline - num / 2f;
				vmethod_46((float)startx / 1000f, (num4 - num3) / 1000f, x, (num4 + num3) / 1000f, horz: true, startOrBefore: true, 133, col, 0);
			}
			if (inline.method_44())
			{
				Color col2 = (Color)inline.method_33(Class5757.int_28);
				float num5 = (float)baseline - 1.1f * num2;
				vmethod_46((float)startx / 1000f, (num5 - num3) / 1000f, x, (num5 + num3) / 1000f, horz: true, startOrBefore: true, 133, col2, 0);
			}
			if (inline.method_45())
			{
				Color col3 = (Color)inline.method_33(Class5757.int_29);
				float num6 = (float)baseline - 0.45f * num2;
				vmethod_46((float)startx / 1000f, (num6 - num3) / 1000f, x, (num6 + num3) / 1000f, horz: true, startOrBefore: true, 133, col3, 0);
			}
		}
	}

	protected abstract void vmethod_38();

	protected abstract void vmethod_39(float x, float y, float width, float height);

	protected abstract void vmethod_40(float x, float y);

	protected abstract void vmethod_41(float x, float y);

	protected abstract void vmethod_42();

	protected abstract void vmethod_43(float x, float y, float width, float height);

	protected abstract void vmethod_44(Color col, bool fill);

	protected abstract void vmethod_45(string url, RectangleF pos, Hashtable foreignAttributes, bool isBackground);

	protected void method_26(string url, RectangleF pos, bool isBackground)
	{
		vmethod_45(url, pos, null, isBackground);
	}

	protected abstract void vmethod_46(float x1, float y1, float x2, float y2, bool horz, bool startOrBefore, int style, Color col, int lineIndex);

	public override void vmethod_27(Class4970 fo, RectangleF pos)
	{
		vmethod_37();
		XmlDocument doc = fo.method_38();
		string ns = fo.method_39();
		method_14(doc, ns, pos, fo.method_3());
	}

	protected void method_27(Matrix at)
	{
		vmethod_34();
		vmethod_31(method_7(at));
	}
}
