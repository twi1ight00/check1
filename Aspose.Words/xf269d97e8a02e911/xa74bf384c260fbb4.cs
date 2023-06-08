using x74500b509de15565;

namespace xf269d97e8a02e911;

internal class xa74bf384c260fbb4 : xbadcaf18b423f918
{
	private x34f926c5b38e8b7d[] x6e065206ad69f012;

	private int x4b088f70e8b96620;

	public int x7efbe0a2dc0d335f
	{
		get
		{
			return x4b088f70e8b96620;
		}
		set
		{
			x4b088f70e8b96620 = value;
		}
	}

	x1c26f4f3c6f98ecc xbadcaf18b423f918.xfae96ceb2d396a78 => x1c26f4f3c6f98ecc.xbb0f59489b846f6f;

	internal x34f926c5b38e8b7d[] x17a6c74a7a9447f6 => x6e065206ad69f012;

	internal xa74bf384c260fbb4()
	{
	}

	internal void x5023e134b4415253(x28a5d52551b64191 xe134235b3526fa75)
	{
		x4b088f70e8b96620 = xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt16();
		int num = xe134235b3526fa75.ReadInt16();
		x6e065206ad69f012 = new x34f926c5b38e8b7d[num];
		for (int i = 0; i < num; i++)
		{
			x6e065206ad69f012[i] = new x34f926c5b38e8b7d(xe134235b3526fa75.ReadInt32());
		}
	}
}
