using System.Collections;
using System.Text;

namespace ns26;

internal class Class524
{
	internal string string_0;

	internal ArrayList arrayList_0;

	internal Class524(string string_1, ArrayList arrayList_1)
	{
		string_0 = string_1;
		arrayList_0 = arrayList_1;
	}

	internal string method_0(Hashtable hashtable_0)
	{
		if (arrayList_0 != null && arrayList_0.Count != 0)
		{
			string text = null;
			string text2 = null;
			string text3 = null;
			int num = 0;
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				Class1494 @class = (Class1494)arrayList_0[i];
				if (@class.string_0.Equals("value()>0"))
				{
					text = ((Class524)hashtable_0[@class.string_1]).method_0(hashtable_0);
					num++;
				}
				if (@class.string_0.Equals("value()>=0"))
				{
					text = ((Class524)hashtable_0[@class.string_1]).method_0(hashtable_0);
					num += 2;
				}
				else if (@class.string_0.Equals("value()<0"))
				{
					text2 = ((Class524)hashtable_0[@class.string_1]).method_0(hashtable_0);
					num++;
				}
				else if (@class.string_0.Equals("value()=0"))
				{
					text3 = ((Class524)hashtable_0[@class.string_1]).method_0(hashtable_0);
					num++;
				}
			}
			StringBuilder stringBuilder = new StringBuilder();
			if (text != null)
			{
				stringBuilder.Append(text);
			}
			if (text2 != null)
			{
				if (stringBuilder.Length != 0)
				{
					stringBuilder.Append(';');
				}
				stringBuilder.Append(text2);
			}
			if (text3 != null)
			{
				if (stringBuilder.Length != 0)
				{
					stringBuilder.Append(';');
				}
				stringBuilder.Append(text3);
			}
			if (stringBuilder.Length != 0)
			{
				stringBuilder.Append(';');
			}
			if (num < 3)
			{
				stringBuilder.Append(string_0);
			}
			else
			{
				stringBuilder.Append('@');
			}
			string_0 = stringBuilder.ToString();
			arrayList_0 = null;
			return string_0;
		}
		return string_0;
	}
}
