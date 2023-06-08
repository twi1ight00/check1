using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal abstract class xa117f86ce0e66a3e
{
	public short x1a1cb85d8c2525a3;

	public short x9462c8df936efa39;

	public short x11f73230b9b436a7;

	public short x5b051452efe1bbe3;

	public short xbed6b6abe5a7fcce;

	public bool x7149c962c02931b3 => x1a1cb85d8c2525a3 == 0;

	public virtual void Write(x73087173962e3778 writer)
	{
		writer.xab5f6b7526efa5be(x1a1cb85d8c2525a3);
		writer.xab5f6b7526efa5be(x9462c8df936efa39);
		writer.xab5f6b7526efa5be(x5b051452efe1bbe3);
		writer.xab5f6b7526efa5be(x11f73230b9b436a7);
		writer.xab5f6b7526efa5be(xbed6b6abe5a7fcce);
	}

	public static xa117f86ce0e66a3e x06b0e25aa6ad68a9(xa8866d7566da0aa2 xe134235b3526fa75)
	{
		short num = xe134235b3526fa75.x2e6b89ad8001e18f();
		xe134235b3526fa75.x9e418ad9a56d1cf5.Position -= 2L;
		if (num < 0)
		{
			return xc6a9eccebd57cc06.x31a3f77e98668a51(xe134235b3526fa75);
		}
		return x9154e21429180d32.xe45a24eec57c3398(xe134235b3526fa75);
	}
}
