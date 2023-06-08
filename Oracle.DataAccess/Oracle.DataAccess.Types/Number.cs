namespace Oracle.DataAccess.Types;

internal class Number
{
	internal const byte ExpOffset = 65;

	internal const byte MaxByteValue = byte.MaxValue;

	internal const byte HighBitValue = 128;

	internal const byte PosExpOffset = 193;

	internal const byte NegExpOffset = 62;

	internal const byte PosDigitOffset = 1;

	internal const byte NegDigitOffset = 101;

	internal const byte NegTrailingByte = 102;

	internal const byte ZeroBytesLen = 1;

	internal const byte ZeroBytesExp = 128;

	internal const byte NumLen = 22;

	internal const byte LENINDEX = 0;

	internal const byte EXPINDEX = 1;

	internal const byte DIGITINDEX = 2;

	internal const byte Base = 100;

	internal const byte ExpBase = 2;

	internal const byte MaxDigitsLen = 20;

	internal const byte MaxScale = 127;

	internal const short MinScale = -84;

	internal const byte MaxPrecision = 38;

	internal const byte BinaryFloatLength = 4;

	private Number()
	{
	}
}
