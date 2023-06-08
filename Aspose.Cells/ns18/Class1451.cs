using System;
using System.Collections;
using System.Drawing;
using ns22;

namespace ns18;

internal class Class1451
{
	private Class1440 class1440_0;

	private SortedList sortedList_0 = new SortedList();

	private SortedList sortedList_1 = new SortedList();

	private SortedList sortedList_2 = new SortedList();

	private SortedList sortedList_3 = new SortedList();

	private SortedList sortedList_4 = new SortedList();

	private Hashtable hashtable_0 = new Hashtable();

	private static Hashtable hashtable_1;

	internal Class1451(Class1440 class1440_1)
	{
		class1440_0 = class1440_1;
	}

	internal int method_0(Enum209 enum209_0)
	{
		return method_11(enum209_0).Count;
	}

	internal Class954 method_1(string string_0, FontStyle fontStyle_0, bool bool_0)
	{
		string key = smethod_2(string_0, fontStyle_0, bool_0);
		SortedList sortedList = method_11(Enum209.const_1);
		Class954 @class = (Class954)sortedList[key];
		if (@class == null)
		{
			@class = Class954.smethod_0(class1440_0, string_0, fontStyle_0, bool_0);
			sortedList.Add(key, @class);
		}
		return @class;
	}

	internal Class948 method_2(Brush brush_0)
	{
		Class1199 @class = brush_0 as Class1199;
		Class948 class2 = null;
		if (@class != null)
		{
			class2 = new Class948(class1440_0, @class);
			SortedList sortedList = method_11(Enum209.const_5);
			sortedList.Add(class2.method_3(), class2);
			return class2;
		}
		return null;
	}

	internal Class943 method_3(Brush brush_0)
	{
		Class943 @class = Class943.smethod_0(brush_0, class1440_0);
		SortedList sortedList = method_11(Enum209.const_2);
		sortedList.Add(@class.method_3(), @class);
		return @class;
	}

	internal Class953 method_4()
	{
		Class953 @class = new Class953(class1440_0);
		SortedList sortedList = method_11(Enum209.const_3);
		sortedList.Add(@class.method_3(), @class);
		return @class;
	}

	internal Class942 method_5(Class1201 class1201_0)
	{
		SortedList sortedList = method_11(Enum209.const_4);
		Class942 @class = new Class942(class1440_0, class1201_0);
		sortedList.Add(@class.method_3(), @class);
		return @class;
	}

	internal Class942 method_6(Class1201 class1201_0, long long_0)
	{
		SortedList sortedList = method_11(Enum209.const_4);
		if (!hashtable_0.ContainsKey(long_0))
		{
			Class942 @class = new Class942(class1440_0, class1201_0);
			hashtable_0[long_0] = @class;
			sortedList.Add(@class.method_3(), @class);
			return @class;
		}
		return (Class942)hashtable_0[long_0];
	}

	internal void method_7(Class1447 class1447_0)
	{
		method_9(Enum209.const_1, class1447_0);
		method_9(Enum209.const_5, class1447_0);
		method_9(Enum209.const_2, class1447_0);
		method_9(Enum209.const_3, class1447_0);
		method_9(Enum209.const_4, class1447_0);
	}

	internal void method_8(Class1447 class1447_0)
	{
		method_10(Enum209.const_1, class1447_0);
		method_10(Enum209.const_5, class1447_0);
		method_10(Enum209.const_2, class1447_0);
		method_10(Enum209.const_3, class1447_0);
		method_10(Enum209.const_4, class1447_0);
	}

	private void method_9(Enum209 enum209_0, Class1447 class1447_0)
	{
		SortedList sortedList = method_11(enum209_0);
		if (sortedList.Count == 0)
		{
			return;
		}
		class1447_0.Write("/{0}", smethod_0(enum209_0));
		class1447_0.method_9();
		foreach (DictionaryEntry item in sortedList)
		{
			Class938 @class = (Class938)item.Value;
			class1447_0.method_11($"/{@class.method_3()}", @class.method_1());
		}
		class1447_0.method_10();
	}

	private void method_10(Enum209 enum209_0, Class1447 class1447_0)
	{
		SortedList sortedList = method_11(enum209_0);
		if (sortedList.Count == 0)
		{
			return;
		}
		foreach (DictionaryEntry item in sortedList)
		{
			Class938 @class = (Class938)item.Value;
			@class.vmethod_1(class1447_0);
		}
	}

	internal static string smethod_0(Enum209 enum209_0)
	{
		return ((Struct75)hashtable_1[enum209_0]).string_0;
	}

	internal static string smethod_1(Enum209 enum209_0)
	{
		return ((Struct75)hashtable_1[enum209_0]).string_1;
	}

	private static string smethod_2(string string_0, FontStyle fontStyle_0, bool bool_0)
	{
		return $"{string_0}{(int)fontStyle_0}{bool_0}";
	}

	[Attribute0(true)]
	private SortedList method_11(Enum209 enum209_0)
	{
		return enum209_0 switch
		{
			Enum209.const_1 => sortedList_0, 
			Enum209.const_2 => sortedList_1, 
			Enum209.const_3 => sortedList_2, 
			Enum209.const_4 => sortedList_3, 
			Enum209.const_5 => sortedList_4, 
			_ => throw new Exception("Unknown resource type."), 
		};
	}

	static Class1451()
	{
		hashtable_1 = new Hashtable();
		hashtable_1.Add(Enum209.const_1, new Struct75("Font", "F"));
		hashtable_1.Add(Enum209.const_2, new Struct75("Pattern", "P"));
		hashtable_1.Add(Enum209.const_3, new Struct75("ExtGState", "GS"));
		hashtable_1.Add(Enum209.const_4, new Struct75("XObject", "X"));
		hashtable_1.Add(Enum209.const_5, new Struct75("Shading", "Sh"));
	}
}
