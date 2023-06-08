using ns233;

namespace ns264;

internal class Class6487 : Class6486
{
	private byte[] byte_0;

	internal byte[] ExtractedImageBytes => byte_0;

	protected override bool vmethod_1(Enum837 recordType, int dataSize)
	{
		switch (recordType)
		{
		default:
			return false;
		case Enum837.const_60:
		{
			base.Reader.BaseStream.Position += 22L;
			int dibLength = dataSize - 22;
			byte_0 = Class6148.smethod_21(base.Reader, dibLength);
			return false;
		}
		case Enum837.const_11:
		case Enum837.const_12:
			return true;
		}
	}
}
