using System;
using System.Xml;
using ns56;

namespace ns8;

internal abstract class Class103
{
	private Enum120 enum120_0;

	private Enum121 enum121_0;

	public Enum120 HorizontalAlignment
	{
		get
		{
			return enum120_0;
		}
		protected set
		{
			enum120_0 = value;
		}
	}

	public Enum121 VerticalAlignment
	{
		get
		{
			return enum121_0;
		}
		protected set
		{
			enum121_0 = value;
		}
	}

	public static Class103 smethod_0(Class2146 element)
	{
		return element.Type switch
		{
			Enum306.const_0 => new Class105(element), 
			Enum306.const_1 => new Class106(element), 
			Enum306.const_2 => new Class107(element), 
			Enum306.const_3 => new Class108(element), 
			Enum306.const_4 => new Class109(element), 
			Enum306.const_5 => new Class113(element), 
			Enum306.const_6 => new Class110(element), 
			Enum306.const_7 => new Class111(element), 
			Enum306.const_8 => new Class104(element), 
			Enum306.const_9 => new Class112(element), 
			_ => throw new ArgumentException("Unknown algorithm parameter", "element"), 
		};
	}

	protected static Enum120 smethod_1(string value)
	{
		return value switch
		{
			"none" => Enum120.const_0, 
			"r" => Enum120.const_3, 
			"ctr" => Enum120.const_2, 
			"l" => Enum120.const_1, 
			_ => Enum120.const_1, 
		};
	}

	protected static Enum121 smethod_2(string value)
	{
		return value switch
		{
			"none" => Enum121.const_0, 
			"t" => Enum121.const_1, 
			"mid" => Enum121.const_2, 
			"b" => Enum121.const_3, 
			_ => Enum121.const_1, 
		};
	}

	protected static Enum119 smethod_3(string value)
	{
		return value switch
		{
			"fromT" => Enum119.const_4, 
			"fromR" => Enum119.const_3, 
			"fromL" => Enum119.const_2, 
			"fromB" => Enum119.const_1, 
			_ => Enum119.const_0, 
		};
	}

	protected static double smethod_4(string value, double defaultValue)
	{
		try
		{
			return XmlConvert.ToDouble(value);
		}
		catch (FormatException)
		{
			Console.WriteLine("Parsing error double value: " + value);
			return defaultValue;
		}
	}
}
