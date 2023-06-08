using System.Drawing;

namespace x120d4bb5c80fb10c;

internal class x319a5291e0303fb7
{
	private x534d8847b46a0ceb x7093a5fab98daac1;

	private PointF xfa79116e1d2d275f;

	internal x534d8847b46a0ceb x68953f97ddfd5344
	{
		get
		{
			return x7093a5fab98daac1;
		}
		set
		{
			x7093a5fab98daac1 = value;
		}
	}

	internal PointF x755f16bdf92ce7c4
	{
		get
		{
			return xfa79116e1d2d275f;
		}
		set
		{
			xfa79116e1d2d275f = value;
		}
	}

	internal x319a5291e0303fb7(PointF point)
		: this(point, x534d8847b46a0ceb.xefd793a3562fa636)
	{
	}

	internal x319a5291e0303fb7(PointF point, x534d8847b46a0ceb typeOfVertex)
	{
		x755f16bdf92ce7c4 = point;
		x68953f97ddfd5344 = typeOfVertex;
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
		if (obj.GetType() != typeof(x319a5291e0303fb7))
		{
			return false;
		}
		return Equals((x319a5291e0303fb7)obj);
	}

	public bool Equals(x319a5291e0303fb7 other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		if (object.Equals(other.x7093a5fab98daac1, x7093a5fab98daac1))
		{
			return other.xfa79116e1d2d275f.Equals(xfa79116e1d2d275f);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ((int)x7093a5fab98daac1 * 397) ^ xfa79116e1d2d275f.GetHashCode();
	}

	public override string ToString()
	{
		return string.Concat(x7093a5fab98daac1, ":", xfa79116e1d2d275f);
	}
}
