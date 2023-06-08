using System.Collections;
using System.IO;
using xa604c4d210ae0581;

namespace x16f9a31f749b8bb1;

internal class x5c2107ebcbb7681b : xa38071b52e850907
{
	private readonly BinaryReader xd5f978e76777d3f3;

	private Hashtable x71ae8d015436dcf6;

	private readonly Hashtable x475cddab5221f0ab = new Hashtable();

	internal x5c2107ebcbb7681b(x8aeace2bf92692ab fib, BinaryReader tableStreamReader)
	{
		xd5f978e76777d3f3 = tableStreamReader;
		x06b0e25aa6ad68a9(x9e131021ba70185c.xc447809891322395, fib.x955a03f821588c52.x4e5af45e90e86266, "PlcfFldMom");
		x06b0e25aa6ad68a9(x9e131021ba70185c.x1ea60bde2b5d0d28, fib.x955a03f821588c52.xd42cf51f01c25e54, "PlcfFldHdr");
		x06b0e25aa6ad68a9(x9e131021ba70185c.x69d28a4aeef83a6f, fib.x955a03f821588c52.x9cc70b5da3f30539, "PlcfFldFtn");
		x06b0e25aa6ad68a9(x9e131021ba70185c.x937e050c63ea1527, fib.x955a03f821588c52.x266b4e5c7534e0a8, "PlcfFldAtn");
		x06b0e25aa6ad68a9(x9e131021ba70185c.xd90ac7fcbe961761, fib.x955a03f821588c52.xc85e1fbe5c0265f9, "PlcfFldEdn");
		x06b0e25aa6ad68a9(x9e131021ba70185c.xf79eacb7dc6313bb, fib.x955a03f821588c52.xf21a0a6a898debc2, "PlcfFldTxbx");
		x06b0e25aa6ad68a9(x9e131021ba70185c.xda79e5b626eda365, fib.x955a03f821588c52.xe38f741b7cacc4ff, "PlcfFldHdrTxtbx");
	}

	internal xb96b10c688c10ef2 xf1922831d211dc4f(x9e131021ba70185c x77b06614416ee4d3, int x18d1054d82981887)
	{
		Hashtable hashtable = (Hashtable)x475cddab5221f0ab[x77b06614416ee4d3];
		return (xb96b10c688c10ef2)hashtable[x18d1054d82981887];
	}

	private void xb10f2c5426ecd7f6(BinaryReader xe134235b3526fa75, int xd59ec9a3f7a434cb, int x115e8b3958ad070b)
	{
		xb96b10c688c10ef2 value = new xb96b10c688c10ef2(xe134235b3526fa75);
		x71ae8d015436dcf6[xd59ec9a3f7a434cb] = value;
	}

	void xa38071b52e850907.xa6a789f0e88511c3(BinaryReader xe134235b3526fa75, int xd59ec9a3f7a434cb, int x115e8b3958ad070b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xb10f2c5426ecd7f6
		this.xb10f2c5426ecd7f6(xe134235b3526fa75, xd59ec9a3f7a434cb, x115e8b3958ad070b);
	}

	private void x06b0e25aa6ad68a9(x9e131021ba70185c x77b06614416ee4d3, x3fdb33c580a0bef3 x2e35a61e0b396eec, string xde5031b4f06bf874)
	{
		x71ae8d015436dcf6 = new Hashtable();
		x475cddab5221f0ab[x77b06614416ee4d3] = x71ae8d015436dcf6;
		xd5f978e76777d3f3.BaseStream.Seek(x2e35a61e0b396eec.xe53f0e68147463d1, SeekOrigin.Begin);
		x759e32a03439237a.x06b0e25aa6ad68a9(xd5f978e76777d3f3, x2e35a61e0b396eec.x04c290dc4d04369c, 2, this, xde5031b4f06bf874);
	}
}
