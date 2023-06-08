using ns233;

namespace ns224;

internal class Class6004
{
	private readonly byte[] byte_0;

	private readonly byte[] byte_1;

	private readonly bool bool_0;

	private readonly Enum786 enum786_0;

	private readonly int int_0;

	public byte[] ColorValues => byte_0;

	public byte[] AlphaValues => byte_1;

	public bool HasTransparentPixels => bool_0;

	internal Enum786 ColorModel => enum786_0;

	internal int BitsPerComponent => int_0;

	public Class6004(byte[] colorValues, byte[] alphaValues, bool hasTransparentPixels, Enum786 colorModel, int bitsPerComponent)
	{
		byte_0 = colorValues;
		byte_1 = alphaValues;
		bool_0 = hasTransparentPixels;
		enum786_0 = colorModel;
		int_0 = bitsPerComponent;
	}
}
