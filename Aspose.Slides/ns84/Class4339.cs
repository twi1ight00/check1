using ns73;

namespace ns84;

internal class Class4339
{
	private readonly Enum514 enum514_0;

	private Class4339 class4339_0;

	private Class4339 class4339_1;

	public Class4339 Next => class4339_0;

	internal Class4339 First
	{
		get
		{
			Class4339 @class = this;
			while (@class.class4339_1 != null)
			{
				@class = @class.class4339_1;
			}
			return @class;
		}
	}

	internal Class4339 Last
	{
		get
		{
			Class4339 @class = this;
			while (@class.class4339_0 != null)
			{
				@class = @class.class4339_0;
			}
			return @class;
		}
	}

	public Enum514 Type => enum514_0;

	public Class4339(Enum514 type)
	{
		enum514_0 = type;
	}

	public bool method_0()
	{
		return class4339_0 != null;
	}

	internal Class4339 method_1(Class4339 element)
	{
		class4339_0 = element;
		element.class4339_1 = this;
		return class4339_0;
	}

	internal bool method_2(Class4339 element)
	{
		if (Type != element.Type)
		{
			return false;
		}
		if (method_0() != element.method_0())
		{
			if (!element.method_0())
			{
				return true;
			}
			return false;
		}
		if (method_0())
		{
			return Next.method_2(element.Next);
		}
		return true;
	}

	public static bool operator ==(Class4339 left, Class4339 right)
	{
		if (object.ReferenceEquals(left, right))
		{
			return true;
		}
		if (!object.ReferenceEquals(null, left) && !object.ReferenceEquals(null, right))
		{
			return Equals(left, right);
		}
		return false;
	}

	public static bool operator !=(Class4339 left, Class4339 right)
	{
		return !(left == right);
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		Class4339 @class = obj as Class4339;
		if (@class == null)
		{
			return false;
		}
		return Equals(@class, this);
	}

	internal Class4339 Clone()
	{
		Class4339 @class = new Class4339(Type);
		if (method_0())
		{
			@class.method_1(Next.Clone());
		}
		return @class;
	}

	private static bool Equals(Class4339 left, Class4339 right)
	{
		if (left.Type != right.Type)
		{
			return false;
		}
		if (left.method_0() != right.method_0())
		{
			return false;
		}
		if (left.method_0())
		{
			return Equals(left.Next, right.Next);
		}
		return true;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override string ToString()
	{
		string text = ":" + Class4342.smethod_0<Enum514>().imethod_2(Type);
		if (method_0())
		{
			text += class4339_0.ToString();
		}
		return text;
	}
}
