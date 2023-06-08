namespace x4adf554d20d941a6;

internal class xf4aae7217e7b8a13 : x8ff4741a766a2d93
{
	protected override bool IsStarted => xd4bd25740614b729 != null;

	protected override bool IsFinished
	{
		get
		{
			if (IsStarted)
			{
				return ((x86accec882b7012a)xd4bd25740614b729).xfdc6650195492419;
			}
			return false;
		}
	}

	internal xf4aae7217e7b8a13(x694f001896973fe3 containerRow)
		: base(containerRow)
	{
	}

	internal override bool x47f176deff0d42e2()
	{
		if (!IsStarted)
		{
			xd4bd25740614b729 = ((x694f001896973fe3)x437fa02210b98bec).x96ac59f61797f5b9;
		}
		else if (!IsFinished)
		{
			xd4bd25740614b729 = xd4bd25740614b729.xf432ece93e450408();
		}
		return !IsFinished;
	}
}
