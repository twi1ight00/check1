using System.Collections;
using System.IO;
using xa604c4d210ae0581;

namespace xea819b8d8e4542a6;

internal class x1758acc737fefb49 : x456c8b07916a8790
{
	private readonly MemoryStream xa49cef274042e702;

	private readonly x354e9ebad65eecc8 x9b287b671d592594;

	private readonly ArrayList x8cbaa794a76b3dea;

	internal byte[] x2f35be44dc27a548 => xa49cef274042e702.ToArray();

	internal x1758acc737fefb49(byte[] grpprl, BinaryReader dataReader, bool processTableStyles, ArrayList ignoreSprms)
	{
		xa49cef274042e702 = new MemoryStream();
		x9b287b671d592594 = new x354e9ebad65eecc8(xa49cef274042e702);
		x8cbaa794a76b3dea = ignoreSprms;
		xd503583b32a53cea xd503583b32a53cea = new xd503583b32a53cea(this, dataReader);
		xd503583b32a53cea.xd2f1f3523585ff1e = processTableStyles;
		xd503583b32a53cea.x06b0e25aa6ad68a9(grpprl);
	}

	private bool x9b1a5fd2bd42bd55(x875aca5784596b73 x28180b3c3774af93, x8de82539c936c298 xe780cde24dcce6f2, int x0d4f7f21e78721d6, BinaryReader xe134235b3526fa75)
	{
		if (!x135cb307cf17cff8(xe780cde24dcce6f2, x28180b3c3774af93))
		{
			x9b287b671d592594.x3a52c4e37999b16e(x28180b3c3774af93);
			if (xd503583b32a53cea.x65f094754e99b28c(x28180b3c3774af93) == 0)
			{
				if (x28180b3c3774af93 == x875aca5784596b73.x79d0fad9e29c9f31)
				{
					x9b287b671d592594.Write((short)(x0d4f7f21e78721d6 + 1));
				}
				else
				{
					x9b287b671d592594.Write((byte)x0d4f7f21e78721d6);
				}
			}
			byte[] buffer = xe134235b3526fa75.ReadBytes(x0d4f7f21e78721d6);
			x9b287b671d592594.Write(buffer);
		}
		return true;
	}

	bool x456c8b07916a8790.x09a3d4a7eac8f520(x875aca5784596b73 x28180b3c3774af93, x8de82539c936c298 xe780cde24dcce6f2, int x0d4f7f21e78721d6, BinaryReader xe134235b3526fa75)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x9b1a5fd2bd42bd55
		return this.x9b1a5fd2bd42bd55(x28180b3c3774af93, xe780cde24dcce6f2, x0d4f7f21e78721d6, xe134235b3526fa75);
	}

	private bool x135cb307cf17cff8(x8de82539c936c298 xe780cde24dcce6f2, x875aca5784596b73 x28180b3c3774af93)
	{
		if (xe780cde24dcce6f2 == x8de82539c936c298.xc760d3c548350954 && !x8cbaa794a76b3dea.Contains(x28180b3c3774af93) && x28180b3c3774af93 != x875aca5784596b73.x45d84ee9b173b612)
		{
			return x28180b3c3774af93 == x875aca5784596b73.xd959dd2c7aa008cc;
		}
		return true;
	}
}
