using Aspose.Words;

namespace x4adf554d20d941a6;

internal class xbb128850ab6e3d33 : x4af4ee0384f9176a
{
	internal override StoryType xfe6cdb7c00822bd9 => StoryType.Endnotes;

	internal override bool x31fecf0961487c73 => false;

	internal xbb128850ab6e3d33(x4e2f8bff72d83f71 documentLayout)
		: base(documentLayout)
	{
	}

	internal override x78752dd11b777af5 x6160b752f2880dec(x852fe8bb5ac31098 xe3e287548b3d01f5, bool x502d59bacbd3e16e)
	{
		if (xe3e287548b3d01f5.xd90ac7fcbe961761 == null && x502d59bacbd3e16e)
		{
			xe3e287548b3d01f5.xd90ac7fcbe961761 = new xd37fbb663b35a9f2();
			x78752dd11b777af5[] array = x3411594c37cd9251(xe3e287548b3d01f5, xfb73ba58c683a607: false);
			xbc4db1b9481c1d31(array[0], array[1], xe3e287548b3d01f5.xd90ac7fcbe961761, x502d59bacbd3e16e: false);
		}
		return xe3e287548b3d01f5.xd90ac7fcbe961761;
	}

	internal override void x2eb651a26ca80730(x852fe8bb5ac31098 xe3e287548b3d01f5, x78752dd11b777af5 xd7e5673853e47af4)
	{
		xe3e287548b3d01f5.xd90ac7fcbe961761 = (xd37fbb663b35a9f2)xd7e5673853e47af4;
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.x9a5f0985ca88522b(this);
	}
}
