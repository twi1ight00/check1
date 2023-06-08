using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells.Rendering;
using Aspose.Cells.Rendering.PdfSecurity;
using ns40;

namespace ns18;

internal class Class1448
{
	private static bool bool_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private Enum207 enum207_0 = Enum207.const_3;

	private Enum208 enum208_0 = Enum208.const_3;

	private int int_0 = 50;

	private bool bool_1;

	private PdfBookmarkEntry pdfBookmarkEntry_0;

	private static readonly Hashtable hashtable_0;

	private static readonly Hashtable hashtable_1;

	private PdfCompliance pdfCompliance_0;

	private Class945 class945_0;

	private PdfSecurityOptions pdfSecurityOptions_0;

	private bool bool_2 = true;

	internal PdfBookmarkEntry Bookmark
	{
		get
		{
			return pdfBookmarkEntry_0;
		}
		set
		{
			pdfBookmarkEntry_0 = value;
		}
	}

	internal PdfCompliance Compliance
	{
		get
		{
			return pdfCompliance_0;
		}
		set
		{
			pdfCompliance_0 = value;
		}
	}

	internal PdfSecurityOptions SecurityOptions
	{
		get
		{
			return pdfSecurityOptions_0;
		}
		set
		{
			pdfSecurityOptions_0 = value;
			if (value != null)
			{
				Compliance = PdfCompliance.None;
			}
		}
	}

	internal Class1448()
	{
	}

	[SpecialName]
	public static bool smethod_0()
	{
		return bool_0;
	}

	[SpecialName]
	internal void method_0(Enum207 enum207_1)
	{
		enum207_0 = enum207_1;
	}

	[SpecialName]
	internal Enum208 method_1()
	{
		return enum208_0;
	}

	[SpecialName]
	internal void method_2(Enum208 enum208_1)
	{
		enum208_0 = enum208_1;
	}

	[SpecialName]
	internal int method_3()
	{
		return int_0;
	}

	[SpecialName]
	internal bool method_4()
	{
		switch (enum208_0)
		{
		default:
			return false;
		case Enum208.const_4:
		case Enum208.const_5:
		case Enum208.const_6:
			return true;
		}
	}

	internal Enum205 method_5()
	{
		return (Enum205)hashtable_0[enum207_0];
	}

	internal Enum205 method_6()
	{
		return (Enum205)hashtable_1[enum208_0];
	}

	[SpecialName]
	internal bool method_7()
	{
		return bool_1;
	}

	static Class1448()
	{
		bool_0 = false;
		hashtable_0 = new Hashtable();
		hashtable_1 = new Hashtable();
		hashtable_0.Add(Enum207.const_0, Enum205.const_0);
		hashtable_0.Add(Enum207.const_1, Enum205.const_5);
		hashtable_0.Add(Enum207.const_2, Enum205.const_3);
		hashtable_0.Add(Enum207.const_3, Enum205.const_4);
		hashtable_1.Add(Enum208.const_0, Enum205.const_0);
		hashtable_1.Add(Enum208.const_1, Enum205.const_5);
		hashtable_1.Add(Enum208.const_2, Enum205.const_3);
		hashtable_1.Add(Enum208.const_3, Enum205.const_4);
		hashtable_1.Add(Enum208.const_4, Enum205.const_8);
		hashtable_1.Add(Enum208.const_5, Enum205.const_6);
		hashtable_1.Add(Enum208.const_6, Enum205.const_6);
	}

	[SpecialName]
	internal string method_8()
	{
		return string_0;
	}

	[SpecialName]
	internal void method_9(string string_4)
	{
		string_0 = string_4;
	}

	[SpecialName]
	internal string method_10()
	{
		return string_1;
	}

	[SpecialName]
	internal void method_11(string string_4)
	{
		string_1 = string_4;
	}

	[SpecialName]
	internal string method_12()
	{
		return string_3;
	}

	[SpecialName]
	internal void method_13(string string_4)
	{
		string_3 = string_4;
	}

	[SpecialName]
	internal string method_14()
	{
		return string_2;
	}

	[SpecialName]
	internal void method_15(string string_4)
	{
		string_2 = string_4;
	}

	[SpecialName]
	internal Class945 method_16()
	{
		return class945_0;
	}

	[SpecialName]
	internal void method_17(Class945 class945_1)
	{
		class945_0 = class945_1;
	}

	[SpecialName]
	public bool method_18()
	{
		return bool_2;
	}

	[SpecialName]
	public void method_19(bool bool_3)
	{
		bool_2 = bool_3;
	}
}
