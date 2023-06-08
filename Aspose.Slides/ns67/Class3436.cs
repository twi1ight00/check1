using System;

namespace ns67;

internal sealed class Class3436 : ICloneable
{
	private Enum483 enum483_0;

	private Enum482 enum482_0;

	private Class3458 class3458_0;

	public Enum483 RigType
	{
		get
		{
			return enum483_0;
		}
		set
		{
			enum483_0 = value;
		}
	}

	public Enum482 Direction
	{
		get
		{
			return enum482_0;
		}
		set
		{
			enum482_0 = value;
		}
	}

	public Class3458 Rotation
	{
		get
		{
			return class3458_0;
		}
		set
		{
			if (class3458_0 != value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				class3458_0 = value.method_0();
			}
		}
	}

	public Class3436()
		: this(Enum483.const_25, Enum482.const_1, Class3458.Default)
	{
	}

	public Class3436(Enum483 type, Enum482 direction, Class3458 rotation)
	{
		enum483_0 = type;
		enum482_0 = direction;
		class3458_0 = rotation.method_0();
	}

	public Class3436(string type, string direction, Class3458 rotation)
		: this(smethod_0(type), smethod_1(direction), rotation)
	{
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3436 method_0()
	{
		return new Class3436(enum483_0, enum482_0, class3458_0);
	}

	public static Enum483 smethod_0(string param)
	{
		if (param == null)
		{
			throw new ArgumentNullException(param);
		}
		return param switch
		{
			"balanced" => Enum483.const_0, 
			"brightRoom" => Enum483.const_1, 
			"chilly" => Enum483.const_2, 
			"contrasting" => Enum483.const_3, 
			"flat" => Enum483.const_4, 
			"flood" => Enum483.const_5, 
			"freezing" => Enum483.const_6, 
			"glow" => Enum483.const_7, 
			"harsh" => Enum483.const_8, 
			"legacyFlat1" => Enum483.const_9, 
			"legacyFlat2" => Enum483.const_10, 
			"legacyFlat3" => Enum483.const_11, 
			"legacyFlat4" => Enum483.const_12, 
			"legacyHarsh1" => Enum483.const_13, 
			"legacyHarsh2" => Enum483.const_14, 
			"legacyHarsh3" => Enum483.const_15, 
			"legacyHarsh4" => Enum483.const_16, 
			"legacyNormal1" => Enum483.const_17, 
			"legacyNormal2" => Enum483.const_18, 
			"legacyNormal3" => Enum483.const_19, 
			"legacyNormal4" => Enum483.const_20, 
			"morning" => Enum483.const_21, 
			"soft" => Enum483.const_22, 
			"sunrise" => Enum483.const_23, 
			"sunset" => Enum483.const_24, 
			"threePt" => Enum483.const_25, 
			"twoPt" => Enum483.const_26, 
			_ => throw new ArgumentOutOfRangeException("param"), 
		};
	}

	public static Enum482 smethod_1(string param)
	{
		if (param == null)
		{
			throw new ArgumentNullException("param");
		}
		return param switch
		{
			"b" => Enum482.const_5, 
			"bl" => Enum482.const_6, 
			"br" => Enum482.const_4, 
			"l" => Enum482.const_7, 
			"r" => Enum482.const_3, 
			"t" => Enum482.const_1, 
			"tl" => Enum482.const_0, 
			"tr" => Enum482.const_2, 
			_ => throw new ArgumentOutOfRangeException("param"), 
		};
	}
}
