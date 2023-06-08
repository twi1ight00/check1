using Aspose.Words;
using Aspose.Words.Fields;
using Aspose.Words.Tables;
using xf9a9481c3f63a419;

namespace x2a6f63b6650e76c4;

internal class x12e7545fad3ccc9b
{
	private readonly Field x54c413cc80cb99d5;

	private readonly string x8203f6652120ad8a;

	private int xa3f9b2fd98264390;

	internal Field xd1b40af56a8385d4 => x54c413cc80cb99d5;

	internal Cell xc5464084edc8e226 => (Cell)x54c413cc80cb99d5.Start.GetAncestor(NodeType.Cell);

	internal Table x133f2db9e5b5690d
	{
		get
		{
			if (xc5464084edc8e226 == null)
			{
				return null;
			}
			return xc5464084edc8e226.x133f2db9e5b5690d;
		}
	}

	internal string x459ec2e1881aa14d => x8203f6652120ad8a;

	internal int xbe1e23e7d5b43370 => xa3f9b2fd98264390;

	internal char x1efcac262b819134 => x8203f6652120ad8a[xa3f9b2fd98264390];

	internal bool x0e410626c9576523
	{
		get
		{
			if (x8203f6652120ad8a != null)
			{
				return xa3f9b2fd98264390 >= x8203f6652120ad8a.Length;
			}
			return true;
		}
	}

	internal Document x2c8c6741422a1298 => x54c413cc80cb99d5.x357c90b33d6bb8e6();

	internal bool x34db7e7f15310e21 => x54c413cc80cb99d5.Type == FieldType.FieldFormula;

	internal x12e7545fad3ccc9b(Field field, string expression)
	{
		x54c413cc80cb99d5 = field;
		x8203f6652120ad8a = expression;
	}

	internal void xf601d2ca12b0a3f5()
	{
		xa3f9b2fd98264390++;
	}

	internal bool x0fb6e35dbe9b1677(string xe4115acdf4fbfccc)
	{
		if (x27cd5f9641d9eb15.Equals(x8203f6652120ad8a, xa3f9b2fd98264390, xe4115acdf4fbfccc, 0, xe4115acdf4fbfccc.Length))
		{
			xa3f9b2fd98264390 += xe4115acdf4fbfccc.Length;
			return true;
		}
		return false;
	}

	internal bool x0fb6e35dbe9b1677(char x3c4da2980d043c95)
	{
		if (x8203f6652120ad8a[xa3f9b2fd98264390] == x3c4da2980d043c95)
		{
			xa3f9b2fd98264390++;
			return true;
		}
		return false;
	}

	internal bool x0fb6e35dbe9b1677(char[] x80de18ecf198e7a3)
	{
		foreach (char x3c4da2980d043c in x80de18ecf198e7a3)
		{
			if (x0fb6e35dbe9b1677(x3c4da2980d043c))
			{
				return true;
			}
		}
		return false;
	}

	internal void x5bd1e2585b1c4eef()
	{
		while (!x0e410626c9576523 && char.IsWhiteSpace(x1efcac262b819134))
		{
			xf601d2ca12b0a3f5();
		}
	}

	internal bool x49f5caacf9067bfa(char[] xb1a84c9c521e900c)
	{
		xa3f9b2fd98264390 = x8203f6652120ad8a.IndexOfAny(xb1a84c9c521e900c, xbe1e23e7d5b43370);
		if (xa3f9b2fd98264390 < 0)
		{
			xa3f9b2fd98264390 = x8203f6652120ad8a.Length;
			return false;
		}
		return true;
	}
}
