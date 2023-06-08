using System.Drawing;
using x1c8faa688b1f0b0c;
using x24e0e4e48dc84bd8;
using x6c95d9cf46ff5f25;
using x74500b509de15565;
using xa7850104c8d8c135;

namespace x0097836593a6a96a;

internal class x00baf17d46a2678d : x776d392443cca64d
{
	public x00baf17d46a2678d(x3fa09e8d7b952fbc info, xb0d8039f74776744 context)
		: base(info, context)
	{
	}

	protected override xb8e7e788f6d59708 PlayToVector(SizeF size, x6edb191c4eaef585 options)
	{
		if (options.xd30dd304e6bd2ce6)
		{
			x4cb7537b071ca71a x4cb7537b071ca71a = new xaf433c760728a867(base.xb444c09fa044bbca, x28fcdc775a1d069c);
			xb8e7e788f6d59708 result = x4cb7537b071ca71a.x0613827d1b6c81c9(size, options.xd7e4b40571fbbe66 || options.x77e4ea8d21a6ccca);
			if (!x28fcdc775a1d069c.xec8728ceac69f279 || !options.xd7e4b40571fbbe66)
			{
				return result;
			}
			x511f69ab860b84c2();
		}
		x28fcdc775a1d069c.xec8728ceac69f279 = false;
		x4cb7537b071ca71a x4cb7537b071ca71a2 = new x36e85e2927175782(base.xb444c09fa044bbca, x28fcdc775a1d069c);
		return x4cb7537b071ca71a2.x0613827d1b6c81c9(size, options.x77e4ea8d21a6ccca);
	}

	private void x511f69ab860b84c2()
	{
		x28fcdc775a1d069c.x4d2cf6c77ee521cd().xbbf9a1ead81dd3a1(x6d058fdf61831c39.x13efdeb5b4f0d186, x3959df40367ac8a3.x5459fadea977d08d, "EMF+ part of EMF+ dual metafile cannot be correctly rendered. Fallback to EMF part rendering will be performed.");
	}
}
