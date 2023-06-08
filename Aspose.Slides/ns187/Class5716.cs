using System.Collections;
using ns171;
using ns176;
using ns184;
using ns195;

namespace ns187;

internal class Class5716
{
	private static Class5749 class5749_0 = new Class5749();

	private int int_0 = -1;

	private Class5030 class5030_0;

	private Class5042 class5042_0;

	private Class5042 class5042_1;

	private Class5042 class5042_2;

	private Class5042 class5042_3;

	private Class5042 class5042_4;

	public Interface182 interface182_0;

	public Interface181 interface181_0;

	private Class5716(Class5030 fontFamily, Class5042 fontSelectionStrategy, Class5042 fontStretch, Class5042 fontStyle, Class5042 fontVariant, Class5042 fontWeight, Interface182 fontSize, Interface181 fontSizeAdjust)
	{
		class5030_0 = fontFamily;
		class5042_0 = fontSelectionStrategy;
		class5042_1 = fontStretch;
		class5042_2 = fontStyle;
		class5042_3 = fontVariant;
		class5042_4 = fontWeight;
		interface182_0 = fontSize;
		interface181_0 = fontSizeAdjust;
	}

	public static Class5716 smethod_0(Class5634 pList)
	{
		Class5030 fontFamily = (Class5030)pList.method_5(101);
		Class5042 fontSelectionStrategy = (Class5042)pList.method_5(102);
		Class5042 fontStretch = (Class5042)pList.method_5(105);
		Class5042 fontStyle = (Class5042)pList.method_5(106);
		Class5042 fontVariant = (Class5042)pList.method_5(107);
		Class5042 fontWeight = (Class5042)pList.method_5(108);
		Interface181 fontSizeAdjust = pList.method_5(104).vmethod_10();
		Interface182 fontSize = pList.method_5(103).vmethod_0();
		Class5716 obj = new Class5716(fontFamily, fontSelectionStrategy, fontStretch, fontStyle, fontVariant, fontWeight, fontSize, fontSizeAdjust);
		return (Class5716)class5749_0.method_0(obj);
	}

	private string[] method_0()
	{
		ArrayList arrayList = class5030_0.vmethod_8();
		string[] array = new string[arrayList.Count];
		int i = 0;
		for (int count = arrayList.Count; i < count; i++)
		{
			array[i] = ((Class5024)arrayList[i]).vmethod_13();
		}
		return array;
	}

	public string method_1()
	{
		return ((Class5024)class5030_0.arrayList_0[0]).vmethod_13();
	}

	public int method_2()
	{
		return class5042_0.imethod_0();
	}

	public int method_3()
	{
		return class5042_1.imethod_0();
	}

	public int method_4()
	{
		return class5042_2.imethod_0();
	}

	public int method_5()
	{
		return class5042_3.imethod_0();
	}

	public int method_6()
	{
		return class5042_4.imethod_0();
	}

	public Interface182 method_7()
	{
		return interface182_0;
	}

	public Interface181 method_8()
	{
		return interface181_0;
	}

	public Class5732[] method_9(Class5730 fontInfo)
	{
		int weight = (Enum679)class5042_4.imethod_0() switch
		{
			Enum679.const_256 => 100, 
			Enum679.const_257 => 200, 
			Enum679.const_258 => 300, 
			Enum679.const_259 => 400, 
			Enum679.const_260 => 500, 
			Enum679.const_261 => 600, 
			Enum679.const_262 => 700, 
			Enum679.const_263 => 800, 
			Enum679.const_264 => 900, 
			_ => 400, 
		};
		string style = (Enum679)class5042_2.imethod_0() switch
		{
			Enum679.const_251 => "italic", 
			Enum679.const_252 => "oblique", 
			Enum679.const_253 => "backslant", 
			_ => "normal", 
		};
		int fontVariant = class5042_3.imethod_0();
		return fontInfo.method_16(method_0(), style, weight, fontVariant);
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is Class5716 @class))
		{
			return false;
		}
		if (Class5721.smethod_0(class5030_0, @class.class5030_0) && Class5721.smethod_0(class5042_0, @class.class5042_0) && Class5721.smethod_0(interface182_0, @class.interface182_0) && Class5721.smethod_0(interface181_0, @class.interface181_0) && Class5721.smethod_0(class5042_1, @class.class5042_1) && Class5721.smethod_0(class5042_2, @class.class5042_2) && Class5721.smethod_0(class5042_3, @class.class5042_3))
		{
			return Class5721.smethod_0(class5042_4, @class.class5042_4);
		}
		return false;
	}

	public int method_10()
	{
		if (int_0 == -1)
		{
			int num = 17;
			num = 629 + Class5721.smethod_1(interface182_0);
			num = 37 * num + Class5721.smethod_1(interface181_0);
			num = 37 * num + Class5721.smethod_1(class5030_0);
			num = 37 * num + Class5721.smethod_1(class5042_0);
			num = 37 * num + Class5721.smethod_1(class5042_1);
			num = 37 * num + Class5721.smethod_1(class5042_2);
			num = 37 * num + Class5721.smethod_1(class5042_3);
			num = 37 * num + Class5721.smethod_1(class5042_4);
			int_0 = num;
		}
		return int_0;
	}
}
