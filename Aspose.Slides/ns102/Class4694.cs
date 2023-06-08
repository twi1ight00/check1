using System.Collections;
using ns154;

namespace ns102;

internal class Class4694
{
	private Hashtable hashtable_0;

	private object object_0 = new object();

	internal Class4694()
	{
		hashtable_0 = new Hashtable();
	}

	public void method_0(string fontName, string[] encoding)
	{
		if (hashtable_0.ContainsKey(fontName))
		{
			return;
		}
		lock (object_0)
		{
			if (!hashtable_0.ContainsKey(fontName))
			{
				Class4716 @class = new Class4716();
				for (int i = 0; i < encoding.Length; i++)
				{
					@class.Add(i, encoding[i]);
				}
				hashtable_0.Add(fontName, @class);
			}
		}
	}

	internal Class4716 method_1(string fontName)
	{
		if (hashtable_0.ContainsKey(fontName))
		{
			return (Class4716)hashtable_0[fontName];
		}
		return null;
	}
}
