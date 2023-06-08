using System;
using System.Text.RegularExpressions;
using Aspose.Words;
using x13f1efc79617a47b;

namespace x28925c9b27b37a46;

internal class xd71a3da4fdc6d210
{
	private static readonly char[] xbef55fa66167f659 = new char[10] { '\u0001', '\u0002', '\u0003', '\u0004', '\a', '\f', '\r', '\u0013', '\u0014', '\u0015' };

	private static readonly char[] x03b50b486a69116a = new char[9] { '\u0001', '\u0002', '\u0003', '\u0004', '\a', '\r', '\u0013', '\u0014', '\u0015' };

	private Node x1ceb6cc9352d809d;

	private Regex x0682fb25c52df292;

	private string x5b8550bbc6fc02cf;

	private IReplacingCallback xf468985d28e07e8a;

	private bool x7954f588969b8289;

	internal Node xa121174cdba0be65
	{
		get
		{
			return x1ceb6cc9352d809d;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			x1ceb6cc9352d809d = value;
		}
	}

	internal Regex xd265a220a45d3124
	{
		get
		{
			return x0682fb25c52df292;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (value.ToString() == "")
			{
				throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("oppjpahkjaokbmelbbmlaadmjpjmhabnfphnhponmkfompmokpdpfpkpjobaloiabopahjgbhnnbcnecmnlcjncdhnjdjnaecihebmoebmffjhmflldgamkgambhbmihdmphfhgi", 1547280298)));
			}
			x0682fb25c52df292 = value;
		}
	}

	internal string xa5e4fbbb5f8203fa
	{
		get
		{
			return x5b8550bbc6fc02cf;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (value.IndexOfAny(x03b50b486a69116a) != -1)
			{
				throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("oodappkajpbbblibaaacapgcipncbpeddoldcocebojejjafjohfhoofcofggnmgindhomkheibiemiiplpijmgjgmnjemekgmlkpgclpkjlilamelhmhlombkfngkmnikdohfkohkbpbkipdjppoigabjnagieboilbpdcclijcliadgdhdfhodcifechmelgdfchkfecbgegigggpgmfghkgnhgfeifflidgcjbfjjlfakjfhkbbok", 530187162)));
			}
			x5b8550bbc6fc02cf = value;
		}
	}

	internal IReplacingCallback xa9afcd06a67ca96d
	{
		get
		{
			return xf468985d28e07e8a;
		}
		set
		{
			xf468985d28e07e8a = value;
		}
	}

	internal bool xbcb605462e4830f8
	{
		get
		{
			return x7954f588969b8289;
		}
		set
		{
			x7954f588969b8289 = value;
		}
	}

	internal xd71a3da4fdc6d210(Node rootNode, Regex pattern, string replacement, IReplacingCallback handler, bool isForward)
	{
		xa121174cdba0be65 = rootNode;
		xd265a220a45d3124 = pattern;
		xa5e4fbbb5f8203fa = replacement;
		xa9afcd06a67ca96d = handler;
		xbcb605462e4830f8 = isForward;
	}

	internal xd71a3da4fdc6d210(Node rootNode, string oldValue, string newValue, bool isMatchCase, bool isMatchWholeWord)
		: this(rootNode, x9bdf498a405310ba(oldValue, isMatchCase, isMatchWholeWord), newValue, null, isForward: false)
	{
	}

	internal int x57bf52bb3d1c2d43()
	{
		MatchCollection matchCollection = x0682fb25c52df292.Matches(x1ceb6cc9352d809d.GetText());
		int num = 0;
		int num2 = matchCollection.Count;
		int num3 = (x7954f588969b8289 ? 1 : (-1));
		int num4 = ((!x7954f588969b8289) ? (matchCollection.Count - 1) : 0);
		int num5 = 0;
		while (num2 > 0)
		{
			Match match = matchCollection[num4];
			if (match.Length > 0)
			{
				int num6 = x1ceb6cc9352d809d.x22e0084ce6e1ab9a() + match.Index + num5;
				Node node = x1ceb6cc9352d809d.x42ef18de02ad5182(num6);
				int matchOffset = num6 - node.x22e0084ce6e1ab9a();
				ReplacingArgs replacingArgs = new ReplacingArgs(match, node, matchOffset, x5b8550bbc6fc02cf);
				switch ((xf468985d28e07e8a != null) ? xf468985d28e07e8a.Replacing(replacingArgs) : ReplaceAction.Replace)
				{
				case ReplaceAction.Replace:
				{
					int num7 = xcb3b6d66f24adc5d(replacingArgs);
					if (x7954f588969b8289)
					{
						num5 += num7;
					}
					num++;
					break;
				}
				case ReplaceAction.Stop:
					return num;
				default:
					throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lfnabheblglblgccjgjcogadcghdbbodagfeafmeifdfbfkfdebgceigbepgjpfhhdnhgdeieeligdcjjdjjfdakcpgk", 1710034182)));
				case ReplaceAction.Skip:
					break;
				}
			}
			num4 += num3;
			num2--;
		}
		return num;
	}

	private int xcb3b6d66f24adc5d(ReplacingArgs xce8d8c7e3c2c2426)
	{
		Group group = ((xce8d8c7e3c2c2426.GroupName == null) ? xce8d8c7e3c2c2426.Match.Groups[xce8d8c7e3c2c2426.GroupIndex] : xce8d8c7e3c2c2426.Match.Groups[xce8d8c7e3c2c2426.GroupName]);
		if (group.Value.IndexOfAny(xbef55fa66167f659) != -1)
		{
			throw new NotSupportedException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jdifkepfeeggmpmggeehhdlhheciddjifdajkogjadojcdfkecmkkcdladklmbbmkbimfcpmpmfnlbnnhbeolalodmbppajppaaaklgaeaoadafbdambdpcclkjclpadfphdhoodcofefomekndfcokfdjbgpnigpnpgkighjmnhgneigmliplcjgmjjihakilhkklokalflolmlkkdmjkkmhlbnfkinpkpnnkgohfnofjeppjlpcjcalejaliabgihbajobnifclimcniddgdkdfhbefhiencpemhgfmgnfehegnglgpfchofjhnfaijfhiacoi", 1858623461)));
		}
		Run run = (Run)xce8d8c7e3c2c2426.MatchNode;
		int num = group.Length;
		int num2 = xce8d8c7e3c2c2426.MatchOffset;
		Run run2 = run;
		while (num > 0)
		{
			int val = run2.x2e39a445d52f6ea8() - num2;
			int num3 = Math.Min(val, num);
			run2.Text = run2.Text.Remove(num2, num3);
			num -= num3;
			num2 = 0;
			Node node = run2;
			do
			{
				node = node.NextPreOrder(x1ceb6cc9352d809d);
			}
			while (node != null && node.NodeType != NodeType.Run);
			if (run2 != run && run2.Text == "")
			{
				run2.Remove();
			}
			run2 = (Run)node;
		}
		run.Text = run.Text.Insert(xce8d8c7e3c2c2426.MatchOffset, xce8d8c7e3c2c2426.Replacement);
		if (run.Text == "")
		{
			run.Remove();
		}
		return xce8d8c7e3c2c2426.Replacement.Length - group.Length;
	}

	private static Regex x9bdf498a405310ba(string x82cc274dec6f4f4c, bool x0048240fdfd0e923, bool xa712131b0e8f56bd)
	{
		string text = Regex.Escape(x82cc274dec6f4f4c);
		if (xa712131b0e8f56bd)
		{
			text = "\\b" + text + "\\b";
		}
		RegexOptions options = ((!x0048240fdfd0e923) ? RegexOptions.IgnoreCase : RegexOptions.None);
		return new Regex(text, options);
	}
}
