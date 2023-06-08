using Aspose;

namespace x2182451cabb5c30d;

internal abstract class xe16295e98b4802cb
{
	private readonly xe5e546ef5f0503b2 x8cedcaa9a62c6e39;

	protected xe5e546ef5f0503b2 x28fcdc775a1d069c => x8cedcaa9a62c6e39;

	internal xe16295e98b4802cb(xe5e546ef5f0503b2 context)
	{
		x8cedcaa9a62c6e39 = context;
	}

	internal bool x06b0e25aa6ad68a9(x03f56b37a0050a82 x153c99a852375422)
	{
		if (ParseSingleToken(x153c99a852375422))
		{
			return true;
		}
		return SearchInEnums(x153c99a852375422);
	}

	[JavaThrows(true)]
	protected abstract bool ParseSingleToken(x03f56b37a0050a82 token);

	[JavaThrows(true)]
	protected abstract bool SearchInEnums(x03f56b37a0050a82 token);
}
