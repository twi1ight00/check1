using System.Globalization;
using ns73;

namespace ns84;

internal class Class4337
{
	private Enum634 enum634_0;

	private float float_0;

	internal static readonly CultureInfo cultureInfo_0 = new CultureInfo("en-US");

	public Enum634 Type
	{
		get
		{
			return enum634_0;
		}
		protected set
		{
			enum634_0 = value;
		}
	}

	public float Value
	{
		get
		{
			return float_0;
		}
		protected set
		{
			float_0 = value;
		}
	}

	public Class4337(float unitValue, Enum634 unitType)
	{
		float_0 = unitValue;
		enum634_0 = unitType;
	}

	public override string ToString()
	{
		Interface55<Enum634> @interface = Class4342.smethod_0<Enum634>();
		return string.Format(cultureInfo_0, "{0}{1}", new object[2]
		{
			Value,
			@interface.imethod_2(Type)
		});
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
		Class4337 @class = obj as Class4337;
		if (object.ReferenceEquals(null, @class))
		{
			return false;
		}
		return Equals(@class);
	}

	public bool Equals(Class4337 other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		if (object.Equals(other.enum634_0, enum634_0))
		{
			return other.float_0.Equals(float_0);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (enum634_0.GetHashCode() * 397) ^ float_0.GetHashCode();
	}
}
