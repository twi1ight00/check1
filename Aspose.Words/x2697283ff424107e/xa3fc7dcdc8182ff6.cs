using System.Collections;
using System.Reflection;
using System.Text;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x2697283ff424107e;

[DefaultMember("Item")]
internal class xa3fc7dcdc8182ff6
{
	private readonly xd345c73dd1b16b74 x5f771fd8ed75bf95 = new xd345c73dd1b16b74();

	private static readonly char[] x5bafc350c07a79fc = new char[5] { ' ', '\r', '\n', '\t', '\f' };

	internal xedac08b4826d3056 xe6d4b1b411ed94b5
	{
		get
		{
			return (xedac08b4826d3056)x5f771fd8ed75bf95[xc15bd84e01929885.ToLower()];
		}
		set
		{
			x5f771fd8ed75bf95[xc15bd84e01929885.ToLower()] = value;
		}
	}

	internal xedac08b4826d3056 xe6d4b1b411ed94b5 => (xedac08b4826d3056)x5f771fd8ed75bf95.GetByIndex(xc0c4c459c6ccbd00);

	internal int xd44988f225497f3a => x5f771fd8ed75bf95.Count;

	internal xa3fc7dcdc8182ff6()
	{
	}

	internal xa3fc7dcdc8182ff6(string cssStyle)
	{
		x5b4b16238b2a05ea(cssStyle);
	}

	internal void x5b4b16238b2a05ea(string x36c843bef78b260f)
	{
		string[] array = x36c843bef78b260f.Split(';');
		string[] array2 = array;
		foreach (string xc46bc842bdf28b in array2)
		{
			xd3ec5e13b0a6588b(xc46bc842bdf28b);
		}
	}

	internal void x5b4b16238b2a05ea(xa3fc7dcdc8182ff6 x36c843bef78b260f)
	{
		int num = x36c843bef78b260f.xd44988f225497f3a;
		while (--num >= 0)
		{
			this.set_xe6d4b1b411ed94b5(x36c843bef78b260f.xf15263674eb297bb(num), x36c843bef78b260f.get_xe6d4b1b411ed94b5(num));
		}
	}

	internal void xf0ca15702ca7498c(string xc15bd84e01929885, string xbcea506a33cf9111)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			this.set_xe6d4b1b411ed94b5(xc15bd84e01929885, xedac08b4826d3056.xe6e56b57a990d08c(xbcea506a33cf9111));
		}
	}

	internal void x566936ceeb951bac(string xc15bd84e01929885, string xbcea506a33cf9111)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			this.set_xe6d4b1b411ed94b5(xc15bd84e01929885, xedac08b4826d3056.x94f5da15b32c4a50(xbcea506a33cf9111));
		}
	}

	internal void x5ae72a407a137e0b(string xc15bd84e01929885, x0a4437fb7b6e1adb xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111.Count > 0)
		{
			this.set_xe6d4b1b411ed94b5(xc15bd84e01929885, xedac08b4826d3056.x035941ec4f0820d1(xbcea506a33cf9111));
		}
	}

	internal void x19f4b30676d8bb52(string xc15bd84e01929885, x0a4437fb7b6e1adb xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111.Count > 0)
		{
			this.set_xe6d4b1b411ed94b5(xc15bd84e01929885, xedac08b4826d3056.x6af10efae8365753(xbcea506a33cf9111));
		}
	}

	internal void xfd7a4669c14e659a(string xc15bd84e01929885, double xc941868c59399d3e, double xfc2074a859a5db8c, double xaf9a0436a70689de, double xa447fc54e41dfe06, x0ec035c4a2d07fb6 x1c40252c1b8530fe)
	{
		this.set_xe6d4b1b411ed94b5(xc15bd84e01929885, xedac08b4826d3056.x38a376898e19240d(xc941868c59399d3e, xfc2074a859a5db8c, xaf9a0436a70689de, xa447fc54e41dfe06, x1c40252c1b8530fe));
	}

	internal void x0973ec6da4c01c5e(string xc15bd84e01929885, double xbcea506a33cf9111)
	{
		this.set_xe6d4b1b411ed94b5(xc15bd84e01929885, xedac08b4826d3056.x0267f5d69eccd9dc(xbcea506a33cf9111));
	}

	internal void xb2275198aa955331(string xc15bd84e01929885, double xbcea506a33cf9111)
	{
		this.set_xe6d4b1b411ed94b5(xc15bd84e01929885, xedac08b4826d3056.x8f35c5ba62da43af(xbcea506a33cf9111));
	}

	internal void xd6d0700e6673d965(string xc15bd84e01929885, double xbcea506a33cf9111, x0ec035c4a2d07fb6 xec1dc110291a6af9)
	{
		this.set_xe6d4b1b411ed94b5(xc15bd84e01929885, xedac08b4826d3056.x87b271b2896f9b89(xbcea506a33cf9111, xec1dc110291a6af9));
	}

	internal void xf4868abd18f579a7(string xc15bd84e01929885, x26d9ecb4bdf0456d xbcea506a33cf9111)
	{
		this.set_xe6d4b1b411ed94b5(xc15bd84e01929885, xedac08b4826d3056.x9a101e8986ce2172(xbcea506a33cf9111));
	}

	internal string xc79ba7b5665427dc(string xc15bd84e01929885)
	{
		xedac08b4826d3056 xedac08b4826d3057 = this.get_xe6d4b1b411ed94b5(xc15bd84e01929885);
		if (xedac08b4826d3057 == null)
		{
			return string.Empty;
		}
		return xedac08b4826d3057.x48112399d54b30c7();
	}

	internal string x9a706f5d15bd6d95(bool xb39cf349cb3e0d91)
	{
		if (x5f771fd8ed75bf95.Count == 0)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		x9a706f5d15bd6d95(stringBuilder, xb39cf349cb3e0d91);
		return stringBuilder.ToString();
	}

	private void x9a706f5d15bd6d95(StringBuilder xfef0c89324a5fd31, bool xb39cf349cb3e0d91)
	{
		if (x5f771fd8ed75bf95.Count == 0)
		{
			return;
		}
		SortedList sortedList = (xb39cf349cb3e0d91 ? new SortedList(x5f771fd8ed75bf95, new x1cf08cb657f22ab0()) : x5f771fd8ed75bf95);
		bool flag = true;
		foreach (DictionaryEntry item in sortedList)
		{
			if (!flag)
			{
				xfef0c89324a5fd31.Append("; ");
			}
			else
			{
				flag = false;
			}
			x06edec80a793ffa1((string)item.Key, (xedac08b4826d3056)item.Value, xfef0c89324a5fd31);
		}
	}

	internal string xf15263674eb297bb(int xc0c4c459c6ccbd00)
	{
		return (string)x5f771fd8ed75bf95.GetKey(xc0c4c459c6ccbd00);
	}

	internal void x52b190e626f65140(string xba08ce632055a1d9)
	{
		x5f771fd8ed75bf95.Remove(xba08ce632055a1d9.ToLower());
	}

	private void xd3ec5e13b0a6588b(string xc46bc842bdf28b94)
	{
		int num = xc46bc842bdf28b94.IndexOf(':');
		if (num >= 0)
		{
			string text = xe4865282b8c46a35(xc46bc842bdf28b94[..num]);
			string text2 = xe4865282b8c46a35(xc46bc842bdf28b94[(num + 1)..]);
			if (x0d299f323d241756.x5959bccb67bbf051(text) && x0d299f323d241756.x5959bccb67bbf051(text2))
			{
				this.set_xe6d4b1b411ed94b5(text, xedac08b4826d3056.x1f490eac106aee12(text, text2));
			}
		}
	}

	private static string xe4865282b8c46a35(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111.Trim(x5bafc350c07a79fc);
	}

	private static void x06edec80a793ffa1(string xba08ce632055a1d9, xedac08b4826d3056 xbcea506a33cf9111, StringBuilder xfef0c89324a5fd31)
	{
		xfef0c89324a5fd31.Append(xba08ce632055a1d9);
		xfef0c89324a5fd31.Append(":");
		xbcea506a33cf9111.x9a706f5d15bd6d95(xfef0c89324a5fd31);
	}
}
