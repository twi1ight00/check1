using x24ed092a62874e86;
using x32a884d842a34446;
using xad5c68c1ad3b0224;

namespace x5f5ca2a37b849b4a;

internal class x3b89e8fea42c2f6a : xcd38be6e82bc4732
{
	private static readonly x40b68bd2f183c615[] x2ccbe109860375ba = new x40b68bd2f183c615[9]
	{
		x40b68bd2f183c615.x02c85a8205c3f73b,
		x40b68bd2f183c615.xed2a37919fe44f03,
		x40b68bd2f183c615.x8a49f1364bdbc4e8,
		x40b68bd2f183c615.x8df91a2f90079e88,
		x40b68bd2f183c615.xf72c9308f786e2f0,
		x40b68bd2f183c615.x4053bf44f19ab1e2,
		x40b68bd2f183c615.x7599ce6fe8bedf46,
		x40b68bd2f183c615.x3cb6807e93737c2d,
		x40b68bd2f183c615.x35078e8db43b001f
	};

	public x3b89e8fea42c2f6a(xcd7d6e7318ee6574 context)
		: base(context)
	{
		base.x757fd640babff861 = new x8579bcedac010519(xbf07f5794fa0e774.xbd2342b58438bbd5(context.xfe2178c1f916f36c), xbf07f5794fa0e774.xa87d0dcf016863b9(context.xfe2178c1f916f36c, x5b428099b4c542f7: false), xbf07f5794fa0e774.x1a64bd72918f4b0d(context.xfe2178c1f916f36c));
	}

	internal override xda4dde4038ab80db x2a45f54275953215(int xc0c4c459c6ccbd00)
	{
		return xcd38be6e82bc4732.x99eeea7831ce8476(xc0c4c459c6ccbd00, base.x757fd640babff861.x48cc0c3eaf9f5f05.x30f0af038def5996);
	}

	internal override xda4dde4038ab80db x258fcff67a4e5639(int xc0c4c459c6ccbd00)
	{
		return xcd38be6e82bc4732.x99eeea7831ce8476(xc0c4c459c6ccbd00, base.x757fd640babff861.x6a81a30bcaf20a97.x30f0af038def5996);
	}

	internal x40b68bd2f183c615 x9f585ae5d4fffb7f(int xc0c4c459c6ccbd00)
	{
		int num = xc0c4c459c6ccbd00 % 9;
		return x2ccbe109860375ba[num];
	}
}
