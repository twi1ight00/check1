using Aspose.Words;

namespace x4adf554d20d941a6;

internal class xb3182f54aafe1dd9 : x4af4ee0384f9176a
{
	internal override StoryType xfe6cdb7c00822bd9 => StoryType.Footnotes;

	internal override bool x31fecf0961487c73 => false;

	internal xb3182f54aafe1dd9(x4e2f8bff72d83f71 documentLayout)
		: base(documentLayout)
	{
	}

	internal override x78752dd11b777af5 x6160b752f2880dec(x852fe8bb5ac31098 xe3e287548b3d01f5, bool x502d59bacbd3e16e)
	{
		if (xe3e287548b3d01f5.x69d28a4aeef83a6f == null && x502d59bacbd3e16e)
		{
			xe3e287548b3d01f5.x69d28a4aeef83a6f = new x41744f5ec654abee();
			x78752dd11b777af5[] array = x3411594c37cd9251(xe3e287548b3d01f5, xfb73ba58c683a607: false);
			xbc4db1b9481c1d31(array[0], array[1], xe3e287548b3d01f5.x69d28a4aeef83a6f, x502d59bacbd3e16e: false);
		}
		return xe3e287548b3d01f5.x69d28a4aeef83a6f;
	}

	internal override void x2eb651a26ca80730(x852fe8bb5ac31098 xe3e287548b3d01f5, x78752dd11b777af5 xd7e5673853e47af4)
	{
		xe3e287548b3d01f5.x69d28a4aeef83a6f = (x41744f5ec654abee)xd7e5673853e47af4;
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.x19221dc4fc4344bf(this);
	}
}
