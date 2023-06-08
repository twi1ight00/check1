using System.Collections;
using System.Reflection;

namespace x9db5f2e5af3d596e;

[DefaultMember("Item")]
internal class xdb4d596cc6b8659f : ArrayList
{
	public xf8cef531dae89ea3 xe6d4b1b411ed94b5
	{
		get
		{
			return (xf8cef531dae89ea3)base[xc0c4c459c6ccbd00];
		}
		set
		{
			base[xc0c4c459c6ccbd00] = value;
		}
	}

	internal bool xd538fa592193218b(int xba08ce632055a1d9)
	{
		for (int i = 0; i < Count; i++)
		{
			if (this.get_xe6d4b1b411ed94b5(i).xbc5dc59d0d9b620d(xba08ce632055a1d9))
			{
				return true;
			}
		}
		return false;
	}
}
