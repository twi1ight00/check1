using System.Text;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x2a6f63b6650e76c4;

internal class x918e475ee39e3253 : x82e26649b09596bd
{
	private readonly double x4574aea041dd835f;

	private bool x413132d5bf59c844;

	private bool x9045ba57960848df;

	internal override double x7ce859afc0c75642 => x4574aea041dd835f;

	internal override bool x3a56e581f7d70f0a => x4574aea041dd835f != 0.0;

	internal override string xf6e2349738d2d14e => x9540796cdde76ac8(null);

	internal override xca3ee5e02f497e0b xca3ee5e02f497e0b => xca3ee5e02f497e0b.x94c083f2813272f4;

	internal bool x098e34a8968e1aa4 => x413132d5bf59c844;

	internal bool x5bd2073e2b041e13 => x9045ba57960848df;

	internal x918e475ee39e3253(double value)
	{
		x4574aea041dd835f = value;
	}

	private x918e475ee39e3253(double value, bool isCurrency, bool isUseGroupSeparator)
	{
		x4574aea041dd835f = value;
		x413132d5bf59c844 = isCurrency;
		x9045ba57960848df = isUseGroupSeparator;
	}

	internal static x918e475ee39e3253 xcf290d1e33e810d0(x82e26649b09596bd x337e217cb3ba0627, double xbcea506a33cf9111)
	{
		x918e475ee39e3253 x918e475ee39e3254 = new x918e475ee39e3253(xbcea506a33cf9111);
		x918e475ee39e3254.x6c0ea2f758501d85(x337e217cb3ba0627);
		return x918e475ee39e3254;
	}

	internal static x918e475ee39e3253 xcf290d1e33e810d0(x82e26649b09596bd x14a9540879201a72, x82e26649b09596bd x66cac625740ca15b, double xbcea506a33cf9111)
	{
		x918e475ee39e3253 x918e475ee39e3254 = new x918e475ee39e3253(xbcea506a33cf9111);
		x918e475ee39e3254.x6c0ea2f758501d85(x14a9540879201a72);
		x918e475ee39e3254.x6c0ea2f758501d85(x66cac625740ca15b);
		return x918e475ee39e3254;
	}

	internal static x918e475ee39e3253 xcf290d1e33e810d0(xc50df386fc548c72 x224a10c5a9aa52ca, double xbcea506a33cf9111)
	{
		x918e475ee39e3253 x918e475ee39e3254 = new x918e475ee39e3253(xbcea506a33cf9111);
		foreach (x82e26649b09596bd item in x224a10c5a9aa52ca)
		{
			x918e475ee39e3254.x6c0ea2f758501d85(item);
		}
		return x918e475ee39e3254;
	}

	internal void x6c0ea2f758501d85(x82e26649b09596bd x337e217cb3ba0627)
	{
		if (x337e217cb3ba0627.xca3ee5e02f497e0b == xca3ee5e02f497e0b.x94c083f2813272f4)
		{
			x918e475ee39e3253 x918e475ee39e3254 = (x918e475ee39e3253)x337e217cb3ba0627;
			if (x918e475ee39e3254.x098e34a8968e1aa4)
			{
				x413132d5bf59c844 = true;
			}
			if (x918e475ee39e3254.x5bd2073e2b041e13)
			{
				x9045ba57960848df = true;
			}
		}
	}

	internal static x918e475ee39e3253 x19890931227f0f56(string xe4115acdf4fbfccc)
	{
		double num = xca004f56614e2431.xc510d8f3e12c9223(xe4115acdf4fbfccc);
		if (double.IsNaN(num))
		{
			num = xca004f56614e2431.x9af476c0811d07cd(xe4115acdf4fbfccc);
		}
		if (!double.IsNaN(num))
		{
			bool isUseGroupSeparator = xe4115acdf4fbfccc.IndexOf(xca004f56614e2431.x34467b042ad8c56e()) != -1;
			bool isCurrency = xe4115acdf4fbfccc.IndexOf(xca004f56614e2431.x1b50446eaf1c4798()) != -1;
			return new x918e475ee39e3253(num, isCurrency, isUseGroupSeparator);
		}
		return null;
	}

	internal override string x9540796cdde76ac8(string x5786461d089b10a0)
	{
		string text = (x0d299f323d241756.x5959bccb67bbf051(x5786461d089b10a0) ? xca004f56614e2431.x3fefcbaee4514358(x4574aea041dd835f, x5786461d089b10a0, x5c4c72022ea54b2c: false) : xca004f56614e2431.xbce25c860880d237(x4574aea041dd835f, x413132d5bf59c844, x9045ba57960848df));
		if (x413132d5bf59c844 && !x9045ba57960848df)
		{
			char c = xca004f56614e2431.x34467b042ad8c56e();
			StringBuilder stringBuilder = new StringBuilder();
			string text2 = text;
			foreach (char c2 in text2)
			{
				if (c2 != c)
				{
					stringBuilder.Append(c2);
				}
			}
			text = stringBuilder.ToString();
		}
		return text;
	}

	internal override bool xbbbd3dabf01980ee(out double xbcea506a33cf9111)
	{
		xbcea506a33cf9111 = x4574aea041dd835f;
		return true;
	}
}
