using System.Collections;
using System.Globalization;
using ns177;
using ns195;

namespace ns180;

internal class Class5596 : Class5595
{
	internal class Class5597
	{
		private Hashtable hashtable_0;

		public Class5597 method_0(string name, object value)
		{
			if (hashtable_0 == null)
			{
				hashtable_0 = new Hashtable();
			}
			hashtable_0.Add(name, value);
			return this;
		}

		public Hashtable method_1()
		{
			return hashtable_0;
		}
	}

	private string string_0;

	private string string_1;

	private Class5598 class5598_0;

	private CultureInfo cultureInfo_0;

	private Hashtable hashtable_0;

	public Class5596(object source, string eventID, Class5598 severity, Hashtable @params)
		: this(source, eventID, severity, CultureInfo.CurrentCulture, @params)
	{
	}

	public Class5596(object source, string eventID, Class5598 severity, CultureInfo locale, Hashtable @params)
		: base(source)
	{
		int num = eventID.LastIndexOf('.');
		if (num >= 0 && num != eventID.Length - 1)
		{
			string_0 = Class5479.smethod_0(eventID, 0, num);
			string_1 = eventID.Substring(num + 1);
		}
		else
		{
			string_1 = eventID;
		}
		method_5(severity);
		cultureInfo_0 = locale;
		hashtable_0 = @params;
	}

	public string method_1()
	{
		if (string_0 == null)
		{
			return string_1;
		}
		return string_0 + '.' + string_1;
	}

	public string method_2()
	{
		return string_0;
	}

	public string method_3()
	{
		return string_1;
	}

	public Class5598 method_4()
	{
		return class5598_0;
	}

	public void method_5(Class5598 severitY)
	{
		class5598_0 = severitY;
	}

	public CultureInfo method_6()
	{
		return cultureInfo_0;
	}

	public object method_7(string key)
	{
		if (hashtable_0 != null)
		{
			return hashtable_0[key];
		}
		return null;
	}

	public Hashtable method_8()
	{
		return hashtable_0;
	}

	public static Class5597 smethod_0()
	{
		return new Class5597();
	}
}
