using System.Collections;
using System.Drawing;

namespace x120d4bb5c80fb10c;

internal class xdb993f83d3c3518d
{
	private readonly x03d68de1c2f74051 xc93a8b18950ae181;

	private readonly x03d68de1c2f74051 x64af90493f8ca539;

	private readonly ArrayList[] x3f0ae3fc3f45b898;

	private readonly ArrayList[] x1f5cec64789cb8bd;

	private readonly ArrayList[] xe5a1749ff86e7fb9;

	private readonly ArrayList[] x05c3c6d549bb3d84;

	private PointF x4df1380ea2839637;

	private PointF x6fe2caad04304b28;

	private int x0193054291ad74f0;

	private int x2508af4a4388bf1e;

	private int x22529b84bcce3424;

	private int x9d823ba5d23bac10;

	private PointF x93c27e3906cc6217;

	private bool x5e236b7ef3a857a6;

	internal x03d68de1c2f74051 x132706af982e66d4 => xc93a8b18950ae181;

	internal x03d68de1c2f74051 xda1fa90ecfb45f47 => x64af90493f8ca539;

	internal PointF x11294912393cf4da
	{
		get
		{
			return x4df1380ea2839637;
		}
		set
		{
			x4df1380ea2839637 = value;
		}
	}

	internal PointF x86a54cb9b074862a
	{
		get
		{
			return x6fe2caad04304b28;
		}
		set
		{
			x6fe2caad04304b28 = value;
		}
	}

	internal PointF xf35d8b856c1f3037
	{
		get
		{
			return x93c27e3906cc6217;
		}
		set
		{
			x93c27e3906cc6217 = value;
		}
	}

	internal bool x59588380b3c4e6d6
	{
		get
		{
			return x5e236b7ef3a857a6;
		}
		set
		{
			x5e236b7ef3a857a6 = value;
		}
	}

	internal int xeb2981f42da5479b
	{
		get
		{
			return x0193054291ad74f0;
		}
		set
		{
			x0193054291ad74f0 = value;
		}
	}

	internal int x7d8c1a8f7bce8aef
	{
		get
		{
			return x2508af4a4388bf1e;
		}
		set
		{
			x2508af4a4388bf1e = value;
		}
	}

	internal int x0670b69f56b4ff17
	{
		get
		{
			return x22529b84bcce3424;
		}
		set
		{
			x22529b84bcce3424 = value;
		}
	}

	internal int xbc30aae3175af8d8
	{
		get
		{
			return x9d823ba5d23bac10;
		}
		set
		{
			x9d823ba5d23bac10 = value;
		}
	}

	internal xdb993f83d3c3518d(x03d68de1c2f74051 polygon1, x03d68de1c2f74051 polygon2)
	{
		xc93a8b18950ae181 = polygon1;
		x64af90493f8ca539 = polygon2;
		x3f0ae3fc3f45b898 = new ArrayList[polygon1.xe161fd465603c384];
		x1f5cec64789cb8bd = new ArrayList[polygon2.xe161fd465603c384];
		xe5a1749ff86e7fb9 = new ArrayList[polygon1.xe161fd465603c384];
		x05c3c6d549bb3d84 = new ArrayList[polygon2.xe161fd465603c384];
	}

	internal ArrayList xb9470426ecaacdf2(int x251e26ec1b1ddfdc)
	{
		if (x3f0ae3fc3f45b898[x251e26ec1b1ddfdc] == null)
		{
			x3f0ae3fc3f45b898[x251e26ec1b1ddfdc] = new ArrayList();
		}
		return x3f0ae3fc3f45b898[x251e26ec1b1ddfdc];
	}

	internal ArrayList x19ab0a16c4ddebbd(int x251e26ec1b1ddfdc)
	{
		if (x1f5cec64789cb8bd[x251e26ec1b1ddfdc] == null)
		{
			x1f5cec64789cb8bd[x251e26ec1b1ddfdc] = new ArrayList();
		}
		return x1f5cec64789cb8bd[x251e26ec1b1ddfdc];
	}

	internal ArrayList x315e0ef80871d679(int x251e26ec1b1ddfdc)
	{
		if (xe5a1749ff86e7fb9[x251e26ec1b1ddfdc] == null)
		{
			xe5a1749ff86e7fb9[x251e26ec1b1ddfdc] = new ArrayList();
		}
		return xe5a1749ff86e7fb9[x251e26ec1b1ddfdc];
	}

	internal ArrayList xfc2f58086a8d500e(int x251e26ec1b1ddfdc)
	{
		if (x05c3c6d549bb3d84[x251e26ec1b1ddfdc] == null)
		{
			x05c3c6d549bb3d84[x251e26ec1b1ddfdc] = new ArrayList();
		}
		return x05c3c6d549bb3d84[x251e26ec1b1ddfdc];
	}
}
