using System;
using System.Collections;
using System.Text;
using ns173;
using ns183;
using ns187;
using ns189;
using ns196;
using ns205;

namespace ns199;

internal class Class5289 : Class5281, Interface184
{
	private class Class5262 : Class5254
	{
		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		public Class5262(Interface173 lm, int labelFirst, int labelLast, int bodyFirst, int bodyLast)
			: base(lm)
		{
			int_1 = labelFirst;
			int_2 = labelLast;
			int_3 = bodyFirst;
			int_4 = bodyLast;
		}

		public int method_6()
		{
			return int_1;
		}

		public int method_7()
		{
			return int_2;
		}

		public int method_8()
		{
			return int_3;
		}

		public int method_9()
		{
			return int_4;
		}

		public override bool vmethod_1()
		{
			return true;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder("ListItemPosition:");
			stringBuilder.Append(method_4()).Append("(");
			stringBuilder.Append("label:").Append(int_1).Append("-")
				.Append(int_2);
			stringBuilder.Append(" body:").Append(int_3).Append("-")
				.Append(int_4);
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}
	}

	private Class5293 class5293_0;

	private Class5293 class5293_1;

	private Class4962 class4962_0;

	private ArrayList arrayList_2;

	private ArrayList arrayList_3;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private Class5746 class5746_0;

	private Class5746 class5746_1;

	private Class5686 class5686_0;

	private Class5686 class5686_1;

	private bool bool_9;

	internal bool IsStrartLabelList => bool_9;

	public Class5289(Class5160 node)
		: base(node)
	{
		method_54(node.method_53());
		method_55(node.method_54());
	}

	protected Class5160 method_53()
	{
		return (Class5160)class5094_0;
	}

	public void method_54(Class5132 node)
	{
		class5293_0 = new Class5293(node);
		class5293_0.imethod_1(this);
	}

	public void method_55(Class5131 node)
	{
		class5293_1 = new Class5293(node);
		class5293_1.imethod_1(this);
	}

	public override void imethod_3()
	{
		int_6 = method_53().method_48().interface182_4.imethod_6(this);
		int_7 = method_53().method_48().interface182_5.imethod_6(this);
	}

	private void method_56()
	{
		bool_5 = false;
		bool_6 = false;
		bool_7 = false;
		bool_8 = false;
		class5746_0 = null;
		class5746_1 = null;
	}

	public override ArrayList imethod_14(Class5687 context, int alignment)
	{
		int_5 = context.method_31();
		ArrayList arrayList = new ArrayList();
		if (!method_32(context, arrayList))
		{
			return arrayList;
		}
		vmethod_5(arrayList, context, alignment);
		Class5687 @class = vmethod_4(context);
		class5293_0.imethod_3();
		try
		{
			bool_9 = true;
			arrayList_2 = class5293_0.imethod_14(@class, alignment);
		}
		finally
		{
			bool_9 = false;
		}
		Class5746 class2 = @class.method_63() ?? Class5746.class5746_0;
		Class5644.smethod_6(arrayList_2);
		Class5651.smethod_2(arrayList_2, "list-item-label", class5293_0.method_53().vmethod_31());
		context.method_15(@class.method_10());
		class5686_0 = @class.method_9();
		@class = vmethod_4(context);
		class5293_1.imethod_3();
		arrayList_3 = class5293_1.imethod_14(@class, alignment);
		Class5746 class3 = @class.method_63() ?? Class5746.class5746_0;
		class2 = class2.method_19(class3.method_1()).method_20(class3.method_3());
		context.method_64(class2);
		Class5644.smethod_6(arrayList_3);
		Class5651.smethod_2(arrayList_3, "list-item-body", class5293_1.method_53().vmethod_31());
		context.method_15(@class.method_10());
		class5686_1 = @class.method_9();
		ArrayList sourceList = method_57(arrayList_2, arrayList_3, context);
		method_51(sourceList, arrayList, force: true);
		method_31(arrayList, context, alignment);
		method_47(arrayList, context);
		context.method_14(class5686_0);
		context.method_14(class5686_1);
		context.method_14(imethod_33());
		context.method_15(imethod_31());
		imethod_6(fin: true);
		method_56();
		return arrayList;
	}

	protected override void vmethod_5(ArrayList elements, Class5687 context, int alignment)
	{
		method_48(elements, alignment);
		method_43(elements, !bool_4);
		bool_4 = true;
		method_39(context);
	}

	private ArrayList method_57(ArrayList labelElements, ArrayList bodyElements, Class5687 context)
	{
		ArrayList[] array = new ArrayList[2]
		{
			new ArrayList(labelElements),
			new ArrayList(bodyElements)
		};
		int[] array2 = new int[2]
		{
			Class5683.smethod_5(array[0]),
			Class5683.smethod_5(array[1])
		};
		int[] array3 = new int[2];
		int[] partialHeights = array3;
		int[] array4 = new int[2] { -1, -1 };
		int[] array5 = new int[2] { -1, -1 };
		int num = Math.Max(array2[0], array2[1]);
		int num2 = 0;
		Class5686 @class = Class5686.class5686_0;
		ArrayList arrayList = new ArrayList();
		int num3;
		while ((num3 = method_58(array, array4, array5, partialHeights)) > 0)
		{
			if (array5[0] + 1 == array[0].Count)
			{
				@class = @class.method_4(class5686_0);
			}
			if (array5[1] + 1 == array[1].Count)
			{
				@class = @class.method_4(class5686_1);
			}
			int num4 = num3 + method_59(array2, partialHeights) - num;
			int num5 = 0;
			int num6 = 0;
			Class5337 class2 = (Class5337)array[0][array5[0]];
			if (class2 is Class5342)
			{
				num5 = class2.method_4();
				num6 = Math.Max(num6, class2.vmethod_5());
			}
			class2 = (Class5337)array[1][array5[1]];
			if (class2 is Class5342)
			{
				num5 = Math.Max(num5, class2.method_4());
				num6 = Math.Max(num6, class2.vmethod_5());
			}
			int num7 = num3 - num2 - num4;
			num4 += num5;
			ArrayList arrayList2 = null;
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = array4[i]; j <= array5[i]; j++)
				{
					Class5328 class3 = (Class5328)array[i][j];
					if (class3 is Class5341 && ((Class5341)class3).method_8())
					{
						if (arrayList2 == null)
						{
							arrayList2 = new ArrayList();
						}
						arrayList2.AddRange(((Class5341)class3).method_6());
					}
				}
			}
			num2 += num7;
			Class5262 class4 = new Class5262(this, array4[0], array5[0], array4[1], array5[1]);
			if (arrayList2 == null)
			{
				arrayList.Add(new Class5338(num7, class4, auxiliary: false));
			}
			else
			{
				arrayList.Add(new Class5341(num7, arrayList2, new ArrayList(), class4, auxiliary: false));
			}
			if (num2 < num)
			{
				Class5686 class5 = @class.method_4(imethod_29());
				int num8 = num6;
				if (num8 > -Class5337.int_0)
				{
					num8 = Math.Max(num8, class5.method_3());
				}
				arrayList.Add(new Class5336(class4, num4, num8, class5.method_2(), context));
			}
		}
		return arrayList;
	}

	private int method_58(ArrayList[] elementLists, int[] start, int[] end, int[] partialHeights)
	{
		int[] array = new int[2]
		{
			partialHeights[0],
			partialHeights[1]
		};
		start[0] = end[0] + 1;
		start[1] = end[1] + 1;
		int num = 0;
		for (int i = 0; i < start.Length; i++)
		{
			while (end[i] + 1 < elementLists[i].Count)
			{
				end[i]++;
				Class5337 @class = (Class5337)elementLists[i][end[i]];
				if (@class.vmethod_2())
				{
					if (@class.vmethod_5() < Class5337.int_0)
					{
						break;
					}
				}
				else if (@class.vmethod_1())
				{
					if (end[i] > 0)
					{
						Class5337 class2 = (Class5337)elementLists[i][end[i] - 1];
						if (class2.vmethod_0())
						{
							break;
						}
					}
					partialHeights[i] += @class.method_4();
				}
				else
				{
					partialHeights[i] += @class.method_4();
				}
			}
			if (end[i] < start[i])
			{
				partialHeights[i] = array[i];
			}
			else
			{
				num++;
			}
		}
		if (num == 0)
		{
			return 0;
		}
		int num2 = ((array[0] != 0 || array[1] != 0) ? Math.Min((end[0] >= start[0]) ? partialHeights[0] : int.MaxValue, (end[1] >= start[1]) ? partialHeights[1] : int.MaxValue) : Math.Max((end[0] >= start[0]) ? partialHeights[0] : int.MinValue, (end[1] >= start[1]) ? partialHeights[1] : int.MinValue));
		for (int j = 0; j < partialHeights.Length; j++)
		{
			if (partialHeights[j] > num2)
			{
				partialHeights[j] = array[j];
				end[j] = start[j] - 1;
			}
		}
		return num2;
	}

	private int method_59(int[] fullHeights, int[] partialHeights)
	{
		return Math.Max(fullHeights[0] - partialHeights[0], fullHeights[1] - partialHeights[1]);
	}

	public override ArrayList imethod_15(ArrayList oldList, int alignment)
	{
		arrayList_2 = class5293_0.imethod_15(arrayList_2, alignment);
		Interface168 @interface = new Class5495(oldList);
		while (@interface.imethod_0())
		{
			Class5337 @class = (Class5337)@interface.imethod_1();
			Class5254 class2 = @class.method_0().vmethod_0();
			if (class2 != null)
			{
				@class.method_1(class2);
			}
			else
			{
				@class.method_1(new Class5254(this));
			}
		}
		ArrayList arrayList = class5293_1.imethod_15(oldList, alignment);
		ArrayList arrayList2 = arrayList;
		arrayList = new ArrayList();
		Interface168 interface2 = new Class5495(arrayList2);
		while (interface2.imethod_0())
		{
			Class5337 class3 = (Class5337)interface2.imethod_1();
			class3.method_1(new Class5255(this, class3.method_0()));
			arrayList.Add(class3);
		}
		return arrayList;
	}

	public override void imethod_9(Class5652 parentIter, Class5687 layoutContext)
	{
		imethod_7(null);
		vmethod_1();
		Class5687 @class = new Class5687(0);
		Class5254 class2 = null;
		Class5254 pos = null;
		ArrayList arrayList = new ArrayList();
		while (parentIter.imethod_0())
		{
			Class5254 class3 = (Class5254)parentIter.imethod_1();
			if (class3.method_4() >= 0)
			{
				if (class2 == null)
				{
					class2 = class3;
				}
				pos = class3;
			}
			if (class3 is Class5255 && class3.vmethod_0() != null)
			{
				arrayList.Add(class3.vmethod_0());
			}
		}
		method_21(isStarting: true, method_16(class2), method_17(pos));
		int num = ((Class5262)arrayList[0]).method_6();
		int num2 = ((Class5262)arrayList[arrayList.Count - 1]).method_7();
		int num3 = ((Class5262)arrayList[0]).method_8();
		int num4 = ((Class5262)arrayList[arrayList.Count - 1]).method_9();
		int prevBreak = Class5683.smethod_9(arrayList_2, num);
		Class5644.smethod_7(arrayList_2, num, num2, prevBreak);
		prevBreak = Class5683.smethod_9(arrayList_3, num3);
		Class5644.smethod_7(arrayList_3, num3, num4, prevBreak);
		if (num <= num2)
		{
			Class5653 posIter = new Class5653(arrayList_2, num, num2 + 1);
			@class.method_2(32, layoutContext.method_6());
			@class.method_2(128, layoutContext.method_7());
			@class.method_37(layoutContext.method_38());
			@class.method_28(layoutContext.method_29());
			class5293_0.imethod_9(posIter, @class);
		}
		if (num3 <= num4)
		{
			Class5653 posIter2 = new Class5653(arrayList_3, num3, num4 + 1);
			@class.method_2(32, layoutContext.method_6());
			@class.method_2(128, layoutContext.method_7());
			@class.method_37(layoutContext.method_38());
			@class.method_28(layoutContext.method_29());
			class5293_1.imethod_9(posIter2, @class);
		}
		int count = class4962_0.method_37().Count;
		int num5 = ((Class4962)class4962_0.method_37()[0]).method_15();
		if (count == 2)
		{
			num5 = Math.Max(num5, ((Class4962)class4962_0.method_37()[1]).method_15());
		}
		class4962_0.method_13(num5);
		method_21(isStarting: false, method_16(class2), method_17(pos));
		Class5677.smethod_11(class4962_0, method_53().method_49(), this);
		Class5677.smethod_15(class4962_0, layoutContext.method_38(), class5746_0, class5746_1);
		vmethod_2();
		class4962_0 = null;
		method_56();
		method_23(pos);
	}

	public override Class4942 imethod_7(Class4942 childArea)
	{
		if (class4962_0 == null)
		{
			class4962_0 = new Class4962();
			interface173_0.imethod_7(class4962_0);
			Class5160 @class = method_53();
			Class5677.smethod_21(class4962_0, @class.vmethod_31());
			Class5677.smethod_3(class4962_0, @class.method_49(), bool_5, bool_6, discardStart: false, discardEnd: false, this);
			Class5677.smethod_7(class4962_0, @class.method_49(), bool_7, bool_8, discardStart: false, discardEnd: false, this);
			Class5677.smethod_13(class4962_0, @class.method_49(), @class.method_48(), this);
			Class5677.smethod_17(class4962_0, @class.imethod_2(), @class.imethod_1());
			int ipD = int_5 - vmethod_7();
			class4962_0.method_11(ipD);
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

	public override Class5043 imethod_35()
	{
		return method_53().method_52();
	}

	public override Class5043 imethod_36()
	{
		return method_53().method_51();
	}

	public override Class5043 imethod_37()
	{
		return method_53().method_50();
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
				bool_5 = true;
			}
			else
			{
				bool_6 = true;
			}
		}
	}

	public void imethod_40(Class5695 side, Class5746 effectiveLength)
	{
		if (effectiveLength == null)
		{
			if (Class5695.class5695_0 == side)
			{
				bool_7 = true;
			}
			else
			{
				bool_8 = true;
			}
		}
	}

	public override void imethod_23()
	{
		base.imethod_23();
		class5293_0.imethod_23();
		class5293_1.imethod_23();
	}
}
