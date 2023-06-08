namespace x38a89dee67fc7a16;

internal struct xcd20a6db055c59bf
{
	public readonly short xb0b4ff1622a01d12;

	public readonly short x1be93eed8950d961;

	public readonly short x30b362a3009d1d63;

	public xcd20a6db055c59bf(short length, short code, short runlen)
	{
		x1be93eed8950d961 = length;
		xb0b4ff1622a01d12 = code;
		x30b362a3009d1d63 = runlen;
	}

	public xcd20a6db055c59bf(int length, int code, int runlen)
		: this((short)length, (short)code, (short)runlen)
	{
	}

	public static xcd20a6db055c59bf xf38f54ad368a4a36(short[] x9d5750eb2d6373bc, int x7e9c6de790cc3ca6)
	{
		int num = x7e9c6de790cc3ca6 * 3;
		return new xcd20a6db055c59bf(x9d5750eb2d6373bc[num], x9d5750eb2d6373bc[num + 1], x9d5750eb2d6373bc[num + 2]);
	}
}
