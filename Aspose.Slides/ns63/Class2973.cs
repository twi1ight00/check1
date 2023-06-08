using System.Text;
using Aspose.Slides;

namespace ns63;

internal class Class2973 : Class2972
{
	public short? BulletBlipRef
	{
		get
		{
			if (method_5(Enum450.flag_23))
			{
				return short_8;
			}
			return null;
		}
		set
		{
			if (value.HasValue)
			{
				short_8 = value.Value;
			}
			method_6(Enum450.flag_23, value.HasValue);
		}
	}

	public NullableBool BulletHasScheme
	{
		get
		{
			if (method_5(Enum450.flag_25))
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
			bool_0 = value == NullableBool.True;
			method_6(Enum450.flag_25, value != NullableBool.NotDefined);
		}
	}

	public Class2979 BulletAutoNumberScheme
	{
		get
		{
			if (method_5(Enum450.flag_24))
			{
				return class2979_0;
			}
			return null;
		}
		set
		{
			class2979_0 = value;
			method_6(Enum450.flag_24, value != null);
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("TextPFException9");
		stringBuilder.Append(base.ToString());
		return stringBuilder.ToString();
	}
}
