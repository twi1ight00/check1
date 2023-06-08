using System.Text;
using xa604c4d210ae0581;

namespace xaa035fc640f94856;

internal class x63a40cd184d097e5 : xc9072e4c3fa520ad
{
	internal x63a40cd184d097e5(int itemSize)
		: base(itemSize)
	{
	}

	protected void x5e3ecd9069f14784(x63a40cd184d097e5 x779599e48ff1e5c0, x63a40cd184d097e5 x0daa7f32d5e2b411)
	{
		int num = base.x23719734cf1f138c;
		for (int i = 0; i < num; i++)
		{
			int num2 = xed8a0d4499d6f292(i);
			x3f476b1639f1fbe9 x3f476b1639f1fbe10 = (x3f476b1639f1fbe9)xe84e6ff66aac2a0e(i);
			x3f476b1639f1fbe10.x71e1774af0bcc655 = 0;
			for (int j = 0; j < num; j++)
			{
				xa6101120b8ed585e xa6101120b8ed585e = new xa6101120b8ed585e(x779599e48ff1e5c0.xed8a0d4499d6f292(j), x0daa7f32d5e2b411.xed8a0d4499d6f292(j));
				if (!xa6101120b8ed585e.x7149c962c02931b3() && xa6101120b8ed585e.x263d579af1d0d43f(num2))
				{
					x3f476b1639f1fbe10.x71e1774af0bcc655++;
				}
				if (xa6101120b8ed585e.x12cb12b5d2cad53d > num2)
				{
					break;
				}
			}
		}
	}

	internal void x4c9ca06a97713d57(x63a40cd184d097e5 x50a18ad2656e7181, int x03d82212f016d5f9)
	{
		int num = base.x23719734cf1f138c;
		for (int i = 0; i < x50a18ad2656e7181.x23719734cf1f138c; i++)
		{
			x3f476b1639f1fbe9 x3f476b1639f1fbe10 = (x3f476b1639f1fbe9)x50a18ad2656e7181.xe84e6ff66aac2a0e(i);
			x3f476b1639f1fbe10.x0d1e53f2c8fd6fb3 += num;
			int num2 = x50a18ad2656e7181.xed8a0d4499d6f292(i);
			xd6b6ed77479ef68c(x03d82212f016d5f9 + num2, x3f476b1639f1fbe10);
		}
	}

	internal string x37b0f9668836956c()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < base.x23719734cf1f138c; i++)
		{
			x3f476b1639f1fbe9 x3f476b1639f1fbe10 = (x3f476b1639f1fbe9)xe84e6ff66aac2a0e(i);
			stringBuilder.AppendFormat("[{0},{1},{2}]", xed8a0d4499d6f292(i), x3f476b1639f1fbe10.x0d1e53f2c8fd6fb3, x3f476b1639f1fbe10.x71e1774af0bcc655);
		}
		return stringBuilder.ToString();
	}
}
