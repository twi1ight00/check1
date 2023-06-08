using System;
using System.Collections;
using System.Text;
using x6c95d9cf46ff5f25;

namespace xb1090543d168d647;

internal class xc43925ba6f2dd66c
{
	private string x741beff62ef6c16d;

	private string xed4a7b1500064e12;

	private string xeb2df80c40b21ec9;

	private string x8652f7fdeda5b809 = "";

	private byte x579118b655aa2c42;

	private readonly int x67f0e95c6da64adf;

	private readonly x4bf4b8af8c9f9e78 x79a2d0a98cad1272;

	private x61828b8ede430221[] xb9ac289783dd127b;

	private int[] x92e4b59a5496c035;

	private int[] xeaf1f49e3ec75baf;

	private bool xba77159a9b62f799;

	private bool x3a804cd0fdb78355;

	private x6ec39b1b0c66f918[] x12a03cf6a6ffda92;

	internal string xf9ad6fb78355fe13 => x741beff62ef6c16d;

	internal string x05db5df9789b24d9
	{
		get
		{
			return x8652f7fdeda5b809;
		}
		set
		{
			x8652f7fdeda5b809 = value;
		}
	}

	internal string x2a41239165b955b7
	{
		get
		{
			if (!x0d299f323d241756.x5959bccb67bbf051(xeb2df80c40b21ec9))
			{
				x0e61e1975f017e8e();
				xccdc427968c568fe();
				x1d3504d08215e809(x1dbda17901d20060: true);
				xc7de909fb9aaca09();
			}
			string text = xeb2df80c40b21ec9;
			if (x8652f7fdeda5b809 != "")
			{
				text += x8652f7fdeda5b809;
			}
			return text;
		}
	}

	internal int[] xb624969a856e30be => xeaf1f49e3ec75baf;

	internal int[] x923c40a843439696 => x92e4b59a5496c035;

	internal x6ec39b1b0c66f918[] xdcff38cbdd9cf395
	{
		get
		{
			if (x12a03cf6a6ffda92 == null)
			{
				x0e61e1975f017e8e();
				xccdc427968c568fe();
				x1d3504d08215e809(x1dbda17901d20060: false);
			}
			return x12a03cf6a6ffda92;
		}
	}

	internal byte x3a03159a374ab4fd => x579118b655aa2c42;

	internal static ArrayList xcd89c6dd6a1b87e6(string x467620606087e51a)
	{
		return xcd89c6dd6a1b87e6(x467620606087e51a, null, null);
	}

	internal static ArrayList xcd89c6dd6a1b87e6(string x467620606087e51a, xea515a7e0d19a986 xb79abd38519661cc, x4bf4b8af8c9f9e78 xa5328886ea1c7a18)
	{
		ArrayList arrayList = new ArrayList();
		StringBuilder stringBuilder = new StringBuilder();
		string text = "";
		for (int i = 0; i < x467620606087e51a.Length; i++)
		{
			char c = x467620606087e51a[i];
			xd2d2b731b30d7023 xd2d2b731b30d7024 = xd9a6b2b6ada137e6.x839a041aa1476aed(c);
			if (xd2d2b731b30d7024 == xd2d2b731b30d7023.x8e8f6cc6a0756b05)
			{
				text += c;
				if (i + 1 < x467620606087e51a.Length && x467620606087e51a[i] == '\r' && x467620606087e51a[i + 1] == '\n')
				{
					text += x467620606087e51a[++i];
				}
			}
			else
			{
				stringBuilder.Append(c);
			}
			if (text != "" || i + 1 == x467620606087e51a.Length)
			{
				string text2 = stringBuilder.ToString();
				int embeddingLevel = xb79abd38519661cc?.x59e8b6b220bc288a(arrayList, text2) ?? (-1);
				xc43925ba6f2dd66c xc43925ba6f2dd66c2 = new xc43925ba6f2dd66c(text2, embeddingLevel, xa5328886ea1c7a18);
				xc43925ba6f2dd66c2.x05db5df9789b24d9 = text;
				arrayList.Add(xc43925ba6f2dd66c2);
				stringBuilder.Length = 0;
				text = "";
			}
		}
		return arrayList;
	}

	private xc43925ba6f2dd66c()
	{
	}

	internal xc43925ba6f2dd66c(string text, int embeddingLevel, x4bf4b8af8c9f9e78 calcRunsCharDataModifier)
	{
		x741beff62ef6c16d = text;
		xed4a7b1500064e12 = text;
		x67f0e95c6da64adf = embeddingLevel;
		x79a2d0a98cad1272 = calcRunsCharDataModifier;
	}

	internal xc43925ba6f2dd66c(string text)
		: this(text, -1, null)
	{
	}

	private void xc7de909fb9aaca09()
	{
		StringBuilder stringBuilder = new StringBuilder(xeb2df80c40b21ec9);
		ArrayList arrayList = new ArrayList(xeaf1f49e3ec75baf);
		ArrayList arrayList2 = new ArrayList(x92e4b59a5496c035);
		int num = 0;
		while (num < stringBuilder.Length)
		{
			if ("\u200f\u202b\u202e\u200e\u202a\u202d\u202c".IndexOf(stringBuilder[num]) >= 0)
			{
				stringBuilder.Remove(num, 1);
				arrayList.RemoveAt(num);
				arrayList2.RemoveAt(num);
			}
			else
			{
				num++;
			}
		}
		xeb2df80c40b21ec9 = stringBuilder.ToString();
		xeaf1f49e3ec75baf = xcd4bd3abd72ff2da.x25c5f23efe5b47e4(arrayList);
		x92e4b59a5496c035 = xcd4bd3abd72ff2da.x25c5f23efe5b47e4(arrayList2);
	}

	private void xccdc427968c568fe()
	{
		if (x67f0e95c6da64adf != -1)
		{
			x579118b655aa2c42 = (byte)x67f0e95c6da64adf;
			return;
		}
		for (int i = 0; i < xed4a7b1500064e12.Length; i++)
		{
			switch (xd9a6b2b6ada137e6.x839a041aa1476aed(xed4a7b1500064e12[i]))
			{
			case xd2d2b731b30d7023.xc613adc4330033f3:
			case xd2d2b731b30d7023.x97338636ab2fccfa:
				x579118b655aa2c42 = 1;
				return;
			case xd2d2b731b30d7023.xed846b3bb18ccf39:
				return;
			}
		}
	}

	private void x0e61e1975f017e8e()
	{
		ArrayList arrayList = new ArrayList();
		StringBuilder stringBuilder = x8e2a01cc5dc3c566(arrayList);
		x334886f145ac9471(stringBuilder, arrayList);
		x92e4b59a5496c035 = xcd4bd3abd72ff2da.x25c5f23efe5b47e4(arrayList);
		xed4a7b1500064e12 = stringBuilder.ToString();
	}

	private void x1d3504d08215e809(bool x1dbda17901d20060)
	{
		if (xba77159a9b62f799 && x1dbda17901d20060)
		{
			xed4a7b1500064e12 = x23ea7e981fd7a0f9(xed4a7b1500064e12);
		}
		xb9ac289783dd127b = new x61828b8ede430221[xed4a7b1500064e12.Length];
		byte b = x3a03159a374ab4fd;
		xe037bb9eeffbd9db xe037bb9eeffbd9db2 = xe037bb9eeffbd9db.x3c8c01e56f70ee5c;
		Stack stack = new Stack();
		Stack stack2 = new Stack();
		int num = 0;
		for (int i = 0; i < xed4a7b1500064e12.Length; i++)
		{
			char c = xed4a7b1500064e12[i];
			xb9ac289783dd127b[i] = new x61828b8ede430221();
			xb9ac289783dd127b[i].xbf7d698e3d6d1a49 = xd9a6b2b6ada137e6.x839a041aa1476aed(c);
			xb9ac289783dd127b[i].xfb1fc02db7c42694 = c;
			xb9ac289783dd127b[i].xd1bdf42207dd3638 = num;
			num += x92e4b59a5496c035[i];
			switch (c)
			{
			case '\u202b':
			case '\u202e':
				xb9ac289783dd127b[i].xbd9ab1dea014f991 = b;
				if (b < 60)
				{
					stack2.Push(b);
					stack.Push(xe037bb9eeffbd9db2);
					b = (byte)(b + 1);
					b = (byte)(b | 1u);
					xe037bb9eeffbd9db2 = ((c != '\u202b') ? xe037bb9eeffbd9db.x0162ac4c6d60077b : xe037bb9eeffbd9db.x3c8c01e56f70ee5c);
				}
				continue;
			case '\u202a':
			case '\u202d':
				xb9ac289783dd127b[i].xbd9ab1dea014f991 = b;
				if (b < 59)
				{
					stack2.Push(b);
					stack.Push(xe037bb9eeffbd9db2);
					b = (byte)(b | 1u);
					b = (byte)(b + 1);
					xe037bb9eeffbd9db2 = ((c != '\u202a') ? xe037bb9eeffbd9db.x2663bb9902ccd1fe : xe037bb9eeffbd9db.x3c8c01e56f70ee5c);
				}
				continue;
			default:
				if (xb9ac289783dd127b[i].xbf7d698e3d6d1a49 != xd2d2b731b30d7023.xc2d0cff69f25dfe2)
				{
					xb9ac289783dd127b[i].xbd9ab1dea014f991 = b;
					switch (xe037bb9eeffbd9db2)
					{
					case xe037bb9eeffbd9db.x2663bb9902ccd1fe:
						xb9ac289783dd127b[i].xbf7d698e3d6d1a49 = xd2d2b731b30d7023.xed846b3bb18ccf39;
						break;
					case xe037bb9eeffbd9db.x0162ac4c6d60077b:
						xb9ac289783dd127b[i].xbf7d698e3d6d1a49 = xd2d2b731b30d7023.xc613adc4330033f3;
						break;
					}
					continue;
				}
				break;
			case '\u202c':
				break;
			}
			if (c == '\u202c')
			{
				xb9ac289783dd127b[i].xbd9ab1dea014f991 = b;
				if (stack2.Count > 0)
				{
					b = (byte)stack2.Pop();
					xe037bb9eeffbd9db2 = (xe037bb9eeffbd9db)stack.Pop();
				}
			}
			else if (xb9ac289783dd127b[i].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.xc2d0cff69f25dfe2)
			{
				xb9ac289783dd127b[i].xbd9ab1dea014f991 = b;
			}
		}
		int val = x3a03159a374ab4fd;
		int num2 = 0;
		while (num2 < xed4a7b1500064e12.Length)
		{
			int xbd9ab1dea014f = xb9ac289783dd127b[num2].xbd9ab1dea014f991;
			xd2d2b731b30d7023 x706f68db49e9e = x5b1ffa197a8f3f19(Math.Max(val, xbd9ab1dea014f));
			int j;
			for (j = num2 + 1; j < xed4a7b1500064e12.Length && xb9ac289783dd127b[j].xbd9ab1dea014f991 == xbd9ab1dea014f; j++)
			{
			}
			int val2 = ((j < xed4a7b1500064e12.Length) ? xb9ac289783dd127b[j].xbd9ab1dea014f991 : x3a03159a374ab4fd);
			xd2d2b731b30d7023 x23fe1f362d57a5f = x5b1ffa197a8f3f19(Math.Max(val2, xbd9ab1dea014f));
			x6f7c5a1fad92e7e6(num2, j, x706f68db49e9e, x23fe1f362d57a5f);
			x7c9df96429e230cf(num2, j, x706f68db49e9e, x23fe1f362d57a5f, xbd9ab1dea014f);
			xf3c1f6aad9829cfb(num2, j, xbd9ab1dea014f);
			val = xbd9ab1dea014f;
			num2 = j;
		}
		if (!x1dbda17901d20060)
		{
			xbdf28729a34d7e00();
			return;
		}
		x515b28a46426eb83();
		xbd066ae83d59cd62();
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		StringBuilder stringBuilder = new StringBuilder();
		x61828b8ede430221[] array = xb9ac289783dd127b;
		foreach (x61828b8ede430221 x61828b8ede430222 in array)
		{
			stringBuilder.Append(x61828b8ede430222.xfb1fc02db7c42694);
			arrayList.Add(x61828b8ede430222.xd1bdf42207dd3638);
			arrayList2.Add(1);
		}
		xeb2df80c40b21ec9 = stringBuilder.ToString();
		xeaf1f49e3ec75baf = xcd4bd3abd72ff2da.x25c5f23efe5b47e4(arrayList);
	}

	private void x6f7c5a1fad92e7e6(int x10aaa7cdfa38f254, int x18d5f4b2a0e4dfa3, xd2d2b731b30d7023 x706f68db49e9e323, xd2d2b731b30d7023 x23fe1f362d57a5f1)
	{
		if (x3a804cd0fdb78355)
		{
			xd2d2b731b30d7023 xbf7d698e3d6d1a = x706f68db49e9e323;
			for (int i = x10aaa7cdfa38f254; i < x18d5f4b2a0e4dfa3; i++)
			{
				xd2d2b731b30d7023 xbf7d698e3d6d1a2 = xb9ac289783dd127b[i].xbf7d698e3d6d1a49;
				if (xbf7d698e3d6d1a2 == xd2d2b731b30d7023.xa9f17c4ae061f876)
				{
					xb9ac289783dd127b[i].xbf7d698e3d6d1a49 = xbf7d698e3d6d1a;
				}
				else
				{
					xbf7d698e3d6d1a = xbf7d698e3d6d1a2;
				}
			}
		}
		xd2d2b731b30d7023 xbf7d698e3d6d1a3 = xd2d2b731b30d7023.x311782148482223b;
		for (int j = x10aaa7cdfa38f254; j < x18d5f4b2a0e4dfa3; j++)
		{
			if (xb9ac289783dd127b[j].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.xed846b3bb18ccf39 || xb9ac289783dd127b[j].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.xc613adc4330033f3)
			{
				xbf7d698e3d6d1a3 = xd2d2b731b30d7023.x311782148482223b;
			}
			else if (xb9ac289783dd127b[j].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.x97338636ab2fccfa)
			{
				xbf7d698e3d6d1a3 = xd2d2b731b30d7023.x8b8c96d3cd6915df;
			}
			else if (xb9ac289783dd127b[j].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.x311782148482223b)
			{
				xb9ac289783dd127b[j].xbf7d698e3d6d1a49 = xbf7d698e3d6d1a3;
			}
		}
		if (xba77159a9b62f799)
		{
			for (int k = x10aaa7cdfa38f254; k < x18d5f4b2a0e4dfa3; k++)
			{
				if (xb9ac289783dd127b[k].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.x97338636ab2fccfa)
				{
					xb9ac289783dd127b[k].xbf7d698e3d6d1a49 = xd2d2b731b30d7023.xc613adc4330033f3;
				}
			}
		}
		for (int l = x10aaa7cdfa38f254 + 1; l < x18d5f4b2a0e4dfa3 - 1; l++)
		{
			if (xb9ac289783dd127b[l].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.x93d35165906c7521 || xb9ac289783dd127b[l].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.x93cb071467f4b8f1)
			{
				xd2d2b731b30d7023 xbf7d698e3d6d1a4 = xb9ac289783dd127b[l - 1].xbf7d698e3d6d1a49;
				xd2d2b731b30d7023 xbf7d698e3d6d1a5 = xb9ac289783dd127b[l + 1].xbf7d698e3d6d1a49;
				if (xbf7d698e3d6d1a4 == xd2d2b731b30d7023.x311782148482223b && xbf7d698e3d6d1a5 == xd2d2b731b30d7023.x311782148482223b)
				{
					xb9ac289783dd127b[l].xbf7d698e3d6d1a49 = xd2d2b731b30d7023.x311782148482223b;
				}
				else if (xb9ac289783dd127b[l].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.x93cb071467f4b8f1 && xbf7d698e3d6d1a4 == xd2d2b731b30d7023.x8b8c96d3cd6915df && xbf7d698e3d6d1a5 == xd2d2b731b30d7023.x8b8c96d3cd6915df)
				{
					xb9ac289783dd127b[l].xbf7d698e3d6d1a49 = xd2d2b731b30d7023.x8b8c96d3cd6915df;
				}
			}
		}
		for (int m = x10aaa7cdfa38f254; m < x18d5f4b2a0e4dfa3; m++)
		{
			if (xb9ac289783dd127b[m].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.x1436c9411c3271c3)
			{
				int num = m;
				int num2 = x84665807add26725(num, x18d5f4b2a0e4dfa3, new xd2d2b731b30d7023[1] { xd2d2b731b30d7023.x1436c9411c3271c3 });
				xd2d2b731b30d7023 xd2d2b731b30d7024 = ((num == x10aaa7cdfa38f254) ? x706f68db49e9e323 : xb9ac289783dd127b[num - 1].xbf7d698e3d6d1a49);
				if (xd2d2b731b30d7024 != xd2d2b731b30d7023.x311782148482223b)
				{
					xd2d2b731b30d7024 = ((num2 == x18d5f4b2a0e4dfa3) ? x23fe1f362d57a5f1 : xb9ac289783dd127b[num2].xbf7d698e3d6d1a49);
				}
				if (xd2d2b731b30d7024 == xd2d2b731b30d7023.x311782148482223b)
				{
					xad31bbf5803efd51(num, num2, xd2d2b731b30d7023.x311782148482223b);
				}
				m = num2;
			}
		}
		for (int n = x10aaa7cdfa38f254; n < x18d5f4b2a0e4dfa3; n++)
		{
			xd2d2b731b30d7023 xbf7d698e3d6d1a6 = xb9ac289783dd127b[n].xbf7d698e3d6d1a49;
			if (xbf7d698e3d6d1a6 == xd2d2b731b30d7023.x93d35165906c7521 || xbf7d698e3d6d1a6 == xd2d2b731b30d7023.x1436c9411c3271c3 || xbf7d698e3d6d1a6 == xd2d2b731b30d7023.x93cb071467f4b8f1)
			{
				xb9ac289783dd127b[n].xbf7d698e3d6d1a49 = xd2d2b731b30d7023.x9f8df74f70555214;
			}
		}
		xd2d2b731b30d7023 xbf7d698e3d6d1a7 = ((x706f68db49e9e323 != 0) ? xd2d2b731b30d7023.x311782148482223b : xd2d2b731b30d7023.xed846b3bb18ccf39);
		for (int num3 = x10aaa7cdfa38f254; num3 < x18d5f4b2a0e4dfa3; num3++)
		{
			if (xb9ac289783dd127b[num3].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.xc613adc4330033f3)
			{
				xbf7d698e3d6d1a7 = xd2d2b731b30d7023.x311782148482223b;
			}
			else if (xb9ac289783dd127b[num3].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.xed846b3bb18ccf39)
			{
				xbf7d698e3d6d1a7 = xd2d2b731b30d7023.xed846b3bb18ccf39;
			}
			else if (xb9ac289783dd127b[num3].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.x311782148482223b)
			{
				xb9ac289783dd127b[num3].xbf7d698e3d6d1a49 = xbf7d698e3d6d1a7;
			}
		}
	}

	private void x7c9df96429e230cf(int x10aaa7cdfa38f254, int x18d5f4b2a0e4dfa3, xd2d2b731b30d7023 x706f68db49e9e323, xd2d2b731b30d7023 x23fe1f362d57a5f1, int x66bbd7ed8c65740d)
	{
		for (int i = x10aaa7cdfa38f254; i < x18d5f4b2a0e4dfa3; i++)
		{
			xd2d2b731b30d7023 xbf7d698e3d6d1a = xb9ac289783dd127b[i].xbf7d698e3d6d1a49;
			if (xbf7d698e3d6d1a != xd2d2b731b30d7023.xc28c6a6e1d15307f && xbf7d698e3d6d1a != xd2d2b731b30d7023.x9f8df74f70555214 && xbf7d698e3d6d1a != xd2d2b731b30d7023.x8e8f6cc6a0756b05 && xbf7d698e3d6d1a != xd2d2b731b30d7023.x376fa6aec4a1bfe6)
			{
				continue;
			}
			int num = i;
			int num2 = x84665807add26725(num, x18d5f4b2a0e4dfa3, new xd2d2b731b30d7023[4]
			{
				xd2d2b731b30d7023.x8e8f6cc6a0756b05,
				xd2d2b731b30d7023.x376fa6aec4a1bfe6,
				xd2d2b731b30d7023.xc28c6a6e1d15307f,
				xd2d2b731b30d7023.x9f8df74f70555214
			});
			xd2d2b731b30d7023 xd2d2b731b30d7024;
			if (num == x10aaa7cdfa38f254)
			{
				xd2d2b731b30d7024 = x706f68db49e9e323;
			}
			else
			{
				xd2d2b731b30d7024 = xb9ac289783dd127b[num - 1].xbf7d698e3d6d1a49;
				if (xd2d2b731b30d7024 == xd2d2b731b30d7023.x8b8c96d3cd6915df || xd2d2b731b30d7024 == xd2d2b731b30d7023.x311782148482223b)
				{
					xd2d2b731b30d7024 = xd2d2b731b30d7023.xc613adc4330033f3;
				}
			}
			xd2d2b731b30d7023 xd2d2b731b30d7025;
			if (num2 == x18d5f4b2a0e4dfa3)
			{
				xd2d2b731b30d7025 = x23fe1f362d57a5f1;
			}
			else
			{
				xd2d2b731b30d7025 = xb9ac289783dd127b[num2].xbf7d698e3d6d1a49;
				if (xd2d2b731b30d7025 == xd2d2b731b30d7023.x8b8c96d3cd6915df || xd2d2b731b30d7025 == xd2d2b731b30d7023.x311782148482223b)
				{
					xd2d2b731b30d7025 = xd2d2b731b30d7023.xc613adc4330033f3;
				}
			}
			xd2d2b731b30d7023 x7f0d0710aaf8b45b = ((xd2d2b731b30d7024 != xd2d2b731b30d7025) ? x5b1ffa197a8f3f19(x66bbd7ed8c65740d) : xd2d2b731b30d7024);
			xad31bbf5803efd51(num, num2, x7f0d0710aaf8b45b);
			i = num2;
		}
	}

	private void xf3c1f6aad9829cfb(int x10aaa7cdfa38f254, int x18d5f4b2a0e4dfa3, int x66bbd7ed8c65740d)
	{
		if ((x66bbd7ed8c65740d & 1) == 0)
		{
			for (int i = x10aaa7cdfa38f254; i < x18d5f4b2a0e4dfa3; i++)
			{
				switch (xb9ac289783dd127b[i].xbf7d698e3d6d1a49)
				{
				case xd2d2b731b30d7023.xc613adc4330033f3:
					xb9ac289783dd127b[i].xbd9ab1dea014f991 = xb9ac289783dd127b[i].xbd9ab1dea014f991 + 1;
					break;
				case xd2d2b731b30d7023.x311782148482223b:
				case xd2d2b731b30d7023.x8b8c96d3cd6915df:
					xb9ac289783dd127b[i].xbd9ab1dea014f991 = xb9ac289783dd127b[i].xbd9ab1dea014f991 + 2;
					break;
				}
			}
			return;
		}
		for (int j = x10aaa7cdfa38f254; j < x18d5f4b2a0e4dfa3; j++)
		{
			xd2d2b731b30d7023 xbf7d698e3d6d1a = xb9ac289783dd127b[j].xbf7d698e3d6d1a49;
			if (xbf7d698e3d6d1a == xd2d2b731b30d7023.xed846b3bb18ccf39 || xbf7d698e3d6d1a == xd2d2b731b30d7023.x8b8c96d3cd6915df || xbf7d698e3d6d1a == xd2d2b731b30d7023.x311782148482223b)
			{
				xb9ac289783dd127b[j].xbd9ab1dea014f991 = xb9ac289783dd127b[j].xbd9ab1dea014f991 + 1;
			}
		}
	}

	private void x515b28a46426eb83()
	{
		int num = 0;
		for (int i = 0; i < xb9ac289783dd127b.Length; i++)
		{
			if (xb9ac289783dd127b[i].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.x376fa6aec4a1bfe6 || xb9ac289783dd127b[i].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.x8e8f6cc6a0756b05)
			{
				for (int j = num; j <= i; j++)
				{
					xb9ac289783dd127b[j].xbd9ab1dea014f991 = x3a03159a374ab4fd;
				}
			}
			if (xb9ac289783dd127b[i].xbf7d698e3d6d1a49 != xd2d2b731b30d7023.xc28c6a6e1d15307f)
			{
				num = i + 1;
			}
		}
		for (int k = num; k < xb9ac289783dd127b.Length; k++)
		{
			xb9ac289783dd127b[k].xbd9ab1dea014f991 = x3a03159a374ab4fd;
		}
		int num2 = 0;
		int num3 = 63;
		x61828b8ede430221[] array = xb9ac289783dd127b;
		foreach (x61828b8ede430221 x61828b8ede430222 in array)
		{
			if (x61828b8ede430222.xbd9ab1dea014f991 > num2)
			{
				num2 = x61828b8ede430222.xbd9ab1dea014f991;
			}
			if ((x61828b8ede430222.xbd9ab1dea014f991 & 1) == 1 && x61828b8ede430222.xbd9ab1dea014f991 < num3)
			{
				num3 = x61828b8ede430222.xbd9ab1dea014f991;
			}
		}
		for (int num4 = num2; num4 >= num3; num4--)
		{
			for (int m = 0; m < xb9ac289783dd127b.Length; m++)
			{
				if (xb9ac289783dd127b[m].xbd9ab1dea014f991 >= num4)
				{
					int num5 = m;
					int n;
					for (n = m + 1; n < xb9ac289783dd127b.Length && xb9ac289783dd127b[n].xbd9ab1dea014f991 >= num4; n++)
					{
					}
					int num6 = num5;
					int num7 = n - 1;
					while (num6 < num7)
					{
						x61828b8ede430221 x61828b8ede430223 = xb9ac289783dd127b[num6];
						xb9ac289783dd127b[num6] = xb9ac289783dd127b[num7];
						xb9ac289783dd127b[num7] = x61828b8ede430223;
						num6++;
						num7--;
					}
					m = n;
				}
			}
		}
	}

	private void xbd066ae83d59cd62()
	{
		for (int i = 0; i < xb9ac289783dd127b.Length; i++)
		{
			if ((xb9ac289783dd127b[i].xbd9ab1dea014f991 & 1) == 1)
			{
				xb9ac289783dd127b[i].xfb1fc02db7c42694 = x34c58051c362e2a2.xa8926498a9b9a931(xb9ac289783dd127b[i].xfb1fc02db7c42694);
			}
		}
	}

	private string x23ea7e981fd7a0f9(string xb41faee6912a2313)
	{
		x89c665a4797cda9f x89c665a4797cda9f2 = x89c665a4797cda9f.xaeebd880347ac418;
		x13db88e817534a1c x13db88e817534a1c2 = x13db88e817534a1c.x5920fbeb94de1c90;
		int num = 0;
		char c = '\uffff';
		x13db88e817534a1c[] array = new x13db88e817534a1c[xb41faee6912a2313.Length];
		for (int i = 0; i < xb41faee6912a2313.Length; i++)
		{
			char c2 = xb41faee6912a2313[i];
			x89c665a4797cda9f x89c665a4797cda9f3 = x6350aa5ac0b179b2.x9a083b5e298259c7(c2);
			if ((x89c665a4797cda9f3 == x89c665a4797cda9f.xc613adc4330033f3 || x89c665a4797cda9f3 == x89c665a4797cda9f.x5d593cee9d844848 || x89c665a4797cda9f3 == x89c665a4797cda9f.x857912840ffd015f) && (x89c665a4797cda9f2 == x89c665a4797cda9f.xed846b3bb18ccf39 || x89c665a4797cda9f2 == x89c665a4797cda9f.x5d593cee9d844848 || x89c665a4797cda9f2 == x89c665a4797cda9f.x857912840ffd015f))
			{
				if (x13db88e817534a1c2 == x13db88e817534a1c.x5920fbeb94de1c90 && (x89c665a4797cda9f2 == x89c665a4797cda9f.x5d593cee9d844848 || x89c665a4797cda9f2 == x89c665a4797cda9f.xed846b3bb18ccf39))
				{
					array[num] = x13db88e817534a1c.x660adf533ba4edef;
				}
				else if (x13db88e817534a1c2 == x13db88e817534a1c.x6c4a61fe0135fb17 && x89c665a4797cda9f2 == x89c665a4797cda9f.x5d593cee9d844848)
				{
					array[num] = x13db88e817534a1c.x144e30a1467072ae;
				}
				array[i] = x13db88e817534a1c.x6c4a61fe0135fb17;
				x13db88e817534a1c2 = x13db88e817534a1c.x6c4a61fe0135fb17;
				x89c665a4797cda9f2 = x89c665a4797cda9f3;
				num = i;
				c = c2;
			}
			else if (x89c665a4797cda9f3 != x89c665a4797cda9f.x14abc7eff15bf82b)
			{
				array[i] = x13db88e817534a1c.x5920fbeb94de1c90;
				x13db88e817534a1c2 = x13db88e817534a1c.x5920fbeb94de1c90;
				x89c665a4797cda9f2 = x89c665a4797cda9f3;
				num = i;
				c = c2;
			}
			else
			{
				array[i] = x13db88e817534a1c.x5920fbeb94de1c90;
			}
		}
		c = '\uffff';
		num = 0;
		int index = 0;
		StringBuilder stringBuilder = new StringBuilder();
		ArrayList arrayList = new ArrayList(x92e4b59a5496c035);
		for (int j = 0; j < xb41faee6912a2313.Length; j++)
		{
			char c3 = xb41faee6912a2313[j];
			x89c665a4797cda9f x89c665a4797cda9f4 = x6350aa5ac0b179b2.x9a083b5e298259c7(c3);
			if (c == 'ل' && c3 != 'ا' && c3 != 'آ' && c3 != 'أ' && c3 != 'إ' && x89c665a4797cda9f4 != x89c665a4797cda9f.x14abc7eff15bf82b)
			{
				c = '\uffff';
			}
			else if (c3 == 'ل')
			{
				c = c3;
				num = j;
				index = stringBuilder.Length;
			}
			if (c == 'ل')
			{
				if (array[num] == x13db88e817534a1c.x144e30a1467072ae)
				{
					switch (c3)
					{
					case 'ا':
						stringBuilder[index] = 'ﻼ';
						arrayList.RemoveAt(index);
						continue;
					case 'آ':
						stringBuilder[index] = 'ﻶ';
						arrayList.RemoveAt(index);
						arrayList[index] = (int)arrayList[index] + 1;
						continue;
					case 'أ':
						stringBuilder[index] = 'ﻸ';
						arrayList.RemoveAt(index);
						continue;
					case 'إ':
						stringBuilder[index] = 'ﻺ';
						arrayList.RemoveAt(index);
						continue;
					}
				}
				else if (array[num] == x13db88e817534a1c.x660adf533ba4edef)
				{
					switch (c3)
					{
					case 'ا':
						stringBuilder[index] = 'ﻻ';
						arrayList.RemoveAt(index);
						continue;
					case 'آ':
						stringBuilder[index] = 'ﻵ';
						arrayList.RemoveAt(index);
						arrayList[index] = (int)arrayList[index] + 1;
						continue;
					case 'أ':
						stringBuilder[index] = 'ﻷ';
						arrayList.RemoveAt(index);
						continue;
					case 'إ':
						stringBuilder[index] = 'ﻹ';
						arrayList.RemoveAt(index);
						continue;
					}
				}
			}
			stringBuilder.Append(x6350aa5ac0b179b2.xb6b2696908760820(c3, array[j]));
		}
		x92e4b59a5496c035 = xcd4bd3abd72ff2da.x25c5f23efe5b47e4(arrayList);
		return stringBuilder.ToString();
	}

	private char x2a5f0934ae62db3f(char x62584df2cb5d40dd, char xac08cf66a2c6510c)
	{
		if (x62584df2cb5d40dd < '\0' || x62584df2cb5d40dd > '\uffff' || xac08cf66a2c6510c < '\0' || xac08cf66a2c6510c > '\uffff')
		{
			return '\uffff';
		}
		return xd9a6b2b6ada137e6.x10d30c930a90ad82(x62584df2cb5d40dd.ToString() + xac08cf66a2c6510c);
	}

	private void x334886f145ac9471(StringBuilder x11d58b056c032b03, ArrayList x8b3ddb1c02be2067)
	{
		if (x11d58b056c032b03.Length == 0)
		{
			return;
		}
		int index = 0;
		int num = 1;
		char c = x11d58b056c032b03[0];
		x8b3ddb1c02be2067[index] = (int)x8b3ddb1c02be2067[index] + 1;
		x610f9b736060774c x610f9b736060774c2 = xd9a6b2b6ada137e6.xdcb014d94aea6e74(c);
		if (x610f9b736060774c2 != 0)
		{
			x610f9b736060774c2 = (x610f9b736060774c)256;
		}
		int length = x11d58b056c032b03.Length;
		for (int i = num; i < x11d58b056c032b03.Length; i++)
		{
			char c2 = x11d58b056c032b03[i];
			x610f9b736060774c x610f9b736060774c3 = xd9a6b2b6ada137e6.xdcb014d94aea6e74(c2);
			char c3 = x2a5f0934ae62db3f(c, c2);
			if (xd9a6b2b6ada137e6.x41c856f7eceb7c62(c3) == xe9104eca3968ec19.x4d0b9d4447ba7566 && c3 != '\uffff' && (x610f9b736060774c2 < x610f9b736060774c3 || x610f9b736060774c2 == x610f9b736060774c.x48ce0d46d6b8c1d4))
			{
				x11d58b056c032b03[index] = c3;
				x8b3ddb1c02be2067[index] = (int)x8b3ddb1c02be2067[index] + 1;
				c = c3;
				continue;
			}
			if (x610f9b736060774c3 == x610f9b736060774c.x48ce0d46d6b8c1d4)
			{
				index = num;
				c = c2;
			}
			x610f9b736060774c2 = x610f9b736060774c3;
			x11d58b056c032b03[num] = c2;
			int j = num;
			if ((int)x8b3ddb1c02be2067[j] < 0)
			{
				for (; (int)x8b3ddb1c02be2067[j] < 0; j++)
				{
					x8b3ddb1c02be2067[j] = (int)x8b3ddb1c02be2067[j] + 1;
					x8b3ddb1c02be2067.Insert(num, 0);
				}
			}
			else
			{
				x8b3ddb1c02be2067[j] = (int)x8b3ddb1c02be2067[j] + 1;
			}
			if (x11d58b056c032b03.Length != length)
			{
				i += x11d58b056c032b03.Length - length;
				length = x11d58b056c032b03.Length;
			}
			num++;
		}
		x11d58b056c032b03.Length = num;
		x8b3ddb1c02be2067.RemoveRange(num, x8b3ddb1c02be2067.Count - num);
	}

	private static void x11f64aae12429e33(bool x2701c149a7daec31, char xb867a42da3ae686d, StringBuilder xd07ce4b74c5774a7)
	{
		string text = xd9a6b2b6ada137e6.x603bc1e3ce7f9a3a(xb867a42da3ae686d);
		if (text != null && (!x2701c149a7daec31 || xd9a6b2b6ada137e6.x41c856f7eceb7c62(xb867a42da3ae686d) == xe9104eca3968ec19.x4d0b9d4447ba7566))
		{
			for (int i = 0; i < text.Length; i++)
			{
				x11f64aae12429e33(x2701c149a7daec31, text[i], xd07ce4b74c5774a7);
			}
		}
		else
		{
			xd07ce4b74c5774a7.Append(xb867a42da3ae686d);
		}
	}

	private StringBuilder x8e2a01cc5dc3c566(ArrayList x8b3ddb1c02be2067)
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		xba77159a9b62f799 = false;
		x3a804cd0fdb78355 = false;
		for (int i = 0; i < xed4a7b1500064e12.Length; i++)
		{
			xd2d2b731b30d7023 xd2d2b731b30d7024 = xd9a6b2b6ada137e6.x839a041aa1476aed(xed4a7b1500064e12[i]);
			xba77159a9b62f799 |= xd2d2b731b30d7024 == xd2d2b731b30d7023.x97338636ab2fccfa || xd2d2b731b30d7024 == xd2d2b731b30d7023.x8b8c96d3cd6915df;
			x3a804cd0fdb78355 |= xd2d2b731b30d7024 == xd2d2b731b30d7023.xa9f17c4ae061f876;
			stringBuilder2.Length = 0;
			x11f64aae12429e33(x2701c149a7daec31: false, xed4a7b1500064e12[i], stringBuilder2);
			x8b3ddb1c02be2067.Add(1 - stringBuilder2.Length);
			for (int j = 0; j < stringBuilder2.Length; j++)
			{
				char c = stringBuilder2[j];
				x610f9b736060774c x610f9b736060774c2 = xd9a6b2b6ada137e6.xdcb014d94aea6e74(c);
				int num = stringBuilder.Length;
				if (x610f9b736060774c2 != 0)
				{
					while (num > 0)
					{
						char x3c4da2980d043c = stringBuilder[num - 1];
						if (xd9a6b2b6ada137e6.xdcb014d94aea6e74(x3c4da2980d043c) <= x610f9b736060774c2)
						{
							break;
						}
						num--;
					}
				}
				stringBuilder.Insert(num, c);
			}
		}
		return stringBuilder;
	}

	private static xd2d2b731b30d7023 x5b1ffa197a8f3f19(int x66bbd7ed8c65740d)
	{
		if (((uint)x66bbd7ed8c65740d & (true ? 1u : 0u)) != 0)
		{
			return xd2d2b731b30d7023.xc613adc4330033f3;
		}
		return xd2d2b731b30d7023.xed846b3bb18ccf39;
	}

	private int x84665807add26725(int xc0c4c459c6ccbd00, int x18d5f4b2a0e4dfa3, xd2d2b731b30d7023[] x93721743ee3e07fc)
	{
		xc0c4c459c6ccbd00--;
		while (++xc0c4c459c6ccbd00 < x18d5f4b2a0e4dfa3)
		{
			xd2d2b731b30d7023 xbf7d698e3d6d1a = xb9ac289783dd127b[xc0c4c459c6ccbd00].xbf7d698e3d6d1a49;
			bool flag = false;
			for (int i = 0; i < x93721743ee3e07fc.Length; i++)
			{
				if (flag)
				{
					break;
				}
				if (xbf7d698e3d6d1a == x93721743ee3e07fc[i])
				{
					flag = true;
				}
			}
			if (!flag)
			{
				return xc0c4c459c6ccbd00;
			}
		}
		return x18d5f4b2a0e4dfa3;
	}

	private void xad31bbf5803efd51(int x10aaa7cdfa38f254, int x18d5f4b2a0e4dfa3, xd2d2b731b30d7023 x7f0d0710aaf8b45b)
	{
		for (int i = x10aaa7cdfa38f254; i < x18d5f4b2a0e4dfa3; i++)
		{
			xb9ac289783dd127b[i].xbf7d698e3d6d1a49 = x7f0d0710aaf8b45b;
		}
	}

	private void xbdf28729a34d7e00()
	{
		if (x79a2d0a98cad1272 != null)
		{
			x79a2d0a98cad1272.x57f70b425b43a885(this, xb9ac289783dd127b);
		}
		int num = -1;
		StringBuilder stringBuilder = new StringBuilder();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < xb9ac289783dd127b.Length; i++)
		{
			if ("\u200f\u202b\u202e\u200e\u202a\u202d\u202c".IndexOf(xb9ac289783dd127b[i].xfb1fc02db7c42694) != -1)
			{
				continue;
			}
			if (xb9ac289783dd127b[i].xbd9ab1dea014f991 != num || num == -1)
			{
				if (num != -1)
				{
					arrayList.Add(new x6ec39b1b0c66f918(stringBuilder.ToString(), num));
				}
				stringBuilder = new StringBuilder();
				num = xb9ac289783dd127b[i].xbd9ab1dea014f991;
			}
			stringBuilder.Append(xb9ac289783dd127b[i].xfb1fc02db7c42694);
		}
		arrayList.Add(new x6ec39b1b0c66f918(stringBuilder.ToString(), num));
		x12a03cf6a6ffda92 = (x6ec39b1b0c66f918[])arrayList.ToArray(typeof(x6ec39b1b0c66f918));
	}
}
