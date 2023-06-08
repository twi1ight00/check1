using System;
using x38a89dee67fc7a16;

namespace x5794c252ba25e723;

internal class xdf4d4502e7d76522
{
	private float xbc445cc2cc6088dd = -1f;

	private xaf230aa026fb819b[] x8faf6f46ac664b71;

	private x1f2ba9b7cb678190 x7286375b31f8bb61;

	private xf276f6a75b584d31 xe9902cfb8b8d2131;

	public bool xdc6051967ab838b7
	{
		get
		{
			if (xbc445cc2cc6088dd >= 0f)
			{
				return xbc445cc2cc6088dd <= 1f;
			}
			return false;
		}
	}

	public float xd3f06edc344811a0
	{
		get
		{
			return xbc445cc2cc6088dd;
		}
		set
		{
			xbc445cc2cc6088dd = value;
		}
	}

	public xaf230aa026fb819b[] xdd55432873547248
	{
		get
		{
			if (x8faf6f46ac664b71 == null)
			{
				x8faf6f46ac664b71 = new xaf230aa026fb819b[0];
			}
			return x8faf6f46ac664b71;
		}
		set
		{
			x8faf6f46ac664b71 = value;
		}
	}

	public x1f2ba9b7cb678190 x45f18b4d2446e7cd
	{
		get
		{
			if (x7286375b31f8bb61 == null)
			{
				x7286375b31f8bb61 = new x1f2ba9b7cb678190();
			}
			return x7286375b31f8bb61;
		}
		set
		{
			x7286375b31f8bb61 = value;
		}
	}

	public xf276f6a75b584d31 xf276f6a75b584d31
	{
		get
		{
			return xe9902cfb8b8d2131;
		}
		set
		{
			xe9902cfb8b8d2131 = value;
		}
	}

	public void xbe789c544c465680(xaf230aa026fb819b[] x23029bec4dd3e949)
	{
		if (x23029bec4dd3e949 == null)
		{
			throw new ArgumentNullException("colorMaps");
		}
		if (x23029bec4dd3e949.Length != 0)
		{
			if (xdd55432873547248.Length == 0)
			{
				xdd55432873547248 = x23029bec4dd3e949;
				return;
			}
			xaf230aa026fb819b[] array = new xaf230aa026fb819b[xdd55432873547248.Length + x23029bec4dd3e949.Length];
			xdd55432873547248.CopyTo(array, 0);
			x23029bec4dd3e949.CopyTo(array, xdd55432873547248.Length);
			xdd55432873547248 = array;
		}
	}

	public void xb526ae6a95468f9a(x1f2ba9b7cb678190 xd6ee666025336f11)
	{
		if (xd6ee666025336f11 == null)
		{
			throw new ArgumentNullException("colorMatrix");
		}
		x45f18b4d2446e7cd = x1f2ba9b7cb678190.x490e30087768649f(x45f18b4d2446e7cd, xd6ee666025336f11);
	}

	public void x8f8e71f6dc88af5a()
	{
		xbc445cc2cc6088dd = -1f;
	}
}
