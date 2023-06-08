using System.Collections;

namespace x6b8130194ad714f7;

internal class xd19834b67eb2af98 : x1985c4f45424d70e
{
	private x21a27d1a7e6b5414 xf10e700548414881;

	private Hashtable x66cd11f407255d70 = new Hashtable();

	public x21a27d1a7e6b5414 xea1a00c57e891448
	{
		get
		{
			return xf10e700548414881;
		}
		set
		{
			xf10e700548414881 = value;
		}
	}

	public object x4ff37084a5d7d57f(object xba08ce632055a1d9)
	{
		if (xba08ce632055a1d9 == null)
		{
			return null;
		}
		object obj = x66cd11f407255d70[xba08ce632055a1d9];
		if (obj == null && xea1a00c57e891448 != null)
		{
			x1985c4f45424d70e xa31eca437f1db8c = xea1a00c57e891448.xa31eca437f1db8c7;
			if (xa31eca437f1db8c != null)
			{
				return xa31eca437f1db8c.x4ff37084a5d7d57f(xba08ce632055a1d9);
			}
		}
		return obj;
	}

	public void x9b050884457cf3b5(object xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		if (xba08ce632055a1d9 != null)
		{
			x66cd11f407255d70[xba08ce632055a1d9] = xbcea506a33cf9111;
		}
	}
}
