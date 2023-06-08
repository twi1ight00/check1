using x6c95d9cf46ff5f25;

namespace x7c7a1dceb600404e;

internal class x94f937e2091879d2
{
	private readonly string xc61ff88f1f98652d;

	private readonly string x4574aea041dd835f;

	internal string x759aa16c2016a289 => xc61ff88f1f98652d;

	internal string xd2f68ee6f47e9dfb => x4574aea041dd835f;

	internal x94f937e2091879d2(string name, string value)
	{
		xc61ff88f1f98652d = name;
		x4574aea041dd835f = value;
	}

	internal static x94f937e2091879d2 xb0c325557cbfd6d3(string xe4115acdf4fbfccc)
	{
		string[] array = xe4115acdf4fbfccc.Split(':');
		if (array.Length < 2)
		{
			return null;
		}
		string text = array[0].Trim();
		string text2 = array[1].Trim();
		if (!x0d299f323d241756.x5959bccb67bbf051(text) || !x0d299f323d241756.x5959bccb67bbf051(text2))
		{
			return null;
		}
		return new x94f937e2091879d2(text, text2);
	}
}
