using System.Collections;
using System.IO;
using System.Text;
using x6c95d9cf46ff5f25;

namespace x643046e3f004c49f;

internal class xce9c5b0a9b7b658c
{
	private enum x5bbb627fd202d40c
	{
		xf9ad6fb78355fe13,
		x20abfbb300452b94,
		xd229d86af0f16fb0,
		x8272b224c765818e,
		x9989a45714e49ce1,
		x41722bdafc579870,
		x9e11018b2b9153ad,
		x29eeea42f36c9c0f,
		xad752fa1abb9883d,
		x937e050c63ea1527,
		x4f92727072b38926,
		xd68b587e1c130afd,
		xf27706f4cef15dde
	}

	internal Hashtable xe6fe0fdeb463a333;

	internal x9d6b37cac59aa2e2 x10e05a35f37660c5;

	internal string xed4a7b1500064e12;

	private x9d6b37cac59aa2e2 x5a4005b11b247c4d;

	private x9d6b37cac59aa2e2 x4e9bf513f3fd7c01;

	private xb5db1aec26ffbd5e x10cdb594c621057e;

	private int xc7a1ff40f60e5ecf;

	private char x6d0df3179ab204fc;

	private bool x5ee9dd273d9a1457;

	private x5bbb627fd202d40c x9b529da35d1032aa;

	private x5bbb627fd202d40c x64807174df32bf8c;

	private static readonly Hashtable x4ebe353021fb0790;

	internal x9d6b37cac59aa2e2 x154bf1cc56c06b95 => x10e05a35f37660c5;

	static xce9c5b0a9b7b658c()
	{
		x4ebe353021fb0790 = new Hashtable(16);
		x4ebe353021fb0790.Add("li", new xb893565b7e4116c7(new string[1] { "li" }, new string[2] { "ol", "ul" }));
		xb893565b7e4116c7 value = new xb893565b7e4116c7(new string[2] { "dt", "dd" }, null);
		x4ebe353021fb0790.Add("dt", value);
		x4ebe353021fb0790.Add("dd", value);
		x4ebe353021fb0790.Add("tr", new xb893565b7e4116c7(new string[1] { "tr" }, new string[1] { "table" }));
		xb893565b7e4116c7 value2 = new xb893565b7e4116c7(new string[2] { "th", "td" }, new string[2] { "tr", "table" });
		x4ebe353021fb0790.Add("th", value2);
		x4ebe353021fb0790.Add("td", value2);
		xb893565b7e4116c7 value3 = new xb893565b7e4116c7(new string[4] { "thead", "tfoot", "tbody", "tr" }, new string[1] { "table" });
		x4ebe353021fb0790.Add("thead", value3);
		x4ebe353021fb0790.Add("tfoot", value3);
		x4ebe353021fb0790.Add("tbody", value3);
		x4ebe353021fb0790.Add("option", new xb893565b7e4116c7(new string[1] { "option" }, null));
		x4ebe353021fb0790.Add("body", new xb893565b7e4116c7(new string[1] { "head" }, null));
	}

	internal xce9c5b0a9b7b658c()
	{
		x10e05a35f37660c5 = x9a3cd5964e27b158(x8be2136363630db4.x2c8c6741422a1298, 0);
	}

	internal void x5d95f5f98c940295(Stream xcf18e5243f8d5fd3, Encoding xff3edc9aa5f0523b)
	{
		x5d95f5f98c940295(new StreamReader(xcf18e5243f8d5fd3, xff3edc9aa5f0523b));
	}

	internal void x5d95f5f98c940295(string xe125219852864557)
	{
		using StreamReader xe134235b3526fa = new StreamReader(xe125219852864557);
		x5d95f5f98c940295(xe134235b3526fa);
	}

	internal void xd82c42838030fa49(string x27d6d3ff1b275a1a)
	{
		using StringReader xe134235b3526fa = new StringReader(x27d6d3ff1b275a1a);
		x5d95f5f98c940295(xe134235b3526fa);
	}

	internal void x5d95f5f98c940295(TextReader xe134235b3526fa75)
	{
		xed4a7b1500064e12 = xe134235b3526fa75.ReadToEnd();
		x10e05a35f37660c5 = x9a3cd5964e27b158(x8be2136363630db4.x2c8c6741422a1298, 0);
		x1f490eac106aee12();
	}

	internal x9d6b37cac59aa2e2 x9a3cd5964e27b158(x8be2136363630db4 x43163d22e8cd5a71, int xc0c4c459c6ccbd00)
	{
		return x43163d22e8cd5a71 switch
		{
			x8be2136363630db4.x937e050c63ea1527 => new x1cb19c55611bc242(this, xc0c4c459c6ccbd00), 
			x8be2136363630db4.xf9ad6fb78355fe13 => new x5ed0803b99b17b70(this, xc0c4c459c6ccbd00), 
			_ => new x9d6b37cac59aa2e2(x43163d22e8cd5a71, this, xc0c4c459c6ccbd00), 
		};
	}

	private void x1f490eac106aee12()
	{
		int num = 0;
		xe6fe0fdeb463a333 = new Hashtable();
		x6d0df3179ab204fc = '\0';
		x5ee9dd273d9a1457 = false;
		x9b529da35d1032aa = x5bbb627fd202d40c.xf9ad6fb78355fe13;
		x64807174df32bf8c = x9b529da35d1032aa;
		x10e05a35f37660c5.x91c3e0e7013350f3 = xed4a7b1500064e12.Length;
		x10e05a35f37660c5.xd14e6592dcabf708 = xed4a7b1500064e12.Length;
		x4e9bf513f3fd7c01 = x10e05a35f37660c5;
		x5a4005b11b247c4d = x9a3cd5964e27b158(x8be2136363630db4.xf9ad6fb78355fe13, 0);
		x10cdb594c621057e = null;
		xc7a1ff40f60e5ecf = 0;
		x924923c3e0a0a23b(x8be2136363630db4.xf9ad6fb78355fe13, 0);
		while (xc7a1ff40f60e5ecf < xed4a7b1500064e12.Length)
		{
			x6d0df3179ab204fc = xed4a7b1500064e12[xc7a1ff40f60e5ecf++];
			switch (x9b529da35d1032aa)
			{
			case x5bbb627fd202d40c.xf9ad6fb78355fe13:
				if (!xc2ca8c3dd3eb5ab2())
				{
				}
				break;
			case x5bbb627fd202d40c.x20abfbb300452b94:
				if (!xc2ca8c3dd3eb5ab2())
				{
					if (x6d0df3179ab204fc == '/')
					{
						x181795112161a98c(x68ee3ac086332950: false, xc7a1ff40f60e5ecf);
					}
					else
					{
						x181795112161a98c(x68ee3ac086332950: true, --xc7a1ff40f60e5ecf);
					}
					x9b529da35d1032aa = x5bbb627fd202d40c.xd229d86af0f16fb0;
				}
				break;
			case x5bbb627fd202d40c.xd229d86af0f16fb0:
				if (xc2ca8c3dd3eb5ab2())
				{
					break;
				}
				if (x6c589c7857d7d8d9(x6d0df3179ab204fc))
				{
					x3d07603fd853dff0(xc7a1ff40f60e5ecf - 1);
					if (x9b529da35d1032aa == x5bbb627fd202d40c.xd229d86af0f16fb0)
					{
						x9b529da35d1032aa = x5bbb627fd202d40c.x8272b224c765818e;
					}
				}
				else if (x6d0df3179ab204fc == '/')
				{
					x3d07603fd853dff0(xc7a1ff40f60e5ecf - 1);
					if (x9b529da35d1032aa == x5bbb627fd202d40c.xd229d86af0f16fb0)
					{
						x9b529da35d1032aa = x5bbb627fd202d40c.x9989a45714e49ce1;
					}
				}
				else
				{
					if (x6d0df3179ab204fc != '>')
					{
						break;
					}
					x3d07603fd853dff0(xc7a1ff40f60e5ecf - 1);
					if (x9b529da35d1032aa == x5bbb627fd202d40c.xd229d86af0f16fb0)
					{
						if (!x79e9f8d17bf653c5(xc7a1ff40f60e5ecf, xeb1688f3c25edfc6: false))
						{
							xc7a1ff40f60e5ecf = xed4a7b1500064e12.Length;
						}
						else if (x9b529da35d1032aa == x5bbb627fd202d40c.xd229d86af0f16fb0)
						{
							x9b529da35d1032aa = x5bbb627fd202d40c.xf9ad6fb78355fe13;
							x924923c3e0a0a23b(x8be2136363630db4.xf9ad6fb78355fe13, xc7a1ff40f60e5ecf);
						}
					}
				}
				break;
			case x5bbb627fd202d40c.x8272b224c765818e:
				if (xc2ca8c3dd3eb5ab2() || x6c589c7857d7d8d9(x6d0df3179ab204fc))
				{
					break;
				}
				if (x6d0df3179ab204fc == '/' || x6d0df3179ab204fc == '?')
				{
					x9b529da35d1032aa = x5bbb627fd202d40c.x9989a45714e49ce1;
				}
				else if (x6d0df3179ab204fc == '>')
				{
					if (!x79e9f8d17bf653c5(xc7a1ff40f60e5ecf, xeb1688f3c25edfc6: false))
					{
						xc7a1ff40f60e5ecf = xed4a7b1500064e12.Length;
					}
					else if (x9b529da35d1032aa == x5bbb627fd202d40c.x8272b224c765818e)
					{
						x9b529da35d1032aa = x5bbb627fd202d40c.xf9ad6fb78355fe13;
						x924923c3e0a0a23b(x8be2136363630db4.xf9ad6fb78355fe13, xc7a1ff40f60e5ecf);
					}
				}
				else
				{
					x95c6b771b71d3e8e(xc7a1ff40f60e5ecf - 1);
					x9b529da35d1032aa = x5bbb627fd202d40c.x41722bdafc579870;
				}
				break;
			case x5bbb627fd202d40c.x9989a45714e49ce1:
				if (xc2ca8c3dd3eb5ab2())
				{
					break;
				}
				if (x6d0df3179ab204fc == '>')
				{
					if (!x79e9f8d17bf653c5(xc7a1ff40f60e5ecf, xeb1688f3c25edfc6: true))
					{
						xc7a1ff40f60e5ecf = xed4a7b1500064e12.Length;
					}
					else if (x9b529da35d1032aa == x5bbb627fd202d40c.x9989a45714e49ce1)
					{
						x9b529da35d1032aa = x5bbb627fd202d40c.xf9ad6fb78355fe13;
						x924923c3e0a0a23b(x8be2136363630db4.xf9ad6fb78355fe13, xc7a1ff40f60e5ecf);
					}
				}
				else
				{
					x9b529da35d1032aa = x5bbb627fd202d40c.x8272b224c765818e;
				}
				break;
			case x5bbb627fd202d40c.x41722bdafc579870:
				if (xc2ca8c3dd3eb5ab2())
				{
					break;
				}
				if (x6c589c7857d7d8d9(x6d0df3179ab204fc))
				{
					xf3ebed69fe3491bb(xc7a1ff40f60e5ecf - 1);
					x9b529da35d1032aa = x5bbb627fd202d40c.x9e11018b2b9153ad;
				}
				else if (x6d0df3179ab204fc == '=')
				{
					xf3ebed69fe3491bb(xc7a1ff40f60e5ecf - 1);
					x9b529da35d1032aa = x5bbb627fd202d40c.x29eeea42f36c9c0f;
				}
				else if (x6d0df3179ab204fc == '>')
				{
					xf3ebed69fe3491bb(xc7a1ff40f60e5ecf - 1);
					if (!x79e9f8d17bf653c5(xc7a1ff40f60e5ecf, xeb1688f3c25edfc6: false))
					{
						xc7a1ff40f60e5ecf = xed4a7b1500064e12.Length;
					}
					else if (x9b529da35d1032aa == x5bbb627fd202d40c.x41722bdafc579870)
					{
						x9b529da35d1032aa = x5bbb627fd202d40c.xf9ad6fb78355fe13;
						x924923c3e0a0a23b(x8be2136363630db4.xf9ad6fb78355fe13, xc7a1ff40f60e5ecf);
					}
				}
				break;
			case x5bbb627fd202d40c.x9e11018b2b9153ad:
				if (xc2ca8c3dd3eb5ab2() || x6c589c7857d7d8d9(x6d0df3179ab204fc))
				{
					break;
				}
				if (x6d0df3179ab204fc == '>')
				{
					if (!x79e9f8d17bf653c5(xc7a1ff40f60e5ecf, xeb1688f3c25edfc6: false))
					{
						xc7a1ff40f60e5ecf = xed4a7b1500064e12.Length;
					}
					else if (x9b529da35d1032aa == x5bbb627fd202d40c.x9e11018b2b9153ad)
					{
						x9b529da35d1032aa = x5bbb627fd202d40c.xf9ad6fb78355fe13;
						x924923c3e0a0a23b(x8be2136363630db4.xf9ad6fb78355fe13, xc7a1ff40f60e5ecf);
					}
				}
				else if (x6d0df3179ab204fc == '=')
				{
					x9b529da35d1032aa = x5bbb627fd202d40c.x29eeea42f36c9c0f;
				}
				else
				{
					x9b529da35d1032aa = x5bbb627fd202d40c.x8272b224c765818e;
					xc7a1ff40f60e5ecf--;
				}
				break;
			case x5bbb627fd202d40c.x29eeea42f36c9c0f:
				if (xc2ca8c3dd3eb5ab2() || x6c589c7857d7d8d9(x6d0df3179ab204fc))
				{
					break;
				}
				if (x6d0df3179ab204fc == '\'' || x6d0df3179ab204fc == '"')
				{
					x9b529da35d1032aa = x5bbb627fd202d40c.x4f92727072b38926;
					x75272c379f8194f2(xc7a1ff40f60e5ecf);
					num = x6d0df3179ab204fc;
				}
				else if (x6d0df3179ab204fc == '>')
				{
					if (!x79e9f8d17bf653c5(xc7a1ff40f60e5ecf, xeb1688f3c25edfc6: false))
					{
						xc7a1ff40f60e5ecf = xed4a7b1500064e12.Length;
					}
					else if (x9b529da35d1032aa == x5bbb627fd202d40c.x29eeea42f36c9c0f)
					{
						x9b529da35d1032aa = x5bbb627fd202d40c.xf9ad6fb78355fe13;
						x924923c3e0a0a23b(x8be2136363630db4.xf9ad6fb78355fe13, xc7a1ff40f60e5ecf);
					}
				}
				else
				{
					x75272c379f8194f2(xc7a1ff40f60e5ecf - 1);
					x9b529da35d1032aa = x5bbb627fd202d40c.xad752fa1abb9883d;
				}
				break;
			case x5bbb627fd202d40c.xad752fa1abb9883d:
				if (xc2ca8c3dd3eb5ab2())
				{
					break;
				}
				if (x6c589c7857d7d8d9(x6d0df3179ab204fc))
				{
					x3b1ebc010e7bfa7e(xc7a1ff40f60e5ecf - 1);
					x9b529da35d1032aa = x5bbb627fd202d40c.x8272b224c765818e;
				}
				else if (x6d0df3179ab204fc == '>')
				{
					x3b1ebc010e7bfa7e(xc7a1ff40f60e5ecf - 1);
					if (!x79e9f8d17bf653c5(xc7a1ff40f60e5ecf, xeb1688f3c25edfc6: false))
					{
						xc7a1ff40f60e5ecf = xed4a7b1500064e12.Length;
					}
					else if (x9b529da35d1032aa == x5bbb627fd202d40c.xad752fa1abb9883d)
					{
						x9b529da35d1032aa = x5bbb627fd202d40c.xf9ad6fb78355fe13;
						x924923c3e0a0a23b(x8be2136363630db4.xf9ad6fb78355fe13, xc7a1ff40f60e5ecf);
					}
				}
				break;
			case x5bbb627fd202d40c.x4f92727072b38926:
				if (x6d0df3179ab204fc == num)
				{
					x3b1ebc010e7bfa7e(xc7a1ff40f60e5ecf - 1);
					x9b529da35d1032aa = x5bbb627fd202d40c.x8272b224c765818e;
				}
				else if (x6d0df3179ab204fc == '<' && xc7a1ff40f60e5ecf < xed4a7b1500064e12.Length && xed4a7b1500064e12[xc7a1ff40f60e5ecf] == '%')
				{
					x64807174df32bf8c = x9b529da35d1032aa;
					x9b529da35d1032aa = x5bbb627fd202d40c.xd68b587e1c130afd;
				}
				break;
			case x5bbb627fd202d40c.x937e050c63ea1527:
				if (x6d0df3179ab204fc == '>' && (!x5ee9dd273d9a1457 || (xed4a7b1500064e12[xc7a1ff40f60e5ecf - 2] == '-' && xed4a7b1500064e12[xc7a1ff40f60e5ecf - 3] == '-')))
				{
					if (!x79e9f8d17bf653c5(xc7a1ff40f60e5ecf, xeb1688f3c25edfc6: false))
					{
						xc7a1ff40f60e5ecf = xed4a7b1500064e12.Length;
						break;
					}
					x9b529da35d1032aa = x5bbb627fd202d40c.xf9ad6fb78355fe13;
					x924923c3e0a0a23b(x8be2136363630db4.xf9ad6fb78355fe13, xc7a1ff40f60e5ecf);
				}
				break;
			case x5bbb627fd202d40c.xd68b587e1c130afd:
				if (x6d0df3179ab204fc == '%' && xc7a1ff40f60e5ecf < xed4a7b1500064e12.Length && xed4a7b1500064e12[xc7a1ff40f60e5ecf] == '>')
				{
					switch (x64807174df32bf8c)
					{
					case x5bbb627fd202d40c.x29eeea42f36c9c0f:
						x9b529da35d1032aa = x5bbb627fd202d40c.xad752fa1abb9883d;
						break;
					case x5bbb627fd202d40c.x8272b224c765818e:
						xf3ebed69fe3491bb(xc7a1ff40f60e5ecf + 1);
						x9b529da35d1032aa = x5bbb627fd202d40c.x8272b224c765818e;
						break;
					default:
						x9b529da35d1032aa = x64807174df32bf8c;
						break;
					}
					xc7a1ff40f60e5ecf++;
				}
				break;
			case x5bbb627fd202d40c.xf27706f4cef15dde:
				if (x5a4005b11b247c4d.x64a6cd26be484095 + 3 <= xed4a7b1500064e12.Length - (xc7a1ff40f60e5ecf - 1) && x0d299f323d241756.x90637a473b1ceaaa(xed4a7b1500064e12.Substring(xc7a1ff40f60e5ecf - 1, x5a4005b11b247c4d.x64a6cd26be484095 + 2), "</" + x5a4005b11b247c4d.x759aa16c2016a289))
				{
					int num2 = xed4a7b1500064e12[xc7a1ff40f60e5ecf - 1 + 2 + x5a4005b11b247c4d.x759aa16c2016a289.Length];
					if (num2 == 62 || x6c589c7857d7d8d9(num2))
					{
						x9d6b37cac59aa2e2 x9d6b37cac59aa2e3 = x9a3cd5964e27b158(x8be2136363630db4.xf9ad6fb78355fe13, x5a4005b11b247c4d.x2da03f24ec312444 + x5a4005b11b247c4d.xd14e6592dcabf708);
						x9d6b37cac59aa2e3.xd14e6592dcabf708 = xc7a1ff40f60e5ecf - 1 - x9d6b37cac59aa2e3.x2da03f24ec312444;
						x5a4005b11b247c4d.x7b7a6766ca5eec6e(x9d6b37cac59aa2e3);
						x924923c3e0a0a23b(x8be2136363630db4.x2dcc7207ee287dbb, xc7a1ff40f60e5ecf - 1);
						x181795112161a98c(x68ee3ac086332950: false, xc7a1ff40f60e5ecf - 1 + 2);
						x9b529da35d1032aa = x5bbb627fd202d40c.xd229d86af0f16fb0;
						xc7a1ff40f60e5ecf++;
					}
				}
				break;
			}
		}
		if (x5a4005b11b247c4d.xb7073a34e062543e > 0)
		{
			x3d07603fd853dff0(xc7a1ff40f60e5ecf);
		}
		x79e9f8d17bf653c5(xc7a1ff40f60e5ecf, xeb1688f3c25edfc6: false);
		xe6fe0fdeb463a333.Clear();
	}

	private bool xc2ca8c3dd3eb5ab2()
	{
		if (x6d0df3179ab204fc != '<')
		{
			return false;
		}
		if (xc7a1ff40f60e5ecf < xed4a7b1500064e12.Length)
		{
			if (xed4a7b1500064e12[xc7a1ff40f60e5ecf] == '%')
			{
				switch (x9b529da35d1032aa)
				{
				case x5bbb627fd202d40c.x29eeea42f36c9c0f:
					x75272c379f8194f2(xc7a1ff40f60e5ecf - 1);
					break;
				case x5bbb627fd202d40c.x8272b224c765818e:
					x95c6b771b71d3e8e(xc7a1ff40f60e5ecf - 1);
					break;
				case x5bbb627fd202d40c.x20abfbb300452b94:
					x181795112161a98c(x68ee3ac086332950: true, xc7a1ff40f60e5ecf - 1);
					x9b529da35d1032aa = x5bbb627fd202d40c.xd229d86af0f16fb0;
					break;
				}
				x64807174df32bf8c = x9b529da35d1032aa;
				x9b529da35d1032aa = x5bbb627fd202d40c.xd68b587e1c130afd;
				return true;
			}
			if (xed4a7b1500064e12[xc7a1ff40f60e5ecf] == ' ')
			{
				return true;
			}
		}
		if (!x79e9f8d17bf653c5(xc7a1ff40f60e5ecf - 1, xeb1688f3c25edfc6: true))
		{
			xc7a1ff40f60e5ecf = xed4a7b1500064e12.Length;
			return true;
		}
		x9b529da35d1032aa = x5bbb627fd202d40c.x20abfbb300452b94;
		if (xc7a1ff40f60e5ecf - 1 <= xed4a7b1500064e12.Length - 2 && xed4a7b1500064e12[xc7a1ff40f60e5ecf] == '!')
		{
			x924923c3e0a0a23b(x8be2136363630db4.x937e050c63ea1527, xc7a1ff40f60e5ecf - 1);
			x181795112161a98c(x68ee3ac086332950: true, xc7a1ff40f60e5ecf);
			x3d07603fd853dff0(xc7a1ff40f60e5ecf + 1);
			x9b529da35d1032aa = x5bbb627fd202d40c.x937e050c63ea1527;
			if (xc7a1ff40f60e5ecf < xed4a7b1500064e12.Length - 2)
			{
				if (xed4a7b1500064e12[xc7a1ff40f60e5ecf + 1] == '-' && xed4a7b1500064e12[xc7a1ff40f60e5ecf + 2] == '-')
				{
					x5ee9dd273d9a1457 = true;
				}
				else
				{
					x5ee9dd273d9a1457 = false;
				}
			}
			return true;
		}
		x924923c3e0a0a23b(x8be2136363630db4.x2dcc7207ee287dbb, xc7a1ff40f60e5ecf - 1);
		return true;
	}

	private void x95c6b771b71d3e8e(int xc0c4c459c6ccbd00)
	{
		x10cdb594c621057e = new xb5db1aec26ffbd5e(this);
		x10cdb594c621057e.xb7073a34e062543e = xc0c4c459c6ccbd00;
	}

	private void xf3ebed69fe3491bb(int xc0c4c459c6ccbd00)
	{
		x10cdb594c621057e.x64a6cd26be484095 = xc0c4c459c6ccbd00 - x10cdb594c621057e.xb7073a34e062543e;
		x5a4005b11b247c4d.xf9ca4ea3f3bfac5b.x917b69030691beda(x10cdb594c621057e);
	}

	private void x75272c379f8194f2(int xc0c4c459c6ccbd00)
	{
		x10cdb594c621057e.x9a3f9338e6bd436b = xc0c4c459c6ccbd00;
	}

	private void x3b1ebc010e7bfa7e(int xc0c4c459c6ccbd00)
	{
		x10cdb594c621057e.x85cb92159e6a9496 = xc0c4c459c6ccbd00 - x10cdb594c621057e.x9a3f9338e6bd436b;
	}

	private void x924923c3e0a0a23b(x8be2136363630db4 x43163d22e8cd5a71, int xc0c4c459c6ccbd00)
	{
		x5a4005b11b247c4d = x9a3cd5964e27b158(x43163d22e8cd5a71, xc0c4c459c6ccbd00);
		x5a4005b11b247c4d.x6043aa7b1bd39ea9 = xc0c4c459c6ccbd00;
	}

	private bool x79e9f8d17bf653c5(int xc0c4c459c6ccbd00, bool xeb1688f3c25edfc6)
	{
		x5a4005b11b247c4d.xd14e6592dcabf708 = xc0c4c459c6ccbd00 - x5a4005b11b247c4d.x2da03f24ec312444;
		if (x5a4005b11b247c4d.x0eb6f6a44184311b == x8be2136363630db4.xf9ad6fb78355fe13 || x5a4005b11b247c4d.x0eb6f6a44184311b == x8be2136363630db4.x937e050c63ea1527)
		{
			if (x5a4005b11b247c4d.xd14e6592dcabf708 > 0)
			{
				x5a4005b11b247c4d.x91c3e0e7013350f3 = x5a4005b11b247c4d.xd14e6592dcabf708;
				x5a4005b11b247c4d.x62d429bbdde9ec70 = x5a4005b11b247c4d.x2da03f24ec312444;
				if (x4e9bf513f3fd7c01 != null)
				{
					x4e9bf513f3fd7c01.x7b7a6766ca5eec6e(x5a4005b11b247c4d);
				}
			}
		}
		else if (x5a4005b11b247c4d.xb96b4386d9f54db6 && x4e9bf513f3fd7c01 != x5a4005b11b247c4d)
		{
			if (x4e9bf513f3fd7c01 != null)
			{
				x4e9bf513f3fd7c01.x7b7a6766ca5eec6e(x5a4005b11b247c4d);
			}
			x9d6b37cac59aa2e2 xf70a35a67164d = (x9d6b37cac59aa2e2)xe6fe0fdeb463a333[x5a4005b11b247c4d.x759aa16c2016a289];
			x5a4005b11b247c4d.xf70a35a67164d329 = xf70a35a67164d;
			xe6fe0fdeb463a333[x5a4005b11b247c4d.x759aa16c2016a289] = x5a4005b11b247c4d;
			if (x5a4005b11b247c4d.x1b809103b90e9c4f == x8be2136363630db4.x2c8c6741422a1298 || x5a4005b11b247c4d.x1b809103b90e9c4f == x8be2136363630db4.x2dcc7207ee287dbb)
			{
				x4e9bf513f3fd7c01 = x5a4005b11b247c4d;
			}
			if (x9d6b37cac59aa2e2.x23c2824013b425d4(x5a4005b11b247c4d.x759aa16c2016a289))
			{
				x9b529da35d1032aa = x5bbb627fd202d40c.xf27706f4cef15dde;
				return true;
			}
			if (x9d6b37cac59aa2e2.x8ffab91b57c552e6(x5a4005b11b247c4d.x759aa16c2016a289) || x9d6b37cac59aa2e2.x03f0124d771d307a(x5a4005b11b247c4d.x759aa16c2016a289))
			{
				xeb1688f3c25edfc6 = true;
			}
		}
		if (xeb1688f3c25edfc6 || !x5a4005b11b247c4d.xb96b4386d9f54db6)
		{
			x46539717b432bc01();
		}
		return true;
	}

	private void x181795112161a98c(bool x68ee3ac086332950, int xc0c4c459c6ccbd00)
	{
		x5a4005b11b247c4d.xb96b4386d9f54db6 = x68ee3ac086332950;
		x5a4005b11b247c4d.xb7073a34e062543e = xc0c4c459c6ccbd00;
	}

	private static string[] xb663c27d3059fe59(string xc15bd84e01929885)
	{
		return ((xb893565b7e4116c7)x4ebe353021fb0790[xc15bd84e01929885])?.x1570ceda15ab6627;
	}

	private void x04c4c925c4dd29ca()
	{
		if (!x5a4005b11b247c4d.xb96b4386d9f54db6)
		{
			return;
		}
		string x759aa16c2016a = x5a4005b11b247c4d.x759aa16c2016a289;
		xb893565b7e4116c7 xb893565b7e4116c8 = (xb893565b7e4116c7)x4ebe353021fb0790[x759aa16c2016a];
		if (xb893565b7e4116c8 == null)
		{
			return;
		}
		string[] x8d870d6b1e54a = xb893565b7e4116c8.x8d870d6b1e54a188;
		foreach (string key in x8d870d6b1e54a)
		{
			x9d6b37cac59aa2e2 x9d6b37cac59aa2e3 = (x9d6b37cac59aa2e2)xe6fe0fdeb463a333[key];
			if (x9d6b37cac59aa2e3 != null && !x9d6b37cac59aa2e3.x289bf94a509dd84c && !x9b56e645588a563c(x9d6b37cac59aa2e3, xb893565b7e4116c8.x1570ceda15ab6627))
			{
				x9d6b37cac59aa2e2 x9d6b37cac59aa2e4 = new x9d6b37cac59aa2e2(x9d6b37cac59aa2e3.x1b809103b90e9c4f, this, -1);
				x9d6b37cac59aa2e4.x827dc2ed8a939771 = x9d6b37cac59aa2e4;
				x9d6b37cac59aa2e3.x4affc55a82c0dc76(x9d6b37cac59aa2e4);
			}
		}
	}

	private bool x9b56e645588a563c(x9d6b37cac59aa2e2 xda5bf54deb817e37, string[] xf1992da7aa363514)
	{
		if (xf1992da7aa363514 != null)
		{
			for (int i = 0; i < xf1992da7aa363514.Length; i++)
			{
				if (x2b66e009d9d7f6af(xda5bf54deb817e37, xf1992da7aa363514[i]) != null)
				{
					return true;
				}
			}
		}
		return false;
	}

	private x9d6b37cac59aa2e2 x2b66e009d9d7f6af(x9d6b37cac59aa2e2 xda5bf54deb817e37, string xc15bd84e01929885)
	{
		x9d6b37cac59aa2e2 x9d6b37cac59aa2e3 = (x9d6b37cac59aa2e2)xe6fe0fdeb463a333[xc15bd84e01929885];
		if (x9d6b37cac59aa2e3 == null)
		{
			return null;
		}
		if (x9d6b37cac59aa2e3.x289bf94a509dd84c)
		{
			return null;
		}
		if (x9d6b37cac59aa2e3.x6043aa7b1bd39ea9 < xda5bf54deb817e37.x6043aa7b1bd39ea9)
		{
			return null;
		}
		return x9d6b37cac59aa2e3;
	}

	private void x3d07603fd853dff0(int xc0c4c459c6ccbd00)
	{
		x5a4005b11b247c4d.x64a6cd26be484095 = xc0c4c459c6ccbd00 - x5a4005b11b247c4d.xb7073a34e062543e;
		x04c4c925c4dd29ca();
	}

	private void x46539717b432bc01()
	{
		if (x5a4005b11b247c4d.x289bf94a509dd84c)
		{
			return;
		}
		bool flag = false;
		x9d6b37cac59aa2e2 x9d6b37cac59aa2e3 = (x9d6b37cac59aa2e2)xe6fe0fdeb463a333[x5a4005b11b247c4d.x759aa16c2016a289];
		if (x9d6b37cac59aa2e3 == null)
		{
			if (x9d6b37cac59aa2e2.x8ffab91b57c552e6(x5a4005b11b247c4d.x759aa16c2016a289))
			{
				x5a4005b11b247c4d.x4affc55a82c0dc76(x5a4005b11b247c4d);
				if (x4e9bf513f3fd7c01 != null)
				{
					x9d6b37cac59aa2e2 x9d6b37cac59aa2e4 = null;
					Stack stack = new Stack();
					for (x9d6b37cac59aa2e2 x9d6b37cac59aa2e5 = x4e9bf513f3fd7c01.x1f63ab34d720cabb; x9d6b37cac59aa2e5 != null; x9d6b37cac59aa2e5 = x9d6b37cac59aa2e5.x1f3ed48ef81a3a47)
					{
						if (x9d6b37cac59aa2e5.x759aa16c2016a289 == x5a4005b11b247c4d.x759aa16c2016a289 && !x9d6b37cac59aa2e5.x024a13cfae9ff232)
						{
							x9d6b37cac59aa2e4 = x9d6b37cac59aa2e5;
							break;
						}
						stack.Push(x9d6b37cac59aa2e5);
					}
					if (x9d6b37cac59aa2e4 != null)
					{
						while (stack.Count != 0)
						{
							x9d6b37cac59aa2e2 x9d6b37cac59aa2e6 = (x9d6b37cac59aa2e2)stack.Pop();
							x4e9bf513f3fd7c01.xb8020fa26cf32505(x9d6b37cac59aa2e6);
							x9d6b37cac59aa2e4.x7b7a6766ca5eec6e(x9d6b37cac59aa2e6);
						}
					}
					else
					{
						x4e9bf513f3fd7c01.x7b7a6766ca5eec6e(x5a4005b11b247c4d);
					}
				}
			}
		}
		else
		{
			flag = x9b56e645588a563c(x9d6b37cac59aa2e3, xb663c27d3059fe59(x5a4005b11b247c4d.x759aa16c2016a289));
			if (!flag)
			{
				xe6fe0fdeb463a333[x5a4005b11b247c4d.x759aa16c2016a289] = x9d6b37cac59aa2e3.xf70a35a67164d329;
				x9d6b37cac59aa2e3.x4affc55a82c0dc76(x5a4005b11b247c4d);
			}
		}
		if (!flag && x4e9bf513f3fd7c01 != null && (!x9d6b37cac59aa2e2.x8ffab91b57c552e6(x5a4005b11b247c4d.x759aa16c2016a289) || x5a4005b11b247c4d.xb96b4386d9f54db6))
		{
			x0b1695341955fd92();
		}
	}

	internal void x0b1695341955fd92()
	{
		do
		{
			if (x4e9bf513f3fd7c01.x289bf94a509dd84c)
			{
				x4e9bf513f3fd7c01 = x4e9bf513f3fd7c01.xc2cedc613dfc915b;
			}
		}
		while (x4e9bf513f3fd7c01 != null && x4e9bf513f3fd7c01.x289bf94a509dd84c);
		if (x4e9bf513f3fd7c01 == null)
		{
			x4e9bf513f3fd7c01 = x10e05a35f37660c5;
		}
	}

	internal static bool x6c589c7857d7d8d9(int x3c4da2980d043c95)
	{
		if (x3c4da2980d043c95 != 10 && x3c4da2980d043c95 != 13 && x3c4da2980d043c95 != 32)
		{
			return x3c4da2980d043c95 == 9;
		}
		return true;
	}

	internal x9d6b37cac59aa2e2 x978112238435bc70(string xe543a91e86aaeb92)
	{
		return x6f237da4f0680f1d(x154bf1cc56c06b95, xe543a91e86aaeb92);
	}

	private static x9d6b37cac59aa2e2 x6f237da4f0680f1d(x9d6b37cac59aa2e2 x3bd62873fafa6252, string xe543a91e86aaeb92)
	{
		if (x3bd62873fafa6252.x759aa16c2016a289 == xe543a91e86aaeb92)
		{
			return x3bd62873fafa6252;
		}
		foreach (x9d6b37cac59aa2e2 item in (IEnumerable)x3bd62873fafa6252.x8898b61a98eb027f)
		{
			x9d6b37cac59aa2e2 x9d6b37cac59aa2e3 = x6f237da4f0680f1d(item, xe543a91e86aaeb92);
			if (x9d6b37cac59aa2e3 != null)
			{
				return x9d6b37cac59aa2e3;
			}
		}
		return null;
	}
}
