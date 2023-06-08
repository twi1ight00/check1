using System;
using System.Collections;
using System.IO;
using ns206;

namespace ns184;

internal class Class5458
{
	internal class Class5460 : Interface193
	{
		private bool bool_0;

		internal Class5460(bool useComplexScriptFeatures)
		{
			bool_0 = useComplexScriptFeatures;
		}

		public Stream imethod_0(string href)
		{
			throw new NotImplementedException();
		}

		public bool imethod_1()
		{
			return bool_0;
		}
	}

	public static bool bool_0 = true;

	private string string_0;

	private Class5452 class5452_0;

	private bool bool_1;

	private Class5732.Interface242 interface242_0;

	public virtual void vmethod_0(string fontBasE)
	{
		string_0 = fontBasE;
	}

	public string method_0()
	{
		return string_0;
	}

	public bool method_1()
	{
		return bool_1;
	}

	public void method_2(bool value)
	{
		bool_1 = value;
	}

	public void method_3(Class5452 substitutions)
	{
		class5452_0 = substitutions;
	}

	protected Class5452 method_4()
	{
		if (class5452_0 == null)
		{
			class5452_0 = new Class5452();
		}
		return class5452_0;
	}

	public void method_5(Stream cacheFile)
	{
	}

	public Stream method_6()
	{
		return null;
	}

	public void method_7(bool useCache)
	{
	}

	public bool method_8()
	{
		return false;
	}

	public void method_9()
	{
	}

	public bool method_10()
	{
		return true;
	}

	public void method_11(Class5730 fontInfo, Interface195[] fontCollections)
	{
		int start = 1;
		int i = 0;
		for (int num = fontCollections.Length; i < num; i++)
		{
			start = fontCollections[i].imethod_0(start, fontInfo);
		}
		method_4().method_0(fontInfo);
	}

	public static Interface193 smethod_0(bool useComplexScriptFeatures)
	{
		return new Class5460(useComplexScriptFeatures);
	}

	public void method_12(Class5732.Interface242 matcher)
	{
		interface242_0 = matcher;
	}

	public Class5732.Interface242 method_13()
	{
		return interface242_0;
	}

	public void method_14(ArrayList fontInfoList)
	{
		Class5732.Interface242 matcher = method_13();
		method_15(fontInfoList, matcher);
	}

	public void method_15(ArrayList fontInfoList, Class5732.Interface242 matcher)
	{
		if (matcher == null)
		{
			return;
		}
		foreach (Class5447 fontInfo in fontInfoList)
		{
			foreach (Class5732 item in fontInfo.method_7())
			{
				if (matcher.imethod_0(item))
				{
					fontInfo.method_9(value: false);
					break;
				}
			}
		}
	}
}
