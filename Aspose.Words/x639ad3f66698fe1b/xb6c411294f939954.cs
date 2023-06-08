using System;
using System.Collections;
using Aspose.Words.Drawing;
using Aspose.Words.Lists;
using xd2754ae26d400653;

namespace x639ad3f66698fe1b;

internal class xb6c411294f939954
{
	private x21f0d20d41203be1 x8cedcaa9a62c6e39;

	private x902c8ac86fbaf048 x37a3a9edb53f138b;

	private xbfd162a6d47f59a4 xe1410f585439c7d4 => x8cedcaa9a62c6e39.xe1410f585439c7d4;

	internal xb6c411294f939954()
	{
	}

	internal void x6210059f049f0d48(x21f0d20d41203be1 x0f7b23d1c393aed9)
	{
		x8cedcaa9a62c6e39 = x0f7b23d1c393aed9;
		if (x8cedcaa9a62c6e39.x2c8c6741422a1298.Lists.Count != 0)
		{
			x53749785f75c7732();
			xb39c8d9736cb01ae();
		}
	}

	private void x53749785f75c7732()
	{
		xe1410f585439c7d4.xee60bff2900a72f2("\\*\\listtable");
		xa23a9cf7d03725c8();
		x2788ff87c749937c();
		xe1410f585439c7d4.xc8a13a52db0580ae();
		xe1410f585439c7d4.x25d0efbd7848eeb3();
	}

	private void xa23a9cf7d03725c8()
	{
		ListCollection lists = x8cedcaa9a62c6e39.x2c8c6741422a1298.Lists;
		if (lists.xe10f375b4290d48f != 0)
		{
			xe1410f585439c7d4.xee60bff2900a72f2("\\*\\listpicture");
			for (int i = 0; i < lists.xe10f375b4290d48f; i++)
			{
				Shape x5770cdefd8931aa = lists.x4916e8670feefe58(i);
				x8cedcaa9a62c6e39.x8b8ab0cf32b35f3c.x68bc5741469ea60b(x5770cdefd8931aa);
			}
			xe1410f585439c7d4.xc8a13a52db0580ae();
			xe1410f585439c7d4.x25d0efbd7848eeb3();
		}
	}

	private void x2788ff87c749937c()
	{
		ListCollection lists = x8cedcaa9a62c6e39.x2c8c6741422a1298.Lists;
		for (int i = 0; i < lists.xddf1da3d36406847; i++)
		{
			x178ff6dcbf808c38 x02c001fe9bc = lists.x3bfa6064d69ac0da(i);
			x723106ba2e8579a1(x02c001fe9bc);
		}
	}

	private void x723106ba2e8579a1(x178ff6dcbf808c38 x02c001fe9bc75871)
	{
		xe1410f585439c7d4.xee60bff2900a72f2("\\list");
		xe1410f585439c7d4.x4d14ee33f46b5913("\\listtemplateid", x02c001fe9bc75871.x18f9fc979b70e77f);
		x37a3a9edb53f138b = x02c001fe9bc75871.x902c8ac86fbaf048;
		xbd42905033faf427(x02c001fe9bc75871.x438a2a8db4b2d07b.Count);
		for (int i = 0; i < x02c001fe9bc75871.x438a2a8db4b2d07b.Count; i++)
		{
			ListLevel x0fe7a8514e20eb = x02c001fe9bc75871.x438a2a8db4b2d07b[i];
			x788718c529bf1726(x0fe7a8514e20eb, i, x02c001fe9bc75871.x902c8ac86fbaf048 == x902c8ac86fbaf048.x598f41525926b38a);
		}
		xe1410f585439c7d4.x65e60a21b3a69631("\\listname", x02c001fe9bc75871.x759aa16c2016a289);
		xe1410f585439c7d4.x4d14ee33f46b5913("\\listid", x02c001fe9bc75871.x1eac770549050632);
		if (x02c001fe9bc75871.xf81d0e09758457fe)
		{
			xe1410f585439c7d4.x65e60a21b3a69631("\\*\\liststylename", x02c001fe9bc75871.xfe2178c1f916f36c.Name);
		}
		else if (x02c001fe9bc75871.x01381925b7dd551e)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913("\\liststyleid", x02c001fe9bc75871.xfe2178c1f916f36c.List.x1eac770549050632);
		}
		xe1410f585439c7d4.xc8a13a52db0580ae();
		xe1410f585439c7d4.x25d0efbd7848eeb3();
	}

	private void xbd42905033faf427(int x392861dd84b84368)
	{
		switch (x37a3a9edb53f138b)
		{
		case x902c8ac86fbaf048.xabed123f43874357:
		case x902c8ac86fbaf048.x7e86ac926e2dc940:
			if (x392861dd84b84368 == 1)
			{
				xe1410f585439c7d4.x4d14ee33f46b5913("\\listsimple");
			}
			break;
		default:
			xe1410f585439c7d4.x4d14ee33f46b5913("\\listhybrid");
			break;
		}
	}

	private void xb39c8d9736cb01ae()
	{
		xe1410f585439c7d4.xee60bff2900a72f2("\\*\\listoverridetable");
		ListCollection lists = x8cedcaa9a62c6e39.x2c8c6741422a1298.Lists;
		for (int i = 0; i < lists.Count; i++)
		{
			xe1410f585439c7d4.xee60bff2900a72f2("\\listoverride");
			List list = lists[i];
			xe1410f585439c7d4.x4d14ee33f46b5913("\\listid", list.x1eac770549050632);
			xe1410f585439c7d4.x4d14ee33f46b5913("\\listoverridecount", list.x6047afa6812e47bc.Count);
			xe1410f585439c7d4.x4d14ee33f46b5913("\\ls", i + 1);
			foreach (x136abcf7d9c0eef3 item in list.x6047afa6812e47bc)
			{
				xe1410f585439c7d4.xee60bff2900a72f2("\\lfolevel");
				if (item.x33160172e2e7ff13)
				{
					xe1410f585439c7d4.x4d14ee33f46b5913("\\listoverridestartat");
					if (!item.x178c863a9c967cd2)
					{
						xe1410f585439c7d4.x4d14ee33f46b5913("\\levelstartat", item.x6da6130e001c6962);
					}
				}
				if (item.x178c863a9c967cd2)
				{
					xe1410f585439c7d4.x4d14ee33f46b5913("\\listoverrideformat", 9);
					x788718c529bf1726(item.xf13a626e550cef8f, item.xf13a626e550cef8f.x008c23e8f687bbd3, list.x178ff6dcbf808c38.x902c8ac86fbaf048 == x902c8ac86fbaf048.x598f41525926b38a);
				}
				xe1410f585439c7d4.xc8a13a52db0580ae();
			}
			xe1410f585439c7d4.xc8a13a52db0580ae();
		}
		xe1410f585439c7d4.xc8a13a52db0580ae();
		xe1410f585439c7d4.x25d0efbd7848eeb3();
	}

	private void x788718c529bf1726(ListLevel x0fe7a8514e20eb94, int x91611f9f468032ee, bool xd2dbc3e832ae17df)
	{
		xe1410f585439c7d4.xee60bff2900a72f2("\\listlevel");
		int xbcea506a33cf = Convert.ToInt32(x0fe7a8514e20eb94.NumberStyle);
		xe1410f585439c7d4.x4d14ee33f46b5913("\\levelnfc", xbcea506a33cf);
		xe1410f585439c7d4.x4d14ee33f46b5913("\\levelnfcn", xbcea506a33cf);
		int xbcea506a33cf2 = Convert.ToInt32(x0fe7a8514e20eb94.Alignment);
		xe1410f585439c7d4.x4d14ee33f46b5913("\\leveljc", xbcea506a33cf2);
		xe1410f585439c7d4.x4d14ee33f46b5913("\\leveljcn", xbcea506a33cf2);
		xe1410f585439c7d4.x4d14ee33f46b5913("\\levelstartat", x0fe7a8514e20eb94.StartAt);
		if (x0fe7a8514e20eb94.xf9be1d0b8b44c7e8)
		{
			xe1410f585439c7d4.x5fdd0595d40cfe6d("\\levelold", xbcea506a33cf9111: true);
			xe1410f585439c7d4.x5fdd0595d40cfe6d("\\levelprev", x0fe7a8514e20eb94.x969abf858b3fe7e8);
			xe1410f585439c7d4.x5fdd0595d40cfe6d("\\levelprevspace", x0fe7a8514e20eb94.x91bd46873c858a0c);
			xe1410f585439c7d4.x4d14ee33f46b5913("\\levelindent", x0fe7a8514e20eb94.x5cf63f659ff5ee9f);
			xe1410f585439c7d4.x4d14ee33f46b5913("\\levelspace", x0fe7a8514e20eb94.x42bf8be828fc1b33);
		}
		xe1410f585439c7d4.xee60bff2900a72f2("\\leveltext");
		if (xd2dbc3e832ae17df)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913("\\leveltemplateid", x91611f9f468032ee);
		}
		ArrayList arrayList = x8ae65ccdbd5e060c(x0fe7a8514e20eb94.NumberFormat);
		xe1410f585439c7d4.x80fb22e7844d1324();
		xe1410f585439c7d4.xc8a13a52db0580ae();
		xe1410f585439c7d4.xee60bff2900a72f2("\\levelnumbers");
		for (int i = 0; i < arrayList.Count; i++)
		{
			xe1410f585439c7d4.xae8ee99c2d2310b7((char)arrayList[i]);
		}
		xe1410f585439c7d4.x80fb22e7844d1324();
		xe1410f585439c7d4.xc8a13a52db0580ae();
		xe1410f585439c7d4.x4d14ee33f46b5913("\\levelfollow", Convert.ToInt32(x0fe7a8514e20eb94.TrailingCharacter));
		xe1410f585439c7d4.xb8aea59edd4060ce("\\levellegal", x0fe7a8514e20eb94.IsLegal);
		xe1410f585439c7d4.xb8aea59edd4060ce("\\levelnorestart", x0fe7a8514e20eb94.xfbad6d0650721048);
		x8cedcaa9a62c6e39.x6fca94e50472ae68.x6210059f049f0d48(x0fe7a8514e20eb94.xeedad81aaed42a76, x00ce61b8358bb4cc: false);
		if (x0fe7a8514e20eb94.x4a1340b0df048976 != 4095)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913("\\s", x0fe7a8514e20eb94.x4a1340b0df048976);
		}
		x8cedcaa9a62c6e39.x1e8de05c1565effc.x6210059f049f0d48(x0fe7a8514e20eb94.x1a78664fa10a3755, x00ce61b8358bb4cc: false, x02cadcecef04989f: true);
		if (x0fe7a8514e20eb94.x44b52529222cea8a)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913("\\levelpicture", x0fe7a8514e20eb94.x4d819daa8b29e86b);
		}
		xe1410f585439c7d4.xc8a13a52db0580ae();
		xe1410f585439c7d4.x25d0efbd7848eeb3();
	}

	private ArrayList x8ae65ccdbd5e060c(string x5786461d089b10a0)
	{
		ArrayList arrayList = new ArrayList();
		xe1410f585439c7d4.xae8ee99c2d2310b7((char)x5786461d089b10a0.Length);
		for (int i = 0; i < x5786461d089b10a0.Length; i++)
		{
			char c = x5786461d089b10a0[i];
			if (ListLevel.x775a459d4e3c3432(c))
			{
				xe1410f585439c7d4.xae8ee99c2d2310b7(c);
				arrayList.Add((char)(i + 1));
			}
			else
			{
				xe1410f585439c7d4.x50f5dc167b3269a7(c.ToString());
			}
		}
		return arrayList;
	}
}
