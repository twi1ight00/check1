using System;
using System.Text;
using Aspose.Slides;

namespace ns63;

internal class Class2977 : Class2976, ICloneable
{
	public Class2967 SpellInfo
	{
		get
		{
			if (method_5(Enum442.flag_0))
			{
				return class2967_0;
			}
			return null;
		}
		set
		{
			class2967_0 = value;
			method_6(Enum442.flag_0, value != null);
		}
	}

	public ushort? Lid
	{
		get
		{
			if (method_5(Enum442.flag_1))
			{
				return ushort_0;
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				ushort_0 = value.Value;
			}
			method_6(Enum442.flag_1, value.HasValue);
		}
	}

	public ushort? AltLid
	{
		get
		{
			if (method_5(Enum442.flag_2))
			{
				return ushort_1;
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				ushort_1 = value.Value;
			}
			method_6(Enum442.flag_2, value.HasValue);
		}
	}

	public NullableBool Bidi
	{
		get
		{
			if (method_5(Enum442.flag_4))
			{
				if (!bool_0)
				{
					return NullableBool.False;
				}
				return NullableBool.True;
			}
			return NullableBool.NotDefined;
		}
		set
		{
			if (value != NullableBool.NotDefined)
			{
				bool_0 = value == NullableBool.True;
			}
			method_6(Enum442.flag_4, value != NullableBool.NotDefined);
		}
	}

	public byte? Pp10runid
	{
		get
		{
			if (method_5(Enum442.flag_3))
			{
				return byte_0;
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				byte_0 = value.Value;
			}
			method_6(Enum442.flag_3, value.HasValue);
		}
	}

	public NullableBool GrammarError
	{
		get
		{
			if (method_5(Enum442.flag_3))
			{
				if (!bool_1)
				{
					return NullableBool.False;
				}
				return NullableBool.True;
			}
			return NullableBool.NotDefined;
		}
		set
		{
			if (value != NullableBool.NotDefined)
			{
				bool_1 = value == NullableBool.True;
			}
			method_6(Enum442.flag_3, value != NullableBool.NotDefined);
		}
	}

	public uint[] SmartTags
	{
		get
		{
			if (method_5(Enum442.flag_6))
			{
				return uint_0;
			}
			return null;
		}
		set
		{
			uint_0 = value;
			method_6(Enum442.flag_6, value != null);
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("TextSIException");
		stringBuilder.Append(base.ToString());
		return stringBuilder.ToString();
	}

	public object Clone()
	{
		return MemberwiseClone();
	}
}
