using System.Collections.Generic;
using ns73;
using ns76;

namespace ns84;

internal class Class4143 : Interface96
{
	private Dictionary<string, Class4260> dictionary_0 = new Dictionary<string, Class4260>();

	private Class4142 class4142_0;

	public Class4260 this[string styleName]
	{
		get
		{
			if (string.IsNullOrEmpty(styleName))
			{
				styleName = "decimal";
			}
			styleName = styleName.ToLower();
			if (dictionary_0.ContainsKey(styleName))
			{
				return dictionary_0[styleName];
			}
			Class4260 @class = class4142_0.method_0(styleName);
			if (dictionary_0.ContainsKey(@class.StyleName))
			{
				return dictionary_0[@class.StyleName];
			}
			@class.method_0(this);
			dictionary_0.Add(@class.StyleName, @class);
			return @class;
		}
	}

	public Class4143(Class4142 factory)
	{
		class4142_0 = factory;
	}

	public void method_0(Class3709 style)
	{
		string key = style.Name.ToLower();
		if (dictionary_0.ContainsKey(key))
		{
			Class4260 @class = dictionary_0[key];
			@class.Type = Class4342.smethod_1<Class4260.Enum500>(style.CounterType);
			@class.Prefix = style.Prefix;
			@class.Suffix = style.Suffix;
			@class.Fallback = style.Fallback;
			@class.Glyphs.Clear();
			@class.Glyphs.AddRange(style.Glyphs);
		}
		else
		{
			Class4260 class2 = new Class4260(style.Name);
			class2.Type = Class4342.smethod_1<Class4260.Enum500>(style.CounterType);
			class2.Prefix = style.Prefix;
			class2.Suffix = style.Suffix;
			class2.Fallback = style.Fallback;
			class2.Glyphs.AddRange(style.Glyphs);
			class2.method_0(this);
			dictionary_0.Add(key, class2);
		}
	}
}
