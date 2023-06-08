using System;
using System.Collections;
using System.Drawing;
using x74500b509de15565;

namespace xf269d97e8a02e911;

internal class xfc986ef9bf7fc434 : xbadcaf18b423f918
{
	private int x4b088f70e8b96620;

	private RectangleF x930e7264e89b1eb5 = RectangleF.Empty;

	private readonly ArrayList x32b42f50736dcc6f = new ArrayList();

	public x1c26f4f3c6f98ecc x3146d638ec378671 => x1c26f4f3c6f98ecc.x4b94e58155458175;

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

	internal RectangleF x6ae4612a8469678e
	{
		get
		{
			return x930e7264e89b1eb5;
		}
		set
		{
			x930e7264e89b1eb5 = value;
		}
	}

	internal ArrayList x58efbacd665a3e59 => x32b42f50736dcc6f;

	internal void xda72e69795827549(xa1f7a3d42bca7cb8 xe134235b3526fa75)
	{
		try
		{
			xe134235b3526fa75.ReadInt16();
			xe134235b3526fa75.ReadInt16();
			xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt16();
			int num = xe134235b3526fa75.ReadInt16();
			xe134235b3526fa75.ReadInt16();
			x930e7264e89b1eb5 = xe134235b3526fa75.xf1575d122ac7f90e();
			x32b42f50736dcc6f.Clear();
			for (int i = 0; i < num; i++)
			{
				int num2 = xe134235b3526fa75.ReadUInt16();
				int num3 = xe134235b3526fa75.ReadUInt16();
				int num4 = xe134235b3526fa75.ReadUInt16();
				for (int j = 0; j < num2 / 2; j++)
				{
					int num5 = xe134235b3526fa75.ReadUInt16();
					int num6 = xe134235b3526fa75.ReadUInt16();
					x32b42f50736dcc6f.Add(new RectangleF(num5, num3, num6 - num5, num4 - num3));
				}
				xe134235b3526fa75.ReadUInt16();
			}
		}
		catch (Exception)
		{
		}
	}

	internal void x5023e134b4415253(x28a5d52551b64191 xe134235b3526fa75)
	{
		xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt32();
		int num = xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt32();
		x930e7264e89b1eb5 = xe134235b3526fa75.x70a5bafbe8fbfeb2();
		x32b42f50736dcc6f.Clear();
		for (int i = 0; i < num; i++)
		{
			x32b42f50736dcc6f.Add(xe134235b3526fa75.x70a5bafbe8fbfeb2());
		}
	}
}
