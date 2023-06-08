using System;
using System.Drawing;

namespace ns215;

internal class Class5922 : Class5916
{
	protected float float_2;

	public Class5922(Interface249 nativeObj)
		: base(nativeObj)
	{
	}

	internal override void vmethod_3()
	{
		foreach (Class5914 item in arrayList_0)
		{
			if (!item.IsHidden)
			{
				if (item is Class5916)
				{
					((Class5916)item).vmethod_3();
				}
				float_0 = Math.Max(item.Size.Width, float_0);
				item.Pos = new PointF(class5829_0.LeftInset, float_2);
				float_2 += item.Size.Height;
			}
		}
		float_1 = float_2;
		method_0();
	}
}
