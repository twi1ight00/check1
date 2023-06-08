using System;
using System.Drawing;
using x6c95d9cf46ff5f25;
using xad5c68c1ad3b0224;

namespace xb3013071794e5415;

internal class x5b215895ce9a4c9a : x43c3197706cb18d9
{
	private float x6e74c79ac777f020;

	private float xf995a7a9bffac1cf;

	private float x2cede84e47db333b;

	private float xf63c9a791cae8f48;

	private readonly float x2619a85322287a6d;

	private SizeF xc79460a2ad0bf0a7;

	internal float xac703ffc184eb346
	{
		get
		{
			if (!(x31f3192bdc025ca5 > x89a1d2c0b93619bb))
			{
				return x31f3192bdc025ca5 / 2f;
			}
			return x89a1d2c0b93619bb / 2f;
		}
	}

	private float x31f3192bdc025ca5 => xc79460a2ad0bf0a7.Width - (x6e74c79ac777f020 + xf995a7a9bffac1cf);

	private float x89a1d2c0b93619bb => xc79460a2ad0bf0a7.Height - (x2cede84e47db333b + xf63c9a791cae8f48);

	public float xc24e3e091abd3197 => x6e74c79ac777f020;

	public float xb50d6cb9d3b61d4d => xf995a7a9bffac1cf;

	public float xcdb214dfc38b1be3 => x2cede84e47db333b;

	public float xd0fade446b8d532a => xf63c9a791cae8f48;

	internal x5b215895ce9a4c9a(SizeF targetSize, bool isInner)
	{
		xc79460a2ad0bf0a7 = targetSize;
		x2619a85322287a6d = x4574ea26106f0edb.x3aa08882c9feaf96(10.0);
		x2e726fc92e4398c6(isInner);
	}

	private void x2e726fc92e4398c6(bool x08b8b1b344c66023)
	{
		if (!x08b8b1b344c66023)
		{
			x9d75576ac28fd38a(x2619a85322287a6d, x2619a85322287a6d, x2619a85322287a6d, x2619a85322287a6d);
		}
		float num = xac703ffc184eb346 * 2f;
		if (num < x31f3192bdc025ca5)
		{
			x6e74c79ac777f020 += (x31f3192bdc025ca5 - num) / 2f;
			xf995a7a9bffac1cf = x6e74c79ac777f020;
		}
		else if (num < x89a1d2c0b93619bb)
		{
			x2cede84e47db333b += (x89a1d2c0b93619bb - num) / 2f;
			xf63c9a791cae8f48 = x2cede84e47db333b;
		}
	}

	public PointF x2206903f9421fd4b(float xe13ad605e0d03723, float xfb4c1c76fc5d2a6f)
	{
		throw new NotSupportedException("Getting points is not supported for this type of plane.");
	}

	public PointF[] x466c8609d8f6c6c1(x9b87766ad1dbe8d6 x7acb8518c8ed6133)
	{
		throw new NotSupportedException("Getting points is not supported for this type of plane.");
	}

	public PointF xeed202914e7c06d3()
	{
		return new PointF(x31f3192bdc025ca5 / 2f + x6e74c79ac777f020, x89a1d2c0b93619bb / 2f + x2cede84e47db333b);
	}

	public void x9d75576ac28fd38a(float xa447fc54e41dfe06, float xfc2074a859a5db8c, float xc941868c59399d3e, float xaf9a0436a70689de)
	{
		x6e74c79ac777f020 = Math.Max(x6e74c79ac777f020, xa447fc54e41dfe06);
		xf995a7a9bffac1cf = Math.Max(xf995a7a9bffac1cf, xfc2074a859a5db8c);
		x2cede84e47db333b = Math.Max(x2cede84e47db333b, xc941868c59399d3e);
		xf63c9a791cae8f48 = Math.Max(xf63c9a791cae8f48, xaf9a0436a70689de);
	}

	public virtual RectangleF xb7d97a6d836eba66()
	{
		return new RectangleF(0f, 0f, xc79460a2ad0bf0a7.Width, xc79460a2ad0bf0a7.Height);
	}

	public void xac399403da6cb85d()
	{
	}

	public void x5006720129e0cf11()
	{
	}
}
