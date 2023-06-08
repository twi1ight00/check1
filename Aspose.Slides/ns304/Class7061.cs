using System;

namespace ns304;

internal class Class7061 : IEquatable<Class7061>
{
	private readonly bool bool_0;

	private readonly string string_0;

	private readonly Interface365 interface365_0;

	public string EventType => string_0;

	public Interface365 Listener => interface365_0;

	public bool CaptureProcessingMethod => bool_0;

	public Class7061(string type, Interface365 listener, bool useCapture)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (listener == null)
		{
			throw new ArgumentNullException("listener");
		}
		string_0 = type;
		bool_0 = useCapture;
		interface365_0 = listener;
	}

	public override int GetHashCode()
	{
		int hashCode = bool_0.GetHashCode();
		hashCode = (hashCode * 397) ^ ((string_0 != null) ? string_0.GetHashCode() : 0);
		return (hashCode * 397) ^ ((interface365_0 != null) ? interface365_0.GetHashCode() : 0);
	}

	public static bool operator ==(Class7061 left, Class7061 right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Class7061 left, Class7061 right)
	{
		return !object.Equals(left, right);
	}

	public bool Equals(Class7061 other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		if (bool_0.Equals(other.bool_0) && string.Equals(string_0, other.string_0))
		{
			return object.Equals(interface365_0, other.interface365_0);
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
		if (obj.GetType() != GetType())
		{
			return false;
		}
		return Equals((Class7061)obj);
	}
}
