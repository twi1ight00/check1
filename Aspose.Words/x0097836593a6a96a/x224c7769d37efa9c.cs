using System.Drawing;
using x1c8faa688b1f0b0c;
using x74500b509de15565;
using xa7850104c8d8c135;

namespace x0097836593a6a96a;

internal class x224c7769d37efa9c : x776d392443cca64d
{
	public x224c7769d37efa9c(x3fa09e8d7b952fbc info, xb0d8039f74776744 context)
		: base(info, context)
	{
	}

	public override xb8e7e788f6d59708 Play(SizeF size, x6edb191c4eaef585 options)
	{
		if (options.xff53682edbd8fefe)
		{
			x156c31fff65927f3 x156c31fff65927f = new x156c31fff65927f3(base.xb444c09fa044bbca);
			byte[] array = x156c31fff65927f.x2ebb73bd61f0b1e0();
			if (array != null)
			{
				x776d392443cca64d x776d392443cca64d2 = x776d392443cca64d.xebcf83b00134300b(array, x28fcdc775a1d069c);
				return x776d392443cca64d2.Play(size, options);
			}
		}
		return base.Play(size, options);
	}

	protected override xb8e7e788f6d59708 PlayToVector(SizeF size, x6edb191c4eaef585 options)
	{
		x055feb40a6f16001 x055feb40a6f = new x055feb40a6f16001(base.xb444c09fa044bbca, x28fcdc775a1d069c);
		return x055feb40a6f.x0613827d1b6c81c9(size, options.x77e4ea8d21a6ccca);
	}
}
