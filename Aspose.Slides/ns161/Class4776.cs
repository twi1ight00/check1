using System.IO;

namespace ns161;

internal class Class4776 : Class4775
{
	private string string_1;

	public Class4776(Stream stream, string familyName)
		: base(stream)
	{
		string_1 = familyName;
	}

	public bool Equals(Class4776 other)
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
			return object.Equals(other.string_1, string_1);
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
		return Equals(obj as Class4776);
	}

	public override int GetHashCode()
	{
		return (base.GetHashCode() * 397) ^ ((string_1 != null) ? string_1.GetHashCode() : 0);
	}

	public static bool operator ==(Class4776 left, Class4776 right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Class4776 left, Class4776 right)
	{
		return !object.Equals(left, right);
	}
}
