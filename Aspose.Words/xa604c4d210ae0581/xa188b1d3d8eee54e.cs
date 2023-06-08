using System.Collections;
using Aspose.Words;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace xa604c4d210ae0581;

internal class xa188b1d3d8eee54e
{
	private static readonly Hashtable xead576fba0887340;

	private static readonly Hashtable x1dc4566238993d43;

	private static readonly ArrayList x0b3679d6e4d572a3;

	private xa188b1d3d8eee54e()
	{
	}

	internal static string x7bcd2fb72fb7aae6(int x9035cf16181332fc)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xead576fba0887340, x9035cf16181332fc, "Times New Roman");
	}

	internal static int x04327ff503798cdd(string xc15bd84e01929885)
	{
		return (int)x682712679dbc585a.xce92de628aa023cf(x1dc4566238993d43, xc15bd84e01929885, 0);
	}

	internal static bool xbd743ca2a349e5c4(TableStyle x13eeaa19b4289a25)
	{
		foreach (xe12ab2f55355c7f0 item in x13eeaa19b4289a25.x7205cb42c2f994a4)
		{
			xeedad81aaed42a76 xeedad81aaed42a = item.xeedad81aaed42a76;
			if (xeedad81aaed42a == null)
			{
				continue;
			}
			foreach (int item2 in x0b3679d6e4d572a3)
			{
				if (xeedad81aaed42a.x263d579af1d0d43f(item2) && x682712679dbc585a.xadb8a11581ae0f33(x1dc4566238993d43, xeedad81aaed42a.xf7866f89640a29a3(item2)) == null)
				{
					return true;
				}
			}
		}
		return false;
	}

	static xa188b1d3d8eee54e()
	{
		xead576fba0887340 = new Hashtable();
		x1dc4566238993d43 = new Hashtable();
		x0b3679d6e4d572a3 = new ArrayList(new int[4] { 230, 270, 235, 240 });
		x682712679dbc585a.x70fa1602ceccddee(new object[72]
		{
			0, "Times New Roman", 1, "Arial", 2, "Courier New", 3, "Symbol", 4, "Helvetica",
			5, "Courier", 6, "Tms Rmn", 7, "Helv", 8, "New York", 9, "System",
			10, "Wingdings", 11, "MS Mincho", 12, "Batang", 13, "SimSun", 14, "PMingLiU",
			15, "MS Gothic", 16, "Dotum", 17, "SimHei", 18, "MingLiU", 19, "Mincho",
			20, "Gulim", 21, "Century", 22, "Angsana New", 23, "Cordia New", 24, "Mangal",
			25, "Latha", 26, "Sylfaen", 27, "Vrinda", 28, "Raavi", 29, "Shruti",
			30, "Sendnya", 31, "Gautami", 32, "Tunga", 33, "Estrangelo Edessa", 34, "Arial Unicode MS",
			35, "Tahoma"
		}, xead576fba0887340, x1dc4566238993d43);
	}
}
