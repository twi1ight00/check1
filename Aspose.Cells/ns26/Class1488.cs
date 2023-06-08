using System.Collections;
using Aspose.Cells;

namespace ns26;

internal class Class1488
{
	internal int int_0;

	internal int int_1;

	internal double double_0;

	internal bool bool_0;

	internal string string_0;

	internal int int_2;

	internal Hashtable hashtable_0;

	internal int int_3;

	internal string string_1;

	internal Class1488()
	{
		hashtable_0 = new Hashtable();
		int_2 = -1;
	}

	internal void Copy(Class1488 class1488_0)
	{
		double_0 = class1488_0.double_0;
		bool_0 = class1488_0.bool_0;
		string_0 = class1488_0.string_0;
		int_2 = class1488_0.int_2;
		int_3 = class1488_0.int_3;
		string_1 = class1488_0.string_1;
	}

	internal void method_0(Class1489 class1489_0, int int_4)
	{
		int num = 0;
		string text = null;
		if (hashtable_0 != null && hashtable_0.Count != 0)
		{
			bool flag = false;
			IEnumerator enumerator = hashtable_0.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string text2 = (string)enumerator.Current;
				int num2 = (int)hashtable_0[text2];
				if (text2.ToLower() == "default")
				{
					num2 += 65535 - int_4 + 1;
					flag = true;
				}
				if (num < num2)
				{
					text = text2;
					num = num2;
				}
			}
			if (!flag && num < 65535 - int_4 + 1)
			{
				text = class1489_0.string_0;
			}
			if (text != null)
			{
				if (text.ToLower() == "default")
				{
					text = class1489_0.string_0;
				}
				if (class1489_0.hashtable_0[text] != null)
				{
					object obj = class1489_0.hashtable_0[text];
					Style style = class1489_0.workbook_0.Worksheets.method_58()[(int)obj];
					if (style.Name != null && style.Name != "")
					{
						int_3 = class1489_0.workbook_0.Worksheets.method_58().method_1(style, (int)obj);
					}
					else
					{
						int_3 = (int)obj;
					}
					string_1 = text;
				}
				else
				{
					int_3 = -1;
					string_1 = null;
				}
			}
			else
			{
				int_3 = -1;
				string_1 = null;
			}
		}
		else
		{
			int_3 = -1;
			string_1 = null;
		}
		hashtable_0 = null;
	}
}
