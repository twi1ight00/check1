namespace ns22;

internal class Class276 : Class258
{
	private byte[] byte_0;

	private ushort ushort_0;

	private uint uint_0;

	public byte[] OfficeArtFBSE_RgbUid
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
			method_0();
		}
	}

	public ushort OfficeArtFBSE_Tag
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
			method_0();
		}
	}

	internal uint Version => uint_0;

	private void method_0()
	{
		uint_0++;
	}
}
