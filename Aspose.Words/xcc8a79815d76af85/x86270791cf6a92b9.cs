using System;

namespace xcc8a79815d76af85;

internal abstract class x86270791cf6a92b9 : IComparable
{
	private int x57d3c0a64c1df452;

	private xd620087af5172910 x89289876f91be771;

	public int xd1bdf42207dd3638 => x57d3c0a64c1df452;

	public xd620087af5172910 x2bd4228892f25674 => x89289876f91be771;

	public abstract string StringValue { get; }

	public abstract float FloatValue { get; }

	internal x86270791cf6a92b9(int index, xd620087af5172910 valueType)
	{
		x57d3c0a64c1df452 = index;
		x89289876f91be771 = valueType;
	}

	public int CompareTo(object obj)
	{
		return FloatValue.CompareTo(((x86270791cf6a92b9)obj).FloatValue);
	}
}
