using System.Collections;
using xf9a9481c3f63a419;

namespace x38d3ef1c1d247e82;

internal class x94c83b1ca7961561 : x1e9b3e0e8864e135, IEnumerable
{
	private readonly IDictionary x579c7d284bd868ba;

	public int xd44988f225497f3a => x579c7d284bd868ba.Count;

	public x94c83b1ca7961561()
	{
		x579c7d284bd868ba = new Hashtable();
	}

	public x94c83b1ca7961561(int capacity)
	{
		x579c7d284bd868ba = new Hashtable(capacity);
	}

	private x94c83b1ca7961561(IDictionary dictionary)
	{
		x579c7d284bd868ba = dictionary;
	}

	public static x94c83b1ca7961561 x964c8ab59da5fc93()
	{
		return new x94c83b1ca7961561(xd51c34d05311eee3.xdb04a310bbb29cff());
	}

	public bool xd6b6ed77479ef68c(object xccb63ca5f63dc470)
	{
		object key = x2d425143e1f95bba.x62ae61bd64b94d52(xccb63ca5f63dc470);
		if (x579c7d284bd868ba.Contains(key))
		{
			return false;
		}
		x579c7d284bd868ba.Add(key, xccb63ca5f63dc470);
		return true;
	}

	public void xa9d636b00ff486b7()
	{
		x579c7d284bd868ba.Clear();
	}

	public bool x263d579af1d0d43f(object xccb63ca5f63dc470)
	{
		return x579c7d284bd868ba.Contains(x2d425143e1f95bba.x62ae61bd64b94d52(xccb63ca5f63dc470));
	}

	public IEnumerator GetEnumerator()
	{
		return x579c7d284bd868ba.Values.GetEnumerator();
	}

	public bool x52b190e626f65140(object xccb63ca5f63dc470)
	{
		xccb63ca5f63dc470 = x2d425143e1f95bba.x62ae61bd64b94d52(xccb63ca5f63dc470);
		if (!x579c7d284bd868ba.Contains(xccb63ca5f63dc470))
		{
			return false;
		}
		x579c7d284bd868ba.Remove(xccb63ca5f63dc470);
		return true;
	}
}
