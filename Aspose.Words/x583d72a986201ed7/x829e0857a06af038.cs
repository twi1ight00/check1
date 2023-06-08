using Aspose.Words;

namespace x583d72a986201ed7;

internal abstract class x829e0857a06af038
{
	private readonly bool xcdea1db3afe46fe3;

	private readonly bool x6ab65b56fd9aacd5;

	private readonly NumberStyle xb787a022f2ac29f1;

	internal bool xd625490738b93054 => xcdea1db3afe46fe3;

	internal bool xd573a87c8d2cd484 => !xcdea1db3afe46fe3;

	internal bool xf80e8a13daebb8f4 => x6ab65b56fd9aacd5;

	internal NumberStyle x41e9d5f906ecbec1 => xb787a022f2ac29f1;

	protected x829e0857a06af038(bool isBullet, bool isLevelsSupported, NumberStyle numberStyle)
	{
		xcdea1db3afe46fe3 = isBullet;
		x6ab65b56fd9aacd5 = isLevelsSupported;
		xb787a022f2ac29f1 = numberStyle;
	}

	internal abstract bool xb983789489a1157b(string xbcea506a33cf9111);

	internal abstract string x181ceabdeeb62d2d(string x0a98315ddae9f889);

	internal abstract xd0213f18a88e2027 x22bdad7984a6b53a(string xb41faee6912a2313);

	internal abstract string x54f56e2c447eeea2(int x66bbd7ed8c65740d);
}
