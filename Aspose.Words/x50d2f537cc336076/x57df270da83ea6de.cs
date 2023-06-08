using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Words.Math;
using x1c8faa688b1f0b0c;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using xe5b37aee2c2a4d4e;

namespace x50d2f537cc336076;

internal class x57df270da83ea6de
{
	internal RectangleF x6ae4612a8469678e;

	private float x8654063f93053b7f = float.NaN;

	private bool x71c6a0d27363d546 = true;

	private xb8e7e788f6d59708 x87f8561aebf828bc;

	private ArrayList xddc60c8d74d0f01b = new ArrayList();

	private float x608d575bad4fc435;

	private OfficeMath xd3e103c3475b9b31;

	internal float x43a729b39a97938d
	{
		get
		{
			if (float.IsNaN(x8654063f93053b7f))
			{
				x8654063f93053b7f = x6ae4612a8469678e.Height / 2f;
			}
			return x8654063f93053b7f;
		}
		set
		{
			x8654063f93053b7f = value;
		}
	}

	internal xb8e7e788f6d59708 xefb7a8f84373ac04 => x87f8561aebf828bc;

	internal ArrayList xf2453c298c5de6f5 => xddc60c8d74d0f01b;

	internal xeedad81aaed42a76 xeedad81aaed42a76 => xd3e103c3475b9b31.xeedad81aaed42a76;

	internal OfficeMath xc48e358ce4f81353 => xd3e103c3475b9b31;

	internal x26d9ecb4bdf0456d xa1088ce63fcbe744
	{
		get
		{
			if (!(xeedad81aaed42a76.x9b41425268471380 == x26d9ecb4bdf0456d.x45260ad4b94166f2))
			{
				return xeedad81aaed42a76.x9b41425268471380;
			}
			return x26d9ecb4bdf0456d.x89fffa2751fdecbe;
		}
	}

	internal x57df270da83ea6de(OfficeMath officeMath)
	{
		x6ae4612a8469678e = default(RectangleF);
		x87f8561aebf828bc = new xb8e7e788f6d59708();
		xd3e103c3475b9b31 = officeMath;
	}

	internal virtual void x1fa9148f6731ff24(x57df270da83ea6de x4bbc2c453c470189)
	{
		xddc60c8d74d0f01b.Add(x4bbc2c453c470189);
	}

	internal virtual void xb7ae55095fddecd9()
	{
		if (!x71c6a0d27363d546)
		{
			return;
		}
		x62084450a0785b90();
		foreach (x57df270da83ea6de item in xddc60c8d74d0f01b)
		{
			xefb7a8f84373ac04.xd6b6ed77479ef68c(item.xefb7a8f84373ac04);
			float x6842879318972d9e = x43a729b39a97938d - item.x43a729b39a97938d;
			if (item.xefb7a8f84373ac04.x52dde376accdec7d == null)
			{
				item.xefb7a8f84373ac04.x52dde376accdec7d = new x54366fa5f75a02f7();
			}
			item.xefb7a8f84373ac04.x52dde376accdec7d.xce92de628aa023cf(x608d575bad4fc435, x6842879318972d9e, MatrixOrder.Append);
			x608d575bad4fc435 += item.x6ae4612a8469678e.Width;
		}
		x6ae4612a8469678e = new RectangleF(x6ae4612a8469678e.X, x6ae4612a8469678e.Y, x608d575bad4fc435, x6ae4612a8469678e.Height);
		x526b49d71f4f42a6();
		x71c6a0d27363d546 = false;
	}

	internal virtual void x62084450a0785b90()
	{
		foreach (x57df270da83ea6de item in xddc60c8d74d0f01b)
		{
			item.xb7ae55095fddecd9();
			x5c013976a3dd29e6(item);
		}
	}

	internal void x5c013976a3dd29e6(x57df270da83ea6de x4bbc2c453c470189)
	{
		float num = x6ae4612a8469678e.Height - x8654063f93053b7f;
		float num2 = x4bbc2c453c470189.x6ae4612a8469678e.Height - x4bbc2c453c470189.x43a729b39a97938d;
		x8654063f93053b7f = ((x8654063f93053b7f > x4bbc2c453c470189.x43a729b39a97938d) ? x8654063f93053b7f : x4bbc2c453c470189.x43a729b39a97938d);
		float num3 = x8654063f93053b7f + ((num > num2) ? num : num2);
		if (x6ae4612a8469678e.Height <= num3)
		{
			x6ae4612a8469678e = new RectangleF(x6ae4612a8469678e.X, x6ae4612a8469678e.Y, x6ae4612a8469678e.Width, num3);
		}
	}

	internal void x5152a5707921c783(float xb5c369f64ea369e5, float x9b8af180a4e21ec1)
	{
		if (x87f8561aebf828bc.x52dde376accdec7d == null)
		{
			x87f8561aebf828bc.x52dde376accdec7d = new x54366fa5f75a02f7();
		}
		x87f8561aebf828bc.x52dde376accdec7d.x5152a5707921c783(xb5c369f64ea369e5, x9b8af180a4e21ec1, MatrixOrder.Append);
		x6ae4612a8469678e = x87f8561aebf828bc.x52dde376accdec7d.xaccac17571a8d9fa(x6ae4612a8469678e);
		x8654063f93053b7f *= x9b8af180a4e21ec1;
	}

	private void x526b49d71f4f42a6()
	{
		float width = (float)xeedad81aaed42a76.x437e3b626c0fdd43 / 30f;
		if (xd3e103c3475b9b31.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x78451b450fb7d099 || xd3e103c3475b9b31.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.xced856c17df679c5)
		{
			xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
			xab391c46ff9a0a.x9e5d5f9128c69a8f = new x31c19fcb724dfaf5(new xc020fa2f5133cba8(xa1088ce63fcbe744), width);
			x1cab6af0a41b70e2 xda5bf54deb817e;
			if (xd3e103c3475b9b31.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x78451b450fb7d099)
			{
				xda5bf54deb817e = x1cab6af0a41b70e2.x7c89cd07f845b8e1(x6ae4612a8469678e);
			}
			else
			{
				xc7b86a71e45628c2 xc7b86a71e45628c = (xc7b86a71e45628c2)xd3e103c3475b9b31.x52642f91ccdeeb35;
				float y = ((xc7b86a71e45628c.xbe1e23e7d5b43370 == xce8b2ce767b2485c.xe360b1885d8d4a41) ? x6ae4612a8469678e.Top : x6ae4612a8469678e.Bottom);
				PointF x10aaa7cdfa38f = new PointF(x6ae4612a8469678e.Left, y);
				PointF xca09b6c2b5b = new PointF(x6ae4612a8469678e.Right, y);
				xda5bf54deb817e = x1cab6af0a41b70e2.xb471d14948c54f27(x10aaa7cdfa38f, xca09b6c2b5b);
			}
			xab391c46ff9a0a.xd6b6ed77479ef68c(xda5bf54deb817e);
			x87f8561aebf828bc.xd6b6ed77479ef68c(xab391c46ff9a0a);
		}
	}
}
