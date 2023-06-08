using System.Collections;
using Aspose.Words.Fields;

namespace xfbd1009a0cbb9842;

internal class xbf9ddf72e1283af9
{
	private readonly xfedf115fd9c03862 x9a4ce700a778f1a8;

	private readonly x6435b7bbb0879a04 xf4534a93f13f6ff3;

	private readonly ArrayList x7c5e3f5aa6913590 = new ArrayList();

	internal xbf9ddf72e1283af9(xfedf115fd9c03862 updater)
		: this(updater, new x6435b7bbb0879a04())
	{
	}

	internal xbf9ddf72e1283af9(xfedf115fd9c03862 updater, x6435b7bbb0879a04 fields)
	{
		x9a4ce700a778f1a8 = updater;
		xf4534a93f13f6ff3 = fields;
	}

	internal bool xe06bf41f3e53680c(xa7114c309aebe17d xab8fe3cd8c5556fb)
	{
		foreach (xa7114c309aebe17d item in x7c5e3f5aa6913590)
		{
			if (xab8fe3cd8c5556fb.GetType() == item.GetType())
			{
				return false;
			}
		}
		x7c5e3f5aa6913590.Add(xab8fe3cd8c5556fb);
		return true;
	}

	internal bool x69dc2014b9eea9e3(Field xe01ae93d9fe5a880)
	{
		if (xf4534a93f13f6ff3.IndexOf(xe01ae93d9fe5a880) == -1)
		{
			xf4534a93f13f6ff3.Add(xe01ae93d9fe5a880);
			return true;
		}
		return false;
	}

	internal void x18dfca7c5fd2402f()
	{
		foreach (xa7114c309aebe17d item in x7c5e3f5aa6913590)
		{
			item.xb333e1e6c01c2be2();
		}
		foreach (Field item2 in xf4534a93f13f6ff3)
		{
			x9a4ce700a778f1a8.x4e3cfc222c92cda7(item2);
		}
	}
}
