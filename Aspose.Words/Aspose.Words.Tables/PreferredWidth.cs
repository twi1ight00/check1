using System;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace Aspose.Words.Tables;

public class PreferredWidth
{
	private const int xc0cb86139b39dc10 = 600;

	private const int xf85a9015d4399285 = 1584;

	internal const int x6821593532f0f45a = 50;

	public static readonly PreferredWidth Auto = new PreferredWidth(PreferredWidthType.Auto, 0);

	private readonly PreferredWidthType xf263b01e2956834c;

	private readonly int x1400a3dcd7919e91;

	public PreferredWidthType Type => xf263b01e2956834c;

	public double Value => xf263b01e2956834c switch
	{
		PreferredWidthType.Auto => 0.0, 
		PreferredWidthType.Percent => (double)x1400a3dcd7919e91 / 50.0, 
		PreferredWidthType.Points => x4574ea26106f0edb.x0e1fdb362561ddb2(x1400a3dcd7919e91), 
		_ => throw new InvalidOperationException("Unknown preferred width type."), 
	};

	internal int x7680505e84ce0354 => x1400a3dcd7919e91;

	internal int xdf4645c89f0e47f6 => x1400a3dcd7919e91;

	internal bool x40aae25d22abf007 => x1400a3dcd7919e91 > 0;

	internal bool xa72bf798a679c0aa => xf263b01e2956834c == PreferredWidthType.Auto;

	internal bool x08428aa3999da322 => xf263b01e2956834c == PreferredWidthType.Points;

	internal bool x368bd9f7b8c336b4 => xf263b01e2956834c == PreferredWidthType.Percent;

	internal static PreferredWidth x6b44e3efc21fd5b4(PreferredWidthType x43163d22e8cd5a71, int x5b1c8ddab0846b39)
	{
		return new PreferredWidth(x43163d22e8cd5a71, x5b1c8ddab0846b39);
	}

	internal static PreferredWidth xf6bcf515ffcb5cc9(int xf6495da3f9ed2d9c)
	{
		return new PreferredWidth(PreferredWidthType.Points, xf6495da3f9ed2d9c);
	}

	internal static PreferredWidth xb4e521ca3a7fd077(double x4afa7e85b5b4d006)
	{
		return new PreferredWidth(PreferredWidthType.Percent, x15e971129fd80714.x43fcc3f62534530b(x4afa7e85b5b4d006 * 50.0));
	}

	internal static PreferredWidth xb6bb25492776965a(double x6fa2570084b2ad39)
	{
		return new PreferredWidth(PreferredWidthType.Points, x4574ea26106f0edb.x88bf16f2386d633e(x6fa2570084b2ad39));
	}

	public static PreferredWidth FromPercent(double percent)
	{
		x0d299f323d241756.x0b2d7be73d532b1c(percent, 0.0, 0.0, 600.0, 600.0, x9199ed88324d69ff: true, "percent");
		return xb4e521ca3a7fd077(percent);
	}

	public static PreferredWidth FromPoints(double points)
	{
		x0d299f323d241756.x0b2d7be73d532b1c(points, 0.0, 0.0, 1584.0, 1584.0, x9199ed88324d69ff: true, "points");
		return xb6bb25492776965a(points);
	}

	private PreferredWidth(PreferredWidthType type, int rawValue)
	{
		if (type == (PreferredWidthType)0)
		{
			type = PreferredWidthType.Auto;
		}
		xf263b01e2956834c = type;
		x1400a3dcd7919e91 = rawValue;
	}

	internal bool Equals(PreferredWidth other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		if (other.xf263b01e2956834c == xf263b01e2956834c)
		{
			return other.x1400a3dcd7919e91 == x1400a3dcd7919e91;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj.GetType() != typeof(PreferredWidth))
		{
			return false;
		}
		return Equals((PreferredWidth)obj);
	}

	public override int GetHashCode()
	{
		return (((int)xf263b01e2956834c).GetHashCode() * 397) ^ x1400a3dcd7919e91;
	}

	public override string ToString()
	{
		return xf263b01e2956834c switch
		{
			PreferredWidthType.Auto => "Auto", 
			PreferredWidthType.Percent => xca004f56614e2431.xdbca7a004e2d3753(Value) + '%', 
			PreferredWidthType.Points => xca004f56614e2431.xc8ba948e0d631490(xdf4645c89f0e47f6), 
			_ => base.ToString(), 
		};
	}
}
