using System.Collections;
using Aspose.Words;
using Aspose.Words.Lists;
using xd2754ae26d400653;

namespace x13cd31bb39e0b7ea;

internal class x81e499fc7c476682
{
	private readonly IWarningCallback xa056586c1f99e199;

	private readonly ListCollection xbc2e79ef0cee7243;

	private readonly bool x944e17c2480d8678;

	private bool xd9f65aa023cd14c8
	{
		get
		{
			if (xbc2e79ef0cee7243.xddf1da3d36406847 == 0)
			{
				return true;
			}
			int num = int.MinValue;
			for (int i = 0; i < xbc2e79ef0cee7243.xc40f91140312b303.Count; i++)
			{
				x178ff6dcbf808c38 x178ff6dcbf808c = (x178ff6dcbf808c38)xbc2e79ef0cee7243.xc40f91140312b303[i];
				if (x178ff6dcbf808c.x1eac770549050632 <= num)
				{
					return false;
				}
				num = x178ff6dcbf808c.x1eac770549050632;
			}
			return true;
		}
	}

	private bool x249ed2eba0136fc4
	{
		get
		{
			if (xbc2e79ef0cee7243.Count == 0)
			{
				return false;
			}
			foreach (DictionaryEntry item in xbc2e79ef0cee7243.xb17de0643f715f73)
			{
				if ((int)item.Key != (int)item.Value)
				{
					return true;
				}
			}
			return (int)xbc2e79ef0cee7243.xb17de0643f715f73[1] != 1;
		}
	}

	internal x81e499fc7c476682(ListCollection lists, IWarningCallback warningCallback)
	{
		xbc2e79ef0cee7243 = lists;
		x944e17c2480d8678 = x249ed2eba0136fc4;
		xa056586c1f99e199 = warningCallback;
	}

	internal void x648a8aa88d1bbe19()
	{
		if (x944e17c2480d8678)
		{
			for (int i = 0; i < xbc2e79ef0cee7243.Count; i++)
			{
				xbc2e79ef0cee7243[i].xd01d085303c8ed31(i + 1);
			}
			xbc2e79ef0cee7243.xb17de0643f715f73.Clear();
			for (int j = 0; j < xbc2e79ef0cee7243.Count; j++)
			{
				xbc2e79ef0cee7243.xb17de0643f715f73.Add(j + 1, j + 1);
			}
		}
		Hashtable hashtable = new Hashtable();
		int num = 0;
		while (num < xbc2e79ef0cee7243.xc40f91140312b303.Count)
		{
			x178ff6dcbf808c38 x178ff6dcbf808c = (x178ff6dcbf808c38)xbc2e79ef0cee7243.xc40f91140312b303[num];
			if (hashtable[x178ff6dcbf808c.x1eac770549050632] != null)
			{
				xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, "Non-unique list definition removed.");
				xbc2e79ef0cee7243.xc40f91140312b303.RemoveAt(num);
			}
			else
			{
				hashtable.Add(x178ff6dcbf808c.x1eac770549050632, x178ff6dcbf808c);
				num++;
			}
		}
		if (!xd9f65aa023cd14c8)
		{
			xbc2e79ef0cee7243.xc40f91140312b303.Sort();
		}
	}

	internal void x57a5d79d9b9d67f5(Paragraph x31e6518f5e08db6c)
	{
		if (x944e17c2480d8678)
		{
			object obj = xbc2e79ef0cee7243.xb17de0643f715f73[x31e6518f5e08db6c.x1a78664fa10a3755.x71c63f7e57f7ede5];
			if (obj != null)
			{
				x31e6518f5e08db6c.x1a78664fa10a3755.x71c63f7e57f7ede5 = (int)obj;
			}
		}
	}

	private void xbbf9a1ead81dd3a1(WarningType x9f91de645a9fe01a, string xc2358fbac7da3d45)
	{
		if (xa056586c1f99e199 != null)
		{
			xa056586c1f99e199.Warning(new WarningInfo(x9f91de645a9fe01a, WarningSource.Validator, xc2358fbac7da3d45));
		}
	}
}
