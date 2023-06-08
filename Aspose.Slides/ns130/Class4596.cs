namespace ns130;

internal class Class4596
{
	private byte[] byte_0;

	public byte FamilyType => byte_0[0];

	public byte SerifStyle => byte_0[1];

	public byte Weight => byte_0[2];

	public byte Proportion => byte_0[3];

	public byte Contrast => byte_0[4];

	public byte StrokeVariation => byte_0[5];

	public byte ArmStyle => byte_0[6];

	public byte Letterform => byte_0[7];

	public byte Midline => byte_0[8];

	public byte XHeight => byte_0[9];

	internal Class4596(byte[] data)
	{
		byte_0 = data;
	}
}
