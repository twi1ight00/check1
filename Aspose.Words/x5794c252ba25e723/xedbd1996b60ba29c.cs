using x38a89dee67fc7a16;

namespace x5794c252ba25e723;

internal class xedbd1996b60ba29c
{
	private readonly byte[] xbefbcae782e38308;

	private readonly byte[] x771782ffbd372410;

	private readonly bool xd86becf22b56c5eb;

	private readonly bool xd0ad414852120af1;

	private readonly x342b86618ed63a10 xf80bc06fbedec26c;

	private readonly int xe97e96740bd5f717;

	public byte[] xe2001cce235baad2 => xbefbcae782e38308;

	public byte[] x3c5747a5ee1946d5 => x771782ffbd372410;

	public bool x24585bc9b0b1d9e9 => xd86becf22b56c5eb;

	internal bool xd7e5cd7ab6525f63 => xd0ad414852120af1;

	internal x342b86618ed63a10 x342b86618ed63a10 => xf80bc06fbedec26c;

	internal int x1fda32d41ebcf020 => xe97e96740bd5f717;

	public xedbd1996b60ba29c(byte[] colorValues, byte[] alphaValues, bool hasTransparentPixels, bool hadTransparentPixels, x342b86618ed63a10 colorModel, int bitsPerComponent)
		: this(colorValues, alphaValues, hasTransparentPixels, colorModel, bitsPerComponent)
	{
		xd0ad414852120af1 = hadTransparentPixels;
	}

	public xedbd1996b60ba29c(byte[] colorValues, byte[] alphaValues, bool hasTransparentPixels, x342b86618ed63a10 colorModel, int bitsPerComponent)
	{
		xbefbcae782e38308 = colorValues;
		x771782ffbd372410 = alphaValues;
		xd86becf22b56c5eb = hasTransparentPixels;
		xf80bc06fbedec26c = colorModel;
		xe97e96740bd5f717 = bitsPerComponent;
	}
}
