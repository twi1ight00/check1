namespace ns62;

internal class Class2945
{
	private Class2945()
	{
	}

	public static Class2944 smethod_0(Class2670 frame)
	{
		return smethod_1(frame, 1);
	}

	public static Class2944 smethod_1(Class2670 frame, int block)
	{
		if (frame != null)
		{
			Class2944 @class = ((block != 1) ? ((frame.ShapeTertiaryOptions != null) ? frame.ShapeTertiaryOptions.Properties : null) : ((frame.ShapePrimaryOptions != null) ? frame.ShapePrimaryOptions.Properties : null));
			if (@class != null)
			{
				return @class;
			}
		}
		return null;
	}

	public static Class2910 smethod_2(Class2670 frame, Enum426 index)
	{
		return smethod_0(frame)?[index];
	}

	public static Class2911 smethod_3(Class2670 frame, Enum426 index)
	{
		return smethod_2(frame, index) as Class2911;
	}

	public static Class2911 smethod_4(Class2670 frame, Class2670 masterFrame, Enum426 index)
	{
		Class2910 @class = smethod_2(frame, index);
		if (@class == null && masterFrame != null)
		{
			return smethod_2(masterFrame, index) as Class2911;
		}
		return @class as Class2911;
	}

	public static Class2930 smethod_5(Class2670 frame, Enum426 index)
	{
		return smethod_2(frame, index) as Class2930;
	}

	public static Class2930 smethod_6(Class2670 frame, Class2670 masterFrame, Enum426 index)
	{
		Class2910 @class = smethod_2(frame, index);
		if (@class == null && masterFrame != null)
		{
			return smethod_2(masterFrame, index) as Class2930;
		}
		return smethod_2(frame, index) as Class2930;
	}

	public static uint smethod_7(Class2834 fopt, Enum426 id, uint defValue)
	{
		Class2944 properties = fopt.Properties;
		if (properties != null && properties.Contains(id))
		{
			return ((Class2911)properties[id]).Value;
		}
		return defValue;
	}

	public static uint smethod_8(Class2670 frame, Enum426 id, uint defValue)
	{
		Class2944 @class = smethod_0(frame);
		if (@class != null && @class.Contains(id))
		{
			return ((Class2911)@class[id]).Value;
		}
		return defValue;
	}

	public static int smethod_9(Class2670 frame, Class2670 masterFrame, Enum426 id, int defValue)
	{
		Class2944 @class = smethod_0(frame);
		object obj = null;
		if (@class != null)
		{
			obj = @class[id];
		}
		if (obj == null && masterFrame != null)
		{
			@class = smethod_0(masterFrame);
			if (@class != null)
			{
				obj = @class[id];
			}
		}
		if (obj == null)
		{
			return defValue;
		}
		return (int)((Class2911)obj).Value;
	}

	public static uint smethod_10(Class2670 frame, Class2670 masterFrame, Enum426 id, uint defValue)
	{
		Class2944 @class = smethod_0(frame);
		object obj = null;
		if (@class != null)
		{
			obj = @class[id];
		}
		if (obj == null && masterFrame != null)
		{
			@class = smethod_0(masterFrame);
			if (@class != null)
			{
				obj = @class[id];
			}
		}
		if (obj == null)
		{
			return defValue;
		}
		return ((Class2911)obj).Value;
	}

	public static void smethod_11(Class2670 frame, Enum426 id, uint value, uint defValue)
	{
		Class2944 @class = smethod_0(frame);
		if (@class != null)
		{
			if (value != defValue)
			{
				@class[id] = new Class2911(id, isBid: false, value);
			}
			else
			{
				@class.Remove(id);
			}
		}
	}
}
