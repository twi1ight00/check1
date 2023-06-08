using System.Text;
using Aspose;
using x66dd9eaee57cfba4;

namespace x4f4df92b75ba3b67;

internal abstract class xcb3d00e64f2216e5
{
	private readonly x6b1a899052c71a60 x63414d035eba9b06;

	internal abstract bool xc668392aa770aaef { get; }

	public x6b1a899052c71a60 x29f65b3e7616f6b3 => x63414d035eba9b06;

	protected xcb3d00e64f2216e5(x6b1a899052c71a60 font)
	{
		x63414d035eba9b06 = font;
	}

	internal abstract bool xd116716bb9acc746(string xb41faee6912a2313);

	internal abstract int x5827fed50444ba26();

	internal abstract int xb6ce281bc6a25482();

	internal virtual string x192c5bb32da97748(int x940b70f481656041, int xb74a2158c6f43227)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[");
		for (int i = x940b70f481656041; i <= xb74a2158c6f43227; i++)
		{
			int xbcea506a33cf = (x7819ee089c842c62.xc3b52d8fb3995dd1((byte)i) ? x63414d035eba9b06.x1e6da4134d115607.x12f49b36ab885c48(x7819ee089c842c62.x3bc87e84cb72b3d7((byte)i)).xf58adb71a3d2dade : 0);
			stringBuilder.Append(xba2f911354958a68.xf716fdaf41b2c8ab(xbcea506a33cf, x63414d035eba9b06.xa25a0348a20dc6ca));
			stringBuilder.Append(" ");
		}
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}

	[JavaThrows(true)]
	internal abstract void xb98ce8f1ed7517e8(x4f40d990d5bf81a6 xbdfb620b7167944b);
}
