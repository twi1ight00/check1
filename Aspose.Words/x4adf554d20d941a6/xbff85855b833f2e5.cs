namespace x4adf554d20d941a6;

internal class xbff85855b833f2e5 : x8ff4741a766a2d93
{
	protected override bool IsStarted
	{
		get
		{
			if (!IsFinished)
			{
				return !((x86accec882b7012a)xd4bd25740614b729).xfdc6650195492419;
			}
			return true;
		}
	}

	protected override bool IsFinished => xd4bd25740614b729 == null;

	internal xbff85855b833f2e5(x694f001896973fe3 containerRow)
		: base(containerRow)
	{
		xd4bd25740614b729 = containerRow.xc1277af2cd8d654e;
	}

	internal override bool x47f176deff0d42e2()
	{
		if (!IsFinished)
		{
			xd4bd25740614b729 = xd4bd25740614b729.x9b2bbd3d05bf558b();
		}
		return !IsFinished;
	}
}
