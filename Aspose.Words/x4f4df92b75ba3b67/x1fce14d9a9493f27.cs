using x38a89dee67fc7a16;
using x5794c252ba25e723;

namespace x4f4df92b75ba3b67;

internal class x1fce14d9a9493f27 : x585f64260eb07f7b
{
	private readonly byte[] xd08494dce3b2b550;

	protected override x54366fa5f75a02f7 BrushTransform => null;

	protected override int TileWidth => 8;

	protected override int TileHeight => 8;

	internal x1fce14d9a9493f27(x4882ae789be6e2ef context, x5bdb4ba66c23277c brush)
		: base(context)
	{
		xd08494dce3b2b550 = x973c394bd6a899a2.xb19c72971505e3ca(brush);
	}

	protected override void WriteStream()
	{
		xdb55316cd005e09a.x27335b788ad093c5(xd08494dce3b2b550, x65668b4ebd0faa8f(), null, null);
	}

	protected override bool EqualsInternal(x02cd5c9c8d54330e other)
	{
		return false;
	}

	private x54366fa5f75a02f7 x65668b4ebd0faa8f()
	{
		return new x54366fa5f75a02f7(TileWidth, 0f, 0f, TileHeight, 0f, 0f);
	}
}
