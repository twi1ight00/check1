using System.Collections;

namespace xeb665d1aeef09d64;

internal abstract class xe030f6981d09423d : xe26a2357ce987196
{
	private readonly Hashtable x0f62a530ebbd1b7d;

	protected xe030f6981d09423d(Hashtable table)
	{
		x0f62a530ebbd1b7d = table;
	}

	internal override void x57bf52bb3d1c2d43(ArrayList xc6815cd4fdf9719d)
	{
		ArrayList arrayList = new ArrayList();
		foreach (int item in xc6815cd4fdf9719d)
		{
			if (x0f62a530ebbd1b7d.ContainsKey(item))
			{
				arrayList.Add(x0f62a530ebbd1b7d[item]);
			}
		}
		foreach (int item2 in arrayList)
		{
			xc6815cd4fdf9719d.Add(item2);
		}
	}
}
