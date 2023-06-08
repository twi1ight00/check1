namespace x4adf554d20d941a6;

internal abstract class x8ff4741a766a2d93
{
	protected readonly x1073233de8252b3e x437fa02210b98bec;

	protected x398b3bd0acd94b61 xd4bd25740614b729;

	internal x398b3bd0acd94b61 x35cfcea4890f4e7d
	{
		get
		{
			if (!IsStarted || IsFinished)
			{
				return null;
			}
			return xd4bd25740614b729;
		}
	}

	protected abstract bool IsStarted { get; }

	protected abstract bool IsFinished { get; }

	protected x8ff4741a766a2d93(x1073233de8252b3e container)
	{
		x437fa02210b98bec = container;
	}

	internal abstract bool x47f176deff0d42e2();

	internal static x8ff4741a766a2d93 x0df886665b5be89e(x694f001896973fe3 xa806b754814b9ae0)
	{
		if (!xa806b754814b9ae0.x8786efe6471e0521)
		{
			return new xf4aae7217e7b8a13(xa806b754814b9ae0);
		}
		return new xbff85855b833f2e5(xa806b754814b9ae0);
	}
}
