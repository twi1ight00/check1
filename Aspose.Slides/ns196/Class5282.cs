using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using ns173;
using ns181;
using ns183;
using ns186;
using ns187;
using ns189;
using ns197;
using ns198;
using ns199;

namespace ns196;

internal class Class5282 : Class5281
{
	internal class Class5325<T>
	{
		private List<T> list_0;

		private int int_0;

		internal Class5325(List<T> list)
		{
			list_0 = list;
			int_0 = list.Count - 1;
		}

		internal bool method_0()
		{
			return int_0 != -1;
		}

		internal T method_1()
		{
			return list_0[int_0--];
		}
	}

	internal static int int_10;

	private bool bool_5;

	private readonly List<Class5298> list_0 = new List<Class5298>();

	internal Class4942 class4942_0;

	internal int int_11;

	internal int int_12 = -1;

	private int int_13;

	private int int_14;

	private int int_15;

	private bool bool_6;

	private int int_16;

	private int int_17;

	private int int_18;

	private Class5319 class5319_0;

	private int int_19;

	private int int_20;

	private int int_21;

	private int int_22;

	private bool bool_7;

	private int int_23;

	private object object_0;

	private object object_1;

	private bool bool_8;

	public object FObjInitializer => object_0;

	public bool IsReinitialized => bool_8;

	internal int CaptionInset => int_23;

	internal bool InitForTable => bool_7;

	public bool IsCalculated
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public int Width
	{
		get
		{
			return int_20;
		}
		set
		{
			int_20 = value;
		}
	}

	public int Height => int_13;

	internal int X
	{
		get
		{
			return int_21;
		}
		set
		{
			int_21 = value;
		}
	}

	internal int Y
	{
		get
		{
			return int_22;
		}
		set
		{
			int_22 = value;
		}
	}

	internal int KnuthListPositionMutable
	{
		get
		{
			return int_17;
		}
		set
		{
			int_17 = value;
		}
	}

	internal int KnuthListPosition
	{
		get
		{
			return int_16;
		}
		set
		{
			int_16 = (int_17 = value);
		}
	}

	internal int Lines
	{
		get
		{
			return int_18;
		}
		set
		{
			int_18 = value;
		}
	}

	internal int StartLine
	{
		get
		{
			return int_19;
		}
		set
		{
			int_19 = value;
			int_12 = value + 1;
		}
	}

	internal Rectangle Rect
	{
		get
		{
			int num = ((int_12 > 0) ? (int_12 * int_15) : 0);
			if (int_14 < int_22 + num)
			{
				return new Rectangle(int_21, int_22 + num - int_14, int_20, int_13);
			}
			if (int_14 < int_22 + num + int_13)
			{
				return new Rectangle(int_21, 0, int_20, int_22 + num + int_13 - int_14);
			}
			return new Rectangle(int_21, 0, int_20, 0);
		}
	}

	public Class5282(Class5095 node)
		: base(node)
	{
		int_11 = ++int_10;
	}

	public override ArrayList imethod_14(Class5687 context, int alignment)
	{
		return base.imethod_14(context, alignment);
	}

	public override void imethod_9(Class5652 parentIter, Class5687 layoutContext)
	{
		Interface173 @interface = null;
		Interface173 interface2 = null;
		Class5687 @class = new Class5687(0);
		ArrayList arrayList = new ArrayList();
		while (parentIter.imethod_0())
		{
			Class5254 class2 = (Class5254)parentIter.imethod_1();
			Class5254 class3 = class2;
			if (class2 is Class5255)
			{
				class3 = class2.vmethod_0();
				if (class3.method_0() != this)
				{
					arrayList.Add(class3);
					interface2 = class3.method_0();
				}
			}
		}
		Class5652 class4 = new Class5652(new Class5495(arrayList));
		while ((@interface = class4.method_0()) != null)
		{
			@class.method_2(128, layoutContext.method_7() && @interface == interface2);
			@interface.imethod_9(class4, @class);
		}
	}

	internal Class5095 method_53()
	{
		return (Class5095)class5094_0;
	}

	public override Class5043 imethod_36()
	{
		return method_53().method_48();
	}

	public override Class5043 imethod_35()
	{
		return method_53().method_49();
	}

	public override Class5043 imethod_37()
	{
		return method_53().method_50();
	}

	private void method_54(ArrayList children, List<Size> blockViewports, List<Size> blocks, List<Size> lines, int lineWidth)
	{
		if (children == null)
		{
			return;
		}
		foreach (Class4942 child in children)
		{
			method_58(child, blockViewports, blocks, lines, lineWidth);
		}
	}

	private void method_55(Class4963 blockViewport, List<Size> blockViewports, List<Size> blocks, List<Size> lines, int lineWidth)
	{
		if (blockViewport.PredefinedWidth.imethod_0() != 9)
		{
			blockViewports.Add(new Size(blockViewport.method_14(), blockViewport.method_15()));
		}
		else
		{
			method_54(blockViewport.method_37(), blockViewports, blocks, lines, lineWidth);
		}
	}

	private void method_56(Class4972 lineArea, List<Size> blockViewports, List<Size> lines, int lineWidth)
	{
		Size empty = Size.Empty;
		ArrayList arrayList = lineArea.method_39();
		foreach (Class4942 item in arrayList)
		{
			if (item is Class4951 class2)
			{
				Class4942 class3 = class2.method_55();
				if (!(class3 is Class4968) && !(class3 is Class4969) && !(class3 is Class4970) && class3 is Class4950 && item.method_14() >= lineWidth)
				{
					Class4950 class4 = (Class4950)class3;
					List<Size> list = new List<Size>();
					List<Size> blocks = new List<Size>();
					method_57(class4.method_51(), blockViewports, blocks, list, lineWidth);
					Size size = method_59(list);
					empty.Width += size.Width;
					empty.Height = Math.Max(empty.Height, empty.Height);
					continue;
				}
			}
			if (item.method_15() != 0)
			{
				empty.Width += item.method_14();
				empty.Height = Math.Max(empty.Height, item.method_15());
			}
		}
		lines.Add(empty);
	}

	private void method_57(Class4962 block, List<Size> blockViewports, List<Size> blocks, List<Size> lines, int lineWidth)
	{
		blocks.Add(new Size(block.method_14(), block.method_15()));
		method_54(block.method_37(), blockViewports, blocks, lines, lineWidth);
	}

	private void method_58(Class4942 area, List<Size> blockViewports, List<Size> blocks, List<Size> lines, int lineWidth)
	{
		if (area is Class4963 blockViewport)
		{
			method_55(blockViewport, blockViewports, blocks, lines, lineWidth);
		}
		else if (area is Class4972 lineArea)
		{
			method_56(lineArea, blockViewports, lines, lineWidth);
		}
		else if (area is Class4962 block)
		{
			method_57(block, blockViewports, blocks, lines, lineWidth);
		}
	}

	private Size method_59(List<Size> sizes)
	{
		int num = 0;
		int num2 = 0;
		foreach (Size size in sizes)
		{
			num2 = Math.Max(num2, size.Width);
			num = Math.Max(num, size.Height);
		}
		return new Size(num2, num);
	}

	private Size method_60(Class4942 area, int lineWidth)
	{
		List<Size> list = new List<Size>();
		List<Size> list2 = new List<Size>();
		List<Size> list3 = new List<Size>();
		method_58(area, list, list2, list3, lineWidth);
		Size item = method_59(list);
		method_59(list2);
		Size item2 = method_59(list3);
		List<Size> list4 = new List<Size>();
		list4.Add(item);
		list4.Add(item2);
		return method_59(list4);
	}

	private Class4942 method_61(ArrayList elementList)
	{
		Class5687 layoutContext = new Class5687(0);
		Class5648.smethod_0(null, new Class5653(elementList, 0, elementList.Count), layoutContext);
		Class5298 @class = (Class5298)imethod_2();
		return @class.method_24();
	}

	private ArrayList method_62(Class5687 context, int alignment)
	{
		try
		{
			return imethod_26(new Class5687(context), alignment, null, null, null);
		}
		catch (Exception)
		{
		}
		return new ArrayList();
	}

	internal static List<Class5298> smethod_1(Interface173 lm)
	{
		return smethod_2(lm, forsed: false);
	}

	internal static List<Class5298> smethod_2(Interface173 lm, bool forsed)
	{
		Class5282 @class = smethod_9(lm);
		if (@class != null)
		{
			if (!forsed && @class.bool_5)
			{
				return null;
			}
			return @class.list_0;
		}
		return null;
	}

	internal static List<Class5298> smethod_3(Interface173 lm)
	{
		return smethod_8(lm)?.FloatLayoutManagers;
	}

	private void method_63(Stack stack, Interface173 manager)
	{
		if (manager != null && manager != this)
		{
			Interface173 @interface = manager.imethod_2();
			if (@interface.imethod_11().Count == 0)
			{
				@interface.imethod_12(manager);
			}
			stack.Push(manager);
			method_63(stack, @interface);
		}
	}

	internal void method_64(Class5687 context, int alignment, int lineWidth)
	{
		if (bool_6)
		{
			return;
		}
		bool_6 = true;
		if (class4942_0 != null)
		{
			return;
		}
		imethod_3();
		Class4942 @class;
		try
		{
			Class5326.Instance.InsideFloat = true;
			ArrayList arrayList = method_62(context, alignment);
			Class5326.Instance.ResetArea = true;
			if (arrayList.Count == 0)
			{
				return;
			}
			@class = method_61(arrayList);
		}
		finally
		{
			Class5326.Instance.ResetArea = false;
			Class5326.Instance.InsideFloat = false;
		}
		class4942_0 = @class;
		@class.FloatBodyManager = this;
		Size size = method_60(@class, lineWidth);
		int num = 0;
		int num2 = 0;
		List<Class5298> list = smethod_3(this);
		if (list == null)
		{
			list = Class5326.Instance.CurrentFlowLayoutManager.FloatLayoutManagers;
		}
		if (size.Width == 0 && list_0.Count == 1 && list_0[list_0.Count - 1].BodyLm == null)
		{
			list_0[list_0.Count - 1].IsOrdinarContent = true;
			Class5298 class2 = list_0[list_0.Count - 1];
			list_0.Clear();
			try
			{
				Class5326.Instance.InsideFloat = true;
				Stack stack = new Stack();
				method_63(stack, class2.imethod_2());
				class2.imethod_2().imethod_12(class2);
				ArrayList elementList = imethod_26(new Class5687(context), alignment, stack, null, class2);
				Class5326.Instance.ResetArea = true;
				imethod_23();
				@class = method_61(elementList);
			}
			finally
			{
				Class5326.Instance.ResetArea = false;
				Class5326.Instance.InsideFloat = false;
			}
			class4942_0 = @class;
			@class.FloatBodyManager = this;
			size = method_60(@class, lineWidth);
		}
		foreach (Class5298 item in list_0)
		{
			if (item.BodyLm == null)
			{
				list.Add(item);
				continue;
			}
			if (item.BodyLm.method_67())
			{
				num = Math.Max(num, item.BodyLm.Width);
			}
			if (item.BodyLm.method_68())
			{
				num2 = Math.Max(num2, item.BodyLm.Width);
			}
		}
		int_20 = size.Width + num2 + num;
		int_13 = size.Height;
		if (int_13 == 0)
		{
			int_13 = 1;
		}
		Class4963 class3 = @class as Class4963;
		@class.method_29(Class5757.int_36, new Class5026(1000.0, 10));
		if (class3 != null)
		{
			if (class3.method_22() == 0)
			{
				int_20 += class3.EndIndent;
			}
			if (!class3.method_34(Class5757.int_12))
			{
				int_22 = -class3.method_19();
			}
		}
	}

	internal static void smethod_4(int line, int index, Interface173 parent, int lineWidth, int lineHeight, int lead, int follow, Class5687 context, int alignment, ref int leftInset, ref int rightInset)
	{
		rightInset = lineWidth;
		leftInset = 0;
		int num = line * lineHeight;
		int num2 = parent.imethod_4().method_15().method_34()
			.method_39();
		List<Class5298> list = null;
		Class5296 @class = Class5283.smethod_1(parent);
		Class5289 class2 = Class5283.smethod_2(parent);
		if (@class != null && !Class5326.Instance.InsideFloat)
		{
			list = Class5326.Instance.method_1(@class);
		}
		if (list == null)
		{
			list = smethod_3(parent);
			if (list == null)
			{
				list = smethod_1(parent);
				if (list == null)
				{
					return;
				}
			}
		}
		List<Class5282> list2 = new List<Class5282>();
		List<Class5282> list3 = new List<Class5282>();
		int yOffset = 0;
		for (int i = 0; i < list.Count; i++)
		{
			Class5298 class3 = list[i];
			if (class3.BodyLm == null)
			{
				class3.imethod_3();
				class3.BodyLm.imethod_1(class3);
				class3.imethod_1(parent);
				if (parent is Class5287)
				{
					class3.BodyLm.bool_7 = true;
				}
			}
			Class5282 bodyLm = class3.BodyLm;
			if (bodyLm.KnuthListPositionMutable >= index || (bodyLm.object_1 != null && bodyLm.object_1 != parent.imethod_21()))
			{
				continue;
			}
			if (bodyLm.method_68() && class2 != null && class2.IsStrartLabelList)
			{
				bodyLm.int_23 = lineWidth;
				continue;
			}
			int num3 = 0;
			if (!bodyLm.IsCalculated)
			{
				bodyLm.method_64(context, alignment, lineWidth);
				bodyLm.object_1 = null;
				if (bodyLm.object_0 == null)
				{
					bodyLm.object_0 = parent.imethod_21();
				}
				if (bodyLm.KnuthListPositionMutable > 0)
				{
					bodyLm.StartLine = line;
				}
				num3 = bodyLm.Width;
				bodyLm.int_15 = lineHeight;
				Class5325<Class5282> class4 = new Class5325<Class5282>(list2);
				Class5325<Class5282> class5 = new Class5325<Class5282>(list3);
				Class5282 class6 = (class4.method_0() ? class4.method_1() : null);
				Class5282 class7 = (class5.method_0() ? class5.method_1() : null);
				int num4;
				int num5;
				while (true)
				{
					num4 = class6?.Rect.Right ?? 0;
					num5 = class7?.X ?? 0;
					int num6 = num4 + num5;
					if (num6 <= 0 || num6 <= num2 - num3)
					{
						break;
					}
					int num7 = class6?.Rect.Bottom ?? 0;
					int num8 = class7?.Rect.Bottom ?? 0;
					if ((class7 == null || num7 < num8) && class6 != null)
					{
						class6 = smethod_7(class4, class6, num7, ref yOffset);
					}
					else
					{
						class7 = smethod_7(class5, class7, num8, ref yOffset);
					}
				}
				if (bodyLm.method_67())
				{
					bodyLm.X = num4;
				}
				else if (bodyLm.method_68())
				{
					bodyLm.X = ((num5 > 0) ? (num5 - num3) : (lineWidth - num3));
				}
				bodyLm.Y = yOffset;
				if (bodyLm.int_12 == -1)
				{
					bodyLm.int_12 = line;
				}
				smethod_6(bodyLm, list3, list2);
				bodyLm.Y -= follow / 2;
			}
			else if (bodyLm.Rect.Bottom > num)
			{
				smethod_6(bodyLm, list3, list2);
			}
		}
		Rectangle lineRect = new Rectangle(0, line * lineHeight, num2, (line + 1) * lineHeight);
		smethod_5(line, ref leftInset, list2, lineRect, max: true);
		smethod_5(line, ref rightInset, list3, lineRect, max: false);
	}

	private static void smethod_5(int line, ref int inset, List<Class5282> fblms, Rectangle lineRect, bool max)
	{
		foreach (Class5282 fblm in fblms)
		{
			if (lineRect.IntersectsWith(fblm.Rect))
			{
				inset = (max ? Math.Max(inset, fblm.Rect.Right) : Math.Min(inset, fblm.Rect.Left));
				if (fblm.int_12 == -1)
				{
					fblm.int_12 = line;
				}
			}
		}
	}

	private static void smethod_6(Class5282 fblm, List<Class5282> rightFblms, List<Class5282> leftFblms)
	{
		if (fblm.Height > 0)
		{
			if (fblm.method_68())
			{
				rightFblms.Add(fblm);
			}
			else if (fblm.method_67())
			{
				leftFblms.Add(fblm);
			}
		}
	}

	private static Class5282 smethod_7(Class5325<Class5282> iterator, Class5282 lm, int b, ref int yOffset)
	{
		yOffset = lm.Rect.Bottom;
		do
		{
			if (iterator.method_0())
			{
				lm = iterator.method_1();
				continue;
			}
			return null;
		}
		while (lm.Rect.Bottom <= b);
		yOffset += b;
		return lm;
	}

	private static Class5297 smethod_8(Interface173 layoutManager)
	{
		Interface173 @interface = layoutManager.imethod_2();
		if (@interface != null && !(@interface is Class5282))
		{
			if (@interface is Class5297)
			{
				return @interface as Class5297;
			}
			return smethod_8(@interface);
		}
		return null;
	}

	private static Class5282 smethod_9(Interface173 layoutManager)
	{
		Interface173 @interface = layoutManager.imethod_2();
		if (@interface == null)
		{
			return null;
		}
		if (@interface is Class5282)
		{
			return @interface as Class5282;
		}
		return smethod_9(@interface);
	}

	internal void method_65()
	{
		bool_6 = false;
		int_14 = 0;
		int_18 = 0;
		object_1 = object_0;
		bool_8 = true;
	}

	internal void method_66(int line, int lineHeight, int ignoredLine, Interface173 layoutManager)
	{
		if (Rect.Height > 0)
		{
			Class5289 @class = Class5283.smethod_2(layoutManager);
			if (@class != null && @class.IsStrartLabelList)
			{
				return;
			}
			int num = line - int_12;
			int num2 = (int)Math.Ceiling((float)Rect.Bottom / (float)lineHeight);
			int_14 += num * lineHeight;
			num = ((num2 > num) ? num : num2);
			int_18 += num;
			if (ignoredLine != -1)
			{
				int_18 = ((int_18 > ignoredLine) ? (int_18 - ignoredLine) : 0);
			}
		}
		int_12 = -1;
		KnuthListPositionMutable = 0;
	}

	internal bool method_67()
	{
		return method_69() == 135;
	}

	internal bool method_68()
	{
		return method_69() == 39;
	}

	public override void imethod_8(Class4942 childArea)
	{
		switch (((Class5095)imethod_21()).method_52())
		{
		case 13:
			childArea.method_10(Class4942.int_7);
			break;
		default:
			childArea.method_10(Class4942.int_4);
			break;
		case 39:
		case 135:
			childArea.method_10(Class4942.int_9);
			break;
		}
		imethod_2().imethod_8(childArea);
	}

	internal int method_69()
	{
		return ((Class5095)imethod_21()).method_52();
	}
}
