namespace ns322;

internal abstract class Class7397
{
	public const string string_0 = "object";

	public const string string_1 = "boolean";

	public const string string_2 = "string";

	public const string string_3 = "number";

	public const string string_4 = "undefined";

	public const string string_5 = "null";

	public const string string_6 = "descriptor";

	public const string string_7 = "function";

	public const string string_8 = "Number";

	public const string string_9 = "String";

	public const string string_10 = "Boolean";

	public const string string_11 = "Object";

	public const string string_12 = "Function";

	public const string string_13 = "Array";

	public const string string_14 = "RegExp";

	public const string string_15 = "Date";

	public const string string_16 = "Error";

	public const string string_17 = "Arguments";

	public const string string_18 = "Global";

	public const string string_19 = "Descriptor";

	public const string string_20 = "Scope";

	private Enum988 enum988_0;

	private Interface403 interface403_0;

	public static Class7397[] class7397_0 = new Class7397[0];

	public abstract object Value { get; set; }

	internal Enum988 Attributes
	{
		get
		{
			return enum988_0;
		}
		set
		{
			enum988_0 = value;
		}
	}

	public Interface403 Indexer
	{
		get
		{
			return interface403_0;
		}
		set
		{
			interface403_0 = value;
		}
	}

	public abstract string _Class { get; }

	public abstract string Type { get; }

	public virtual Class7397 vmethod_0(Class7397 index)
	{
		return null;
	}

	internal virtual Class7397 vmethod_1(Interface401 global)
	{
		return Class7437.class7437_0;
	}

	public virtual bool vmethod_2()
	{
		return true;
	}

	public virtual double vmethod_3()
	{
		return 0.0;
	}

	public virtual int vmethod_4()
	{
		return (int)vmethod_3();
	}

	public virtual object vmethod_5()
	{
		return Value;
	}

	public virtual string vmethod_6()
	{
		return ToString();
	}

	public override string ToString()
	{
		return ((Value == null) ? _Class : Value).ToString();
	}

	public override int GetHashCode()
	{
		if (Value == null)
		{
			return base.GetHashCode();
		}
		return Value.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		Class7397 @class = obj as Class7397;
		if (object.ReferenceEquals(null, @class))
		{
			return false;
		}
		if (object.ReferenceEquals(this, @class))
		{
			return true;
		}
		if (Type != @class.Type)
		{
			return false;
		}
		if (@class is Class7437)
		{
			return true;
		}
		if (@class is Class7433)
		{
			return true;
		}
		return vmethod_5().Equals(@class.vmethod_5());
	}

	public Class7397()
	{
	}
}
