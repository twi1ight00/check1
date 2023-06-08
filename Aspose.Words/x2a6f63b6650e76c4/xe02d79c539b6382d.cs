using System.Text.RegularExpressions;
using Aspose.Words.Tables;
using x28925c9b27b37a46;
using xf9a9481c3f63a419;

namespace x2a6f63b6650e76c4;

internal class xe02d79c539b6382d
{
	private const string x2ae6b945ff6ef0e0 = "!Invalid column name.";

	private readonly Table x0f62a530ebbd1b7d;

	private int x9c8e465a79bff887;

	private int xe55137f2e976e51a;

	private static readonly Regex xaa72f034566b2295 = new Regex("([A-Z]+)?(\\d+)?", RegexOptions.IgnoreCase);

	internal Cell x11db8fc7f469a2fc => x0f62a530ebbd1b7d.xfeb19f1007c0b581(x9c8e465a79bff887, xe55137f2e976e51a);

	internal bool x22ab5dfa6f12e902 => x396403486c793a6b(xe55137f2e976e51a, x9c8e465a79bff887);

	internal bool xe27d24f5402f718b => x9c8e465a79bff887 == 0;

	internal bool xc95e2772f13b118e => xe55137f2e976e51a == 0;

	internal bool xe827bb03048c257c => x9c8e465a79bff887 == x0f62a530ebbd1b7d.Rows[xe55137f2e976e51a].Cells.Count - 1;

	internal bool x68c5cc3196e669be => xe55137f2e976e51a == x0f62a530ebbd1b7d.Rows.Count - 1;

	internal int x59bc0096de497989
	{
		get
		{
			return x9c8e465a79bff887;
		}
		set
		{
			x9c8e465a79bff887 = value;
		}
	}

	internal int x9b1baea4e485d168
	{
		get
		{
			return xe55137f2e976e51a;
		}
		set
		{
			xe55137f2e976e51a = value;
		}
	}

	internal xe02d79c539b6382d(Cell cell)
		: this(cell.x133f2db9e5b5690d, cell.x59bc0096de497989, cell.x9b1baea4e485d168)
	{
	}

	internal xe02d79c539b6382d(Table table, int columnIndex, int rowIndex)
	{
		x0f62a530ebbd1b7d = table;
		x9c8e465a79bff887 = columnIndex;
		xe55137f2e976e51a = rowIndex;
	}

	internal static xe02d79c539b6382d x1f490eac106aee12(Table x1ec770899c98a268, string xc15bd84e01929885, int x2238fe9b8f06bd9d)
	{
		Match match = xaa72f034566b2295.Match(xc15bd84e01929885);
		Group group = match.Groups[1];
		Group group2 = match.Groups[2];
		if (group.Success && group2.Success)
		{
			return new xe02d79c539b6382d(x1ec770899c98a268, x00b47748a95c9437.xcd4c71cf08e97198(group.Value), xca004f56614e2431.xa93402510be8434e(group2.Value) - 1);
		}
		if (group.Success)
		{
			return new xe02d79c539b6382d(x1ec770899c98a268, x00b47748a95c9437.xcd4c71cf08e97198(group.Value), x2238fe9b8f06bd9d);
		}
		return new xe02d79c539b6382d(x1ec770899c98a268, x2238fe9b8f06bd9d, xca004f56614e2431.xa93402510be8434e(group2.Value) - 1);
	}

	internal static bool xb24b74b10625a017(xe02d79c539b6382d xf105a51d88d5c155, xe02d79c539b6382d xf3413e78bf2f4469)
	{
		if (xf105a51d88d5c155.x59bc0096de497989 == xf3413e78bf2f4469.x59bc0096de497989)
		{
			return xf105a51d88d5c155.x9b1baea4e485d168 == xf3413e78bf2f4469.x9b1baea4e485d168;
		}
		return false;
	}

	internal xe02d79c539b6382d x8b61531c8ea35b85()
	{
		return (xe02d79c539b6382d)MemberwiseClone();
	}

	public override string ToString()
	{
		string text = x00b47748a95c9437.x6a1f74b85bf16c63(x9c8e465a79bff887);
		if (text == null)
		{
			text = "!Invalid column name.";
		}
		return $"{text}{xe55137f2e976e51a + 1}";
	}

	internal bool xa53526a8e4a7b443(int x5a231e160d743567)
	{
		if (x9c8e465a79bff887 < 0)
		{
			return false;
		}
		int xbeb0e74fd1e3aefb = x9c8e465a79bff887 + x5a231e160d743567;
		bool flag = x396403486c793a6b(xe55137f2e976e51a, xbeb0e74fd1e3aefb);
		if (flag)
		{
			x9c8e465a79bff887 = xbeb0e74fd1e3aefb;
		}
		return flag;
	}

	internal bool x6f0363886d340825(int x5a231e160d743567)
	{
		if (x9c8e465a79bff887 < 0)
		{
			return false;
		}
		int x78a7603cacf2ae = xe55137f2e976e51a + x5a231e160d743567;
		bool flag = x88660554cdbc3289(x78a7603cacf2ae);
		if (flag)
		{
			xe55137f2e976e51a = x78a7603cacf2ae;
		}
		return flag;
	}

	private bool x88660554cdbc3289(int x78a7603cacf2ae22)
	{
		if (0 <= x78a7603cacf2ae22)
		{
			return x78a7603cacf2ae22 < x0f62a530ebbd1b7d.Rows.Count;
		}
		return false;
	}

	private bool x396403486c793a6b(int x78a7603cacf2ae22, int xbeb0e74fd1e3aefb)
	{
		if (x88660554cdbc3289(x78a7603cacf2ae22) && 0 <= xbeb0e74fd1e3aefb)
		{
			return xbeb0e74fd1e3aefb < x0f62a530ebbd1b7d.Rows[x78a7603cacf2ae22].Cells.Count;
		}
		return false;
	}
}
