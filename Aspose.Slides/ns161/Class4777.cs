using System.Drawing;
using System.IO;

namespace ns161;

internal class Class4777 : Class4775
{
	private SizeF sizeF_0;

	public bool Equals(Class4777 other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		if (Equals((Class4775)other))
		{
			return other.sizeF_0.Equals(sizeF_0);
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
		return Equals(obj as Class4777);
	}

	public override int GetHashCode()
	{
		return (base.GetHashCode() * 397) ^ sizeF_0.GetHashCode();
	}

	public static bool operator ==(Class4777 left, Class4777 right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Class4777 left, Class4777 right)
	{
		return !object.Equals(left, right);
	}

	public Class4777(SizeF size, Stream stream)
		: base(stream)
	{
		sizeF_0 = size;
	}
}
