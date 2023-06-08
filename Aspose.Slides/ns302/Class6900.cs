using System.Collections;
using System.Globalization;
using ns301;

namespace ns302;

internal class Class6900
{
	private ArrayList arrayList_0;

	private Hashtable hashtable_0;

	internal Class6900(string text)
	{
		arrayList_0 = new ArrayList();
		hashtable_0 = new Hashtable();
		method_2(text);
	}

	internal string method_0(string name)
	{
		Class6892.smethod_0(name, "name");
		ArrayList arrayList = method_1(name);
		if (arrayList == null)
		{
			return null;
		}
		Class6899 @class = arrayList[0] as Class6899;
		return @class.string_1;
	}

	internal ArrayList method_1(string name)
	{
		if (name == null)
		{
			return arrayList_0;
		}
		return hashtable_0[name] as ArrayList;
	}

	private void method_2(string text)
	{
		arrayList_0.Clear();
		hashtable_0.Clear();
		if (text == null)
		{
			return;
		}
		string[] array = text.Split(';');
		if (array == null)
		{
			return;
		}
		foreach (string text2 in array)
		{
			if (text2.Length == 0)
			{
				continue;
			}
			string[] array2 = text2.Split(new char[1] { '=' }, 2);
			if (array2 != null)
			{
				Class6899 @class = new Class6899(array2[0].Trim().ToLower(CultureInfo.InvariantCulture));
				if (array2.Length < 2)
				{
					@class.string_1 = string.Empty;
				}
				else
				{
					@class.string_1 = array2[1];
				}
				arrayList_0.Add(@class);
				ArrayList arrayList = hashtable_0[@class.string_0] as ArrayList;
				if (arrayList == null)
				{
					arrayList = new ArrayList();
					hashtable_0[@class.string_0] = arrayList;
				}
				arrayList.Add(@class);
			}
		}
	}

	internal static string smethod_0(string text, string name)
	{
		Class6900 @class = new Class6900(text);
		return @class.method_0(name);
	}
}
