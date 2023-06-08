using System.Collections;
using System.Reflection;
using System.Text;

namespace x722d80085b19d13f;

[DefaultMember("Item")]
internal class xf167a284a47d2590
{
	private int x9971322f22d748de;

	private ArrayList x047f3d74dc5f5da7 = new ArrayList();

	internal StringBuilder xf9ea3b8d9198b0cc
	{
		get
		{
			int num = x9971322f22d748de - x047f3d74dc5f5da7.Count + 1;
			for (int i = 0; i < num; i++)
			{
				x047f3d74dc5f5da7.Add(new StringBuilder());
			}
			return this.get_xe6d4b1b411ed94b5(x9971322f22d748de);
		}
	}

	internal int x356b85d0f5cf3f6f
	{
		get
		{
			return x9971322f22d748de;
		}
		set
		{
			x9971322f22d748de = value;
		}
	}

	internal int xd44988f225497f3a => x047f3d74dc5f5da7.Count;

	internal StringBuilder xe6d4b1b411ed94b5 => (StringBuilder)x047f3d74dc5f5da7[xc0c4c459c6ccbd00];

	internal xf167a284a47d2590()
	{
	}
}
