using System.Drawing;
using System.Drawing.Drawing2D;
using x0a3ff9616df4cd36;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using x8784bdb393e53e65;
using x8b1f7613579e78d0;
using xeb326c6285a77ac1;

namespace x996431aaaaf00543;

internal class xf4c807956df6c3b9 : x162d67570d6be3e3
{
	private xb8c0a122dcc2f776 xf04bec92f7bf4445;

	public xb8c0a122dcc2f776 xc84061bfd839e5fa
	{
		get
		{
			return xf04bec92f7bf4445;
		}
		set
		{
			xf04bec92f7bf4445 = value;
		}
	}

	public override x4fdf549af9de6b97 Render(x2094302a66c2ec77 nodeRenderParams)
	{
		nodeRenderParams.x1a1fb4b19097b9f6.x84e43ba1eb351dc4(GetTransform());
		try
		{
			x687bd29facb7e34a x687bd29facb7e34a = x4c1a949e2d5fc9d0(nodeRenderParams);
			x687bd29facb7e34a.x17b2b93b89a6dd3c = true;
			xb8e7e788f6d59708 xb8e7e788f6d = base.x5d1f5ab5850c22b5.xe406325e56f74b46(x687bd29facb7e34a);
			x4fdf549af9de6b97 x4fdf549af9de6b = x70f2a9357c1d25dc(x687bd29facb7e34a);
			if (x4fdf549af9de6b != null)
			{
				xb8e7e788f6d.xef23aa45e7612fdd(0, x4fdf549af9de6b);
			}
			x4ef42df82075df9e(nodeRenderParams.x1a1fb4b19097b9f6, xb8e7e788f6d);
			return xb8e7e788f6d;
		}
		finally
		{
			nodeRenderParams.x1a1fb4b19097b9f6.x23f6d2779534dd99();
		}
	}

	private x4fdf549af9de6b97 x70f2a9357c1d25dc(x687bd29facb7e34a x7cc44cab9e9f8397)
	{
		x8b545195dd56c1c7 x2c8538c67f1d80e = x7cc44cab9e9f8397.x2c8538c67f1d80e5;
		switch (xc84061bfd839e5fa.x90c6e45466e5b849.x22bfb60fc9ca9282(x2c8538c67f1d80e.xe9e9c556ec0c3e33))
		{
		case xfe2ff3c162b47c70.xd69df86e2a88ddb2:
		case xfe2ff3c162b47c70.xb5fe04c34562f438:
			return xdb6e5b78ff4fa348(x7cc44cab9e9f8397);
		default:
			return x6bf3c6b45600dc1e(x7cc44cab9e9f8397);
		}
	}

	private x4fdf549af9de6b97 xdb6e5b78ff4fa348(x687bd29facb7e34a x7cc44cab9e9f8397)
	{
		x8b545195dd56c1c7 x2c8538c67f1d80e = x7cc44cab9e9f8397.x2c8538c67f1d80e5;
		byte[] imageBytes = xc84061bfd839e5fa.x90c6e45466e5b849.x601e9a2243ca6720(x2c8538c67f1d80e.xe9e9c556ec0c3e33);
		x78e18bdf9a108059 transform = GetTransform();
		RectangleF x2727839aafc = transform.x2727839aafc09868;
		x72c34b8dbaec3734 x72c34b8dbaec = new x72c34b8dbaec3734(x2727839aafc.Location, x2727839aafc.Size, imageBytes);
		x3502e2a3c4b8ec52.xe42491110461872b(x72c34b8dbaec, xc84061bfd839e5fa.x90c6e45466e5b849.x819589f292a61f6b, x7cc44cab9e9f8397.x2c8538c67f1d80e5);
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		xb8e7e788f6d.xd6b6ed77479ef68c(x72c34b8dbaec);
		PointF x2f7096dac971d6ec = x37d2d88f96f87b47.x0aa7e9f1585a5d1e(new RectangleF(0f, 0f, x2727839aafc.Width, x2727839aafc.Height));
		xb8e7e788f6d.x52dde376accdec7d = new x54366fa5f75a02f7();
		xb8e7e788f6d.x52dde376accdec7d.x49d618948c467be6((float)transform.xa00ce09851f40ee5.x95bb1b6b5e161bbe, x2f7096dac971d6ec);
		xb8e7e788f6d.x52dde376accdec7d.xce92de628aa023cf((float)transform.x8df91a2f90079e88, (float)transform.xc821290d7ecc08bf, MatrixOrder.Append);
		return xb8e7e788f6d;
	}

	private xab391c46ff9a0a38 x6bf3c6b45600dc1e(x687bd29facb7e34a x7cc44cab9e9f8397)
	{
		x8b545195dd56c1c7 x2c8538c67f1d80e = x7cc44cab9e9f8397.x2c8538c67f1d80e5;
		xab391c46ff9a0a38 xab391c46ff9a0a = base.x5d1f5ab5850c22b5.xbe03fdfd3b07bf15(x7cc44cab9e9f8397);
		if (xab391c46ff9a0a == null)
		{
			return null;
		}
		bool x3012fceed1fc4fbf = xc84061bfd839e5fa.x3012fceed1fc4fbf;
		try
		{
			xc84061bfd839e5fa.x3012fceed1fc4fbf = true;
			xab391c46ff9a0a.x60465f602599d327 = xc84061bfd839e5fa.CreateBrush(x2c8538c67f1d80e);
			return xab391c46ff9a0a;
		}
		finally
		{
			xc84061bfd839e5fa.x3012fceed1fc4fbf = x3012fceed1fc4fbf;
		}
	}
}
