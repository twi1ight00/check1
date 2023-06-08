using System;
using System.Globalization;
using ns301;

namespace ns284;

internal class Class6959 : IEquatable<Class6959>
{
	private const string string_0 = "{0}{1}";

	private float float_0 = -1f;

	private bool bool_0;

	private Enum955 enum955_0;

	private bool bool_1;

	public float Value
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public Enum955 Unit
	{
		get
		{
			return enum955_0;
		}
		set
		{
			enum955_0 = value;
		}
	}

	public bool IsInherit
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public bool IsAuto
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public Class6959(bool isAuto)
		: this(0f, Enum955.const_0, isAuto, isInherit: false)
	{
	}

	public Class6959(float val)
		: this(val, Enum955.const_0, isAuto: false, isInherit: false)
	{
	}

	public Class6959(float val, Enum955 px)
		: this(val, px, isAuto: false, isInherit: false)
	{
	}

	public Class6959(float val, Enum955 px, bool isAuto, bool isInherit)
	{
		float_0 = val;
		enum955_0 = px;
		bool_1 = isAuto;
		bool_0 = isInherit;
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as Class6959);
	}

	public bool Equals(Class6959 other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (IsAuto && other.IsAuto)
		{
			return true;
		}
		if (IsInherit && other.IsInherit)
		{
			return true;
		}
		if (Unit == other.Unit)
		{
			return Value.Equals(other.Value);
		}
		return false;
	}

	public override string ToString()
	{
		if (IsAuto)
		{
			return "auto";
		}
		if (IsInherit)
		{
			return "inherit";
		}
		string text = Unit switch
		{
			Enum955.const_0 => "pt", 
			Enum955.const_1 => "em", 
			Enum955.const_2 => "ex", 
			Enum955.const_3 => "%", 
			Enum955.const_4 => "px", 
			Enum955.const_5 => "in", 
			Enum955.const_6 => "cm", 
			Enum955.const_7 => "mm", 
			Enum955.const_8 => "pc", 
			_ => throw new ArgumentOutOfRangeException(string.Format(CultureInfo.InvariantCulture, "The Unit is out of range: {0}", new object[1] { Unit })), 
		};
		return string.Format(CultureInfo.InvariantCulture, "{0}{1}", new object[2] { Value, text });
	}

	public static Class6959 smethod_0(Class6959 num1, Class6959 num2)
	{
		if (num1.Unit == Enum955.const_3 && num2.Unit != Enum955.const_3)
		{
			return num1;
		}
		if (num2.Unit == Enum955.const_3 && num1.Unit != Enum955.const_3)
		{
			return num2;
		}
		if (num1.Unit == num2.Unit)
		{
			if (num1.Value > num2.Value)
			{
				return num1;
			}
			return num2;
		}
		float num3 = Class6969.smethod_10(num1);
		float num4 = Class6969.smethod_10(num2);
		if (num3 > num4)
		{
			return num1;
		}
		return num2;
	}

	internal bool method_0(float fontSize)
	{
		if (Unit != Enum955.const_1 && Unit != Enum955.const_2 && Unit != Enum955.const_3)
		{
			Unit = Enum955.const_1;
			Value /= fontSize;
			return true;
		}
		return false;
	}
}
