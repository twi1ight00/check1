using System;
using Aspose.Words;
using Aspose.Words.Lists;

namespace xd2754ae26d400653;

internal class x136abcf7d9c0eef3
{
	internal int x6da6130e001c6962 = 1;

	internal bool x33160172e2e7ff13;

	internal bool x178c863a9c967cd2;

	internal int xda76c7dfd195022e;

	internal int x41c02f247da65443;

	private ListLevel x1fa4169cbf2b08e9;

	internal int xa12fba83b43c84d8
	{
		get
		{
			if (!x33160172e2e7ff13 || !x178c863a9c967cd2)
			{
				return x6da6130e001c6962;
			}
			return xf13a626e550cef8f.StartAt;
		}
	}

	internal ListLevel xf13a626e550cef8f
	{
		get
		{
			return x1fa4169cbf2b08e9;
		}
		set
		{
			if (x1fa4169cbf2b08e9 != null)
			{
				throw new InvalidOperationException("ListLevel object already assigned.");
			}
			x1fa4169cbf2b08e9 = value;
		}
	}

	internal x136abcf7d9c0eef3()
	{
	}

	internal x136abcf7d9c0eef3(DocumentBase document, int levelNumber)
	{
		x1fa4169cbf2b08e9 = new ListLevel(document, levelNumber);
	}

	internal x136abcf7d9c0eef3 x8b61531c8ea35b85()
	{
		x136abcf7d9c0eef3 x136abcf7d9c0eef4 = (x136abcf7d9c0eef3)MemberwiseClone();
		x136abcf7d9c0eef4.x1fa4169cbf2b08e9 = x1fa4169cbf2b08e9.x8b61531c8ea35b85(null);
		return x136abcf7d9c0eef4;
	}
}
