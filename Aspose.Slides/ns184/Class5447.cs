using System;
using System.Collections;

namespace ns184;

internal class Class5447
{
	protected string string_0;

	protected string string_1;

	protected bool bool_0;

	protected bool bool_1;

	protected Class5448 class5448_0 = Class5448.smethod_0("auto");

	protected string string_2;

	protected string string_3;

	private ArrayList arrayList_0;

	private bool bool_2 = true;

	public Class5447(string metricsFile, bool kerning, bool advanced, ArrayList fontTriplets, string embedFile, string subFontName)
	{
		string_0 = metricsFile;
		string_1 = embedFile;
		bool_0 = kerning;
		bool_1 = advanced;
		arrayList_0 = fontTriplets;
		string_3 = subFontName;
	}

	public string method_0()
	{
		return string_0;
	}

	public string method_1()
	{
		return string_1;
	}

	public bool method_2()
	{
		return bool_0;
	}

	public bool method_3()
	{
		return bool_1;
	}

	public string method_4()
	{
		return string_3;
	}

	public string method_5()
	{
		return string_2;
	}

	public void method_6(string postScriptNamE)
	{
		string_2 = postScriptNamE;
	}

	public ArrayList method_7()
	{
		return arrayList_0;
	}

	public bool method_8()
	{
		if (string_0 != null && string_1 == null)
		{
			return false;
		}
		return bool_2;
	}

	public void method_9(bool value)
	{
		bool_2 = value;
	}

	public Class5448 method_10()
	{
		return class5448_0;
	}

	public void method_11(Class5448 mode)
	{
		if (mode == null)
		{
			throw new NullReferenceException("mode must not be null");
		}
		class5448_0 = mode;
	}

	public override string ToString()
	{
		return string.Concat("metrics-url=", string_0, ", embed-url=", string_1, ", kerning=", bool_0, ", advanced=", bool_1, ", enc-mode=", class5448_0, ", font-triplet=", arrayList_0, (method_4() != null) ? (", sub-font=" + method_4()) : string.Empty, method_8() ? string.Empty : ", NOT embedded");
	}
}
