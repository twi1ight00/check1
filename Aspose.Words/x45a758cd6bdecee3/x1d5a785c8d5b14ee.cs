using x6c95d9cf46ff5f25;

namespace x45a758cd6bdecee3;

internal class x1d5a785c8d5b14ee
{
	public const int xa230444f4711f2cc = 16;

	public string xd229d86af0f16fb0;

	public int x05dda501c2a6f104;

	public uint xf1d9b91c9700c401;

	public uint x1be93eed8950d961;

	public static x1d5a785c8d5b14ee x06b0e25aa6ad68a9(xa8866d7566da0aa2 xe134235b3526fa75)
	{
		x1d5a785c8d5b14ee x1d5a785c8d5b14ee2 = new x1d5a785c8d5b14ee();
		x1d5a785c8d5b14ee2.xd229d86af0f16fb0 = new string(xe134235b3526fa75.x9a839f0ae94bc95f(4));
		x1d5a785c8d5b14ee2.x05dda501c2a6f104 = xe134235b3526fa75.x95ea7d23cc8ee04d();
		x1d5a785c8d5b14ee2.xf1d9b91c9700c401 = xe134235b3526fa75.x2aa9a7ff4efa6ddf();
		x1d5a785c8d5b14ee2.x1be93eed8950d961 = xe134235b3526fa75.x2aa9a7ff4efa6ddf();
		return x1d5a785c8d5b14ee2;
	}

	public void x6210059f049f0d48(x73087173962e3778 xbdfb620b7167944b)
	{
		for (int i = 0; i < xd229d86af0f16fb0.Length; i++)
		{
			xbdfb620b7167944b.xc351d479ff7ee789((byte)xd229d86af0f16fb0[i]);
		}
		xbdfb620b7167944b.x6ff7c65ed4805c27(x05dda501c2a6f104);
		xbdfb620b7167944b.x04aa082effd9db6b(xf1d9b91c9700c401);
		xbdfb620b7167944b.x04aa082effd9db6b(x1be93eed8950d961);
	}

	public static int x7feeb3b91bfbb9ea(byte[] x4a3f0a05c02f235f)
	{
		return x7feeb3b91bfbb9ea(x4a3f0a05c02f235f, 0, x4a3f0a05c02f235f.Length);
	}

	public static int x7feeb3b91bfbb9ea(byte[] x4a3f0a05c02f235f, int xc0c4c459c6ccbd00, int x10f4d88af727adbc)
	{
		int num = 0;
		int num2 = xc0c4c459c6ccbd00;
		int num3 = x10f4d88af727adbc / 4;
		int num4;
		int num5;
		int num6;
		int num7;
		for (int i = 0; i < num3; i++)
		{
			num4 = x4a3f0a05c02f235f[num2++];
			num5 = x4a3f0a05c02f235f[num2++];
			num6 = x4a3f0a05c02f235f[num2++];
			num7 = x4a3f0a05c02f235f[num2++];
			int num8 = num7 | (num6 << 8) | (num5 << 16) | (num4 << 24);
			num += num8;
		}
		num4 = ((num2 < x10f4d88af727adbc) ? x4a3f0a05c02f235f[num2++] : 0);
		num5 = ((num2 < x10f4d88af727adbc) ? x4a3f0a05c02f235f[num2++] : 0);
		num6 = ((num2 < x10f4d88af727adbc) ? x4a3f0a05c02f235f[num2] : 0);
		num7 = 0;
		int num9 = num7 | (num6 << 8) | (num5 << 16) | (num4 << 24);
		return num + num9;
	}
}
