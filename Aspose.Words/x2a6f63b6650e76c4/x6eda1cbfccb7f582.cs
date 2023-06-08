using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x2a6f63b6650e76c4;

internal class x6eda1cbfccb7f582
{
	private x0c42a45932a8a6f5 xddbdbbf3d2a2466e;

	private string x37333827c1866061;

	private int xf1e00dfdba918031;

	public bool xe1a2028d267ad710 => (xddbdbbf3d2a2466e & x0c42a45932a8a6f5.xce7d39f89d44bc2a) == x0c42a45932a8a6f5.xce7d39f89d44bc2a;

	public bool xb1af30d261818633 => (xddbdbbf3d2a2466e & x0c42a45932a8a6f5.xdc88f9287c50d24f) == x0c42a45932a8a6f5.xdc88f9287c50d24f;

	public bool x8c3ce9ba649c6f48 => (xddbdbbf3d2a2466e & x0c42a45932a8a6f5.x8c0d22e4c133799d) == x0c42a45932a8a6f5.x8c0d22e4c133799d;

	public bool xec9b6efd599882d1 => (xddbdbbf3d2a2466e & x0c42a45932a8a6f5.xdca898064db7c0c8) == x0c42a45932a8a6f5.xdca898064db7c0c8;

	public bool x1527af5289bfaea9 => (xddbdbbf3d2a2466e & x0c42a45932a8a6f5.xef19f5be66d2e2e3) == x0c42a45932a8a6f5.xef19f5be66d2e2e3;

	public bool x5f726bbb7e65499f => (xddbdbbf3d2a2466e & x0c42a45932a8a6f5.xed7cdcd3ee395542) == x0c42a45932a8a6f5.xed7cdcd3ee395542;

	public bool xa48414550ce3ccac => (xddbdbbf3d2a2466e & x0c42a45932a8a6f5.x4c9a70a194eb1b1a) == x0c42a45932a8a6f5.x4c9a70a194eb1b1a;

	public int xb23845739ee7b10f => xf1e00dfdba918031;

	public string xa0ca4fcd0cd6b855
	{
		get
		{
			return x37333827c1866061;
		}
		set
		{
			xddbdbbf3d2a2466e = x0c42a45932a8a6f5.x4d0b9d4447ba7566;
			xf1e00dfdba918031 = 0;
			if (!x0d299f323d241756.x5959bccb67bbf051(value))
			{
				x37333827c1866061 = string.Empty;
				return;
			}
			if (x0d299f323d241756.x6c589c7857d7d8d9(value[0]))
			{
				xddbdbbf3d2a2466e |= x0c42a45932a8a6f5.xce7d39f89d44bc2a;
			}
			if (x0d299f323d241756.x6c589c7857d7d8d9(value[value.Length - 1]))
			{
				xddbdbbf3d2a2466e |= x0c42a45932a8a6f5.xdc88f9287c50d24f;
			}
			x37333827c1866061 = value.Trim();
			if (x37333827c1866061.Length < 1)
			{
				xddbdbbf3d2a2466e = x0c42a45932a8a6f5.x4d0b9d4447ba7566;
				return;
			}
			int i = 0;
			if (x37333827c1866061[i] == '-')
			{
				if (x37333827c1866061.Length < 2)
				{
					xddbdbbf3d2a2466e = x0c42a45932a8a6f5.x4d0b9d4447ba7566;
					return;
				}
				xddbdbbf3d2a2466e |= x0c42a45932a8a6f5.xef19f5be66d2e2e3;
				i++;
			}
			string text = xca004f56614e2431.x1b50446eaf1c4798();
			if (x37333827c1866061.Substring(i, text.Length).Equals(text))
			{
				i += text.Length;
				if (i == x37333827c1866061.Length)
				{
					xddbdbbf3d2a2466e = x0c42a45932a8a6f5.x4d0b9d4447ba7566;
					return;
				}
				xddbdbbf3d2a2466e |= x0c42a45932a8a6f5.xed7cdcd3ee395542;
			}
			char c = xca004f56614e2431.xaccdf4f36d70782c();
			int num = i;
			for (; i < x37333827c1866061.Length; i++)
			{
				if (!char.IsDigit(x37333827c1866061, i))
				{
					if (xec9b6efd599882d1 || x37333827c1866061[i] != c)
					{
						break;
					}
					xddbdbbf3d2a2466e |= x0c42a45932a8a6f5.xdca898064db7c0c8;
					xf1e00dfdba918031 = i - num;
					if (xf1e00dfdba918031 == 0 && (i == x37333827c1866061.Length - 1 || !char.IsDigit(x37333827c1866061, i + 1)))
					{
						xddbdbbf3d2a2466e = x0c42a45932a8a6f5.x4d0b9d4447ba7566;
						return;
					}
				}
			}
			if (!xec9b6efd599882d1)
			{
				xf1e00dfdba918031 = i - num;
			}
			if (i < x37333827c1866061.Length)
			{
				if (x5f726bbb7e65499f || x37333827c1866061.Length - i != text.Length || !x37333827c1866061.Substring(i).Equals(text))
				{
					xddbdbbf3d2a2466e = x0c42a45932a8a6f5.x4d0b9d4447ba7566;
					xf1e00dfdba918031 = 0;
					return;
				}
				xddbdbbf3d2a2466e |= x0c42a45932a8a6f5.x4c9a70a194eb1b1a;
			}
			xddbdbbf3d2a2466e |= x0c42a45932a8a6f5.x8c0d22e4c133799d;
		}
	}

	internal x0c42a45932a8a6f5 x9bd4ec85acfcef6d => xddbdbbf3d2a2466e;

	public x6eda1cbfccb7f582(string parameterValue)
	{
		xa0ca4fcd0cd6b855 = parameterValue;
	}
}
