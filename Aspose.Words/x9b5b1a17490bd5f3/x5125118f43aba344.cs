using Aspose.Words.Tables;
using x643046e3f004c49f;
using x7c4557e104065fc9;

namespace x9b5b1a17490bd5f3;

internal class x5125118f43aba344
{
	private readonly x9d6b37cac59aa2e2 x48154453a08515ea;

	private readonly PreferredWidth x7da4fdc86e3c460d;

	private CellMerge xe508d1d5accf3da6;

	private CellMerge xfc2c833dced14146;

	private x5125118f43aba344 x950c2743fa773500;

	private x5125118f43aba344 x2566c3e5f9901b82;

	private double x8291d327dfc9bfc8;

	internal x9d6b37cac59aa2e2 x40212106aad8a8b0 => x48154453a08515ea;

	internal PreferredWidth xc6a8342933c4e987 => x7da4fdc86e3c460d;

	internal int x2f4795c5e4c1617e
	{
		get
		{
			if (x48154453a08515ea == null)
			{
				return 1;
			}
			return x48154453a08515ea.x75658b3f8be4005c("colspan", 1);
		}
	}

	internal int xe9fd99df52338f59
	{
		get
		{
			if (x48154453a08515ea == null)
			{
				return 1;
			}
			return x48154453a08515ea.x75658b3f8be4005c("rowspan", 1);
		}
	}

	internal CellMerge x338a5e6ab7c5595e
	{
		get
		{
			return xe508d1d5accf3da6;
		}
		set
		{
			xe508d1d5accf3da6 = value;
		}
	}

	internal CellMerge x1a1dda35b3ae703d
	{
		get
		{
			return xfc2c833dced14146;
		}
		set
		{
			xfc2c833dced14146 = value;
		}
	}

	internal x5125118f43aba344 x4da4b13c8bf87e9a
	{
		get
		{
			return x950c2743fa773500;
		}
		set
		{
			x950c2743fa773500 = value;
		}
	}

	internal x5125118f43aba344 xf041dffa93734047
	{
		get
		{
			return x2566c3e5f9901b82;
		}
		set
		{
			x2566c3e5f9901b82 = value;
		}
	}

	internal double x93308e6d4fdc657d
	{
		get
		{
			return x8291d327dfc9bfc8;
		}
		set
		{
			x8291d327dfc9bfc8 = value;
		}
	}

	internal x5125118f43aba344(x9d6b37cac59aa2e2 node)
	{
		x48154453a08515ea = node;
		x7da4fdc86e3c460d = x495fdb45f3d92b70.x844d4319ee50b6d6(node.x75658b3f8be4005c("width", ""));
	}

	internal x5125118f43aba344()
	{
		x7da4fdc86e3c460d = PreferredWidth.Auto;
	}
}
