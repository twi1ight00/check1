using System.Text.RegularExpressions;

namespace ns322;

internal class Class7421 : Class7400
{
	private Interface401 interface401_0;

	public Class7397 method_4(Class7398 target, Class7397[] parameters)
	{
		return interface401_0.StringClass.method_5(target.ToString());
	}

	public static Class7397 smethod_0(Class7435 regex, Class7397[] parameters)
	{
		return regex["lastIndex"];
	}

	public Class7397 method_5(Class7435 regexp, Class7397[] parameters)
	{
		Class7427 @class = interface401_0.ArrayClass.method_4();
		string text = parameters[0].ToString();
		@class["input"] = interface401_0.StringClass.method_5(text);
		int num = 0;
		MatchCollection matchCollection = Regex.Matches(text, regexp.Pattern, regexp.Options);
		if (matchCollection.Count > 0)
		{
			if (regexp.IsGlobal)
			{
				foreach (Match item in matchCollection)
				{
					@class[interface401_0.NumberClass.method_4(num++)] = interface401_0.StringClass.method_5(item.Value);
				}
			}
			else
			{
				foreach (Group group in matchCollection[0].Groups)
				{
					@class[interface401_0.NumberClass.method_4(num++)] = interface401_0.StringClass.method_5(group.Value);
				}
			}
			@class["index"] = interface401_0.NumberClass.method_4(matchCollection[0].Index);
		}
		return @class;
	}

	public Class7397 method_6(Class7435 regex, Class7397[] parameters)
	{
		return interface401_0.BooleanClass.method_4(method_5(regex, parameters) != Class7433.class7433_0);
	}

	public override Class7397 vmethod_25(Interface396 visitor, Class7398 that, Class7397[] parameters)
	{
		Class7397 result;
		if (string_21 == "toString")
		{
			result = method_4(that, parameters);
		}
		else if (string_21 == "toLocaleString")
		{
			result = method_4(that, parameters);
		}
		else if (string_21 == "lastIndex")
		{
			result = smethod_0(that as Class7435, parameters);
		}
		else if (string_21 == "exec")
		{
			result = method_5(that as Class7435, parameters);
		}
		else
		{
			if (!(string_21 == "test"))
			{
				throw new Exception89("unknown error function");
			}
			result = method_6(that as Class7435, parameters);
		}
		visitor.imethod_36(result);
		return result;
	}

	public override string ToString()
	{
		return $"function {base.Name}";
	}

	public Class7421(Interface401 global, string name, Class7399 prototype)
		: base(prototype)
	{
		string_21 = name;
		interface401_0 = global;
	}
}
