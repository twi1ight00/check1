using System.Collections.Specialized;
using System.IO;

namespace xa604c4d210ae0581;

internal class xd47c6c7442eb8033
{
	private const string x5d4c3e5600437c2b = "Unknown";

	private readonly StringCollection xcd7a948cd6d6f316;

	internal xd47c6c7442eb8033(x8aeace2bf92692ab fib, BinaryReader reader)
	{
		xcd7a948cd6d6f316 = new StringCollection();
		xaf807f6784ee1743.x06b0e25aa6ad68a9(reader, fib.x955a03f821588c52.x440deb16ce197f30, xcd7a948cd6d6f316);
	}

	internal xd47c6c7442eb8033()
	{
		xcd7a948cd6d6f316 = new StringCollection();
		xcd7a948cd6d6f316.Add("Unknown");
	}

	internal int x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		return xaf807f6784ee1743.x6210059f049f0d48(xbdfb620b7167944b, xcd7a948cd6d6f316);
	}

	internal string x8f3a8caf455fbd75(int x9f442fb6cbea238c)
	{
		if (x9f442fb6cbea238c < 0 || x9f442fb6cbea238c >= xcd7a948cd6d6f316.Count)
		{
			return "Unknown";
		}
		return xcd7a948cd6d6f316[x9f442fb6cbea238c];
	}

	internal int x157cb2cfc16453ee(string x2d101e14c410daec)
	{
		int num = xcd7a948cd6d6f316.IndexOf(x2d101e14c410daec);
		if (num < 0)
		{
			num = x80d06c39c307fd2d(x2d101e14c410daec);
		}
		return num;
	}

	internal int x80d06c39c307fd2d(string x2d101e14c410daec)
	{
		xcd7a948cd6d6f316.Add(x2d101e14c410daec);
		return xcd7a948cd6d6f316.Count - 1;
	}
}
