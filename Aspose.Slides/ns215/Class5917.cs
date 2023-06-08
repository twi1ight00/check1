using System;
using System.Drawing;

namespace ns215;

internal class Class5917 : Class5916
{
	protected float float_2;

	protected float float_3;

	protected float float_4;

	public Class5917(Interface249 nativeObj)
		: base(nativeObj)
	{
	}

	internal override void vmethod_3()
	{
		foreach (Class5914 item in arrayList_0)
		{
			if (item is Class5916)
			{
				((Class5916)item).vmethod_3();
			}
			if (!(float_4 + item.Size.Width <= method_1()) && !float_4.Equals(0f))
			{
				float_2 += float_3;
				item.Pos = new PointF(0f, float_2);
				float_4 = item.Size.Width;
				float_3 = item.Size.Height;
				float_0 = Math.Max(float_4, float_0);
			}
			else
			{
				item.Pos = new PointF(float_4, float_2);
				float_4 += item.Size.Width;
				float_0 = Math.Max(float_4, float_0);
				float_3 = Math.Max(float_3, item.Size.Height);
			}
		}
		float_1 = float_2 + float_3;
		method_0();
	}
}
