using System.Text;
using ns175;
using ns176;
using ns187;

namespace ns186;

internal class Class5006 : Class5003
{
	private class Class5383 : Interface180
	{
		public int imethod_0()
		{
			return 0;
		}

		public double imethod_1()
		{
			return 1.0;
		}

		public int imethod_2(Interface172 context)
		{
			return 0;
		}
	}

	public override int imethod_0()
	{
		return 6;
	}

	public override Interface180 imethod_1()
	{
		return new Class5383();
	}

	public override Class5024 imethod_2(Class5024[] args, Class5750 pInfo)
	{
		float num = (float)args[0].vmethod_9();
		float num2 = (float)args[1].vmethod_9();
		float num3 = (float)args[2].vmethod_9();
		if (!(num < 0f) && !(num > 255f) && !(num2 < 0f) && !(num2 > 255f) && !(num3 < 0f) && num3 <= 255f)
		{
			float num4 = (float)args[3].vmethod_9();
			float num5 = (float)args[4].vmethod_9();
			float num6 = (float)args[5].vmethod_9();
			if (!(num4 < 0f) && num4 <= 100f)
			{
				if (!(num5 < -127f) && !(num5 > 127f) && !(num6 < -127f) && num6 <= 127f)
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append("cie-lab-color(" + num + "," + num2 + "," + num3 + "," + num4 + "," + num5 + "," + num6 + ")");
					Class5738 foUserAgent = ((pInfo == null) ? null : ((pInfo.method_2() == null) ? null : pInfo.method_2().method_2()));
					return Class5040.smethod_0(foUserAgent, stringBuilder.ToString());
				}
				throw new Exception55("a* and b* values out of range. Valid range: [-127..+127]");
			}
			throw new Exception55("L* value out of range. Valid range: [0..100]");
		}
		throw new Exception55("sRGB color values out of range. Arguments to cie-lab-color() must be [0..255] or [0%..100%]");
	}
}
