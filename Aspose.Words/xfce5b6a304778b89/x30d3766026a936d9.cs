using System;
using System.Collections;
using System.Reflection;
using Aspose.Words.Tables;

namespace xfce5b6a304778b89;

[DefaultMember("Item")]
internal class x30d3766026a936d9 : ArrayList
{
	private int xc9bdbf0e5ca18249;

	public xc54ca6df458adfc5 xe6d4b1b411ed94b5
	{
		get
		{
			return (xc54ca6df458adfc5)base[xc0c4c459c6ccbd00];
		}
		set
		{
			base[xc0c4c459c6ccbd00] = value;
		}
	}

	internal int x5840ec53f70adb17
	{
		get
		{
			return xc9bdbf0e5ca18249;
		}
		set
		{
			xc9bdbf0e5ca18249 = value;
		}
	}

	private void xe0c60fe89428dfaa(int x78a7603cacf2ae22, int x2238fe9b8f06bd9d, xcb27402694ec8794 xe6de5e5fa2d44af5)
	{
		xc54ca6df458adfc5 xc54ca6df458adfc6 = this.get_xe6d4b1b411ed94b5(x78a7603cacf2ae22);
		xc54ca6df458adfc6.Add(null);
		int num = xc54ca6df458adfc6.Count - 1;
		int num2 = num - 1;
		while (num2 >= x2238fe9b8f06bd9d)
		{
			while (xc54ca6df458adfc6.get_xe6d4b1b411ed94b5(num2).x1a1dda35b3ae703d == CellMerge.Previous)
			{
				num2--;
			}
			xc54ca6df458adfc6.set_xe6d4b1b411ed94b5(num, xc54ca6df458adfc6.get_xe6d4b1b411ed94b5(num2));
			num = num2--;
		}
		xc54ca6df458adfc6.set_xe6d4b1b411ed94b5(x2238fe9b8f06bd9d, xe6de5e5fa2d44af5);
	}

	private void x781d3f725395287c(int x78a7603cacf2ae22, int x7fd9148696d48225)
	{
		for (int i = 0; i < x7fd9148696d48225; i++)
		{
			this.get_xe6d4b1b411ed94b5(x78a7603cacf2ae22).Add(new xcb27402694ec8794());
		}
	}

	internal void x1a1dda35b3ae703d()
	{
		for (int i = 0; i < Count; i++)
		{
			xc54ca6df458adfc5 xc54ca6df458adfc6 = this.get_xe6d4b1b411ed94b5(i);
			for (int j = 0; j < xc54ca6df458adfc6.Count; j++)
			{
				xcb27402694ec8794 xcb27402694ec8795 = xc54ca6df458adfc6.get_xe6d4b1b411ed94b5(j);
				int num = Math.Min(xcb27402694ec8795.xe9fd99df52338f59, Count - i);
				if (num <= 1)
				{
					continue;
				}
				xcb27402694ec8795.x1a1dda35b3ae703d = CellMerge.First;
				for (int k = 1; k < num; k++)
				{
					int num2 = i + k;
					if (j + 1 > this.get_xe6d4b1b411ed94b5(num2).Count)
					{
						x781d3f725395287c(num2, j - this.get_xe6d4b1b411ed94b5(num2).Count + 1);
					}
					else
					{
						xe0c60fe89428dfaa(num2, j, new xcb27402694ec8794());
					}
					xc9bdbf0e5ca18249 = Math.Max(xc9bdbf0e5ca18249, this.get_xe6d4b1b411ed94b5(num2).Count);
					xcb27402694ec8794 xcb27402694ec8796 = this.get_xe6d4b1b411ed94b5(num2).get_xe6d4b1b411ed94b5(j);
					xcb27402694ec8796.x1a1dda35b3ae703d = CellMerge.Previous;
					xcb27402694ec8796.x338a5e6ab7c5595e = xcb27402694ec8795.x338a5e6ab7c5595e;
				}
			}
		}
	}
}
