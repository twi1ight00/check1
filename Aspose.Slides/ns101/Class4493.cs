using ns119;

namespace ns101;

internal class Class4493 : Class4492
{
	private int int_0;

	public long FontIndex => int_0;

	public Class4493(int fontIndex, string fileExtension, Class4487 streamSource, long offset)
		: base(fileExtension, streamSource, offset)
	{
		int_0 = fontIndex;
	}
}
