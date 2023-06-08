using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xa7850104c8d8c135;
using xf84f8427dc22d095;
using xf9a9481c3f63a419;

namespace x1c8faa688b1f0b0c;

internal class x72c34b8dbaec3734 : x4fdf549af9de6b97
{
	private PointF x831916008bfc3ed7 = PointF.Empty;

	private SizeF x3b77a41bd57164d6 = SizeF.Empty;

	private byte[] xd08494dce3b2b550;

	private x02df97c06afacbf3 x8dab1a0b6655c671;

	private xa702b771604efc86 xcbb1563eca0c21f2;

	private xf276f6a75b584d31 x491c1af7ed6ea845;

	private x2bfc048c6117997a[] x661ff97aad146326;

	public PointF xc22eade24b085d91
	{
		get
		{
			return x831916008bfc3ed7;
		}
		set
		{
			x831916008bfc3ed7 = value;
		}
	}

	public SizeF x437e3b626c0fdd43
	{
		get
		{
			return x3b77a41bd57164d6;
		}
		set
		{
			x3b77a41bd57164d6 = value;
		}
	}

	public RectangleF x6ae4612a8469678e => new RectangleF(x831916008bfc3ed7, x3b77a41bd57164d6);

	public byte[] xcc18177a965e0313
	{
		get
		{
			return xd08494dce3b2b550;
		}
		set
		{
			xd08494dce3b2b550 = value;
		}
	}

	public xfe2ff3c162b47c70 x688d6f6524ba3c8b => xdd1b8f14cc8ba86d.x22bfb60fc9ca9282(xd08494dce3b2b550);

	public x02df97c06afacbf3 x4d7261a5f7f6e09c
	{
		get
		{
			return x8dab1a0b6655c671;
		}
		set
		{
			x8dab1a0b6655c671 = value;
		}
	}

	public xa702b771604efc86 xc9bcfb2d9630b0c7
	{
		get
		{
			return xcbb1563eca0c21f2;
		}
		set
		{
			xcbb1563eca0c21f2 = value;
		}
	}

	public xf276f6a75b584d31 x1fa52d87045f9b01
	{
		get
		{
			return x491c1af7ed6ea845;
		}
		set
		{
			x491c1af7ed6ea845 = value;
		}
	}

	public x2bfc048c6117997a[] x819589f292a61f6b
	{
		get
		{
			return x661ff97aad146326;
		}
		set
		{
			x661ff97aad146326 = value;
		}
	}

	public x72c34b8dbaec3734(PointF origin, SizeF size, byte[] imageBytes)
		: this(origin, size, imageBytes, null)
	{
	}

	public x72c34b8dbaec3734(PointF origin, SizeF size, byte[] imageBytes, x02df97c06afacbf3 crop, xf276f6a75b584d31 chromaKey)
		: this(origin, size, imageBytes, crop)
	{
		x491c1af7ed6ea845 = chromaKey;
	}

	public x72c34b8dbaec3734(PointF origin, SizeF size, byte[] imageBytes, x02df97c06afacbf3 crop)
	{
		x831916008bfc3ed7 = origin;
		x3b77a41bd57164d6 = size;
		x8dab1a0b6655c671 = crop;
		xd08494dce3b2b550 = x3cd5d648729cd9b6.x9119dc963bd33df7(imageBytes);
	}

	public static x72c34b8dbaec3734 xd18a213c26688d63(x72c34b8dbaec3734 x50a18ad2656e7181)
	{
		x72c34b8dbaec3734 x72c34b8dbaec3735 = x50a18ad2656e7181.x8b61531c8ea35b85();
		x72c34b8dbaec3735.xcc18177a965e0313 = x0d299f323d241756.xcd6c2a9742c9220a();
		x72c34b8dbaec3735.x4d7261a5f7f6e09c = null;
		return x72c34b8dbaec3735;
	}

	private x72c34b8dbaec3734 x8b61531c8ea35b85()
	{
		return (x72c34b8dbaec3734)MemberwiseClone();
	}

	public static x72c34b8dbaec3734 xaaf6f3ebf249eaac(PointF x9c3c185e7046dc72, SizeF x0ceec69a97f73617, string xafe2f3653ee64ebc)
	{
		FileStream fileStream = new FileStream(xafe2f3653ee64ebc, FileMode.Open, FileAccess.Read);
		try
		{
			byte[] imageBytes = x0d299f323d241756.xa0aed4cd3b3d5d92(fileStream);
			return new x72c34b8dbaec3734(x9c3c185e7046dc72, x0ceec69a97f73617, imageBytes);
		}
		finally
		{
			fileStream.Close();
		}
	}

	public override void Accept(xf51865b83a7a0b3b visitor)
	{
		visitor.VisitImage(this);
	}

	internal x72c34b8dbaec3734 x9214b18190604b0d(xf51865b83a7a0b3b x672ff13faf031f3d, x48cb59b8ec3b78c9 x5a7a657dd8463d3b, bool xac51bc46b01ec35d)
	{
		switch (x688d6f6524ba3c8b)
		{
		case xfe2ff3c162b47c70.xf6c17f648b65c793:
		case xfe2ff3c162b47c70.x796ab23ce57ee1e0:
		case xfe2ff3c162b47c70.x6339cdb9e2b512c7:
		case xfe2ff3c162b47c70.xc2746d872ce402e9:
		case xfe2ff3c162b47c70.x15c106572f1e1fbf:
		case xfe2ff3c162b47c70.x8e716ec1cb703e9f:
			return this;
		case xfe2ff3c162b47c70.xd69df86e2a88ddb2:
		case xfe2ff3c162b47c70.xb5fe04c34562f438:
			xdb6e5b78ff4fa348(x5a7a657dd8463d3b, xac51bc46b01ec35d, x672ff13faf031f3d);
			return null;
		default:
			return xd18a213c26688d63(this);
		}
	}

	private void xdb6e5b78ff4fa348(x48cb59b8ec3b78c9 x5a7a657dd8463d3b, bool xac51bc46b01ec35d, xf51865b83a7a0b3b x672ff13faf031f3d)
	{
		xb0d8039f74776744 x0f7b23d1c393aed = new xb0d8039f74776744(x672ff13faf031f3d as x2da3d38c09108f49);
		xb8e7e788f6d59708 xb8e7e788f6d59709 = x5a7a657dd8463d3b.x5b81632e5b71b64c(this, x0f7b23d1c393aed);
		if (xb8e7e788f6d59709 != null)
		{
			if (xac51bc46b01ec35d)
			{
				xdd96b58d9d4da8a7(xb8e7e788f6d59709);
			}
			xf796701adb7bc194.x550781f8db1cf5f2(xb8e7e788f6d59709, x661ff97aad146326);
			if (x491c1af7ed6ea845 != null)
			{
				xf796701adb7bc194.x550781f8db1cf5f2(xb8e7e788f6d59709, new x2bfc048c6117997a[1]
				{
					new x19207c5e60a5ce17(x491c1af7ed6ea845)
				});
			}
			xb8e7e788f6d59709.Accept(x672ff13faf031f3d);
		}
	}

	private static void xdd96b58d9d4da8a7(xb8e7e788f6d59708 xcd0c95ffcb6ae107)
	{
		float num = xef9927f997089c23(xcd0c95ffcb6ae107);
		if (!(num >= 1f))
		{
			xeb74be576dcd2dd2 xeb74be576dcd2dd3 = new xeb74be576dcd2dd2();
			xeb74be576dcd2dd3.xbf200fb0098a05e6 = true;
			xeb74be576dcd2dd3.x5152a5707921c783(xcd0c95ffcb6ae107, num);
			if (xcd0c95ffcb6ae107.x52dde376accdec7d == null)
			{
				xcd0c95ffcb6ae107.x52dde376accdec7d = new x54366fa5f75a02f7();
			}
			xcd0c95ffcb6ae107.x52dde376accdec7d.x5152a5707921c783(1f / num, 1f / num, MatrixOrder.Prepend);
		}
	}

	private static float xef9927f997089c23(xb8e7e788f6d59708 xcd0c95ffcb6ae107)
	{
		x12aabb49dc07bbe6 x12aabb49dc07bbe7 = new x12aabb49dc07bbe6();
		x12aabb49dc07bbe7.xb1de1ba20faeeff8(xcd0c95ffcb6ae107);
		float x83d36262f = x12aabb49dc07bbe7.x83d36262f4284272;
		if (x83d36262f < 32767f)
		{
			return 1f;
		}
		return 32766f / x83d36262f;
	}
}
