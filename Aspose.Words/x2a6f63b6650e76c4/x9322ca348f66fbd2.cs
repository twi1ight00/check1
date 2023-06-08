using Aspose.Words;
using Aspose.Words.Tables;
using x6c95d9cf46ff5f25;

namespace x2a6f63b6650e76c4;

internal class x9322ca348f66fbd2 : xddb28bb303a8678b
{
	private readonly x209f3e4a2f735d1e x4517c2b411ea1d52;

	internal x9322ca348f66fbd2(x209f3e4a2f735d1e range)
	{
		x4517c2b411ea1d52 = range;
	}

	internal static xddb28bb303a8678b x19890931227f0f56(x12e7545fad3ccc9b x0f7b23d1c393aed9, string x4e249dc4e99686bb)
	{
		xddb28bb303a8678b xddb28bb303a8678b2 = xddb4ba01239df646(x0f7b23d1c393aed9, x4e249dc4e99686bb);
		if (xddb28bb303a8678b2 == null)
		{
			return xf7bd47d7d4051da1(x0f7b23d1c393aed9, x4e249dc4e99686bb, x87e8133a83e97e91: true);
		}
		return xddb28bb303a8678b2;
	}

	private static xddb28bb303a8678b xddb4ba01239df646(x12e7545fad3ccc9b x0f7b23d1c393aed9, string x4e249dc4e99686bb)
	{
		x209f3e4a2f735d1e x9b10ace6509508c;
		x82e26649b09596bd x82e26649b09596bd2 = xd554b53e829d5f97.x19890931227f0f56(x0f7b23d1c393aed9, x4e249dc4e99686bb, out x9b10ace6509508c);
		if (x82e26649b09596bd2 != null)
		{
			return x82e26649b09596bd2;
		}
		if (x9b10ace6509508c == null)
		{
			return null;
		}
		return new x9322ca348f66fbd2(x9b10ace6509508c);
	}

	internal static xddb28bb303a8678b xf7bd47d7d4051da1(x12e7545fad3ccc9b x0f7b23d1c393aed9, string x4e249dc4e99686bb, bool x87e8133a83e97e91)
	{
		x209f3e4a2f735d1e x9b10ace6509508c;
		x82e26649b09596bd x82e26649b09596bd2 = x393ce53fde4b6f6e.x19890931227f0f56(x0f7b23d1c393aed9, x4e249dc4e99686bb, x87e8133a83e97e91, out x9b10ace6509508c);
		if (x82e26649b09596bd2 != null)
		{
			return x82e26649b09596bd2;
		}
		if (x9b10ace6509508c == null)
		{
			return null;
		}
		return new x9322ca348f66fbd2(x9b10ace6509508c);
	}

	private x82e26649b09596bd x3494e22b9d135f56(xa7ef704c7557cbae x4be5a34ade30ae6b)
	{
		if (x4517c2b411ea1d52.xe519c9d6797c17d9)
		{
			if (x4517c2b411ea1d52.x12cb12b5d2cad53d.x11db8fc7f469a2fc != null)
			{
				x82e26649b09596bd x82e26649b09596bd2 = xaf9b8dc2dc1ced67(x4517c2b411ea1d52.x12cb12b5d2cad53d.x11db8fc7f469a2fc);
				if (x82e26649b09596bd2 == null)
				{
					return new x918e475ee39e3253(0.0);
				}
				return x82e26649b09596bd2;
			}
			return new xf7d966ea5d1701b6($"!{x4517c2b411ea1d52.x12cb12b5d2cad53d} Is Not In Table");
		}
		bool flag = false;
		xbddbf0d43615fbd5 xbddbf0d43615fbd6 = new xbddbf0d43615fbd5();
		foreach (Cell item in x4517c2b411ea1d52)
		{
			x82e26649b09596bd x82e26649b09596bd3 = xaf9b8dc2dc1ced67(item);
			if (x82e26649b09596bd3 != null)
			{
				xbddbf0d43615fbd6.xe4a88350013963a1.xd6b6ed77479ef68c(x82e26649b09596bd3);
				flag = true;
			}
			else if (!x4517c2b411ea1d52.xb6efea3f5fb6b1bd)
			{
				if (flag)
				{
					break;
				}
				xbddbf0d43615fbd6.xe4a88350013963a1.xd6b6ed77479ef68c(new x414971650f35e163());
			}
		}
		return xbddbf0d43615fbd6;
	}

	x82e26649b09596bd xddb28bb303a8678b.x308cb2f3483de2a6(xa7ef704c7557cbae x4be5a34ade30ae6b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x3494e22b9d135f56
		return this.x3494e22b9d135f56(x4be5a34ade30ae6b);
	}

	private static x82e26649b09596bd xaf9b8dc2dc1ced67(Cell xe6de5e5fa2d44af5)
	{
		string text = xe6de5e5fa2d44af5.ToString(SaveFormat.Text);
		text = text.Trim();
		if (text.Length > 1 && !char.IsDigit(text[0]))
		{
			if (text[0] == '(')
			{
				text = $"-{text.Substring(1, text.Length - 1)}";
			}
			else if (text[0] != '-')
			{
				text = text.Substring(1, text.Length - 1);
			}
		}
		text = x0d299f323d241756.xdd8b55ba4e7542c3(text);
		return x918e475ee39e3253.x19890931227f0f56(text);
	}
}
