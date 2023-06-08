using ns22;

namespace ns23;

internal class Class260 : Class258
{
	private uint uint_0;

	public uint SoundIdRef
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	internal bool Equals(Class260 unsupportedProps)
	{
		if (unsupportedProps == null)
		{
			return false;
		}
		return uint_0 == unsupportedProps.uint_0;
	}
}
