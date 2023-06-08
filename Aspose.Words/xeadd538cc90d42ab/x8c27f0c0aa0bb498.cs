using System;
using System.Collections;

namespace xeadd538cc90d42ab;

internal class x8c27f0c0aa0bb498 : xb1d0e94341d125f3
{
	private x23d94c795091e07b x539684652778d238 = new x99d4288684259ff6();

	public x23d94c795091e07b x2e3089920bd958a5
	{
		get
		{
			return x539684652778d238;
		}
		set
		{
			x539684652778d238 = value;
		}
	}

	public x171aaaf6429b9e28 x8cc8208eeaefe98c(string x5518c79299afe5d9, string xc15bd84e01929885)
	{
		if (x5518c79299afe5d9 == null)
		{
			throw new ArgumentNullException("formula");
		}
		if (xc15bd84e01929885 == null)
		{
			throw new ArgumentNullException("name");
		}
		xc68387e4ac42bd67 formula = x2e3089920bd958a5.xebcf83b00134300b(x5518c79299afe5d9);
		return new x171aaaf6429b9e28(xc15bd84e01929885, formula);
	}

	public ArrayList x7c793059ad032d47()
	{
		ArrayList arrayList = new ArrayList(34);
		arrayList.Add(x8cc8208eeaefe98c("val 16200000", "3cd4"));
		arrayList.Add(x8cc8208eeaefe98c("val 8100000", "3cd8"));
		arrayList.Add(x8cc8208eeaefe98c("val 13500000", "5cd8"));
		arrayList.Add(x8cc8208eeaefe98c("val 18900000", "7cd8"));
		arrayList.Add(x8cc8208eeaefe98c("val 10800000", "cd2"));
		arrayList.Add(x8cc8208eeaefe98c("val 5400000", "cd4"));
		arrayList.Add(x8cc8208eeaefe98c("val 2700000", "cd8"));
		arrayList.Add(x8cc8208eeaefe98c("val h", "b"));
		arrayList.Add(x8cc8208eeaefe98c("val 0", "l"));
		arrayList.Add(x8cc8208eeaefe98c("val 0", "t"));
		arrayList.Add(x8cc8208eeaefe98c("val w", "r"));
		arrayList.Add(x8cc8208eeaefe98c("*/ w 1.0 2.0", "hc"));
		arrayList.Add(x8cc8208eeaefe98c("*/ h 1.0 2.0", "hd2"));
		arrayList.Add(x8cc8208eeaefe98c("*/ h 1.0 3.0", "hd3"));
		arrayList.Add(x8cc8208eeaefe98c("*/ h 1.0 4.0", "hd4"));
		arrayList.Add(x8cc8208eeaefe98c("*/ h 1.0 5.0", "hd5"));
		arrayList.Add(x8cc8208eeaefe98c("*/ h 1.0 6.0", "hd6"));
		arrayList.Add(x8cc8208eeaefe98c("*/ h 1.0 8.0", "hd8"));
		arrayList.Add(x8cc8208eeaefe98c("*/ h 1.0 2.0", "vc"));
		arrayList.Add(x8cc8208eeaefe98c("*/ w 1.0 2.0", "wd2"));
		arrayList.Add(x8cc8208eeaefe98c("*/ w 1.0 3.0", "wd3"));
		arrayList.Add(x8cc8208eeaefe98c("*/ w 1.0 4.0", "wd4"));
		arrayList.Add(x8cc8208eeaefe98c("*/ w 1.0 5.0", "wd5"));
		arrayList.Add(x8cc8208eeaefe98c("*/ w 1.0 6.0", "wd6"));
		arrayList.Add(x8cc8208eeaefe98c("*/ w 1.0 8.0", "wd8"));
		arrayList.Add(x8cc8208eeaefe98c("*/ w 1.0 10.0", "wd10"));
		arrayList.Add(x8cc8208eeaefe98c("*/ w 1.0 32.0", "wd32"));
		arrayList.Add(x8cc8208eeaefe98c("max w h", "ls"));
		arrayList.Add(x8cc8208eeaefe98c("min w h", "ss"));
		arrayList.Add(x8cc8208eeaefe98c("*/ ss 1.0 2.0", "ssd2"));
		arrayList.Add(x8cc8208eeaefe98c("*/ ss 1.0 4.0", "ssd4"));
		arrayList.Add(x8cc8208eeaefe98c("*/ ss 1.0 6.0", "ssd6"));
		arrayList.Add(x8cc8208eeaefe98c("*/ ss 1.0 8.0", "ssd8"));
		arrayList.Add(x8cc8208eeaefe98c("*/ ss 1.0 16.0", "ssd16"));
		arrayList.Add(x8cc8208eeaefe98c("*/ ss 1.0 32.0", "ssd32"));
		return arrayList;
	}
}
