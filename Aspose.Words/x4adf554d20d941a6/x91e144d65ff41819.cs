using Aspose.Words;

namespace x4adf554d20d941a6;

internal class x91e144d65ff41819 : x61ebdec02c254c25
{
	private readonly Node x04aa51c0858be176;

	internal override int x1be93eed8950d961 => 0;

	internal override bool x1b4884baf08c8d62 => true;

	internal override x6e414db5d060a816 x6e414db5d060a816
	{
		get
		{
			if (x12cb12b5d2cad53d == null)
			{
				return x6e414db5d060a816.x9fd888e65466818c;
			}
			return x6e414db5d060a816.x12cb12b5d2cad53d;
		}
	}

	internal string x759aa16c2016a289
	{
		get
		{
			if (x12cb12b5d2cad53d == null)
			{
				return x9fd888e65466818c.Name;
			}
			return x12cb12b5d2cad53d.Name;
		}
	}

	private BookmarkStart x12cb12b5d2cad53d
	{
		get
		{
			if (!(x04aa51c0858be176 is BookmarkStart))
			{
				return null;
			}
			return (BookmarkStart)x04aa51c0858be176;
		}
	}

	private BookmarkEnd x9fd888e65466818c
	{
		get
		{
			if (!(x04aa51c0858be176 is BookmarkEnd))
			{
				return null;
			}
			return (BookmarkEnd)x04aa51c0858be176;
		}
	}

	internal x91e144d65ff41819(Node bookmark)
		: base(0)
	{
		x04aa51c0858be176 = bookmark;
	}

	internal override x56410a8dd70087c5 xa9d7e8f6fbdcbcfc(x56410a8dd70087c5 x7d95d971d8923f4c)
	{
		if (x7d95d971d8923f4c == null)
		{
			x7d95d971d8923f4c = new x91e144d65ff41819(x04aa51c0858be176);
		}
		return base.xa9d7e8f6fbdcbcfc(x7d95d971d8923f4c);
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.x8f7209e6e174fc25(this);
	}
}
