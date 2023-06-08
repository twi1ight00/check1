using System.Collections;

namespace x53eb9320ebbb8395;

internal class xdafb1884dd39ffcb
{
	private readonly Hashtable x6ab7272beb21e992 = new Hashtable();

	internal IEnumerable x68bd1387be2e3e2d => x6ab7272beb21e992.Keys;

	internal void x74f5a1ef3906e23c()
	{
		x6ab7272beb21e992.Clear();
	}

	internal void xdad4105ec91aae57(object xa59bff7708de3a18)
	{
		object obj = x6ab7272beb21e992[xa59bff7708de3a18];
		if (obj != null)
		{
			int num = (int)obj;
			x6ab7272beb21e992[xa59bff7708de3a18] = ++num;
		}
		else
		{
			x6ab7272beb21e992.Add(xa59bff7708de3a18, 1);
		}
	}

	internal void xb6910a2b7b542ffb(object xa59bff7708de3a18)
	{
		object obj = x6ab7272beb21e992[xa59bff7708de3a18];
		if (obj != null)
		{
			int num = (int)obj;
			if (num > 0)
			{
				num--;
			}
			if (num == 0)
			{
				x6ab7272beb21e992.Remove(xa59bff7708de3a18);
			}
			else
			{
				x6ab7272beb21e992[xa59bff7708de3a18] = num;
			}
		}
	}

	internal bool xdbf8965584c07a90(object xa59bff7708de3a18)
	{
		return x6ab7272beb21e992.ContainsKey(xa59bff7708de3a18);
	}
}
