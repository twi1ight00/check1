namespace ns52;

internal class Class1141
{
	private static int int_0;

	private static bool bool_0;

	private static bool bool_1;

	private static int int_1;

	internal static int SignatureInvalidFlag
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	internal static int MethodCalledFlag1
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	internal static bool MethodCalledFlag2
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

	internal static bool DummyProperty1
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

	static Class1141()
	{
		Clear();
	}

	internal static void Clear()
	{
		int_0 = 48;
		bool_0 = true;
		int_1 = 0;
	}

	internal static int smethod_0()
	{
		if (int_0 == 128 && !bool_0)
		{
			return 256;
		}
		return 4096;
	}
}
