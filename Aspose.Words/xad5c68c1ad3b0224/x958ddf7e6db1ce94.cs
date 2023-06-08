using System;
using System.Collections;
using xb3013071794e5415;
using xcc8a79815d76af85;

namespace xad5c68c1ad3b0224;

internal abstract class x958ddf7e6db1ce94
{
	private x75cb5ec6f61462cf xfd695d7efdeff44d = new x75cb5ec6f61462cf();

	private int x04797a3841788177;

	private x6128243c276d529b x8f4a54c23a2aaba2;

	private int x3cb8355f2be02ddd = -1;

	private x66e735b434e6b412 x574b2eddfff7d520;

	internal abstract x8f04e4e6e23bd1f5 x13c22d4630b556cf { get; }

	internal x6128243c276d529b x665038dfa8849161 => x8f4a54c23a2aaba2;

	internal x9b87766ad1dbe8d6 x21ad465cfac3f62e => (x9b87766ad1dbe8d6)xc869533ad93d98d3[0];

	internal ArrayList xc869533ad93d98d3 => (ArrayList)xfd695d7efdeff44d.x4ff37084a5d7d57f(x2c127adefb5db3a3.xc869533ad93d98d3);

	internal bool x62819e9fb2110ddc
	{
		get
		{
			return (bool)x1c0c32c5e4d010d3.x4ff37084a5d7d57f(x2c127adefb5db3a3.x62819e9fb2110ddc);
		}
		set
		{
			x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.x62819e9fb2110ddc, value);
		}
	}

	internal x823fa53f2dab6113 x6fb6c0caf80d65aa
	{
		get
		{
			return (x823fa53f2dab6113)x1c0c32c5e4d010d3.x4ff37084a5d7d57f(x2c127adefb5db3a3.xcc203ebd00328bf9);
		}
		set
		{
			x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.xcc203ebd00328bf9, value);
		}
	}

	internal x75cb5ec6f61462cf x1c0c32c5e4d010d3 => xfd695d7efdeff44d;

	internal int x28627c25cb262062
	{
		get
		{
			if (x3cb8355f2be02ddd < 0)
			{
				foreach (x9b87766ad1dbe8d6 item in xc869533ad93d98d3)
				{
					x3cb8355f2be02ddd = Math.Max(x3cb8355f2be02ddd, item.x2205bab75ecf5743);
				}
			}
			return x3cb8355f2be02ddd;
		}
	}

	private x66e735b434e6b412 x3b25b5af52069364
	{
		get
		{
			if (x574b2eddfff7d520 == null)
			{
				x574b2eddfff7d520 = x115aae47c7f4276e.x58a1d09697340faa(this);
			}
			return x574b2eddfff7d520;
		}
	}

	internal void x8e438b1f360b9045(int xe093f46dbfbdd01e)
	{
		switch (x04797a3841788177)
		{
		case 0:
			xfd695d7efdeff44d.x9b050884457cf3b5(x2c127adefb5db3a3.xed481cc115d56292, xe093f46dbfbdd01e);
			break;
		case 1:
			xfd695d7efdeff44d.x9b050884457cf3b5(x2c127adefb5db3a3.x346626c30e7ddb97, xe093f46dbfbdd01e);
			break;
		case 2:
			xfd695d7efdeff44d.x9b050884457cf3b5(x2c127adefb5db3a3.x3ec426f7bc5b3568, xe093f46dbfbdd01e);
			break;
		default:
			throw new ArgumentException("there cannot be more then 3 axis.");
		}
		x04797a3841788177++;
	}

	internal void x40f19e37287f753b(x6128243c276d529b xd5b52cb638a1e057)
	{
		x8f4a54c23a2aaba2 = xd5b52cb638a1e057;
	}

	internal void xe406325e56f74b46(x43c3197706cb18d9 x7458794d854f9b68, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		x3b25b5af52069364.xe406325e56f74b46(x7458794d854f9b68, x0f7b23d1c393aed9);
	}

	internal void x19858496179c0d1c(xc48e9faacc88a3d5 x968685ed781f7a46, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		x3b25b5af52069364.x19858496179c0d1c(x968685ed781f7a46, x0f7b23d1c393aed9);
	}
}
