using System.Globalization;

namespace ns289;

internal class Class6785
{
	private float float_0;

	private Enum920 enum920_0;

	private static readonly CultureInfo cultureInfo_0 = new CultureInfo("en-US");

	public Enum920 Unit
	{
		get
		{
			return enum920_0;
		}
		set
		{
			enum920_0 = value;
		}
	}

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

	public Class6785(float value, Enum920 unit)
	{
		Value = value;
		Unit = unit;
	}

	public override string ToString()
	{
		return string.Format(cultureInfo_0, "{0}{1}", new object[2]
		{
			float_0,
			smethod_0(Unit)
		});
	}

	internal static string smethod_0(Enum920 unit)
	{
		return unit switch
		{
			Enum920.const_1 => "cm", 
			Enum920.const_2 => "mm", 
			Enum920.const_3 => "in", 
			Enum920.const_4 => "pt", 
			_ => "px", 
		};
	}
}
