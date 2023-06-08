using System;
using System.Collections;
using ns171;
using ns180;
using ns183;
using ns195;
using ns205;

namespace ns196;

internal abstract class Class5268
{
	internal class Class5259 : Class5258
	{
		internal double double_0;

		internal int int_2;

		internal int int_3;

		internal int int_4;

		internal int int_5;

		internal int int_6;

		internal int int_7;

		internal int int_8;

		internal Class5259(Interface173 lm, int breakIndex, int fofli, int fofei, int folli, int folei, int flfli, int fllli, double bpdA, int diff)
			: base(lm, breakIndex)
		{
			double_0 = bpdA;
			int_2 = diff;
			int_3 = fofli;
			int_4 = fofei;
			int_5 = folli;
			int_6 = folei;
			int_7 = flfli;
			int_8 = fllli;
		}
	}

	internal class Class5276 : Class5275
	{
		internal int int_1;

		internal int int_2;

		private int int_3;

		private int int_4;

		private Class5268 class5268_0;

		public Class5276(int startOn, int displayAlign, Class5268 owner)
		{
			int_3 = startOn;
			int_4 = displayAlign;
			class5268_0 = owner;
		}

		public int method_8()
		{
			return int_3;
		}

		public int method_9()
		{
			return int_4;
		}

		public override Class5274 vmethod_1()
		{
			return method_10(null);
		}

		public Class5274 method_10(Class5254 breakPosition)
		{
			while (Count > int_1 && !((Class5337)Class5693.smethod_0(this)).vmethod_0())
			{
				Class5693.smethod_1(this);
			}
			if (Count > int_1)
			{
				if (method_9() == 163 && class5268_0.vmethod_6())
				{
					Add(new Class5342(0, -Class5337.int_0, penaltyFlagged: false, breakPosition, auxiliary: false));
					int_2 = 1;
				}
				else
				{
					Add(new Class5342(0, Class5337.int_0, penaltyFlagged: false, null, auxiliary: false));
					Add(new Class5344(0, 10000000, 0, null, auxiliary: false));
					Add(new Class5342(0, -Class5337.int_0, penaltyFlagged: false, breakPosition, auxiliary: false));
					int_2 = 3;
				}
				return this;
			}
			Clear();
			return null;
		}

		public Class5276 method_11(Class5254 breakPosition)
		{
			Class5274 @class = method_10(breakPosition);
			if (@class != null)
			{
				Class5276 class2 = new Class5276(int_3, int_4, class5268_0);
				class2.AddRange(@class);
				class2.int_2 = int_2;
				return class2;
			}
			return null;
		}
	}

	private ArrayList arrayList_0;

	private bool bool_0 = true;

	protected int int_0;

	private int int_1;

	protected Class5746 class5746_0 = Class5746.class5746_0;

	protected Class5746 class5746_1 = Class5746.class5746_0;

	internal static string smethod_0(int breakClassId)
	{
		return (Enum679)breakClassId switch
		{
			Enum679.const_45 => "EVEN PAGE", 
			Enum679.const_29 => "COLUMN", 
			Enum679.const_6 => "ALL", 
			Enum679.const_9 => "ANY", 
			Enum679.const_10 => "AUTO", 
			Enum679.const_182 => "NONE", 
			Enum679.const_76 => "LINE", 
			Enum679.const_191 => "PAGE", 
			Enum679.const_187 => "ODD PAGE", 
			_ => "??? (" + breakClassId + ")", 
		};
	}

	protected abstract int vmethod_0();

	protected abstract bool vmethod_1();

	protected abstract void vmethod_2(Class5652 posIter, Class5687 context);

	protected abstract Interface173 vmethod_3();

	protected abstract Interface173 vmethod_4();

	protected virtual bool vmethod_5()
	{
		return true;
	}

	protected virtual bool vmethod_6()
	{
		return false;
	}

	protected virtual Class5691 vmethod_7()
	{
		return null;
	}

	protected virtual Class5395.Interface183 vmethod_8()
	{
		return null;
	}

	protected abstract ArrayList vmethod_9(Class5687 context, int alignment);

	protected virtual ArrayList vmethod_10(Class5687 context, int alignment, Class5254 positionAtIPDChange, Interface173 restartAtLM)
	{
		throw new NotSupportedException("TODO: implement acceptable fallback");
	}

	public bool method_0()
	{
		return bool_0;
	}

	protected virtual void vmethod_11(Class5276 list, int breakClass)
	{
	}

	protected virtual void vmethod_12()
	{
	}

	protected abstract void vmethod_13(Class5395 alg, Class5259 pbp);

	protected virtual Class5687 vmethod_14()
	{
		return new Class5687(0);
	}

	protected virtual void vmethod_15(Class5687 context)
	{
	}

	protected virtual void vmethod_16(ArrayList elementList)
	{
		Class5651.smethod_2(elementList, "breaker", null);
	}

	public void method_1(int flowBPD, bool autoHeight)
	{
		Class5687 @class = vmethod_14();
		@class.method_28(Class5746.smethod_1(flowBPD));
		if (vmethod_0() == 162)
		{
			int_0 = 70;
		}
		else if (vmethod_0() == 163)
		{
			int_0 = 70;
		}
		else
		{
			int_0 = 135;
		}
		int_1 = 135;
		if (vmethod_6() && int_0 == 70)
		{
			int_1 = 70;
		}
		@class.method_35(int_0);
		arrayList_0 = new ArrayList();
		int nextSequenceStartsOn = 8;
		while (vmethod_1())
		{
			arrayList_0.Clear();
			nextSequenceStartsOn = vmethod_19(@class, nextSequenceStartsOn);
			bool_0 = bool_0 && arrayList_0.Count == 0;
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				Class5276 class2 = (Class5276)arrayList_0[i];
				vmethod_16(class2);
				Class5395 class3 = new Class5395(vmethod_3(), vmethod_7(), vmethod_8(), int_0, int_1, class5746_0, class5746_1, vmethod_5(), autoHeight, vmethod_6());
				Class5276 class4 = ((vmethod_0() != 162) ? class2 : method_6(class2, class3, flowBPD));
				class3.method_2(flowBPD);
				int partCount = class3.method_3(class4, 1.0, force: true, Class5394.int_2);
				if (class3.vmethod_3() != 0)
				{
					method_3(class3, partCount, class2, class4);
					arrayList_0.Clear();
					nextSequenceStartsOn = method_5(@class, class3, class4);
					i = -1;
				}
				else
				{
					vmethod_17(class3, partCount, class2, class4);
				}
			}
		}
		arrayList_0 = null;
	}

	private bool method_2(Class5254 position)
	{
		Interface173 @interface = position.method_0();
		if (@interface != null && !@interface.imethod_24())
		{
			return true;
		}
		Class5254 @class = position.vmethod_0();
		if (@class != null)
		{
			return method_2(@class);
		}
		return false;
	}

	protected abstract void vmethod_17(Class5395 alg, int partCount, Class5276 originalList, Class5276 effectiveList);

	protected void method_3(Class5395 alg, int partCount, Class5276 originalList, Class5276 effectiveList)
	{
		method_4(alg, 0, partCount, originalList, effectiveList);
	}

	protected void method_4(Class5395 alg, int startPart0, int partCount, Class5276 originalList, Class5276 effectiveList)
	{
		int num = 0;
		int num2 = 0;
		int prevBreak = -1;
		for (int i = startPart0; i < startPart0 + partCount; i++)
		{
			Class5259 @class = (Class5259)alg.method_23()[i];
			int breakClass;
			if (i == 0)
			{
				breakClass = effectiveList.method_8();
			}
			else
			{
				Class5328 class2 = effectiveList.method_5(num2);
				if (class2.vmethod_2())
				{
					Class5342 class3 = (Class5342)class2;
					breakClass = class3.method_8();
				}
				else
				{
					breakClass = 28;
				}
			}
			num2 = @class.method_6();
			num += ((num == 0) ? effectiveList.int_1 : 0);
			vmethod_11(effectiveList, breakClass);
			int num3 = vmethod_0();
			int endElementIndex = num2;
			num2 -= ((num2 == originalList.Count - 1) ? effectiveList.int_2 : 0);
			if (((Class5337)effectiveList[num2]).vmethod_1())
			{
				num2--;
			}
			Interface168 @interface = new Class5495(effectiveList);
			while (@interface.imethod_0() && !((Class5337)@interface.imethod_1()).vmethod_0())
			{
				num++;
			}
			if (num <= num2)
			{
				Class5687 class4 = new Class5687(0);
				class4.method_37(@class.double_0);
				if (@class.int_2 != 0 && num3 == 23)
				{
					class4.method_54(@class.int_2 / 2);
				}
				else if (@class.int_2 != 0 && num3 == 3)
				{
					class4.method_54(@class.int_2);
				}
				else if (@class.int_2 != 0 && num3 == 163 && i < partCount - 1)
				{
					int num4 = 0;
					@interface = new Class5495(effectiveList, num);
					while (@interface.imethod_4() <= num2)
					{
						Class5337 class5 = (Class5337)@interface.imethod_1();
						if (class5.vmethod_0() && class5.method_4() > 0)
						{
							num4++;
						}
					}
					if (num4 >= 2)
					{
						class4.method_56(@class.int_2 / (num4 - 1));
					}
				}
				if (num3 == 162)
				{
					int num5 = smethod_1(effectiveList, num, num2);
					if (num5 != 0)
					{
						class4.method_28(Class5746.smethod_1(num5));
					}
				}
				Class5644.smethod_7(effectiveList, num, endElementIndex, prevBreak);
				vmethod_2(new Class5653(effectiveList, num, num2 + 1), class4);
			}
			else
			{
				vmethod_12();
			}
			vmethod_13(alg, @class);
			prevBreak = num2;
			num = @class.method_6() + 1;
		}
	}

	protected virtual int vmethod_18(Class5687 childLC, int nextSequenceStartsOn)
	{
		return nextSequenceStartsOn;
	}

	protected virtual int vmethod_19(Class5687 childLC, int nextSequenceStartsOn)
	{
		return vmethod_20(childLC, nextSequenceStartsOn, null, null, null);
	}

	protected virtual int vmethod_20(Class5687 childLC, int nextSequenceStartsOn, Class5254 positionAtIPDChange, Interface173 restartAtLM, ArrayList firstElements)
	{
		vmethod_15(childLC);
		childLC.method_50(0);
		ArrayList arrayList;
		if (firstElements == null)
		{
			arrayList = vmethod_9(childLC, int_0);
		}
		else if (positionAtIPDChange == null)
		{
			arrayList = firstElements;
			Interface168 @interface = new Class5495(arrayList, arrayList.Count);
			for (int i = 0; i < 3; i++)
			{
				@interface.imethod_3();
				@interface.imethod_6();
			}
		}
		else
		{
			arrayList = vmethod_10(childLC, int_0, positionAtIPDChange, restartAtLM);
			arrayList.InsertRange(0, firstElements);
		}
		if (arrayList != null)
		{
			if (arrayList.Count == 0)
			{
				nextSequenceStartsOn = vmethod_18(childLC, nextSequenceStartsOn);
				return nextSequenceStartsOn;
			}
			Class5276 @class = new Class5276(nextSequenceStartsOn, vmethod_0(), this);
			nextSequenceStartsOn = vmethod_18(childLC, nextSequenceStartsOn);
			Class5254 breakPosition = null;
			if (Class5683.smethod_6(arrayList))
			{
				Class5342 class2 = (Class5342)Class5693.smethod_1(arrayList);
				breakPosition = class2.method_0();
				nextSequenceStartsOn = (Enum679)class2.method_8() switch
				{
					Enum679.const_45 => 44, 
					Enum679.const_29 => 28, 
					Enum679.const_191 => 8, 
					Enum679.const_187 => 100, 
					_ => throw new InvalidOperationException("Invalid break class: " + class2.method_8()), 
				};
			}
			@class.AddRange(arrayList);
			Class5276 class3 = @class.method_11(breakPosition);
			if (class3 != null)
			{
				arrayList_0.Add(class3);
			}
		}
		return nextSequenceStartsOn;
	}

	private int method_5(Class5687 childLC, Class5395 alg, Class5276 effectiveList)
	{
		Class5394.Class5399 @class = alg.method_29();
		int num = @class.int_0;
		Class5337 class2 = alg.method_14(num);
		Class5254 class3 = class2.method_0();
		if (!(class3 is Class5644.Class5263))
		{
			throw new NotSupportedException("Don't know how to restart at position " + class3);
		}
		class3 = class3.vmethod_0();
		Interface173 restartAtLM = null;
		ArrayList arrayList = new ArrayList();
		if (method_2(class3))
		{
			if (alg.vmethod_3() > 0)
			{
				Interface207 broadcaster = vmethod_4().imethod_21().method_2().method_48();
				Interface206 @interface = Class5701.smethod_0(broadcaster);
				@interface.imethod_10(this);
			}
			arrayList = new ArrayList();
			bool flag = false;
			Interface208 interface2 = new Class5495(effectiveList, num + 1);
			Class5254 class4 = null;
			while (interface2.imethod_0() && (class4 == null || method_2(class4)))
			{
				num++;
				Class5337 class5 = (Class5337)interface2.imethod_1();
				class4 = class5.method_0();
				if (class5.vmethod_0())
				{
					flag = true;
					arrayList.Add(class5);
				}
				else if (flag)
				{
					arrayList.Add(class5);
				}
			}
			class3 = ((!(class4 is Class5644.Class5263)) ? null : class4.vmethod_0());
		}
		if (class3 != null && class3.method_4() == -1)
		{
			Interface208 interface3 = new Class5495(effectiveList, num + 1);
			Class5254 class7;
			do
			{
				Class5337 class6 = (Class5337)interface3.imethod_1();
				class7 = class6.method_0();
			}
			while (class7 == null || class7 is Class5644.Class5264 || (class7 is Class5644.Class5263 && class7.vmethod_0().method_4() == -1));
			Interface173 interface4 = class3.method_0();
			while (class7.method_0() != interface4)
			{
				class7 = class7.vmethod_0();
			}
			restartAtLM = class7.vmethod_0().method_0();
		}
		return vmethod_20(childLC, 28, class3, restartAtLM, arrayList);
	}

	private static int smethod_1(Class5274 effectiveList, int startElementIndex, int endElementIndex)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		Interface168 @interface = new Class5495(effectiveList, startElementIndex);
		while (@interface.imethod_4() <= endElementIndex)
		{
			Class5337 @class = (Class5337)@interface.imethod_1();
			if (@class is Class5341)
			{
				Class5341 class2 = (Class5341)@class;
				if (class2.method_16() > 0)
				{
					num++;
					num2 += ((Class5341)@class).method_16();
				}
				if (class2.method_14().method_1() > num3)
				{
					num3 = class2.method_14().method_1();
				}
			}
		}
		int num4 = 0;
		if (num2 > 0 && num > 0)
		{
			num4 = num2 / num;
			if (num4 < num3)
			{
				num4 = num3;
			}
		}
		return num4;
	}

	private Class5276 method_6(Class5276 blockList, Class5395 alg, int availableBPD)
	{
		alg.method_2(availableBPD);
		Interface168 @interface = new Class5495(blockList);
		Interface168 interface2 = new Class5495(alg.method_23());
		Class5337 @class = null;
		while (interface2.imethod_0())
		{
			Class5259 class2 = (Class5259)interface2.imethod_1();
			int num = 0;
			while (@interface.imethod_0())
			{
				Class5337 class3 = (Class5337)@interface.imethod_1();
				if (class3.vmethod_0())
				{
					break;
				}
				if (class3.vmethod_1())
				{
					((Interface174)class3.method_2()).imethod_28((Class5344)class3);
				}
			}
			@interface.imethod_3();
			Class5746 class4 = Class5746.class5746_0;
			Class5746 class5 = Class5746.class5746_0;
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			ArrayList arrayList3 = new ArrayList();
			bool flag = false;
			while (@interface.imethod_0() && @interface.imethod_4() <= class2.method_6())
			{
				@class = (Class5337)@interface.imethod_1();
				if (@class.vmethod_1())
				{
					Class5344 class6 = (Class5344)@class;
					Class5682 class7 = class6.method_6();
					if (!class7.Equals(Class5682.class5682_1) && !class7.Equals(Class5682.class5682_2))
					{
						if (class7.Equals(Class5682.class5682_3))
						{
							class4 = class4.method_13(@class.vmethod_6());
							class4 = class4.method_12(@class.vmethod_7());
							arrayList3.Add(class6);
						}
						else if (!class7.Equals(Class5682.class5682_4))
						{
						}
					}
					else
					{
						arrayList2.Add(class6);
					}
				}
				else
				{
					if (!@class.vmethod_0())
					{
						continue;
					}
					if (!flag)
					{
						flag = true;
						continue;
					}
					while (arrayList2.Count != 0)
					{
						Class5344 class8 = (Class5344)arrayList2[0];
						arrayList2.Remove(0);
						class5 = class5.method_13(class8.vmethod_6());
						class5 = class5.method_12(class8.vmethod_7());
						arrayList.Add(class8);
					}
				}
			}
			if (@class.vmethod_2() && @class.method_4() > 0)
			{
				((Interface174)@class.method_2()).imethod_27(@class.method_4(), @class);
			}
			if ((class2.double_0 != 0.0 && class2.int_2 > 0 && class2.int_2 <= class5.method_3()) || (class2.int_2 < 0 && class2.int_2 >= class5.method_1()))
			{
				num += smethod_2(arrayList, class2.int_2, (class2.int_2 > 0) ? class5.method_3() : (-class5.method_1()));
			}
			else if (class2.double_0 != 0.0)
			{
				num += smethod_3(arrayList3, class2.int_2, (class2.int_2 > 0) ? class4.method_3() : (-class4.method_1()));
				num += smethod_2(arrayList, class2.int_2 - num, (class2.int_2 - num > 0) ? class5.method_3() : (-class5.method_1()));
			}
		}
		Class5276 class9 = new Class5276(blockList.method_8(), blockList.method_9(), this);
		Class5480 class10 = new Class5480(blockList, 0, blockList.Count - blockList.int_2);
		class9.AddRange(vmethod_4().imethod_15(class10.method_0(), 0));
		class10.method_1();
		class9.vmethod_1();
		Class5651.smethod_2(class9, "breaker-effective", null);
		alg.method_23().Clear();
		return class9;
	}

	private static int smethod_2(ArrayList spaceList, int difference, int total)
	{
		Interface168 @interface = new Class5495(spaceList);
		int num = 0;
		int num2 = 0;
		while (@interface.imethod_0())
		{
			Class5344 @class = (Class5344)@interface.imethod_1();
			num2 += ((difference > 0) ? @class.vmethod_6() : @class.vmethod_7());
			int num3 = ((Interface174)@class.method_2()).imethod_27((int)((float)num2 * (float)difference / (float)total) - num, @class);
			num += num3;
		}
		return num;
	}

	private static int smethod_3(ArrayList lineList, int difference, int total)
	{
		Interface168 @interface = new Class5495(lineList);
		int num = 0;
		int num2 = 0;
		while (@interface.imethod_0())
		{
			Class5344 @class = (Class5344)@interface.imethod_1();
			num2 += ((difference > 0) ? @class.vmethod_6() : @class.vmethod_7());
			int num3 = ((Interface174)@class.method_2()).imethod_27((int)((float)num2 * (float)difference / (float)total) - num, @class);
			num += num3;
		}
		return num;
	}
}
