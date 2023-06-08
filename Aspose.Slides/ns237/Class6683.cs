using System;
using System.Collections;
using System.Drawing;
using ns218;
using ns224;
using ns233;

namespace ns237;

internal class Class6683
{
	private readonly Class6672 class6672_0;

	private readonly SortedList sortedList_0 = new Class5968();

	private readonly SortedList sortedList_1 = new Class5968();

	private readonly SortedList sortedList_2 = new Class5968();

	private readonly SortedList sortedList_3 = new SortedList();

	private readonly Class6553 class6553_0 = new Class6553();

	private static readonly Hashtable hashtable_0;

	internal Class6683(Class6672 context)
	{
		class6672_0 = context;
	}

	internal int GetCount(Enum892 type)
	{
		return method_8(type).Count;
	}

	internal Class6527 method_0(string key)
	{
		return (Class6527)sortedList_0[key];
	}

	internal Class6527 method_1(Class5999 font, bool isComposite, Enum872 embeddingRule)
	{
		Enum873 fontType = (font.TrueTypeFont.IsCff ? ((!font.TrueTypeFont.IsCffTopDict) ? Enum873.const_1 : Enum873.const_0) : ((!isComposite) ? Enum873.const_3 : Enum873.const_2));
		string key = smethod_0(font.FamilyName, font.Style, fontType);
		Class6527 @class = (Class6527)sortedList_0[key];
		if (@class == null)
		{
			@class = Class6527.smethod_0(class6672_0, font.Style, font.TrueTypeFont, fontType, embeddingRule);
			sortedList_0[key] = @class;
		}
		return @class;
	}

	private static string smethod_0(string familyName, FontStyle style, Enum873 fontType)
	{
		return $"{familyName}-{(int)style}-{(int)fontType}";
	}

	internal Class6525 method_2(Class5990 brush)
	{
		Class6525 @class;
		if (Class6553.smethod_0(brush))
		{
			if (!class6553_0.Contains(brush))
			{
				@class = Class6525.smethod_0(brush, class6672_0);
				sortedList_1[@class.ResourceName] = @class;
				class6553_0.Add(brush, @class);
			}
			else
			{
				@class = class6553_0.method_0(brush);
			}
		}
		else
		{
			@class = Class6525.smethod_0(brush, class6672_0);
			sortedList_1[@class.ResourceName] = @class;
		}
		return @class;
	}

	internal Class6542 method_3()
	{
		Class6542 @class = new Class6542(class6672_0);
		sortedList_2[@class.ResourceName] = @class;
		return @class;
	}

	internal Class6521 method_4(byte[] imageBytes, Class6145 crop, Class6140 chromaKey)
	{
		int num = Class6145.smethod_2(imageBytes, crop, chromaKey);
		Class6521 @class = (Class6521)class6672_0.Resources.sortedList_3[num];
		if (@class == null)
		{
			@class = new Class6521(class6672_0, imageBytes, crop, chromaKey);
			class6672_0.Resources.sortedList_3[num] = @class;
		}
		sortedList_3[num] = @class;
		return @class;
	}

	internal void method_5(Class6679 writer)
	{
		method_7(Enum892.const_1, writer);
		method_7(Enum892.const_2, writer);
		method_7(Enum892.const_3, writer);
		method_7(Enum892.const_4, writer);
	}

	internal void method_6(Class6679 writer)
	{
		smethod_1(sortedList_0, writer);
		smethod_1(sortedList_1, writer);
		smethod_1(sortedList_2, writer);
		smethod_1(sortedList_3, writer);
	}

	private void method_7(Enum892 type, Class6679 writer)
	{
		SortedList sortedList = method_8(type);
		if (sortedList.Count == 0)
		{
			return;
		}
		writer.Write("/{0}", smethod_2(type));
		writer.method_6();
		foreach (object value in sortedList.GetValueList())
		{
			Class6511 @class = (Class6511)value;
			writer.method_8($"/{@class.ResourceName}", @class.IndirectReference);
		}
		writer.method_7();
	}

	private static void smethod_1(SortedList resources, Class6679 writer)
	{
		if (resources.Count == 0)
		{
			return;
		}
		foreach (object value in resources.GetValueList())
		{
			Class6511 @class = (Class6511)value;
			@class.vmethod_0(writer);
		}
	}

	internal static string smethod_2(Enum892 type)
	{
		return ((Class6671)hashtable_0[type]).string_0;
	}

	internal static string smethod_3(Enum892 type)
	{
		return ((Class6671)hashtable_0[type]).string_1;
	}

	private SortedList method_8(Enum892 type)
	{
		return type switch
		{
			Enum892.const_1 => sortedList_0, 
			Enum892.const_2 => sortedList_1, 
			Enum892.const_3 => sortedList_2, 
			Enum892.const_4 => sortedList_3, 
			_ => throw new InvalidOperationException("Unknown resource type."), 
		};
	}

	static Class6683()
	{
		hashtable_0 = new Hashtable();
		hashtable_0.Add(Enum892.const_1, new Class6671("Font", "F"));
		hashtable_0.Add(Enum892.const_2, new Class6671("Pattern", "P"));
		hashtable_0.Add(Enum892.const_3, new Class6671("ExtGState", "GS"));
		hashtable_0.Add(Enum892.const_4, new Class6671("XObject", "X"));
	}
}
