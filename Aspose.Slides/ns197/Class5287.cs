using System;
using System.Collections;
using ns171;
using ns173;
using ns176;
using ns183;
using ns186;
using ns187;
using ns192;
using ns195;
using ns196;
using ns205;

namespace ns197;

internal class Class5287 : Class5281, Interface184
{
	internal class Class5405
	{
		internal Class5158 class5158_0;

		internal Class4962 class4962_0;

		internal int int_0;

		internal Class5405(Class5158 column, Class4962 backgroundArea, int xShift)
		{
			class5158_0 = column;
			class4962_0 = backgroundArea;
			int_0 = xShift;
		}
	}

	private class Class5406 : IDisposable
	{
		[ThreadStatic]
		private static Class5287 class5287_0;

		private Class5287 class5287_1;

		private bool bool_0;

		public bool IsRootTable => bool_0;

		public Class5406(Class5287 layoutManager)
		{
			class5287_1 = layoutManager;
			bool_0 = method_0(layoutManager);
		}

		public bool method_0(Class5287 layoutManager)
		{
			if (class5287_0 == null)
			{
				class5287_0 = layoutManager;
				return true;
			}
			if (!object.ReferenceEquals(class5287_0, layoutManager))
			{
				return false;
			}
			class5287_0 = layoutManager;
			return true;
		}

		public void method_1()
		{
			if (object.ReferenceEquals(class5287_1, class5287_0))
			{
				class5287_0 = null;
			}
		}

		public void Dispose()
		{
			if (class5287_0 != null)
			{
				method_1();
			}
		}
	}

	private Class5674 class5674_0;

	private Class5650 class5650_0;

	internal Class4962 class4962_0;

	private double double_0;

	private bool bool_5 = true;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private Class5746 class5746_0;

	private Class5746 class5746_1;

	private int int_10;

	private int int_11;

	private ArrayList arrayList_2;

	private Class5254 class5254_1;

	private int int_12;

	public Class5287(Class5156 node)
		: base(node)
	{
		class5650_0 = new Class5650(node);
	}

	public Class5156 method_53()
	{
		return (Class5156)class5094_0;
	}

	public Class5650 method_54()
	{
		return class5650_0;
	}

	public override void imethod_3()
	{
		int_6 = method_53().method_66().interface182_4.imethod_6(this);
		int_7 = method_53().method_66().interface182_5.imethod_6(this);
		if (method_53().method_72())
		{
			int_10 = method_53().method_73().method_4().vmethod_0()
				.imethod_6(this) / 2;
			int_11 = method_53().method_73().method_3().vmethod_0()
				.imethod_6(this) / 2;
		}
		else
		{
			int_10 = 0;
			int_11 = 0;
		}
		if (!method_53().method_56() && method_53().method_64().method_10(this).imethod_0() != 9)
		{
			bool_5 = false;
		}
	}

	private void method_55()
	{
		bool_6 = false;
		bool_7 = false;
		bool_8 = false;
		bool_9 = false;
		class5746_0 = null;
		class5746_1 = null;
	}

	public int method_56()
	{
		return int_10;
	}

	public int method_57()
	{
		return int_11;
	}

	public override ArrayList imethod_14(Class5687 context, int alignment)
	{
		int leftInset = 0;
		int rightInset = 0;
		int num = imethod_4().method_15().method_34().method_39();
		Class5282.smethod_4(0, 1, this, num, 1, 1, 0, context, alignment, ref leftInset, ref rightInset);
		if (rightInset != num || leftInset != 0)
		{
			int_12 = leftInset;
		}
		ArrayList arrayList = new ArrayList();
		int_5 = context.method_31();
		if (method_53().method_64().method_10(this).imethod_0() != 9)
		{
			int contentIPD = method_53().method_64().method_10(this).vmethod_0()
				.imethod_6(this);
			method_30(contentIPD);
		}
		else
		{
			if (!method_53().method_56())
			{
				Interface206 @interface = Class5701.smethod_0(method_53().method_2().method_48());
				@interface.imethod_1(this, method_53().method_1());
			}
			method_29();
		}
		int num2 = class5650_0.method_10(this);
		if (!bool_5 && num2 > imethod_16())
		{
			method_30(num2);
		}
		int num3 = int_5 - vmethod_7();
		if (imethod_16() > num3)
		{
			Interface206 interface2 = Class5701.smethod_0(method_53().method_2().method_48());
			interface2.imethod_2(this, method_53().method_17(), imethod_16(), context.method_31(), method_53().method_1());
		}
		if (!method_53().method_56() && double_0 == 0.0)
		{
			double_0 = class5650_0.method_5(this);
		}
		if (!bool_4)
		{
			method_48(arrayList, alignment);
		}
		if (method_53().method_72())
		{
			method_43(arrayList, !bool_4);
			bool_4 = true;
			method_39(context);
		}
		if (method_53().method_56())
		{
			method_58(context, alignment);
		}
		class5674_0 = new Class5674(this);
		Class5687 @class = new Class5687(0);
		@class.method_30(context.method_31());
		@class.method_0(context);
		ArrayList arrayList2 = class5674_0.method_12(@class, alignment);
		Interface208 interface3 = new Class5495(arrayList2);
		while (interface3.imethod_0())
		{
			Class5328 class2 = (Class5328)interface3.imethod_1();
			imethod_22(class2.method_0());
		}
		method_50(arrayList2, arrayList);
		if (method_53().method_64().method_10(this).imethod_0() == 9 && method_53().method_72())
		{
			vmethod_8(method_54().method_10(this));
		}
		context.method_15(imethod_31());
		context.method_15(@class.method_10());
		context.method_14(imethod_33());
		context.method_14(@class.method_9());
		if (method_53().method_72())
		{
			method_44(arrayList, isLast: true);
		}
		method_49(arrayList, alignment);
		if (!context.method_8())
		{
			int num4 = Class5676.smethod_1(method_53().imethod_2(), @class.method_57());
			if (num4 != 9)
			{
				arrayList.Insert(0, new Class5336(vmethod_3(), 0, -Class5337.int_0, num4, context));
			}
		}
		int num5 = Class5676.smethod_1(method_53().imethod_1(), @class.method_59());
		if (num5 != 9)
		{
			arrayList.Add(new Class5336(vmethod_3(), 0, -Class5337.int_0, num5, context));
		}
		imethod_6(fin: true);
		method_55();
		return arrayList;
	}

	private void method_58(Class5687 context, int alignment)
	{
		using Class5406 class2 = method_62();
		int num = method_54().method_2();
		if (num == 0)
		{
			return;
		}
		bool flag;
		int num2 = ((!(flag = method_53().method_64().method_10(this).imethod_0() != 9)) ? context.method_31() : method_53().method_64().method_10(this).vmethod_0()
			.imethod_6(this));
		class5674_0 = new Class5674(this);
		Class5687 @class = new Class5687(0);
		@class.method_30(num2);
		@class.method_0(context);
		class5674_0.method_12(@class, alignment);
		ArrayList arrayList = new ArrayList();
		int num3 = 0;
		if (class2.IsRootTable)
		{
			method_54().method_11(this);
			int num4 = method_54().method_12(this);
			if (flag && !method_54().method_13(this) && num2 > num4)
			{
				method_54().method_15(this, num2);
				class5650_0 = new Class5650(method_53());
				return;
			}
			int num5 = method_54().method_16(this, num2);
			bool flag2 = class5650_0.method_14(this);
			if (num2 > num4 + num5 && flag2)
			{
				class5650_0.method_18(this, num2);
			}
			num4 = method_54().method_12(this);
			num2 -= num4;
			for (int i = 1; i <= num; i++)
			{
				Class5158 class3 = method_54().method_1(i);
				if (class3.method_52().imethod_4() && class3.method_52().imethod_6(this) != 0)
				{
					continue;
				}
				Class5746 class5;
				if (class3.method_52() is Class5037 class4)
				{
					int max;
					int num6 = (max = (int)(class4.method_4() / 100.0 * (double)num2));
					class5 = class3.method_53();
					int min = 0;
					if (class5 != null)
					{
						if (class5.method_1() > num6)
						{
							num6 = class5.method_2();
						}
						max = ((class5.method_3() > num6) ? class5.method_3() : num6);
						min = class5.method_1();
					}
					class3.method_54(Class5746.smethod_0(min, num6, max));
				}
				class5 = class3.method_53();
				if (class5 != null)
				{
					if (!class5.method_18() && class5.method_2() == -1)
					{
						int value = (int)(1f / (float)num * (float)@class.method_31());
						class3.method_54(Class5746.smethod_1(value));
					}
					arrayList.Add(class3);
					num3 += class3.method_53().method_2();
				}
				else if (class3.int_4 == 0)
				{
					class3.method_55(Class5036.smethod_2(0.0));
				}
			}
		}
		else
		{
			int num7 = 0;
			int num8 = 0;
			for (int j = 1; j <= num; j++)
			{
				Class5158 class6 = method_54().method_1(j);
				if (class6.method_53() == null)
				{
					class6.method_54(Class5746.smethod_1(class6.int_4));
				}
				num7 += class6.method_53().method_1() + class6.int_5;
				num8 += class6.method_53().method_2() + class6.int_5;
			}
			if (method_53().method_64().method_10(this).imethod_0() != 9)
			{
				int val = method_53().method_64().method_10(this).vmethod_0()
					.imethod_6(this);
				num7 = Math.Max(val, num7);
				if (num8 < num7)
				{
					num8 = num7;
				}
				vmethod_8(num7);
				context.method_64(Class5746.smethod_0(num7, num8, num8));
			}
			else
			{
				if (num2 == 0)
				{
					num2 = method_54().method_10(this);
				}
				if (num7 > num2)
				{
					num2 = num7;
				}
				if (method_53().method_72())
				{
					num2 += method_53().vmethod_33().method_4(discard: false);
					num2 += method_53().vmethod_33().method_5(discard: false);
				}
				vmethod_8(num2);
				context.method_64(Class5746.smethod_0(num7, num2, num2));
			}
		}
		if (class2.IsRootTable)
		{
			bool flag3 = num2 > 0;
			double num9 = 0.0;
			if (flag3)
			{
				num9 = (double)num2 / (double)num3;
				if (num9 < 1.0)
				{
					for (int k = 0; k < arrayList.Count; k++)
					{
						Class5158 class7 = (Class5158)arrayList[k];
						Class5746 class8 = class7.method_53();
						if (class8.method_1() == class8.method_3())
						{
							int num10 = class8.method_1();
							class7.method_55(Class5036.smethod_1(num10, "mpt"));
							num2 -= num10;
							num3 -= num10;
							arrayList.RemoveAt(k);
							k--;
						}
					}
					num9 = (double)num2 / (double)num3;
				}
			}
			foreach (Class5158 item in arrayList)
			{
				bool flag4 = false;
				Class5746 class10 = item.method_53();
				int num11;
				if (flag3)
				{
					if (num9 > 1.0 && flag)
					{
						num11 = (int)((double)class10.method_2() * num9);
					}
					else if (num2 < num3)
					{
						num11 = (int)((double)class10.method_2() * num9);
						if (num11 < class10.method_1())
						{
							num11 = class10.method_1();
							flag4 = true;
						}
					}
					else
					{
						num11 = class10.method_2();
					}
				}
				else
				{
					num11 = class10.method_2();
				}
				num2 -= num11;
				num3 -= class10.method_2();
				if (flag4)
				{
					num9 = (double)num2 / (double)num3;
				}
				int num12 = vmethod_7();
				if (num12 < 0)
				{
					int num13 = context.method_31();
					if (num11 > num13 && !flag)
					{
						num11 = num13;
					}
					item.method_55(Class5036.smethod_1(num11, "mpt"));
				}
				else
				{
					item.method_55(Class5036.smethod_1(num11, "mpt"));
				}
			}
		}
		class5650_0 = new Class5650(method_53());
	}

	protected override Class5254 vmethod_3()
	{
		if (class5254_1 == null)
		{
			class5254_1 = new Class5258(this, 0);
		}
		return class5254_1;
	}

	internal void method_59(Class5158 column, Class4962 backgroundArea, int xShift)
	{
		method_60(backgroundArea);
		if (arrayList_2 == null)
		{
			arrayList_2 = new ArrayList();
		}
		arrayList_2.Add(new Class5405(column, backgroundArea, xShift));
	}

	public override void imethod_9(Class5652 parentIter, Class5687 layoutContext)
	{
		imethod_7(null);
		vmethod_1();
		if (layoutContext.method_53() != 0)
		{
			method_26(0.0, Class5746.smethod_1(layoutContext.method_53()));
		}
		if (method_53().method_66().interface182_2 is Class5035 && method_53().method_66().interface182_3 is Class5035)
		{
			int num;
			if (method_53().method_64().method_10(this).imethod_0() == 9)
			{
				num = method_54().method_10(this);
				num += method_53().vmethod_33().method_4(discard: false);
				num += method_53().vmethod_33().method_5(discard: false);
			}
			else
			{
				num = imethod_16();
			}
			int num2 = (method_5() - num) / 2;
			if (num2 < 0)
			{
				num2 = 0;
			}
			Interface182 numeric = Class5036.smethod_2(num2);
			Class5049 @class = (Class5049)method_53().method_66().interface182_4;
			@class.method_5(method_53().method_66().interface182_2, numeric);
			@class = (Class5049)method_53().method_66().interface182_5;
			@class.method_5(method_53().method_66().interface182_3, numeric);
			int_6 = method_53().method_66().interface182_4.imethod_6(this);
			int_7 = method_53().method_66().interface182_5.imethod_6(this);
		}
		int startXOffset = method_53().method_66().interface182_4.imethod_6(this);
		int num3 = 0;
		Class5687 class2 = new Class5687(0);
		class2.method_30(imethod_16());
		class5674_0.method_20(startXOffset);
		class5674_0.method_16(parentIter, class2);
		num3 = 0 + class5674_0.method_21();
		class4962_0.method_13(num3);
		if (arrayList_2 != null)
		{
			Interface208 @interface = new Class5495(arrayList_2);
			while (@interface.imethod_0())
			{
				Class5405 class3 = (Class5405)@interface.imethod_1();
				Class5677.smethod_10(class3.class4962_0, class3.class5158_0.vmethod_33(), this, class3.int_0, -class3.class4962_0.method_41(), class3.class5158_0.method_52().imethod_6(this), num3);
			}
			arrayList_2.Clear();
		}
		if (method_53().method_72())
		{
			Class5677.smethod_3(class4962_0, method_53().vmethod_33(), bool_6, bool_7, discardStart: false, discardEnd: false, this);
			Class5677.smethod_7(class4962_0, method_53().vmethod_33(), bool_8, bool_9, discardStart: false, discardEnd: false, this);
		}
		Class5677.smethod_11(class4962_0, method_53().vmethod_33(), this);
		Class5677.smethod_12(class4962_0, method_53().vmethod_33(), int_6, int_7, this);
		Class5677.smethod_17(class4962_0, method_53().imethod_2(), method_53().imethod_1());
		Class5677.smethod_15(class4962_0, layoutContext.method_38(), class5746_0, class5746_1);
		vmethod_2();
		method_55();
		class4962_0 = null;
		method_22();
	}

	public override Class4942 imethod_7(Class4942 childArea)
	{
		if (class4962_0 == null)
		{
			class4962_0 = new Class4962();
			class4962_0.XOffset = int_12;
			interface173_0.imethod_7(class4962_0);
			Class5677.smethod_21(class4962_0, method_53().vmethod_31());
			class4962_0.method_11(imethod_16());
			method_25(class4962_0);
		}
		return class4962_0;
	}

	public override void imethod_8(Class4942 childArea)
	{
		if (class4962_0 != null)
		{
			class4962_0.vmethod_5((Class4962)childArea);
		}
	}

	internal void method_60(Class4962 background)
	{
		class4962_0.vmethod_2(background);
	}

	public override int imethod_27(int adj, Class5337 lastElement)
	{
		return 0;
	}

	public override void imethod_28(Class5344 spaceGlue)
	{
	}

	public override Class5043 imethod_35()
	{
		return method_53().method_69();
	}

	public override Class5043 imethod_36()
	{
		return method_53().method_68();
	}

	public override Class5043 imethod_37()
	{
		return method_53().method_67();
	}

	public bool method_61()
	{
		return method_53().method_56();
	}

	public override int imethod_0(int lengthBase, Class5094 fobj)
	{
		if (fobj is Class5158 && fobj.method_4() == imethod_21())
		{
			switch (lengthBase)
			{
			default:
				return 0;
			case 11:
				if (class5674_0 != null && method_61() && ((Class5158)fobj).method_63())
				{
					object obj = class5674_0.method_7(fobj);
					if (obj != null)
					{
						return (int)obj;
					}
					return 0;
				}
				return (int)double_0;
			case 5:
				return imethod_16();
			}
		}
		if (lengthBase == 11)
		{
			return (int)double_0;
		}
		return base.imethod_0(lengthBase, fobj);
	}

	public void imethod_38(Class5695 side, Class5746 effectiveLength)
	{
		if (Class5695.class5695_0 == side)
		{
			class5746_0 = effectiveLength;
		}
		else
		{
			class5746_1 = effectiveLength;
		}
	}

	public void imethod_39(Class5695 side, Class5746 effectiveLength)
	{
		if (effectiveLength == null)
		{
			if (Class5695.class5695_0 == side)
			{
				bool_6 = true;
			}
			else
			{
				bool_7 = true;
			}
		}
	}

	public void imethod_40(Class5695 side, Class5746 effectiveLength)
	{
		if (effectiveLength == null)
		{
			if (Class5695.class5695_0 == side)
			{
				bool_8 = true;
			}
			else
			{
				bool_9 = true;
			}
		}
	}

	public override void imethod_23()
	{
		base.imethod_23();
		class4962_0 = null;
		double_0 = 0.0;
	}

	private Class5406 method_62()
	{
		return new Class5406(this);
	}
}
