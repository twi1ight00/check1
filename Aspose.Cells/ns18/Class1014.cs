using ns22;

namespace ns18;

internal class Class1014
{
	private readonly double double_0;

	private readonly double double_1;

	private readonly double double_2;

	private readonly double double_3;

	public override int GetHashCode()
	{
		return (Class1024.GetHashCode(double_0) >> 1) ^ (Class1024.GetHashCode(double_1) << 3) ^ (Class1024.GetHashCode(double_2) << 1) ^ (Class1024.GetHashCode(double_3) >> 3);
	}

	public static int smethod_0(byte[] byte_0)
	{
		return Class1013.smethod_0(byte_0).GetHashCode();
	}
}
