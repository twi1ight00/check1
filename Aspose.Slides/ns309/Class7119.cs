using System;

namespace ns309;

internal class Class7119
{
	private int int_0;

	private int int_1;

	public virtual bool vmethod_0(string unicodeCSS)
	{
		if (unicodeCSS.Length == 1)
		{
			return vmethod_1(unicodeCSS[0]);
		}
		return false;
	}

	public virtual bool vmethod_1(int unicodeVal)
	{
		if (unicodeVal >= int_0)
		{
			return unicodeVal <= int_1;
		}
		return false;
	}

	public Class7119(string unicodeRange)
	{
		if (unicodeRange.StartsWith("U+") && unicodeRange.Length > 2)
		{
			unicodeRange = unicodeRange.Substring(2);
			int num = unicodeRange.IndexOf('-');
			string text;
			string text2;
			if (num != -1)
			{
				text = unicodeRange.Substring(0, num);
				text2 = unicodeRange.Substring(num + 1);
			}
			else
			{
				text = unicodeRange;
				text2 = unicodeRange;
				if (unicodeRange.IndexOf('?') != -1)
				{
					text = text.Replace('?', '0');
					text2 = text2.Replace('?', 'F');
				}
			}
			try
			{
				int_0 = Convert.ToInt32(text, 16);
				int_1 = Convert.ToInt32(text2, 16);
				return;
			}
			catch (Exception ex)
			{
				int_0 = -1;
				int_1 = -1;
				_ = ex.Message;
				return;
			}
		}
		int_0 = -1;
		int_1 = -1;
	}
}
