using System;
using System.Collections;
using System.Text;
using Aspose.Words;
using x28925c9b27b37a46;

namespace xfbd1009a0cbb9842;

internal class x948832640e0e1725 : x8b9b7e0edc8c7c4f
{
	private StringBuilder x206140170bd1cb62 = new StringBuilder();

	private StringBuilder x6ac803642fac7471 = new StringBuilder();

	private readonly StringBuilder x738107d263b18706 = new StringBuilder();

	private readonly ArrayList x4ff54db11f63ec8d = new ArrayList();

	private readonly Paragraph xf6369bd92887b92e;

	private Run xbe92fd9b2aff2778;

	private Run x1da164b06673f8db;

	private Run xb91e78c6fefd509b;

	private bool xce154b1510b027da;

	private x43bb7ecffe7e5855 xd9f02891a3463928;

	private static readonly int[] x104d472a424fedf8;

	private bool x1d59bafe2f9e84d5 => xd9f02891a3463928 != null;

	static x948832640e0e1725()
	{
		int num = Run.xfc7b12804e684767.Length;
		x104d472a424fedf8 = new int[num + 1];
		Array.Copy(Run.xfc7b12804e684767, x104d472a424fedf8, num);
		x104d472a424fedf8[num] = 265;
		Array.Sort(x104d472a424fedf8);
	}

	internal x948832640e0e1725(IEnumerable resultNodes, Paragraph startParagraph, Paragraph endParagraph)
		: base(resultNodes, startParagraph)
	{
		xf6369bd92887b92e = endParagraph;
	}

	internal void x0179a04e11cec04d(x43bb7ecffe7e5855 x58d5aed105ad0745, Paragraph x1786d39c5802073f)
	{
		xd9f02891a3463928 = x58d5aed105ad0745;
		while (x58d5aed105ad0745.x47f176deff0d42e2() && x47f176deff0d42e2())
		{
			if (base.xbad74afa42d95f36)
			{
				Paragraph paragraph = (x58d5aed105ad0745.xbad74afa42d95f36 ? x58d5aed105ad0745.xc4d960d0b07339fc : x58d5aed105ad0745.x6b1ebac4b985013b);
				x56641f6b32c0e21b(base.xc4d960d0b07339fc, paragraph.x1a78664fa10a3755, x58d5aed105ad0745.xeedad81aaed42a76);
				x2024af4f57d3224f();
				x58d5aed105ad0745.x45277e5380a187db();
			}
			else if (!xce154b1510b027da)
			{
				xf638e0702840dc28(x58d5aed105ad0745.xeedad81aaed42a76, x91cdbdcb1db8f827: false);
				if (x58d5aed105ad0745.xbad74afa42d95f36)
				{
					xe130132888d3488c();
					x58d5aed105ad0745.x75be698bf0c3a5c5();
				}
			}
		}
		x642ff670f83b5343();
		xf2ad3e62d62b4107();
		x56641f6b32c0e21b(xf6369bd92887b92e, x1786d39c5802073f.x1a78664fa10a3755, x1786d39c5802073f.x344511c4e4ce09da);
		if (base.x6b1ebac4b985013b != xf6369bd92887b92e)
		{
			x56641f6b32c0e21b(base.x6b1ebac4b985013b, x58d5aed105ad0745.x6b1ebac4b985013b.x1a78664fa10a3755, null);
		}
		xd9f02891a3463928 = null;
	}

	private void xf638e0702840dc28(xeedad81aaed42a76 x789564759d365819, bool x91cdbdcb1db8f827)
	{
		if (xbe92fd9b2aff2778 == null || !xbe92fd9b2aff2778.xeedad81aaed42a76.Equals(x789564759d365819, x104d472a424fedf8))
		{
			xac2ecf385ee5bd30();
			if (x206140170bd1cb62.Length == 0)
			{
				xbe92fd9b2aff2778 = null;
				return;
			}
			xbe92fd9b2aff2778 = new Run(x1da164b06673f8db.Document, string.Empty, x6f83e5bc997d2b34(x789564759d365819, x1da164b06673f8db.xeedad81aaed42a76));
			x1da164b06673f8db.ParentNode.InsertBefore(xbe92fd9b2aff2778, x1da164b06673f8db);
		}
		if (x206140170bd1cb62.Length != 0)
		{
			x738107d263b18706.Append(x206140170bd1cb62.ToString());
			xcf95ba2d669183a2();
		}
		if (x91cdbdcb1db8f827 || base.x273d95283e8fc8d2)
		{
			xac2ecf385ee5bd30();
			xbe92fd9b2aff2778 = null;
		}
	}

	private static xeedad81aaed42a76 x6f83e5bc997d2b34(xeedad81aaed42a76 xafcf4868722b4b6f, xeedad81aaed42a76 x1270cc91498bcc77)
	{
		xeedad81aaed42a76 xeedad81aaed42a = (xeedad81aaed42a76)xafcf4868722b4b6f.x8b61531c8ea35b85();
		x1270cc91498bcc77.x456b2c186131b981(265, xeedad81aaed42a);
		return xeedad81aaed42a;
	}

	private static void x56641f6b32c0e21b(Paragraph x31e6518f5e08db6c, x1a78664fa10a3755 x062aae8c9613eeaa, xeedad81aaed42a76 x789564759d365819)
	{
		x31e6518f5e08db6c.x1a78664fa10a3755 = (x1a78664fa10a3755)x062aae8c9613eeaa.x8b61531c8ea35b85();
		if (x789564759d365819 != null)
		{
			x31e6518f5e08db6c.x344511c4e4ce09da = x6f83e5bc997d2b34(x789564759d365819, x31e6518f5e08db6c.x344511c4e4ce09da);
		}
	}

	private void x642ff670f83b5343()
	{
		if (!xeb08cb9dbeb7967f(xb91e78c6fefd509b))
		{
			x0ae297d1a318f25a();
		}
		x1da164b06673f8db = null;
		xb91e78c6fefd509b = null;
		xac2ecf385ee5bd30();
		xbe92fd9b2aff2778 = null;
		xcf95ba2d669183a2();
		x6ac803642fac7471.Length = 0;
	}

	private void xac2ecf385ee5bd30()
	{
		if (xbe92fd9b2aff2778 != null)
		{
			xbe92fd9b2aff2778.Text = x738107d263b18706.ToString();
			x738107d263b18706.Length = 0;
		}
	}

	private void x0ae297d1a318f25a()
	{
		if (x1da164b06673f8db != null)
		{
			x1da164b06673f8db.Text = x1da164b06673f8db.Text.Substring(base.xb76ace4a8294b8d0, x1da164b06673f8db.Text.Length - base.xb76ace4a8294b8d0);
		}
	}

	private void xe068c643022b4983()
	{
		if (base.x14af24c1e6f8f311)
		{
			x86ce1fca7c42095a(base.x4092a781b3b7aab4.Text[base.xb76ace4a8294b8d0]);
		}
	}

	private void xcf95ba2d669183a2()
	{
		x206140170bd1cb62.Length = 0;
	}

	private void xf2ad3e62d62b4107()
	{
		foreach (Run item in x4ff54db11f63ec8d)
		{
			item.Remove();
		}
	}

	private void xe130132888d3488c()
	{
		if (!xce154b1510b027da)
		{
			x642ff670f83b5343();
			xce154b1510b027da = true;
		}
	}

	private void x2024af4f57d3224f()
	{
		if (xce154b1510b027da)
		{
			xe068c643022b4983();
			xce154b1510b027da = false;
		}
	}

	protected override void OnFieldResultBoundary()
	{
		if (!xce154b1510b027da && x1d59bafe2f9e84d5)
		{
			xf638e0702840dc28(xd9f02891a3463928.xeedad81aaed42a76, x91cdbdcb1db8f827: true);
		}
	}

	protected override void OnChar(char c)
	{
		if (!xce154b1510b027da && x1d59bafe2f9e84d5)
		{
			xeb08cb9dbeb7967f(base.x4092a781b3b7aab4);
			x206140170bd1cb62.Append(c);
		}
	}

	protected override void OnNextChar(char c)
	{
		if (!xce154b1510b027da && x1d59bafe2f9e84d5)
		{
			x86ce1fca7c42095a(c);
		}
	}

	private void x86ce1fca7c42095a(char x3c4da2980d043c95)
	{
		x6ac803642fac7471.Append(x3c4da2980d043c95);
		xb91e78c6fefd509b = base.x4092a781b3b7aab4;
	}

	protected override void ApplyNext()
	{
		if (!xce154b1510b027da && x1d59bafe2f9e84d5)
		{
			xeb08cb9dbeb7967f(xb91e78c6fefd509b);
			xb91e78c6fefd509b = null;
			xcf95ba2d669183a2();
			StringBuilder stringBuilder = x206140170bd1cb62;
			x206140170bd1cb62 = x6ac803642fac7471;
			x6ac803642fac7471 = stringBuilder;
		}
	}

	private bool xeb08cb9dbeb7967f(Run x99143d034bce0239)
	{
		if (x1da164b06673f8db == x99143d034bce0239)
		{
			return false;
		}
		if (x1da164b06673f8db != null)
		{
			x4ff54db11f63ec8d.Add(x1da164b06673f8db);
		}
		if (x1d59bafe2f9e84d5 && x1da164b06673f8db != null && x99143d034bce0239 != null && x1da164b06673f8db.xeedad81aaed42a76.xcedf9c82728ad579 != x99143d034bce0239.xeedad81aaed42a76.xcedf9c82728ad579)
		{
			xf638e0702840dc28(xd9f02891a3463928.xeedad81aaed42a76, x91cdbdcb1db8f827: true);
		}
		x1da164b06673f8db = x99143d034bce0239;
		return true;
	}
}
