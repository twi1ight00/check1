using System;
using Aspose.Words;

namespace x4adf554d20d941a6;

internal class xb1f375aa1b12d10f : xac6c82c74ce247fb
{
	private xc7f90d9c7c51cede x277a8e7797009ec7;

	private readonly StoryType x476547a1677d89f7;

	internal override StoryType xfe6cdb7c00822bd9 => x476547a1677d89f7;

	internal override x398b3bd0acd94b61 x8b8a0a04b3aeaf3a
	{
		get
		{
			return base.xa51d8d9790431b2b.x8b8a0a04b3aeaf3a;
		}
		set
		{
		}
	}

	internal override x398b3bd0acd94b61 x7e2e5dd40daabc3b
	{
		get
		{
			return base.x88fee64dba8223f9.x7e2e5dd40daabc3b;
		}
		set
		{
		}
	}

	internal override bool x00ae9a426371c468 => true;

	internal bool x9391000fee92b9fe
	{
		get
		{
			switch (xfe6cdb7c00822bd9)
			{
			case StoryType.EvenPagesHeader:
			case StoryType.PrimaryHeader:
			case StoryType.FirstPageHeader:
				return true;
			default:
				return false;
			}
		}
	}

	internal xf6689e0eed33812c x7249fe3d61a20125
	{
		get
		{
			if (x277a8e7797009ec7 != null)
			{
				return x277a8e7797009ec7.x3c1c340351d94fbd;
			}
			return null;
		}
	}

	internal xc7f90d9c7c51cede xa65184d44a47025b
	{
		get
		{
			return x277a8e7797009ec7;
		}
		set
		{
			x277a8e7797009ec7 = value;
		}
	}

	internal xb1f375aa1b12d10f(x4e2f8bff72d83f71 documentLayout, StoryType storyType)
		: base(documentLayout)
	{
		x476547a1677d89f7 = storyType;
	}

	internal override x1073233de8252b3e x8db1e90bce56e416(x398b3bd0acd94b61 xd7e5673853e47af4)
	{
		throw new InvalidOperationException();
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.x1bcfb144a0b27106(this);
	}

	internal static void x9b961d025fb6a1b3(xc7f90d9c7c51cede xbbe2f7d7c86e0379, bool x6b0ad9f73c48ad53)
	{
		x46bd7081dec08b8e x46bd7081dec08b8e2 = (x6b0ad9f73c48ad53 ? xbbe2f7d7c86e0379.x1ea60bde2b5d0d28 : xbbe2f7d7c86e0379.x1d7b771e95a9abb5);
		if (x46bd7081dec08b8e2 == null)
		{
			xb1f375aa1b12d10f xb1f375aa1b12d10f2 = x2c0c9a4fb5b11521.xa2711a6fcb6054d5(xbbe2f7d7c86e0379, x6b0ad9f73c48ad53);
			if (xb1f375aa1b12d10f2 != null)
			{
				x46bd7081dec08b8e2 = (x46bd7081dec08b8e)xb1f375aa1b12d10f2.x8b8a0a04b3aeaf3a;
			}
			if (x6b0ad9f73c48ad53)
			{
				xbbe2f7d7c86e0379.x1ea60bde2b5d0d28 = x46bd7081dec08b8e2;
			}
			else
			{
				xbbe2f7d7c86e0379.x1d7b771e95a9abb5 = x46bd7081dec08b8e2;
			}
		}
		if (x46bd7081dec08b8e2 != null && !x46bd7081dec08b8e2.xe5764fe5359a6d91)
		{
			x46bd7081dec08b8e2.x53111d6596d16a99.xc3819e13f60dd8e6(xfad304b5f8f3bb5b: true);
		}
	}
}
