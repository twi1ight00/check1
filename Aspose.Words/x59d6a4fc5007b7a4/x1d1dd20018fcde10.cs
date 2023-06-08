using Aspose.Words;
using x28925c9b27b37a46;
using x66dd9eaee57cfba4;

namespace x59d6a4fc5007b7a4;

internal class x1d1dd20018fcde10
{
	internal readonly Font xc2d4efc42998d87b;

	internal readonly bool x4e1d3347e7864b81;

	internal readonly bool x3312403c03667693;

	internal readonly bool x00d0ae795109fe11;

	internal readonly bool xab4229188249d97a;

	internal readonly string x51cf23ce6e71b84c;

	internal readonly string x31ece097bda75a20;

	internal readonly string xf3d194b4e6a2594a;

	internal readonly string xd08cbc518cf39317;

	internal readonly bool x0080ae622855f90c;

	internal readonly int xbcb6fa15d8981abb;

	private x6b1a899052c71a60 x0ae318df6992826f;

	private x6b1a899052c71a60 x6fe308ec2625e8c3;

	private x6b1a899052c71a60 x8914e225e506a926;

	private x6b1a899052c71a60 xc3897e7787c1bba7;

	internal x1d1dd20018fcde10(Font font)
	{
		xc2d4efc42998d87b = font;
		x4e1d3347e7864b81 = font.Bold;
		x3312403c03667693 = font.BoldBi;
		x00d0ae795109fe11 = font.Italic;
		xab4229188249d97a = font.ItalicBi;
		x51cf23ce6e71b84c = font.NameAscii;
		x31ece097bda75a20 = font.NameFarEast;
		xf3d194b4e6a2594a = font.NameBi;
		xd08cbc518cf39317 = font.NameOther;
		x0080ae622855f90c = font.SmallCaps;
		xbcb6fa15d8981abb = font.xbcb6fa15d8981abb;
	}

	internal x6b1a899052c71a60 xc06de25aa714683f(x000f21cbda739311 x6f02b6a80bf6b36f)
	{
		return x6f02b6a80bf6b36f switch
		{
			x000f21cbda739311.x175297738c8b8d1e => x0ae318df6992826f, 
			x000f21cbda739311.xd4e922ceeed89b74 => x8914e225e506a926, 
			x000f21cbda739311.x7c8c2d13fa5b79fa => x6fe308ec2625e8c3, 
			_ => xc3897e7787c1bba7, 
		};
	}

	internal void x3c8f1980ecfa6e87(x000f21cbda739311 x6f02b6a80bf6b36f, x6b1a899052c71a60 x26094932cf7a9139)
	{
		switch (x6f02b6a80bf6b36f)
		{
		case x000f21cbda739311.x175297738c8b8d1e:
			x0ae318df6992826f = x26094932cf7a9139;
			break;
		case x000f21cbda739311.xd4e922ceeed89b74:
			x8914e225e506a926 = x26094932cf7a9139;
			break;
		case x000f21cbda739311.x7c8c2d13fa5b79fa:
			x6fe308ec2625e8c3 = x26094932cf7a9139;
			break;
		default:
			xc3897e7787c1bba7 = x26094932cf7a9139;
			break;
		}
	}

	internal string xaf95fb496eb25433(x000f21cbda739311 x6f02b6a80bf6b36f)
	{
		return xb7dbd7bb3ed97d5b.x4a59367ba6527b94(x6f02b6a80bf6b36f, x51cf23ce6e71b84c, xf3d194b4e6a2594a, x31ece097bda75a20, xd08cbc518cf39317);
	}
}
