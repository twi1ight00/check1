using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose;
using Aspose.Words;
using Aspose.Words.Drawing;
using x1c8faa688b1f0b0c;
using x3d94286fe72124a8;
using x4adf554d20d941a6;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x59d6a4fc5007b7a4;

internal class xa7492065dee59ad0 : x038d2057eb729fcf
{
	private x7721ad963b03c6eb xff72be8b55033598;

	internal x7721ad963b03c6eb x7721ad963b03c6eb => xff72be8b55033598;

	internal override bool xd4933b722e704dcd
	{
		get
		{
			xcc8377767090013e xcc8377767090013e = xcc8377767090013e.x7a4c51050e4e7530(x40212106aad8a8b0);
			if (xcc8377767090013e.xc5bb70cfaaae4a20)
			{
				return base.xd4933b722e704dcd;
			}
			return false;
		}
	}

	private xa67197c42bddc7dc xa67197c42bddc7dc => (xa67197c42bddc7dc)x9fb0e9c0b1bdc4b3;

	private Node x40212106aad8a8b0 => xa67197c42bddc7dc.x40212106aad8a8b0;

	internal override PointF xc22eade24b085d91
	{
		get
		{
			if (!base.x56410a8dd70087c5.x34251722ab416841.x109e3389933c23a8.x6f6877b222ed4153)
			{
				return base.xc22eade24b085d91;
			}
			PointF pointF = x4574ea26106f0edb.xc96d70553223ee04(base.x56410a8dd70087c5.x588d7683a6d1fbd5());
			if (base.x56410a8dd70087c5.x34251722ab416841.x109e3389933c23a8.x5885cb220c00df36)
			{
				xc7f90d9c7c51cede xc7f90d9c7c51cede = base.x56410a8dd70087c5.x776fd7c2f7270172();
				if (xc7f90d9c7c51cede.xd4c1d21f07094800 != null)
				{
					x109e3389933c23a8 x109e3389933c23a = xc7f90d9c7c51cede.xd4c1d21f07094800.x9d08aad9f0890726(base.x56410a8dd70087c5);
					if (x109e3389933c23a != null && x109e3389933c23a.xb6ef83a1238c066c == xae532cfb203d8406.x53111d6596d16a99)
					{
						pointF = x4574ea26106f0edb.xc96d70553223ee04(x109e3389933c23a.x6ae4612a8469678e.Location);
					}
				}
			}
			float y = pointF.Y + base.xbcd477821fdbd81b;
			float x = pointF.X;
			return new PointF(x, y);
		}
	}

	internal xa7492065dee59ad0(x398b3bd0acd94b61 part)
		: base(part)
	{
	}

	internal override void x7012609bcdb39574(x3adba2572f6b9747 x672ff13faf031f3d)
	{
		x672ff13faf031f3d.x371451abcd43de03(this);
	}

	[JavaConvertCheckedExceptions]
	internal xb8e7e788f6d59708 xe406325e56f74b46(xdeb77ea37ad74c56 x1e972e751678e682, out bool xf31bd0ec37d2cc8b)
	{
		switch (x40212106aad8a8b0.NodeType)
		{
		case NodeType.GroupShape:
		case NodeType.Shape:
			return xf51bb9981f8d7796(x1e972e751678e682, out xf31bd0ec37d2cc8b);
		case NodeType.DrawingML:
			return x539f48f6ee6ea753(x1e972e751678e682, out xf31bd0ec37d2cc8b);
		case NodeType.OfficeMath:
			return x82f9daf0a45f7d22(x1e972e751678e682, out xf31bd0ec37d2cc8b);
		default:
			throw new InvalidOperationException("Unexpected node type.");
		}
	}

	private xb8e7e788f6d59708 xf51bb9981f8d7796(xdeb77ea37ad74c56 x1e972e751678e682, out bool xf31bd0ec37d2cc8b)
	{
		x54b98d0096d7251a warningCallback = new xfadb51c1fcf6d0ba(x1e972e751678e682);
		xfc96716110004aef xfc96716110004aef = null;
		if (xa67197c42bddc7dc.x8da14380c3ea3537())
		{
			xfc96716110004aef = new x2450078883332f11(xa67197c42bddc7dc);
			xfc96716110004aef.xdeb77ea37ad74c56 = x1e972e751678e682;
		}
		float containerWidth = x70a70a203547ad53();
		ShapeBase shapeBase = (ShapeBase)x40212106aad8a8b0;
		xff72be8b55033598 = new x7721ad963b03c6eb(shapeBase, SizeF.Empty, containerWidth);
		Hashtable x0b16d2d2ced2de = ((Document)x40212106aad8a8b0.Document).x0b16d2d2ced2de05;
		xc958d22004253850 xc958d22004253850 = new xc958d22004253850(xfc96716110004aef, warningCallback, x0b16d2d2ced2de, x1e972e751678e682.x4e89abab59063fe9);
		xf31bd0ec37d2cc8b = false;
		xb8e7e788f6d59708 xb8e7e788f6d = xc958d22004253850.xe406325e56f74b46(xff72be8b55033598, x1e972e751678e682.x739586df98f871fe || !shapeBase.xa4281603feb56c8c());
		if (xb8e7e788f6d != null)
		{
			xb8e7e788f6d.x52dde376accdec7d = null;
			if (xff72be8b55033598.xa9993ed2e0c64574.IsInline)
			{
				xb8e7e788f6d.x52dde376accdec7d = new x54366fa5f75a02f7();
				xa30331e5a3477e03(xb8e7e788f6d);
				xb8e7e788f6d.x52dde376accdec7d.xce92de628aa023cf(0f - xff72be8b55033598.xfe502558fa04ffb1.Left, 0f - xff72be8b55033598.xfe502558fa04ffb1.Top, MatrixOrder.Append);
			}
		}
		return xb8e7e788f6d;
	}

	private xb8e7e788f6d59708 x539f48f6ee6ea753(xdeb77ea37ad74c56 x1e972e751678e682, out bool xf31bd0ec37d2cc8b)
	{
		if (((DrawingML)x40212106aad8a8b0).x96e55b5d052d1279)
		{
			xf31bd0ec37d2cc8b = true;
			return new xb8e7e788f6d59708();
		}
		x54b98d0096d7251a warningCallback = new xfadb51c1fcf6d0ba(x1e972e751678e682);
		x73d966e39902908a x73d966e39902908a = new x73d966e39902908a(warningCallback);
		xf31bd0ec37d2cc8b = false;
		xff72be8b55033598 = new x7721ad963b03c6eb((DrawingML)x40212106aad8a8b0);
		x2fca56c11bd20653 x2fca56c11bd = x73d966e39902908a.xe406325e56f74b46(xff72be8b55033598);
		RectangleF xfe502558fa04ffb = x2fca56c11bd.xfe502558fa04ffb1;
		xff72be8b55033598.x178374f0600f2696 = xfe502558fa04ffb.Size;
		xff72be8b55033598.xfe502558fa04ffb1 = xfe502558fa04ffb;
		xb8e7e788f6d59708 xa1eafe7821eb4aab = x2fca56c11bd.xa1eafe7821eb4aab;
		if (xa1eafe7821eb4aab != null && ((DrawingML)x40212106aad8a8b0).xf7125312c7ee115c.xc5bb70cfaaae4a20)
		{
			if (xa1eafe7821eb4aab.x52dde376accdec7d == null)
			{
				xa1eafe7821eb4aab.x52dde376accdec7d = new x54366fa5f75a02f7();
			}
			xa30331e5a3477e03(xa1eafe7821eb4aab);
			xa1eafe7821eb4aab.x52dde376accdec7d.xce92de628aa023cf(0f - xff72be8b55033598.xfe502558fa04ffb1.Left, 0f - xff72be8b55033598.xfe502558fa04ffb1.Top, MatrixOrder.Append);
		}
		return xa1eafe7821eb4aab;
	}

	private xb8e7e788f6d59708 x82f9daf0a45f7d22(xdeb77ea37ad74c56 x1e972e751678e682, out bool xf31bd0ec37d2cc8b)
	{
		xf31bd0ec37d2cc8b = false;
		xceb9556f0fd95aa6 xceb9556f0fd95aa = (xceb9556f0fd95aa6)xa67197c42bddc7dc.x347b79f9c616f92c;
		return xceb9556f0fd95aa.x57df270da83ea6de.xefb7a8f84373ac04;
	}

	private void xa30331e5a3477e03(xb8e7e788f6d59708 x08ce8f4769eb3234)
	{
		Shape shape = x850ed4df684a21e2(x40212106aad8a8b0);
		if (shape != null)
		{
			float num = 0f - x91be6b8f43d9bf39.xd08732447aa791e7(shape);
			if (num != 0f)
			{
				PointF x2f7096dac971d6ec = x37d2d88f96f87b47.x0aa7e9f1585a5d1e(xff72be8b55033598.xfe502558fa04ffb1);
				x08ce8f4769eb3234.x52dde376accdec7d.x49d618948c467be6(num, x2f7096dac971d6ec);
			}
		}
	}

	private Shape x850ed4df684a21e2(Node xda5bf54deb817e37)
	{
		for (CompositeNode parentNode = xda5bf54deb817e37.ParentNode; parentNode != null; parentNode = parentNode.ParentNode)
		{
			if (parentNode.NodeType == NodeType.Shape)
			{
				return (Shape)parentNode;
			}
			if (parentNode.NodeType == NodeType.Section)
			{
				return null;
			}
		}
		return null;
	}

	private float x70a70a203547ad53()
	{
		return x4574ea26106f0edb.xc96d70553223ee04(x9fb0e9c0b1bdc4b3.xc255c495fd9232ca.xdc1bf80853046136 - x9fb0e9c0b1bdc4b3.xc255c495fd9232ca.x5c392d6ad6fe7e28 - x9fb0e9c0b1bdc4b3.xc255c495fd9232ca.xf159a68356fd5b23);
	}
}
