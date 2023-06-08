using System;
using Aspose.Words.Lists;
using x13f1efc79617a47b;
using x28925c9b27b37a46;

namespace Aspose.Words;

public class ListFormat
{
	private readonly xac4d96a62eaba39e xc454c03c23d4b4d9;

	private readonly ListCollection xbc2e79ef0cee7243;

	public int ListLevelNumber
	{
		get
		{
			return (int)xc454c03c23d4b4d9.xc3cc338a59c5293b(1110);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1110, value);
		}
	}

	public bool IsListItem => x71c63f7e57f7ede5 != 0;

	public List List
	{
		get
		{
			int num = x71c63f7e57f7ede5;
			if (num == 0)
			{
				return null;
			}
			return xbc2e79ef0cee7243.x6c3daa8c787e54bf(num);
		}
		set
		{
			if (value == null)
			{
				x71c63f7e57f7ede5 = 0;
				ListLevelNumber = 0;
				return;
			}
			if (value.Document != xbc2e79ef0cee7243.Document)
			{
				throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hjbfikifckpfkfggdkngnjeheklhckcilejikiajkihjoiojoifkkimkaidljiklddbmeiimmhpmkcgnignneceofglohgcpbgjpofaakfhaegoaeffbkfmbnfdcgakchebdpeidaepdpegeeenejdefpdlfcecgjpig", 1677807939)));
			}
			if (value.IsListStyleDefinition)
			{
				throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kmmplndafnkanibbgnibanpbhngcfnncohedemldlmcefhjedlafpghfalofokfgmkmgmkdhokkhgkbiokiiakpidkgjpjnjoeekkjlkoiclfejldiampdhmiiomcifnjimnhidoadkoaibpohipaippahgaggnamceb", 104660086)));
			}
			x71c63f7e57f7ede5 = value.ListId;
		}
	}

	public ListLevel ListLevel => List?.x1fc16b41653eb571(ListLevelNumber);

	internal int x71c63f7e57f7ede5
	{
		get
		{
			return (int)xc454c03c23d4b4d9.xc3cc338a59c5293b(1120);
		}
		set
		{
			xc454c03c23d4b4d9.xb6157b6da9895c0d(1120, value);
		}
	}

	internal ListFormat(xac4d96a62eaba39e parent, ListCollection lists)
	{
		xc454c03c23d4b4d9 = parent;
		xbc2e79ef0cee7243 = lists;
	}

	public void ApplyBulletDefault()
	{
		x71c63f7e57f7ede5 = xbc2e79ef0cee7243.Add(ListTemplate.BulletDefault).ListId;
		ListLevelNumber = 0;
	}

	public void ApplyNumberDefault()
	{
		x71c63f7e57f7ede5 = xbc2e79ef0cee7243.Add(ListTemplate.NumberDefault).ListId;
		ListLevelNumber = 0;
	}

	public void RemoveNumbers()
	{
		List = null;
	}

	public void ListIndent()
	{
		if (ListLevelNumber < 8)
		{
			ListLevelNumber++;
		}
	}

	public void ListOutdent()
	{
		if (ListLevelNumber > 0)
		{
			ListLevelNumber--;
		}
	}
}
