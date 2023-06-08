using System;
using System.Collections;
using System.Collections.Generic;
using ns173;
using ns176;
using ns183;
using ns190;
using ns195;
using ns198;

namespace ns196;

internal class Class5297 : Class5281, Interface172, Interface173, Interface174
{
	private Class4957[] class4957_1 = new Class4957[Class4942.int_10];

	private List<Class5298> list_0 = new List<Class5298>();

	internal List<Class5298> FloatLayoutManagers => list_0;

	public Class5297(Class5322 pslm, Class5128 node)
		: base(node)
	{
		imethod_1(pslm);
		Class5326.Instance.CurrentFlowLayoutManager = this;
	}

	public override ArrayList imethod_14(Class5687 context, int alignment)
	{
		return method_53(context, alignment, null, null);
	}

	internal ArrayList method_53(Class5687 context, int alignment, Class5254 restartPosition, Interface173 restartLM)
	{
		ArrayList arrayList = new ArrayList();
		bool flag;
		bool flag2 = (flag = restartPosition != null);
		Stack stack = new Stack();
		Interface173 @interface;
		if (flag)
		{
			@interface = restartPosition.method_0();
			if (@interface == null)
			{
				throw new InvalidOperationException("Cannot find layout manager to restart from");
			}
			if (restartLM != null && restartLM.imethod_2() == this)
			{
				@interface = restartLM;
			}
			else
			{
				while (@interface.imethod_2() != this)
				{
					stack.Push(@interface);
					@interface = @interface.imethod_2();
				}
				flag2 = false;
			}
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
				if (flag && !flag2)
				{
					if (method_54(arrayList, @interface, context, alignment, stack, restartPosition, restartLM) != null)
					{
						return arrayList;
					}
					flag2 = true;
				}
				else
				{
					if (flag2)
					{
						@interface.imethod_23();
					}
					if (method_54(arrayList, @interface, context, alignment, null, null, null) != null)
					{
						break;
					}
				}
				@interface = method_9();
				continue;
			}
			Class5644.smethod_6(arrayList);
			imethod_6(fin: true);
			return arrayList;
		}
		return arrayList;
	}

	private ArrayList method_54(ArrayList elements, Interface173 childLM, Class5687 context, int alignment, Stack lmStack, Class5254 position, Interface173 restartAtLM)
	{
		if (smethod_1(childLM, context))
		{
			Class5644.smethod_6(elements);
			return elements;
		}
		Class5687 @class = vmethod_4(context);
		ArrayList arrayList = vmethod_6(childLM, context, @class, alignment, lmStack, position, restartAtLM);
		if (elements.Count == 0)
		{
			context.method_15(@class.method_10());
		}
		if (elements.Count != 0 && !Class5683.smethod_7(arrayList))
		{
			method_37(elements, context, @class);
		}
		context.method_14(@class.method_9());
		elements.AddRange(arrayList);
		if (Class5683.smethod_6(elements))
		{
			if (childLM.imethod_5() && !method_11())
			{
				imethod_6(fin: true);
			}
			Class5644.smethod_6(elements);
			return elements;
		}
		return null;
	}

	private static bool smethod_1(Interface173 childLM, Class5687 context)
	{
		int num = 95;
		int disableColumnBalancing = 48;
		if (childLM is Class5283)
		{
			num = ((Class5283)childLM).method_56().method_64();
			disableColumnBalancing = ((Class5283)childLM).method_56().method_78();
		}
		else if (childLM is Class5285)
		{
			num = ((Class5285)childLM).method_67().method_60();
			disableColumnBalancing = ((Class5285)childLM).method_67().method_61();
		}
		int num2 = context.method_49();
		if (num2 != num)
		{
			if (num == 5)
			{
				context.method_62(disableColumnBalancing);
			}
			context.method_50(num);
			return true;
		}
		return false;
	}

	protected override Class5687 vmethod_4(Class5687 context)
	{
		Class5687 @class = new Class5687(0);
		@class.method_28(context.method_29());
		@class.method_30(context.method_31());
		@class.method_52(vmethod_0().method_0().method_59());
		return @class;
	}

	protected override ArrayList vmethod_6(Interface173 childLM, Class5687 context, Class5687 childLC, int alignment, Stack lmStack, Class5254 restartPosition, Interface173 restartLM)
	{
		ArrayList arrayList = ((lmStack != null) ? childLM.imethod_26(childLC, alignment, lmStack, restartPosition, restartLM) : childLM.imethod_14(childLC, alignment));
		ArrayList sourceList = arrayList;
		arrayList = new ArrayList();
		method_50(sourceList, arrayList);
		return arrayList;
	}

	public override int imethod_27(int adj, Class5337 lastElement)
	{
		if (lastElement.method_0() is Class5255)
		{
			Class5255 @class = (Class5255)lastElement.method_0();
			lastElement.method_1(@class.vmethod_0());
			int result = ((Interface174)lastElement.method_2()).imethod_27(adj, lastElement);
			lastElement.method_1(@class);
			return result;
		}
		return 0;
	}

	public override void imethod_28(Class5344 spaceGlue)
	{
		if (spaceGlue.method_0() is Class5255)
		{
			Class5255 @class = (Class5255)spaceGlue.method_0();
			spaceGlue.method_1(@class.vmethod_0());
			((Interface174)spaceGlue.method_2()).imethod_28(spaceGlue);
			spaceGlue.method_1(@class);
		}
	}

	public override Class5686 imethod_29()
	{
		return Class5686.class5686_0;
	}

	public override Class5686 imethod_33()
	{
		return Class5686.class5686_0;
	}

	public override Class5686 imethod_31()
	{
		return Class5686.class5686_0;
	}

	public override ArrayList imethod_15(ArrayList oldList, int alignment)
	{
		Interface168 @interface = new Class5495(oldList);
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		Class5337 @class = null;
		Class5337 class2 = null;
		int from = 0;
		while (@interface.imethod_0())
		{
			Class5337 class3 = (Class5337)@interface.imethod_1();
			if (class3.method_0() is Class5255)
			{
				class3.method_1(class3.method_0().vmethod_0());
			}
			else
			{
				@interface.imethod_6();
			}
		}
		@interface = new Class5495(oldList);
		while (@interface.imethod_0())
		{
			class2 = (Class5337)@interface.imethod_1();
			if (@class != null && @class.method_2() != class2.method_2())
			{
				Interface174 interface2 = (Interface174)@class.method_2();
				Interface174 interface3 = (Interface174)class2.method_2();
				Class5480 class4 = new Class5480(oldList, from, @interface.imethod_5());
				arrayList.AddRange(interface2.imethod_15(class4.method_0(), alignment));
				class4.method_1();
				from = @interface.imethod_5();
				if (!interface2.imethod_34() && !interface3.imethod_32())
				{
					if (!((Class5337)Class5693.smethod_0(arrayList)).vmethod_1())
					{
						arrayList.Add(new Class5342(0, 0, penaltyFlagged: false, new Class5254(this), auxiliary: false));
					}
				}
				else
				{
					arrayList.Add(new Class5342(0, Class5337.int_0, penaltyFlagged: false, new Class5254(this), auxiliary: false));
				}
			}
			@class = class2;
		}
		if (class2 != null)
		{
			Interface174 interface4 = (Interface174)class2.method_2();
			Class5480 class5 = new Class5480(oldList, from, oldList.Count);
			arrayList.AddRange(interface4.imethod_15(class5.method_0(), alignment));
			class5.method_1();
		}
		Interface168 interface5 = new Class5495(arrayList);
		while (interface5.imethod_0())
		{
			Class5337 class6 = (Class5337)interface5.imethod_1();
			if (class6.method_2() != this)
			{
				class6.method_1(new Class5255(this, class6.method_0()));
			}
			arrayList2.Add(class6);
		}
		return arrayList2;
	}

	public override void imethod_9(Class5652 parentIter, Class5687 layoutContext)
	{
		Class5648.smethod_0(this, parentIter, layoutContext);
		vmethod_2();
	}

	public override void imethod_8(Class4942 childArea)
	{
		imethod_7(childArea);
		method_27(childArea, class4957_1[childArea.method_9()]);
	}

	public override Class4942 imethod_7(Class4942 childArea)
	{
		Class4957 @class = null;
		int num = childArea.method_9();
		if (num == Class4942.int_4)
		{
			@class = method_15().method_35();
		}
		else if (num == Class4942.int_7)
		{
			@class = method_15().method_32().method_49();
		}
		else if (num == Class4942.int_8)
		{
			@class = method_15().method_32().method_50();
		}
		else
		{
			if (num != Class4942.int_9)
			{
				throw new InvalidOperationException("(internal error) Invalid area class (" + num + ") requested.");
			}
			@class = method_15().method_32().method_44();
		}
		class4957_1[num] = @class;
		method_25(@class);
		return @class;
	}

	public override int imethod_16()
	{
		return method_15().method_34().method_39();
	}

	public override int imethod_17()
	{
		return method_15().method_32().vmethod_1();
	}

	public override bool imethod_24()
	{
		return true;
	}
}
