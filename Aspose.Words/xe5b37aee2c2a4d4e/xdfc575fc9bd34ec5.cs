using System.Collections;
using System.Reflection;

namespace xe5b37aee2c2a4d4e;

[DefaultMember("Item")]
internal class xdfc575fc9bd34ec5
{
	private readonly ArrayList xddc60c8d74d0f01b = new ArrayList();

	internal x9d761ee3eb0e5b6d xe6d4b1b411ed94b5 => (x9d761ee3eb0e5b6d)xddc60c8d74d0f01b[x7b28e8a789372508];

	internal int xd44988f225497f3a => xddc60c8d74d0f01b.Count;

	internal xdfc575fc9bd34ec5 x8b61531c8ea35b85()
	{
		xdfc575fc9bd34ec5 xdfc575fc9bd34ec6 = new xdfc575fc9bd34ec5();
		for (int i = 0; i < xd44988f225497f3a; i++)
		{
			xdfc575fc9bd34ec6.xd6b6ed77479ef68c(this.get_xe6d4b1b411ed94b5(i).x8b61531c8ea35b85());
		}
		return xdfc575fc9bd34ec6;
	}

	internal void xd6b6ed77479ef68c(x9d761ee3eb0e5b6d x520748205b288669)
	{
		xd6b6ed77479ef68c(x520748205b288669, 1);
	}

	internal void xd6b6ed77479ef68c(x9d761ee3eb0e5b6d x520748205b288669, int x10f4d88af727adbc)
	{
		for (int i = 0; i < x10f4d88af727adbc; i++)
		{
			xddc60c8d74d0f01b.Add(x520748205b288669.x8b61531c8ea35b85());
		}
	}

	internal void x7121e9e177952651(int xc0c4c459c6ccbd00)
	{
		xddc60c8d74d0f01b.RemoveAt(xc0c4c459c6ccbd00);
	}

	internal void x6e8f833777ff313e()
	{
		x7121e9e177952651(xd44988f225497f3a - 1);
	}

	internal void xf84614781814c042(int xc902e92728a6a4bd)
	{
		int num = xd44988f225497f3a - xc902e92728a6a4bd;
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				x6e8f833777ff313e();
			}
		}
		else if (num < 0)
		{
			for (int j = num; j < 0; j++)
			{
				xd6b6ed77479ef68c(new x9d761ee3eb0e5b6d());
			}
		}
	}
}
