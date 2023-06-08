using System.Text;

namespace xce0136f05681c5e9;

internal class xbaf8b2953ab3e261
{
	private readonly StringBuilder xf8725102f8a24d56 = new StringBuilder();

	private string xed4a7b1500064e12;

	private int xcc1f166f114798b7;

	private int x56e600641e398ff3;

	internal string x83793d947b8211ad(string xb41faee6912a2313)
	{
		xf8725102f8a24d56.Length = 0;
		xed4a7b1500064e12 = xb41faee6912a2313;
		x56e600641e398ff3 = 0;
		bool flag = false;
		for (xcc1f166f114798b7 = 0; xcc1f166f114798b7 < xb41faee6912a2313.Length; xcc1f166f114798b7++)
		{
			if (xb41faee6912a2313[xcc1f166f114798b7] == ' ')
			{
				if (!flag)
				{
					flag = true;
					x56e600641e398ff3 = xcc1f166f114798b7;
				}
			}
			else if (flag)
			{
				x4f07c0f732805b24();
				flag = false;
			}
		}
		if (flag)
		{
			x4f07c0f732805b24();
		}
		if (xf8725102f8a24d56.Length > 0)
		{
			return xf8725102f8a24d56.ToString();
		}
		return xb41faee6912a2313;
	}

	private void x4f07c0f732805b24()
	{
		int num = xcc1f166f114798b7 - x56e600641e398ff3;
		if (num > 1)
		{
			if (xf8725102f8a24d56.Length == 0)
			{
				xf8725102f8a24d56.Append(xed4a7b1500064e12);
			}
			int num2 = num - 1;
			for (int i = 0; i < num2; i++)
			{
				xf8725102f8a24d56[x56e600641e398ff3 + i] = '\u00a0';
			}
		}
	}
}
