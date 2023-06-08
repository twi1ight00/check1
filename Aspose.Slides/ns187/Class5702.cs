using ns171;

namespace ns187;

internal class Class5702
{
	internal float float_0;

	internal float float_1;

	internal float float_2;

	internal float float_3;

	internal float float_4;

	internal float float_5;

	internal float float_6;

	internal float float_7;

	internal bool method_0()
	{
		if (float_0 == 0f && float_1 == 0f && float_2 == 0f && float_3 == 0f && float_4 == 0f && float_5 == 0f && float_6 == 0f)
		{
			return float_7 != 0f;
		}
		return true;
	}

	private static float smethod_0(Class5634 pList, int id)
	{
		Class5024 @class = pList.vmethod_0(id);
		if (@class != null)
		{
			return (float)@class.vmethod_0().imethod_1() / 1000f;
		}
		return 0f;
	}

	private static void smethod_1(ref float w, ref float h)
	{
		if ((w != 0f || h != 0f) && (w == 0f || h == 0f))
		{
			if (w == 0f)
			{
				w = h;
			}
			else if (h == 0f)
			{
				h = w;
			}
		}
	}

	internal void method_1(Class5634 pList)
	{
		float_0 = smethod_0(pList, 289);
		float_1 = smethod_0(pList, 290);
		smethod_1(ref float_0, ref float_1);
		float_2 = smethod_0(pList, 291);
		float_3 = smethod_0(pList, 292);
		smethod_1(ref float_2, ref float_3);
		float_4 = smethod_0(pList, 293);
		float_5 = smethod_0(pList, 294);
		smethod_1(ref float_4, ref float_5);
		float_6 = smethod_0(pList, 295);
		float_7 = smethod_0(pList, 296);
		smethod_1(ref float_6, ref float_7);
	}
}
