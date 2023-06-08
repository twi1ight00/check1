using System;
using System.Collections;
using System.Reflection;

namespace x556d8f9846e43329;

[DefaultMember("Item")]
internal class xb06fc1bffc8a689b
{
	private ArrayList x7753aae671b04fa1 = new ArrayList();

	internal string xe6d4b1b411ed94b5
	{
		get
		{
			if (xc0c4c459c6ccbd00 >= xd44988f225497f3a)
			{
				return "Unknown";
			}
			return (string)x7753aae671b04fa1[xc0c4c459c6ccbd00];
		}
	}

	internal int xd44988f225497f3a => x7753aae671b04fa1.Count;

	internal xb06fc1bffc8a689b(bool addFirstEntry)
	{
		if (addFirstEntry)
		{
			xd6b6ed77479ef68c("Unknown");
		}
	}

	internal int xd6b6ed77479ef68c(string x984160c7f0248924)
	{
		if (x984160c7f0248924 == null)
		{
			throw new ArgumentNullException("author");
		}
		int num = x7753aae671b04fa1.IndexOf(x984160c7f0248924);
		if (num == -1)
		{
			return x7753aae671b04fa1.Add(x984160c7f0248924);
		}
		return num;
	}
}
