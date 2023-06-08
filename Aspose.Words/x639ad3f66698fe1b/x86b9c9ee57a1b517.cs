using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Tables;
using x28925c9b27b37a46;
using x556d8f9846e43329;
using x9db5f2e5af3d596e;

namespace x639ad3f66698fe1b;

internal class x86b9c9ee57a1b517
{
	private x21f0d20d41203be1 x8cedcaa9a62c6e39;

	internal static bool x492f529cee830a40;

	private xbfd162a6d47f59a4 xe1410f585439c7d4 => x8cedcaa9a62c6e39.xe1410f585439c7d4;

	internal x86b9c9ee57a1b517(x21f0d20d41203be1 context)
	{
		x8cedcaa9a62c6e39 = context;
	}

	internal void x6210059f049f0d48(xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		if (!x8cedcaa9a62c6e39.xf57de0fd37d5e97d.ExportCompactSize)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913(xe193ceb565ecaa0a.xcedf9c82728ad579 ? "\\rtlrow" : "\\ltrrow");
		}
		for (int i = 0; i < xe193ceb565ecaa0a.xd44988f225497f3a; i++)
		{
			int num = xe193ceb565ecaa0a.xf15263674eb297bb(i);
			object obj = xe193ceb565ecaa0a.x6d3720b962bd3112(i);
			switch (num)
			{
			case 4290:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\trspdl", (int)obj);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\trspdfl3");
				xe1410f585439c7d4.x4d14ee33f46b5913("\\trspdr", (int)obj);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\trspdfr3");
				xe1410f585439c7d4.x4d14ee33f46b5913("\\trspdt", (int)obj);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\trspdft3");
				xe1410f585439c7d4.x4d14ee33f46b5913("\\trspdb", (int)obj);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\trspdfb3");
				break;
			case 4240:
				xe1410f585439c7d4.x5fdd0595d40cfe6d("\\trautofit", (bool)obj);
				break;
			case 4040:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\trhdr", (bool)obj);
				break;
			case 4360:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\trkeep", !(bool)obj);
				break;
			case 4010:
			{
				TableAlignment tableAlignment = (TableAlignment)obj;
				if (xe193ceb565ecaa0a.xcedf9c82728ad579)
				{
					tableAlignment = xedb0eb766e25e0c9.xbf8ba56877f02689(tableAlignment);
				}
				xe1410f585439c7d4.x4d14ee33f46b5913(x88449d6466e04295.xae7ecedfb1c25e0e(tableAlignment));
				break;
			}
			case 4020:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\trgaph", (int)obj);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\trpaddl", (int)obj);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\trpaddfl3");
				break;
			case 4320:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\trpaddr", (int)obj);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\trpaddfr3");
				break;
			case 4300:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\trpaddt", (int)obj);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\trpaddft3");
				break;
			case 4310:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\trpaddb", (int)obj);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\trpaddfb3");
				break;
			case 4230:
				xe1410f585439c7d4.xcdbc678d36159c69("\\trwWidth", "\\trftsWidth", (PreferredWidth)obj);
				break;
			case 4260:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\trwWidthA", (int)obj);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\trftsWidthA3");
				break;
			case 4250:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\trwWidthB", (int)obj);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\trftsWidthB3");
				break;
			case 4210:
				if (xe193ceb565ecaa0a.x6f6877b222ed4153)
				{
					xe1410f585439c7d4.x4d14ee33f46b5913("\\tdfrmtxtLeft", (int)obj);
				}
				break;
			case 4270:
				if (xe193ceb565ecaa0a.x6f6877b222ed4153)
				{
					xe1410f585439c7d4.x4d14ee33f46b5913("\\tdfrmtxtRight", (int)obj);
				}
				break;
			case 4220:
				if (xe193ceb565ecaa0a.x6f6877b222ed4153)
				{
					xe1410f585439c7d4.x4d14ee33f46b5913("\\tdfrmtxtTop", (int)obj);
				}
				break;
			case 4280:
				if (xe193ceb565ecaa0a.x6f6877b222ed4153)
				{
					xe1410f585439c7d4.x4d14ee33f46b5913("\\tdfrmtxtBottom", (int)obj);
				}
				break;
			case 4350:
				if (xe193ceb565ecaa0a.x6f6877b222ed4153)
				{
					xe1410f585439c7d4.x5fdd0595d40cfe6d("\\tabsnoovrlp", !(bool)obj);
				}
				break;
			case 4150:
				if (xe193ceb565ecaa0a.xef633558eb57057f)
				{
					xe1410f585439c7d4.x4d14ee33f46b5913(x88449d6466e04295.xd2b15bd56bbd56f2((RelativeHorizontalPosition)obj));
				}
				break;
			case 4160:
				if (xe193ceb565ecaa0a.xee8dbcbd77a95107)
				{
					xe1410f585439c7d4.x4d14ee33f46b5913(x88449d6466e04295.x81ebc6d588b0838e((RelativeVerticalPosition)obj));
				}
				break;
			case 4060:
				if (obj != null)
				{
					xe1410f585439c7d4.x4d14ee33f46b5913("\\trbrdrl");
					x4bf0725a1c29dbf0.x6210059f049f0d48(x8cedcaa9a62c6e39, (Border)obj);
				}
				break;
			case 4080:
				if (obj != null)
				{
					xe1410f585439c7d4.x4d14ee33f46b5913("\\trbrdrr");
					x4bf0725a1c29dbf0.x6210059f049f0d48(x8cedcaa9a62c6e39, (Border)obj);
				}
				break;
			case 4050:
				if (obj != null)
				{
					xe1410f585439c7d4.x4d14ee33f46b5913("\\trbrdrt");
					x4bf0725a1c29dbf0.x6210059f049f0d48(x8cedcaa9a62c6e39, (Border)obj);
				}
				break;
			case 4070:
				if (obj != null)
				{
					xe1410f585439c7d4.x4d14ee33f46b5913("\\trbrdrb");
					x4bf0725a1c29dbf0.x6210059f049f0d48(x8cedcaa9a62c6e39, (Border)obj);
				}
				break;
			case 4090:
				if (obj != null)
				{
					xe1410f585439c7d4.x4d14ee33f46b5913("\\trbrdrh");
					x4bf0725a1c29dbf0.x6210059f049f0d48(x8cedcaa9a62c6e39, (Border)obj);
				}
				break;
			case 4100:
				if (obj != null)
				{
					xe1410f585439c7d4.x4d14ee33f46b5913("\\trbrdrv");
					x4bf0725a1c29dbf0.x6210059f049f0d48(x8cedcaa9a62c6e39, (Border)obj);
				}
				break;
			default:
				_ = x492f529cee830a40;
				break;
			case 4005:
			case 4110:
			case 4120:
			case 4140:
			case 4170:
			case 4180:
			case 4190:
			case 4200:
			case 4330:
			case 4340:
			case 4380:
			case 5000:
			case 5010:
			case 10010:
				break;
			}
		}
		xad4abe09c7029566(xe193ceb565ecaa0a);
		x61c305191003eb85(xe193ceb565ecaa0a);
	}

	private void xad4abe09c7029566(xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		switch (xe193ceb565ecaa0a.x85e9ab4255d7e70c)
		{
		case HeightRule.AtLeast:
			xe1410f585439c7d4.x4d14ee33f46b5913("\\trrh", xe193ceb565ecaa0a.xb0f146032f47c24e);
			break;
		case HeightRule.Exactly:
			xe1410f585439c7d4.x4d14ee33f46b5913("\\trrh", -xe193ceb565ecaa0a.xb0f146032f47c24e);
			break;
		default:
			xe1410f585439c7d4.x4d14ee33f46b5913("\\trrh", 0);
			break;
		}
	}

	private void x61c305191003eb85(xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		x2da87913451ec5ec(xe193ceb565ecaa0a);
		xf52f5bef5370d3e1(xe193ceb565ecaa0a);
	}

	private void xf52f5bef5370d3e1(xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		if (xe193ceb565ecaa0a.x35918784dcf6eda5)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913((xe193ceb565ecaa0a.x2c651fc94bf42334 < 0) ? "\\tposnegy" : "\\tposy", xe193ceb565ecaa0a.x2c651fc94bf42334);
		}
		if (xe193ceb565ecaa0a.x5a935fafcca169c3)
		{
			VerticalAlignment xf6ce0e8106e6a1d = xe193ceb565ecaa0a.xf6ce0e8106e6a1d8;
			if (xf6ce0e8106e6a1d != 0 && xf6ce0e8106e6a1d != VerticalAlignment.Inline)
			{
				xe1410f585439c7d4.x4d14ee33f46b5913(x88449d6466e04295.x2c1d37865de363ef(xf6ce0e8106e6a1d));
			}
			if (xf6ce0e8106e6a1d == VerticalAlignment.Inline && !xe193ceb565ecaa0a.xbc5dc59d0d9b620d(4340))
			{
				xe1410f585439c7d4.x4d14ee33f46b5913("\\tblind0\\tblindtype3");
			}
		}
	}

	private void x2da87913451ec5ec(xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		if (xe193ceb565ecaa0a.x608d0b033d69391d)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913((xe193ceb565ecaa0a.x07f0fe00ef8c8a88 < 0) ? "\\tposnegx" : "\\tposx", xe193ceb565ecaa0a.x07f0fe00ef8c8a88);
		}
		if (xe193ceb565ecaa0a.x46c5e9ab72e3166d)
		{
			HorizontalAlignment xab67cb9464a3325b = xe193ceb565ecaa0a.xab67cb9464a3325b;
			if (xab67cb9464a3325b != 0)
			{
				xe1410f585439c7d4.x4d14ee33f46b5913(x88449d6466e04295.x83b1ccc4b4899faf(xab67cb9464a3325b));
			}
		}
	}

	private void xac55650dda4d602e(xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		if (xe193ceb565ecaa0a.x0f53f53f15b61ef5)
		{
			x5fb16e270c21db2e x5fb16e270c21db2e = xe193ceb565ecaa0a.x5fb16e270c21db2e;
			xe1410f585439c7d4.x4d14ee33f46b5913("\\trauth", x8cedcaa9a62c6e39.x2086e697b5620586.xd6b6ed77479ef68c(x5fb16e270c21db2e.xb063bbfcfeade526));
			xe1410f585439c7d4.x4d14ee33f46b5913("\\trdate", xa0d3611565b2a1f2.x7c734cfcbb14646a(x5fb16e270c21db2e.x242851e6278ed355));
			xe1410f585439c7d4.xee60bff2900a72f2("\\oldtprops");
			x6210059f049f0d48((xedb0eb766e25e0c9)x5fb16e270c21db2e.xdf4bcc85da8f85b2);
			xe1410f585439c7d4.xc8a13a52db0580ae();
		}
	}
}
