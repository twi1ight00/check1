using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using Aspose.Cells.Pivot;
using ns12;

namespace ns45;

internal class Class1148
{
	internal Class1141 class1141_0;

	private int int_0;

	internal string string_0;

	private string string_1;

	internal byte[] byte_0;

	internal Class1169 class1169_0;

	internal int int_1 = -1;

	internal Class1171 class1171_0;

	[SpecialName]
	internal int method_0()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_1(int int_2)
	{
		int_0 = int_2;
	}

	internal void SetFormula(int int_2, string string_2)
	{
		WorksheetCollection worksheetCollection_ = class1141_0.class1142_0.worksheetCollection_0;
		worksheetCollection_.method_3(this);
		int_0 = int_2;
		byte_0 = worksheetCollection_.Formula.method_3(string_2, 0, 0, Enum226.const_0, Enum227.const_1, bool_0: false, bool_1: false);
		worksheetCollection_.method_3(null);
		string_1 = string_2;
	}

	internal string method_2(int int_2, int int_3)
	{
		Class1141 @class = class1141_0;
		Class1161 class2 = (Class1161)@class.arrayList_0[method_0()];
		Class1169 class3 = class1169_0;
		Class1166 class4 = class3[int_2];
		Class1158 class5 = (Class1158)class2.arrayList_0[class4.method_1()[0].ushort_1];
		object object_ = class5.object_0;
		string text = "";
		text = ((object_ != null) ? object_.ToString() : "(Blank)");
		if (Class1660.smethod_6(text))
		{
			text = '\'' + text + '\'';
		}
		if (int_3 == 1)
		{
			string text2 = class2.string_0;
			if (Class1660.smethod_6(text2))
			{
				text2 = '\'' + text2 + '\'';
			}
			return text2 + "[" + text + "]";
		}
		return text;
	}

	internal int method_3(string string_2)
	{
		string text = string_2.ToUpper();
		if (text[text.Length - 1] == ']')
		{
			int num = text.LastIndexOf('[');
			if (num != -1)
			{
				text = text.Substring(num + 1, text.Length - 2 - num);
			}
		}
		if (text != null && text[0] == '\'')
		{
			text = text.Substring(1, text.Length - 2);
		}
		Class1141 @class = class1141_0;
		Class1169 class2 = class1169_0;
		int num2 = -1;
		Class1161 class3 = (Class1161)@class.arrayList_0[method_0()];
		if (class3 != null)
		{
			ArrayList arrayList_ = class3.arrayList_0;
			for (int i = 0; i < arrayList_.Count; i++)
			{
				string text2 = ((((Class1158)arrayList_[i]).object_0 != null) ? ((Class1158)arrayList_[i]).object_0.ToString().ToUpper() : "(BLANK)");
				if (!text2.Equals(text))
				{
					continue;
				}
				for (int j = 0; j < class2.Count; j++)
				{
					Class1166 class4 = class2[j];
					for (int k = 0; k < class4.method_1().Count; k++)
					{
						Class1167 class5 = class4.method_1()[k];
						if (class5.ushort_1 == i)
						{
							num2 = j;
							break;
						}
					}
					if (num2 != -1)
					{
						break;
					}
				}
				if (num2 == -1)
				{
					num2 = class2.Count;
					class2.Add(new Class1166(method_0(), i));
				}
				break;
			}
		}
		return num2;
	}

	[SpecialName]
	public string method_4()
	{
		try
		{
			if (byte_0 == null)
			{
				return string_1;
			}
			WorksheetCollection worksheetCollection_ = class1141_0.class1142_0.worksheetCollection_0;
			worksheetCollection_.method_3(this);
			string result = worksheetCollection_.method_4().method_3(0, byte_0, 0, 0, bool_0: false);
			worksheetCollection_.method_3(null);
			return result;
		}
		catch
		{
			return string_1;
		}
	}

	internal void SetFormula(string string_2)
	{
		string_1 = string_2;
	}

	internal string method_5()
	{
		return string_1;
	}

	internal Class1148(Class1141 class1141_1, PivotField pivotField_0, string string_2, string string_3, PivotFieldType pivotFieldType_0, int int_2)
	{
		class1141_0 = class1141_1;
		class1169_0 = new Class1169();
		int_0 = pivotField_0.BaseIndex;
		class1171_0 = new Class1171();
		class1171_0.byte_0 = (byte)pivotField_0.Position;
		Class1162 @class = new Class1162();
		class1171_0.arrayList_0.Add(@class);
		switch (pivotFieldType_0)
		{
		case PivotFieldType.Column:
			@class.ushort_0 = 2;
			break;
		case PivotFieldType.Row:
			@class.ushort_0 = 0;
			break;
		}
		@class.ushort_1 = (ushort)((uint)method_0() | 0x400u);
		@class.Function = 1;
		@class.arrayList_0 = new ArrayList();
		@class.arrayList_0.Add(int_2);
		string_0 = string_2;
	}

	internal Class1148(Class1141 class1141_1)
	{
		class1141_0 = class1141_1;
		class1171_0 = new Class1171();
		class1169_0 = new Class1169();
		Class1162 @class = new Class1162();
		class1171_0.arrayList_0.Add(@class);
		@class.ushort_1 = (ushort)((uint)method_0() | 0x400u);
		@class.Function = 1;
	}
}
