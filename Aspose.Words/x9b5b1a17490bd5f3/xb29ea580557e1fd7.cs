using System;
using System.Collections;
using System.Reflection;
using Aspose.Words.Tables;
using x2697283ff424107e;
using x643046e3f004c49f;
using x7c4557e104065fc9;

namespace x9b5b1a17490bd5f3;

[DefaultMember("Item")]
internal class xb29ea580557e1fd7 : ArrayList
{
	private const int x6e7f230f86e8b472 = 0;

	private const int x4c1923fed2a5eb0c = 1;

	private const int x653f38cbd7899529 = 2;

	private readonly x9d6b37cac59aa2e2 x48154453a08515ea;

	private readonly PreferredWidth x7da4fdc86e3c460d;

	private readonly double x542ec23a3d6a14e3;

	private readonly double x5ab7b7ddba2ab864;

	private readonly double x528af537a1cdc5b3;

	private readonly TableAlignment x72e79137e9213c8c;

	private int xc9bdbf0e5ca18249;

	private bool x350ffaaefa6d463c;

	private bool xa80a102ec3427a5b;

	internal x9d6b37cac59aa2e2 x40212106aad8a8b0 => x48154453a08515ea;

	public x4e51edddc028898f xe6d4b1b411ed94b5
	{
		get
		{
			return (x4e51edddc028898f)base[xc0c4c459c6ccbd00];
		}
		set
		{
			base[xc0c4c459c6ccbd00] = value;
		}
	}

	internal int x5840ec53f70adb17 => xc9bdbf0e5ca18249;

	internal PreferredWidth xc6a8342933c4e987 => x7da4fdc86e3c460d;

	internal double xeae235558dc44397 => x542ec23a3d6a14e3;

	internal double xe644ac50cf36ac78 => x5ab7b7ddba2ab864;

	internal double xd2905906dc0619f2 => x528af537a1cdc5b3;

	internal TableAlignment x78a8158ce97f2a67 => x72e79137e9213c8c;

	private x4e51edddc028898f x39c11fce0571e063 => this.get_xe6d4b1b411ed94b5(Count - 1);

	internal xb29ea580557e1fd7(x9d6b37cac59aa2e2 tableNode, string parentAlignment)
	{
		x48154453a08515ea = tableNode;
		x7da4fdc86e3c460d = x495fdb45f3d92b70.x844d4319ee50b6d6(x48154453a08515ea.x75658b3f8be4005c("width", ""));
		x542ec23a3d6a14e3 = x48154453a08515ea.x75658b3f8be4005c("border", 0);
		x5ab7b7ddba2ab864 = x48154453a08515ea.x75658b3f8be4005c("cellpadding", 1);
		x528af537a1cdc5b3 = x48154453a08515ea.x75658b3f8be4005c("cellspacing", 2);
		x72e79137e9213c8c = x495fdb45f3d92b70.xa4258984257f6241(parentAlignment);
		string text = x7778af522baacfda.xaca4ebd805fc7700(tableNode.x75658b3f8be4005c("style", string.Empty));
		if (text.Length != 0)
		{
			xa3fc7dcdc8182ff6 x36c843bef78b260f = new xa3fc7dcdc8182ff6(text);
			x72e79137e9213c8c = x495fdb45f3d92b70.xd55b823b4c121cee(x36c843bef78b260f);
		}
		if (x48154453a08515ea.x75658b3f8be4005c("align", "").Length != 0)
		{
			x72e79137e9213c8c = x495fdb45f3d92b70.xa4258984257f6241(x48154453a08515ea.x75658b3f8be4005c("align", parentAlignment));
		}
		x53ed331c1f3b8fda(tableNode);
		if (xa80a102ec3427a5b)
		{
			x1a1dda35b3ae703d();
		}
		xb05fecf4f00720fc();
	}

	private void x53ed331c1f3b8fda(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		if (xd01fc8d304d05d80(xda5bf54deb817e37, xa59013d234619c58: true))
		{
			for (int i = 0; i < xda5bf54deb817e37.x8898b61a98eb027f.xd44988f225497f3a; i++)
			{
				x53ed331c1f3b8fda(xda5bf54deb817e37.x8898b61a98eb027f.get_xe6d4b1b411ed94b5(i));
			}
			xd01fc8d304d05d80(xda5bf54deb817e37, xa59013d234619c58: false);
		}
	}

	private bool xd01fc8d304d05d80(x9d6b37cac59aa2e2 xda5bf54deb817e37, bool xa59013d234619c58)
	{
		switch (xda5bf54deb817e37.x759aa16c2016a289.ToUpper())
		{
		case "TABLE":
			if (xa59013d234619c58)
			{
				if (x350ffaaefa6d463c)
				{
					return false;
				}
				x350ffaaefa6d463c = true;
			}
			break;
		case "TR":
			if (xa59013d234619c58)
			{
				Add(new x4e51edddc028898f(xda5bf54deb817e37));
			}
			else
			{
				xc9bdbf0e5ca18249 = Math.Max(xc9bdbf0e5ca18249, x39c11fce0571e063.Count);
			}
			break;
		case "TH":
		case "TD":
		{
			if (!xa59013d234619c58 || Count == 0)
			{
				break;
			}
			x5125118f43aba344 x5125118f43aba345 = new x5125118f43aba344(xda5bf54deb817e37);
			if (!xb1e2c9a68308ad60(x5125118f43aba345))
			{
				break;
			}
			if (x5125118f43aba345.xe9fd99df52338f59 > 1)
			{
				xa80a102ec3427a5b = true;
			}
			if (x5125118f43aba345.x2f4795c5e4c1617e <= 1)
			{
				break;
			}
			x5125118f43aba345.x338a5e6ab7c5595e = CellMerge.First;
			int num = x5125118f43aba345.x2f4795c5e4c1617e;
			while (--num > 0)
			{
				x5125118f43aba344 x5125118f43aba346 = new x5125118f43aba344(xda5bf54deb817e37);
				x5125118f43aba346.x338a5e6ab7c5595e = CellMerge.Previous;
				x5125118f43aba346.x4da4b13c8bf87e9a = x5125118f43aba345;
				if (!xb1e2c9a68308ad60(x5125118f43aba346))
				{
					break;
				}
			}
			break;
		}
		}
		return true;
	}

	private bool xb1e2c9a68308ad60(x5125118f43aba344 xe6de5e5fa2d44af5)
	{
		if (x39c11fce0571e063.Count >= 63)
		{
			return false;
		}
		x39c11fce0571e063.Add(xe6de5e5fa2d44af5);
		return true;
	}

	private void xe0c60fe89428dfaa(int x78a7603cacf2ae22, int x2238fe9b8f06bd9d, x5125118f43aba344 xe6de5e5fa2d44af5)
	{
		x4e51edddc028898f x4e51edddc028898f2 = this.get_xe6d4b1b411ed94b5(x78a7603cacf2ae22);
		x4e51edddc028898f2.Add(null);
		int num = x4e51edddc028898f2.Count - 1;
		int num2 = num - 1;
		while (num2 >= x2238fe9b8f06bd9d)
		{
			while (x4e51edddc028898f2.get_xe6d4b1b411ed94b5(num2).x1a1dda35b3ae703d != 0)
			{
				num2--;
			}
			x4e51edddc028898f2.set_xe6d4b1b411ed94b5(num, x4e51edddc028898f2.get_xe6d4b1b411ed94b5(num2));
			num = num2--;
		}
		x4e51edddc028898f2.set_xe6d4b1b411ed94b5(x2238fe9b8f06bd9d, xe6de5e5fa2d44af5);
	}

	private void x781d3f725395287c(int x78a7603cacf2ae22, int x7fd9148696d48225)
	{
		for (int i = 0; i < x7fd9148696d48225; i++)
		{
			this.get_xe6d4b1b411ed94b5(x78a7603cacf2ae22).Add(new x5125118f43aba344());
		}
	}

	private void xb05fecf4f00720fc()
	{
		for (int i = 0; i < Count; i++)
		{
			while (this.get_xe6d4b1b411ed94b5(i).Count < xc9bdbf0e5ca18249)
			{
				this.get_xe6d4b1b411ed94b5(i).Add(new x5125118f43aba344());
			}
		}
	}

	private void x1a1dda35b3ae703d()
	{
		for (int i = 0; i < Count; i++)
		{
			x4e51edddc028898f x4e51edddc028898f2 = this.get_xe6d4b1b411ed94b5(i);
			for (int j = 0; j < x4e51edddc028898f2.Count; j++)
			{
				x5125118f43aba344 x5125118f43aba345 = x4e51edddc028898f2.get_xe6d4b1b411ed94b5(j);
				int num = Math.Min(x5125118f43aba345.xe9fd99df52338f59, Count - i);
				if (num <= 1)
				{
					continue;
				}
				x5125118f43aba345.x1a1dda35b3ae703d = CellMerge.First;
				for (int k = 1; k < num; k++)
				{
					int num2 = i + k;
					if (j + 1 > this.get_xe6d4b1b411ed94b5(num2).Count)
					{
						x781d3f725395287c(num2, j - this.get_xe6d4b1b411ed94b5(num2).Count + 1);
					}
					else if (this.get_xe6d4b1b411ed94b5(num2).get_xe6d4b1b411ed94b5(j).x338a5e6ab7c5595e != CellMerge.Previous)
					{
						xe0c60fe89428dfaa(num2, j, new x5125118f43aba344());
					}
					xc9bdbf0e5ca18249 = Math.Max(xc9bdbf0e5ca18249, this.get_xe6d4b1b411ed94b5(num2).Count);
					x5125118f43aba344 x5125118f43aba346 = this.get_xe6d4b1b411ed94b5(num2).get_xe6d4b1b411ed94b5(j);
					x5125118f43aba346.x1a1dda35b3ae703d = CellMerge.Previous;
					x5125118f43aba346.xf041dffa93734047 = x5125118f43aba345;
					x5125118f43aba346.x338a5e6ab7c5595e = x5125118f43aba345.x338a5e6ab7c5595e;
					x5125118f43aba346.x4da4b13c8bf87e9a = x5125118f43aba345.x4da4b13c8bf87e9a;
				}
			}
		}
	}
}
