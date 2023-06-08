namespace x2a6f63b6650e76c4;

internal class x096ed875f2aef681 : x4e68fc46f3a05e16
{
	private readonly int x6d6da754f6f3a374;

	internal x096ed875f2aef681(xd554b53e829d5f97 range)
		: base(range)
	{
		switch (range.xdbfa333b4cd503e0)
		{
		case xb8f8d187f6793877.x72d92bd1aff02e37:
			x6d6da754f6f3a374 = -1;
			break;
		case xb8f8d187f6793877.x419ba17a5322627b:
			x6d6da754f6f3a374 = 1;
			break;
		default:
			x4e68fc46f3a05e16.x360ab359eefb8af4();
			break;
		}
	}

	protected override bool MoveToNextCell()
	{
		return xc83d0e6d4611cafd.xa53526a8e4a7b443(x6d6da754f6f3a374);
	}
}
