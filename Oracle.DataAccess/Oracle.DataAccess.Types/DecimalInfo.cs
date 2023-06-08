namespace Oracle.DataAccess.Types;

internal class DecimalInfo
{
	internal const byte ExponentIndex = 3;

	internal const byte ScaleByteIndex = 2;

	internal const byte SignByteIndex = 3;

	internal const byte SignBitIndex = 31;

	internal const byte MaxPrecision = 29;

	private DecimalInfo()
	{
	}
}
