using System;
using System.Drawing;

namespace ns215;

internal class Class5918 : Class5917
{
	public Class5918(Interface249 nativeObj)
		: base(nativeObj)
	{
	}

	internal override void vmethod_3()
	{
		float_2 = 0f;
		float_3 = 0f;
		float_4 = 0f;
		method_7(0, 0f, 0f);
		float_1 = float_2 + float_3;
		method_0();
	}

	private void method_7(int index, float width, float height)
	{
		if (index < arrayList_0.Count)
		{
			Class5914 @class = arrayList_0[index] as Class5914;
			if (@class is Class5916)
			{
				((Class5916)@class).vmethod_3();
			}
			if (!(float_4 + @class.Size.Width <= method_1()) && float_4 != 0f)
			{
				float_2 += float_3;
				float_3 = 0f;
				float_4 = 0f;
				width = 0f;
				height += float_3;
			}
			else
			{
				float_4 += @class.Size.Width;
				float_0 = Math.Max(float_4, float_0);
				float_3 = Math.Max(float_3, @class.Size.Height);
			}
			method_7(++index, width + @class.Size.Width, height);
			@class.Pos = new PointF(vmethod_0().Width - width - @class.Size.Width + class5829_0.LeftInset, height + class5829_0.TopInset);
		}
	}
}
