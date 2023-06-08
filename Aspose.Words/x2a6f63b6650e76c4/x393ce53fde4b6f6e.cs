using System.Collections;
using System.Text.RegularExpressions;
using Aspose.Words;
using Aspose.Words.Tables;

namespace x2a6f63b6650e76c4;

internal class x393ce53fde4b6f6e : x209f3e4a2f735d1e, IEnumerable
{
	private class x24541fc7c4da49fa : IEnumerator
	{
		private readonly x209f3e4a2f735d1e x4517c2b411ea1d52;

		private xe02d79c539b6382d xc83d0e6d4611cafd;

		private bool xd76986098a24fd8c;

		public object Current
		{
			get
			{
				if (!xd76986098a24fd8c)
				{
					return null;
				}
				return xc83d0e6d4611cafd.x11db8fc7f469a2fc;
			}
		}

		internal x24541fc7c4da49fa(x209f3e4a2f735d1e range)
		{
			x4517c2b411ea1d52 = range;
		}

		public bool MoveNext()
		{
			bool flag;
			if (xd76986098a24fd8c)
			{
				flag = xc83d0e6d4611cafd.xa53526a8e4a7b443(1);
			}
			else
			{
				xd76986098a24fd8c = true;
				xc83d0e6d4611cafd = x4517c2b411ea1d52.x12cb12b5d2cad53d.x8b61531c8ea35b85();
				flag = xc83d0e6d4611cafd.x22ab5dfa6f12e902;
			}
			if (flag && xc83d0e6d4611cafd.x59bc0096de497989 <= x4517c2b411ea1d52.x9fd888e65466818c.x59bc0096de497989)
			{
				return true;
			}
			xc83d0e6d4611cafd.x59bc0096de497989 = 0;
			while (xc83d0e6d4611cafd.x6f0363886d340825(1) && xc83d0e6d4611cafd.x9b1baea4e485d168 <= x4517c2b411ea1d52.x9fd888e65466818c.x9b1baea4e485d168)
			{
				if (xc83d0e6d4611cafd.xa53526a8e4a7b443(x4517c2b411ea1d52.x12cb12b5d2cad53d.x59bc0096de497989))
				{
					return true;
				}
			}
			return false;
		}

		public void Reset()
		{
			xd76986098a24fd8c = false;
		}
	}

	private const int x80567318e63fbba7 = 2;

	private const int xee31db43f1f6ad54 = 4;

	private const int x740658abc4af6bc4 = 5;

	private const int x674408f6e4b5e79f = 6;

	private const int xde6bc57367669171 = 7;

	private readonly xe02d79c539b6382d x212ae880d15d2ed1;

	private readonly xe02d79c539b6382d xb664a8c25c0c85cc;

	private static readonly Regex x8d0080837d5fdbfa = new Regex("^((\\w+)\\s+)?(([A-Z]+\\d+)|(([A-Z]+|\\d+|[A-Z]+\\d+):([A-Z]+|\\d+|[A-Z]+\\d+)))$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

	bool x209f3e4a2f735d1e.x3b634e1fe06f2a1c => true;

	bool x209f3e4a2f735d1e.x2e39ff7109112d84 => xe02d79c539b6382d.xb24b74b10625a017(x212ae880d15d2ed1, xb664a8c25c0c85cc);

	xe02d79c539b6382d x209f3e4a2f735d1e.x9f8c133ccef2c16c => x212ae880d15d2ed1;

	xe02d79c539b6382d x209f3e4a2f735d1e.x92116d159a362cf8 => xb664a8c25c0c85cc;

	internal x393ce53fde4b6f6e(xe02d79c539b6382d start, xe02d79c539b6382d end)
	{
		x212ae880d15d2ed1 = start;
		xb664a8c25c0c85cc = end;
	}

	internal static x82e26649b09596bd x19890931227f0f56(x12e7545fad3ccc9b x0f7b23d1c393aed9, string xc15bd84e01929885, bool x87e8133a83e97e91, out x209f3e4a2f735d1e x9b10ace6509508c0)
	{
		x9b10ace6509508c0 = null;
		Match match = x8d0080837d5fdbfa.Match(xc15bd84e01929885);
		if (!match.Success)
		{
			return null;
		}
		Table x1ec770899c98a = null;
		Group group = match.Groups[2];
		if (group.Success)
		{
			x82e26649b09596bd x82e26649b09596bd2 = xcd425a1819a8fdf3(x0f7b23d1c393aed9, group.Value, out x1ec770899c98a);
			if (x82e26649b09596bd2 != null)
			{
				return x82e26649b09596bd2;
			}
		}
		Table x1ec770899c98a2;
		if (x1ec770899c98a != null)
		{
			x1ec770899c98a2 = x1ec770899c98a;
		}
		else
		{
			if (x0f7b23d1c393aed9.x133f2db9e5b5690d == null)
			{
				return new xf7d966ea5d1701b6("!The Formula Not In Table");
			}
			x1ec770899c98a2 = x0f7b23d1c393aed9.x133f2db9e5b5690d;
		}
		Group group2 = match.Groups[4];
		if (group2.Success)
		{
			x9b10ace6509508c0 = x1f490eac106aee12(x1ec770899c98a2, group2.Value, group2.Value);
		}
		else if (match.Groups[5].Success)
		{
			x9b10ace6509508c0 = x1f490eac106aee12(x1ec770899c98a2, match.Groups[6].Value, match.Groups[7].Value);
		}
		if (!x87e8133a83e97e91 && !x9b10ace6509508c0.xe519c9d6797c17d9)
		{
			return new xf7d966ea5d1701b6("!Syntax Error");
		}
		return null;
	}

	private static x82e26649b09596bd xcd425a1819a8fdf3(x12e7545fad3ccc9b x0f7b23d1c393aed9, string xd17ec8f278d25c87, out Table x1ec770899c98a268)
	{
		x1ec770899c98a268 = null;
		Bookmark bookmark = x0f7b23d1c393aed9.x2c8c6741422a1298.Range.Bookmarks[xd17ec8f278d25c87];
		if (bookmark == null)
		{
			return new xf7d966ea5d1701b6($"!Undefined Bookmark, {xd17ec8f278d25c87.ToUpper()}");
		}
		Table table = (Table)bookmark.BookmarkStart.GetAncestor(NodeType.Table);
		Table table2 = (Table)bookmark.BookmarkEnd.GetAncestor(NodeType.Table);
		bool flag = table != null;
		if (table2 == null && bookmark.BookmarkEnd.xdfa6ecc6f742f086.PreviousSibling != table)
		{
			return new xf7d966ea5d1701b6($"!{xd17ec8f278d25c87} Is Not In Table");
		}
		if (!flag)
		{
			return new x918e475ee39e3253(0.0);
		}
		x1ec770899c98a268 = table;
		return null;
	}

	private static x209f3e4a2f735d1e x1f490eac106aee12(Table x1ec770899c98a268, string x2998bc0b2545c5b6, string xd58ddfc523d7f291)
	{
		return new x393ce53fde4b6f6e(xe02d79c539b6382d.x1f490eac106aee12(x1ec770899c98a268, x2998bc0b2545c5b6, 0), xe02d79c539b6382d.x1f490eac106aee12(x1ec770899c98a268, xd58ddfc523d7f291, int.MaxValue));
	}

	private IEnumerator x05b0b83b5e6c5de6()
	{
		return new x24541fc7c4da49fa(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x05b0b83b5e6c5de6
		return this.x05b0b83b5e6c5de6();
	}
}
