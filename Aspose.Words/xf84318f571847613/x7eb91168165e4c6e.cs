using System.IO;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x1495530f35d79681;
using x28925c9b27b37a46;
using x4c895f6c49b1bff5;
using xf9a9481c3f63a419;

namespace xf84318f571847613;

internal class x7eb91168165e4c6e
{
	private DrawingML x61f18ca85b7c2226;

	private x3c85359e1389ad43 xc3723d392789e04d;

	private Shape x317be79405176667;

	internal Shape x5b81632e5b71b64c(DrawingML xb3c5925d90ebc5f0)
	{
		x61f18ca85b7c2226 = xb3c5925d90ebc5f0;
		x317be79405176667 = null;
		MemoryStream memoryStream = new MemoryStream();
		xd165c26d81eb4a1e.x8ebf37a8980eb562(x61f18ca85b7c2226.xb327816528e8798b, memoryStream);
		memoryStream.Position = 0L;
		xc3723d392789e04d = new x3c85359e1389ad43(memoryStream);
		xffe8719b6d87d067();
		if (x317be79405176667 != null)
		{
			x317be79405176667.xeedad81aaed42a76 = (xeedad81aaed42a76)x61f18ca85b7c2226.xeedad81aaed42a76.x8b61531c8ea35b85();
			x5faffbcdf0f573c6();
		}
		return x317be79405176667;
	}

	private void x5faffbcdf0f573c6()
	{
		if ((bool)x317be79405176667.xf7125312c7ee115c.xfe91eeeafcb3026a(446))
		{
			xf7125312c7ee115c xf7125312c7ee115c = x317be79405176667.xf7125312c7ee115c;
			int x90a2a80844ac0e7d = (int)xf7125312c7ee115c.xfe91eeeafcb3026a(404);
			int x65e1259faf40cf = (int)xf7125312c7ee115c.xfe91eeeafcb3026a(401);
			int x90a2a80844ac0e7d2 = (int)xf7125312c7ee115c.xfe91eeeafcb3026a(403);
			int x65e1259faf40cf2 = (int)xf7125312c7ee115c.xfe91eeeafcb3026a(402);
			double xd19556b84468224c = (double)xf7125312c7ee115c.xfe91eeeafcb3026a(260);
			double xd19556b84468224c2 = (double)xf7125312c7ee115c.xfe91eeeafcb3026a(261);
			double num = x317be79405176667.Width;
			double num2 = x317be79405176667.Height;
			double num3 = xebfbff2096a585c1(num, xd19556b84468224c, x65e1259faf40cf, x90a2a80844ac0e7d2);
			double num4 = xebfbff2096a585c1(num2, xd19556b84468224c2, x65e1259faf40cf2, x90a2a80844ac0e7d);
			if (num3 > num4)
			{
				num2 *= num4 / num3;
			}
			else
			{
				num *= num3 / num4;
			}
			xf7125312c7ee115c.xae20093bed1e48a8(4131, num);
			xf7125312c7ee115c.xae20093bed1e48a8(4132, num2);
		}
	}

	private static double xebfbff2096a585c1(double xef6aa17754566a9c, double xd19556b84468224c, int x65e1259faf40cf86, int x90a2a80844ac0e7d)
	{
		double num = x95d37387163b57db.x1acd48d5a10b1315(x65e1259faf40cf86) + x95d37387163b57db.x1acd48d5a10b1315(x90a2a80844ac0e7d);
		if (num > 0.0)
		{
			xef6aa17754566a9c *= num;
		}
		return xd19556b84468224c / xef6aa17754566a9c;
	}

	private void xffe8719b6d87d067()
	{
		while (xc3723d392789e04d.x152cbadbfa8061b1("graphic"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xc3723d392789e04d.xa66385d80d4d296f) != null && xa66385d80d4d296f == "graphicData")
			{
				x85d408c887af682f();
			}
			else
			{
				xc3723d392789e04d.IgnoreElement();
			}
		}
	}

	private void x85d408c887af682f()
	{
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xc3723d392789e04d.xa66385d80d4d296f) != null)
			{
				_ = xa66385d80d4d296f == "uri";
			}
		}
		while (xc3723d392789e04d.x152cbadbfa8061b1("graphicData"))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "pic":
			{
				xf7125312c7ee115c xf7125312c7ee115c = (xf7125312c7ee115c)x61f18ca85b7c2226.xf7125312c7ee115c.x8b61531c8ea35b85();
				x317be79405176667 = new Shape(x61f18ca85b7c2226.Document);
				x317be79405176667.xf7125312c7ee115c = xf7125312c7ee115c;
				x317be79405176667.x88d1b78392d1a0ab(ShapeType.Image);
				x88cc21ed387e51b7 x88cc21ed387e51b8 = new x88cc21ed387e51b7(x61f18ca85b7c2226.xaf782602efcbdda1(), xc3723d392789e04d);
				x88cc21ed387e51b8.x14a565c15004b08c(x317be79405176667);
				break;
			}
			default:
				xc3723d392789e04d.IgnoreElement();
				break;
			}
		}
	}
}
