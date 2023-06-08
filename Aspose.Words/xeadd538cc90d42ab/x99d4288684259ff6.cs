using System;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;
using x97158843ec3fa116;

namespace xeadd538cc90d42ab;

internal class x99d4288684259ff6 : x23d94c795091e07b
{
	public xc68387e4ac42bd67 xebcf83b00134300b(string x5518c79299afe5d9)
	{
		string[] array = x789ce306a3447741(x5518c79299afe5d9);
		string text = array[0];
		return text switch
		{
			"*/" => new x7d9efc51e92d95f4(array, new xf9cc0c2ca331fcdf()), 
			"+-" => new x7d9efc51e92d95f4(array, new x928d6a43ccc1346f()), 
			"+/" => new x7d9efc51e92d95f4(array, new x8ec93c8cd66cf431()), 
			"?:" => new x7d9efc51e92d95f4(array, new xdc9d696105a4ef8d()), 
			"abs" => new xef1490cf545277fa(array, new xcc81fe9ea1727572()), 
			"at2" => new x70af5e096fdbdd4e(array, new x8bb55114c5c94ad7()), 
			"cat2" => new x7d9efc51e92d95f4(array, new x43547821a4124670()), 
			"cos" => new x70af5e096fdbdd4e(array, new xb3bacade47605735()), 
			"max" => new x70af5e096fdbdd4e(array, new xb7c6c17911402ec5()), 
			"min" => new x70af5e096fdbdd4e(array, new x1cf45b94b736dc6d()), 
			"mod" => new x7d9efc51e92d95f4(array, new x19f070eaf7274619()), 
			"pin" => new x7d9efc51e92d95f4(array, new x6e3a0ff5e29d0030()), 
			"sat2" => new x7d9efc51e92d95f4(array, new xa74c618d3173563b()), 
			"sin" => new x70af5e096fdbdd4e(array, new x4ff49920c8b54d7e()), 
			"sqrt" => new xef1490cf545277fa(array, new x806a0d3b41081c53()), 
			"tan" => new x70af5e096fdbdd4e(array, new x269fb7bd17a1ef40()), 
			"val" => new xef1490cf545277fa(array, new x0dc3fe1d6d2b8385()), 
			_ => throw new ArgumentOutOfRangeException("formula", $"Unknown formula type '{text}'."), 
		};
	}

	private static string[] x789ce306a3447741(string x5518c79299afe5d9)
	{
		string[] x923f7d53fd = x5518c79299afe5d9.Split(' ');
		x923f7d53fd = x98ce0996574fba4d(x923f7d53fd);
		if (x923f7d53fd.Length == 0)
		{
			throw new ArgumentOutOfRangeException("formula", string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ecpbaegcaencjpddmdldcececejekdafpdhfddoffcfgbolgfochgdkhioaicdiijnoinnfj", 178659042)), x5518c79299afe5d9));
		}
		return x923f7d53fd;
	}

	private static string[] x98ce0996574fba4d(string[] x923f7d53fd050627)
	{
		int num = 0;
		foreach (string xbcea506a33cf in x923f7d53fd050627)
		{
			if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf))
			{
				num++;
			}
		}
		string[] array = new string[num];
		int num2 = 0;
		foreach (string text in x923f7d53fd050627)
		{
			if (x0d299f323d241756.x5959bccb67bbf051(text))
			{
				array[num2++] = text;
			}
		}
		return array;
	}
}
