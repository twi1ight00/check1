using System;
using System.IO;
using x13f1efc79617a47b;
using x38a89dee67fc7a16;

namespace x4f4df92b75ba3b67;

internal class x16dc68e1ea82ce9e : x4c746eafc29e5079
{
	private readonly xc402f9a087112e63 x4a66f2abeb17a818;

	private readonly xa2745adfabe0c674 xbfcb11d1f4e5d8ba;

	internal x16dc68e1ea82ce9e(xc402f9a087112e63 compression, xa2745adfabe0c674 imageSize)
	{
		x4a66f2abeb17a818 = compression;
		xbfcb11d1f4e5d8ba = imageSize;
	}

	internal override Stream xdd66d940acb3d138(Stream xf823f0edaa261f3b)
	{
		x302a61bb21175bd5 compression = ((x4a66f2abeb17a818 == xc402f9a087112e63.xf6875da725c82a98) ? x302a61bb21175bd5.x810adcc346e1d17e : x302a61bb21175bd5.x1693cc0f7e432616);
		return new x62612bdea8ae1b03(xf823f0edaa261f3b, compression, (float)xbfcb11d1f4e5d8ba.x5c6fc5693c6898cd, xbfcb11d1f4e5d8ba.xdc1bf80853046136);
	}

	internal override void x0a2e1f2c2da67e52(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Filter", "/CCITTFaxDecode");
		xbdfb620b7167944b.x25d0efbd7848eeb3("/DecodeParms <<");
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/K", xad8efd16cd44bb21());
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Columns", xbfcb11d1f4e5d8ba.xdc1bf80853046136);
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Rows", xbfcb11d1f4e5d8ba.xb0f146032f47c24e);
		xbdfb620b7167944b.x25d0efbd7848eeb3(">>");
	}

	private int xad8efd16cd44bb21()
	{
		return x4a66f2abeb17a818 switch
		{
			xc402f9a087112e63.xf6875da725c82a98 => 0, 
			xc402f9a087112e63.xd9c34d7c9f00a2f9 => -1, 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gocmmpjmapanaainfponhofocomoapdponkpknbadjiadnpamngbhnnbhnecgnlcgmcdbnjdomaebmheemoeamffnhmf", 1985790609))), 
		};
	}
}
