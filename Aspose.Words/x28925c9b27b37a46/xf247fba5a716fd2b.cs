using Aspose.Words;

namespace x28925c9b27b37a46;

internal class xf247fba5a716fd2b
{
	private int x60adf410a9cceab0;

	private int x38cc21f542fc2cb9;

	private int xd724d82e953324d0;

	private int x70315994665222f7;

	private byte[][] x80af3ee36db8cf27;

	private byte[] x4c2e24477698ff4f;

	private byte[][] x2906a5dd5a3164a3;

	private byte[] xed2dc18c3871b17b;

	internal int xea1e81378298fa81 => x60adf410a9cceab0;

	internal float x48bad9bd1e802b02 => (float)xd724d82e953324d0 / (float)x38cc21f542fc2cb9;

	internal float x506be76690bd7373 => (float)x70315994665222f7 / (float)x38cc21f542fc2cb9;

	internal xf247fba5a716fd2b(int id, int contraction, int hExpansion, int vExpansion)
	{
		x60adf410a9cceab0 = id;
		x38cc21f542fc2cb9 = contraction;
		xd724d82e953324d0 = hExpansion;
		x70315994665222f7 = vExpansion;
		x80af3ee36db8cf27 = new byte[3][];
		x2906a5dd5a3164a3 = new byte[3][];
	}

	internal void xf95986cc69ab2564(BorderType xe6e655492739f7d2, x32836ca8baa844bb x60fe2a0636112190, byte[] x4e98ecec2864d4b1)
	{
		switch (xe6e655492739f7d2)
		{
		case BorderType.Top:
			x80af3ee36db8cf27[(int)x60fe2a0636112190] = x4e98ecec2864d4b1;
			break;
		case BorderType.Bottom:
			x2906a5dd5a3164a3[(int)x60fe2a0636112190] = x4e98ecec2864d4b1;
			break;
		case BorderType.Left:
			xed2dc18c3871b17b = x4e98ecec2864d4b1;
			break;
		case BorderType.Right:
			x4c2e24477698ff4f = x4e98ecec2864d4b1;
			break;
		}
	}

	internal byte[] x2bc6e069e2d64db8(BorderType xe6e655492739f7d2, x32836ca8baa844bb x60fe2a0636112190)
	{
		return xe6e655492739f7d2 switch
		{
			BorderType.Top => x80af3ee36db8cf27[(int)x60fe2a0636112190], 
			BorderType.Bottom => x2906a5dd5a3164a3[(int)x60fe2a0636112190], 
			BorderType.Left => xed2dc18c3871b17b, 
			BorderType.Right => x4c2e24477698ff4f, 
			_ => new byte[0], 
		};
	}
}
