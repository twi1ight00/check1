using System.Collections.Generic;
using ns56;

namespace ns24;

internal abstract class Class296 : Class278
{
	private Class2259 class2259_0;

	private uint uint_0;

	private byte[] byte_0;

	private List<object[]> list_0 = new List<object[]>();

	private Class1885 class1885_0;

	private Class1885 class1885_1;

	private Class2224 class2224_0;

	private Class1885 class1885_2;

	public Class2259 TimingElementData
	{
		get
		{
			return class2259_0;
		}
		set
		{
			class2259_0 = value;
		}
	}

	public Class2224 BuildListOfTiming
	{
		get
		{
			return class2224_0;
		}
		set
		{
			class2224_0 = value;
		}
	}

	public Class1885 ExtensionListOfTiming
	{
		get
		{
			return class1885_2;
		}
		set
		{
			class1885_2 = value;
		}
	}

	public uint SlideId
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

	public Class1885 ExtensionListOfSlideIdListEntry
	{
		get
		{
			return class1885_0;
		}
		set
		{
			class1885_0 = value;
		}
	}

	public Class1885 ExtensionListOfCommonSlideData
	{
		get
		{
			return class1885_1;
		}
		set
		{
			class1885_1 = value;
		}
	}

	public List<object[]> RelsToUnknownParts => list_0;
}
