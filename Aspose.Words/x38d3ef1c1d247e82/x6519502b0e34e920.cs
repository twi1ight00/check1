using System.Collections;
using x6c95d9cf46ff5f25;

namespace x38d3ef1c1d247e82;

internal class x6519502b0e34e920 : x1e9b3e0e8864e135, IEnumerable
{
	private readonly SortedList x07febcac547c71cf;

	public int xd44988f225497f3a => x07febcac547c71cf.Count;

	public x6519502b0e34e920()
	{
		x07febcac547c71cf = new SortedList();
	}

	private x6519502b0e34e920(SortedList sortedList)
	{
		x07febcac547c71cf = sortedList;
	}

	public static x6519502b0e34e920 x5fd350d97e3d7ce7()
	{
		return new x6519502b0e34e920(new SortedList(xebbd06a8e6c039fe.xb9715d2f06b63cf0));
	}

	public static x6519502b0e34e920 x820665812c4c07a7()
	{
		return new x6519502b0e34e920(new SortedList(xa1fe40c1efb73872.xb9715d2f06b63cf0));
	}

	public bool xd6b6ed77479ef68c(object xccb63ca5f63dc470)
	{
		object key = x2d425143e1f95bba.x62ae61bd64b94d52(xccb63ca5f63dc470);
		if (x07febcac547c71cf.Contains(key))
		{
			return false;
		}
		x07febcac547c71cf.Add(key, xccb63ca5f63dc470);
		return true;
	}

	public void xa9d636b00ff486b7()
	{
		x07febcac547c71cf.Clear();
	}

	public bool x263d579af1d0d43f(object xccb63ca5f63dc470)
	{
		return x07febcac547c71cf.Contains(x2d425143e1f95bba.x62ae61bd64b94d52(xccb63ca5f63dc470));
	}

	public IEnumerator GetEnumerator()
	{
		return x07febcac547c71cf.GetValueList().GetEnumerator();
	}

	public bool x52b190e626f65140(object xccb63ca5f63dc470)
	{
		xccb63ca5f63dc470 = x2d425143e1f95bba.x62ae61bd64b94d52(xccb63ca5f63dc470);
		if (!x07febcac547c71cf.Contains(xccb63ca5f63dc470))
		{
			return false;
		}
		x07febcac547c71cf.Remove(xccb63ca5f63dc470);
		return true;
	}
}
