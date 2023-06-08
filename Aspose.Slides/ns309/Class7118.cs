namespace ns309;

internal class Class7118
{
	public string string_0;

	public string string_1;

	public string string_2;

	public bool bool_0;

	public string string_3;

	public string string_4;

	public string string_5;

	public string string_6;

	public string string_7;

	public string string_8;

	public string string_9;

	public string string_10;

	public string string_11;

	public string string_12;

	public int int_0;

	public int int_1;

	public Class7118()
	{
	}

	public Class7118(Class7118 info)
	{
		vmethod_0(info);
	}

	public virtual void vmethod_0(Class7118 info)
	{
		if (info == null)
		{
			string_10 = null;
			string_11 = null;
			string_12 = null;
			string_3 = null;
			string_4 = null;
			string_5 = null;
			string_6 = null;
			string_7 = null;
			bool_0 = false;
			string_8 = null;
			string_9 = null;
			string_0 = null;
			string_1 = null;
			string_2 = null;
		}
		else
		{
			string_0 = info.string_0;
			string_1 = info.string_1;
			string_2 = info.string_2;
			string_3 = info.string_3;
			string_4 = info.string_4;
			string_5 = info.string_5;
			string_6 = info.string_6;
			string_7 = info.string_7;
			string_8 = info.string_8;
			string_9 = info.string_9;
			bool_0 = info.bool_0;
			string_10 = info.string_10;
			string_11 = info.string_11;
			string_12 = info.string_12;
		}
	}

	public static bool smethod_0(Class7118 info, Class7118 infoNext)
	{
		if (info == null)
		{
			if (infoNext == null)
			{
				return true;
			}
			return false;
		}
		if (infoNext == null)
		{
			return false;
		}
		if (info.string_3 == null != (infoNext.string_3 == null))
		{
			return false;
		}
		if (info.bool_0 != infoNext.bool_0)
		{
			return false;
		}
		bool flag = info.string_4 != null && info.string_5 != null;
		bool flag2 = infoNext.string_4 != null && infoNext.string_5 != null;
		return flag == flag2;
	}
}
