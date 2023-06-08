using System;
using System.Collections;
using ns171;
using ns173;
using ns176;
using ns183;
using ns187;
using ns189;
using ns192;
using ns195;
using ns197;
using ns198;
using ns205;

namespace ns196;

internal abstract class Class5281 : Class5280, Interface172, Interface173, Interface174
{
	private class Class5324
	{
		private Class5335 class5335_0;

		private Class5335 class5335_1;

		private bool bool_0 = true;

		private Class5324(ArrayList elements)
		{
			Class5495 @class = new Class5495(elements);
			while (@class.imethod_0())
			{
				object obj = @class.imethod_1();
				if (obj is Class5335 class2)
				{
					if (class2.method_6().Equals(Class5695.class5695_0))
					{
						if (class5335_0 == null)
						{
							class5335_0 = class2;
						}
					}
					else if (class2.method_6().Equals(Class5695.class5695_1))
					{
						class5335_1 = class2;
					}
				}
				else if (obj is Class5338 class3)
				{
					if (bool_0 && class3.method_4() != 0)
					{
						bool_0 = false;
					}
					class5335_1 = null;
				}
			}
		}

		public static void Add(ArrayList destinationElements, ArrayList sourceElements)
		{
			Class5324 @class = new Class5324(sourceElements);
			Class5324 class2 = new Class5324(destinationElements);
			if (@class.method_0())
			{
				if (class2.method_0())
				{
					Class5746 class3 = @class.class5335_0.method_4();
					Class5746 class4 = @class.class5335_1.method_4();
					if (class3.method_2() < class4.method_2())
					{
						class3 = class4;
					}
					@class.class5335_0.method_5(Class5746.class5746_0);
					@class.class5335_1.method_5(class3);
					class3 = class2.class5335_1.method_4();
					class4 = @class.class5335_1.method_4();
					if (class3.method_2() < class4.method_2())
					{
						class3 = class4;
					}
					class2.class5335_1.method_5(Class5746.class5746_0);
					@class.class5335_1.method_5(class3);
				}
				else if (class2.class5335_1 != null)
				{
					Class5746 class5 = class2.class5335_1.method_4();
					Class5746 class6 = @class.class5335_0.method_4();
					if (class5.method_2() < class6.method_2())
					{
						class5 = class6;
					}
					class6 = @class.class5335_1.method_4();
					if (class5.method_2() < class6.method_2())
					{
						class5 = class6;
					}
					class2.class5335_1.method_5(Class5746.class5746_0);
					@class.class5335_0.method_5(Class5746.class5746_0);
					@class.class5335_1.method_5(class5);
				}
				else
				{
					Class5746 class7 = @class.class5335_0.method_4();
					Class5746 class8 = @class.class5335_1.method_4();
					if (class7.method_2() < class8.method_2())
					{
						class7 = class8;
					}
					@class.class5335_0.method_5(Class5746.class5746_0);
					@class.class5335_1.method_5(class7);
				}
			}
			Class5693.smethod_2(destinationElements, sourceElements);
		}

		private bool method_0()
		{
			if (bool_0 && class5335_0 != null)
			{
				return class5335_1 != null;
			}
			return false;
		}
	}

	protected class Class5261 : Class5254
	{
		private int int_1;

		private int int_2;

		public Class5261(Interface173 lm, int first, int last)
			: base(lm)
		{
			int_1 = first;
			int_2 = last;
		}

		public int method_6()
		{
			return int_1;
		}

		public int method_7()
		{
			return int_2;
		}
	}

	protected Class4957 class4957_0;

	protected int int_2;

	protected int int_3;

	protected int int_4;

	protected ArrayList arrayList_1;

	protected bool bool_3;

	protected bool bool_4;

	protected int int_5;

	protected int int_6;

	protected int int_7;

	protected int int_8;

	private Class5254 class5254_0;

	private int int_9;

	public Class5281(Class5094 node)
		: base(node)
	{
		method_8(generatesBlockArea: true);
	}

	protected Class4957 method_24()
	{
		return class4957_0;
	}

	protected void method_25(Class4957 parentAreA)
	{
		class4957_0 = parentAreA;
	}

	public void method_26(double adjust, Class5746 minoptmax)
	{
		int num = Class5677.smethod_14(adjust, minoptmax);
		if (num != 0)
		{
			Class4962 @class = new Class4962();
			@class.method_13(num);
			interface173_0.imethod_8(@class);
		}
	}

	protected void method_27(Class4942 childArea, Class4957 parentArea)
	{
		parentArea.vmethod_5((Class4962)childArea);
		vmethod_2();
	}

	public override void imethod_8(Class4942 childArea)
	{
		method_27(childArea, method_24());
	}

	protected virtual void vmethod_2()
	{
		if (method_24() != null)
		{
			interface173_0.imethod_8(method_24());
		}
	}

	protected virtual Class5254 vmethod_3()
	{
		if (class5254_0 == null)
		{
			class5254_0 = new Class5255(this, null);
		}
		return class5254_0;
	}

	protected int method_28(int len)
	{
		return (int)Math.Ceiling((float)len / (float)int_2);
	}

	protected int method_29()
	{
		int num = int_5 - (int_6 + int_7);
		if (num < 0)
		{
			Interface206 @interface = Class5701.smethod_0(imethod_21().method_2().method_48());
			@interface.imethod_3(this, imethod_21().method_17(), num, imethod_21().method_1());
			int_7 += num;
			num = 0;
		}
		vmethod_8(num);
		return num;
	}

	protected int method_30(int contentIPD)
	{
		int num = int_5 - (contentIPD + (int_6 + int_7));
		if (num < 0)
		{
			Interface206 @interface = Class5701.smethod_0(imethod_21().method_2().method_48());
			@interface.imethod_3(this, imethod_21().method_17(), num, imethod_21().method_1());
			int_7 += num;
		}
		vmethod_8(contentIPD);
		return contentIPD;
	}

	public override ArrayList imethod_14(Class5687 context, int alignment)
	{
		return imethod_26(context, alignment, null, null, null);
	}

	public override ArrayList imethod_26(Class5687 context, int alignment, Stack lmStack, Class5254 restartPosition, Interface173 restartAtLM)
	{
		int_5 = context.method_31();
		method_29();
		bool flag;
		bool flag2 = !(flag = lmStack != null) || lmStack.Count == 0;
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		if (!method_32(context, arrayList2))
		{
			return arrayList2;
		}
		vmethod_5(arrayList2, context, alignment);
		Class5336 @class = null;
		Interface173 @interface;
		if (flag)
		{
			@interface = ((!flag2) ? ((Interface173)lmStack.Pop()) : restartAtLM);
			method_10(@interface);
		}
		else
		{
			@interface = method_9();
		}
		while (true)
		{
			if (@interface != null)
			{
				Class5687 class2 = vmethod_4(context);
				ArrayList arrayList3;
				if (flag && !flag2)
				{
					arrayList3 = vmethod_6(@interface, context, class2, alignment, lmStack, restartPosition, restartAtLM);
					flag2 = true;
				}
				else
				{
					if (flag)
					{
						@interface.imethod_23();
					}
					arrayList3 = vmethod_6(@interface, context, class2, alignment, null, null, null);
				}
				int num = class2.method_31();
				Class5746 class3 = context.method_63().method_19(class2.method_63().method_1()).method_20(class2.method_63().method_3());
				if (class2.method_63().method_2() == -1 && class3.method_2() == 0)
				{
					class3 = class2.method_63();
				}
				context.method_64(class3);
				if (@interface is Class5287)
				{
					Class5287 class4 = @interface as Class5287;
					if (class4.method_61())
					{
						bool flag3 = class4.method_53().method_72();
						int num2 = class4.method_54().method_2();
						num = 0;
						Class5746 class5 = Class5746.class5746_0;
						for (int i = 1; i <= num2; i++)
						{
							Class5158 class6 = class4.method_54().method_1(i);
							Class5746 class7 = class6.method_53();
							if (class7 != null)
							{
								class5 = class5.method_6(class7);
							}
							if (flag3)
							{
								int num3 = 0;
								num3 = 0 + class6.vmethod_33().method_4(discard: false);
								num3 += class6.vmethod_33().method_8(discard: false, Class5621.smethod_0());
								num3 += class6.vmethod_33().method_5(discard: false);
								num3 += class6.vmethod_33().method_9(discard: false, Class5621.smethod_0());
								class5 = class5.method_7(num3);
							}
							else
							{
								class5 = class5.method_7(class6.int_5 / 2);
							}
						}
						num = class5.method_3();
						if (class4.method_53().method_64().method_10(this) is Class5037)
						{
							Interface173 interface2 = imethod_2() as Class5296;
							if (interface2 != null && interface2.imethod_16() == 0)
							{
								interface2 = interface2.imethod_2();
							}
							if (interface2 != null && interface2.imethod_16() != 0 && interface2.imethod_16() < class5.method_2() && interface2.imethod_16() > class5.method_1())
							{
								num = class5.method_1() + class4.vmethod_7();
							}
						}
						if (class4.method_53().method_72())
						{
							num += class4.method_53().vmethod_33().method_4(discard: false);
							num += class4.method_53().vmethod_33().method_5(discard: false);
						}
					}
					else
					{
						Class5158 class9 = class4.method_54().method_1(class4.method_54().method_2());
						num = class4.imethod_16() - class9.int_5;
					}
					if (imethod_25() && imethod_16() < num)
					{
						int_5 = num;
						method_29();
						context.method_30(int_5);
					}
				}
				else if (@interface is Class5319)
				{
					if (imethod_16() < num && imethod_25())
					{
						int_5 = int_6 + num + int_7;
						method_29();
						context.method_30(int_5);
					}
				}
				else if (int_5 < num && imethod_25())
				{
					int_5 = num;
					method_29();
					context.method_30(int_5);
				}
				if (arrayList.Count == 0)
				{
					context.method_15(class2.method_10());
				}
				if (arrayList3 == null || arrayList3.Count == 0)
				{
					goto IL_0473;
				}
				if (arrayList.Count != 0 && !Class5683.smethod_7(arrayList3))
				{
					bool flag4 = true;
					if (arrayList3.Count == 1 && arrayList3[0] is Class5338 class10 && class10.method_4() == 0 && class10.method_2() is Class5285 class11 && class11.method_58())
					{
						flag4 = false;
					}
					if (flag4)
					{
						method_37(arrayList, context, class2);
					}
				}
				if (arrayList3.Count != 1 || !Class5683.smethod_7(arrayList3))
				{
					Class5324.Add(arrayList, arrayList3);
					if (!Class5683.smethod_6(arrayList3))
					{
						context.method_14(class2.method_9());
						goto IL_0473;
					}
					if (!@interface.imethod_5() || method_11())
					{
						break;
					}
					@class = (Class5336)Class5693.smethod_1(arrayList);
					context.method_25();
				}
				else
				{
					if (!@interface.imethod_5() || method_11())
					{
						if (arrayList.Count == 0)
						{
							arrayList2.Add(method_34());
						}
						Class5324.Add(arrayList, arrayList3);
						method_50(arrayList, arrayList2);
						return arrayList2;
					}
					@class = (Class5336)arrayList3[0];
					context.method_25();
				}
			}
			if (arrayList.Count == 0)
			{
				if (@class == null)
				{
					arrayList2.Add(method_34());
				}
			}
			else
			{
				method_50(arrayList, arrayList2);
			}
			method_31(arrayList2, context, alignment);
			if (@class == null)
			{
				method_47(arrayList2, context);
			}
			else
			{
				@class.method_11();
				arrayList2.Add(@class);
			}
			context.method_14(imethod_33());
			imethod_6(fin: true);
			return arrayList2;
			IL_0473:
			@interface = method_9();
		}
		method_50(arrayList, arrayList2);
		return arrayList2;
	}

	protected virtual Class5687 vmethod_4(Class5687 context)
	{
		Class5687 @class = new Class5687(0);
		@class.method_0(context);
		@class.method_28(context.method_29());
		@class.method_30(int_5);
		return @class;
	}

	protected virtual void vmethod_5(ArrayList elements, Class5687 context, int alignment)
	{
		if (!bool_4)
		{
			method_48(elements, alignment);
			context.method_15(imethod_31());
		}
		method_43(elements, !bool_4);
		bool_4 = true;
		method_39(context);
	}

	protected void method_31(ArrayList elements, Class5687 context, int alignment)
	{
		method_44(elements, isLast: true);
		method_49(elements, alignment);
		context.method_25();
	}

	protected bool method_32(Class5687 context, ArrayList elements)
	{
		if (!bool_3)
		{
			bool_3 = true;
			if (!context.method_8() && method_45(elements, context))
			{
				return false;
			}
		}
		return bool_3;
	}

	private Class5338 method_33()
	{
		return new Class5338(0, new Class5255(this, null), auxiliary: false);
	}

	private Class5338 method_34()
	{
		return new Class5338(0, imethod_22(new Class5254(this)), auxiliary: true);
	}

	private Class5342 method_35(int penaltyValue)
	{
		return new Class5342(0, penaltyValue, penaltyFlagged: false, new Class5255(this, null), auxiliary: false);
	}

	private Class5344 method_36(int width, Class5682 adjustmentClass, bool isAuxiliary)
	{
		return new Class5344(width, 0, 0, adjustmentClass, new Class5255(this, null), isAuxiliary);
	}

	protected virtual ArrayList vmethod_6(Interface173 childLM, Class5687 context, Class5687 childLC, int alignment, Stack lmStack, Class5254 restartPosition, Interface173 restartAtLM)
	{
		if (childLM == arrayList_0[0])
		{
			childLC.method_1(16);
		}
		if (lmStack == null)
		{
			return childLM.imethod_14(childLC, alignment);
		}
		return childLM.imethod_26(childLC, alignment, lmStack, restartPosition, restartAtLM);
	}

	protected void method_37(ArrayList contentList, Class5687 parentLC, Class5687 childLC)
	{
		if (!imethod_30() && !parentLC.method_16() && !childLC.method_17())
		{
			Class5328 @class = (Class5328)Class5693.smethod_0(contentList);
			if (!@class.vmethod_1() && !Class5683.smethod_8(contentList))
			{
				contentList.Add(new Class5336(new Class5254(this), 0, 9, parentLC));
			}
		}
		else
		{
			Class5686 class2 = imethod_29();
			class2 = class2.method_4(parentLC.method_9());
			parentLC.method_11();
			class2 = class2.method_4(childLC.method_10());
			childLC.method_12();
			contentList.Add(new Class5336(new Class5254(this), class2.method_3(), class2.method_2(), parentLC));
		}
	}

	public virtual int imethod_27(int adj, Class5337 lastElement)
	{
		Class5254 @class = lastElement.method_0().vmethod_0();
		if (@class == null && lastElement.vmethod_1())
		{
			if (((Class5344)lastElement).method_6() == Class5682.class5682_1)
			{
				int_3 += adj;
			}
			else
			{
				int_4 += adj;
			}
			return adj;
		}
		if (@class is Class5261)
		{
			Class5261 class2 = (Class5261)@class;
			if (lastElement.vmethod_1())
			{
				Interface168 @interface = new Class5495(arrayList_1, class2.method_6());
				int num = 0;
				while (@interface.imethod_4() <= class2.method_7())
				{
					Class5337 class3 = (Class5337)@interface.imethod_1();
					if (class3.vmethod_1())
					{
						num += ((Interface174)class3.method_2()).imethod_27(adj - num, class3);
					}
				}
				return (num > 0) ? (int_2 * method_28(num)) : (-int_2 * method_28(-num));
			}
			Class5342 class4 = (Class5342)arrayList_1[class2.method_7()];
			if (class4.method_4() > 0)
			{
				return ((Interface174)class4.method_2()).imethod_27(class4.method_4(), class4);
			}
			return adj;
		}
		if (@class != null && @class.method_0() != this)
		{
			Class5255 positioN = (Class5255)lastElement.method_0();
			lastElement.method_1(@class);
			int result = ((Interface174)lastElement.method_2()).imethod_27(adj, lastElement);
			lastElement.method_1(positioN);
			return result;
		}
		return 0;
	}

	public virtual void imethod_28(Class5344 spaceGlue)
	{
		Class5254 @class = spaceGlue.method_0().vmethod_0();
		if (@class != null && @class.method_0() != this)
		{
			Class5255 positioN = (Class5255)spaceGlue.method_0();
			spaceGlue.method_1(@class);
			((Interface174)spaceGlue.method_2()).imethod_28(spaceGlue);
			spaceGlue.method_1(positioN);
		}
		else if (spaceGlue.method_6() == Class5682.class5682_1)
		{
			int_3 = 0;
		}
		else
		{
			int_4 = 0;
		}
	}

	public override ArrayList imethod_15(ArrayList oldList, int alignment)
	{
		Interface168 @interface = new Class5495(oldList);
		Class5337 @class = null;
		Class5337 class2 = null;
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		int num = 0;
		while (@interface.imethod_0())
		{
			Class5337 class3 = (Class5337)@interface.imethod_1();
			Class5254 class4 = class3.method_0().vmethod_0();
			if (class4 != null)
			{
				class3.method_1(class4);
			}
			else
			{
				class3.method_1(new Class5254(this));
			}
		}
		Interface168 interface2 = new Class5495(oldList);
		while (interface2.imethod_0())
		{
			@class = (Class5337)interface2.imethod_1();
			if (class2 != null && class2.method_2() != @class.method_2())
			{
				Interface174 interface3 = (Interface174)class2.method_2();
				Interface174 interface4 = (Interface174)@class.method_2();
				bool flag = false;
				if (interface3 != this)
				{
					ArrayList arrayList3 = interface3.imethod_15(oldList.GetRange(num, interface2.imethod_5() - num + 1), alignment);
					foreach (object item in arrayList3)
					{
						arrayList.Add(item);
					}
					flag = true;
				}
				num = interface2.imethod_5();
				if (flag && (imethod_30() || interface3.imethod_34() || interface4.imethod_32()))
				{
					arrayList.Add(method_35(Class5337.int_0));
				}
				else if (flag && !((Class5337)Class5693.smethod_0(arrayList)).vmethod_1())
				{
					arrayList.Add(method_35(Class5337.int_0));
				}
			}
			class2 = @class;
		}
		if (@class != null)
		{
			Interface173 interface5 = @class.method_2();
			if (interface5 != this)
			{
				ArrayList arrayList4 = interface5.imethod_15(oldList.GetRange(num, oldList.Count - num + 1), alignment);
				foreach (object item2 in arrayList4)
				{
					arrayList.Add(item2);
				}
			}
			else if (arrayList.Count != 0)
			{
				Class5693.smethod_1(arrayList);
			}
		}
		bool flag2 = true;
		if (class5094_0 is Class5106)
		{
			flag2 = method_41().method_15();
		}
		if (int_3 != 0)
		{
			if (!flag2)
			{
				arrayList2.Add(method_33());
				arrayList2.Add(method_35(Class5337.int_0));
			}
			arrayList2.Add(method_36(int_3, Class5682.class5682_1, isAuxiliary: false));
		}
		foreach (Class5337 item3 in arrayList2)
		{
			item3.method_1(new Class5255(this, item3.method_0()));
			arrayList2.Add(item3);
		}
		bool flag3 = true;
		if (class5094_0 is Class5106)
		{
			flag3 = method_42().method_15();
		}
		if (int_4 != 0)
		{
			if (!flag3)
			{
				arrayList2.Add(method_35(Class5337.int_0));
			}
			arrayList2.Add(method_36(int_4, Class5682.class5682_2, flag3));
			if (!flag3)
			{
				arrayList2.Add(method_33());
			}
		}
		return arrayList2;
	}

	protected Class5686 method_38()
	{
		Class5686 result = Class5686.class5686_0;
		if (imethod_2() is Interface174)
		{
			result = ((Interface174)imethod_2()).imethod_29();
		}
		else if (imethod_2() is Class5315 && ((Class5315)imethod_2()).method_32())
		{
			result = Class5686.class5686_1;
		}
		return result;
	}

	public bool imethod_30()
	{
		return !imethod_29().method_1();
	}

	public bool imethod_32()
	{
		return !imethod_31().method_1();
	}

	public bool imethod_34()
	{
		return !imethod_33().method_1();
	}

	public virtual Class5686 imethod_29()
	{
		Class5686 @class = Class5686.smethod_1(imethod_35());
		return @class.method_4(method_38());
	}

	public virtual Class5686 imethod_31()
	{
		return Class5686.smethod_1(imethod_36());
	}

	public virtual Class5686 imethod_33()
	{
		return Class5686.smethod_1(imethod_37());
	}

	public virtual Class5043 imethod_35()
	{
		throw new InvalidOperationException();
	}

	public virtual Class5043 imethod_36()
	{
		throw new InvalidOperationException();
	}

	public virtual Class5043 imethod_37()
	{
		throw new InvalidOperationException();
	}

	protected void method_39(Class5687 context)
	{
		Class5703 @class = method_40();
		if (@class != null)
		{
			if (@class.method_6(discard: false) > 0)
			{
				context.method_26(new Class5333(vmethod_3(), @class.method_2(0).method_2(), Class5695.class5695_0, isFirst: false, isLast: false, this));
			}
			if (@class.method_10(discard: false, this) > 0)
			{
				context.method_26(new Class5334(vmethod_3(), @class.method_17(0), Class5695.class5695_0, isFirst: false, isLast: false, this));
			}
			if (@class.method_7(discard: false) > 0)
			{
				context.method_23(new Class5333(vmethod_3(), @class.method_2(1).method_2(), Class5695.class5695_1, isFirst: false, isLast: false, this));
			}
			if (@class.method_11(discard: false, this) > 0)
			{
				context.method_23(new Class5334(vmethod_3(), @class.method_17(1), Class5695.class5695_1, isFirst: false, isLast: false, this));
			}
		}
	}

	private Class5703 method_40()
	{
		if (class5094_0 is Class5106)
		{
			return ((Class5106)class5094_0).method_51();
		}
		if (class5094_0 is Class5161)
		{
			return ((Class5161)class5094_0).method_50();
		}
		if (class5094_0 is Class5159)
		{
			return ((Class5159)class5094_0).method_49();
		}
		if (class5094_0 is Class5160)
		{
			return ((Class5160)class5094_0).method_49();
		}
		if (class5094_0 is Class5156)
		{
			return ((Class5156)class5094_0).vmethod_33();
		}
		return null;
	}

	protected Class5046 method_41()
	{
		if (class5094_0 is Class5106)
		{
			return ((Class5106)class5094_0).method_50().class5046_0;
		}
		if (class5094_0 is Class5161)
		{
			return ((Class5161)class5094_0).method_49().class5046_0;
		}
		if (class5094_0 is Class5159)
		{
			return ((Class5159)class5094_0).method_48().class5046_0;
		}
		if (class5094_0 is Class5160)
		{
			return ((Class5160)class5094_0).method_48().class5046_0;
		}
		if (class5094_0 is Class5156)
		{
			return ((Class5156)class5094_0).method_66().class5046_0;
		}
		return null;
	}

	protected Class5046 method_42()
	{
		if (class5094_0 is Class5106)
		{
			return ((Class5106)class5094_0).method_50().class5046_1;
		}
		if (class5094_0 is Class5161)
		{
			return ((Class5161)class5094_0).method_49().class5046_1;
		}
		if (class5094_0 is Class5159)
		{
			return ((Class5159)class5094_0).method_48().class5046_1;
		}
		if (class5094_0 is Class5160)
		{
			return ((Class5160)class5094_0).method_48().class5046_1;
		}
		if (class5094_0 is Class5156)
		{
			return ((Class5156)class5094_0).method_66().class5046_1;
		}
		return null;
	}

	protected void method_43(ArrayList returnList, bool isFirst)
	{
		Class5703 @class = method_40();
		if (@class != null)
		{
			if (@class.method_6(discard: false) > 0)
			{
				returnList.Add(new Class5333(vmethod_3(), @class.method_2(0).method_2(), Class5695.class5695_0, isFirst, isLast: false, this));
			}
			if (@class.method_10(discard: false, this) > 0)
			{
				returnList.Add(new Class5334(vmethod_3(), @class.method_17(0), Class5695.class5695_0, isFirst, isLast: false, this));
			}
		}
	}

	protected void method_44(ArrayList returnList, bool isLast)
	{
		Class5703 @class = method_40();
		if (@class != null)
		{
			if (@class.method_11(discard: false, this) > 0)
			{
				returnList.Add(new Class5334(vmethod_3(), @class.method_17(1), Class5695.class5695_1, isFirst: false, isLast, this));
			}
			if (@class.method_7(discard: false) > 0)
			{
				returnList.Add(new Class5333(vmethod_3(), @class.method_2(1).method_2(), Class5695.class5695_1, isFirst: false, isLast, this));
			}
		}
	}

	protected bool method_45(ArrayList returnList, Class5687 context)
	{
		int num = method_46();
		if (num != 104 && num != 28 && num != 44 && num != 100)
		{
			return false;
		}
		returnList.Add(new Class5336(vmethod_3(), 0, -Class5337.int_0, num, context));
		return true;
	}

	private int method_46()
	{
		int num = 9;
		if (class5094_0 is Interface229)
		{
			num = ((Interface229)class5094_0).imethod_2();
		}
		Interface173 @interface = method_9();
		if (@interface is Class5281)
		{
			Class5281 @class = (Class5281)@interface;
			num = Class5676.smethod_1(num, @class.method_46());
		}
		return num;
	}

	protected bool method_47(ArrayList returnList, Class5687 context)
	{
		int num = -1;
		if (class5094_0 is Interface229)
		{
			num = ((Interface229)class5094_0).imethod_1();
		}
		if (num != 104 && num != 28 && num != 44 && num != 100)
		{
			return false;
		}
		returnList.Add(new Class5336(vmethod_3(), 0, -Class5337.int_0, num, context));
		return true;
	}

	protected void method_48(ArrayList returnList, int alignment)
	{
		Class5046 @class = method_41();
		if (@class != null && (@class.method_8(this).vmethod_0().imethod_6(this) != 0 || @class.method_9(this).vmethod_0().imethod_6(this) != 0))
		{
			returnList.Add(new Class5335(vmethod_3(), @class, Class5695.class5695_0, isFirst: true, isLast: false, this));
		}
	}

	protected void method_49(ArrayList returnList, int alignment)
	{
		Class5046 @class = method_42();
		if (@class != null && (@class.method_8(this).vmethod_0().imethod_6(this) != 0 || @class.method_9(this).vmethod_0().imethod_6(this) != 0))
		{
			returnList.Add(new Class5335(vmethod_3(), @class, Class5695.class5695_1, isFirst: false, isLast: true, this));
		}
	}

	protected void method_50(ArrayList sourceList, ArrayList targetList)
	{
		method_51(sourceList, targetList, force: false);
	}

	protected void method_51(ArrayList sourceList, ArrayList targetList, bool force)
	{
		Interface168 @interface = new Class5495(sourceList);
		while (@interface.imethod_0())
		{
			object obj = @interface.imethod_1();
			if (obj is Class5328)
			{
				method_52((Class5328)obj, targetList, force);
			}
			else if (obj is ArrayList)
			{
				method_51((ArrayList)obj, targetList, force);
			}
		}
	}

	protected void method_52(Class5328 el, ArrayList targetList, bool force)
	{
		if (force || el.method_2() != this)
		{
			el.method_1(imethod_22(new Class5255(this, el.method_0())));
		}
		targetList.Add(el);
	}

	internal virtual int vmethod_7()
	{
		return int_6 + int_7;
	}

	public override int imethod_16()
	{
		return int_9;
	}

	protected virtual void vmethod_8(int contentAreaIPD)
	{
		int_9 = contentAreaIPD;
	}

	public override int imethod_17()
	{
		return -1;
	}

	public override void imethod_23()
	{
		base.imethod_23();
		bool_3 = false;
		bool_4 = false;
	}
}
