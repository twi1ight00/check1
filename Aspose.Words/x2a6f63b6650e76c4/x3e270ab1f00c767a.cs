namespace x2a6f63b6650e76c4;

internal abstract class x3e270ab1f00c767a : xddb28bb303a8678b
{
	private readonly x83760f1ced087a09 x62a6eaf179c89359 = new x83760f1ced087a09();

	internal virtual bool xd06fa436eec0b476 => false;

	protected abstract int ParameterCountMin { get; }

	protected abstract int ParameterCountMax { get; }

	internal x83760f1ced087a09 x69ff6456126e289b => x62a6eaf179c89359;

	private x82e26649b09596bd x3494e22b9d135f56(xa7ef704c7557cbae x4be5a34ade30ae6b)
	{
		if (x62a6eaf179c89359.xd44988f225497f3a < ParameterCountMin || x62a6eaf179c89359.xd44988f225497f3a > ParameterCountMax)
		{
			return new xf7d966ea5d1701b6("!Syntax Error");
		}
		xc50df386fc548c72 xc50df386fc548c73 = new xc50df386fc548c72();
		foreach (xddb28bb303a8678b item in x62a6eaf179c89359)
		{
			x82e26649b09596bd x82e26649b09596bd2 = item.x308cb2f3483de2a6(null);
			if (x82e26649b09596bd2.x6b54bdfbc4586f55 && !(this is x5332a650b01c3260))
			{
				return x82e26649b09596bd2;
			}
			xc50df386fc548c73.xd6b6ed77479ef68c(x82e26649b09596bd2);
		}
		return EvaluateCore(xc50df386fc548c73);
	}

	x82e26649b09596bd xddb28bb303a8678b.x308cb2f3483de2a6(xa7ef704c7557cbae x4be5a34ade30ae6b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x3494e22b9d135f56
		return this.x3494e22b9d135f56(x4be5a34ade30ae6b);
	}

	protected abstract x82e26649b09596bd EvaluateCore(xc50df386fc548c72 parameters);
}
