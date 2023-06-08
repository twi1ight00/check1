namespace x38a89dee67fc7a16;

internal class x24fae39da17573bb
{
	private readonly xb56653ec61f2ac36 x9122f16b78914e0a;

	private readonly float x376458a60fc4b5e2;

	private readonly float xadfe4e32d177d042;

	public xb56653ec61f2ac36 x11a0eb5c9c3f84e0 => x9122f16b78914e0a;

	public float x6389c51ad2820f52 => x376458a60fc4b5e2;

	public float x4f7155e57c89d548 => xadfe4e32d177d042;

	public x24fae39da17573bb()
		: this(xb56653ec61f2ac36.x4d0b9d4447ba7566, 0.5f, 0.5f)
	{
	}

	public x24fae39da17573bb(xb56653ec61f2ac36 colorMode, float brightness, float contrast)
	{
		x9122f16b78914e0a = colorMode;
		x376458a60fc4b5e2 = ((brightness > 1f) ? 1f : ((brightness < 0f) ? 0f : brightness));
		xadfe4e32d177d042 = ((contrast > 1f) ? 1f : ((contrast < 0f) ? 0f : contrast));
	}

	public bool xf8d5458b61f7fa46()
	{
		if (xa1f5bf51f937128d(x11a0eb5c9c3f84e0) && x83cdafbb59ee3eb7(x6389c51ad2820f52))
		{
			return x660d4544111e2562(x4f7155e57c89d548);
		}
		return false;
	}

	public static bool xa1f5bf51f937128d(xb56653ec61f2ac36 x83e290a8ccdceb7e)
	{
		return x83e290a8ccdceb7e == xb56653ec61f2ac36.x4d0b9d4447ba7566;
	}

	public static bool x660d4544111e2562(float x6eebe5873d5613d0)
	{
		if (x6eebe5873d5613d0 > 0.49f && x6eebe5873d5613d0 < 0.51f)
		{
			return true;
		}
		return false;
	}

	public static bool x83cdafbb59ee3eb7(float x7245ca8139eba392)
	{
		if (x7245ca8139eba392 > 0.49f && x7245ca8139eba392 < 0.51f)
		{
			return true;
		}
		return false;
	}
}
