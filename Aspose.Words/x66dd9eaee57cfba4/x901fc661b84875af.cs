using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal class x901fc661b84875af : x62bf5fe8b95eb273
{
	private readonly int xa6343dc875c3a0d0;

	private readonly int xa7966b77592d0cda;

	public override bool IsSymbolEncoding
	{
		get
		{
			if (xa6343dc875c3a0d0 == 3)
			{
				return xa7966b77592d0cda == 0;
			}
			return false;
		}
	}

	public x901fc661b84875af(x09ce2c02826e31a6 charMap, int language, int platformId, int encodingId)
		: base(charMap, language)
	{
		xa6343dc875c3a0d0 = platformId;
		xa7966b77592d0cda = encodingId;
	}

	protected override x6c5a92230c2f59e2[] BuildSubtables()
	{
		return new x6c5a92230c2f59e2[1]
		{
			new x3668d88d65d61a11(xa6343dc875c3a0d0, xa7966b77592d0cda, xe6414aff183c47a1, x448900fcb384c333)
		};
	}
}
