using System.Collections;
using System.IO;

namespace x1a62aaf14e3c5909;

internal class x7036f104bc5c45f0 : xc93de5b84cb7a11f
{
	private readonly ArrayList x1fd3fe91973c232e = new ArrayList();

	private xfbb3f4be330f4086 xe1b9c2e6c31f3c20(int xc8f6fc994c5e1a4f)
	{
		if (x1fd3fe91973c232e.Count == 0)
		{
			return null;
		}
		return (xfbb3f4be330f4086)x1fd3fe91973c232e[((xc8f6fc994c5e1a4f > x1fd3fe91973c232e.Count) ? x1fd3fe91973c232e.Count : xc8f6fc994c5e1a4f) - 1];
	}

	xfbb3f4be330f4086 xc93de5b84cb7a11f.x590497a2b838b652(int xc8f6fc994c5e1a4f)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xe1b9c2e6c31f3c20
		return this.xe1b9c2e6c31f3c20(xc8f6fc994c5e1a4f);
	}

	private int x3e6724484e60ec90(xfbb3f4be330f4086 xd1741b157ea7d032)
	{
		x1fd3fe91973c232e.Add(xd1741b157ea7d032);
		return x1fd3fe91973c232e.Count;
	}

	int xc93de5b84cb7a11f.xcfcc704945beca71(xfbb3f4be330f4086 xd1741b157ea7d032)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x3e6724484e60ec90
		return this.x3e6724484e60ec90(xd1741b157ea7d032);
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b, int x62ccf2f5b04cb08c)
	{
		foreach (xfbb3f4be330f4086 item in x1fd3fe91973c232e)
		{
			item.x62ccf2f5b04cb08c = (uint)x62ccf2f5b04cb08c;
			item.x6210059f049f0d48(xbdfb620b7167944b);
		}
	}
}
