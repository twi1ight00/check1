using System;
using System.Collections.Generic;
using System.Drawing;
using ns224;
using ns271;

namespace ns161;

internal class Class4860
{
	[ThreadStatic]
	private static Class4860 class4860_0;

	private Class4859 class4859_0 = new Class4859();

	private float float_0 = 1.5f;

	private Dictionary<Class5999, float> dictionary_0 = new Dictionary<Class5999, float>();

	private Class5999 class5999_0;

	internal Class5999 TimesNewRoman
	{
		get
		{
			if (class5999_0 == null)
			{
				class5999_0 = Class6652.Instance.method_1("Times New Roman", 10f, FontStyle.Regular);
			}
			return class5999_0;
		}
	}

	internal Dictionary<Class5999, float> WhitSpaceSizes => dictionary_0;

	public float RelativeHorizontalProximity
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

	public Class4859 Options
	{
		get
		{
			return class4859_0;
		}
		set
		{
			class4859_0 = value;
		}
	}

	public static Class4860 Instance
	{
		get
		{
			if (class4860_0 == null)
			{
				class4860_0 = new Class4860();
			}
			return class4860_0;
		}
	}

	private Class4860()
	{
	}

	public void Clear()
	{
		dictionary_0.Clear();
		dictionary_0 = null;
		class4859_0 = null;
		class4860_0 = null;
	}
}
