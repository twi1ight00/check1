using x74500b509de15565;
using xa7850104c8d8c135;

namespace x24e0e4e48dc84bd8;

internal class x030508d4549c7599
{
	private xdddf00507e66b745 x68ff470e0ca989a3;

	private xdddf00507e66b745 x9e2594a5de674575;

	private double xc93e5f6d6191f1bd = 1.0 / 6.0;

	private double x3261459aa5d4d2cd = 1.0 / 6.0;

	private double x2c1be5e94d9bfd0e = 1.03;

	private x7f58a245ea7b47d0 x102c8d1345fac45b;

	public xdddf00507e66b745 xade2575399cddd2d => x68ff470e0ca989a3;

	public xdddf00507e66b745 x5fa735305a376d47 => x9e2594a5de674575;

	public double x7c9f71283253e177 => xc93e5f6d6191f1bd;

	public double x3d1656d05c05afb5 => x3261459aa5d4d2cd;

	public double x7beeab5a7a33f8de => x2c1be5e94d9bfd0e;

	public x7f58a245ea7b47d0 xa16a48047a815248 => x102c8d1345fac45b;

	public bool x097960ea288b2feb => (x102c8d1345fac45b & x7f58a245ea7b47d0.x2457ad064eafea96) != 0;

	public bool xfe855daf0c2c927d => (x102c8d1345fac45b & x7f58a245ea7b47d0.xfe855daf0c2c927d) != 0;

	public bool xd13a588829d84a35 => (x102c8d1345fac45b & x7f58a245ea7b47d0.xd13a588829d84a35) != 0;

	public static x030508d4549c7599 x06b0e25aa6ad68a9(x28a5d52551b64191 xe134235b3526fa75)
	{
		x030508d4549c7599 x030508d4549c7600 = new x030508d4549c7599();
		xe134235b3526fa75.ReadInt32();
		x030508d4549c7600.x102c8d1345fac45b = (x7f58a245ea7b47d0)xe134235b3526fa75.ReadUInt32();
		xe134235b3526fa75.ReadInt32();
		x030508d4549c7600.x68ff470e0ca989a3 = (xdddf00507e66b745)xe134235b3526fa75.ReadInt32();
		x030508d4549c7600.x9e2594a5de674575 = (xdddf00507e66b745)xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadSingle();
		xe134235b3526fa75.ReadInt32();
		x030508d4549c7600.xc93e5f6d6191f1bd = xe134235b3526fa75.ReadSingle();
		x030508d4549c7600.x3261459aa5d4d2cd = xe134235b3526fa75.ReadSingle();
		x030508d4549c7600.x2c1be5e94d9bfd0e = xe134235b3526fa75.ReadSingle();
		return x030508d4549c7600;
	}
}
