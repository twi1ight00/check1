using System.Collections;
using Aspose.Cells;
using ns2;
using ns22;

namespace ns16;

internal class Class1539
{
	internal ArrayList arrayList_0 = new ArrayList();

	internal ArrayList arrayList_1 = new ArrayList();

	internal ArrayList arrayList_2 = new ArrayList();

	internal ArrayList arrayList_3 = new ArrayList();

	internal ArrayList arrayList_4 = new ArrayList();

	internal Hashtable hashtable_0 = new Hashtable();

	internal Hashtable hashtable_1 = new Hashtable();

	private Class1540 class1540_0;

	internal static Class1539 smethod_0(Class1540 class1540_1)
	{
		Class1539 @class = new Class1539();
		@class.class1540_0 = class1540_1;
		@class.method_0();
		@class.method_1();
		Class1683 class2 = class1540_1.workbook_0.Worksheets.method_58();
		Style style = class2[0];
		style.method_11(bool_0: false);
		@class.method_2(style, 0);
		style = class2[15];
		style.method_11(bool_0: true);
		@class.method_2(style, 15);
		for (int i = 1; i < class2.Count; i++)
		{
			if (i != 15)
			{
				style = class2[i];
				@class.method_2(style, i);
			}
		}
		return @class;
	}

	internal void method_0()
	{
		Class1535 @class = new Class1535();
		@class.class1561_0 = new Class1561();
		@class.class1561_0.string_0 = "none";
		@class.int_0 = arrayList_0.Add(@class);
		Class1535 class2 = new Class1535();
		class2.class1561_0 = new Class1561();
		class2.class1561_0.string_0 = "gray125";
		class2.int_0 = arrayList_0.Add(class2);
	}

	internal void method_1()
	{
		Class1526 @class = new Class1526();
		@class.class1527_1 = new Class1527();
		@class.class1527_3 = new Class1527();
		@class.class1527_0 = new Class1527();
		@class.class1527_2 = new Class1527();
		@class.class1527_4 = new Class1527();
		@class.int_0 = arrayList_1.Add(@class);
	}

	internal void method_2(Style style_0, int int_0)
	{
		Class1571 @class = new Class1571();
		@class.style_0 = style_0;
		@class.bool_0 = style_0.method_10();
		if (style_0.method_44() != -1 && style_0.method_44() != 0)
		{
			@class.bool_2 = true;
		}
		@class.int_1 = (short)style_0.method_44();
		if (style_0.method_40() != null)
		{
			@class.int_2 = (short)style_0.Font.method_21();
			@class.bool_3 = true;
		}
		if (style_0.Pattern != 0 || style_0.IsGradient)
		{
			@class.int_3 = method_4(style_0);
			@class.bool_4 = true;
		}
		if (style_0.method_4() != null)
		{
			@class.int_4 = method_5(style_0);
			@class.bool_5 = true;
		}
		@class.class1525_0 = Class1525.smethod_0(style_0);
		if (@class.class1525_0 != null)
		{
			@class.bool_6 = true;
		}
		@class.class1563_0 = Class1563.smethod_0(style_0);
		if (@class.class1563_0 != null)
		{
			@class.bool_7 = true;
		}
		@class.int_6 = (short)int_0;
		if (!style_0.method_10())
		{
			int num = (@class.int_0 = arrayList_2.Add(@class));
			hashtable_1.Add(int_0, num);
			if (int_0 == 0)
			{
				method_3(style_0, "Normal", @class.int_0);
			}
			else if (style_0.Name != null)
			{
				method_3(style_0, style_0.Name, @class.int_0);
			}
		}
		else
		{
			if (style_0.method_12() != 0 && hashtable_1.ContainsKey(style_0.method_12()))
			{
				@class.int_5 = Class1179.smethod_4((int)hashtable_1[style_0.method_12()]);
			}
			int num2 = (@class.int_0 = arrayList_3.Add(@class));
			if (class1540_0.bool_1)
			{
				hashtable_0.Add(int_0, Class1618.smethod_80(num2));
			}
			else
			{
				hashtable_0.Add(int_0, num2);
			}
		}
	}

	internal void method_3(Style style_0, string string_0, int int_0)
	{
		Class1529 @class = new Class1529();
		@class.string_0 = string_0;
		@class.int_0 = int_0;
		arrayList_4.Add(@class);
	}

	private short method_4(Style style_0)
	{
		if (style_0.Pattern == BackgroundType.None && !style_0.IsGradient)
		{
			return 0;
		}
		Class1535 @class = Class1535.smethod_0(style_0);
		int num = 0;
		Class1535 class2;
		while (true)
		{
			if (num < arrayList_0.Count)
			{
				class2 = (Class1535)arrayList_0[num];
				if (Class1535.smethod_1(@class, class2))
				{
					break;
				}
				num++;
				continue;
			}
			return (short)(@class.int_0 = arrayList_0.Add(@class));
		}
		return (short)class2.int_0;
	}

	private short method_5(Style style_0)
	{
		if (!style_0.method_9())
		{
			return 0;
		}
		Class1526 @class = Class1526.smethod_0(style_0);
		int num = 0;
		Class1526 class2;
		while (true)
		{
			if (num < arrayList_1.Count)
			{
				class2 = (Class1526)arrayList_1[num];
				if (Class1526.smethod_1(@class, class2))
				{
					break;
				}
				num++;
				continue;
			}
			return (short)(@class.int_0 = arrayList_1.Add(@class));
		}
		return (short)class2.int_0;
	}
}
