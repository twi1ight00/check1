using System.Text;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x7cd71466ce904867;

internal class xd7fbbc457ace2480 : x84f077c4a21fdc06
{
	private string x2b9c3f93d8888ad2;

	private xd67056cdc9587a61 xc67369e42f67472e;

	private x0a80b8c2d1e8cf13 xd513984ed6f4bb82;

	private bool x0cdb19194ffc0651;

	public string xecdb691bd5b6abb3 => x2b9c3f93d8888ad2;

	public xd67056cdc9587a61 x77dc43988eaceb1c => xc67369e42f67472e;

	public void x45f449c33b7ded61(string xb41faee6912a2313)
	{
		if (xb41faee6912a2313 == null)
		{
			xb41faee6912a2313 = string.Empty;
		}
		xd513984ed6f4bb82 = new x0a80b8c2d1e8cf13(new x115139807e6482f7(xb41faee6912a2313));
		x0cdb19194ffc0651 = xd513984ed6f4bb82.x47f176deff0d42e2();
	}

	public bool x47f176deff0d42e2()
	{
		if (!x0cdb19194ffc0651)
		{
			return false;
		}
		bool flag = true;
		StringBuilder stringBuilder = new StringBuilder();
		do
		{
			int num = (int)xd513984ed6f4bb82.x35cfcea4890f4e7d;
			xd67056cdc9587a61 xd67056cdc9587a62 = x6d15ce7622d5048b(num);
			if (flag)
			{
				xc67369e42f67472e = xd67056cdc9587a62;
				flag = false;
			}
			if (xd67056cdc9587a62 == xc67369e42f67472e)
			{
				stringBuilder.Append(xdf3a1f89dca325a3.x251dbcb3221739c5(num));
				continue;
			}
			x2b9c3f93d8888ad2 = stringBuilder.ToString();
			return true;
		}
		while (xd513984ed6f4bb82.x47f176deff0d42e2());
		x2b9c3f93d8888ad2 = stringBuilder.ToString();
		x0cdb19194ffc0651 = false;
		return true;
	}

	public override string ToString()
	{
		return xecdb691bd5b6abb3;
	}

	private static bool x8615dd3f8ce8e460(int x3c4da2980d043c95)
	{
		if (x3c4da2980d043c95 != 10)
		{
			return x3c4da2980d043c95 == 13;
		}
		return true;
	}

	private static bool x1ad61cbc9c5346ce(int x3c4da2980d043c95)
	{
		if (x3c4da2980d043c95 != 32)
		{
			return x3c4da2980d043c95 == 9;
		}
		return true;
	}

	private static xd67056cdc9587a61 x6d15ce7622d5048b(int x940b70f481656041)
	{
		if (x1ad61cbc9c5346ce(x940b70f481656041))
		{
			return xd67056cdc9587a61.x3e1feffd8ca6feb2;
		}
		if (x8615dd3f8ce8e460(x940b70f481656041))
		{
			return xd67056cdc9587a61.xcd42aad2332fa37b;
		}
		return xd67056cdc9587a61.xe89828e8b8199286;
	}
}
