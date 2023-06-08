using System;
using System.Collections;

namespace xeadd538cc90d42ab;

internal class xd0098fb28618d8f9 : x97e2c177c8bba32e
{
	private ArrayList xbc1000a5b5a3bac6 = new ArrayList();

	private ArrayList x016cecd881079c09;

	private xb1d0e94341d125f3 x3091d0c819080c35 = new x8c27f0c0aa0bb498();

	private Hashtable xe12be7a77873edbf = new Hashtable();

	private ArrayList x9c1f5270297abb08 = new ArrayList();

	internal ArrayList xe57d87fa2a819d93 => xbc1000a5b5a3bac6;

	internal ArrayList x2639dfbfaf0930ee => x9c1f5270297abb08;

	public xb1d0e94341d125f3 x3690b5a66c175078
	{
		get
		{
			return x3091d0c819080c35;
		}
		set
		{
			x3091d0c819080c35 = value;
		}
	}

	public double x3f88a25febd23896(string x2f97f3f4563276cb)
	{
		object obj = xe12be7a77873edbf[x2f97f3f4563276cb];
		if (obj == null)
		{
			throw new ArgumentOutOfRangeException(x2f97f3f4563276cb, $"Guide with name '{x2f97f3f4563276cb}' not found.");
		}
		return (double)obj;
	}

	internal void xdd6780868524dfa8(string xc15bd84e01929885, string x5518c79299afe5d9)
	{
		x171aaaf6429b9e28 value = x3690b5a66c175078.x8cc8208eeaefe98c(x5518c79299afe5d9, xc15bd84e01929885);
		xbc1000a5b5a3bac6.Add(value);
	}

	internal void x436652f076b7c10c(string xc15bd84e01929885, string x5518c79299afe5d9)
	{
		x171aaaf6429b9e28 value = x3690b5a66c175078.x8cc8208eeaefe98c(x5518c79299afe5d9, xc15bd84e01929885);
		x9c1f5270297abb08.Add(value);
	}

	internal void x4a705c5e126d7900(double x9b0739496f8b5475, double x4d5aabc7a55b12ba)
	{
		xe12be7a77873edbf.Clear();
		xe12be7a77873edbf["w"] = x9b0739496f8b5475;
		xe12be7a77873edbf["h"] = x4d5aabc7a55b12ba;
		x016cecd881079c09 = x3690b5a66c175078.x7c793059ad032d47();
		x4f934b2f9eb26c46(x016cecd881079c09);
		x4f934b2f9eb26c46(xbc1000a5b5a3bac6);
		x4f934b2f9eb26c46(x9c1f5270297abb08);
	}

	private void x4f934b2f9eb26c46(ArrayList xe7ad8322f2a407ce)
	{
		foreach (x171aaaf6429b9e28 item in xe7ad8322f2a407ce)
		{
			xe12be7a77873edbf[item.x759aa16c2016a289] = item.x40937ad35b1cf5f7.xb1de1ba20faeeff8(this);
		}
	}
}
