using System.Collections;
using System.Diagnostics;
using Aspose.Words;
using xeb665d1aeef09d64;

namespace x4adf554d20d941a6;

internal class x3c81b884cf5d3405
{
	private readonly xac6c82c74ce247fb x2c9b21f64c8361c0;

	private x56410a8dd70087c5 x749f8493ad444bdb;

	private x56410a8dd70087c5 x576773fbf9307688;

	private int x32da7b51aa81365b;

	private readonly xf3f447691ab38eee x4215dc623c1e4f14;

	internal x3c81b884cf5d3405(xac6c82c74ce247fb layout)
	{
		x2c9b21f64c8361c0 = layout;
		x4215dc623c1e4f14 = x2c9b21f64c8361c0.xb3a79d506b0e2f7f.x8b61531c8ea35b85();
	}

	internal void xef23aa45e7612fdd(x56410a8dd70087c5 xd9ff4dee1dba180e, x56410a8dd70087c5 x5906905c888d3d98)
	{
		x5906905c888d3d98.x53111d6596d16a99 = x2c9b21f64c8361c0;
		if (xd9ff4dee1dba180e == null)
		{
			x4215dc623c1e4f14.x6cfb41b4bd00d940();
			x4215dc623c1e4f14.xef23aa45e7612fdd(x5906905c888d3d98, x5906905c888d3d98.x1be93eed8950d961);
			x4215dc623c1e4f14.x355eaee82ffc1f46();
		}
		else
		{
			x2092926475576941(xd9ff4dee1dba180e, x5906905c888d3d98);
			x4215dc623c1e4f14.xd8b11076ff837685(xd9ff4dee1dba180e);
			x4215dc623c1e4f14.x917b69030691beda(x5906905c888d3d98, x5906905c888d3d98.x1be93eed8950d961);
			x4215dc623c1e4f14.x47f176deff0d42e2();
		}
		x3e8056e24595cb03(xd9ff4dee1dba180e, x5906905c888d3d98);
		xdce98699bb67f9fc(x5906905c888d3d98);
	}

	internal void x52b190e626f65140(x56410a8dd70087c5 x5906905c888d3d98)
	{
		try
		{
			x2c9b21f64c8361c0.x51b09bddd13a48d7(1);
			if (x5566e2d2acbd1fbe.xe371fdef7ad898c9(x5906905c888d3d98.x5566e2d2acbd1fbe))
			{
				xa38a54a008425bf4((x41ac54db4e627dea)x5906905c888d3d98);
			}
			x5906905c888d3d98.x52b190e626f65140();
			x4215dc623c1e4f14.xd8b11076ff837685(x5906905c888d3d98);
			x4215dc623c1e4f14.x240a962b838217cd();
			x64ada8e57fca22b4(x5906905c888d3d98);
		}
		finally
		{
			x2c9b21f64c8361c0.x16d239165f7f2b5e();
		}
	}

	internal void x408f4b7efc86fd49()
	{
		xef8721f06e48b9f3();
		xd111c39238a6b91f();
		if (xc4175228fcb808bc())
		{
			return;
		}
		try
		{
			x336a718e2ba66b53(out var x2171c110ade1f79e, out var x3f091b4d578123a);
			xf8319e677a9bd732 xf8319e677a9bd733 = new xf8319e677a9bd732(x3f091b4d578123a, x2171c110ade1f79e);
			x56410a8dd70087c5 x56410a8dd70087c6;
			do
			{
				x56410a8dd70087c6 = (x56410a8dd70087c5)x4215dc623c1e4f14.x35cfcea4890f4e7d;
				xf8319e677a9bd733.xef23aa45e7612fdd(x56410a8dd70087c6);
			}
			while (x56410a8dd70087c6 != x749f8493ad444bdb && x4215dc623c1e4f14.x355eaee82ffc1f46());
			x4215dc623c1e4f14.xd8b11076ff837685(x576773fbf9307688);
			x56410a8dd70087c6 = (x56410a8dd70087c5)x4215dc623c1e4f14.x35cfcea4890f4e7d;
			xf8319e677a9bd733.x22eff0ce085903b3(x56410a8dd70087c6.x406d8cd2af514771);
		}
		finally
		{
			xdeabb4094890b6f0();
		}
	}

	internal static bool x888cbbd33c96afa3(x56410a8dd70087c5 xa447fc54e41dfe06, x56410a8dd70087c5 xfc2074a859a5db8c)
	{
		int xf1d9b91c9700c = xa447fc54e41dfe06.xf1d9b91c9700c401;
		int xf1d9b91c9700c2 = xfc2074a859a5db8c.xf1d9b91c9700c401;
		if (xf1d9b91c9700c != xf1d9b91c9700c2)
		{
			return xf1d9b91c9700c < xf1d9b91c9700c2;
		}
		xf3f447691ab38eee xb3a79d506b0e2f7f = xa447fc54e41dfe06.x53111d6596d16a99.xb3a79d506b0e2f7f;
		xb3a79d506b0e2f7f.xd8b11076ff837685(xa447fc54e41dfe06);
		bool flag = false;
		while (xb3a79d506b0e2f7f.x47f176deff0d42e2())
		{
			if (xb3a79d506b0e2f7f.x35cfcea4890f4e7d == xfc2074a859a5db8c)
			{
				return true;
			}
			if (0 < ((x56410a8dd70087c5)xb3a79d506b0e2f7f.x35cfcea4890f4e7d).x1be93eed8950d961)
			{
				if (flag)
				{
					break;
				}
				flag = true;
			}
		}
		return false;
	}

	private void xe88ab84767e8fb69(x56410a8dd70087c5 x62584df2cb5d40dd, x56410a8dd70087c5 x2aa5114a5da7d6c8)
	{
		if (x32da7b51aa81365b == 0)
		{
			x749f8493ad444bdb = x62584df2cb5d40dd;
			x576773fbf9307688 = x2aa5114a5da7d6c8;
		}
		else
		{
			if (x62584df2cb5d40dd == null)
			{
				x749f8493ad444bdb = null;
			}
			else if (x749f8493ad444bdb != null && x888cbbd33c96afa3(x62584df2cb5d40dd, x749f8493ad444bdb))
			{
				x749f8493ad444bdb = x62584df2cb5d40dd;
			}
			if (x2aa5114a5da7d6c8 == null)
			{
				x576773fbf9307688 = null;
			}
			else if (x576773fbf9307688 != null && x888cbbd33c96afa3(x576773fbf9307688, x2aa5114a5da7d6c8))
			{
				x576773fbf9307688 = x2aa5114a5da7d6c8;
			}
		}
		x32da7b51aa81365b++;
	}

	private void xd111c39238a6b91f()
	{
		xb7c47a794d68523c(x749f8493ad444bdb, x4677d8f1eccc3636: true);
		bool flag = false;
		while (!x4215dc623c1e4f14.x45ef6ccec2bafbfc)
		{
			x56410a8dd70087c5 x56410a8dd70087c6 = (x56410a8dd70087c5)x4215dc623c1e4f14.x35cfcea4890f4e7d;
			flag = flag || x56410a8dd70087c6 == x576773fbf9307688;
			bool xd181cfc9bf12b1ac = x56410a8dd70087c6.xd181cfc9bf12b1ac;
			if (x56410a8dd70087c6.x00fa20d37841acd0 && x56410a8dd70087c6.xd181cfc9bf12b1ac)
			{
				x56410a8dd70087c6.x52b190e626f65140();
			}
			x4215dc623c1e4f14.x47f176deff0d42e2();
			if (flag && !xd181cfc9bf12b1ac)
			{
				break;
			}
		}
	}

	private void xef8721f06e48b9f3()
	{
		x3a43ccb489970add x3a43ccb489970add2 = new x3a43ccb489970add();
		xb7c47a794d68523c(x749f8493ad444bdb, x4677d8f1eccc3636: true);
		bool flag = !x2c9b21f64c8361c0.x2c8c6741422a1298.xdeb77ea37ad74c56.x0524267b51e1f4ba;
		xd14f50a067a58062 xd14f50a067a58063 = null;
		x41ac54db4e627dea x6136cc96924b0a = null;
		while (!x4215dc623c1e4f14.x30d6662e83251ab4)
		{
			x56410a8dd70087c5 x56410a8dd70087c6 = (x56410a8dd70087c5)x4215dc623c1e4f14.x35cfcea4890f4e7d;
			bool flag2 = x4215dc623c1e4f14.x35cfcea4890f4e7d == x576773fbf9307688;
			x3a43ccb489970add2.xbc13914359462815(x56410a8dd70087c6);
			if (x56410a8dd70087c6 is x61ebdec02c254c25)
			{
				if (x56410a8dd70087c6 is x577d2faf9a871f11 || x56410a8dd70087c6 is x92361dccfa0347fd)
				{
					bool flag3 = (flag && x56410a8dd70087c6.x705ed5f9769744e5.x24385217e0d88ab8) || x3a43ccb489970add2.xf599d2ce268e77d8;
					if (x56410a8dd70087c6 is x577d2faf9a871f11)
					{
						x56410a8dd70087c6.xd181cfc9bf12b1ac = flag3;
					}
					else
					{
						x56410a8dd70087c6.x1b4884baf08c8d62 = flag3;
					}
				}
				else if (x56410a8dd70087c6 is xeb20d9a559fa99ca)
				{
					x56410a8dd70087c6.xd181cfc9bf12b1ac = x3a43ccb489970add2.xa8cbabceca9f22ea;
				}
				else if (x56410a8dd70087c6 is x5c28fdcd27dee7d9)
				{
					x56410a8dd70087c6.xd181cfc9bf12b1ac = ((x56410a8dd70087c6.x6e414db5d060a816 == x6e414db5d060a816.x12cb12b5d2cad53d) ? x3a43ccb489970add2.xf599d2ce268e77d8 : ((x5c28fdcd27dee7d9)x56410a8dd70087c6).x9a05d8dab0f0619f.xd181cfc9bf12b1ac);
					x56410a8dd70087c6.x1b4884baf08c8d62 = x56410a8dd70087c6.x6e414db5d060a816 == x6e414db5d060a816.x865739e9b580d3cf || !x3a43ccb489970add.x94b9aeac94664188((x5c28fdcd27dee7d9)x56410a8dd70087c6);
				}
				else
				{
					xd14f50a067a58063 = ((x56410a8dd70087c6 is xd14f50a067a58062) ? ((xd14f50a067a58062)x56410a8dd70087c6) : null);
					x56410a8dd70087c6.xd181cfc9bf12b1ac = false;
				}
			}
			else if (x56410a8dd70087c6.x5566e2d2acbd1fbe == 21537)
			{
				xc60f90e4afceec38(x6136cc96924b0a, (x41ac54db4e627dea)x56410a8dd70087c6);
				x6136cc96924b0a = (x41ac54db4e627dea)x56410a8dd70087c6;
				bool flag4 = x3a43ccb489970add2.xf599d2ce268e77d8;
				if (!flag4 && flag && x56410a8dd70087c6.x705ed5f9769744e5.x24385217e0d88ab8 && !xb3aeeb41e892a348())
				{
					flag4 = ((x56410a8dd70087c5)x4215dc623c1e4f14.xbc13914359462815).x772764427592d4bb == x56410a8dd70087c6.x772764427592d4bb;
					if (!flag4)
					{
						flag4 = true;
						xf3f447691ab38eee xf3f447691ab38eee2 = x4215dc623c1e4f14.x8b61531c8ea35b85();
						while (xf3f447691ab38eee2.x355eaee82ffc1f46())
						{
							x56410a8dd70087c5 x56410a8dd70087c7 = (x56410a8dd70087c5)xf3f447691ab38eee2.x02ebdc12ebf86805;
							if (!x56410a8dd70087c7.xd181cfc9bf12b1ac)
							{
								flag4 = x5566e2d2acbd1fbe.x8197188ddb6f93d3(x56410a8dd70087c7.x5566e2d2acbd1fbe);
								break;
							}
						}
					}
				}
				x56410a8dd70087c6.xd181cfc9bf12b1ac = flag4;
				if (flag4 && xd14f50a067a58063 != null && !x56410a8dd70087c6.x705ed5f9769744e5.x24385217e0d88ab8)
				{
					xd14f50a067a58063.xd181cfc9bf12b1ac = true;
				}
			}
			else if (x5566e2d2acbd1fbe.xff7735def89bf56b(x56410a8dd70087c6.x5566e2d2acbd1fbe))
			{
				bool flag5 = x56410a8dd70087c6.x5566e2d2acbd1fbe == 25604 && ((xa67197c42bddc7dc)x56410a8dd70087c6).x347b79f9c616f92c.x96e55b5d052d1279;
				x56410a8dd70087c6.xd181cfc9bf12b1ac = flag5 || (flag && x56410a8dd70087c6.x705ed5f9769744e5.x24385217e0d88ab8) || x3a43ccb489970add2.xf599d2ce268e77d8;
				xc6a2ee23c44f25f7(x56410a8dd70087c6);
			}
			else
			{
				x56410a8dd70087c6.xd181cfc9bf12b1ac = x3a43ccb489970add2.xf599d2ce268e77d8;
			}
			if (x5566e2d2acbd1fbe.x8197188ddb6f93d3(x56410a8dd70087c6.x5566e2d2acbd1fbe))
			{
				xd14f50a067a58063 = null;
			}
			if (flag2)
			{
				break;
			}
			x4215dc623c1e4f14.x47f176deff0d42e2();
		}
		xc60f90e4afceec38(x6136cc96924b0a, null);
	}

	private static void xc60f90e4afceec38(x41ac54db4e627dea x6136cc96924b0a93, x41ac54db4e627dea xc054462bcc799b09)
	{
		if (x6136cc96924b0a93 == null || !x6136cc96924b0a93.xd181cfc9bf12b1ac || !x6136cc96924b0a93.x705ed5f9769744e5.x24385217e0d88ab8 || x6136cc96924b0a93.xa79651e2f1a1416e.x7fc015364b8e5a44)
		{
			return;
		}
		if (x6136cc96924b0a93.xa79651e2f1a1416e.xbed6d6330712f0f2)
		{
			x3f2246bac2943b2a(x6136cc96924b0a93);
			return;
		}
		if (xc054462bcc799b09 == null)
		{
			xf3f447691ab38eee xf3f447691ab38eee2 = x6136cc96924b0a93.x53111d6596d16a99.xb3a79d506b0e2f7f.x8b61531c8ea35b85();
			xf3f447691ab38eee2.xd8b11076ff837685(x6136cc96924b0a93);
			while (xf3f447691ab38eee2.x47f176deff0d42e2())
			{
				x56410a8dd70087c5 x56410a8dd70087c6 = (x56410a8dd70087c5)xf3f447691ab38eee2.x35cfcea4890f4e7d;
				if (x5566e2d2acbd1fbe.x8197188ddb6f93d3(x56410a8dd70087c6.x5566e2d2acbd1fbe))
				{
					xc054462bcc799b09 = (x41ac54db4e627dea)x56410a8dd70087c6;
					if (!xc054462bcc799b09.xa79651e2f1a1416e.x7fc015364b8e5a44 || !xc054462bcc799b09.x705ed5f9769744e5.x24385217e0d88ab8)
					{
						break;
					}
					xc054462bcc799b09 = null;
				}
			}
		}
		if (xc054462bcc799b09 != null && xc054462bcc799b09.xa79651e2f1a1416e.xbed6d6330712f0f2)
		{
			x3f2246bac2943b2a(x6136cc96924b0a93);
		}
	}

	private static void x3f2246bac2943b2a(x41ac54db4e627dea x41baca1d6c0c2e8e)
	{
		x41baca1d6c0c2e8e.xd181cfc9bf12b1ac = false;
		x396b77a306f83da6 x396b77a306f83da7 = x396b77a306f83da6.xdb83cd4968ca9d31(x41baca1d6c0c2e8e.x705ed5f9769744e5);
		x396b77a306f83da7.x24385217e0d88ab8 = false;
		x396b77a306f83da7.x17c40acbe47f16cc = false;
		x41baca1d6c0c2e8e.x705ed5f9769744e5 = x396b77a306f83da6.x38758cbbee49e4cb(x396b77a306f83da7);
	}

	private bool xb3aeeb41e892a348()
	{
		if (x4215dc623c1e4f14.x45ef6ccec2bafbfc)
		{
			return true;
		}
		switch (x2c9b21f64c8361c0.xfe6cdb7c00822bd9)
		{
		default:
			return false;
		case StoryType.Footnotes:
		case StoryType.Endnotes:
		case StoryType.Comments:
		{
			xf3f447691ab38eee xf3f447691ab38eee2 = x4215dc623c1e4f14.x8b61531c8ea35b85();
			xf3f447691ab38eee2.x47f176deff0d42e2();
			x56410a8dd70087c5 x56410a8dd70087c6 = (x56410a8dd70087c5)xf3f447691ab38eee2.x35cfcea4890f4e7d;
			if (!(x56410a8dd70087c6 is xfb0c927634a887df))
			{
				return x56410a8dd70087c6 is x92361dccfa0347fd;
			}
			return true;
		}
		}
	}

	private x56410a8dd70087c5 xb7c47a794d68523c(x56410a8dd70087c5 x5906905c888d3d98, bool x4677d8f1eccc3636)
	{
		if (x5906905c888d3d98 != null)
		{
			x4215dc623c1e4f14.xd8b11076ff837685(x5906905c888d3d98);
		}
		else if (!x4677d8f1eccc3636)
		{
			x4215dc623c1e4f14.x6cfb41b4bd00d940();
		}
		else
		{
			x4215dc623c1e4f14.x77a51022b61a6b12();
		}
		if (x5906905c888d3d98 != null)
		{
			return x5906905c888d3d98;
		}
		return (x56410a8dd70087c5)x4215dc623c1e4f14.x35cfcea4890f4e7d;
	}

	private void x336a718e2ba66b53(out x56410a8dd70087c5 x2171c110ade1f79e, out x8d9303345f12a846 x3f091b4d578123a3)
	{
		if (x749f8493ad444bdb == null)
		{
			x4215dc623c1e4f14.x6cfb41b4bd00d940();
			x749f8493ad444bdb = (x56410a8dd70087c5)x4215dc623c1e4f14.x35cfcea4890f4e7d;
		}
		x576773fbf9307688 = xb7c47a794d68523c(x576773fbf9307688, x4677d8f1eccc3636: true);
		while (!x576773fbf9307688.x00fa20d37841acd0 && !x4215dc623c1e4f14.x45ef6ccec2bafbfc)
		{
			x4215dc623c1e4f14.x47f176deff0d42e2();
			x576773fbf9307688 = (x56410a8dd70087c5)x4215dc623c1e4f14.x35cfcea4890f4e7d;
		}
		x2171c110ade1f79e = x576773fbf9307688;
		if (x2171c110ade1f79e.x00fa20d37841acd0)
		{
			x3f091b4d578123a3 = x2171c110ade1f79e.x406d8cd2af514771;
			if (!x4215dc623c1e4f14.xaea770a91df1e1ea)
			{
				x4215dc623c1e4f14.x355eaee82ffc1f46();
			}
			return;
		}
		if (x4215dc623c1e4f14.x45ef6ccec2bafbfc)
		{
			x717965f9d826c215();
			x3f091b4d578123a3 = x4b2e8e22f36c8990((x41ac54db4e627dea)x576773fbf9307688);
			x2171c110ade1f79e = null;
			return;
		}
		x2171c110ade1f79e = (x56410a8dd70087c5)x4215dc623c1e4f14.xbc13914359462815;
		x3f091b4d578123a3 = x2171c110ade1f79e.x406d8cd2af514771;
		if (x3f091b4d578123a3 != null)
		{
			return;
		}
		xf3f447691ab38eee xf3f447691ab38eee2 = x4215dc623c1e4f14.x8b61531c8ea35b85();
		while (xf3f447691ab38eee2.x47f176deff0d42e2())
		{
			x56410a8dd70087c5 x56410a8dd70087c6 = (x56410a8dd70087c5)xf3f447691ab38eee2.x35cfcea4890f4e7d;
			if (x56410a8dd70087c6.x00fa20d37841acd0)
			{
				x3f091b4d578123a3 = x56410a8dd70087c6.x406d8cd2af514771;
				break;
			}
		}
	}

	private void x717965f9d826c215()
	{
		if (!x4215dc623c1e4f14.x45ef6ccec2bafbfc)
		{
			return;
		}
		x56410a8dd70087c5 x56410a8dd70087c6 = (x56410a8dd70087c5)x4215dc623c1e4f14.x35cfcea4890f4e7d;
		if (21639 == x56410a8dd70087c6.x5566e2d2acbd1fbe)
		{
			return;
		}
		if (x5566e2d2acbd1fbe.xd707791130626739(x56410a8dd70087c6.x5566e2d2acbd1fbe))
		{
			switch (x2c9b21f64c8361c0.xfe6cdb7c00822bd9)
			{
			case StoryType.Footnotes:
			case StoryType.Endnotes:
			case StoryType.Comments:
			case StoryType.FootnoteSeparator:
			case StoryType.FootnoteContinuationSeparator:
			case StoryType.EndnoteSeparator:
			case StoryType.EndnoteContinuationSeparator:
				return;
			}
		}
		x56410a8dd70087c5 x56410a8dd70087c7 = new x41ac54db4e627dea(21639);
		x56410a8dd70087c7.x772764427592d4bb = 0;
		x4e2f8bff72d83f71 x2c8c6741422a = x2c9b21f64c8361c0.x2c8c6741422a1298;
		x396b77a306f83da6 x396b77a306f83da7 = new x396b77a306f83da6(x2c8c6741422a.x17dcbf5fe3c0d2d2);
		x396b77a306f83da7.x759aa16c2016a289 = "Times New Roman";
		x396b77a306f83da7.x76cdec455967c074 = x9d888f53892d94df.x9834ddb0e0bd5996;
		x396b77a306f83da7.x437e3b626c0fdd43 = 0;
		x56410a8dd70087c7.x705ed5f9769744e5 = x396b77a306f83da6.x38758cbbee49e4cb(x396b77a306f83da7);
		x41ccdd7753312e4f x41ccdd7753312e4f2 = new x41ccdd7753312e4f(x2c8c6741422a.x17dcbf5fe3c0d2d2);
		x41ccdd7753312e4f2.x6ecc1a11cfc2c359 = LineSpacingRule.Multiple;
		x41ccdd7753312e4f2.x84bbacdc1fc0efd2 = 1;
		x56410a8dd70087c7.xa79651e2f1a1416e = x41ccdd7753312e4f.x38758cbbee49e4cb(x41ccdd7753312e4f2);
		xef23aa45e7612fdd(x56410a8dd70087c6, x56410a8dd70087c7);
	}

	private static void xc6a2ee23c44f25f7(x56410a8dd70087c5 x5906905c888d3d98)
	{
		int num = x5906905c888d3d98.x5566e2d2acbd1fbe;
		if ((num == 21779 || num == 21788) && 0 < x5906905c888d3d98.x772764427592d4bb)
		{
			x5906905c888d3d98.xd181cfc9bf12b1ac = true;
		}
	}

	private bool xc4175228fcb808bc()
	{
		if (x32da7b51aa81365b == 0)
		{
			return true;
		}
		x2c9b21f64c8361c0.x51b09bddd13a48d7(1);
		return false;
	}

	private void xdeabb4094890b6f0()
	{
		x2c9b21f64c8361c0.x16d239165f7f2b5e();
		x32da7b51aa81365b = 0;
		x749f8493ad444bdb = null;
		x576773fbf9307688 = null;
	}

	private void x3e8056e24595cb03(x56410a8dd70087c5 xd9ff4dee1dba180e, x56410a8dd70087c5 x5906905c888d3d98)
	{
		if (x32da7b51aa81365b == 0)
		{
			x749f8493ad444bdb = (x576773fbf9307688 = x5906905c888d3d98);
		}
		else if (xd9ff4dee1dba180e == null)
		{
			x749f8493ad444bdb = x5906905c888d3d98;
			if (x32da7b51aa81365b == 0)
			{
				x576773fbf9307688 = x5906905c888d3d98;
			}
		}
		else if (xd9ff4dee1dba180e == x576773fbf9307688)
		{
			x576773fbf9307688 = x5906905c888d3d98;
		}
		else
		{
			if (x576773fbf9307688 != null && x888cbbd33c96afa3(x576773fbf9307688, x5906905c888d3d98))
			{
				x576773fbf9307688 = x5906905c888d3d98;
			}
			if (x749f8493ad444bdb != null && x888cbbd33c96afa3(x5906905c888d3d98, x749f8493ad444bdb))
			{
				x749f8493ad444bdb = x5906905c888d3d98;
			}
		}
		x32da7b51aa81365b++;
	}

	private void xa38a54a008425bf4(x41ac54db4e627dea x5906905c888d3d98)
	{
		if (x5566e2d2acbd1fbe.xe371fdef7ad898c9(x5906905c888d3d98.x5566e2d2acbd1fbe))
		{
			x4215dc623c1e4f14.xd8b11076ff837685(x5906905c888d3d98);
			if (x4215dc623c1e4f14.x355eaee82ffc1f46())
			{
				x41ac54db4e627dea xee918fe23aa431e = (x41ac54db4e627dea)x4215dc623c1e4f14.x35cfcea4890f4e7d;
				x5906905c888d3d98.xf9f24914e9799bf9(xee918fe23aa431e);
			}
		}
	}

	private x8d9303345f12a846 x4b2e8e22f36c8990(x41ac54db4e627dea x5906905c888d3d98)
	{
		return x2c9b21f64c8361c0.x4b2e8e22f36c8990(x5906905c888d3d98);
	}

	private void x64ada8e57fca22b4(x56410a8dd70087c5 x5906905c888d3d98)
	{
		if (x4215dc623c1e4f14.x7149c962c02931b3)
		{
			x749f8493ad444bdb = null;
			x576773fbf9307688 = null;
			x32da7b51aa81365b = 0;
			return;
		}
		if (x4215dc623c1e4f14.xd5bbb2ab5553d8fb)
		{
			x576773fbf9307688 = null;
			if (x749f8493ad444bdb == x5906905c888d3d98 || (x32da7b51aa81365b == 0 && x4215dc623c1e4f14.x77a51022b61a6b12()))
			{
				x749f8493ad444bdb = (x56410a8dd70087c5)x4215dc623c1e4f14.x35cfcea4890f4e7d;
			}
		}
		else
		{
			x56410a8dd70087c5 x56410a8dd70087c6 = (x56410a8dd70087c5)x4215dc623c1e4f14.x35cfcea4890f4e7d;
			if (x32da7b51aa81365b == 0 || x576773fbf9307688 == x5906905c888d3d98 || (x576773fbf9307688 != null && x888cbbd33c96afa3(x576773fbf9307688, x56410a8dd70087c6)))
			{
				x576773fbf9307688 = x56410a8dd70087c6;
			}
			if (x749f8493ad444bdb != null || x32da7b51aa81365b == 0)
			{
				if (x4215dc623c1e4f14.xaea770a91df1e1ea)
				{
					x749f8493ad444bdb = null;
				}
				else if (x32da7b51aa81365b == 0 || x749f8493ad444bdb == x5906905c888d3d98 || x888cbbd33c96afa3(x56410a8dd70087c6, x749f8493ad444bdb))
				{
					x4215dc623c1e4f14.x355eaee82ffc1f46();
					x749f8493ad444bdb = (x56410a8dd70087c5)x4215dc623c1e4f14.x35cfcea4890f4e7d;
				}
			}
		}
		x32da7b51aa81365b++;
	}

	private static void x2092926475576941(x56410a8dd70087c5 xd9ff4dee1dba180e, x56410a8dd70087c5 x5906905c888d3d98)
	{
		if (xd9ff4dee1dba180e != null)
		{
			if (xd9ff4dee1dba180e.x6e414db5d060a816 == x6e414db5d060a816.x12cb12b5d2cad53d && xd9ff4dee1dba180e.x53819c070f6c4652 != null && xd9ff4dee1dba180e.x53819c070f6c4652 != x5906905c888d3d98)
			{
				x5906905c888d3d98.x2de24895ffc1e75d = xd9ff4dee1dba180e;
			}
			else
			{
				x5906905c888d3d98.x2de24895ffc1e75d = xd9ff4dee1dba180e.x2de24895ffc1e75d;
			}
		}
	}

	private void xdce98699bb67f9fc(x56410a8dd70087c5 x5906905c888d3d98)
	{
		if (x5906905c888d3d98.x53819c070f6c4652 == null || (x6e414db5d060a816.x12cb12b5d2cad53d != x5906905c888d3d98.x6e414db5d060a816 && x6e414db5d060a816.x9fd888e65466818c != x5906905c888d3d98.x6e414db5d060a816))
		{
			return;
		}
		x56410a8dd70087c5 x56410a8dd70087c6 = ((x5906905c888d3d98.x6e414db5d060a816 == x6e414db5d060a816.x9fd888e65466818c) ? x5906905c888d3d98 : x5906905c888d3d98.x53819c070f6c4652);
		x56410a8dd70087c5 x56410a8dd70087c7 = ((x5906905c888d3d98.x6e414db5d060a816 == x6e414db5d060a816.x12cb12b5d2cad53d) ? x5906905c888d3d98 : x5906905c888d3d98.x53819c070f6c4652);
		Hashtable hashtable = new Hashtable();
		x4215dc623c1e4f14.xd8b11076ff837685(x56410a8dd70087c7);
		while (x4215dc623c1e4f14.x47f176deff0d42e2() && x4215dc623c1e4f14.x35cfcea4890f4e7d != x56410a8dd70087c6)
		{
			x56410a8dd70087c5 x56410a8dd70087c8 = (x56410a8dd70087c5)x4215dc623c1e4f14.x35cfcea4890f4e7d;
			if (x56410a8dd70087c8.x2de24895ffc1e75d == null || hashtable.Count == 0)
			{
				x56410a8dd70087c8.x2de24895ffc1e75d = x56410a8dd70087c7;
			}
			if (x56410a8dd70087c8.x53819c070f6c4652 != null)
			{
				if (x6e414db5d060a816.x12cb12b5d2cad53d == x56410a8dd70087c8.x6e414db5d060a816)
				{
					hashtable.Add(x56410a8dd70087c8, x56410a8dd70087c8.x53819c070f6c4652);
				}
				else if (x6e414db5d060a816.x9fd888e65466818c == x56410a8dd70087c8.x6e414db5d060a816 && hashtable.ContainsKey(x56410a8dd70087c8.x53819c070f6c4652))
				{
					hashtable.Remove(x56410a8dd70087c8.x53819c070f6c4652);
				}
			}
		}
		x56410a8dd70087c6.x2de24895ffc1e75d = x56410a8dd70087c7.x2de24895ffc1e75d;
		xe88ab84767e8fb69(x56410a8dd70087c7, x56410a8dd70087c6);
	}

	[Conditional("TEST")]
	internal static void x1b3954afe6f2b479(params object[] xce8d8c7e3c2c2426)
	{
	}

	[Conditional("TEST")]
	internal static void x7c640b15fdb676d3(params object[] xce8d8c7e3c2c2426)
	{
	}

	[Conditional("TEST")]
	internal static void xd9d3cd308f472720(params object[] xce8d8c7e3c2c2426)
	{
	}
}
