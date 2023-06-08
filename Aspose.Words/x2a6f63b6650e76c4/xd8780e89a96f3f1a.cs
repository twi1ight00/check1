using System.Text;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x2a6f63b6650e76c4;

internal class xd8780e89a96f3f1a
{
	private readonly x12e7545fad3ccc9b x8cedcaa9a62c6e39;

	private x496b40ebe5ff5626 x4df8d56da75a5a4b;

	private x496b40ebe5ff5626 x53eb7ca6296ef98b;

	private x8c3521e0d68eee94 xb16d11e0f7336a4f;

	private bool x9f8ad8301e3867c1;

	private xd8780e89a96f3f1a(x12e7545fad3ccc9b context)
	{
		x8cedcaa9a62c6e39 = context;
	}

	internal static x496b40ebe5ff5626 x1f490eac106aee12(x12e7545fad3ccc9b x0f7b23d1c393aed9)
	{
		xd8780e89a96f3f1a xd8780e89a96f3f1a2 = new xd8780e89a96f3f1a(x0f7b23d1c393aed9);
		return xd8780e89a96f3f1a2.x1f490eac106aee12();
	}

	internal x496b40ebe5ff5626 x1f490eac106aee12()
	{
		x4df8d56da75a5a4b = new x496b40ebe5ff5626();
		x53eb7ca6296ef98b = new x496b40ebe5ff5626();
		xb16d11e0f7336a4f = new x8c3521e0d68eee94();
		x9f8ad8301e3867c1 = false;
		bool x07a6dbdbdffc814a = true;
		bool flag = false;
		while (!x8cedcaa9a62c6e39.x0e410626c9576523)
		{
			if (x8cedcaa9a62c6e39.xbe1e23e7d5b43370 == 0 && x8cedcaa9a62c6e39.x1efcac262b819134 == '=')
			{
				x8cedcaa9a62c6e39.xf601d2ca12b0a3f5();
			}
			if (x8cedcaa9a62c6e39.x0e410626c9576523)
			{
				return null;
			}
			if (char.IsWhiteSpace(x8cedcaa9a62c6e39.x1efcac262b819134))
			{
				x8cedcaa9a62c6e39.xf601d2ca12b0a3f5();
				continue;
			}
			x65f1c5fa03df41d5 x65f1c5fa03df41d6 = xd2ada542ac52d9f9(x07a6dbdbdffc814a);
			if (x65f1c5fa03df41d6 != null)
			{
				x01c92b45efeec1d1(x65f1c5fa03df41d6);
				x07a6dbdbdffc814a = !x65f1c5fa03df41d6.x90378800bf36356b;
				flag = x65f1c5fa03df41d6.x90378800bf36356b || x65f1c5fa03df41d6 is xab467e24c8bb0605;
				continue;
			}
			if (flag)
			{
				break;
			}
			xddb28bb303a8678b xddb28bb303a8678b2 = x095ca45783003376();
			if (xddb28bb303a8678b2 != null)
			{
				x72b06107321aac29(xddb28bb303a8678b2);
				x07a6dbdbdffc814a = false;
				flag = true;
				continue;
			}
			return null;
		}
		if (x9f8ad8301e3867c1)
		{
			return null;
		}
		while (xb16d11e0f7336a4f.xd44988f225497f3a > 0)
		{
			x65f1c5fa03df41d5 x65f1c5fa03df41d7 = xb16d11e0f7336a4f.x47c79a4d207183de();
			if (x65f1c5fa03df41d7 is xddb28bb303a8678b)
			{
				x480eb68724612154((xddb28bb303a8678b)x65f1c5fa03df41d7);
				continue;
			}
			return null;
		}
		return x4df8d56da75a5a4b;
	}

	private x65f1c5fa03df41d5 xd2ada542ac52d9f9(bool x07a6dbdbdffc814a)
	{
		if (x8cedcaa9a62c6e39.x0fb6e35dbe9b1677("+"))
		{
			return new x969612d2cbdebc37();
		}
		if (x8cedcaa9a62c6e39.x0fb6e35dbe9b1677("-"))
		{
			if (x07a6dbdbdffc814a)
			{
				return new x0e9955ba934990fc();
			}
			return new xc11a840fbaa1ff53();
		}
		if (x8cedcaa9a62c6e39.x0fb6e35dbe9b1677("%"))
		{
			return new xab467e24c8bb0605();
		}
		if (x8cedcaa9a62c6e39.x0fb6e35dbe9b1677("*"))
		{
			return new x96caeac9bf3351e1();
		}
		if (x8cedcaa9a62c6e39.x0fb6e35dbe9b1677("/"))
		{
			return new x791d08e216366045();
		}
		if (x8cedcaa9a62c6e39.x0fb6e35dbe9b1677("^"))
		{
			return new x5165c02056e8cd4a();
		}
		if (x8cedcaa9a62c6e39.x0fb6e35dbe9b1677("="))
		{
			return new x34c754d2a75c5c86();
		}
		if (x8cedcaa9a62c6e39.x0fb6e35dbe9b1677(">="))
		{
			return new x58501766a5b49a82();
		}
		if (x8cedcaa9a62c6e39.x0fb6e35dbe9b1677(">"))
		{
			return new xfe8f11bafae1159c();
		}
		if (x8cedcaa9a62c6e39.x0fb6e35dbe9b1677("<="))
		{
			return new x909ec1da03a92e23();
		}
		if (x8cedcaa9a62c6e39.x0fb6e35dbe9b1677("<>"))
		{
			return new x01af16a94641729d();
		}
		if (x8cedcaa9a62c6e39.x0fb6e35dbe9b1677("<"))
		{
			return new x5d1bc2c483cb31f2();
		}
		if (x8cedcaa9a62c6e39.x0fb6e35dbe9b1677("("))
		{
			return new x40e041b61bf0cab3();
		}
		if (x8cedcaa9a62c6e39.x0fb6e35dbe9b1677(")"))
		{
			return new x8cd447cd054761ed();
		}
		return null;
	}

	private void x01c92b45efeec1d1(x65f1c5fa03df41d5 xb81c9a91f980dcb0)
	{
		if (xb81c9a91f980dcb0.x456bd4a22e1dc9b8)
		{
			if (x9f8ad8301e3867c1)
			{
				x2125fc1638dbf4cc();
			}
			else
			{
				x9f8ad8301e3867c1 = true;
			}
		}
		if (xb16d11e0f7336a4f.xd44988f225497f3a == 0 || xb81c9a91f980dcb0.x456bd4a22e1dc9b8)
		{
			xb16d11e0f7336a4f.x1914eddf1fde1228(xb81c9a91f980dcb0);
		}
		else if (xb81c9a91f980dcb0.x90378800bf36356b)
		{
			while (xb16d11e0f7336a4f.xd44988f225497f3a > 0)
			{
				x65f1c5fa03df41d5 x65f1c5fa03df41d6 = xb16d11e0f7336a4f.x47c79a4d207183de();
				if (!x65f1c5fa03df41d6.x456bd4a22e1dc9b8)
				{
					x480eb68724612154((xddb28bb303a8678b)x65f1c5fa03df41d6);
					continue;
				}
				if (x9f8ad8301e3867c1)
				{
					x9f8ad8301e3867c1 = false;
					x480eb68724612154(new x0e9955ba934990fc());
				}
				break;
			}
		}
		else
		{
			if (x9f8ad8301e3867c1 && (!xb81c9a91f980dcb0.xa98e25192478b8cd || xb81c9a91f980dcb0.xe700506f58220470))
			{
				x9f8ad8301e3867c1 = false;
			}
			while (xb16d11e0f7336a4f.xd44988f225497f3a > 0 && xb81c9a91f980dcb0.x4af6b6f55aeb44a7 >= xb16d11e0f7336a4f.x607a4a398b7b3888().x4af6b6f55aeb44a7)
			{
				x480eb68724612154((xddb28bb303a8678b)xb16d11e0f7336a4f.x47c79a4d207183de());
			}
			xb16d11e0f7336a4f.x1914eddf1fde1228(xb81c9a91f980dcb0);
		}
	}

	private xddb28bb303a8678b x095ca45783003376()
	{
		string x137ffa3012d6a67d = x591c2d1f3fa4984e();
		xddb28bb303a8678b xddb28bb303a8678b2 = x95b6f2893e37227e(x137ffa3012d6a67d);
		if (xddb28bb303a8678b2 != null)
		{
			x8cedcaa9a62c6e39.x5bd1e2585b1c4eef();
			if (!x8cedcaa9a62c6e39.x0e410626c9576523 && x8cedcaa9a62c6e39.x1efcac262b819134 == '(')
			{
				xc6234f4e6911a33c((x3e270ab1f00c767a)xddb28bb303a8678b2);
			}
			return xddb28bb303a8678b2;
		}
		xddb28bb303a8678b2 = x04f1151450579e4d(x137ffa3012d6a67d);
		if (xddb28bb303a8678b2 != null)
		{
			return xddb28bb303a8678b2;
		}
		return x9f7dc7131ed07aa4(x137ffa3012d6a67d);
	}

	private void x72b06107321aac29(xddb28bb303a8678b x137ffa3012d6a67d)
	{
		if (x9f8ad8301e3867c1 && !(x137ffa3012d6a67d is x918e475ee39e3253))
		{
			x9f8ad8301e3867c1 = false;
		}
		x480eb68724612154(x137ffa3012d6a67d);
	}

	private void x480eb68724612154(xddb28bb303a8678b x807b6a11ed5163b7)
	{
		if (x9f8ad8301e3867c1)
		{
			x53eb7ca6296ef98b.xca34506722145a85(x807b6a11ed5163b7);
			return;
		}
		x2125fc1638dbf4cc();
		x4df8d56da75a5a4b.xca34506722145a85(x807b6a11ed5163b7);
	}

	private void x2125fc1638dbf4cc()
	{
		while (x53eb7ca6296ef98b.xd44988f225497f3a != 0)
		{
			x4df8d56da75a5a4b.xca34506722145a85(x53eb7ca6296ef98b.x1536749f629911ac());
		}
	}

	private static xddb28bb303a8678b x95b6f2893e37227e(string x137ffa3012d6a67d)
	{
		return x137ffa3012d6a67d.ToUpper() switch
		{
			"ABS" => new xf91863fa9c2d0dbf(), 
			"AND" => new x2c2ac2175937e52c(), 
			"AVERAGE" => new xd6040b0a733bd226(), 
			"COUNT" => new x1b4761aaa695b235(), 
			"DEFINED" => new x5332a650b01c3260(), 
			"FALSE" => new x6ce46b1ea87a84b2(), 
			"IF" => new x4044eb55dda2dac0(), 
			"INT" => new xbbb3371bb57b41bb(), 
			"MAX" => new xd11e829291b202c6(), 
			"MIN" => new x92223bd076459026(), 
			"MOD" => new xc31570bcb246a8f4(), 
			"NOT" => new x1355e22e76f30642(), 
			"OR" => new xe15f07472572878a(), 
			"PRODUCT" => new x887584ea2fd487ee(), 
			"ROUND" => new xc57c953dc2a0ed56(), 
			"SIGN" => new xaf26e8043e7c5fc8(), 
			"SUM" => new x690266ac792df8e4(), 
			"TRUE" => new xe699e9f8efcc3e2a(), 
			_ => null, 
		};
	}

	private void xc6234f4e6911a33c(x3e270ab1f00c767a x7db15a276371df56)
	{
		bool flag = true;
		int num = 0;
		char[] array = x0d299f323d241756.x644019557e120d6e();
		char[] array2 = new char[1] { '"' };
		char[] array3 = new char[array.Length + 3];
		array3[0] = '"';
		array3[1] = '(';
		array3[2] = ')';
		char c = xca004f56614e2431.x34467b042ad8c56e();
		bool flag2 = false;
		for (int i = 0; i < array.Length; i++)
		{
			array3[i + 3] = array[i];
			if (array[i] == c)
			{
				flag2 = true;
			}
		}
		x8cedcaa9a62c6e39.xf601d2ca12b0a3f5();
		int xd4f974c06ffa392b = x8cedcaa9a62c6e39.xbe1e23e7d5b43370;
		string text = string.Empty;
		char[] xb1a84c9c521e900c = array3;
		while (!x8cedcaa9a62c6e39.x0e410626c9576523 && x8cedcaa9a62c6e39.x49f5caacf9067bfa(xb1a84c9c521e900c))
		{
			switch (x8cedcaa9a62c6e39.x1efcac262b819134)
			{
			case '"':
				xb1a84c9c521e900c = (flag ? array2 : array3);
				flag = !flag;
				break;
			case '(':
				num++;
				break;
			case ')':
				if (num == 0)
				{
					if (flag2)
					{
						text = x3434313a118d22c1(x7db15a276371df56, xd4f974c06ffa392b, text);
					}
					else
					{
						x94b3ce74aa1e04ef(x7db15a276371df56, xd4f974c06ffa392b);
					}
					x8cedcaa9a62c6e39.xf601d2ca12b0a3f5();
					if (x0d299f323d241756.x5959bccb67bbf051(text))
					{
						x94b3ce74aa1e04ef(x7db15a276371df56, text);
					}
					return;
				}
				num--;
				break;
			default:
				if (num == 0)
				{
					if (flag2)
					{
						text = x3434313a118d22c1(x7db15a276371df56, xd4f974c06ffa392b, text);
					}
					else
					{
						x94b3ce74aa1e04ef(x7db15a276371df56, xd4f974c06ffa392b);
					}
					xd4f974c06ffa392b = x8cedcaa9a62c6e39.xbe1e23e7d5b43370 + 1;
				}
				break;
			}
			x8cedcaa9a62c6e39.xf601d2ca12b0a3f5();
		}
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			x94b3ce74aa1e04ef(x7db15a276371df56, text);
		}
		x94b3ce74aa1e04ef(x7db15a276371df56, xd4f974c06ffa392b);
	}

	private string x3434313a118d22c1(x3e270ab1f00c767a x7db15a276371df56, int xd4f974c06ffa392b, string x9b5c17a885c07938)
	{
		string parameterValue = x8cedcaa9a62c6e39.x459ec2e1881aa14d.Substring(xd4f974c06ffa392b, x8cedcaa9a62c6e39.xbe1e23e7d5b43370 - xd4f974c06ffa392b);
		x6eda1cbfccb7f582 x6eda1cbfccb7f583 = new x6eda1cbfccb7f582(parameterValue);
		if (!x6eda1cbfccb7f583.x8c3ce9ba649c6f48)
		{
			if (x0d299f323d241756.x5959bccb67bbf051(x9b5c17a885c07938))
			{
				x94b3ce74aa1e04ef(x7db15a276371df56, x9b5c17a885c07938);
			}
			x94b3ce74aa1e04ef(x7db15a276371df56, x6eda1cbfccb7f583.xa0ca4fcd0cd6b855);
			return string.Empty;
		}
		if (x6eda1cbfccb7f583.xe1a2028d267ad710 || x6eda1cbfccb7f583.x5f726bbb7e65499f || x6eda1cbfccb7f583.x1527af5289bfaea9 || x6eda1cbfccb7f583.xb23845739ee7b10f < 3)
		{
			if (x0d299f323d241756.x5959bccb67bbf051(x9b5c17a885c07938))
			{
				x94b3ce74aa1e04ef(x7db15a276371df56, x9b5c17a885c07938);
			}
			x9b5c17a885c07938 = x6eda1cbfccb7f583.xa0ca4fcd0cd6b855;
		}
		else
		{
			x9b5c17a885c07938 += x6eda1cbfccb7f583.xa0ca4fcd0cd6b855;
		}
		if (x6eda1cbfccb7f583.xa48414550ce3ccac || x6eda1cbfccb7f583.xec9b6efd599882d1 || x6eda1cbfccb7f583.xb1af30d261818633)
		{
			x94b3ce74aa1e04ef(x7db15a276371df56, x9b5c17a885c07938);
			return string.Empty;
		}
		return x9b5c17a885c07938;
	}

	private void x94b3ce74aa1e04ef(x3e270ab1f00c767a x7db15a276371df56, int xd4f974c06ffa392b)
	{
		string x89d53b1bb542edb = x8cedcaa9a62c6e39.x459ec2e1881aa14d.Substring(xd4f974c06ffa392b, x8cedcaa9a62c6e39.xbe1e23e7d5b43370 - xd4f974c06ffa392b).Trim();
		x94b3ce74aa1e04ef(x7db15a276371df56, x89d53b1bb542edb);
	}

	private void x94b3ce74aa1e04ef(x3e270ab1f00c767a x7db15a276371df56, string x89d53b1bb542edb7)
	{
		if (x7db15a276371df56.xd06fa436eec0b476)
		{
			xddb28bb303a8678b xddb28bb303a8678b2 = x9322ca348f66fbd2.x19890931227f0f56(x8cedcaa9a62c6e39, x89d53b1bb542edb7);
			if (xddb28bb303a8678b2 != null)
			{
				x7db15a276371df56.x69ff6456126e289b.xd6b6ed77479ef68c(xddb28bb303a8678b2);
				return;
			}
		}
		x82e26649b09596bd x28ebd0e = x6d929209cd800011.x308cb2f3483de2a6(x8cedcaa9a62c6e39.xd1b40af56a8385d4, x89d53b1bb542edb7);
		x7db15a276371df56.x69ff6456126e289b.xd6b6ed77479ef68c(x28ebd0e);
	}

	private static xddb28bb303a8678b x04f1151450579e4d(string x137ffa3012d6a67d)
	{
		return x918e475ee39e3253.x19890931227f0f56(x137ffa3012d6a67d);
	}

	private xddb28bb303a8678b x9f7dc7131ed07aa4(string x137ffa3012d6a67d)
	{
		xddb28bb303a8678b xddb28bb303a8678b2 = x9322ca348f66fbd2.xf7bd47d7d4051da1(x8cedcaa9a62c6e39, x137ffa3012d6a67d, x87e8133a83e97e91: false);
		if (x0d299f323d241756.x5959bccb67bbf051(x137ffa3012d6a67d) && char.IsDigit(x137ffa3012d6a67d[0]))
		{
			return xddb28bb303a8678b2;
		}
		xb42dd4742eae5750 xb42dd4742eae5751 = new xb42dd4742eae5750(x8cedcaa9a62c6e39, x137ffa3012d6a67d);
		if (xddb28bb303a8678b2 == null || xb42dd4742eae5751.x6624b07f4ed29060 != null)
		{
			return xb42dd4742eae5751;
		}
		return xddb28bb303a8678b2;
	}

	private string x591c2d1f3fa4984e()
	{
		StringBuilder stringBuilder = new StringBuilder();
		while (x8cedcaa9a62c6e39.xbe1e23e7d5b43370 < x8cedcaa9a62c6e39.x459ec2e1881aa14d.Length)
		{
			char x1efcac262b = x8cedcaa9a62c6e39.x1efcac262b819134;
			if (x43538238ca0e4db7(x1efcac262b))
			{
				break;
			}
			if (x1efcac262b != ' ')
			{
				stringBuilder.Append(x1efcac262b);
			}
			x8cedcaa9a62c6e39.xf601d2ca12b0a3f5();
		}
		return stringBuilder.ToString();
	}

	private static bool x43538238ca0e4db7(char x3c4da2980d043c95)
	{
		switch (x3c4da2980d043c95)
		{
		case ' ':
		case '%':
		case '(':
		case ')':
		case '*':
		case '+':
		case '-':
		case '/':
		case '<':
		case '=':
		case '>':
		case '\\':
		case '^':
			return true;
		default:
			return false;
		}
	}
}
