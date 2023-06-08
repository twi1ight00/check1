using System.Collections;
using ns218;

namespace ns237;

internal class Class6661
{
	private static Hashtable hashtable_0;

	private static Hashtable hashtable_1;

	private static Hashtable hashtable_2;

	private static Hashtable hashtable_3;

	internal static string smethod_0(Enum884 value)
	{
		return (string)Class5957.smethod_3(hashtable_0, value);
	}

	internal static string smethod_1(Enum889 value)
	{
		return (string)Class5957.smethod_3(hashtable_1, value);
	}

	internal static string smethod_2(Enum888 value)
	{
		return (string)Class5957.smethod_3(hashtable_2, value);
	}

	internal static string smethod_3(Enum882 value)
	{
		return (string)Class5957.smethod_3(hashtable_3, value);
	}

	private Class6661()
	{
	}

	static Class6661()
	{
		hashtable_0 = new Hashtable();
		hashtable_1 = new Hashtable();
		hashtable_2 = new Hashtable();
		hashtable_3 = new Hashtable();
		smethod_4();
		smethod_5();
		smethod_6();
		smethod_7();
	}

	private static void smethod_4()
	{
		Class5957.smethod_0(new object[10]
		{
			Enum884.const_0,
			"/MediaBox",
			Enum884.const_1,
			"/CropBox",
			Enum884.const_2,
			"/BleedBox",
			Enum884.const_4,
			"/ArtBox",
			Enum884.const_3,
			"/TrimBox"
		}, hashtable_0, null);
	}

	private static void smethod_5()
	{
		Class5957.smethod_0(new object[10]
		{
			Enum889.const_3,
			"/FullScreen",
			Enum889.const_0,
			"/UseNone",
			Enum889.const_4,
			"/UseOC",
			Enum889.const_1,
			"/UseOutlines",
			Enum889.const_2,
			"/UseThumbs"
		}, hashtable_1, null);
	}

	private static void smethod_6()
	{
		Class5957.smethod_0(new object[12]
		{
			Enum888.const_1,
			"/OneColumn",
			Enum888.const_0,
			"/SinglePage",
			Enum888.const_2,
			"/TwoColumnLeft",
			Enum888.const_3,
			"/TwoColumnRight",
			Enum888.const_4,
			"/TwoPageLeft",
			Enum888.const_5,
			"/TwoPageRight"
		}, hashtable_2, null);
	}

	private static void smethod_7()
	{
		Class5957.smethod_0(new object[8]
		{
			Enum882.const_0,
			"/Btn",
			Enum882.const_2,
			"/Ch",
			Enum882.const_3,
			"/Sig",
			Enum882.const_1,
			"/Tx"
		}, hashtable_3, null);
	}
}
