using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Words;
using x06e283fdfa5dc5f0;
using x13f1efc79617a47b;
using x1c8faa688b1f0b0c;
using x28925c9b27b37a46;
using x4adf554d20d941a6;
using x5794c252ba25e723;
using x59d6a4fc5007b7a4;
using x6a42c37b95e9caa1;
using x6c95d9cf46ff5f25;
using xb3b3ff3836e35ac5;
using xeb665d1aeef09d64;
using xf9a9481c3f63a419;
using xfbd1009a0cbb9842;

namespace x99ec507695f2d4ff;

internal sealed class x42b8c317113a56e4
{
	private const float xd5be186bd81d7a72 = 0.05f;

	private const float xee18d66b840fad2b = 0.23f;

	internal const float x60a1cb235be131b0 = 0.8f;

	private const float xcf83a59089f155f3 = 0.042f;

	private readonly xe6a5f3ec802a6d51 x8cedcaa9a62c6e39;

	private readonly x54afa1405121518f x9fc085e06e4bf05d;

	private readonly x5f887a65c13f569c x8ca854032a09b9e0;

	private x6a53cec2ada67e5c x03d592937b5e7bd3;

	private Rectangle xa8548d289a49a30a = Rectangle.Empty;

	private ArrayList x4fda1643e89a6091;

	private static readonly float[] xe52155d15d2da086 = new float[2] { 0.18f, 0.28f };

	internal x42b8c317113a56e4(xe6a5f3ec802a6d51 context)
	{
		x8cedcaa9a62c6e39 = context;
		x8ca854032a09b9e0 = new x5f887a65c13f569c(x9ec6ce5404580fa7.x56410a8dd70087c5);
		x9fc085e06e4bf05d = new x54afa1405121518f(context);
	}

	internal void x7c922a3d2390ec27(x6a53cec2ada67e5c x311e7a92306d7199)
	{
		x03d592937b5e7bd3 = x311e7a92306d7199;
		if (x03d592937b5e7bd3.xef3bf4897acc8ed3)
		{
			xb8e7e788f6d59708 xb8e7e788f6d = x8cedcaa9a62c6e39.xd53690ab1592eec8(x03d592937b5e7bd3.xc22eade24b085d91);
			xa8548d289a49a30a = ((xf6937c72cebe4ad1)x03d592937b5e7bd3.x9fb0e9c0b1bdc4b3).xd17e5f6278553255.xac997a026eea3281();
			RectangleF x26545669838eb36e = x4574ea26106f0edb.xc96d70553223ee04(xa8548d289a49a30a);
			xb8e7e788f6d.x0e1bf8242ad10272 = xab391c46ff9a0a38.x7c89cd07f845b8e1(x26545669838eb36e);
			x4fda1643e89a6091 = new ArrayList();
		}
		else
		{
			xa8548d289a49a30a = Rectangle.Empty;
			x8cedcaa9a62c6e39.xd26f731b334aa0f8(x03d592937b5e7bd3.xc22eade24b085d91);
		}
		x24285ad0c2cf9312();
		xbf152843c1ed2887.x3bc66b20ee9d88e1();
	}

	private void x092b4e0fca387367()
	{
		if (x4fda1643e89a6091.Count <= 0)
		{
			return;
		}
		x8cedcaa9a62c6e39.xd53690ab1592eec8(x03d592937b5e7bd3.xc22eade24b085d91);
		foreach (xb8e7e788f6d59708 item in x4fda1643e89a6091)
		{
			x8cedcaa9a62c6e39.x1fa9148f6731ff24(item);
		}
		x8cedcaa9a62c6e39.xf5b0b9b6ff7ac462();
	}

	private void x24285ad0c2cf9312()
	{
		xf6937c72cebe4ad1 xf6937c72cebe4ad = (xf6937c72cebe4ad1)x03d592937b5e7bd3.x9fb0e9c0b1bdc4b3;
		xac6c82c74ce247fb x53111d6596d16a = xf6937c72cebe4ad.x406d8cd2af514771.x53111d6596d16a99;
		if (x53111d6596d16a.xf684fc5abe7ca67a && xf6937c72cebe4ad.x845183cdf0fdbeec > 0)
		{
			xf6689e0eed33812c xf6689e0eed33812c = (xf6689e0eed33812c)xf6937c72cebe4ad.x406d8cd2af514771.x2cbc0fc707d2e1eb();
			x7c5d33e87d9dfc05 x874c84c = xf6689e0eed33812c.x874c84c476778297;
			xf543de5d109f4fda xf543de5d109f4fda = new xf543de5d109f4fda(xf6937c72cebe4ad.x845183cdf0fdbeec.ToString());
			xf543de5d109f4fda.x705ed5f9769744e5 = x396b77a306f83da6.x38758cbbee49e4cb(x874c84c.xde015839cc88f18d.x16f7f1497a3e7638);
			xf543de5d109f4fda.x8df91a2f90079e88 = -xf6689e0eed33812c.xf48cd6e82340ac70.xeae841520367cd95 - xf543de5d109f4fda.xdc1bf80853046136 - xf6937c72cebe4ad.x8df91a2f90079e88;
			xf543de5d109f4fda.xc821290d7ecc08bf = xf6937c72cebe4ad.x139412b8dea2f02b - xf543de5d109f4fda.x550cafc27071d020(xf6937c72cebe4ad.x2c8c6741422a1298.x80f061859cd048ae.xde015839cc88f18d.x015616f0fde5275b) + xf543de5d109f4fda.x79a071bfba0c5e7d;
			xf543de5d109f4fda.xc255c495fd9232ca = xf6937c72cebe4ad;
			xe04b5d7c28160175(new xcd3694ded987e19d(xf543de5d109f4fda));
		}
	}

	internal void x2c033959922f72a9()
	{
		x9fc085e06e4bf05d.x8fff2b286601b9d6();
		if (xa8548d289a49a30a.IsEmpty)
		{
			x8cedcaa9a62c6e39.xd26f731b334aa0f8(PointF.Empty);
		}
		else
		{
			x8cedcaa9a62c6e39.xf5b0b9b6ff7ac462();
			x092b4e0fca387367();
		}
		if (!x8cedcaa9a62c6e39.xdeb77ea37ad74c56.x1e54a440b0ec94ac.x7149c962c02931b3)
		{
			x8cedcaa9a62c6e39.xee63d905da8ff550(new RectangleF(x03d592937b5e7bd3.x72d92bd1aff02e37, x03d592937b5e7bd3.xe360b1885d8d4a41, x03d592937b5e7bd3.xdc1bf80853046136, x03d592937b5e7bd3.xb0f146032f47c24e), x8cedcaa9a62c6e39.xdeb77ea37ad74c56.x1e54a440b0ec94ac);
		}
		x03d592937b5e7bd3 = null;
		xa8548d289a49a30a = Rectangle.Empty;
		x4fda1643e89a6091 = null;
	}

	internal void xe04b5d7c28160175(xcd3694ded987e19d x5906905c888d3d98)
	{
		x12ca3a3e2d5518cd(x5906905c888d3d98);
		xc7234004e9b72a7e(x5906905c888d3d98);
		xc57fb21ab216f7ff(x5906905c888d3d98);
	}

	internal void xa2007eb3b6f579d9(x96fdc2b3abde93b1 x5906905c888d3d98)
	{
		x12ca3a3e2d5518cd(x5906905c888d3d98);
		if (!x8cedcaa9a62c6e39.xdeb77ea37ad74c56.xc140e3669091ae41)
		{
			xc7234004e9b72a7e(x5906905c888d3d98);
		}
		else
		{
			switch (x5906905c888d3d98.x5566e2d2acbd1fbe)
			{
			case 10754:
				xc61a0e13341003ec(x5906905c888d3d98, x6da6efa5a7623bdb.x06da1ae0ac8f70c8, x5906905c888d3d98.xd49212c2bf5d3d12);
				break;
			case 9747:
			case 10768:
			case 10769:
			case 10770:
				xc61a0e13341003ec(x5906905c888d3d98, x6da6efa5a7623bdb.xfe338dc39b1d1cfd, x5906905c888d3d98.xd49212c2bf5d3d12);
				break;
			case 10782:
				xc61a0e13341003ec(x5906905c888d3d98, x6da6efa5a7623bdb.x5ee147a29667461a, x5906905c888d3d98.xd49212c2bf5d3d12);
				break;
			default:
				xc7234004e9b72a7e(x5906905c888d3d98);
				break;
			}
		}
		xc57fb21ab216f7ff(x5906905c888d3d98);
	}

	internal void xb5cf8dd3ac6ab11c(x740374357407832e xf21396edc6a84878)
	{
		RectangleF xa07a9457a2ebbbfc = xf21396edc6a84878.xa07a9457a2ebbbfc;
		float y = xa07a9457a2ebbbfc.Top + xa07a9457a2ebbbfc.Height * 0.58f;
		PointF x10aaa7cdfa38f = x8cedcaa9a62c6e39.xce92de628aa023cf(new PointF(xa07a9457a2ebbbfc.X, y));
		PointF xca09b6c2b5b = x8cedcaa9a62c6e39.xce92de628aa023cf(new PointF(xa07a9457a2ebbbfc.Right, y));
		xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.xb471d14948c54f27(x10aaa7cdfa38f, xca09b6c2b5b);
		xab391c46ff9a0a.x9e5d5f9128c69a8f = new x31c19fcb724dfaf5(x26d9ecb4bdf0456d.x89fffa2751fdecbe);
		x8cedcaa9a62c6e39.x1fa9148f6731ff24(xab391c46ff9a0a);
	}

	internal void xbb61f83f3bddaa5d(xfb07b2a80e43c2cc x5906905c888d3d98)
	{
		x12ca3a3e2d5518cd(x5906905c888d3d98);
		if (x8cedcaa9a62c6e39.xdeb77ea37ad74c56.x7383a35ee8adbcce)
		{
			xe39d06eee35dd23d xab6b30956a425d = x9d888f53892d94df.x9834ddb0e0bd5996.x491f5a7224612753("Wingdings 3", 12f, FontStyle.Regular);
			string xb41faee6912a = (x5906905c888d3d98.x56410a8dd70087c5.x5a7799e1836857e3.x8786efe6471e0521 ? "\uf021" : "\uf022");
			xc61a0e13341003ec(x5906905c888d3d98, xb41faee6912a, xab6b30956a425d);
		}
		xf783a6243ed7ab79(x5906905c888d3d98);
		xc57fb21ab216f7ff(x5906905c888d3d98);
	}

	internal void x39f76dcf47c1d43c(xb43a47dbe11ef8fb x5906905c888d3d98)
	{
		if (x8cedcaa9a62c6e39.xdeb77ea37ad74c56.x4e3a197ead77ddae)
		{
			x8cedcaa9a62c6e39.x00149f2495b0f026(x5906905c888d3d98.xc2d4efc42998d87b.Shading);
			switch (x5906905c888d3d98.x0fef8fbd5fd7c54d)
			{
			case x0fef8fbd5fd7c54d.x48cc0c3eaf9f5f05:
				xf9369809c1d1f8a2(x5906905c888d3d98.xc22eade24b085d91);
				break;
			case x0fef8fbd5fd7c54d.xa65184d44a47025b:
				x7df55bf4e058b47f(x5906905c888d3d98.xc22eade24b085d91, ".....Page Break.....");
				break;
			case x0fef8fbd5fd7c54d.x4c38e800e85b21ad:
				x7df55bf4e058b47f(x5906905c888d3d98.xc22eade24b085d91, ".....Column Break.....");
				break;
			case x0fef8fbd5fd7c54d.xfdc1a17f479acc42:
			case x0fef8fbd5fd7c54d.x53111d6596d16a99:
				xc51f83f6aa731e5b(x5906905c888d3d98, "¶");
				break;
			case x0fef8fbd5fd7c54d.x11db8fc7f469a2fc:
				xc51f83f6aa731e5b(x5906905c888d3d98, "¤");
				break;
			case x0fef8fbd5fd7c54d.x095e12be284796bf:
				x7df55bf4e058b47f(x5906905c888d3d98.xc22eade24b085d91, ":::::Section Break (Next Page):::::");
				break;
			case x0fef8fbd5fd7c54d.xffd4975b1b539b08:
				x7df55bf4e058b47f(x5906905c888d3d98.xc22eade24b085d91, ":::::End of Section:::::");
				break;
			case x0fef8fbd5fd7c54d.x09df06d0f8a42a94:
				x7df55bf4e058b47f(x5906905c888d3d98.xc22eade24b085d91, ":::::Section Break (Continuous):::::");
				break;
			case x0fef8fbd5fd7c54d.xd5ebfa71835c99de:
				x7df55bf4e058b47f(x5906905c888d3d98.xc22eade24b085d91, ":::::Section Break (Even Page):::::");
				break;
			case x0fef8fbd5fd7c54d.x5c93feb532e73700:
				x7df55bf4e058b47f(x5906905c888d3d98.xc22eade24b085d91, ":::::Section Break (Odd Page):::::");
				break;
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ebjdkcaeecheecoeccffhcmflbdgkmjgmabhcbihfapholfikaniopdjflkjopbkipikkppkooglgknlhpemjplmnocnpnjnfkao", 1704868031)));
			}
			xcc8c7739d82c63ba xcc8c7739d82c63ba = (xcc8c7739d82c63ba)x8cedcaa9a62c6e39.xc255c495fd9232ca.get_xe6d4b1b411ed94b5(x8cedcaa9a62c6e39.xc255c495fd9232ca.xd44988f225497f3a - 1);
			xcc8c7739d82c63ba.xd229d86af0f16fb0 = x5906905c888d3d98.x5566e2d2acbd1fbe;
			x8cedcaa9a62c6e39.xbcd358ebb8d4e95e();
		}
	}

	internal void x6352d2f80acb683d(xa7492065dee59ad0 x5906905c888d3d98)
	{
		x12ca3a3e2d5518cd(x5906905c888d3d98);
		PointF x2f7096dac971d6ec = x5906905c888d3d98.xc22eade24b085d91;
		bool xf31bd0ec37d2cc8b;
		xb8e7e788f6d59708 xb8e7e788f6d = x5906905c888d3d98.xe406325e56f74b46(x8cedcaa9a62c6e39.xdeb77ea37ad74c56, out xf31bd0ec37d2cc8b);
		bool flag = x5906905c888d3d98.x7721ad963b03c6eb != null && x5906905c888d3d98.x7721ad963b03c6eb.xa9993ed2e0c64574 != null && x5906905c888d3d98.x7721ad963b03c6eb.xa9993ed2e0c64574.IsImage && Math.Abs(x5906905c888d3d98.x7721ad963b03c6eb.xa9993ed2e0c64574.Rotation % 180.0) == 90.0;
		x2f7096dac971d6ec = new PointF(x2f7096dac971d6ec.X, x2f7096dac971d6ec.Y - (flag ? x5906905c888d3d98.x887b872a95caaab5 : x5906905c888d3d98.xbcd477821fdbd81b));
		if (!xf31bd0ec37d2cc8b)
		{
			if (null == xb8e7e788f6d.x52dde376accdec7d)
			{
				xb8e7e788f6d.x52dde376accdec7d = new x54366fa5f75a02f7();
			}
			x2f7096dac971d6ec = x8cedcaa9a62c6e39.xce92de628aa023cf(x2f7096dac971d6ec);
			xb8e7e788f6d.x52dde376accdec7d.xce92de628aa023cf(x2f7096dac971d6ec.X, x2f7096dac971d6ec.Y, MatrixOrder.Append);
		}
		xb8e7e788f6d.xc9bcfb2d9630b0c7 = x6a61ddb1d1e8f259(x5906905c888d3d98);
		if (x03d592937b5e7bd3 == null || xa8548d289a49a30a.IsEmpty || x269cfb89ceb2ad61(x5906905c888d3d98))
		{
			x8cedcaa9a62c6e39.x1fa9148f6731ff24(xb8e7e788f6d);
		}
		else
		{
			x4fda1643e89a6091.Add(xb8e7e788f6d);
		}
		xc57fb21ab216f7ff(x5906905c888d3d98);
	}

	private bool x269cfb89ceb2ad61(x038d2057eb729fcf x5906905c888d3d98)
	{
		if (x03d592937b5e7bd3 == null || xa8548d289a49a30a.IsEmpty)
		{
			return false;
		}
		xa67197c42bddc7dc xa67197c42bddc7dc = (xa67197c42bddc7dc)x5906905c888d3d98.x56410a8dd70087c5;
		if (xa67197c42bddc7dc.x34251722ab416841.x109e3389933c23a8.xab6edfb47ff0b74c != 0)
		{
			return false;
		}
		if (!xa67197c42bddc7dc.x347b79f9c616f92c.x831a5e8d62d04082 && !xa67197c42bddc7dc.x347b79f9c616f92c.xcb478672544cad66 && !xa67197c42bddc7dc.x347b79f9c616f92c.x332b663769fd4483)
		{
			return false;
		}
		xf6937c72cebe4ad1 x5a7799e1836857e = xa67197c42bddc7dc.x5a7799e1836857e3;
		int num = x5a7799e1836857e.x139412b8dea2f02b - x5906905c888d3d98.x56410a8dd70087c5.x887a0c79ecbe5ee3 + x5a7799e1836857e.xc821290d7ecc08bf;
		int num2 = x5a7799e1836857e.x139412b8dea2f02b + x5906905c888d3d98.x56410a8dd70087c5.x79a071bfba0c5e7d + x5a7799e1836857e.xc821290d7ecc08bf;
		if (xa8548d289a49a30a.Top < num && xa8548d289a49a30a.Bottom > num2)
		{
			return false;
		}
		return true;
	}

	internal void x3e1fd9da6cf38edc(xc7b875b517342f11 x5906905c888d3d98)
	{
		x9a66d03de2ff27e1 xda5bf54deb817e = new x9a66d03de2ff27e1(x8cedcaa9a62c6e39.xce92de628aa023cf(x5906905c888d3d98.xc22eade24b085d91), x5906905c888d3d98.x759aa16c2016a289);
		x8cedcaa9a62c6e39.x1fa9148f6731ff24(xda5bf54deb817e);
	}

	internal void x5f35398aa06d0b48(x988c1cad471a514c x5906905c888d3d98)
	{
		PointF xc22eade24b085d = x5906905c888d3d98.xc22eade24b085d91;
		string name = x5906905c888d3d98.xd438a3a8968e57e1.Name;
		xfa6279ffd07aa4c9 xfa6279ffd07aa4c;
		switch (x5906905c888d3d98.xd438a3a8968e57e1.xdda013621290d582)
		{
		case xdda013621290d582.xfd2f38e457ba1955:
		{
			xf8b7d3491a4bc1b0 xf8b7d3491a4bc1b = new xf8b7d3491a4bc1b0(xc22eade24b085d, name, x5906905c888d3d98.x437e3b626c0fdd43.Height);
			xf8b7d3491a4bc1b.xd2f68ee6f47e9dfb = "1" == x5906905c888d3d98.xd438a3a8968e57e1.Result;
			xfa6279ffd07aa4c = xf8b7d3491a4bc1b;
			break;
		}
		case xdda013621290d582.xca07ebdb4698a889:
		{
			int num = x5906905c888d3d98.xd438a3a8968e57e1.DropDownSelectedIndex;
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < x5906905c888d3d98.xd438a3a8968e57e1.DropDownItems.Count; i++)
			{
				arrayList.Add(x5906905c888d3d98.xd438a3a8968e57e1.DropDownItems[i]);
			}
			if (arrayList.Count <= 0)
			{
				arrayList.Add(" ");
			}
			if (0 > num || num >= arrayList.Count)
			{
				num = 0;
			}
			x3a68442d168cdd44 x3a68442d168cdd = new x3a68442d168cdd44(xc22eade24b085d, name, arrayList, num);
			xfa6279ffd07aa4c = x3a68442d168cdd;
			break;
		}
		case xdda013621290d582.x09e38cfc94ebc64d:
		{
			x8fd773b74dcec1bc x8fd773b74dcec1bc = new x8fd773b74dcec1bc(xc22eade24b085d, name, x5906905c888d3d98.x437e3b626c0fdd43, x5906905c888d3d98.xd438a3a8968e57e1.Result);
			x8fd773b74dcec1bc.xddffcb24e864cfcc = x5906905c888d3d98.xd49212c2bf5d3d12;
			x8fd773b74dcec1bc.x7e9904b269e29b39 = x5906905c888d3d98.xd438a3a8968e57e1.MaxLength;
			xfa6279ffd07aa4c = x8fd773b74dcec1bc;
			break;
		}
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ojagelhgokogokfhmkmhbldifkkiefbjhjijnjpjnjgkfjnkfeeliilliicmbijmfiankhhnddoneifogimokhdpmgkpcdba", 1805541449)));
		}
		xfa6279ffd07aa4c.xca1781db5d80e987 = x5906905c888d3d98.xd438a3a8968e57e1.Enabled;
		x8cedcaa9a62c6e39.x1fa9148f6731ff24(xfa6279ffd07aa4c);
	}

	private void xc7234004e9b72a7e(x038d2057eb729fcf x5906905c888d3d98)
	{
		Aspose.Words.Font xc2d4efc42998d87b = x5906905c888d3d98.xc2d4efc42998d87b;
		x26d9ecb4bdf0456d x0d380c5f7bca77a = x8cedcaa9a62c6e39.xa6dfa2703204e9f0(x5906905c888d3d98.xc2d4efc42998d87b.x63b1a7c31a962459);
		x26d9ecb4bdf0456d xc59904f088b0d = x33c8377c4846b3c6(x5906905c888d3d98, x0d380c5f7bca77a);
		x26d9ecb4bdf0456d x53218bf919efffd = x02290b0572ae1d5c(x5906905c888d3d98, x0d380c5f7bca77a);
		PointF pointF = x8cedcaa9a62c6e39.xce92de628aa023cf(x5906905c888d3d98.xc22eade24b085d91);
		string text = xb3b7cda06c7ad224(x5906905c888d3d98.xf9ad6fb78355fe13);
		float num = (xc2d4efc42998d87b.Emboss ? (-0.8f) : (xc2d4efc42998d87b.Engrave ? 0.8f : 0f));
		pointF = new PointF(pointF.X + num, pointF.Y + num);
		int num2 = x32643546889d99be(xc2d4efc42998d87b.Scaling);
		x54366fa5f75a02f7 x54366fa5f75a02f = null;
		if (num2 != 100)
		{
			x54366fa5f75a02f = new x54366fa5f75a02f7();
			float num3 = (float)num2 / 100f;
			x54366fa5f75a02f.xce92de628aa023cf((0f - pointF.X) * num3, 0f, MatrixOrder.Prepend);
			x54366fa5f75a02f.x5152a5707921c783(num3, 1f, MatrixOrder.Prepend);
			x54366fa5f75a02f.xce92de628aa023cf(pointF.X / num3, 0f, MatrixOrder.Prepend);
		}
		if (text.Length > 1 && (xc2d4efc42998d87b.Spacing != 0.0 || xe39d06eee35dd23d.x6a6bee62104c093d(xc2d4efc42998d87b.Name)))
		{
			x8f0cc12e56e6deb7(x5906905c888d3d98, text, pointF, x54366fa5f75a02f, x53218bf919efffd, xc59904f088b0d);
		}
		else
		{
			x7fefbbd84dea2c86(x5906905c888d3d98, text, pointF, x54366fa5f75a02f, x53218bf919efffd, xc59904f088b0d);
		}
	}

	private static int x32643546889d99be(int x00242dd6686d6459)
	{
		return Math.Max(1, x00242dd6686d6459);
	}

	private void x8f0cc12e56e6deb7(x038d2057eb729fcf x5906905c888d3d98, string xb41faee6912a2313, PointF x9c3c185e7046dc72, x54366fa5f75a02f7 x678241938de24d81, x26d9ecb4bdf0456d x53218bf919efffd4, x26d9ecb4bdf0456d xc59904f088b0d878)
	{
		float num = (float)x5906905c888d3d98.xc2d4efc42998d87b.Spacing * 100f / (float)x32643546889d99be(x5906905c888d3d98.xc2d4efc42998d87b.Scaling);
		PointF x9c3c185e7046dc73 = x9c3c185e7046dc72;
		x56410a8dd70087c5 x56410a8dd70087c = x5906905c888d3d98.x56410a8dd70087c5;
		x0a80b8c2d1e8cf13 x0a80b8c2d1e8cf = new x0a80b8c2d1e8cf13(new x115139807e6482f7(x5906905c888d3d98.xf9ad6fb78355fe13));
		foreach (int item in new x115139807e6482f7(xb41faee6912a2313))
		{
			string text = xdf3a1f89dca325a3.x251dbcb3221739c5(item);
			x0a80b8c2d1e8cf.x47f176deff0d42e2();
			string xb41faee6912a2314 = xdf3a1f89dca325a3.x251dbcb3221739c5((int)x0a80b8c2d1e8cf.x35cfcea4890f4e7d);
			x56410a8dd70087c5 x56410a8dd70087c2 = x42f2a218ce59dafb.xdcfd21791420d827(x56410a8dd70087c.x5566e2d2acbd1fbe, text, null);
			x56410a8dd70087c2.x705ed5f9769744e5 = x56410a8dd70087c.x705ed5f9769744e5;
			x56410a8dd70087c2.xb0f146032f47c24e = x56410a8dd70087c.xb0f146032f47c24e;
			x038d2057eb729fcf x5906905c888d3d99 = new x038d2057eb729fcf(x56410a8dd70087c2);
			x7fefbbd84dea2c86(x5906905c888d3d99, text, x9c3c185e7046dc73, x678241938de24d81, x53218bf919efffd4, xc59904f088b0d878);
			float num2 = x9c3c185e7046dc73.X + x5906905c888d3d98.xd49212c2bf5d3d12.xee2b4ba51feab3ca(xb41faee6912a2314);
			num2 += num;
			x9c3c185e7046dc73 = new PointF(num2, x9c3c185e7046dc73.Y);
		}
	}

	private void x7fefbbd84dea2c86(x038d2057eb729fcf x5906905c888d3d98, string xb41faee6912a2313, PointF x9c3c185e7046dc72, x54366fa5f75a02f7 x678241938de24d81, x26d9ecb4bdf0456d x53218bf919efffd4, x26d9ecb4bdf0456d xc59904f088b0d878)
	{
		x6a1731d9f22293e5(x5906905c888d3d98, x9c3c185e7046dc72, xb41faee6912a2313, x678241938de24d81);
		xcc8c7739d82c63ba xcc8c7739d82c63ba = x75193344c49d8a71(x5906905c888d3d98, x53218bf919efffd4, xc59904f088b0d878, x9c3c185e7046dc72, 0f, xb41faee6912a2313, x678241938de24d81);
		xcc8c7739d82c63ba.xd229d86af0f16fb0 = x5906905c888d3d98.x5566e2d2acbd1fbe;
		xcc8c7739d82c63ba.xc9bcfb2d9630b0c7 = x6a61ddb1d1e8f259(x5906905c888d3d98);
	}

	private x26d9ecb4bdf0456d x02290b0572ae1d5c(x038d2057eb729fcf x5906905c888d3d98, x26d9ecb4bdf0456d x0d380c5f7bca77a3)
	{
		Aspose.Words.Font xc2d4efc42998d87b = x5906905c888d3d98.xc2d4efc42998d87b;
		x26d9ecb4bdf0456d x26d9ecb4bdf0456d = x26d9ecb4bdf0456d.x45260ad4b94166f2;
		if (xc2d4efc42998d87b.Outline)
		{
			if (xc2d4efc42998d87b.Shadow)
			{
				x26d9ecb4bdf0456d = xc54e4d79e1c0e1c7(x5906905c888d3d98);
				if (x26d9ecb4bdf0456d.x7149c962c02931b3)
				{
					x26d9ecb4bdf0456d = x26d9ecb4bdf0456d.x8f02f53f1587477d;
				}
			}
		}
		else
		{
			x26d9ecb4bdf0456d = x0d380c5f7bca77a3;
		}
		return x26d9ecb4bdf0456d;
	}

	private x26d9ecb4bdf0456d x33c8377c4846b3c6(x038d2057eb729fcf x5906905c888d3d98, x26d9ecb4bdf0456d x0d380c5f7bca77a3)
	{
		if (!x5906905c888d3d98.xc2d4efc42998d87b.Outline)
		{
			return x26d9ecb4bdf0456d.x45260ad4b94166f2;
		}
		return x0d380c5f7bca77a3;
	}

	private void xc698485eba912f6e(x038d2057eb729fcf x5906905c888d3d98, PointF x6128bb1902f8d517, string xb41faee6912a2313, x54366fa5f75a02f7 x678241938de24d81)
	{
		x26d9ecb4bdf0456d x26d9ecb4bdf0456d = x6a843a40faf5e532(x5906905c888d3d98);
		float x374ea4fe62468d0f = x07048d040f15c88c(x5906905c888d3d98.xd49212c2bf5d3d12.x53531537bb3331e6);
		x75193344c49d8a71(x5906905c888d3d98, x26d9ecb4bdf0456d, x26d9ecb4bdf0456d, x6128bb1902f8d517, x374ea4fe62468d0f, xb41faee6912a2313, x678241938de24d81);
	}

	private void x4ba0236e4260b67c(x038d2057eb729fcf x5906905c888d3d98, PointF x6128bb1902f8d517, string xb41faee6912a2313, x54366fa5f75a02f7 x678241938de24d81)
	{
		x26d9ecb4bdf0456d x26d9ecb4bdf0456d = xc54e4d79e1c0e1c7(x5906905c888d3d98);
		if (x26d9ecb4bdf0456d.x7149c962c02931b3)
		{
			x26d9ecb4bdf0456d = x26d9ecb4bdf0456d.x8f02f53f1587477d;
		}
		x26d9ecb4bdf0456d x26d9ecb4bdf0456d2 = xb331151dc0f40276(x26d9ecb4bdf0456d);
		x26d9ecb4bdf0456d x26d9ecb4bdf0456d3 = x5aba14cb467ae5d2(x26d9ecb4bdf0456d);
		if (x5906905c888d3d98.xc2d4efc42998d87b.Engrave)
		{
			x26d9ecb4bdf0456d x26d9ecb4bdf0456d4 = x26d9ecb4bdf0456d3;
			x26d9ecb4bdf0456d3 = x26d9ecb4bdf0456d2;
			x26d9ecb4bdf0456d2 = x26d9ecb4bdf0456d4;
		}
		x75193344c49d8a71(x5906905c888d3d98, x26d9ecb4bdf0456d2, x33c8377c4846b3c6(x5906905c888d3d98, x26d9ecb4bdf0456d2), x6128bb1902f8d517, 0.8f, xb41faee6912a2313, x678241938de24d81);
		x75193344c49d8a71(x5906905c888d3d98, x26d9ecb4bdf0456d3, x33c8377c4846b3c6(x5906905c888d3d98, x26d9ecb4bdf0456d3), x6128bb1902f8d517, -0.8f, xb41faee6912a2313, x678241938de24d81);
	}

	private xcc8c7739d82c63ba x75193344c49d8a71(x038d2057eb729fcf x5906905c888d3d98, x26d9ecb4bdf0456d x53218bf919efffd4, x26d9ecb4bdf0456d xc59904f088b0d878, PointF x6128bb1902f8d517, float x374ea4fe62468d0f, string xb41faee6912a2313, x54366fa5f75a02f7 x678241938de24d81)
	{
		xcc8c7739d82c63ba xcc8c7739d82c63ba = new xcc8c7739d82c63ba(x5906905c888d3d98.xd49212c2bf5d3d12, x53218bf919efffd4, xc59904f088b0d878, new PointF(x6128bb1902f8d517.X + x374ea4fe62468d0f, x6128bb1902f8d517.Y + x374ea4fe62468d0f), xb41faee6912a2313, new SizeF(x5906905c888d3d98.x887b872a95caaab5, x5906905c888d3d98.xb0f146032f47c24e), (float)x5906905c888d3d98.xc2d4efc42998d87b.Spacing, x247ed81d1f186ef7(x5906905c888d3d98.x56410a8dd70087c5));
		xcc8c7739d82c63ba.x52dde376accdec7d = x678241938de24d81;
		if (x5906905c888d3d98.x887b872a95caaab5 > 0f)
		{
			x8cedcaa9a62c6e39.x1fa9148f6731ff24(xcc8c7739d82c63ba);
		}
		return xcc8c7739d82c63ba;
	}

	internal static x26d9ecb4bdf0456d xb331151dc0f40276(x26d9ecb4bdf0456d x154083d58301ef75)
	{
		float num = 0.6f;
		return x26d9ecb4bdf0456d.xd378227c730f388c(x154083d58301ef75.xda71bf6f7c07c3bc, (int)((float)x154083d58301ef75.xc613adc4330033f3 * num), (int)((float)x154083d58301ef75.x26463655896fd90a * num), (int)((float)x154083d58301ef75.x8e8f6cc6a0756b05 * num));
	}

	internal static x26d9ecb4bdf0456d x5aba14cb467ae5d2(x26d9ecb4bdf0456d x154083d58301ef75)
	{
		x26d9ecb4bdf0456d result = x26d9ecb4bdf0456d.x89fffa2751fdecbe;
		if (!x154083d58301ef75.x7149c962c02931b3 && (x154083d58301ef75.xc613adc4330033f3 != x154083d58301ef75.x26463655896fd90a || x154083d58301ef75.x26463655896fd90a != x154083d58301ef75.x8e8f6cc6a0756b05))
		{
			x01f74f175f4a1d3d x01f74f175f4a1d3d = new x01f74f175f4a1d3d(x154083d58301ef75);
			float num = ((x01f74f175f4a1d3d.x7140fff2ddcc94a1 > 0.5) ? 0.8f : 1.2f);
			x01f74f175f4a1d3d.x7140fff2ddcc94a1 *= num;
			result = x01f74f175f4a1d3d.x1659cb35054965d4();
		}
		return result;
	}

	internal static x26d9ecb4bdf0456d xc54e4d79e1c0e1c7(x038d2057eb729fcf x5906905c888d3d98)
	{
		if (x5906905c888d3d98.x9fb0e9c0b1bdc4b3.x332a8eedb847940d is x8d9303345f12a846)
		{
			return ((x8d9303345f12a846)x5906905c888d3d98.x9fb0e9c0b1bdc4b3.x332a8eedb847940d).xa79651e2f1a1416e.x554aca059bdf6d48.x83729c7ebf48ae24;
		}
		return x26d9ecb4bdf0456d.x45260ad4b94166f2;
	}

	internal static x26d9ecb4bdf0456d x6a843a40faf5e532(x038d2057eb729fcf x5906905c888d3d98)
	{
		x26d9ecb4bdf0456d x26d9ecb4bdf0456d = xc54e4d79e1c0e1c7(x5906905c888d3d98);
		if (!x26d9ecb4bdf0456d.x7149c962c02931b3)
		{
			if (x26d9ecb4bdf0456d.xb2c94956116ca10a() == x5906905c888d3d98.xc2d4efc42998d87b.Color.ToArgb())
			{
				return x26d9ecb4bdf0456d.x89fffa2751fdecbe;
			}
			if (x26d9ecb4bdf0456d.xc613adc4330033f3 < 56 || x26d9ecb4bdf0456d.x26463655896fd90a < 56 || x26d9ecb4bdf0456d.x8e8f6cc6a0756b05 < 56)
			{
				return x26d9ecb4bdf0456d.x8f02f53f1587477d;
			}
		}
		return x26d9ecb4bdf0456d.xd378227c730f388c(255, 192, 192, 192);
	}

	internal static float x07048d040f15c88c(float x5c021e387157a637)
	{
		return x5c021e387157a637 * 0.042f;
	}

	private string xb3b7cda06c7ad224(string xb41faee6912a2313)
	{
		if (!x8cedcaa9a62c6e39.xdeb77ea37ad74c56.xc140e3669091ae41)
		{
			return xb41faee6912a2313;
		}
		if (xb41faee6912a2313.Equals(ControlChar.x3e1feffd8ca6feb2))
		{
			return x6da6efa5a7623bdb.x06da1ae0ac8f70c8;
		}
		return xb41faee6912a2313.Replace(ControlChar.x3e1feffd8ca6feb2, x6da6efa5a7623bdb.x06da1ae0ac8f70c8);
	}

	private void xc61a0e13341003ec(x038d2057eb729fcf x5906905c888d3d98, string xb41faee6912a2313, xe39d06eee35dd23d xab6b30956a425d96)
	{
		SizeF size = xab6b30956a425d96.x6e21842ebf5f70df(xb41faee6912a2313);
		PointF x2f7096dac971d6ec = new PointF(x5906905c888d3d98.xc22eade24b085d91.X + (x5906905c888d3d98.x887b872a95caaab5 - size.Width) / 2f, x5906905c888d3d98.xc22eade24b085d91.Y);
		xcc8c7739d82c63ba xcc8c7739d82c63ba = new xcc8c7739d82c63ba(xab6b30956a425d96, x26d9ecb4bdf0456d.x89fffa2751fdecbe, x26d9ecb4bdf0456d.x45260ad4b94166f2, x8cedcaa9a62c6e39.xce92de628aa023cf(x2f7096dac971d6ec), xb41faee6912a2313, size, 0f);
		xcc8c7739d82c63ba.xd229d86af0f16fb0 = x5906905c888d3d98.x5566e2d2acbd1fbe;
		xcc8c7739d82c63ba.xc9bcfb2d9630b0c7 = x6a61ddb1d1e8f259(x5906905c888d3d98);
		x8cedcaa9a62c6e39.x1fa9148f6731ff24(xcc8c7739d82c63ba);
	}

	private xa702b771604efc86 x6a61ddb1d1e8f259(x038d2057eb729fcf x5906905c888d3d98)
	{
		if (x5906905c888d3d98.x33e0a63c396e274b != null)
		{
			return new xa702b771604efc86(x8cedcaa9a62c6e39.xce92de628aa023cf(x5906905c888d3d98.x007986b943c7e3cf), x5906905c888d3d98.x33e0a63c396e274b);
		}
		return null;
	}

	private void xc51f83f6aa731e5b(x038d2057eb729fcf x5906905c888d3d98, string xb41faee6912a2313)
	{
		xe39d06eee35dd23d x26094932cf7a = ((!x09d499c483428bd1.xadc83cc585a89881(x5906905c888d3d98.xc2d4efc42998d87b.Name)) ? x5906905c888d3d98.xd49212c2bf5d3d12 : x9d888f53892d94df.x9834ddb0e0bd5996.x491f5a7224612753("Times New Roman", (float)x5906905c888d3d98.xc2d4efc42998d87b.Size, x5906905c888d3d98.xc2d4efc42998d87b.xfa47517dba72fd20));
		x6a1731d9f22293e5(x5906905c888d3d98, x8cedcaa9a62c6e39.xce92de628aa023cf(x5906905c888d3d98.xc22eade24b085d91), xb41faee6912a2313, null);
		x26d9ecb4bdf0456d x0d380c5f7bca77a = x8cedcaa9a62c6e39.xa6dfa2703204e9f0(x5906905c888d3d98.xc2d4efc42998d87b.x63b1a7c31a962459);
		x26d9ecb4bdf0456d xc59904f088b0d = x33c8377c4846b3c6(x5906905c888d3d98, x0d380c5f7bca77a);
		x26d9ecb4bdf0456d x6c50a99faab7d = x02290b0572ae1d5c(x5906905c888d3d98, x0d380c5f7bca77a);
		x6c8fd1ec8d9fc281(x5906905c888d3d98.xc22eade24b085d91, xb41faee6912a2313, x26094932cf7a, x6c50a99faab7d, xc59904f088b0d);
	}

	private void x6a1731d9f22293e5(x038d2057eb729fcf x5906905c888d3d98, PointF x9c3c185e7046dc72, string xb41faee6912a2313, x54366fa5f75a02f7 x678241938de24d81)
	{
		if (x5906905c888d3d98.xc2d4efc42998d87b.Emboss || x5906905c888d3d98.xc2d4efc42998d87b.Engrave)
		{
			x4ba0236e4260b67c(x5906905c888d3d98, x9c3c185e7046dc72, xb41faee6912a2313, x678241938de24d81);
		}
		else if (x5906905c888d3d98.xc2d4efc42998d87b.Shadow)
		{
			xc698485eba912f6e(x5906905c888d3d98, x9c3c185e7046dc72, xb41faee6912a2313, x678241938de24d81);
		}
	}

	private void x7df55bf4e058b47f(PointF x9c3c185e7046dc72, string xb41faee6912a2313)
	{
		xe39d06eee35dd23d x26094932cf7a = x9d888f53892d94df.x9834ddb0e0bd5996.x491f5a7224612753("Arial", 8f, FontStyle.Regular);
		x6c8fd1ec8d9fc281(x9c3c185e7046dc72, xb41faee6912a2313, x26094932cf7a, x26d9ecb4bdf0456d.x89fffa2751fdecbe, x26d9ecb4bdf0456d.x45260ad4b94166f2);
	}

	private void xf9369809c1d1f8a2(PointF x9c3c185e7046dc72)
	{
		xe39d06eee35dd23d x26094932cf7a = x9d888f53892d94df.x9834ddb0e0bd5996.x491f5a7224612753("Wingdings 3", 12f, FontStyle.Regular);
		x6c8fd1ec8d9fc281(x9c3c185e7046dc72, "\uf038", x26094932cf7a, x26d9ecb4bdf0456d.x89fffa2751fdecbe, x26d9ecb4bdf0456d.x45260ad4b94166f2);
	}

	private void x6c8fd1ec8d9fc281(PointF x9c3c185e7046dc72, string xb41faee6912a2313, xe39d06eee35dd23d x26094932cf7a9139, x26d9ecb4bdf0456d x6c50a99faab7d741, x26d9ecb4bdf0456d xc59904f088b0d878)
	{
		SizeF size = x26094932cf7a9139.x6e21842ebf5f70df(xb41faee6912a2313);
		xcc8c7739d82c63ba xda5bf54deb817e = new xcc8c7739d82c63ba(x26094932cf7a9139, x6c50a99faab7d741, xc59904f088b0d878, x8cedcaa9a62c6e39.xce92de628aa023cf(x9c3c185e7046dc72), xb41faee6912a2313, size, 0f);
		x8cedcaa9a62c6e39.x1fa9148f6731ff24(xda5bf54deb817e);
	}

	private void xf783a6243ed7ab79(xfb07b2a80e43c2cc x5906905c888d3d98)
	{
		char c = x572ba55cf433c73d(x5906905c888d3d98.x902d63c74e3c13c4);
		if (c != 0)
		{
			float num = x5906905c888d3d98.xd49212c2bf5d3d12.x30e45ef93fedb4ba(c);
			int count = (int)(x5906905c888d3d98.x887b872a95caaab5 / num);
			float num2 = x5906905c888d3d98.x887b872a95caaab5 % num;
			string text = new string(c, count);
			xcd3694ded987e19d xcd3694ded987e19d = new xcd3694ded987e19d(x5906905c888d3d98, text);
			xcd3694ded987e19d.xc22eade24b085d91 = new PointF(x5906905c888d3d98.xc22eade24b085d91.X + num2, x5906905c888d3d98.xc22eade24b085d91.Y);
			xc7234004e9b72a7e(xcd3694ded987e19d);
		}
	}

	private static char x572ba55cf433c73d(TabLeader xb5fc2acab7dbaa12)
	{
		return xb5fc2acab7dbaa12 switch
		{
			TabLeader.Dots => '.', 
			TabLeader.Dashes => '-', 
			TabLeader.Line => '_', 
			TabLeader.MiddleDot => '∙', 
			TabLeader.Heavy => '_', 
			_ => '\0', 
		};
	}

	private void x12ca3a3e2d5518cd(x038d2057eb729fcf x5906905c888d3d98)
	{
		x8cedcaa9a62c6e39.x00149f2495b0f026(x5906905c888d3d98.xc2d4efc42998d87b.Shading);
		x9390351fca2a4019(x5906905c888d3d98);
		x48c026c3dc59985f(x5906905c888d3d98);
		x455550a456ba4ff8(x5906905c888d3d98);
	}

	private void xc57fb21ab216f7ff(x038d2057eb729fcf x5906905c888d3d98)
	{
		x85d19d8adea6938a(x5906905c888d3d98);
		x9fc085e06e4bf05d.x1a432fbdc290755d(x5906905c888d3d98);
		x16c1fa2b17e1e8ac(x5906905c888d3d98);
		x8cedcaa9a62c6e39.xbcd358ebb8d4e95e();
		if (!x8cedcaa9a62c6e39.xdeb77ea37ad74c56.x8ebe7aeb5cab0885.x7149c962c02931b3 && !(x5906905c888d3d98 is xa7492065dee59ad0))
		{
			x8cedcaa9a62c6e39.xee63d905da8ff550(x8cedcaa9a62c6e39.xce92de628aa023cf(x5906905c888d3d98.x007986b943c7e3cf), x8cedcaa9a62c6e39.xdeb77ea37ad74c56.x8ebe7aeb5cab0885);
		}
	}

	private void x455550a456ba4ff8(x038d2057eb729fcf x5906905c888d3d98)
	{
	}

	private void x9390351fca2a4019(x038d2057eb729fcf x5906905c888d3d98)
	{
		if (x5906905c888d3d98.xc2d4efc42998d87b.Shading.xa853df7acdb217c8)
		{
			x3bc42b548f62bdca.xa4520be1beb8f046(x8cedcaa9a62c6e39.xce92de628aa023cf(x5906905c888d3d98.x8d3e220b8546945e), x5906905c888d3d98.xc2d4efc42998d87b.Shading, x8cedcaa9a62c6e39);
		}
	}

	private void x48c026c3dc59985f(x038d2057eb729fcf x5906905c888d3d98)
	{
		if (!x5906905c888d3d98.xc2d4efc42998d87b.xff8cd6f1d57322e6.x7149c962c02931b3)
		{
			x8cedcaa9a62c6e39.x98c00ccab44bf40d(x5b0ea7c4a9d65903.xddc161df8aebe771);
			xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.x7c89cd07f845b8e1(x8cedcaa9a62c6e39.xce92de628aa023cf(x5906905c888d3d98.x8d3e220b8546945e));
			xab391c46ff9a0a.x60465f602599d327 = new xc020fa2f5133cba8(x5906905c888d3d98.xc2d4efc42998d87b.xff8cd6f1d57322e6);
			x8cedcaa9a62c6e39.x1fa9148f6731ff24(xab391c46ff9a0a);
			x8cedcaa9a62c6e39.xf5b0b9b6ff7ac462();
		}
	}

	private void x85d19d8adea6938a(x038d2057eb729fcf x5906905c888d3d98)
	{
		if (x5906905c888d3d98.xc2d4efc42998d87b.StrikeThrough)
		{
			float num = x5906905c888d3d98.xc2d4efc42998d87b.xe286def5a6a116b8(x282df02f8c72bc6f: true) * 0.23f;
			float x1e218ceaee1bb = x5906905c888d3d98.xc22eade24b085d91.Y - num;
			x0fc1a86a1f575d0f(x5906905c888d3d98, x1e218ceaee1bb);
		}
		else if (x5906905c888d3d98.xc2d4efc42998d87b.DoubleStrikeThrough)
		{
			for (int i = 0; i < 2; i++)
			{
				float num2 = x5906905c888d3d98.xc2d4efc42998d87b.xe286def5a6a116b8(x282df02f8c72bc6f: true) * xe52155d15d2da086[i];
				float x1e218ceaee1bb2 = x5906905c888d3d98.xc22eade24b085d91.Y - num2;
				x0fc1a86a1f575d0f(x5906905c888d3d98, x1e218ceaee1bb2);
			}
		}
	}

	private void x0fc1a86a1f575d0f(x038d2057eb729fcf x5906905c888d3d98, float x1e218ceaee1bb583)
	{
		PointF x2f7096dac971d6ec = new PointF(x5906905c888d3d98.xc22eade24b085d91.X, x1e218ceaee1bb583);
		PointF x2f7096dac971d6ec2 = new PointF(x5906905c888d3d98.xc22eade24b085d91.X + x5906905c888d3d98.x887b872a95caaab5, x1e218ceaee1bb583);
		float width = x5906905c888d3d98.xc2d4efc42998d87b.xe286def5a6a116b8(x282df02f8c72bc6f: true) * 0.05f;
		xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.xb471d14948c54f27(x8cedcaa9a62c6e39.xce92de628aa023cf(x2f7096dac971d6ec), x8cedcaa9a62c6e39.xce92de628aa023cf(x2f7096dac971d6ec2));
		xab391c46ff9a0a.x9e5d5f9128c69a8f = new x31c19fcb724dfaf5(x8cedcaa9a62c6e39.xa6dfa2703204e9f0(x5906905c888d3d98.xc2d4efc42998d87b.x63b1a7c31a962459), width);
		x8cedcaa9a62c6e39.x1fa9148f6731ff24(xab391c46ff9a0a);
	}

	private void x16c1fa2b17e1e8ac(x038d2057eb729fcf x5906905c888d3d98)
	{
		Border border = x5906905c888d3d98.xc2d4efc42998d87b.Border;
		if (border.IsVisible)
		{
			if (!x8ca854032a09b9e0.x72d46409b45c5b53)
			{
				x8ca854032a09b9e0.xc28dff9f03c0d48f();
			}
			RectangleF x007986b943c7e3cf = x5906905c888d3d98.x007986b943c7e3cf;
			float val = x4574ea26106f0edb.xc96d70553223ee04(x5906905c888d3d98.x9fb0e9c0b1bdc4b3.xc255c495fd9232ca.xb0f146032f47c24e);
			RectangleF x26545669838eb36e = new RectangleF(x007986b943c7e3cf.X, Math.Max(0f, x007986b943c7e3cf.Y), x007986b943c7e3cf.Width, Math.Min(val, x007986b943c7e3cf.Height));
			x8ca854032a09b9e0.xb1e2c9a68308ad60(x8cedcaa9a62c6e39.xce92de628aa023cf(x26545669838eb36e), x5906905c888d3d98.xf456709e18aac75a ? border : Border.x45260ad4b94166f2, x5906905c888d3d98.xb987620b63e60ab6 ? border : Border.x45260ad4b94166f2, border, border);
			if (x5906905c888d3d98.xb987620b63e60ab6)
			{
				x8ca854032a09b9e0.xb0770b4ea658e78d(x8cedcaa9a62c6e39);
			}
		}
	}

	private static bool x247ed81d1f186ef7(x56410a8dd70087c5 x5906905c888d3d98)
	{
		if (x5906905c888d3d98.x4a1a6d8b0aafa0fe == x4a1a6d8b0aafa0fe.x0b228ef3d2b6a257)
		{
			return x5906905c888d3d98.x3a03159a374ab4fd == 1;
		}
		return false;
	}
}
