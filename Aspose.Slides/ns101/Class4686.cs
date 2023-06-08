using ns99;

namespace ns101;

internal class Class4686 : Interface129
{
	private ushort ushort_0;

	private ushort ushort_1;

	public ushort PlatformID
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
		}
	}

	public ushort PlatformSpecificID
	{
		get
		{
			return ushort_1;
		}
		set
		{
			ushort_1 = value;
		}
	}

	public Class4686(ushort platformID, ushort platformSpecificID)
	{
		PlatformID = platformID;
		PlatformSpecificID = platformSpecificID;
	}
}
