using System.Collections;
using System.Text;

namespace ns8;

internal class Class727 : Class726
{
	private ArrayList arrayList_1;

	public Class727()
	{
		arrayList_1 = new ArrayList();
	}

	private string method_11()
	{
		StringBuilder stringBuilder = new StringBuilder();
		method_1();
		while (!method_2())
		{
			if (method_10() == '/')
			{
				method_7();
				if (method_10() != '*')
				{
					continue;
				}
				method_7();
				while (!method_2())
				{
					if (method_10() == '*')
					{
						method_7();
						if (method_10() == '/')
						{
							method_7();
							break;
						}
						method_7();
					}
					else
					{
						method_7();
					}
				}
			}
			else if (method_10() != '.' && method_10() != 0 && method_10() != '\r' && method_10() != '\n' && method_10() != '\t')
			{
				if (method_10() == '{')
				{
					method_7();
					break;
				}
				stringBuilder.Append(method_10());
				method_7();
			}
			else
			{
				method_7();
			}
		}
		method_1();
		return stringBuilder.ToString().Trim();
	}

	public ArrayList method_12()
	{
		while (!method_2())
		{
			string text = method_11();
			if (text.Equals(""))
			{
				break;
			}
			if (method_10() == '}')
			{
				method_7();
				continue;
			}
			Class726 @class = new Class726(text);
			string text2 = method_3();
			string text3 = method_4();
			while (text2 != null && text3 != null)
			{
				@class.method_5(text2, text3);
				method_1();
				if (method_10() != '}')
				{
					text2 = method_3();
					text3 = method_4();
					continue;
				}
				method_7();
				break;
			}
			arrayList_1.Add(@class);
		}
		method_14();
		return arrayList_1;
	}

	private ArrayList method_13(string string_3)
	{
		foreach (Class726 item in arrayList_1)
		{
			if (item.method_9().Equals(string_3))
			{
				return item.method_0();
			}
		}
		return null;
	}

	public void method_14()
	{
		foreach (Class726 item in arrayList_1)
		{
			ArrayList arrayList = new ArrayList();
			arrayList = (ArrayList)item.method_0().Clone();
			foreach (Class724 item2 in arrayList)
			{
				if (item2.Name.Equals("mso-style-parent"))
				{
					item.method_0().Remove(item2);
					ArrayList arrayList2 = new ArrayList();
					arrayList2 = ((item.method_9().Equals("td") || !item2.Value.Equals("style0")) ? method_13(item2.Value) : method_13("td"));
					if (arrayList2 != null)
					{
						item.method_0().InsertRange(0, arrayList2);
					}
				}
			}
		}
	}
}
