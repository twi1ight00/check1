using System.Collections.Specialized;
using System.IO;
using x6c95d9cf46ff5f25;
using xa604c4d210ae0581;

namespace xaa035fc640f94856;

internal class x2e009080ad086857
{
	private readonly string x85672ef2a158d360;

	private readonly string x0ac84b8503c3c847;

	private readonly StringCollection x4decc4430f0b7aea = new StringCollection();

	private readonly StringCollection x3755f17ef3f8758a = new StringCollection();

	internal string xb405a444ca77e2d4
	{
		get
		{
			if (!x0d299f323d241756.x5959bccb67bbf051(x85672ef2a158d360))
			{
				return "";
			}
			return x85672ef2a158d360;
		}
	}

	internal string x8441ed6b8afd4b93
	{
		get
		{
			if (!x0d299f323d241756.x5959bccb67bbf051(x0ac84b8503c3c847))
			{
				return "";
			}
			return x0ac84b8503c3c847;
		}
	}

	internal StringCollection x0c560ee4a7223d6d => x4decc4430f0b7aea;

	internal StringCollection xf9ca4ea3f3bfac5b => x3755f17ef3f8758a;

	internal x2e009080ad086857(string uri)
	{
		x85672ef2a158d360 = uri;
	}

	internal x2e009080ad086857(BinaryReader reader)
	{
		x85672ef2a158d360 = x93b05c1ad709a695.x602d3c3fbfa56f51(reader, x5be1cad1d00af914: true, xac1baf51b3e43d13: false);
		x0ac84b8503c3c847 = x93b05c1ad709a695.x602d3c3fbfa56f51(reader, x5be1cad1d00af914: true, xac1baf51b3e43d13: false);
		xaf807f6784ee1743.xe292217eeca8ebc0(reader, x0c560ee4a7223d6d);
		xaf807f6784ee1743.xe292217eeca8ebc0(reader, xf9ca4ea3f3bfac5b);
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		x93b05c1ad709a695.x4a3c44ae9b1cf5ab(xb405a444ca77e2d4, xb405a444ca77e2d4.Length, xbdfb620b7167944b, x5be1cad1d00af914: true, xac1baf51b3e43d13: false);
		x93b05c1ad709a695.x4a3c44ae9b1cf5ab(x8441ed6b8afd4b93, x8441ed6b8afd4b93.Length, xbdfb620b7167944b, x5be1cad1d00af914: true, xac1baf51b3e43d13: false);
		xaf807f6784ee1743.x6210059f049f0d48(xbdfb620b7167944b, x0c560ee4a7223d6d, x4f5b2499ca42a09c: true);
		xaf807f6784ee1743.x6210059f049f0d48(xbdfb620b7167944b, xf9ca4ea3f3bfac5b, x4f5b2499ca42a09c: true);
	}

	internal int x95916107513c13cb(string x4bbc2c453c470189)
	{
		int num = x0c560ee4a7223d6d.IndexOf(x4bbc2c453c470189);
		if (num < 0)
		{
			num = x0c560ee4a7223d6d.Add(x4bbc2c453c470189);
		}
		return num;
	}

	internal int xd67065de3473913f(string x7918156d406a715d)
	{
		int num = xf9ca4ea3f3bfac5b.IndexOf(x7918156d406a715d);
		if (num < 0)
		{
			num = xf9ca4ea3f3bfac5b.Add(x7918156d406a715d);
		}
		return num;
	}
}
