using Aspose.Words;

namespace x4adf554d20d941a6;

internal class x928803c35fad8dec : xac6c82c74ce247fb
{
	private readonly StoryType x476547a1677d89f7;

	private x398b3bd0acd94b61 x6d394320b25a5754;

	private x398b3bd0acd94b61 x7947a6fc7cce3424;

	internal override StoryType xfe6cdb7c00822bd9 => x476547a1677d89f7;

	internal override bool x31fecf0961487c73 => false;

	internal override x398b3bd0acd94b61 x8b8a0a04b3aeaf3a
	{
		get
		{
			return x6d394320b25a5754;
		}
		set
		{
			x6d394320b25a5754 = value;
		}
	}

	internal override x398b3bd0acd94b61 x7e2e5dd40daabc3b
	{
		get
		{
			return x7947a6fc7cce3424;
		}
		set
		{
			x7947a6fc7cce3424 = value;
		}
	}

	internal x928803c35fad8dec(x4e2f8bff72d83f71 documentLayout, StoryType storyType)
		: base(documentLayout)
	{
		x476547a1677d89f7 = storyType;
	}

	internal override x8d9303345f12a846 x4b2e8e22f36c8990(x41ac54db4e627dea x5906905c888d3d98)
	{
		return x42c697007cbd48df(x5906905c888d3d98);
	}

	internal x9a40326835ff6d69 x436447d6f5d09ffe()
	{
		if (x8b8a0a04b3aeaf3a == null)
		{
			x9a40326835ff6d69 xd7e5673853e47af = new x9a40326835ff6d69();
			xbc4db1b9481c1d31(null, null, xd7e5673853e47af, x502d59bacbd3e16e: false);
		}
		return (x9a40326835ff6d69)x8b8a0a04b3aeaf3a;
	}
}
