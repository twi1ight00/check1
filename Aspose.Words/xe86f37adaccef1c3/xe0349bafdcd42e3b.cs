using System;
using System.Collections;
using System.Text.RegularExpressions;
using Aspose.Words;

namespace xe86f37adaccef1c3;

internal class xe0349bafdcd42e3b
{
	private class xa9afcd06a67ca96d : IReplacingCallback
	{
		private readonly ArrayList x9a33ed6be91154ac;

		internal xa9afcd06a67ca96d(ArrayList insertPoints)
		{
			x9a33ed6be91154ac = insertPoints;
		}

		public ReplaceAction Replacing(ReplacingArgs args)
		{
			xa45b3dfab841e741 value = new xa45b3dfab841e741((Run)args.MatchNode, args.MatchOffset, args.Match.Length, args.Match.Groups[1].Value);
			x9a33ed6be91154ac.Add(value);
			return ReplaceAction.Skip;
		}
	}

	private class xa45b3dfab841e741
	{
		private readonly Run xea402a4626b70a01;

		private readonly int x53ad16e701d09d01;

		private readonly int x62d9bfcf54e338cb;

		private readonly int x06c4b73077b26be2;

		private readonly string xef87cf0908506c40;

		public Run x38453dde2dc1ee92 => xea402a4626b70a01;

		public int xf1d9b91c9700c401 => x62d9bfcf54e338cb - (x53ad16e701d09d01 - xea402a4626b70a01.Text.Length);

		internal int x21f5d7c0f29b7af1 => x06c4b73077b26be2;

		internal string x7cb8be0bdf4542c6 => xef87cf0908506c40;

		internal xa45b3dfab841e741(Run firstRun, int offset, int tagLength, string tagContent)
		{
			xea402a4626b70a01 = firstRun;
			x53ad16e701d09d01 = firstRun.Text.Length;
			x62d9bfcf54e338cb = offset;
			x06c4b73077b26be2 = tagLength;
			xef87cf0908506c40 = tagContent;
		}
	}

	private const int xd7385d41ddd1b7ad = 1;

	private const string x76d3c76026ce4efc = "#foreach";

	private const string xb21e96564af6e3d5 = "/foreach";

	private const string x0a7c6147fa85b987 = "MERGEFIELD {0}";

	private const string xc5efb91c8c33bedf = "MERGEFIELD TableStart:{0}";

	private const string x6ffd4bbdbeba72c6 = "MERGEFIELD TableEnd:{0}";

	private readonly Document xd1424e1a0bb4a72b;

	private readonly ArrayList x9a33ed6be91154ac = new ArrayList();

	private static readonly Regex xd7f92644457e94cd = new Regex("\\{\\{([^}]+)}}");

	internal xe0349bafdcd42e3b(Document document)
	{
		xd1424e1a0bb4a72b = document;
	}

	internal static void x8f1e2d70dda35215(Document x3664041d21d73fdc)
	{
		xe0349bafdcd42e3b xe0349bafdcd42e3b2 = new xe0349bafdcd42e3b(x3664041d21d73fdc);
		xe0349bafdcd42e3b2.x8f1e2d70dda35215();
	}

	internal void x8f1e2d70dda35215()
	{
		xd1424e1a0bb4a72b.Range.Replace(xd7f92644457e94cd, new xa9afcd06a67ca96d(x9a33ed6be91154ac), isForward: true);
		xa9086fbb00fca7e5();
	}

	private void xa9086fbb00fca7e5()
	{
		DocumentBuilder documentBuilder = new DocumentBuilder(xd1424e1a0bb4a72b);
		foreach (xa45b3dfab841e741 item in x9a33ed6be91154ac)
		{
			Node node = xb395fd3bab560317(item);
			documentBuilder.MoveTo(node);
			documentBuilder.x77184348a27ba1e6(item.x38453dde2dc1ee92.xeedad81aaed42a76, x692ced34f50137f2: true);
			string fieldCode = x5682cf541cbaa08c(item);
			documentBuilder.InsertField(fieldCode, "");
		}
	}

	private string x5682cf541cbaa08c(xa45b3dfab841e741 x2f7096dac971d6ec)
	{
		string text = x2f7096dac971d6ec.x7cb8be0bdf4542c6.Trim();
		if (text.StartsWith("#foreach"))
		{
			return string.Format("MERGEFIELD TableStart:{0}", text.Substring("#foreach".Length).Trim());
		}
		if (text.StartsWith("/foreach"))
		{
			return string.Format("MERGEFIELD TableEnd:{0}", text.Substring("/foreach".Length).Trim());
		}
		return $"MERGEFIELD {text}";
	}

	private Node xb395fd3bab560317(xa45b3dfab841e741 x2f7096dac971d6ec)
	{
		Run x38453dde2dc1ee = x2f7096dac971d6ec.x38453dde2dc1ee92;
		int num = x2f7096dac971d6ec.x21f5d7c0f29b7af1;
		int num2 = x2f7096dac971d6ec.xf1d9b91c9700c401;
		int num3 = ((x38453dde2dc1ee.x2e39a445d52f6ea8() - num2 > num) ? num2 : (-1));
		Run run = x38453dde2dc1ee;
		while (num > 0)
		{
			int val = run.x2e39a445d52f6ea8() - num2;
			int num4 = Math.Min(val, num);
			run.Text = run.Text.Remove(num2, num4);
			num -= num4;
			num2 = 0;
			Node node = run;
			do
			{
				node = node.NextPreOrder(xd1424e1a0bb4a72b);
			}
			while (node != null && node.NodeType != NodeType.Run);
			if (run != x38453dde2dc1ee && run.Text.Length == 0)
			{
				run.Remove();
			}
			run = (Run)node;
		}
		if (num3 != -1)
		{
			x38453dde2dc1ee.x4a406570a6226227(num3);
			return x38453dde2dc1ee;
		}
		if (x2f7096dac971d6ec.xf1d9b91c9700c401 == 0)
		{
			return x38453dde2dc1ee;
		}
		if (x38453dde2dc1ee.NextSibling == null)
		{
			return x38453dde2dc1ee.ParentParagraph;
		}
		return x38453dde2dc1ee.NextSibling;
	}
}
