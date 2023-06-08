using System;
using System.Collections.Generic;

namespace ns256;

internal class Class6371 : Interface287
{
	private Interface286 interface286_0 = new Class6368();

	public Interface286 FormulaFactory
	{
		get
		{
			return interface286_0;
		}
		set
		{
			interface286_0 = value;
		}
	}

	public Class6370 imethod_0(string formula, string name)
	{
		if (formula == null)
		{
			throw new ArgumentNullException("formula");
		}
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		Interface289 formula2 = FormulaFactory.imethod_0(formula);
		return new Class6370(name, formula2);
	}

	public IList<Class6370> imethod_1()
	{
		List<Class6370> list = new List<Class6370>(34);
		list.Add(imethod_0("val 16200000", "3cd4"));
		list.Add(imethod_0("val 8100000", "3cd8"));
		list.Add(imethod_0("val 13500000", "5cd8"));
		list.Add(imethod_0("val 18900000", "7cd8"));
		list.Add(imethod_0("val 10800000", "cd2"));
		list.Add(imethod_0("val 5400000", "cd4"));
		list.Add(imethod_0("val 2700000", "cd8"));
		list.Add(imethod_0("val h", "b"));
		list.Add(imethod_0("val 0", "l"));
		list.Add(imethod_0("val 0", "t"));
		list.Add(imethod_0("val w", "r"));
		list.Add(imethod_0("*/ w 1.0 2.0", "hc"));
		list.Add(imethod_0("*/ h 1.0 2.0", "hd2"));
		list.Add(imethod_0("*/ h 1.0 3.0", "hd3"));
		list.Add(imethod_0("*/ h 1.0 4.0", "hd4"));
		list.Add(imethod_0("*/ h 1.0 5.0", "hd5"));
		list.Add(imethod_0("*/ h 1.0 6.0", "hd6"));
		list.Add(imethod_0("*/ h 1.0 8.0", "hd8"));
		list.Add(imethod_0("*/ h 1.0 2.0", "vc"));
		list.Add(imethod_0("*/ w 1.0 2.0", "wd2"));
		list.Add(imethod_0("*/ w 1.0 3.0", "wd3"));
		list.Add(imethod_0("*/ w 1.0 4.0", "wd4"));
		list.Add(imethod_0("*/ w 1.0 5.0", "wd5"));
		list.Add(imethod_0("*/ w 1.0 6.0", "wd6"));
		list.Add(imethod_0("*/ w 1.0 8.0", "wd8"));
		list.Add(imethod_0("*/ w 1.0 10.0", "wd10"));
		list.Add(imethod_0("*/ w 1.0 32.0", "wd32"));
		list.Add(imethod_0("max w h", "ls"));
		list.Add(imethod_0("min w h", "ss"));
		list.Add(imethod_0("*/ ss 1.0 2.0", "ssd2"));
		list.Add(imethod_0("*/ ss 1.0 4.0", "ssd4"));
		list.Add(imethod_0("*/ ss 1.0 6.0", "ssd6"));
		list.Add(imethod_0("*/ ss 1.0 8.0", "ssd8"));
		list.Add(imethod_0("*/ ss 1.0 16.0", "ssd16"));
		list.Add(imethod_0("*/ ss 1.0 32.0", "ssd32"));
		return list;
	}
}
