using System;
using ns218;
using ns257;

namespace ns256;

internal class Class6368 : Interface286
{
	public Interface289 imethod_0(string formula)
	{
		string[] array = smethod_0(formula);
		string text = array[0];
		return text switch
		{
			"*/" => new Class6374(array, new Class6387()), 
			"+-" => new Class6374(array, new Class6378()), 
			"+/" => new Class6374(array, new Class6377()), 
			"?:" => new Class6374(array, new Class6382()), 
			"abs" => new Class6373(array, new Class6376()), 
			"at2" => new Class6375(array, new Class6379()), 
			"cat2" => new Class6374(array, new Class6380()), 
			"cos" => new Class6375(array, new Class6381()), 
			"max" => new Class6375(array, new Class6384()), 
			"min" => new Class6375(array, new Class6385()), 
			"mod" => new Class6374(array, new Class6386()), 
			"pin" => new Class6374(array, new Class6388()), 
			"sat2" => new Class6374(array, new Class6389()), 
			"sin" => new Class6375(array, new Class6390()), 
			"sqrt" => new Class6373(array, new Class6391()), 
			"tan" => new Class6375(array, new Class6392()), 
			"val" => new Class6373(array, new Class6383()), 
			_ => throw new ArgumentOutOfRangeException("formula", $"Unknown formula type '{text}'."), 
		};
	}

	private static string[] smethod_0(string formula)
	{
		string[] parts = formula.Split(' ');
		parts = smethod_1(parts);
		if (parts.Length == 0)
		{
			throw new ArgumentOutOfRangeException("formula", $"Bad formula '{formula}'.");
		}
		return parts;
	}

	private static string[] smethod_1(string[] parts)
	{
		int num = 0;
		foreach (string value in parts)
		{
			if (Class5964.smethod_20(value))
			{
				num++;
			}
		}
		string[] array = new string[num];
		int num2 = 0;
		foreach (string text in parts)
		{
			if (Class5964.smethod_20(text))
			{
				array[num2++] = text;
			}
		}
		return array;
	}
}
